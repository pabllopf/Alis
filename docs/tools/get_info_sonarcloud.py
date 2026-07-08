#!/usr/bin/env python3
"""
SonarCloud Coverage Delta Extractor (AI-Optimized)
Strictly follows: Project specification v1.0 + AI-ready enrichment
"""

import os
import sys
import json
import re
from pathlib import Path
import argparse
import requests
from datetime import datetime, timezone

# ─────────────────────────────────────────────────────────────
# CONFIGURATION & CONSTANTS (DEFAULTS, OVERWRITABLE VIA CLI)
# ─────────────────────────────────────────────────────────────
DEFAULT_PROJECT_KEY = "pabllopf-official_alis"
DEFAULT_BRANCH = "master"
SONAR_URL = "https://sonarcloud.io/api"
MEMORY_DIR = Path("./.memory/coverage")

STATE_DIR = MEMORY_DIR / "state"
TASKS_DIR = MEMORY_DIR / "tasks"
TESTS_DIR = MEMORY_DIR / "tests"
PATTERNS_DIR = MEMORY_DIR / "patterns"
DECISIONS_DIR = MEMORY_DIR / "decisions"
LOGS_DIR = MEMORY_DIR / "logs"

REQUIRED_METRICS = ["coverage", "line_coverage", "branch_coverage", 
                    "uncovered_lines", "conditions_to_cover", "uncovered_conditions",
                    "complexity", "ncloc"]

# ─────────────────────────────────────────────────────────────
# CLI ARGUMENT PARSER
# ─────────────────────────────────────────────────────────────

def parse_args():
    parser = argparse.ArgumentParser(
        description="Extract SonarCloud coverage deltas and format as AI-ready tasks.",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
Examples:
  python extractor.py                          # Interactive mode (default)
  python extractor.py --clean                  # Force clean memory & run
  python extractor.py --no-clean               # Force resume mode & run
  python extractor.py --limit 15               # Extract max 15 files
  python extractor.py --project-key my_proj --branch develop
  python extractor.py --output tasks.md        # Save output to file
  python extractor.py --quiet                  # Suppress info logs
"""
    )
    parser.add_argument("--clean", action="store_true", help="Force clean local coverage memory/cache")
    parser.add_argument("--no-clean", action="store_true", help="Force resume mode (load existing state)")
    parser.add_argument("--project-key", default=DEFAULT_PROJECT_KEY, help="SonarCloud project key")
    parser.add_argument("--branch", default=DEFAULT_BRANCH, help="Target branch (default: master)")
    parser.add_argument("--limit", "-n", type=int, default=None, help="Max number of files to extract (default: no limit)")
    parser.add_argument("--output", "-o", default=None, help="Output file path (defaults to stdout)")
    parser.add_argument("--quiet", "-q", action="store_true", help="Suppress non-essential logs")
    parser.add_argument("--fetch-source", action="store_true", help="Fetch source code via SonarCloud API (slower, AI-ready)")
    return parser.parse_args()

# ─────────────────────────────────────────────────────────────
# MEMORY MANAGEMENT (STATE MACHINE)
# ─────────────────────────────────────────────────────────────

def ask_clean_memory() -> bool:
    """EXACT prompt as specified. Only called in interactive mode."""
    response = input("Do you want to clean the local coverage remediation memory/cache? (yes/no)\n").strip().lower()
    return response in ("yes", "y")

def clean_memory():
    """Delete specified state dirs and recreate structure."""
    print("[INFO] Cleaning local coverage remediation memory...")
    dirs_to_clean = [
        STATE_DIR / "state", TASKS_DIR, TESTS_DIR, 
        PATTERNS_DIR, DECISIONS_DIR, LOGS_DIR
    ]
    for d in dirs_to_clean:
        if d.exists():
            import shutil
            shutil.rmtree(d)
    for json_file in MEMORY_DIR.rglob("*.json"):
        json_file.unlink()
    init_memory_structure()

def init_memory_structure():
    """Recreate the exact Obsidian directory structure."""
    for d in [STATE_DIR, TASKS_DIR, TESTS_DIR, PATTERNS_DIR, DECISIONS_DIR, LOGS_DIR]:
        d.mkdir(parents=True, exist_ok=True)

def load_coverage_index() -> dict:
    """Parse existing coverage-index.md or return empty state."""
    index_file = STATE_DIR / "coverage-index.md"
    if not index_file.exists():
        return {}
    
    data = {}
    with open(index_file, "r", encoding="utf-8") as f:
        content = f.read()
    file_match = re.findall(r"### File\s*\n(.*?)(?:\n|$)", content)
    cov_match = re.findall(r"### Coverage\s*\n(.*?)(?:\n|$)", content)
    method_match = re.findall(r"### Method\s*\n(.*?)(?:\n|$)", content)
    lines_match = re.findall(r"### Uncovered Lines\s*\n(.*?)(?:\n|$)", content)
    
    for f, c, m, l in zip(file_match, cov_match, method_match, lines_match):
        data[f.strip()] = {
            "coverage": c.strip(),
            "method": m.strip(),
            "uncovered_lines": l.strip()
        }
    return data

# ─────────────────────────────────────────────────────────────
# SONARCLOUD API CLIENT (PAGINATION & SOURCE EXTRACTION)
# ─────────────────────────────────────────────────────────────

def get_sonar_token() -> str:
    token = os.getenv("SONARCLOUD_TOKEN")
    if not token:
        print("[ERROR] SONARCLOUD_TOKEN environment variable is missing.")
        sys.exit(1)
    return token

def fetch_sonarcloud_data(project_key: str, branch: str) -> list[dict]:
    """Fetch current coverage state from SonarCloud with pagination."""
    token = get_sonar_token()
    headers = {"Authorization": f"Bearer {token}"}
    url = f"{SONAR_URL}/measures/component_tree"
    
    params = {
        "component": project_key,
        "metricKeys": ",".join(REQUIRED_METRICS),
        "qualifiers": "FIL",
        "branch": branch,
        "p": 1,
        "ps": 100
    }
    
    all_files = []
    page = 1
    while True:
        params["p"] = page
        resp = requests.get(url, headers=headers, params=params, timeout=30)
        if resp.status_code != 200:
            print(f"[ERROR] SonarCloud API failed: {resp.status_code} {resp.text}")
            sys.exit(1)
            
        data = resp.json()
        components = data.get("components", [])
        if not components:
            break
            
        all_files.extend(components)
        if data.get("paging", {}).get("isLast", True):
            break
        page += 1
        
    return all_files

def fetch_source_snippet(project_key: str, file_key: str, max_lines: int = 60) -> str:
    """Fetch source code via SonarCloud API with line limits for AI readability."""
    token = get_sonar_token()
    headers = {"Authorization": f"Bearer {token}"}
    url = f"{SONAR_URL}/sources/raw"
    
    try:
        resp = requests.get(url, headers=headers, params={"key": file_key}, timeout=15)
        if resp.status_code == 200:
            lines = resp.text.splitlines()[:max_lines]
            return "\n".join(lines)
    except Exception:
        pass
    return "// [Source code unavailable or rate-limited. Use /api/sources/raw?key=" + file_key + "]"

# ─────────────────────────────────────────────────────────────
# DELTA ENGINE & TASK FORMATTER (AI-ENRICHED)
# ─────────────────────────────────────────────────────────────

def compute_deltas(current_files: list[dict], previous_state: dict, limit: int = None) -> list[dict]:
    """Identify new uncovered files, reduced coverage, and degraded methods. Apply priority & limit."""
    deltas = []
    
    for comp in current_files:
        key = comp.get("key", "")
        measures = comp.get("measures", [])
        
        cov_val = next((m.get("value") for m in measures if m.get("metric") == "coverage"), None)
        line_cov = next((m.get("value") for m in measures if m.get("metric") == "line_coverage"), None)
        branch_cov = next((m.get("value") for m in measures if m.get("metric") == "branch_coverage"), None)
        lines_val = next((m.get("value") for m in measures if m.get("metric") == "uncovered_lines"), None)
        branches_val = next((m.get("value") for m in measures if m.get("metric") == "uncovered_conditions"), None)
        complexity = next((m.get("value") for m in measures if m.get("metric") == "complexity"), None)
        loc = next((m.get("value") for m in measures if m.get("metric") == "ncloc"), None)
        lang = comp.get("language", "csharp")
        
        if cov_val is None or float(cov_val) >= 100.0:
            continue
            
        prev = previous_state.get(key, {})
        prev_cov = float(prev.get("coverage", 0)) if prev.get("coverage") else 0.0
        
        is_new = key not in previous_state
        is_degraded = float(cov_val) < prev_cov
        
        if is_new or is_degraded:
            priority = "LOW"
            if is_degraded or float(cov_val) < 60:
                priority = "HIGH"
            elif is_new or float(cov_val) < 80:
                priority = "MEDIUM"
                
            deltas.append({
                "file": key,
                "language": lang,
                "coverage": cov_val,
                "line_coverage": line_cov,
                "branch_coverage": branch_cov,
                "uncovered_lines": lines_val,
                "uncovered_branches": branches_val,
                "complexity": complexity,
                "loc": loc,
                "method": key.split(".")[-1],
                "is_new": is_new,
                "is_degraded": is_degraded,
                "priority": priority
            })
            
    priority_order = {"HIGH": 0, "MEDIUM": 1, "LOW": 2}
    deltas.sort(key=lambda x: (priority_order.get(x["priority"], 3), float(x["coverage"] or 100)))
    
    if limit is not None:
        deltas = deltas[:limit]
        
    return deltas

def format_coverage_task(delta: dict, fetch_source: bool = False) -> str:
    """Format exactly as specified in REQUIRED INPUT FORMAT, enriched for AI consumption."""
    source_code = "// [Source code omitted. Use --fetch-source to extract.]"
    if fetch_source:
        source_code = fetch_source_snippet(
            os.getenv("PROJECT_KEY", "pabllopf-official_alis"), 
            delta["file"]
        )
        
    test_hint = delta["file"].replace("src/", "test/").replace(".cs", ".Tests.cs")
    
    return f"""
    ## COVERAGE TASK

    ### File
    {delta['file']}

    ### Language
    {delta['language']}

    ### Coverage
    {delta['coverage']}% (Line: {delta['line_coverage']}%, Branch: {delta['branch_coverage']}%)

    ### Uncovered Lines
    {delta['uncovered_lines']}

    ### Uncovered Branches
    {delta['uncovered_branches']}

    ### Method
    {delta['method']}

    ### Complexity / LOC
    {delta['complexity']} / {delta['loc']} lines

    ### Source Code
    ```csharp
    {source_code}
    ```
    
    ### Test File Hint
    {test_hint}

    Priority
    {delta['priority']} ({"NEW" if delta['is_new'] else "DEGRADED"})

    AI Execution Instructions
    Generate xUnit test targeting {delta['file']}
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage {delta['file'].split('/')[-1]}
    Update ./.memory/coverage/state/coverage-index.md after completion
            """

# ─────────────────────────────────────────────────────────────
# MAIN EXECUTION FLOW (CLI + INTERACTIVE FALLBACK)
# ─────────────────────────────────────────────────────────────

def main():
  args = parse_args()
  project_key = args.project_key
  branch = args.branch

  should_clean = None
  if args.clean:
      should_clean = True
  elif args.no_clean:
      should_clean = False
  else:
      should_clean = ask_clean_memory()

  if should_clean:
      clean_memory()
  else:
      init_memory_structure()
      
  previous_state = {} if should_clean else load_coverage_index()

  if not args.quiet:
      print("[INFO] Fetching current SonarCloud coverage state...")
  current_files = fetch_sonarcloud_data(project_key, branch)

  if not args.quiet:
      print("[INFO] Computing coverage deltas...")
  deltas = compute_deltas(current_files, previous_state, limit=args.limit)

  try:
      if args.output:
          with open(args.output, "w", encoding="utf-8") as out:
              if not deltas:
                  if not args.quiet:
                      print("[INFO] No coverage delta detected. STOP IMMEDIATELY (as specified).", file=out)
                  return
                  
              if not args.quiet:
                  limit_str = f" (limited to {args.limit} files)" if args.limit else ""
                  print(f"\n[INFO] Found {len(deltas)} coverage targets.{limit_str} Outputting AI-ready tasks:\n", file=out)
                  
              for delta in deltas:
                  out.write(format_coverage_task(delta, fetch_source=args.fetch_source))
                  out.write("\n" + "="*50 + "\n")
      else:
          if not deltas:
              if not args.quiet:
                  print("[INFO] No coverage delta detected. STOP IMMEDIATELY (as specified).")
              return
                  
          if not args.quiet:
              limit_str = f" (limited to {args.limit} files)" if args.limit else ""
              print(f"\n[INFO] Found {len(deltas)} coverage targets.{limit_str} Outputting AI-ready tasks:\n")
              
          for delta in deltas:
              print(format_coverage_task(delta, fetch_source=args.fetch_source))
              print("="*50)
  except Exception as e:
      print(f"[ERROR] Failed to write output: {e}", file=sys.stderr)
      sys.exit(1)


if __name__ == "__main__":
    main()
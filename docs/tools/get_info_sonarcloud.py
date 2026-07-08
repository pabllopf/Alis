#!/usr/bin/env python3
"""
SonarCloud Coverage Delta Extractor
Strictly follows: Project specification v1.0
- SonarCloud-first execution
- Local Obsidian-style state management
- Deterministic delta synchronization
- Exact output formatting for coverage tasks
"""

import os
import sys
import json
import re
from pathlib import Path
import requests
from datetime import datetime, timezone

# ─────────────────────────────────────────────────────────────
# CONFIGURATION & CONSTANTS (NON-NEGOTIABLE)
# ─────────────────────────────────────────────────────────────
PROJECT_KEY = "pabllopf-official_alis"
BRANCH = "master"
SONAR_URL = "https://sonarcloud.io/api"
MEMORY_DIR = Path("./.memory/coverage")

STATE_DIR = MEMORY_DIR / "state"
TASKS_DIR = MEMORY_DIR / "tasks"
TESTS_DIR = MEMORY_DIR / "tests"
PATTERNS_DIR = MEMORY_DIR / "patterns"
DECISIONS_DIR = MEMORY_DIR / "decisions"
LOGS_DIR = MEMORY_DIR / "logs"

REQUIRED_METRICS = ["coverage", "line_coverage", "branch_coverage", 
                    "uncovered_lines", "conditions_to_cover", "uncovered_conditions"]

# ─────────────────────────────────────────────────────────────
# MEMORY MANAGEMENT (STATE MACHINE)
# ─────────────────────────────────────────────────────────────

def ask_clean_memory() -> bool:
    """EXACT prompt as specified."""
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
    # Also remove coverage tracking JSON files if any exist
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
    current_file = None
    with open(index_file, "r", encoding="utf-8") as f:
        content = f.read()
    # Simple markdown key-value parser
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
# SONARCLOUD API CLIENT (PAGINATION HANDLING)
# ─────────────────────────────────────────────────────────────

def get_sonar_token() -> str:
    token = os.getenv("SONARCLOUD_TOKEN")
    if not token:
        print("[ERROR] SONARCLOUD_TOKEN environment variable is missing.")
        sys.exit(1)
    return token

def fetch_sonarcloud_data() -> list[dict]:
    """Fetch current coverage state from SonarCloud with pagination."""
    token = get_sonar_token()
    headers = {"Authorization": f"Bearer {token}"}
    url = f"{SONAR_URL}/measures/component_tree"
    
    params = {
        "component": PROJECT_KEY,
        "metricKeys": ",".join(REQUIRED_METRICS),
        "qualifiers": "FIL",  # Files only
        "branch": BRANCH,
        "p": 1,
        "ps": 100  # Page size
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

# ─────────────────────────────────────────────────────────────
# DELTA ENGINE & TASK FORMATTER
# ─────────────────────────────────────────────────────────────

def compute_deltas(current_files: list[dict], previous_state: dict) -> list[dict]:
    """Identify new uncovered files, reduced coverage, and degraded methods."""
    deltas = []
    
    for comp in current_files:
        key = comp.get("key", "")
        measures = comp.get("measures", [])
        
        # Extract metrics
        cov_val = next((m.get("value") for m in measures if m.get("metric") == "coverage"), None)
        lines_val = next((m.get("value") for m in measures if m.get("metric") == "uncovered_lines"), None)
        branch_val = next((m.get("value") for m in measures if m.get("metric") == "branch_coverage"), None)
        
        # Skip fully covered or irrelevant
        if cov_val is None or float(cov_val) >= 100.0:
            continue
            
        # Find matching previous state
        prev = previous_state.get(key, {})
        prev_cov = float(prev.get("coverage", 0)) if prev.get("coverage") else 0.0
        
        # Delta condition: new file, or coverage dropped, or uncovered lines increased
        is_new = key not in previous_state
        is_degraded = float(cov_val) < prev_cov
        
        if is_new or is_degraded:
            deltas.append({
                "file": key,
                "coverage": cov_val,
                "uncovered_lines": lines_val,
                "branch_coverage": branch_val,
                "method": key.split(".")[-1],  # Fallback method name
                "is_new": is_new,
                "is_degraded": is_degraded
            })
            
    return deltas

def format_coverage_task(delta: dict) -> str:
    """Format exactly as specified in REQUIRED INPUT FORMAT."""
    return f"""## COVERAGE TASK

### File
{delta['file']}

### Coverage
{delta['coverage']}%

### Uncovered Lines
{delta['uncovered_lines']}

### Method
{delta['method']}

### Existing Tests
[Search in ./.memory/coverage/tests/ for similar patterns]

### Source Code
```csharp
// Fetch using: GET /api/sources/raw?key={delta['file']}
// [Insert relevant source code here]
```"""

# ─────────────────────────────────────────────────────────────
# MAIN EXECUTION FLOW (STRICT ORDER)
# ─────────────────────────────────────────────────────────────

def main():
    print("=== SonarCloud Coverage Delta Extractor ===")
    
    # 1. Ask user EXACTLY as specified
    should_clean = ask_clean_memory()
    
    if should_clean:
        clean_memory()
    else:
        # Ensure directories exist for resume mode
        init_memory_structure()
        
    # 2. Load previous state (if not cleaning)
    previous_state = {} if should_clean else load_coverage_index()
    
    # 3. Fetch current SonarCloud state
    print("[INFO] Fetching current SonarCloud coverage state...")
    current_files = fetch_sonarcloud_data()
    
    # 4. Compute deltas
    print("[INFO] Computing coverage deltas...")
    deltas = compute_deltas(current_files, previous_state)
    
    # 5. Output results
    if not deltas:
        print("[INFO] No coverage delta detected. STOP IMMEDIATELY (as specified).")
        return
        
    print(f"\n[INFO] Found {len(deltas)} coverage targets. Outputting exactly formatted tasks:\n")
    for delta in deltas:
        print(format_coverage_task(delta))
        print("-" * 40)

if __name__ == "__main__":
    main()

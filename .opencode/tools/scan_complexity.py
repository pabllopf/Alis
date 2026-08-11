#!/usr/bin/env python3
"""Deterministic cyclomatic & cognitive complexity scanner for .cs files.

Usage:
    python3 scan_complexity.py [root_dir] [--limit N] [--method-limit M]

Prints the top-N most complex methods across the solution as JSONL.
"""

import json
import os
import re
import sys

ROOT = sys.argv[1] if len(sys.argv) > 1 and not sys.argv[1].startswith("--") else "."
LIMIT = 50
METHOD_LIMIT = 15
for arg in sys.argv[1:]:
    if arg.startswith("--limit"):
        LIMIT = int(sys.argv[sys.argv.index(arg) + 1])
    if arg.startswith("--method-limit"):
        METHOD_LIMIT = int(sys.argv[sys.argv.index(arg) + 1])

SKIP_DIRS = {"bin", "obj", ".test", ".git", ".opencode", "docs", ".memory", ".github", "node_modules"}
SKIP_FILE_MARKERS = ("Template", "Generator", "Benchmark", ".Sample")

BRANCH_KEYWORDS = {
    "if": 1, "else if": 1, "for": 1, "foreach": 1, "while": 1, "case": 1,
    "catch": 1, "&&": 1, "||": 1, "?:": 1, "??": 1, "do": 1, "default": 0,
}
COGNITIVE_BASE = {"if", "else if", "for", "foreach", "while", "catch", "case", "goto", "switch", "??", "?:", "&&", "||"}


def strip_strings_and_comments(source):
    source = re.sub(r"///.*", "", source)
    source = re.sub(r"//[^\n]*", "", source)
    source = re.sub(r"/\*.*?\*/", "", source, flags=re.S)
    source = re.sub(r"@\"(?:[^\"]|\"\")*\"", '""', source)
    source = re.sub(r'"(?:[^"\\]|\\.)*"', '""', source)
    return source


def scan_methods(source):
    methods = []
    depth = 0
    current = None
    brace_stack = []
    for lineno, line in enumerate(source.splitlines(), 1):
        stripped = line.strip()
        if not stripped:
            continue
        if "{" in line and "}" in line and not re.match(r"^[\w<>\[\],.? ]+\s+\w+\s*\([^;]*\)\s*\{", stripped):
            continue
        if current is not None:
            current["end"] = lineno
            opens = line.count("{")
            closes = line.count("}")
            current["depth"] += opens - closes
            if current["depth"] <= 0:
                methods.append(current)
                current = None
            else:
                for token in re.findall(r"\b(if|else|for|foreach|while|case|catch|do|switch|goto)\b|&&|\|\||\?|\?\?", line):
                    token = token
                    if token == "?":
                        if "?" + "?" in line:
                            continue
                        token = "?:"
                    if token in ("if", "else if", "for", "foreach", "while", "case", "catch", "do", "switch", "goto", "&&", "||", "??", "?:"):
                        current["cyclomatic"] += 1
                        if token in COGNITIVE_BASE:
                            current["cognitive"] += 1
            continue
        if re.match(r"^\s*(public|private|protected|internal)\s+.*\(", stripped) or re.match(r"^\s*(static|virtual|override|sealed|abstract|async|extern|unsafe|partial|new)\s+.*\(", stripped):
            if "(" in stripped and ")" in stripped and ";" not in stripped.split("{")[0]:
                name_match = re.match(r".*?\s([\w<>\[\],]+)\s*\(", stripped)
                if name_match:
                    opens = line.count("{")
                    closes = line.count("}")
                    current = {
                        "name": stripped[:160],
                        "start": lineno,
                        "end": lineno,
                        "depth": opens - closes,
                        "cyclomatic": 0,
                        "cognitive": 0,
                    }
                    if current["depth"] <= 0:
                        methods.append(current)
                        current = None
        if current is None:
            opens = line.count("{")
            if opens > 0 and re.search(r"\bclass\b|\bstruct\b|\binterface\b|\benum\b|\bnamespace\b|\brecord\b|\bswitch\b", stripped):
                if "{" in stripped:
                    pass
    return methods


def complexity_for_file(path):
    try:
        with open(path, "r", encoding="utf-8", errors="replace") as f:
            src = f.read()
    except (OSError, UnicodeDecodeError):
        return []
    src = strip_strings_and_comments(src)
    methods = []
    # brace-tracking scanner
    lines = src.splitlines()
    stack = []
    current = None
    header_re = re.compile(r"^\s*(?:[\w\[\]<>,\?\.]+\s+)*(?:[\w\[\]<>,\?\.]+)\s*\([^;{}]*\)\s*(?:\{)?\s*$")
    for lineno, line in enumerate(lines, 1):
        stripped = line.strip()
        if current is None:
            m = re.search(r"\)\s*(?:\{|$)", stripped)
            if "(" in stripped and ")" in stripped and ";" not in stripped and header_re.match(stripped):
                is_method = bool(re.search(r"\s[\w\[\]<>]+\s*\([^)]*\)\s*\{?\s*$", stripped))
                is_decl = stripped.endswith(";") or stripped.endswith("=>")
                if is_method and not is_decl and "=" not in stripped.split("(")[0] and not re.match(r".*\b(class|struct|interface|record|enum)\b.*\(", stripped):
                    current = {
                        "name": stripped[:200],
                        "start": lineno,
                        "end": lineno,
                        "depth": 0,
                        "cyclomatic": 1,
                        "cognitive": 0,
                    }
        else:
            opens = line.count("{")
            closes = line.count("}")
            if opens or closes:
                current["depth"] += opens - closes
            else:
                branch = re.search(r"\b(if|else if|else|for|foreach|while|do|case|catch|switch|goto)\b", line)
                if branch:
                    current["cyclomatic"] += 1
                    current["cognitive"] += 1
                if "&&" in line:
                    current["cyclomatic"] += 1
                    current["cognitive"] += 1
                if "||" in line:
                    current["cyclomatic"] += 1
                    current["cognitive"] += 1
                if "? " in line and ": " in line:
                    current["cyclomatic"] += 1
                    current["cognitive"] += 1
            if current["depth"] <= 0:
                methods.append(current)
                current = None
    return methods


def main():
    results = []
    for root, dirs, files in os.walk(ROOT):
        dirs[:] = [d for d in dirs if d not in SKIP_DIRS]
        for f in files:
            if not f.endswith(".cs"):
                continue
            if any(m in f for m in SKIP_FILE_MARKERS):
                continue
            path = os.path.join(root, f)
            for m in complexity_for_file(path):
                results.append({
                    "file": path,
                    "method": m["name"],
                    "line": m["start"],
                    "cyclomatic": m["cyclomatic"],
                    "cognitive": m["cognitive"],
                })
    results.sort(key=lambda r: (r["cyclomatic"], r["cognitive"], r["line"]), reverse=True)
    for r in results[:LIMIT]:
        print(json.dumps(r))
    print(f"TOTAL_METHODS {len(results)}", file=sys.stderr)


if __name__ == "__main__":
    main()

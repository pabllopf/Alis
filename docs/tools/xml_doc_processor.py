#!/usr/bin/env python3
"""
XML Documentation Processor for C# files.

Processing Pipeline (per file):
1. Load file
2. Check cache - skip if status == "completed"
3. Analyze for missing XML docs on top-level types only
4. Add missing XML docs if needed
5. Validate no structural changes
6. Write atomically
7. Update cache
8. Return result

SAFETY FIRST: This processor is EXTREMELY conservative. It ONLY adds XML docs
for top-level type declarations (class, struct, interface, enum, record) that
are clearly missing them. It does NOT remove any comments, and it does NOT
attempt to document methods, properties, or other members.
"""

import json
import re
import sys
from datetime import datetime, timezone
from pathlib import Path

CACHE_PATH = ".opencode/cache/processed_files.json"
REPO_ROOT = Path("/Volumes/d/repositorios/Alis")

# Regex to match a top-level type declaration in a C# file
# Must have one of: class, struct, interface, enum, record
# Must NOT be preceded by /// (would have docs)
TYPE_DECL = re.compile(
    r'^\s*(?:(?:public|internal|private|protected|static|partial|abstract|sealed|readonly|unsafe|new)\s+)*'
    r'(class|struct|interface|enum|record)\s+(\w+)'
)

def load_cache():
    cache_file = REPO_ROOT / CACHE_PATH
    if cache_file.exists():
        with open(cache_file) as f:
            return json.load(f)
    return {}

def save_cache(cache):
    cache_file = REPO_ROOT / CACHE_PATH
    cache_file.parent.mkdir(parents=True, exist_ok=True)
    with open(cache_file, 'w') as f:
        json.dump(cache, f, indent=2)
        f.write('\n')

def should_skip(cache, filepath):
    relpath = str(filepath.relative_to(REPO_ROOT))
    entry = cache.get(relpath)
    if entry and entry.get("status") == "completed":
        return True
    return False

def has_xml_doc_before(lines, idx):
    """Check if a line index has XML doc comments directly before it."""
    i = idx - 1
    while i >= 0:
        line = lines[i].rstrip('\n').rstrip('\r')
        if line.strip() == '':
            i -= 1
            continue
        if line.strip().startswith('///'):
            return True
        if line.strip().startswith('//'):
            return False
        if line.strip().startswith('['):
            # Attribute - check before it
            i -= 1
            continue
        # Something else - no docs
        return False
    return False

def find_types_missing_docs(lines):
    """Find top-level type declarations missing XML docs.
    Returns list of (line_number, type_name, kind) tuples (0-indexed)."""
    missing = []
    
    # Track nesting to only look at top-level declarations
    depth = 0
    in_type_decl = False
    
    for i, raw_line in enumerate(lines):
        line = raw_line.rstrip('\n').rstrip('\r')
        stripped = line.strip()
        
        # Skip empty lines, using directives, comments, preprocessor
        if (not stripped or 
            stripped.startswith('using ') or
            stripped.startswith('///') or
            stripped.startswith('//') or
            stripped.startswith('/*') or
            stripped.startswith('*') or
            stripped.startswith('#') or
            stripped.startswith('namespace ') or
            stripped.startswith('[')):
            continue
        
        # Track braces to know depth
        for ch in line:
            if ch == '{':
                depth += 1
            elif ch == '}':
                depth -= 1
        
        # Only look at depth 0 for top-level declarations
        if depth != 0:
            continue
        
        # Check if this line declares a type
        m = TYPE_DECL.match(stripped)
        if m:
            kind = m.group(1)
            name = m.group(2)
            if not has_xml_doc_before(lines, i):
                missing.append((i, name, kind))
    
    return missing

def add_xml_docs(lines, missing_locations):
    """Add XML documentation for missing type declarations.
    Returns (modified_lines, count_added)."""
    if not missing_locations:
        return lines, 0
    
    # Work in reverse to preserve line indices
    missing_locations.sort(key=lambda x: x[0], reverse=True)
    
    added = 0
    for line_idx, name, kind in missing_locations:
        # Get indentation from the target line
        indent = ''
        if line_idx < len(lines):
            match = re.match(r'^(\s*)', lines[line_idx])
            if match:
                indent = match.group(1)
        
        if kind == 'class':
            summary = f"{indent}/// <summary>\n{indent}///     The {name.lower()} class\n{indent}/// </summary>"
        elif kind == 'struct':
            summary = f"{indent}/// <summary>\n{indent}///     The {name.lower()} struct\n{indent}/// </summary>"
        elif kind == 'interface':
            summary = f"{indent}/// <summary>\n{indent}///     The {name.lower()} interface\n{indent}/// </summary>"
        elif kind == 'enum':
            summary = f"{indent}/// <summary>\n{indent}///     The {name.lower()} enum\n{indent}/// </summary>"
        elif kind == 'record':
            summary = f"{indent}/// <summary>\n{indent}///     The {name.lower()} record\n{indent}/// </summary>"
        else:
            summary = f"{indent}/// <summary>\n{indent}///     The {name.lower()}\n{indent}/// </summary>"
        
        # Insert the doc lines before the declaration
        doc_lines = summary.split('\n')
        for dl in reversed(doc_lines):
            lines.insert(line_idx, dl + '\n')
        added += 1
    
    return lines, added

def validate_no_structural_changes(original, modified):
    """Validate that only comments differ between original and modified."""
    def strip_comments(text):
        # Remove XML docs
        text = re.sub(r'^\s*///.*$', '', text, flags=re.MULTILINE)
        # Remove line comments
        text = re.sub(r'^\s*//.*$', '', text, flags=re.MULTILINE)
        # Remove block comments
        text = re.sub(r'/\*.*?\*/', '', text, flags=re.DOTALL)
        # Normalize whitespace
        text = re.sub(r'\s+', ' ', text)
        return text.strip()
    
    return strip_comments(original) == strip_comments(modified)

def process_file(filepath):
    """Process a single C# file. Returns result dict."""
    relpath = str(filepath.relative_to(REPO_ROOT))
    
    content = filepath.read_text(encoding='utf-8')
    lines = content.split('\n')
    
    # Ensure trailing newline
    if lines and lines[-1] != '':
        lines.append('')
    
    original_text = '\n'.join(lines)
    
    # Phase 1: Find types missing XML docs
    missing = find_types_missing_docs(lines)
    if not missing:
        return {
            "modified": False,
            "xml_added": 0,
            "xml_updated": 0,
            "comments_removed": 0
        }
    
    # Phase 2: Add missing docs
    lines, added = add_xml_docs(lines, missing)
    
    if added == 0:
        return {
            "modified": False,
            "xml_added": 0,
            "xml_updated": 0,
            "comments_removed": 0
        }
    
    new_content = '\n'.join(lines)
    
    # Phase 3: Validate no structural changes
    if not validate_no_structural_changes(original_text, new_content):
        # This should never happen since we only add comments
        return {
            "modified": False,
            "xml_added": 0,
            "xml_updated": 0,
            "comments_removed": 0,
            "validation_failed": True
        }
    
    # Phase 4: Atomic write
    temp_path = filepath.with_suffix('.cs.tmp')
    temp_path.write_text(new_content, encoding='utf-8')
    temp_content = temp_path.read_text(encoding='utf-8')
    
    if validate_no_structural_changes(original_text, temp_content):
        temp_path.replace(filepath)
        return {
            "modified": True,
            "xml_added": added,
            "xml_updated": 0,
            "comments_removed": 0
        }
    else:
        temp_path.unlink()
        return {
            "modified": False,
            "xml_added": 0,
            "xml_updated": 0,
            "comments_removed": 0
        }

def update_cache(cache, filepath, result):
    """Update the cache entry for a file."""
    relpath = str(filepath.relative_to(REPO_ROOT))
    now = datetime.now(timezone.utc).strftime("%Y-%m-%dT%H:%M:%SZ")
    
    entry = cache.get(relpath, {})
    entry["status"] = "completed"
    entry["first_read_at"] = entry.get("first_read_at", now)
    entry["last_processed_at"] = now
    entry["modified"] = result["modified"]
    entry["xml_added"] = entry.get("xml_added", 0) + result["xml_added"]
    entry["xml_updated"] = entry.get("xml_updated", 0) + result["xml_updated"]
    entry["comments_removed"] = entry.get("comments_removed", 0) + result.get("comments_removed", 0)
    
    cache[relpath] = entry

def get_commit_msg(filepath, result):
    name = filepath.name
    if result.get("xml_added", 0) > 0:
        return f"docs: {name} add XML documentation for {result['xml_added']} types"
    return None

def main():
    filepath_str = sys.argv[1] if len(sys.argv) > 1 else None
    dry_run = "--dry-run" in sys.argv
    
    if not filepath_str:
        print(json.dumps({"error": "No file specified"}))
        sys.exit(1)
    
    filepath = REPO_ROOT / filepath_str
    
    if not filepath.exists():
        print(json.dumps({"error": f"File not found: {filepath}"}))
        sys.exit(1)
    
    cache = load_cache()
    
    if should_skip(cache, filepath):
        print(json.dumps({"file": filepath_str, "skipped": True}))
        return
    
    result = process_file(filepath)
    
    if not dry_run:
        update_cache(cache, filepath, result)
        save_cache(cache)
    
    output = {
        "file": filepath_str,
        "modified": result["modified"],
        "xml_added": result["xml_added"],
        "comments_removed": result.get("comments_removed", 0),
        "commit_message": get_commit_msg(filepath, result),
        "validation_failed": result.get("validation_failed", False),
        "skipped": False
    }
    print(json.dumps(output))


if __name__ == "__main__":
    main()

#!/usr/bin/env python3
"""
Safe C# documentation processor.
Rules:
1. Only removes standalone // comments that are provably non-semantic
2. Never removes comments with semantic keywords (PERF, NOTE, IMPORTANT, WHY, COMPLEXITY, DESIGN)
3. Never removes comments adjacent to initialization logic
4. Never removes comments explaining performance, algorithm complexity, or implementation choices
5. Never adds XML docs (files already have them; adding generic ones would be worse)
6. Processes one file at a time, atomically
"""

import sys
import re
import json
import os
from pathlib import Path
from datetime import datetime, timezone

CACHE_PATH = Path("/Users/pabllopf/repositorios/Alis/.opencode/cache/csdoc_processed_files.json")

# Semantic keywords that PROTECT a comment from removal
PROTECTED_KEYWORDS = re.compile(
    r'\b(PERF|NOTE|IMPORTANT|WHY|COMPLEXITY|DESIGN|SECURITY|THREAD|GC|CACHE|BUFFER|INLINE|NOINLINE|BINARY\s*SERIALIZATION|SERIALIZATION|GC\s*RECLAIM|FREE\s*MEMORY|BOUNDS\s*CHECK|VIRTUAL\s*METHOD|INLINE|NON-INLINE)\b',
    re.IGNORECASE
)

# Patterns that indicate a comment is adjacent to initialization logic
INITIALIZATION_PATTERNS = re.compile(
    r'(new\s+\w+|=\s*new|=\s*Array\.|=\s*default|=\s*null|=\s*\[\]|=\s*\{\}|\.Dispose\(\)|\.Clear\(\)|\.Reset\(\)|\.Initialize|\.Init|_pool|_array|_size|_version|_syncRoot|_clearOnFree)',
    re.IGNORECASE
)

# Patterns for comments that explain algorithm steps
ALGORITHM_PATTERNS = re.compile(
    r'(find\s+the|copy\s+item|clear\s+the|move\s+next|end\s+of|first\s+call|enumerat|slot|threshold|free\s+slot|removed\s+element|gc\s*reclaim)',
    re.IGNORECASE
)

def load_cache():
    if CACHE_PATH.exists():
        try:
            with open(CACHE_PATH, 'r') as f:
                return json.load(f)
        except (json.JSONDecodeError, IOError):
            return {}
    return {}

def save_cache(cache):
    CACHE_PATH.parent.mkdir(parents=True, exist_ok=True)
    tmp = str(CACHE_PATH) + ".tmp"
    with open(tmp, 'w') as f:
        json.dump(cache, f, indent=2)
    os.replace(tmp, str(CACHE_PATH))

def is_safe_to_remove(line_text, prev_line_text, next_line_text):
    """
    Determine if a standalone // comment line can be safely removed.
    Returns True only if ALL safety conditions are met.
    """
    stripped = line_text.strip()

    # Must be a standalone line comment (starts with //)
    if not stripped.startswith('//'):
        return False

    # Must NOT contain protected keywords
    if PROTECTED_KEYWORDS.search(stripped):
        return False

    # Must NOT be adjacent to initialization logic (check prev/next lines)
    if prev_line_text and INITIALIZATION_PATTERNS.search(prev_line_text):
        return False
    if next_line_text and INITIALIZATION_PATTERNS.search(next_line_text):
        return False

    # Must NOT explain algorithm steps
    if ALGORITHM_PATTERNS.search(stripped):
        return False

    # Must NOT be a multi-line comment block start
    if stripped.startswith('/*') or stripped.startswith('*'):
        return False

    # Must NOT be a license/copyright header line
    if re.match(r'^//\s*(Copyright|Author|Web:|Licensed|License|All\s+rights)', stripped, re.IGNORECASE):
        return False

    # Must NOT be an #if / #else / #endif region marker
    if stripped.startswith('#if') or stripped.startswith('#else') or stripped.startswith('#endif'):
        return False

    # Must NOT be a using directive comment
    if re.match(r'^//\s*using\s+', stripped, re.IGNORECASE):
        return False

    # Must NOT be a file header metadata line (File:, etc.)
    if re.match(r'^//\s*File:', stripped):
        return False

    # If the comment is redundant with an immediately following XML doc, it's safe to remove
    if next_line_text and next_line_text.strip().startswith('///'):
        return True

    # If the comment is a standalone label (like "// Inicialización") with no semantic content
    # and the next line is a member declaration, it's safe to remove
    if next_line_text:
        next_stripped = next_line_text.strip()
        # Check if next line is a member declaration (method, property, field, type)
        if re.match(r'(public|private|protected|internal|protected\s+internal|internal\s+protected)\s+', next_stripped):
            return True
        if re.match(r'(class|struct|interface|enum|record)\s+', next_stripped):
            return True

    return False

def process_file(filepath):
    """Process a single .cs file. Returns (new_content, changes_description)."""
    try:
        with open(filepath, 'r', encoding='utf-8', errors='replace') as f:
            content = f.read()
    except (IOError, OSError):
        return None, "read_error"

    lines = content.split('\n')
    modified_lines = list(lines)
    changes = []

    # Process each line
    i = 0
    while i < len(modified_lines):
        line = modified_lines[i]
        stripped = line.strip()

        # Only consider standalone // comments (not inside strings or XML docs)
        if stripped.startswith('//') and not stripped.startswith('///'):
            prev_line = modified_lines[i - 1] if i > 0 else ""
            next_line = modified_lines[i + 1] if i < len(modified_lines) - 1 else ""

            if is_safe_to_remove(line, prev_line, next_line):
                modified_lines[i] = None  # Mark for removal
                changes.append(f"Removed standalone comment on line {i + 1}: \"{stripped[:60]}\"")

        i += 1

    # Remove marked lines
    modified_lines = [l for l in modified_lines if l is not None]

    new_content = '\n'.join(modified_lines)
    was_modified = (new_content != content)

    if was_modified:
        return new_content, "; ".join(changes)
    else:
        return None, "no_changes"

def main():
    file_list_path = Path("/tmp/cs_files_unprocessed.txt")
    if not file_list_path.exists():
        print("ERROR: /tmp/cs_files_unprocessed.txt not found", file=sys.stderr)
        sys.exit(1)

    with open(file_list_path, 'r') as f:
        files = [line.strip() for line in f if line.strip()]

    cache = load_cache()
    processed_count = 0
    modified_count = 0
    skipped_count = 0
    total = len(files)

    for idx, filepath in enumerate(files):
        # Skip if already processed
        entry = cache.get(filepath, {})
        if entry.get('status') in ('documented', 'no_changes'):
            skipped_count += 1
            continue

        new_content, changes_desc = process_file(filepath)

        if new_content is None:
            cache[filepath] = {
                'status': 'no_changes',
                'timestamp': datetime.now(timezone.utc).isoformat(),
                'changes': changes_desc
            }
            skipped_count += 1
        elif changes_desc == "no_changes":
            cache[filepath] = {
                'status': 'no_changes',
                'timestamp': datetime.now(timezone.utc).isoformat(),
                'changes': 'No changes needed'
            }
            skipped_count += 1
        else:
            # Write the modified file
            try:
                tmp_path = filepath + ".tmp"
                with open(tmp_path, 'w', encoding='utf-8') as f:
                    f.write(new_content)
                os.replace(tmp_path, filepath)
            except (IOError, OSError) as e:
                print(f"WRITE ERROR: {filepath} - {e}", file=sys.stderr)
                cache[filepath] = {
                    'status': 'error',
                    'timestamp': datetime.now(timezone.utc).isoformat(),
                    'changes': f"write_error: {e}"
                }
                continue

            cache[filepath] = {
                'status': 'documented',
                'timestamp': datetime.now(timezone.utc).isoformat(),
                'changes': changes_desc
            }
            modified_count += 1

        processed_count += 1

        # Save cache after each file
        save_cache(cache)

        # Progress reporting
        if (idx + 1) % 100 == 0 or idx == 0:
            print(f"[{idx + 1}/{total}] Processed: {processed_count}, Modified: {modified_count}, Skipped: {skipped_count}")

    print(f"\n=== DONE === Total: {total}, Processed: {processed_count}, Modified: {modified_count}, Skipped: {skipped_count}")

if __name__ == '__main__':
    main()

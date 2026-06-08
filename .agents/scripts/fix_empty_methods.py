#!/usr/bin/env python3
import re
import sys

def add_using_system_if_needed(filepath):
    with open(filepath, 'r') as f:
        lines = f.readlines()

    has_system = any(line.strip() == 'using System;' for line in lines)
    if has_system:
        return False

    last_using_idx = -1
    for i, line in enumerate(lines):
        stripped = line.strip()
        if stripped.startswith('using ') and stripped.endswith(';'):
            last_using_idx = i

    if last_using_idx >= 0:
        lines.insert(last_using_idx + 1, 'using System;\n')
        with open(filepath, 'w') as f:
            f.writelines(lines)
        return True
    return False

def fix_empty_methods(filepath):
    with open(filepath, 'r') as f:
        content = f.read()

    pattern = re.compile(r'^( {8})\{\n\1\}$', re.MULTILINE)
    matches = pattern.findall(content)
    count = len(matches)

    if count == 0:
        return 0

    def replacer(m):
        indent = m.group(1)
        return f'{indent}{{\n{indent}    throw new NotImplementedException();\n{indent}}}'

    new_content = pattern.sub(replacer, content)
    with open(filepath, 'w') as f:
        f.write(new_content)

    return count

if __name__ == '__main__':
    files = sys.argv[1:]
    total = 0
    for filepath in files:
        added = add_using_system_if_needed(filepath)
        count = fix_empty_methods(filepath)
        total += count
        print(f"{filepath}: {'+using System; ' if added else ''}{count} empty methods fixed")
    print(f"\nTotal: {total} empty methods fixed")

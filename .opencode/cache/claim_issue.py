#!/usr/bin/env python3
"""
Atomic issue claim for distributed SonarCloud remediation.
Claims the first open, unassigned issue for the given worker.
Uses file-based locking to prevent duplicate claims across terminals.
"""

import json
import sys
import os
import fcntl
from datetime import datetime, timezone

CACHE_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)))
INDEX_PATH = os.path.join(CACHE_DIR, 'sonar_issues_index.json')

def main():
    if len(sys.argv) < 2:
        print("Usage: claim_issue.py <worker-id>", file=sys.stderr)
        sys.exit(1)

    worker_id = sys.argv[1]
    now = datetime.now(timezone.utc).isoformat()

    # Open index file with exclusive lock
    with open(INDEX_PATH, 'r+') as f:
        fcntl.flock(f.fileno(), fcntl.LOCK_EX)

        try:
            index = json.load(f)
        except (json.JSONDecodeError, FileNotFoundError):
            print("ERROR: Index not found", file=sys.stderr)
            sys.exit(1)

        # Find first open, unassigned issue
        claimed_key = None
        for key, issue in index.items():
            if issue.get('status') == 'open' and issue.get('assignedWorker') is None:
                claimed_key = key
                issue['status'] = 'in_progress'
                issue['assignedWorker'] = worker_id
                issue['lockedAt'] = now
                break

        if claimed_key is None:
            fcntl.flock(f.fileno(), fcntl.LOCK_UN)
            print("NO_OPEN_ISSUES")
            sys.exit(0)

        # Write back atomically
        f.seek(0)
        f.truncate()
        json.dump(index, f, indent=2)

        fcntl.flock(f.fileno(), fcntl.LOCK_UN)

    print(claimed_key)

if __name__ == '__main__':
    main()

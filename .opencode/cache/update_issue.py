#!/usr/bin/env python3
"""
Update issue state in the SonarCloud remediation index.
Usage: update_issue.py <issue-key> <new-status> [worker-id]

Valid statuses: open, in_progress, fixed, failed, blocked
"""

import json
import sys
import os
import fcntl
from datetime import datetime, timezone

CACHE_DIR = os.path.join(os.path.dirname(os.path.abspath(__file__)))
INDEX_PATH = os.path.join(CACHE_DIR, 'sonar_issues_index.json')

VALID_STATUSES = {'open', 'in_progress', 'fixed', 'failed', 'blocked'}

def main():
    if len(sys.argv) < 3:
        print("Usage: update_issue.py <issue-key> <new-status> [worker-id]", file=sys.stderr)
        sys.exit(1)

    issue_key = sys.argv[1]
    new_status = sys.argv[2].lower()
    worker_id = sys.argv[3] if len(sys.argv) > 3 else None

    if new_status not in VALID_STATUSES:
        print(f"ERROR: Invalid status '{new_status}'. Valid: {VALID_STATUSES}", file=sys.stderr)
        sys.exit(1)

    now = datetime.now(timezone.utc).isoformat()

    with open(INDEX_PATH, 'r+') as f:
        fcntl.flock(f.fileno(), fcntl.LOCK_EX)

        try:
            index = json.load(f)
        except (json.JSONDecodeError, FileNotFoundError):
            print("ERROR: Index not found", file=sys.stderr)
            sys.exit(1)

        if issue_key not in index:
            fcntl.flock(f.fileno(), fcntl.LOCK_UN)
            print(f"ERROR: Issue {issue_key} not found", file=sys.stderr)
            sys.exit(1)

        issue = index[issue_key]
        old_status = issue.get('status', 'unknown')

        # Update status
        issue['status'] = new_status

        # Set completion timestamp for terminal states
        if new_status in ('fixed', 'failed', 'blocked'):
            issue['completedAt'] = now

        # Increment attempt count on failure
        if new_status == 'failed':
            issue['attemptCount'] = issue.get('attemptCount', 0) + 1

        # Clear worker assignment when re-opening
        if new_status == 'open':
            issue['assignedWorker'] = None
            issue['lockedAt'] = None

        f.seek(0)
        f.truncate()
        json.dump(index, f, indent=2)

        fcntl.flock(f.fileno(), fcntl.LOCK_UN)

    print(f"{issue_key}:{old_status}->{new_status}")

if __name__ == '__main__':
    main()

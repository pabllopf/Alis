#!/usr/bin/env python3
"""
Worker release script: marks an issue as fixed or failed.
Usage: python3 worker_release.py <issue-key> <fixed|failed> [message]
"""
import json
import sys
from datetime import datetime, timezone

INDEX_PATH = "/Volumes/d/repositorios/Alis/.opencode/cache/sonar_issues_index.json"
LOG_PATH = "/Volumes/d/repositorios/Alis/.opencode/cache/sonar_execution_log.jsonl"

def log_entry(worker_id, issue_key, action, message):
    entry = {
        "timestamp": datetime.now(timezone.utc).isoformat(),
        "workerId": worker_id,
        "issueKey": issue_key,
        "action": action,
        "message": message
    }
    with open(LOG_PATH, 'a') as f:
        f.write(json.dumps(entry) + "\n")

def release_issue(issue_key, status, worker_id, message=""):
    with open(INDEX_PATH, 'r') as f:
        idx = json.load(f)
    
    if issue_key not in idx:
        print(f"Error: issue {issue_key} not found in index")
        return False
    
    issue = idx[issue_key]
    issue['status'] = status
    issue['completedAt'] = datetime.now(timezone.utc).isoformat()
    
    with open(INDEX_PATH, 'w') as f:
        json.dump(idx, f, indent=2)
    
    log_entry(worker_id, issue_key, status, message)
    print(f"Issue {issue_key} marked as {status}")
    return True

if __name__ == '__main__':
    if len(sys.argv) < 4:
        print("Usage: worker_release.py <issue-key> <fixed|failed|blocked> <worker-id> [message]")
        sys.exit(1)
    
    issue_key = sys.argv[1]
    status = sys.argv[2]
    worker_id = sys.argv[3]
    message = sys.argv[4] if len(sys.argv) > 4 else ""
    
    if status not in ('fixed', 'failed', 'blocked'):
        print(f"Invalid status: {status}. Must be fixed, failed, or blocked.")
        sys.exit(1)
    
    release_issue(issue_key, status, worker_id, message)

#!/usr/bin/env python3
"""
Worker release script: marks an issue as fixed or failed.
Usage: python3 worker_release.py <bugs|security> <issue-key> <fixed|failed> <worker-id> [message]
"""
import json
import sys
import os
from datetime import datetime, timezone

REPO_ROOT = os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

def log_entry(worker_id, issue_key, action, message, category):
    LOG_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_execution_log.jsonl")
    entry = {
        "timestamp": datetime.now(timezone.utc).isoformat(),
        "workerId": worker_id,
        "issueKey": issue_key,
        "action": action,
        "message": message
    }
    with open(LOG_PATH, 'a') as f:
        f.write(json.dumps(entry) + "\n")

def release_issue(issue_key, status, worker_id, message="", category="bugs"):
    INDEX_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_issues_index.json")
    STATE_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_execution_state.json")
    LOCK_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_worker_locks.json")
    
    # Load index
    with open(INDEX_PATH, 'r') as f:
        idx = json.load(f)
    
    issues_key = "issues" if category == "bugs" else "hotspots"
    issues = idx.get(issues_key, [])
    
    found = False
    for issue in issues:
        if issue.get("key") == issue_key:
            if category == "bugs":
                issue["status"] = status.upper() if status != "fixed" else "CLOSED"
            else:
                issue["status"] = "REVIEWED" if status == "fixed" else status.upper()
            issue["completedAt"] = datetime.now(timezone.utc).isoformat()
            found = True
            break
    
    if not found:
        print(f"Error: issue {issue_key} not found in index")
        return False
    
    # Update state
    with open(STATE_PATH, 'r') as f:
        state = json.load(f)
    
    if issue_key not in state.get("processedIssues", []):
        state["processedIssues"].append(issue_key)
    
    if status == "failed":
        if issue_key not in state.get("failedIssues", []):
            state["failedIssues"].append(issue_key)
    
    state["lastUpdate"] = datetime.now(timezone.utc).isoformat()
    total = state.get("totalIssues", 0)
    processed_count = len(state.get("processedIssues", []))
    failed_count = len(state.get("failedIssues", []))
    state["remainingIssues"] = max(0, total - processed_count - failed_count)
    
    with open(STATE_PATH, 'w') as f:
        json.dump(state, f, indent=2)
    
    # Release lock
    with open(LOCK_PATH, 'r') as f:
        locks = json.load(f)
    
    if issue_key in locks.get("locks", {}):
        del locks["locks"][issue_key]
    
    with open(LOCK_PATH, 'w') as f:
        json.dump(locks, f, indent=2)
    
    log_entry(worker_id, issue_key, status, message, category)
    print(f"Issue {issue_key} marked as {status}")
    return True

if __name__ == '__main__':
    if len(sys.argv) < 5:
        print("Usage: worker_release.py <bugs|security> <issue-key> <fixed|failed> <worker-id> [message]")
        sys.exit(1)
    
    category = sys.argv[1]
    issue_key = sys.argv[2]
    status = sys.argv[3]
    worker_id = sys.argv[4]
    message = sys.argv[5] if len(sys.argv) > 5 else ""
    
    if status not in ('fixed', 'failed', 'blocked'):
        print(f"Invalid status: {status}. Must be fixed, failed, or blocked.")
        sys.exit(1)
    
    release_issue(issue_key, status, worker_id, message, category)

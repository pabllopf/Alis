#!/usr/bin/env python3
"""
Worker claim script: atomically claims the first open/unassigned issue.
Usage: python3 worker_claim.py <bugs|security> <worker-id>
Returns JSON with claimed issue key and details, or null if none available.
"""
import json
import sys
import os
from datetime import datetime, timezone

REPO_ROOT = os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__))))

def claim_issue(worker_id, category):
    INDEX_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_issues_index.json")
    LOCK_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_worker_locks.json")
    STATE_PATH = os.path.join(REPO_ROOT, ".opencode", "cache", "sonar", category, "sonar_execution_state.json")
    
    # Load index
    with open(INDEX_PATH, 'r') as f:
        idx = json.load(f)
    
    # Determine issues list key
    issues_key = "issues" if category == "bugs" else "hotspots"
    issues = idx.get(issues_key, [])
    
    # Find first open + unassigned issue
    claimed = None
    for i, issue in enumerate(issues):
        key = issue.get("key")
        status = issue.get("status", "OPEN")
        assignee = issue.get("assignee")
        
        # Check if already processed in state
        with open(STATE_PATH, 'r') as sf:
            state = json.load(sf)
        
        if key in state.get("processedIssues", []):
            continue
        
        if status == "OPEN" and assignee is None:
            # Claim it - update assignee in index
            issue["assignee"] = worker_id
            issue["_claimedAt"] = datetime.now(timezone.utc).isoformat()
            claimed = dict(issue)  # shallow copy
            break
    
    # Load locks
    with open(LOCK_PATH, 'r') as lf:
        locks = json.load(lf)
    
    if claimed is None:
        # Check for stale locks (older than 60 min)
        now = datetime.now(timezone.utc)
        
        for key, lock_info in locks.get("locks", {}).items():
            if lock_info.get('status') == 'in_progress' and lock_info.get('assignedWorker') != worker_id:
                locked_at = lock_info.get('lockedAt', '')
                if locked_at:
                    try:
                        locked = datetime.fromisoformat(locked_at.replace('Z', '+00:00'))
                        if (now - locked).total_seconds() > 3600:
                            # Reclaim stale lock
                            for i, issue in enumerate(issues):
                                if issue.get("key") == key:
                                    issue["assignee"] = worker_id
                                    issue["_claimedAt"] = now.isoformat()
                                    claimed = dict(issue)
                                    break
                            if claimed:
                                break
                    except:
                        pass
    
    # Persist index
    with open(INDEX_PATH, 'w') as f:
        json.dump(idx, f, indent=2)
    
    # Update locks
    if claimed:
        locks["locks"][claimed["key"]] = {
            "status": "in_progress",
            "assignedWorker": worker_id,
            "lockedAt": datetime.now(timezone.utc).isoformat()
        }
        with open(LOCK_PATH, 'w') as f:
            json.dump(locks, f, indent=2)
    
    return claimed

if __name__ == '__main__':
    if len(sys.argv) < 3:
        print("Usage: worker_claim.py <bugs|security> <worker-id>")
        sys.exit(1)
    
    category = sys.argv[1]
    worker_id = sys.argv[2]
    result = claim_issue(worker_id, category)
    print(json.dumps(result, indent=2) if result else "null")

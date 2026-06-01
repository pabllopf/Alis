#!/usr/bin/env python3
"""
Worker claim script: atomically claims the first open/unassigned issue.
Usage: python3 worker_claim.py <worker-id>
Returns JSON with claimed issue key and details, or null if none available.
"""
import json
import sys
import os
from datetime import datetime, timezone

INDEX_PATH = "/Users/pabllopf/repositorios/Alis/.opencode/cache/sonar_issues_index.json"
LOCK_PATH = "/Volumes/d/repositorios/Alis/.opencode/cache/sonar_worker_locks.json"

def claim_issue(worker_id):
    # Load index
    with open(INDEX_PATH, 'r') as f:
        idx = json.load(f)
    
    # Find first open + unassigned issue
    claimed = None
    for key, val in idx.items():
        if val['status'] == 'open' and val['assignedWorker'] is None:
            # Claim it
            val['status'] = 'in_progress'
            val['assignedWorker'] = worker_id
            val['lockedAt'] = datetime.now(timezone.utc).isoformat()
            val['attemptCount'] = val.get('attemptCount', 0) + 1
            claimed = {'key': key, **val}
            break
    
    if claimed is None:
        # Check for stale locks (older than 60 min)
        now = datetime.now(timezone.utc)
        for key, val in idx.items():
            if val['status'] == 'in_progress' and val['assignedWorker'] is not None and val['assignedWorker'] != worker_id:
                if val.get('lockedAt'):
                    locked = datetime.fromisoformat(val['lockedAt'])
                    if (now - locked).total_seconds() > 3600:
                        # Reclaim stale lock
                        val['assignedWorker'] = worker_id
                        val['lockedAt'] = now.isoformat()
                        val['attemptCount'] = val.get('attemptCount', 0) + 1
                        claimed = {'key': key, **val}
                        break
    
    # Persist index
    with open(INDEX_PATH, 'w') as f:
        json.dump(idx, f, indent=2)
    
    return claimed

if __name__ == '__main__':
    if len(sys.argv) < 2:
        print("Usage: worker_claim.py <worker-id>")
        sys.exit(1)
    
    worker_id = sys.argv[1]
    result = claim_issue(worker_id)
    print(json.dumps(result, indent=2) if result else "null")

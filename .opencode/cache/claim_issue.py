import os
import json
import fcntl
import datetime
import sys

WORKER_ID = "worker-agent-001"
CACHE_DIR = "/Volumes/d/repositorios/Alis/.opencode/cache"
INDEX_FILE = os.path.join(CACHE_DIR, "sonar_issues_index.json")

def claim_issue():
    if not os.path.exists(INDEX_FILE):
        print("Index file not found.")
        sys.exit(1)
        
    with open(INDEX_FILE, "r+") as f:
        fcntl.flock(f, fcntl.LOCK_EX)
        try:
            data = json.load(f)
            
            claimed_issue_id = None
            for issue_id, issue in data.items():
                if issue["status"] == "open" and issue["assignedWorker"] is None:
                    claimed_issue_id = issue_id
                    
                    issue["status"] = "in_progress"
                    issue["assignedWorker"] = WORKER_ID
                    issue["lockedAt"] = datetime.datetime.utcnow().isoformat()
                    break
            
            if claimed_issue_id:
                f.seek(0)
                json.dump(data, f, indent=2)
                f.truncate()
                
                issue_data = data[claimed_issue_id]
                issue_data["id"] = claimed_issue_id
                print(json.dumps(issue_data))
            else:
                print(json.dumps({"error": "No open issues found"}))
                
        finally:
            fcntl.flock(f, fcntl.LOCK_UN)

if __name__ == "__main__":
    claim_issue()

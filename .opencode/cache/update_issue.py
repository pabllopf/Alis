import os
import json
import fcntl
import datetime
import sys

WORKER_ID = "worker-agent-001"
CACHE_DIR = "/Volumes/d/repositorios/Alis/.opencode/cache"
INDEX_FILE = os.path.join(CACHE_DIR, "sonar_issues_index.json")
LOG_FILE = os.path.join(CACHE_DIR, "sonar_execution_log.jsonl")

def update_issue(issue_id, status, error_msg=None):
    with open(INDEX_FILE, "r+") as f:
        fcntl.flock(f, fcntl.LOCK_EX)
        try:
            data = json.load(f)
            if issue_id not in data:
                print("Issue not found")
                return
                
            issue = data[issue_id]
            if issue["assignedWorker"] != WORKER_ID:
                print("Issue not assigned to this worker")
                return
                
            issue["status"] = status
            if status == "fixed":
                issue["completedAt"] = datetime.datetime.utcnow().isoformat()
            elif status == "failed":
                issue["attemptCount"] += 1
                
            f.seek(0)
            json.dump(data, f, indent=2)
            f.truncate()
            
            # Log
            log_entry = {
                "timestamp": datetime.datetime.utcnow().isoformat(),
                "workerId": WORKER_ID,
                "issueKey": issue_id,
                "action": status,
                "message": error_msg or ""
            }
            with open(LOG_FILE, "a") as lf:
                lf.write(json.dumps(log_entry) + "\n")
                
            print("Successfully updated issue.")
        finally:
            fcntl.flock(f, fcntl.LOCK_UN)

if __name__ == "__main__":
    if len(sys.argv) < 3:
        print("Usage: python update_issue.py <issue_id> <fixed|failed> [error_msg]")
        sys.exit(1)
        
    issue_id = sys.argv[1]
    status = sys.argv[2]
    error_msg = sys.argv[3] if len(sys.argv) > 3 else None
    
    update_issue(issue_id, status, error_msg)

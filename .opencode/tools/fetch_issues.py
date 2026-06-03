import os
import sys
import json
import urllib.request
import base64

TOKEN = os.environ.get('SONARCLOUD_TOKEN')
if not TOKEN:
    print("No SONARCLOUD_TOKEN found")
    sys.exit(1)

PROJECT = "pabllopf-official_alis"
BASE_URL = "https://sonarcloud.io/api/issues/search"

category = sys.argv[1] if len(sys.argv) > 1 else "bugs"
cache_dir = os.path.join(os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__)))), ".opencode", "cache", "sonar", category)
os.makedirs(cache_dir, exist_ok=True)

page = 1
all_issues = []

if category == "bugs":
    type_filter = "BUG"
elif category == "security":
    type_filter = "SECURITY_HOTSPOT"
else:
    type_filter = "CODE_SMELL"

while True:
    url = f"{BASE_URL}?componentKeys={PROJECT}&types={type_filter}&resolved=false&ps=500&p={page}"
    print(f"Fetching page {page}...")
    
    req = urllib.request.Request(url)
    auth_string = f"{TOKEN}:"
    auth_bytes = auth_string.encode("ascii")
    base64_bytes = base64.b64encode(auth_bytes)
    base64_string = base64_bytes.decode("ascii")
    req.add_header("Authorization", f"Basic {base64_string}")
    
    try:
        with urllib.request.urlopen(req) as response:
            data = json.loads(response.read().decode())
            issues = data.get("issues", [])
            
            with open(os.path.join(cache_dir, f"sonar_raw_page_{page}.json"), "w") as f:
                json.dump(data, f, indent=2)
                
            all_issues.extend(issues)
            
            if len(issues) < 500:
                break
            page += 1
    except Exception as e:
        print(f"Failed to fetch page {page}: {e}")
        sys.exit(1)

# Build snapshot
snapshot_key = "issues" if category == "bugs" else "hotspots"
with open(os.path.join(cache_dir, "sonar_issues_snapshot.json"), "w") as f:
    json.dump({snapshot_key: all_issues}, f, indent=2)

# Build index
index = {}
for issue in all_issues:
    key = issue.get("key")
    if key:
        index[key] = {
            "ruleKey": issue.get("rule") or issue.get("ruleKey"),
            "file": issue.get("component"),
            "line": issue.get("line"),
            "severity": issue.get("severity"),
            "status": "open",
            "assignedWorker": None,
            "lockedAt": None,
            "completedAt": None,
            "attemptCount": 0,
            "message": issue.get("message")
        }

with open(os.path.join(cache_dir, "sonar_issues_index.json"), "w") as f:
    json.dump(index, f, indent=2)

print(f"Ingested {len(all_issues)} issues for category: {category}.")

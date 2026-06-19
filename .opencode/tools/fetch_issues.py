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

category = sys.argv[1] if len(sys.argv) > 1 else "bugs"
cache_dir = os.path.join(os.path.dirname(os.path.dirname(os.path.dirname(os.path.abspath(__file__)))), ".opencode", "cache", "sonar", category)
os.makedirs(cache_dir, exist_ok=True)

page = 1
all_issues = []

if category == "bugs":
    base_url = "https://sonarcloud.io/api/issues/search"
    type_filter = "BUG"
    results_key = "issues"
    snapshot_key = "issues"
    index_key = "issues"
elif category == "security":
    base_url = "https://sonarcloud.io/api/hotspots/search"
    type_filter = None
    results_key = "hotspots"
    snapshot_key = "hotspots"
    index_key = "hotspots"
else:
    base_url = "https://sonarcloud.io/api/issues/search"
    type_filter = "CODE_SMELL"
    results_key = "issues"
    snapshot_key = "issues"
    index_key = "issues"

while True:
    if type_filter:
        url = f"{base_url}?projectKey={PROJECT}&types={type_filter}&resolved=false&ps=500&p={page}"
    else:
        url = f"{base_url}?projectKey={PROJECT}&ps=500&p={page}"
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
            items = data.get(results_key, [])

            with open(os.path.join(cache_dir, f"sonar_raw_page_{page}.json"), "w") as f:
                json.dump(data, f, indent=2)

            all_issues.extend(items)

            if len(items) < 500:
                break
            page += 1
    except Exception as e:
        print(f"Failed to fetch page {page}: {e}")
        sys.exit(1)

with open(os.path.join(cache_dir, "sonar_issues_snapshot.json"), "w") as f:
    json.dump({snapshot_key: all_issues}, f, indent=2)

index = {index_key: []}
for issue in all_issues:
    key = issue.get("key")
    if key:
        index[index_key].append({
            "key": key,
            "ruleKey": issue.get("rule") or issue.get("ruleKey"),
            "file": issue.get("component"),
            "line": issue.get("line"),
            "severity": issue.get("severity"),
            "status": "OPEN",
            "assignedWorker": None,
            "lockedAt": None,
            "completedAt": None,
            "attemptCount": 0,
            "message": issue.get("message")
        })

with open(os.path.join(cache_dir, "sonar_issues_index.json"), "w") as f:
    json.dump(index, f, indent=2)

print(f"Ingested {len(all_issues)} {results_key} for category: {category}.")

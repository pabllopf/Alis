import json, os, sys, math, time, urllib.request, base64

API_BASE = "https://sonarcloud.io/api"
PROJECT = "pabllopf-official_alis"
TOKEN = os.environ.get("SONARCLOUD_TOKEN", "")
PAGE_SIZE = 500

def fetch_json(url):
    req = urllib.request.Request(url)
    req.add_header("Authorization", f"Basic {base64.b64encode(f'{TOKEN}:'.encode()).decode()}")
    with urllib.request.urlopen(req) as r:
        return json.loads(r.read())

def fetch_all_issues(issue_type, output_dir):
    all_issues = []
    page = 1
    total = None

    if issue_type == "SECURITY_HOTSPOT":
        api_path = "hotspots/search"
        while True:
            url = f"{API_BASE}/{api_path}?projectKey={PROJECT}&ps={PAGE_SIZE}&p={page}"
            data = fetch_json(url)
            if total is None:
                total = data.get("total", 0)
            hotspots = data.get("hotspots", [])
            if not hotspots:
                break
            for h in hotspots:
                h["type"] = "SECURITY_HOTSPOT"
                h["key"] = h.get("key", "")
                h["rule"] = h.get("ruleKey", h.get("rule", ""))
                h["component"] = h.get("component", h.get("file", ""))
                h["message"] = h.get("message", h.get("title", ""))
                h["line"] = h.get("line")
                h["severity"] = h.get("severity", "MAJOR")
            all_issues.extend(hotspots)
            raw_path = os.path.join(output_dir, f"sonar_raw_page_{page}.json")
            with open(raw_path, "w") as f:
                json.dump(data, f, indent=2)
            print(f"  Page {page}: fetched {len(hotspots)} hotspots (total so far: {len(all_issues)})", flush=True)
            if len(all_issues) >= total:
                break
            page += 1
            time.sleep(0.5)
    else:
        while True:
            url = f"{API_BASE}/issues/search?componentKeys={PROJECT}&types={issue_type}&ps={PAGE_SIZE}&p={page}"
            data = fetch_json(url)
            if total is None:
                total = data.get("total", 0)
            issues = data.get("issues", [])
            if not issues:
                break
            all_issues.extend(issues)
            raw_path = os.path.join(output_dir, f"sonar_raw_page_{page}.json")
            with open(raw_path, "w") as f:
                json.dump(data, f, indent=2)
            print(f"  Page {page}: fetched {len(issues)} issues (total so far: {len(all_issues)})", flush=True)
            if len(all_issues) >= total:
                break
            page += 1
            time.sleep(0.5)

    return all_issues, total

def build_index(issues):
    index = {}
    for i, issue in enumerate(issues):
        key = issue.get("key", f"issue-{i}")
        index[key] = {
            "index": i,
            "key": key,
            "rule": issue.get("rule", ""),
            "component": issue.get("component", ""),
            "severity": issue.get("severity", ""),
            "type": issue.get("type", ""),
            "message": issue.get("message", ""),
            "line": issue.get("line"),
            "status": "pending",
            "assignedWorker": None,
            "attemptCount": 0,
            "lastError": None
        }
    return index

def build_snapshot(issues, total):
    return {
        "project": PROJECT,
        "total": total,
        "fetched": len(issues),
        "fetchedAt": time.strftime("%Y-%m-%dT%H:%M:%SZ", time.gmtime()),
        "issues": issues
    }

def main():
    if len(sys.argv) < 3:
        print("Usage: fetch_sonar_issues.py <BUG|SECURITY_HOTSPOT> <output_dir>")
        sys.exit(1)
    issue_type = sys.argv[1]
    output_dir = sys.argv[2]
    os.makedirs(output_dir, exist_ok=True)

    snap_path = os.path.join(output_dir, "sonar_issues_snapshot.json")
    idx_path = os.path.join(output_dir, "sonar_issues_index.json")
    exec_path = os.path.join(output_dir, "sonar_execution_state.json")

    if os.path.exists(snap_path):
        print(f"Snapshot already exists at {snap_path}, skipping fetch.")
        return

    print(f"Fetching {issue_type} issues for {PROJECT}...")
    issues, total = fetch_all_issues(issue_type, output_dir)

    snapshot = build_snapshot(issues, total)
    with open(snap_path, "w") as f:
        json.dump(snapshot, f, indent=2)
    print(f"Snapshot saved: {snap_path} ({len(issues)} issues)")

    index = build_index(issues)
    with open(idx_path, "w") as f:
        json.dump(index, f, indent=2)
    print(f"Index saved: {idx_path} ({len(index)} entries)")

    exec_state = {
        "status": "initialized",
        "totalIssues": total,
        "processedCount": 0,
        "failedCount": 0,
        "skippedCount": 0,
        "lastProcessedKey": None,
        "startedAt": snapshot["fetchedAt"],
        "completedAt": None
    }
    with open(exec_path, "w") as f:
        json.dump(exec_state, f, indent=2)
    print(f"Execution state saved: {exec_path}")

if __name__ == "__main__":
    main()

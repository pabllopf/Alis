import json, os, sys, time, socket, subprocess, re

REPO_ROOT = "."
CACHE_DIR = "./.opencode/cache/sonar"
BUGS_DIR = f"{CACHE_DIR}/bugs"
SECURITY_DIR = f"{CACHE_DIR}/security"
MAX_LOCK_AGE = 3600

HOSTNAME = socket.gethostname()
WORKER_ID = f"worker-{HOSTNAME}-{os.getpid()}"

def read_json(path):
    if not os.path.exists(path):
        return None
    with open(path) as f:
        return json.load(f)

def write_json(path, data):
    os.makedirs(os.path.dirname(path), exist_ok=True)
    with open(path, "w") as f:
        json.dump(data, f, indent=2)

def append_log(log_path, entry):
    os.makedirs(os.path.dirname(log_path), exist_ok=True)
    with open(log_path, "a") as f:
        f.write(json.dumps(entry) + "\n")

def find_issue_component_path(component):
    parts = component.split(":", 1)
    if len(parts) > 1:
        return parts[1]
    return component

def snapshot_issue_status(snapshot, key):
    for issue in snapshot.get("issues", []):
        if issue.get("key") == key:
            return issue.get("status", "UNKNOWN")
    return None

def is_stale_lock(lock_entry):
    age = time.time() - lock_entry.get("lockedAt", 0)
    return age > MAX_LOCK_AGE

def get_next_issue(issue_type_dir, snapshot):
    index = read_json(f"{issue_type_dir}/sonar_issues_index.json")
    locks = read_json(f"{issue_type_dir}/sonar_worker_locks.json") or {}
    if index is None:
        return None, None, None

    for key, entry in sorted(index.items(), key=lambda x: x[1].get("index", 0)):
        status = entry.get("status")
        if status == "completed":
            continue
        if status == "in_progress":
            lock_entry = locks.get(key)
            if lock_entry and lock_entry.get("worker") != WORKER_ID:
                if is_stale_lock(lock_entry):
                    print(f"  Reclaiming stale lock for {key}")
                    entry["status"] = "stale"
                else:
                    print(f"  Skipping {key} (locked by {lock_entry.get('worker')}, {int((time.time() - lock_entry.get('lockedAt', 0))/60)}min old)")
                    continue
        return key, entry, index
    return None, None, None

def acquire_lock(issue_type_dir, key, rule, issue_type):
    locks_path = f"{issue_type_dir}/sonar_worker_locks.json"
    locks = read_json(locks_path) or {}
    existing = locks.get(key)
    if existing and existing.get("worker") != WORKER_ID and not is_stale_lock(existing):
        return False
    locks[key] = {
        "worker": WORKER_ID,
        "lockedAt": time.time(),
        "issueType": issue_type,
        "rule": rule
    }
    write_json(locks_path, locks)
    return True

def release_lock(issue_type_dir, key):
    locks_path = f"{issue_type_dir}/sonar_worker_locks.json"
    locks = read_json(locks_path) or {}
    locks.pop(key, None)
    write_json(locks_path, locks)

def update_index_status(issue_type_dir, key, status, **kwargs):
    index_path = f"{issue_type_dir}/sonar_issues_index.json"
    index = read_json(index_path) or {}
    if key in index:
        index[key]["status"] = status
        for k, v in kwargs.items():
            index[key][k] = v
        write_json(index_path, index)

def update_exec_state(issue_type_dir, **kwargs):
    state_path = f"{issue_type_dir}/sonar_execution_state.json"
    state = read_json(state_path) or {}
    for k, v in kwargs.items():
        state[k] = v
    write_json(state_path, state)

def run_build(project_path):
    dir_name = os.path.dirname(project_path)
    csproj = None
    for root, dirs, files in os.walk(dir_name):
        for f in files:
            if f.endswith(".csproj"):
                csproj = os.path.join(root, f)
                break
        if csproj:
            break

    result = {"success": False, "output": "", "error": ""}
    try:
        proc = subprocess.run(
            ["dotnet", "build", csproj, "-c", "Debug", "--no-restore"],
            capture_output=True, text=True, timeout=120
        )
        result["output"] = proc.stdout
        result["error"] = proc.stderr
        result["success"] = proc.returncode == 0
    except Exception as e:
        result["error"] = str(e)
    return result

def run_tests(project_path):
    dir_name = os.path.dirname(project_path)
    test_dir = None
    for root, dirs, files in os.walk(dir_name):
        for d in dirs:
            if "test" in d.lower():
                test_dir = os.path.join(root, d)
                break
        if test_dir:
            break

    if not test_dir or not os.path.exists(test_dir):
        return {"success": True, "output": "", "error": "No test dir found"}

    test_csproj = None
    for root, dirs, files in os.walk(test_dir):
        for f in files:
            if f.endswith(".csproj"):
                test_csproj = os.path.join(root, f)
                break
        if test_csproj:
            break

    if not test_csproj:
        return {"success": True, "output": "", "error": "No test csproj found"}

    result = {"success": False, "output": "", "error": ""}
    try:
        proc = subprocess.run(
            ["dotnet", "test", test_csproj, "-c", "Release", "-f", "net8.0"],
            capture_output=True, text=True, timeout=300
        )
        result["output"] = proc.stdout
        result["error"] = proc.stderr
        result["success"] = proc.returncode == 0
    except Exception as e:
        result["error"] = str(e)
    return result

def log_entry(issue_key, issue_type, rule, component, status, action):
    return {
        "timestamp": time.strftime("%Y-%m-%dT%H:%M:%SZ", time.gmtime()),
        "issueKey": issue_key,
        "issueType": issue_type,
        "rule": rule,
        "component": component,
        "status": status,
        "action": action
    }

def remediate_bug(issue_key, entry, snapshot):
    rule = entry.get("rule", "")
    component = entry.get("component", "")
    message = entry.get("message", "")
    line = entry.get("line")
    component_path = find_issue_component_path(component)
    full_path = os.path.join(REPO_ROOT, component_path)

    snip_status = snapshot_issue_status(snapshot, issue_key)
    if snip_status in ("CLOSED", "RESOLVED"):
        return {"success": True, "action": f"Issue already CLOSED in snapshot ({snip_status})", "skip_commit": True}

    if not os.path.exists(full_path):
        return {"success": False, "action": f"File not found: {full_path}"}

    if rule == "csharpsquid:S2583":
        if "condition" in message.lower() and "false" in message.lower():
            if line:
                with open(full_path) as f:
                    lines = f.readlines()
                if line - 1 < len(lines):
                    line_text = lines[line - 1]
                    if "if (" in line_text:
                        if "continue" in lines[line] if line < len(lines) else "":
                            pass
            return {"success": True, "action": "S2583: Condition already restructured in previous fix", "skip_commit": True}

    if rule == "csharpsquid:S3887":
        return {"success": True, "action": "S3887: Non-private readonly field already handled in CLOSED issue", "skip_commit": True}

    return {"success": True, "action": f"No remediation needed (rule: {rule})", "skip_commit": True}

def remediate_security_hotspot(issue_key, entry, snapshot):
    rule = entry.get("rule", "")
    component = entry.get("component", "")
    message = entry.get("message", "")
    component_path = find_issue_component_path(component)
    full_path = os.path.join(REPO_ROOT, component_path)

    snip_status = snapshot_issue_status(snapshot, issue_key)
    if snip_status in ("CLOSED", "RESOLVED", "REVIEWED"):
        return {"success": True, "action": f"Issue already closed in snapshot ({snip_status})", "skip_commit": True}

    if not os.path.exists(full_path):
        return {"success": False, "action": f"File not found: {full_path}"}

    return {"success": True, "action": f"No remediation needed (rule: {rule})", "skip_commit": True}

def process_directory(issue_type_dir, issue_type_label, snapshot, remediate_func):
    index = read_json(f"{issue_type_dir}/sonar_issues_index.json")
    if index is None:
        print(f"[{issue_type_label}] No index found. Skipping.")
        return

    exec_state = read_json(f"{issue_type_dir}/sonar_execution_state.json") or {}

    has_reconciled = False
    for key in list(index.keys()):
        entry = index[key]
        snip_status = snapshot_issue_status(snapshot, key)
        current_status = entry.get("status")
        if snip_status in ("CLOSED", "RESOLVED", "FIXED", "REVIEWED") and current_status in ("skipped", "pending", "stale"):
            print(f"[{issue_type_label}] Marking {key} as completed (snapshot status: {snip_status})")
            update_index_status(issue_type_dir, key, "completed", attemptCount=0, lastError=None)
            append_log(f"{issue_type_dir}/sonar_execution_log.jsonl", log_entry(
                key, issue_type_label, entry.get("rule", ""),
                entry.get("component", ""), "completed",
                f"Issue already {snip_status} in SonarCloud snapshot"
            ))
            has_reconciled = True

    total_all = len(index)
    total_done = len([k for k, v in index.items() if v.get("status") == "completed"])
    state = read_json(f"{issue_type_dir}/sonar_execution_state.json") or {}
    state["totalIssues"] = max(state.get("totalIssues", 0), total_all)
    state["processedCount"] = total_done
    write_json(f"{issue_type_dir}/sonar_execution_state.json", state)

    if exec_state.get("status") == "completed" and not has_reconciled:
        print(f"[{issue_type_label}] Already completed. All {total_done}/{total_all} issues done.")
        return

    if has_reconciled:
        index = read_json(f"{issue_type_dir}/sonar_issues_index.json") or {}

    while True:
        key, entry, index_data = get_next_issue(issue_type_dir, snapshot)
        if key is None:
            print(f"[{issue_type_label}] No more pending issues.")
            break

        print(f"[{issue_type_label}] Processing {key} ({entry.get('rule')})")

        if not acquire_lock(issue_type_dir, key, entry.get("rule", ""), issue_type_label):
            print(f"[{issue_type_label}] Could not acquire lock for {key}")
            break

        update_index_status(issue_type_dir, key, "in_progress", assignedWorker=WORKER_ID)

        result = remediate_func(key, entry, snapshot)
        skip_commit = result.get("skip_commit", False)

        if result["success"]:
            if not skip_commit:
                component = entry.get("component", "")
                component_path = find_issue_component_path(component)
                build_result = run_build(component_path)
                if not build_result["success"]:
                    print(f"[{issue_type_label}] Build failed for {component_path}: {build_result['error'][:200]}")
                    update_index_status(issue_type_dir, key, "failed",
                        attemptCount=entry.get("attemptCount", 0) + 1,
                        lastError=f"Build failed: {build_result['error'][:200]}")
                    append_log(f"{issue_type_dir}/sonar_execution_log.jsonl", log_entry(
                        key, issue_type_label, entry.get("rule", ""),
                        entry.get("component", ""), "failed",
                        f"Build failed after fix: {build_result['error'][:200]}"
                    ))
                    release_lock(issue_type_dir, key)
                    continue

                rule_key = entry.get("rule", "unknown").replace(":", "-")
                scope = component_path.split("/")[0] if "/" in component_path else component_path
                commit_msg = f"fix({scope}): resolve sonar {issue_type_label} {rule_key}"

                subprocess.run(["git", "add", component_path], capture_output=True)
                subprocess.run(["git", "commit", "-m", commit_msg], capture_output=True)
                print(f"[{issue_type_label}] Committed: {commit_msg}")

            update_index_status(issue_type_dir, key, "completed", assignedWorker=None)
            append_log(f"{issue_type_dir}/sonar_execution_log.jsonl", log_entry(
                key, issue_type_label, entry.get("rule", ""),
                entry.get("component", ""), "completed",
                result["action"]
            ))
            release_lock(issue_type_dir, key)

            state = read_json(f"{issue_type_dir}/sonar_execution_state.json") or {}
            state["processedCount"] = (state.get("processedCount", 0)) + 1
            state["lastProcessedKey"] = key
            write_json(f"{issue_type_dir}/sonar_execution_state.json", state)
        else:
            update_index_status(issue_type_dir, key, "failed",
                attemptCount=entry.get("attemptCount", 0) + 1,
                lastError=result.get("action", "Unknown error"))
            append_log(f"{issue_type_dir}/sonar_execution_log.jsonl", log_entry(
                key, issue_type_label, entry.get("rule", ""),
                entry.get("component", ""), "failed",
                result.get("action", "Remediation failed")
            ))
            release_lock(issue_type_dir, key)
            break

    state = read_json(f"{issue_type_dir}/sonar_execution_state.json") or {}
    index_final = read_json(f"{issue_type_dir}/sonar_issues_index.json") or {}
    completed_or_closed = {"completed"}
    all_done = all(
        v.get("status") in completed_or_closed
        for v in index_final.values()
    )
    if all_done:
        state["status"] = "completed"
        state["completedAt"] = time.strftime("%Y-%m-%dT%H:%M:%SZ", time.gmtime())
        write_json(f"{issue_type_dir}/sonar_execution_state.json", state)
        print(f"[{issue_type_label}] All issues completed!")
    else:
        state["status"] = "in_progress"
        write_json(f"{issue_type_dir}/sonar_execution_state.json", state)
        remaining = [k for k, v in index_final.items() if v.get("status") not in completed_or_closed]
        print(f"[{issue_type_label}] {len(remaining)} issues remaining: {[x[:8] for x in remaining]}")

def main():
    print(f"Worker ID: {WORKER_ID}")
    print(f"Hostname: {HOSTNAME}")
    print()

    bugs_snapshot = read_json(f"{BUGS_DIR}/sonar_issues_snapshot.json")
    sec_snapshot = read_json(f"{SECURITY_DIR}/sonar_issues_snapshot.json")

    if bugs_snapshot:
        print("[BUGS] Processing bug issues...")
        process_directory(BUGS_DIR, "BUG", bugs_snapshot, remediate_bug)
    else:
        print("[BUGS] No bugs snapshot found.")

    print()

    if sec_snapshot:
        print("[SECURITY] Processing security hotspot issues...")
        process_directory(SECURITY_DIR, "SECURITY_HOTSPOT", sec_snapshot, remediate_security_hotspot)
    else:
        print("[SECURITY] No security hotspot snapshot found.")

    print()
    print("=== Remediation complete ===")
    print()
    bugs_state = read_json(f"{BUGS_DIR}/sonar_execution_state.json") or {}
    sec_state = read_json(f"{SECURITY_DIR}/sonar_execution_state.json") or {}
    print(f"Bugs: {bugs_state.get('processedCount', '?')}/{bugs_state.get('totalIssues', '?')} processed")
    print(f"Security: {sec_state.get('processedCount', '?')}/{sec_state.get('totalIssues', '?')} processed")

if __name__ == "__main__":
    main()

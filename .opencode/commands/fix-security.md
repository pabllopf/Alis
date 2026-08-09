# FIX SECURITY — SonarCloud Bugs & Security Hotspots Remediation

You are a deterministic senior .NET remediation engine specialized in incremental remediation of SonarCloud BUG and SECURITY_HOTSPOT issues.

Project: `pabllopf-official_alis`, language C#, branch `master`.

## SCOPE

Process ONLY `types=BUG` and `types=SECURITY_HOTSPOT` on `branch=master`. Never process CODE_SMELLs, PR analyses, or other branches.

## STATE

All state lives in JSON under `./.opencode/cache/sonar/`, split by issue type:

```text
./.opencode/cache/sonar/bugs/       # snapshot, index, execution_state, worker_locks, execution_log.jsonl
./.opencode/cache/sonar/security/   # same structure
```

Reuse existing cache/state files; never regenerate snapshots unnecessarily.

## WORKING DIRECTORY BOUNDARY

- Operate strictly inside the repository working directory.
- NEVER absolute paths, `~/...`, `../../outside/...`, or `C:\...`.
- Clamp any path escaping the repo root to a repo-relative path.

## TOOLING & AUTH

- Tools ONLY from `./.opencode/tools`; fallback: deterministic Python.
- NEVER install dependencies, fetch remote tooling, or use global system tooling.
- Token from env `SONARCLOUD_TOKEN` only — never hardcode secrets.

## PHASE 1 — SNAPSHOT INGESTION

Only if cache does not exist:

1. Bugs: fetch `types=BUG`, store raw pages to `bugs/sonar_raw_page_<n>.json`, then build `sonar_issues_snapshot.json`.
2. Security: same for `types=SECURITY_HOTSPOT` into `security/`.

## PHASE 2 — DISTRIBUTED REMEDIATION

Worker id: `worker-<machine>-<id>`.

### Locking rules

- Pick first open issue; lock atomically; persist immediately.
- If `status == in_progress` and `assignedWorker != currentWorker`: SKIP.
- Stale locks (older than 60 minutes) may be reclaimed atomically.

### BUG fixes (allowed)

null safety, race condition mitigation, async/await correctness, resource disposal, exception handling, bounds validation, state consistency, thread safety, deterministic initialization, logic correctness, deadlock prevention, collection mutation safety, cancellation token propagation, unsafe cast validation.

### SECURITY_HOTSPOT fixes (allowed)

input validation, sanitization, secret exposure prevention, insecure deserialization mitigation, cryptographic hardening, SQL injection / path traversal / SSRF / XSS mitigation, auth hardening, secure randomness, secure config defaults, unsafe reflection mitigation, insecure protocol removal.

### Forbidden fixes

- redesign architecture, rewrite unrelated modules, breaking API changes, unnecessary behavior changes
- speculative refactors, suppressing issues without justification, disabling security checks
- insecure bypasses, reduced validation coverage

For hotspots: prefer minimal secure fixes, preserve behavior compatibility, add validation rather than removing functionality. Never mark hotspots safe without code verification.

## VALIDATION (PER ISSUE)

1. Run targeted build.
2. Run impacted tests.
3. No new compiler errors, no new analyzer violations in modified scope.
4. Security-sensitive flows still function.

## COMMIT & STATE

After each successfully validated issue:

```bash
git add <modified-files>
git commit -m "fix(<scope>): resolve sonar <issueType> <ruleKey>"
```

Then persist execution state, release the worker lock, mark the issue resolved, and append an execution log entry.

On failure: persist `{"status": "failed", "attemptCount": "+1"}`.

## CONTINUOUS EXECUTION

Continue until `remaining BUG issues == 0` AND `remaining SECURITY_HOTSPOT issues == 0`. No manual stop before full remediation.

Fast mode: minimal reads/writes, local file scope only, no repository-wide scans, no unnecessary builds.

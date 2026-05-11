# AGENT ROUTER

Classify into ONE mode. Enforce it strictly. Prefer FAST_EXEC.

## MODES

### ⚡ FAST_EXEC — direct implementation
Use when: task is well-defined, change is localized, no exploration needed.

### 🧠 EXPLORE — context gathering
Use when: codebase context unknown, symbols/dependencies unclear, feature touches multiple modules.
Rules: read-only, no code changes.

### 🐛 DEBUG — issue resolution
Use when: bug reported, stack trace exists, unexpected behavior.
Rules: trace root cause first, minimal fix, no refactors.

### 🔧 REFACTOR — structural improvement
Use when: design/readability/duplication/architecture.
Rules: behavior unchanged, localized changes.

### ✅ VERIFY — validation
Use when: testing changes, ensuring correctness.
Rules: build → test → fix failures → stop after 2 failed cycles.

## GLOBAL RULES

- One mode per task. No hybrid reasoning.
- Prefer `.info/` over raw exploration.
- Minimize tool calls and file reads.

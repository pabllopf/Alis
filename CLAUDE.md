# CLAUDE.md — FimMarker (.NET 8 · MAUI · Core + Tests)

## ROLE

Senior .NET engineer. Think in systems, act minimally, validate with code.

## EXECUTION RULES

- **Action over explanation.** Minimal diffs. Assume success unless errors shown.
- **Batch tool calls.** Never re-run same command. Prefer grep/search over full file reads.
- **Suppress output.** `> /dev/null` on success, `tail -n 20` on failure. Never pipe full logs into context.
- **No unrelated changes.** No refactors unless asked. Keep changes local and deterministic.

## CODEBASE UNDERSTANDING

1. Entry points first (Program.cs, services, handlers)
2. Grep before reading files
3. Map only impacted modules (max depth 3)
4. Ignore everything else

## .info/ PRIORITY

If `.info/` exists: use it as canonical index (symbols, architecture, dependencies). Fall back to grep only if incomplete.

## PROJECT STRUCTURE

```
FimMarker.slnx
├── FimMarker.Core/      — domain models, services, interfaces, DTOs
├── FimMarker.Maui/      — MAUI UI layer, views, viewmodels, platforms
└── FimMarker.Tests/     — unit/integration tests (xUnit)
```

## BUILD & RUN

| Task | Command |
|------|---------|
| Build | `dotnet build FimMarker.slnx > /dev/null` |
| Run MAUI | `dotnet run --project FimMarker.Maui` |
| Test | `dotnet test FimMarker.Tests/` |

## AFTER CHANGES

Build → Test → Fix failures → Stop after 2 failed cycles.

## ANTI-PATTERNS

Overengineering, guessing without inspection, re-reading files, repeating identical tool calls, explaining instead of executing.

---

# AGENTS TEAM

Spawn agents for parallel or specialized work. The main Claude (Implementer) handles direct coding and delegates when parallelism or deep specialization adds value.

## AGENT ROLES

### 🔍 Researcher (Explore)
**Use when:** need to locate code, trace dependencies, understand patterns across files.
- Fast read-only search. grep, find, partial reads.
- Returns: file paths, line numbers, dependency maps.
- **Never modifies code.**

### 🏗️ Architect (Plan)
**Use when:** design decisions, multi-file changes, API contracts, breaking changes.
- Produces implementation plan with files, line numbers, and trade-offs.
- Returns: step-by-step plan for approval before coding.

### 🧪 Tester
**Use when:** designing test strategy, writing tests for critical logic, validating behavior changes.
- Identifies edge cases, writes xUnit tests following project conventions.
- Returns: test file + brief summary of coverage.

### 🔎 Reviewer (security-review / review)
**Use when:** before merging, after complex changes, security-sensitive code.
- Checks: injection risks, data flow, auth gaps, error handling.
- Returns: vulnerability list with severity and file:line references.

### 🐛 Debugger
**Use when:** complex bug with no obvious root cause, multi-layer stack traces, intermittent failures.
- Traces execution from entry point through layers.
- Returns: root cause + minimal fix proposal.

## DELEGATION PROTOCOL

1. **Single task, localized** → Implementer handles directly (default)
2. **Parallel exploration** → Spawn Researcher(s) in parallel
3. **Design before code** → Architect first, then Implementer
4. **Complex bug** → Debugger traces, Implementer fixes
5. **Before merge** → Reviewer checks, Implementer applies fixes

## DELEGATION RULES

- Each agent gets a **self-contained prompt** (no shared context assumption)
- Agents run **in parallel** when independent
- Implementer **verifies** agent results before acting on them
- Prefer **foreground agents** when results are needed immediately
- Use **worktree isolation** for experimental branches

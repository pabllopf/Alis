# SHARED RULES

## Execution
No explanations. No alternatives. No design discussion. Direct implementation only. Smallest possible change.

## Context
1. Find entry point → 2. Grep first → 3. Identify dependency chain → 4. Map max depth 3 → 5. Ignore rest

## Tool Efficiency
Batch calls. Never re-run same command. Prefer cached knowledge. Avoid reopening seen files.

## Output Control
No intros. No conclusions. No repetition. Only actions or code. Assume success unless failure detected.
Suppress stdout on success (`> /dev/null`). Extract error lines only (`tail -n 20`).

## .info/ Priority
Canonical index for symbols, modules, dependencies, entry points. Fallback to grep only if missing or incomplete.

## .NET Conventions
Assume standard .NET architecture. CLI validation over manual inspection. `dotnet` CLI as primary truth source.

## Verify Loop
Build → Test (if exists) → Fix failures → Stop after 2 failed cycles.

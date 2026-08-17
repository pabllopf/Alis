# State — Context.cs

Target: 1_Presentation/Extension/Graphic/Sfml/src/Windows/Context.cs
Project: 1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 85.00%
Initial branch coverage: 100.00%
Current line coverage: 85.00%
Current branch coverage: 100.00%
Tests before: 1661
Tests after: 1661
Files modified: none
Tests added: 0
Commits: none
Remaining uncovered lines: 96, 97, 98 (empty catch in finalizer)
Remaining uncovered branches: none
Status: BLOCKED
Last update: 2026-08-17

## Blocker

Lines 96-98 are the empty `catch { }` block inside the finalizer:

```
~Context()
{
    try
    {
        sfContext_destroy(myThis);
    }
    catch
    {
    }
}
```

`sfContext_destroy` is a native `void` P/Invoke into csfml-window. It cannot throw
managed exceptions in normal operation. The only managed exceptions a P/Invoke
call can raise are DllNotFoundException / EntryPointNotFoundException, which
require the native module to be absent. On a machine where the module is absent,
the constructor's `sfContext_create()` would already throw before any instance is
finalizable, and the `[RequireCSfmlWindowsFact]` gate would skip the tests.

`myThis` is `internal readonly`, assigned only from the result of `sfContext_create()`.
It cannot be corrupted to a garbage pointer without reflection (forbidden by AOT rules).

Covering the catch would require either:
- reflection to corrupt `myThis` (forbidden), or
- environment manipulation to unload/hide the native module mid-process (coverage
  gaming, and impossible on this machine since the module is loaded process-globally).

This is defensive dead code. Maximum reachable coverage is therefore 85% line /
100% branch, which the existing tests already achieve.

## Reachable behavior already covered by existing tests

- Constructor creates instance (line 59)
- Settings property returns value (line 66)
- Global getter null path (line 78) and cached path (line 79-82) — both branches
- SetActive true/false (line 107)
- ToString returns "[Context]" (line 114)
- myThis field init (line 54)
- Finalizer try path with successful destroy (lines 93-95)
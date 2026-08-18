# State — View.cs Coverage Remediation

Target:
1_Presentation/Extension/Graphic/Sfml/src/Render/View.cs

Project:
1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj

Test project:
1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj

Agent:
big-pickle (opencode)

Baseline commit:
0a990b0e868fe4bef7b40bba91c89fe96c571dd7

Initial line coverage:
97.91% (47/48 sequence points)

Initial branch coverage:
100% (2/2 branches)

Current line coverage:
97.91% (47/48 sequence points)

Current branch coverage:
100% (2/2 branches)

Tests before:
28 (ViewTest.cs) + 1 (ViewExecutionTests.cs) = 29 View-related tests

Tests after:
28 (ViewTest.cs) + 1 (ViewExecutionTests.cs) = 29 View-related tests (no change needed)

Files modified:
None

Tests added:
None (existing tests already cover all reachable code)

Commits:
None

Remaining uncovered lines:
Line 156 — closing brace of `Reset(FloatRect rectangle)` method

Remaining uncovered branches:
None (2/2 branches covered)

Status:
BLOCKED

Last update:
2026-08-18T20:10:00Z

## Blocker Explanation

Line 156 is the closing brace of the `Reset(FloatRect rectangle)` method. The method body is:

```csharp
public void Reset(FloatRect rectangle)
{
    sfView_reset(CPointer, rectangle);
}
```

The only way to reach line 156 (the method's return point) is if `sfView_reset` completes successfully. However:

1. CSFML 3.0 (installed via Homebrew at `/opt/homebrew/Cellar/csfml/3.0.0/`) removed the `sfView_reset` symbol
2. `nm -gU` on `libcsfml-graphics.3.0.dylib` confirms the symbol does not exist
3. Every call to `Reset()` throws `System.EntryPointNotFoundException`
4. The exception propagates out of the method, preventing the closing brace from being reached
5. No native CSFML 2.x library is available on this system

The existing test `ViewExecutionTests.Reset_WithFloatRect_Executes` deliberately verifies this behavior by asserting `EntryPointNotFoundException`.

This is a legitimate blocker — the uncovered line is unreachable because the native function it depends on was removed in the installed CSFML version. Covering it would require either:
- Installing CSFML 2.x (different API version, not available)
- Creating a stub native library (out of scope for unit testing)
- Modifying production code to remove the `Reset` method (not allowed per rules)

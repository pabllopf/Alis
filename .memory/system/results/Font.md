# Result: Font.cs

File: `4_Operation/Graphic/src/Ui/Font.cs`
CoverageBefore: 38.4% (SonarCloud stale; local coverlet 450/456 = 98.7%)
CoverageAfter: 98.7% (450/456 lines, local coverlet; unchanged)
TestsAdded: 0 (remaining lines require live GL context; production boundary)
Commit: test: coverage Font.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Font.cs is the OpenGL font renderer (35 complexity / 135 LOC per SonarCloud). The committed
suite (`FontCoverageTests.cs` / `FontSafeTests.cs` / `FontRenderCoverageTests.cs` /
`FontRemainingCoverageTests.cs` / `FontRemainingBranchCoverageTests.cs` / FontManager family)
covers 450/456 lines locally (98.7%); targeted run: all Font-filtered tests pass on
`Alis.Core.Graphic.Test` (net8.0).

Covered: construction, ShaderProgram compilation/link, LoadTexture file and resource branches,
SetupBuffers, RenderText full path (with loaded path and NameFile-init branches), CharacterRects
setup, Dispose, and the FontManager surface.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

- 201 — closing brace of the `LoadTexture` resource fallback branch. The call
  `Image.LoadImageFromResources(NameFile)` (line 200) always throws in the test environment
  (no embedded font resource in the running assets.pack), so the branch never completes.
- 330-331 — `LoadTexture(Path)` + `SetupBuffers()` inside the `RenderText` NameFile-init branch.
  `LoadTexture(string.Empty)` throws before line 331 can complete; a successful execution
  requires a live GL context plus a resolvable font resource, which the test host (running
  `Gl.Initialize(null)`) deliberately does not provide.

All three are GL-context/resource-boundary lines unreachable from a headless test host; covering
them requires a live OpenGL context and the packed font asset — out of scope for coverage work.

## Verification

- Targeted run: all Font tests pass (net8.0).
- Local coverlet: Font.cs 450/456 lines (98.7%).

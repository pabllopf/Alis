# Result: Shader.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 358/376 = 95.2%)
CoverageAfter: 95.2% (358/376 lines, local coverlet; unchanged)
TestsAdded: 0 (blocked)
Commit: test: coverage Shader.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Shader.cs is the SFML shader wrapper (54 complexity / 350 LOC per SonarCloud) over the CSFML
`Csfml.Graphics` P/Invoke surface (shader creation from file/memory/stream, uniform setters,
the legacy SetParameter overload family, Bind, Dispose). The committed
`ShaderExecutionTests.cs` / `ShaderTest.cs` / `ShaderRemainingCoverageTests.cs` already cover
358/376 lines (95.2%); the Shader-filtered run passes 79 tests, 0 skipped.

## Remaining uncovered lines (9) — BLOCKED_BY_PRODUCTION_CODE

All 9 lines are the closing braces of the legacy `SetParameter` overloads whose native calls
throw `EntryPointNotFoundException` (the installed libcsfml-graphics no longer exports the old
`sfShader_set*Parameter` symbols; the current API is `sfShader_set*Uniform`):

- 558 — `SetParameter(string, float)` → `sfShader_setFloatParameter` (line 557 throws).
- 573 — `SetParameter(string, float, float)` → `sfShader_setFloat2Parameter` (572 throws).
- 589 — `SetParameter(string, float, float, float)` → `sfShader_setFloat3Parameter` (588 throws).
- 606 — `SetParameter(string, float, float, float, float)` → `sfShader_setFloat4Parameter` (605 throws).
- 620 — `SetParameter(string, Vector2F)` → delegates to the float2 overload (619 throws).
- 634 — `SetParameter(string, Color)` → `sfShader_setColorParameter` (633 throws).
- 648 — `SetParameter(string, Transform)` → `sfShader_setTransformParameter` (647 throws).
- 668 — `SetParameter(string, Texture)` → `myTextures[name] = texture` runs, then
  `sfShader_setTextureParameter` (667 throws).
- 685 — `SetParameter(string, CurrentTextureType)` → `sfShader_setCurrentTextureParameter` (684 throws).

The existing tests already exercise every one of these overloads via
`Assert.Throws<EntryPointNotFoundException>` (ShaderExecutionTests.cs:399-463+) under
`[RequireCSfmlGraphicsFact]` (lib loads — `Shader.FromString` succeeds — but the legacy
entry points are absent). The closing brace is only reachable if the native call completes,
which requires a CSFML build that still exports the old symbols. Same blocked pattern as the
ImPlotP11 / ImPlotP15 closing braces and ImGuiP4 InputText bodies.

Sfml-filtered run: 79 passed / 0 skipped on `Alis.Extension.Graphic.Sfml.Test` (net8.0).

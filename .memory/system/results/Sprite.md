# Result: Sprite.cs (Application)

File: `2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (216/216 lines, local coverlet)
TestsAdded: 2 (SpriteRenderCoverageTests.cs: resource-load fallback + render empty-path branch)
Commit: test: coverage Sprite.cs
Status: PARTIALLY_REMEDIATED

## Summary

Sprite.cs is the ECS render sprite component (record struct; 216 instrumented lines). The
committed suite already covered 214/216 (99.1%); the two remaining lines were the closing
braces of the embedded-resource texture-load fallback (line 323) and the render-time
empty-path shared-resource branch (line 357). This session added two tests to
`SpriteRenderCoverageTests.cs` (reusing its fake-OpenGL delegate infrastructure) that drive
`LoadTexture(string.Empty)` with `NameFile = "dino_assets.bmp"` (loaded from the packed test
assets via AssetRegistry) and `Render` with an empty Path, covering both lines. Local coverlet
(net8.0, Debug, Sprite filter — 70 tests) measures 216/216 lines (100.0%).

## Verification

- Sprite filter (net8.0, Debug): 70 passed, 0 failed, 0 skipped.
- Local coverlet: Sprite.cs 216/216 lines (100.0%), no uncovered lines.

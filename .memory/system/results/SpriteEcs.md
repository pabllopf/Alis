# Sprite.cs (ECS) — Coverage Result

`2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs` — `record struct Sprite(Context, string NameFile, int Depth) : ISprite`.

## Status
COVERED — 100% line / 100% branch (line-rate 1, branch-rate 1, complexity 51).

SonarCloud reported 36.3% (34.3% line / 47.5% branch). Local instrumented baseline was **74/216 = 34.3%**. After remediation: **214/214 instrumentable lines (100.0%)**.

## What was covered
The previous suite (9 files incl. `SpriteEnhancedCoverageTests`) covered record members, `IsSpriteVisible` and the GL-throw error paths. All real-GL happy paths were unreachable without a context + native GL. This remediation injects a **fake OpenGL function-pointer table** through `Gl.Initialize(GetProcAddressDelegate)` and drives:

- `OnExit` 165-170 — texture-release branch with fake `DeleteTexture`.
- `InitializeSharedResources` 185-299 — full shader build/link/buffer/VAO setup, twice (early-return exit on `SharedInitialized`), plus both shader-header variants (`PreviewMode` true/false).
- Error branches 222-238, 246-250 — vertex/fragment compile-fail and link-fail with non-empty info logs → `InvalidOperationException`.
- `LoadTexture` 315-341 — file-exists path via a real temp BMP and the embedded-resource fallback via the test assembly's packed `dino_assets.bmp`.
- `Render` 352-401 — whole draw path through a live `Scene` entity with a `Transform`, including the `NameFile != ""` initializer entry that also triggers `InitializeSharedResources` + resource `LoadTexture`, texture bind, and flip branch.
- `BindTexture` 342-345 — `GlActiveTexture`/`GlBindTexture` once texture differs from `LastBoundTexture`.

## Method
Example: `Gl.Initialize(SuccessResolver())` where `SuccessResolver()` maps each `glX` name to `Marshal.GetFunctionPointerForDelegate(fake delegate)` typed exactly per the public delegate (`Alis.Core.Graphic.OpenGL.Delegates.*`, `Gl.*`). Resolver variants:

- `SuccessResolver` — 33 entry points, shaders/program compile+link OK.
- `CompileFailResolver` — `GetShaderiv` returns CompileStatus=0 and InfoLogLength>0.
- `FragmentFailResolver` — first CompileStatus query OK, second fails (fragment-only).
- `LinkFailResolver` — `GetProgramiv` returns LinkStatus=0 and InfoLogLength>0.

Private statics/members reached via reflection: `Gl._getProcAddress` (save/restore in ctor/Dispose), `Sprite` statics (`SharedInitialized`, `LastBoundTexture`), instance backing fields (`Texture`, `Size`, `Flip`), and private/internal methods (`InitializeSharedResources`, `LoadTexture`, `Render`, `OnExit` invoked on a **boxed** copy so struct mutations persist).

## Test changes
- **Added** `2_Application/Alis/test/Core/Ecs/Components/Render/SpriteGlCoverageTests.cs` (11 tests).
- Build: `dotnet test 2_Application/Alis/test/Alis.Test.csproj -c Debug -f net8.0 --filter "FullyQualifiedName~SpriteGlCoverageTests"` → 11/11 green.
- Full Alis.Test suite: 943 passed / 4 skipped / 0 failed (Regressions: none; `Gl` resolver restored per-test).
- Commit: `test: coverage Sprite.cs`.

## Notes / limitations
- 3 changed-lines attempted first hit reflection-invoke wrapping (`TargetInvocationException`) and struct-by-value mutation loss; fixed via `ExceptionDispatchInfo` unwrap and invoking on the boxed box.
- The fragment-fail branch required a per-resolver captured counter (vertex OK → fragment fail), not the single shared delegate.
- No `.csproj`, `src` edits, or third-party dependencies introduced.
## Re-verification (2026-09-06, auto loop)
Re-issued by SonarCloud (36.3%, stale CI delta). SpriteGlCoverageTests re-run: 11/11 green,
Alis.Test build clean. No test/production changes; committed 100% line/branch baseline stands.

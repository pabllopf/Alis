# BoxCollider.cs — Coverage Results

**File**: `2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs` (558 lines)
**Task**: SonarCloud skip 136

## Result

| Metric | Before | After |
|---|---|---|
| BoxCollider class | 122/178 (68.5%) | **261/261 (100.0%)** |
| BoxCollider/BoxColliderSettings | — | 17/17 (100.0%) |

Branch coverage for the class region is complete (all `if/else` arms of `OnCollision`/`OnSeparation` exercised both ways).

## Uncovered → Covered

- **54-59** (`Vertices` static array data) — hit via `RenderBoxCollider`'s `GlBufferData` path.
- **249-306** `OnStart`/`OnExit` — real physics body creation (`WorldPhysic.CreateRectangle`) and removal (`WorldPhysic.RemoveBody`) via live entities.
- **383-451** `InitializeShaders` (GL) — fake-GL resolver drives `glCreateProgram`/`glCreateShader`/`glShaderSource`/`glCompileShader`/`glAttachShader`/`glLinkProgram`, both desktop and PreviewMode contexts.
- **460-536** `Render`/`RenderBoxCollider` (GL) — full draw path incl. init-in-Render branch, flip, buffer upload, `glEnableVertexAttribArray`/`glVertexAttribPointer`/`glUseProgram`/`glDrawArrays`.
- **325-336 / 365-376** — `OnCollision`/`OnSeparation` `else if` branches: reversed fixture order dispatches into the `IOnCollisionEnter`/`IOnCollisionExit` dispatch loops (both directions).

## Tests Added

`2_Application/Alis/test/Core/Ecs/Components/Collider/BoxColliderGlCoverageTests.cs` (8 tests, `BoxColliderGlCoverageTests : IDisposable`):

1. `InitializeShaders_WithDesktopContext_CreatesProgram`
2. `InitializeShaders_WithPreviewModeContext_CreatesProgram`
3. `Render_WithGlFields_CallsStart`
4. `Render_SecondCall_DoesNotReinitialize`
5. `OnStart_WithEntity_CreatesBody`
6. `OnExit_WithBody_RemovesBody`
7. `OnCollision_WithCollisionEnterComponent_Executes` (both if and else-if dispatch directions)
8. `OnSeparation_WithCollisionExitComponent_Executes` (both directions)

Technique: `Gl.Initialize(GetProcAddressDelegate)` with a resolver over the 15 GL entry points used by the class; `GlField` save/restore; reflection on the private `OnCollision`/`OnSeparation`/`InitializeShaders` methods and `Body.FixtureList` (internal — cast to `IList<Fixture>`); `KeyResolver` delegates; `Body.Tag` holds the `GameObject` entity (not the collider); `Component.RegisterComponent<T>` required for the `IOnCollisionEnter`/`IOnCollisionExit` spy structs.

## Evidence

- Targeted: 8 passed / 0 failed / 0 skipped
- Full `Alis.Test` (net8.0, coverlet): 951 passed / 4 skipped / 0 failed
- Committed: `test: coverage BoxCollider.cs`
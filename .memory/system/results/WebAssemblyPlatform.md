# Result: WebAssemblyPlatform.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatform.cs` (543 LOC / 204 complexity)
Task: SonarCloud skip 142 (re-issue — previously remediated in `648bd6a98`)

## Result

| Metric | Before | After |
|---|---|---|
| Local coverlet | 303/416 (72.8%) | **307/416 (73.8%)** |
| SonarCloud | 74.4% line / 75.3% overall | — |

Suite: 1535 passed / 613 skipped / 0 failed (Alis.Core.Graphic.Test, net8.0, coverlet).

## New coverage (this session)

`WebAssemblyPlatformTests.cs` (+1 test `MakeContextCurrent_WithValidHandles_ExecutesGuard`):
reflects the private `_eglDisplay`/`_eglSurface`/`_eglContext` fields to non-zero and drives
`MakeContextCurrent()`/`SwapBuffers()` through their non-trivial guard branches
(lines 626-627, 637-638) +4 lines. Wrapped in `try/catch (DllNotFoundException)` so it is
CI-agnostic (passes both with and without a native libEGL).

## Remaining uncovered (109) — BLOCKED

- **159-160, 169-171, 187-246** — `Initialize` success/early-return and the entire
  `InitializeEglContext` body (incl. all `EGL.*` failure throws): require a usable native
  `libEGL` (absent on macOS; stub dylib deliberately rejected — would break the existing
  `Initialize_*_ReturnsFalse` CI assertions and Linux runs).
- **628, 639** — closing-brace branch attributions of the guard bodies (executed; coverlet
  branch quirk).
- **272-275, 292-295, 310-316, 332-338, 755-761** — `Register*Events`/`SetWindowIcon`
  catches: dead by construction. The `EmscriptenWeb.Register*Callbacks`/`SetWindowIcon`
  wrappers swallow the native `DllNotFoundException` internally, so the Platform-level
  catch blocks are unreachable.
- **532-543** — `UpdateGamepadStates` loop + catch: `GetConnectedGamepads()` returns
  `Array.Empty<int>()` (wrapper swallows) so the `foreach` never iterates; catch dead.
- **563-578** — `UpdateSingleGamepadState`: never invoked (no gamepad indices) and its
  native axes/buttons getters return empty arrays.
- **669-691** — `Cleanup` body: gated on `_isInitialized`, which only becomes true after
  full EGL initialization.
- **742** — `IsKeyDown` dictionary-miss `return false;`: unreachable by construction — the
  constructor `InitializeDefaultKeyStates()` registers every `ConsoleKey` value including
  `NoName`.

Earlier blocked-verified items (per prior doc) remain: none re-opened.

## Verification

- Targeted `WebAssemblyPlatformTests`: 35 passed, 0 failed.
- Full Graphic suite: 1535 passed / 613 skipped / 0 failed.
- Committed: `test: coverage WebAssemblyPlatform.cs`

---

## Re-verification (fresh run, 2026-09-07)

Clean re-run of the WebAssemblyPlatform-filter coverage on macOS (net8.0):
- Local coverlet: **614/832 (73.8%)**, 218 uncovered executable lines.
- Filter `FullyQualifiedName~WebAssemblyPlatform`: 97 passed / 181 skipped / 0 failed.

The uncovered set is unchanged and every line remains **BLOCKED_BY_PRODUCTION_CODE** — each
requires a usable native `libEGL` / `emscripten` browser runtime or a production change:

- **159-160, 169-171, 184-246** — `Initialize` early-return/success and `InitializeEglContext`
  body (all `EGL.*` native calls + failure throws).
- **262-338 catches** — `Register*Events` dead catches (`EmscriptenWeb` swallows natively).
- **532-543** — `UpdateGamepadStates` foreach + catch (`GetConnectedGamepads()` returns empty).
- **563-578** — `UpdateSingleGamepadState` axes/buttons branches (native getters return empty).
- **628, 639** — coverlet closing-brace attribute of the executed guard native calls.
- **669-691** — `Cleanup` body, gated on `_isInitialized` (only after successful EGL init).
- **742** — `IsKeyDown` dict-miss `return false;` (all `ConsoleKey` values pre-registered).
- **755, 757, 761** — `SetWindowIcon` dead catch.

No reachable uncovered branch exists on a headless macOS host without production changes.
No new tests were added this run; no commit made.
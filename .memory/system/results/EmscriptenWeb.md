# EmscriptenWeb.cs — Coverage Remediation Results

## File
`4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs`

## Metrics
- **CoverageBefore**: 82.22% (546/664 lines) — 86.7% unique (273/332)
- **CoverageAfter**: 82.22% (unchanged — no new lines coverable)
- **TestsAdded**: 0
- **Commit**: none
- **Status**: BLOCKED_BY_PRODUCTION_CODE

## Analysis

All 59 unique uncovered lines are unreachable on macOS (non-emscripten host):

### Category 1: Native P/Invoke call lines (13 lines)
Lines 498, 520, 540, 561, 669, 687, 705, 723, 741, 996, 1141, 1159, 1177
These are call sites to `[DllImport("emscripten")]` native methods inside `try` blocks. On macOS, the runtime throws `DllNotFoundException` before coverlet can record the line as hit. The `catch` blocks ARE covered (proving the wrapper methods are invoked), but the call lines themselves are not counted.

### Category 2: Success-path code (46 lines)
- Lines 579-593 (`GetConnectedGamepads` success branch)
- Lines 609-623 (`GetGamepadAxes` success branch)
- Lines 639-653 (`GetGamepadButtons` success branch)
- Lines 924-929 (`OpenFileDialog` success branch with `Marshal.PtrToStringAnsi`)
- Lines 975-980 (`PasteFromClipboard` success branch with `Marshal.PtrToStringAnsi`)
- Lines 1029-1035 (`GetLanguage` success branch with `Marshal.PtrToStringAnsi`)

These lines are only reachable when native calls return successfully. Since native calls always throw on macOS, these branches are never taken.

## Existing Test Coverage
`EmscriptenWebExecutionTests.cs` contains 51 `[Fact]` tests that invoke every public method on the class, exercising all catch/fallback paths. All tests pass on macOS.

## Why BLOCKED
- All uncovered code requires the native "emscripten" library (WebAssembly builds only)
- No mocking is possible for static P/Invoke calls without production code changes
- Success paths require native data return values that cannot be fabricated
- `[WebOnly]` tests (in `EmscriptenWebTests.cs`) correctly skip on non-web platforms

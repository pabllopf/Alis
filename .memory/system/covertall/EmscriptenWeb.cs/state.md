# State — EmscriptenWeb.cs

Target: 4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs
Project: 4_Operation/Graphic/src/Alis.Core.Graphic.csproj
Test project: 4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 82.23% (273/332)
Initial branch coverage: 9.09% (2/22)
Current line coverage: 82.23%
Current branch coverage: 9.09%
Tests before: 1559 passed / 613 skipped
Tests after: 1559 passed / 613 skipped
Files modified: none
Tests added: 0
Commits: none
Remaining uncovered lines: 454,476,496,517,535-549,565-579,595-609,625,643,661,679,697,880-885,931-936,952,985-991,1097,1115,1133
Remaining uncovered branches: lines 535,543,565,573,595,603,880,931,985,991 (both paths each)
Status: BLOCKED
Last update: 2026-08-17

## Blocker

Every public wrapper in `EmscriptenWeb` wraps a `[DllImport("emscripten", ...)]`
call in try/catch. On macOS the "emscripten" module does not exist, so every
native call throws DllNotFoundException and control jumps directly to the catch
block, skipping:

- the closing brace sequence point of each try block
  (lines 454, 476, 496, 517, 625, 643, 661, 679, 697, 952, 1097, 1115, 1133), and
- all success-path logic after a successful native call:
  GetConnectedGamepads (535-549), GetGamepadAxes (565-579),
  GetGamepadButtons (595-609), OpenFileDialog (880-885),
  PasteFromClipboard (931-936), GetLanguage (985-991).

Those paths require a live WebAssembly/emscripten runtime where the JS glue
exports registerKeyboardCallbacks, getConnectedGamepads, etc. Such a runtime
cannot be loaded on macOS. The repository's own convention acknowledges this:
`EmscriptenWebTests` uses `[WebOnly]` and its 613 tests are skipped on this
platform.

Covering the success paths would require either:
- running inside a WebAssembly browser runtime (unavailable), or
- fabricating a fake "emscripten" native module with the full JS-glue symbol
  surface, which is environment manipulation / coverage gaming and forbidden.

## Reachable behavior already covered

All 30+ wrapper methods' try (throwing call) and catch/fallback paths are
covered by EmscriptenWebExecutionTests.cs ([Fact]) — fallback return values
(empty arrays, 0, 1.0f, false, null, "en") are asserted. The `mimeTypes ?? "*/*"`
null-coalescing branch (line 879) is covered via null / non-null calls.
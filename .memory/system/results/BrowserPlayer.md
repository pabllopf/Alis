# Result: BrowserPlayer.cs

File: `4_Operation/Audio/src/Players/BrowserPlayer.cs`
CoverageBefore: 76.9% (SonarCloud); local coverlet baseline 76.5% line / 89.3% branch
CoverageAfter: 77.9% line / 89.3% branch (local coverlet, net8.0)
TestsAdded: 3 (BrowserPlayerRemainingCoverageTests.cs)
Commit: test: coverage BrowserPlayer.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

BrowserPlayer.cs is an OpenAL-backed `IPlayer` with WAV chunk parsing (openal32 P/Invokes).
The committed suite (10 test files) covers the WAV parsing and error paths; the remaining
uncovered lines are all behind the native `openal32` boundary which does not exist on macOS
(DllNotFoundException), plus the two managed-only members PlayLoop/SetVolume.

## Work performed

Added 3 tests to `BrowserPlayerRemainingCoverageTests.cs` using the established
`FormatterServices.GetUninitializedObject` + `AssetRegistryTestHelper` pattern (no native
OpenAL required, deterministic, no filesystem side effects):
- `PlayLoop_WithMissingResource_ThrowsFileNotFoundException` — covers the PlayLoop arrow body
  (line 188) through the Play missing-resource path.
- `PlayLoop_WithFalseAndMissingResource_ThrowsFileNotFoundException` — same with loop=false.
- `SetVolume_ReturnsCompletedTask` — covers the SetVolume completed-task body (line 228).

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 72-98 — the constructor OpenAL init chain (alcOpenDevice / alcCreateContext /
  alcMakeContextCurrent / alGenSources / alGenBuffers): `openal32` cannot be resolved on this
  host (DllNotFoundException before any managed line runs); the browser-only stub-mode tests
  (`/tmp/openal_stub_mode.txt`) are `[BrowserOnly]`-gated and skipped on macOS.
- 196-199, 207-210, 218-221 — Pause/Resume/Stop state mutation: `alSourceStop`/`alSourcePlay`
  P/Invoke throws DllNotFoundException before the managed lines execute on this host.

## Verification

- Targeted run: 3 passed / 0 failed (net8.0).
- Merged BrowserPlayer suite: all pass; BrowserPlayer.cs 77.9% line / 89.3% branch (was 76.5%).
- Full Audio test project builds clean.

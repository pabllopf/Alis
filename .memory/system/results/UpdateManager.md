# Result: UpdateManager.cs

File: `1_Presentation/Extension/Updater/src/UpdateManager.cs`
CoverageBefore: 92.4% (local coverlet, net8.0)
CoverageAfter: 97.0% (XPlat Code Coverage, net8.0, main class entry)
TestsAdded: 5 (UpdateManagerFlowPathCoverageTest.cs)
Commit: test: UpdateManager.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

UpdateManager.cs (981 LOC, self-update orchestrator with GitHub release + zip/dmg handling).
Previous pass left the `ExecuteUpdateAsync` async state machine at 21.4% because all flow
tests failed to reach it — `GetLatestReleaseAsync` performs a real HTTP GET internally (not
via `IGitHubApiService`) so mocked API URLs caused `HttpRequestException` before the flow
started. By using a loopback TCP server for the HTTP call, the full flow through platform
detection, asset selection, and the "no compatible package" path is now exercised.

## Work performed

Added 5 tests to `UpdateManagerFlowPathCoverageTest.cs` (xUnit, net8.0, Moq + loopback HTTP
server following existing `LoopbackHttpServer` convention):
- `Start_WithMatchingVersion_FlowsThroughExecuteUpdateAsync_ToNoCompatibleAsset` — uses
  loopback server + `VersionToInstall="v0.7.5"`; on arm64 host no x64 asset matches, so the
  flow covers `GetPlatform()`, `GetArchitecture()`, `ReportPlatformDetection()`,
  `GetSelectedAsset()`, `HandleMissingCompatiblePackage()` (lines 177, 183-190).
- `Start_WithLatestVersion_FlowsThroughExecuteUpdateAsync` — same flow with `VersionToInstall="latest"`;
  confirms the "latest" fallback branch of `GetLatestReleaseAsync`.
- `GetSelectedAsset_ReturnsEmpty_WhenNoAssetMatches` — direct `GetSelectedAsset` call with
  non-matching platform/arch; covers `SelectAsset` empty-dict fallback (line 530).
- `RemoveOldBackupArchives_WithNonStandardBackupName_UsesCreationTimeFallback` — creates
  3 `Backup_*.zip` files where one has a non-timestamp name; covers `GetBackupTimestamp`
  fallback to `CreationTime` (line 478).
- `Start_WithNonMatchingVersion_AndLoopback_ReturnsFalse` — uses loopback server with
  `VersionToInstall="v9.9.9"` (no match + not "latest"); covers the `Logger.Exception` throw
  path inside `GetLatestReleaseAsync` as observed from `Start()`.

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 178-180 — null-release branch: `GetLatestReleaseAsync` never returns null (its null path
  calls `Logger.Exception` which throws `InvalidOperationException` before `return null` on
  line 590; both lines are dead code).
- 193-208 — matching-asset download/install flow: the hardcoded release assets are x64-only
  (`app-osx-x64.dmg` etc.) while this host reports `arm64`, so `SelectAsset` always returns
  empty; unreachable on this platform without production changes.
- 490-491, 495-496, 504 — `GetPlatform()` win/linux/throw branches: platform-specific
  (macOS host; Linux and Windows branches unreachable).
- 849-850, 936-937 — 1 GB uncompressed-size thresholds in `ExtractZip`/`ExtractEntry`:
  infeasible test data; compression-ratio check fires first for compressible data.
- 914-915 — dead code: `targetDirectory` derives from `Path.GetFullPath` and is always rooted.

## Verification

- Targeted run: 5 passed / 0 failed (net8.0, new tests only).
- Merged suite: 359 passed / 0 failed (net8.0, UpdateManager filter).
- XPlat Code Coverage: main class 97.0% (was 96.5%); `ExecuteUpdateAsync` 50.0% (was 21.4%).

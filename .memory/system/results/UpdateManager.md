# Result: UpdateManager.cs

File: `1_Presentation/Extension/Updater/src/UpdateManager.cs`
CoverageBefore: 86.3% (SonarCloud); local coverlet baseline 89.6% line (424/473)
CoverageAfter: 92.4% line (437/473, local coverlet, net8.0)
TestsAdded: 3 (UpdateManagerFlowCoverageTests.cs)
Commit: test: coverage UpdateManager.cs
Status: PARTIALLY_REMEDIATED

## Summary

UpdateManager.cs (981 LOC, self-update orchestrator with GitHub release + zip/dmg handling).
Local coverlet showed 49 uncovered lines; the committed "remaining coverage" tests were
vacuous — `GetLatestReleaseAsync` performs a real HTTP GET to `GitHubApiService.ApiUrl`
(unconfigured mock → ArgumentNullException before the null-check) so the flow tests only ever
covered the exception wrapper.

## Work performed

Added 3 tests to `UpdateManagerFlowCoverageTests.cs` (xUnit, net8.0, Moq + loopback HTTP
server following the existing `LoopbackHttpServer` convention):
- `GetLatestReleaseAsync_WithMatchingVersion_ReturnsRelease` — server-backed success with
  `VersionToInstall="v0.7.5"`; covers the matched-version branch (577-579).
- `Start_WithNoCompatiblePackage_ReturnsFalse` — server-backed `Start("latest")`; covers the
  platform-detection report + missing-compatible-package flow (177, 183-190, 530).
- `RemoveOldBackupArchives_DeletesOldestArchives` — creates 3 timestamped + 1 non-timestamped
  `Backup_*.zip` in the test output directory; covers the `GetBackupTimestamp` fallback to
  `CreationTime` (478) and the retention pruning. Asserts only on its own files to stay
  deterministic under xUnit's parallel collections.

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 178-180 — null-release branch: `GetLatestReleaseAsync` never returns null (its null path
  calls `Logger.Exception` which throws InvalidOperationException, line 589-590; 590 is dead).
- 193-208, 334-339 — matching-asset download/install flow: the hardcoded release assets are
  x64-only (`app-osx-x64.dmg` etc.) while this host reports `arm64`, so `SelectAsset` always
  returns empty; unreachable on this platform.
- 490-496, 504 — GetPlatform win/linux/throw branches: platform-specific (macOS host).
- 682-685 — dmg extraction: invokes `hdiutil` system tooling with a real dmg.
- 849-850, 936-937 — 1GB uncompressed-size thresholds: infeasible test data.
- 914-915 — dead: `targetDirectory` derives from `Path.GetFullPath` and is always rooted.

## Verification

- Targeted run: 3 passed / 0 failed (net8.0).
- Merged suite: 353 passed / 0 failed (net8.0, UpdateManager filter).
- Local coverlet: 437/473 = 92.4% line (was 89.6%).

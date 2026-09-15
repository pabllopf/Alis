# UpdateManager.cs Coverage Remediation Result

## File
1_Presentation/Extension/Updater/src/UpdateManager.cs

## Coverage (local coverlet net8.0)
- After: 92.8% (878/946 across class + async state machines)
- Remaining uncovered are blocked:
  - 490-491, 495-496, 504 GetPlatform win/linux/throw — platform-bound (unreachable on macOS).
  - 849-850, 936-937 zip/entry >1GB size thresholds — impractical to materialize.
  - 914-915 ExtractEntry non-rooted path — unreachable (targetDirectory always rooted).
  - ExecuteUpdateAsync 177-208 — hardcoded assets only match osx-x64, so the download/install
    path is not reachable on arm64; on x64 CI the loopback HTTP helper is flaky.
  - 590 GetLatestReleaseAsync null-return — depends on flaky loopback.

## New test
UpdateManagerExtractAndReplaceTest.cs: ExtractAndReplace_WithHighCompressionRatio_Throws
(zip-bomb rejection, deterministic, no network).

## Status
COMPLETED (practical ceiling for deterministic tests)

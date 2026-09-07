# GoogleDriveCloudManager.cs

## File
`1_Presentation/Extension/Cloud/GoogleDrive/src/GoogleDriveCloudManager.cs`

## Coverage Before
- SonarCloud: 96.8% (Line 98.0%, Branch 92.2%)
- Local coverlet (net8.0, 83-test suite): main class line 0.909, branch 0.875; uncovered lines 138-142, Dispose(bool) line 484 partial 75%

## Coverage After (local coverlet, 85-test suite)
- Main class: line 0.909, branch 100% (all conditions 100%, incl. Dispose(bool) line 484 now 4/4)
- Only lines 138-142 remain uncovered (catch/rethrow block in InitializeAsync)

## Tests Added
`test/GoogleDriveCloudManagerDisposeTest.cs` — 2 tests:
1. `Dispose_WithDisposeFalse_DoesNotThrow` — covers `disposing=false` short-circuit branch of `Dispose(bool)` (line 484, was 75% → 100%).
2. `Dispose_WithDisposeFalse_Uninitialized_DoesNotThrow`.

`d__10`/`d__11`/`d__12` state-machine branch rates (UploadFileAsync/DownloadFileAsync/ListFilesAsync) remain partial only in API-response branches requiring real Drive HTTP calls.

## Attempted but reverted (unreachable confirmed)
An `InitializeAsync` test with a malformed token string did **not** throw: `GoogleCredential.FromAccessToken` accepts any non-null token string without validating it, and `DriveService` construction does not throw. Therefore the catch/rethrow block (lines 138-142) is unreachable through the public API — a defensive guard around library instantiation that cannot be triggered without mocking the non-injectable concrete Google.Apis types (rule: mocks only for interfaces/external deps, no reflection). Removed and documented.

## Remaining uncovered (dead defensive guards, unreachable)
- **Lines 138-142** (`InitializeAsync` catch/rethrow): unreachable via public API — `GoogleCredential.FromAccessToken` does not throw on arbitrary token strings and `DriveService` construction succeeds. Defensive, non-injectable.
- Partial `d__10` line 166, `d__11` line 215, `d__12` line 242 branch halves: API-response branches (`response.Status == Completed`, empty non-null directory checks, `result.Files != null`) that require live Drive HTTP responses.

## Status
COMPLETED (all reachable branches covered; remaining lines are defensive/unreachable or require live API calls)
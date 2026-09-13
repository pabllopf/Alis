# FilePickerResult.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Io/FileDialog/src/FilePickerResult.cs
- CoverageBefore: 98.3% (1 uncovered condition of 10, per SonarCloud master cache 2026-09-13T17:39:53; 0 uncovered lines)
- CoverageAfter: 98.3%
- TestsAdded: 0
- Commit: test: FilePickerResult.cs
- Status: BLOCKED_BY_PRODUCTION_CODE

Notes: The single uncovered condition is the null-conditional in SelectedPath (SelectedPaths?.FirstOrDefault(), sl 112). SelectedPaths has a private setter and is always assigned a non-empty List<string> by every constructor and factory (CreateSuccess, CreateCancelled, CreateError), so the null branch can never be reached through any public API. Covering it requires production change (removing the defensive ?.) or reflection-based testing, both forbidden here (src/ is read-only, AOT rules ban reflection). Almost all users call SelectedPath only after IsSuccess, so this is a defensive guard.
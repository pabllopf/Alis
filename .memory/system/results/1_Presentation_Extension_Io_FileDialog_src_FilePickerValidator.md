# FilePickerValidator.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Io/FileDialog/src/FilePickerValidator.cs
- CoverageBefore: 99.0% (2 uncovered conditions of 66, per SonarCloud master cache 2026-09-13T17:39:53; 0 uncovered lines)
- CoverageAfter: 99.0%
- TestsAdded: 0
- Commit: test: FilePickerValidator.cs
- Status: BLOCKED_BY_PRODUCTION_CODE

Notes: The 2 uncovered conditions are defensive null branches that no public input can reach: (1) Path.GetExtension(filePath)?.TrimStart('.') at sl 175 — GetExtension returns non-null for every non-null path and filePath is null-checked earlier, so the ?. null outcome is unreachable; (2) result.SelectedPaths == null in HasSelectedPaths at sl 235 — SelectedPaths is private-set and always a non-empty List<string> from every factory, so the null outcome is unreachable. The conditions_to_cover count (66) matches the 66 local branch outcomes exactly. Covering either requires production refactor (removing the defensive null guards) or reflection-based testing, both forbidden (src/ is read-only, AOT rules ban reflection). IsFileExtensionAllowed filters, path validity, and all ValidateOptions/ValidateSelectedPaths combinations are already covered by existing tests.
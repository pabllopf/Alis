---
status: Active
created: 2026-07-10T12:35:00Z
worker: local-agent
---

## COVERAGE TASK

### File
1_Presentation/Extension/Io/FileDialog/src/FilePickerPathConverter.cs

### Coverage
79.7%

### Uncovered Lines
24

### Uncovered Conditions
0

### Method
Multiple (NormalizePath, SplitMultiplePaths, ConvertPathSeparators, GetDirectoryName, GetFileName, IsValidPath)

### Existing Tests
FilePickerPathConverterTest.cs (~30 tests)

### Strategy
- Add tests for exception catch blocks in all methods
- Test with paths containing invalid characters (null char) to trigger ArgumentException
- Add tests for edge cases not yet covered

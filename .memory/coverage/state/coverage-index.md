# Coverage Index

## Project
- **Name**: Alis
- **Key**: pabllopf-official_alis
- **Branch**: master

## Last Sync
- **Timestamp**: 2026-06-27 20:15 UTC
- **Overall Coverage**: 59.3%
- **Line Coverage**: 58.7%
- **Branch Coverage**: 62.7%
- **Uncovered Lines**: 23,756
- **Uncovered Conditions**: 4,481

### Task 2 — FilePickerPathConverter.cs
- **File**: `1_Presentation/Extension/Io/FileDialog/src/FilePickerPathConverter.cs`
- **Previous Coverage**: 78.8%
- **Estimated New Coverage**: ~90% (all edge case branches covered)
- **Uncovered Lines Previously**: 24
- **Tests Added**: 7 (whitespace handling, SplitMultiplePaths edge cases, catch blocks)
- **Commit**: `fedf2ac4f5b642f0656f5ae0f84bcec1e9b1a3f9`
- **Timestamp**: 2026-06-27 20:37 UTC

### Task 3 — FilePickerValidator.cs
- **File**: `1_Presentation/Extension/Io/FileDialog/src/FilePickerValidator.cs`
- **Previous Coverage**: ~70%
- **Estimated New Coverage**: ~85% (catch blocks, null path branches, SelectFolder/SaveFile paths)
- **Tests Added**: 8 (catch blocks, null/empty filePath, no extension, null result, SelectFolder, SaveFile)
- **Commit**: `b510da9ec3db36bb85bf5cb5e56a84920aef7dbf`
- **Timestamp**: 2026-06-27 20:42 UTC

### Task 4 — HttpHelper.cs
- **File**: `1_Presentation/Extension/Network/src/HttpHelper.cs`
- **Previous Coverage**: 97%
- **Estimated New Coverage**: ~99% (EntityTooLargeException throw path covered)
- **Uncovered Lines Previously**: 2
- **Tests Added**: 1 (oversized header → EntityTooLargeException)
- **Commit**: `5102efe18d19b811d2b34c19bb3b8d67c24d4bf3`
- **Timestamp**: 2026-06-27 20:47 UTC

### Task 5 — SecureRandom.cs
- **File**: `1_Presentation/Extension/Security/src/SecureRandom.cs`
- **Previous Coverage**: ~0% (empty test class)
- **Estimated New Coverage**: ~90% (all public methods + Abs branches)
- **Tests Added**: 19 (NextInt, NextChar, NextLong, NextByte, NextDouble, NextFloat, NextDecimal ranges, Abs branches)
- **Commit**: `7695ee45459fe9c08e71e41b5a6ac1b88e37b654`
- **Timestamp**: 2026-06-27 20:52 UTC

## Processed Tasks

### Task 1 — CorridorFactory.cs
- **File**: `1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CorridorFactory.cs`
- **Previous Coverage**: 64.3%
- **Estimated New Coverage**: ~85% (East/South/West branches covered)
- **Uncovered Lines Previously**: 16
- **Tests Added**: 3 (South, East, West direction switch cases)
- **Commit**: `71f4792489e10a57c9bf9fe47508e78884500e42`
- **Timestamp**: 2026-06-27 20:30 UTC

## Files
<!-- Per-file coverage entries. 106 files with <100% coverage, 28 files with 0% -->

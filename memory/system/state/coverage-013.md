# coverage-013 — BinaryReaderWriter.cs (Complete)

## Summary
Added 2 tests for partial-read loop continuation in `ReadExactly`. The remaining 4 uncovered branches are `BitConverter.IsLittleEndian == false` — strictly untestable on macOS.

## Files Changed
- `1_Presentation/Extension/Network/test/Internal/BinaryReaderWriterCoverageTest.cs` (new) — 2 tests + PartialReadStream helper

## Commit
- `4a3d87ad2` — test: coverage BinaryReaderWriter.cs

## Coverage Delta
- File: `BinaryReaderWriter.cs` — was 96.6% (Line: 100.0%, Branch: 86.7%) with 0 ul / 4 branches. 2 branches covered, 4 BitConverter.IsLittleEndian branches remain uncovered on macOS.

## Next
- Increment skip to 13

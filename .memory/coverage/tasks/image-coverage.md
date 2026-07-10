## COVERAGE TASK

### File
`4_Operation/Graphic/src/Image.cs`

### Coverage
46.9%

### Uncovered Lines
178

### Existing Tests
- `ImageTest.cs` (7 reflection-based tests)
- `ImageTest.Functional.cs` (10 functional tests + BMP helpers)
- `ImageRemainingCoverageTests.cs` (10 functional tests)

### New Tests Added
- `LoadFromStream_When16BitBmp_ThrowsNotSupportedException` — 16 bpp unsupported path
- `LoadFromStream_WhenBitfields32Bit_ReturnsCorrectImage` — compression=3 (BITFIELDS)
- `LoadFromStream_WhenRle8Encoded_ReturnsCorrectImage` — RLE8 basic (absolute mode per row)
- `LoadFromStream_WhenRle8EndOfLine_ReturnsCorrectImage` — RLE8 end-of-line escape
- `LoadFromStream_WhenRle8Delta_ReturnsCorrectImage` — RLE8 delta escape
- `LoadFromStream_WhenRle8AbsoluteMode_ReturnsCorrectImage` — RLE8 absolute mode
- `LoadFromStream_WhenRle4Encoded_ReturnsCorrectImage` — RLE4 encoded
- `LoadFromStream_WhenRle4EndOfLine_ReturnsCorrectImage` — RLE4 end-of-line
- `LoadFromStream_WhenRle4Delta_ReturnsCorrectImage` — RLE4 delta
- `LoadFromStream_WhenRle4AbsoluteMode_ReturnsCorrectImage` — RLE4 absolute mode
- `LoadFromStream_WhenRle8OddAbsoluteCount_SkipsPadding` — RLE8 absolute odd padding
- `LoadFromStream_When24BitWidthNotAligned_LoadsCorrectly` — 24-bit non-aligned width

### Status
Completed - 12 NEW TESTS ADDED (all passing)

### File
`ImageCoverageTest.cs`

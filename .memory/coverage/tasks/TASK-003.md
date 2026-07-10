## COVERAGE TASK

### File
1_Presentation/Extension/Media/FFmpeg/src/BaseClasses/MediaReader.cs

### Coverage
79.3%

### Uncovered Lines
4

### Methods Targeted
- CopyToAsync - throw when reader not opened
- CopyToAsync - throw when writer not opened

### Existing Tests
- MediaReaderTest.cs

### Changes
1. Added MediaReader_CopyToAsync_ShouldThrowWhenReaderNotOpened
2. Added MediaReader_CopyToAsync_ShouldThrowWhenWriterNotOpened

### Status
COMPLETED

### Commit
800a64c4e

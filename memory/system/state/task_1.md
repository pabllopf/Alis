## STATE TRACKING

- **commit hash**: (pending — will be set after commit)
- **timestamp**: 2026-07-09T00:00:00Z
- **file**: 1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs
- **methods covered**: Constructor validation (width, height, framerate, audio channels, sample rate, bit depth, null filename, null stream), property accessors (all read-only properties), OpenWrite safety guard (OpenedForWriting check), CloseWrite safety guard, WriteFrame safety guards (audio + video, both constructors), Dispose safety (never opened, stream-based, multiple calls)
- **estimated coverage improvement**: ~15-20% (20+ previously uncovered lines across validation branches and error paths)
- **test file generated**: AudioVideoWriterValidationTests.cs → ./1_Presentation/Extension/Media/FFmpeg/test/Video/AudioVideoWriterValidationTests.cs

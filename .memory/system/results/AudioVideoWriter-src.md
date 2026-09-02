# Result: AudioVideoWriter.cs

File: `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 23.5% (84/358 instrumented lines, local coverlet, AudioVideoWriterConstructorCoverageTests run)
TestsAdded: 15 (AudioVideoWriterConstructorCoverageTests.cs, plain [Fact])
Commit: test: coverage AudioVideoWriter.cs
Status: PARTIAL_BLOCKED_BY_NATIVE

## Summary

AudioVideoWriter.cs is an FFmpeg process-integration class (spawns an `ffmpeg` process, streams
video/audio frames). Both public constructors (filename and stream overloads) perform a PURE MANAGED
argument-validation preamble (if/throw) followed by field assignment before any FFmpeg/process/stream
work is started. That validation and assignment block is deterministic and coverable without FFmpeg.

Added `AudioVideoWriterConstructorCoverageTests.cs` (15 plain [Fact]):
- File ctor: zero video width, zero video height, zero framerate, empty filename, null filename
  ((string)null to disambiguate overload), zero channels, zero sample rate, unsupported bit depth ->
  expected exception types; valid-construction round-trips Filename/UseFilename/dimensions.
- Stream ctor: zero video width, zero framerate, zero channels, unsupported bit depth,
  null output stream ((Stream)null), valid-construction round-trips UseFilename=false and dims.

The `Dispose` path on a never-opened writer only disposes a nullable DestinationStream and null csc,
so using-blocks are safe and deterministic.

## Remaining uncovered (BLOCKED_BY_NATIVE)

`OpenWrite(bool, int)`, `CloseWrite()`, `WriteFrame(AudioFrame)`, `WriteFrame(VideoFrame)`,
`CurrentFFmpegProcess`, and the rest of the class spawn/live FFmpeg over sockets/streams and require a
real FFmpeg binary plus encoded frame data — not deterministically coverable without FFmpeg.

## Verification

- AudioVideoWriterConstructorCoverageTests-filtered run: 15 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: AudioVideoWriter.cs 23.5% (84/358 instrumented lines).
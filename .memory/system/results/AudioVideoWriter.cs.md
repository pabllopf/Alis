# Result: AudioVideoWriter.cs

- File: 1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs
- CoverageBefore: 49.0%
- TestFile: 1_Presentation/Extension/Media/FFmpeg/test/Video/AudioVideoWriterCoverageGapTests.cs
- TestsAdded: 5 (5 passed, 0 failed; RequireFfmpegFact-gated)
- BuildResult: pass
- TestResult: pass (filtered run: 5/5)
- CoveredAreas: CloseWrite kill path for running ffmpeg (file + stream mode), WriteFrame(AudioFrame) happy path, WriteFrame 24/32-bit audio, OpenWrite File.Delete of pre-existing output, showFFmpegOutput + threadQueueSize/32-bit argument building, Dispose while open with live process
- Status: SUCCESS

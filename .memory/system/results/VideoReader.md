# Result: VideoReader.cs

File: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoReader.cs`
CoverageBefore: 38.4% (SonarCloud stale; local coverlet 162/200 = 81.0%)
CoverageAfter: 81.0% (162/200 lines, local coverlet; unchanged)
TestsAdded: 0 (video-stream metadata block unreachable; production deserializer defect)
Commit: test: coverage VideoReader.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

VideoReader.cs is the ffprobe metadata reader (35 complexity / 135 LOC per SonarCloud). The
committed suite (`VideoReaderTest.cs` / `VideoReaderTests.cs` / `VideoReaderCoverageTest.cs` /
`VideoReaderLoadCoverageTests.cs` / `VideoReaderMetadataStreamTests.cs` with real ffprobe/ffmpeg
`[RequireFfmpegFact]` gating) covers the `VideoReader` class 124/124 (100%) and the async
`LoadMetadataAsync` state machine 36/74; targeted run: 38 passed / 0 failed on
`Alis.Extension.Media.FFmpeg.Test` (net8.0). Overall 162/200 instrumented lines (81.0%).

Covered: construction, Dispose, the already-loaded guard, ReadToEndAsync + deserialization,
the outer InvalidOperationException fallback, LoadedMetadata/Metadata assignment, and the
ignoreStreamErrors inner-catch path.

## Remaining uncovered lines (19) — BLOCKED_BY_PRODUCTION_CODE

- 144-169 — the `if (videoStream != null)` block of `LoadMetadataAsync` (Width/Height/PixelFormat/
  Codec/BitRate/BitDepth/Duration/SampleAspectRatio/AvgFramerate/PredictedFrameCount mapping and
  the inner catch).

A standalone probe with a real libx264 video (ffprobe reports `codec_type: video` and a full
stream object) shows the deserialized `VideoMetadata.Streams` is always **empty**: the committed
`JsonNativeAot.Deserialize` (AOT source generator) does not populate the `MediaStream[] Streams`
property from ffprobe's JSON, so `metadata.Streams.FirstOrDefault(...)` never yields a video
stream and the mapping block is unreachable. The committed `VideoReaderMetadataStreamTests`
pass only because `PredictedFrameCount >= 0` holds for the default zero value. Requires a fix in
the serialization generator output (production code); out of scope for coverage work.

## Verification

- Targeted run: 38 passed / 0 failed (net8.0).
- Local coverlet: VideoReader.cs 162/200 lines (81.0%).
- Probe: `Streams=0` after LoadMetadata on a real video file.

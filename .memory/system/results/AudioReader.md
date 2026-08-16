# Result: AudioReader.cs

File: `1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs`
CoverageBefore: 65.9% (SonarCloud; Line: 63.0%, Branch: 72.9%, 44 uncovered lines)
CoverageAfter: 84.9% (202/238, local coverlet; class 164/164, lambda 2/2, LoadMetadataAsync state machine 36/72)
TestsAdded: 0 (existing committed suite already covers every reachable line)
Commit: test: coverage AudioReader.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

AudioReader.cs is the ffprobe-backed audio metadata reader (40 complexity / 154 LOC). The
committed suite (`AudioReaderTest.cs`, `AudioReaderTests.cs`, `AudioReaderCoverageTest.cs`,
`AudioReaderValidationTests.cs`, `AudioReaderAsyncCoverageTests.cs`,
`AudioReaderFrameCoverageTests.cs`, `AudioReaderAdditionalCoverageTest.cs`,
`AudioReaderRemainingCoverageTests.cs` — real ffmpeg/ffprobe `[RequireFfmpegFact]` gating)
covers the whole `AudioReader` class: 164/164 lines (100%) including ctor/FileNotFound,
Dispose, ResolveBitDepth (all branches), Load (validation + already-open + metadata-first
guards), NextFrame (empty/partial/full/closed), CopyTo, and the LoadMetadataAsync outer paths
(success, already-loaded guard, outer InvalidOperationException fallback, Metadata assignment).
Local coverlet on the full FFmpeg suite (1556 passed / 0 failed): AudioReader.cs 202/238 = 84.9%.

## Remaining uncovered lines (18) — BLOCKED_BY_PRODUCTION_CODE

- 181-205 — the `if (audioStream != null)` mapping block of `LoadMetadataAsync` (Channels,
  Codec, SampleFormat, SampleRate, Duration, BitRate, BitDepth, PredictedSampleCount,
  `ResolveBitDepth` call) plus the inner catch and the `ignoreStreamErrors` rethrow path.

A scratch probe with a real WAV (`ffmpeg -f lavfi -i anullsrc=...` + `ffprobe -print_format
json=c=1 -show_format -show_streams`) proves `JsonNativeAot.Deserialize<AudioMetadata>` returns
`Streams.Count == 0` even though the raw JSON contains a populated `"streams"` array with
`codec_type: audio`. `metadata.Streams.FirstOrDefault(...)` is therefore always null and the
whole mapping block is unreachable. Identical defect to the already-documented VideoReader.cs
case (`.memory/system/results/VideoReader.md`): the AOT serialization generator does not
populate the `MediaStream[]` property. Requires a fix in the source generator (production
code); out of scope for coverage work.

## Verification

- Full FFmpeg suite: 1556 passed / 0 failed (net8.0, local ffmpeg/ffprobe present).
- Local coverlet: AudioReader.cs 202/238 lines (84.9%); class members 100%.

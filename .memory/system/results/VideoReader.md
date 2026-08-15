# VideoReader.cs

- **File**: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoReader.cs`
- **Coverage Before**: 38.4% (SonarCloud); 81.0% local baseline
- **Coverage After**: 81.0% (81/100 lines, local coverlet)
- **Tests Added**: 2 (VideoReaderMetadataStreamTests.cs — real ffprobe + real ffmpeg-generated video)
- **Uncovered Lines**: 144-169 — the video-stream parsing block is unreachable: the source-generated `DeserializeArray<T>` only handles primitive element types, so `MediaStream[]` always deserializes to empty; production generator limitation
- **Status**: BLOCKED_BY_PRODUCTION_CODE

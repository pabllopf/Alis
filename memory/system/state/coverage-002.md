# coverage-002 — AudioVideoWriter.cs

## State
Completed

## Commit
02b7c0b4b

## Timestamp
2026-07-09T16:00:00-03:00

## File
`1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
`1_Presentation/Extension/Media/FFmpeg/test/Video/AudioVideoWriterTest.cs`

## Methods Covered
- `WriteFrame(VideoFrame)` — covered via reflection setup (`OpenedForWriting=true`, `InputDataStreamVideo=MemoryStream`)
- Confirmed frame data is written to the input data stream

## Estimated Improvement
~1.5% (single uncovered method in the file)

## Notes
- Removed unmatched `#endregion` that caused CS1028 compilation error
- Fixed dispose cleanup by resetting `OpenedForWriting` before `Dispose()` to avoid NRE in `CloseWrite` (ffmpegp is null in tests)
- Audio `WriteFrame` happy path not testable via reflection alone because `InputDataStreamAudio` requires a real `NetworkStream`

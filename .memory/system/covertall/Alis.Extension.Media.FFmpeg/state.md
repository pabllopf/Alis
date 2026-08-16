# Project Coverage State

Project:
./1_Presentation/Extension/Media/FFmpeg/src/Alis.Extension.Media.FFmpeg.csproj

Test project:
./1_Presentation/Extension/Media/FFmpeg/test/Alis.Extension.Media.FFmpeg.Test.csproj

Status:
COMPLETED

Agent:
covertall-agent-001

Started:
2026-08-16T22:55:00Z

Last update:
2026-08-16T23:10:00Z

Initial coverage:
97.14% (2916/3002 lines in FFmpeg/src)

Current coverage:
97.14%

Tests before:
~400

Tests after:
unchanged

Files modified:
- none

Coverage work:
- Baseline measured: 97.14%. Gaps: VideoReader.cs (48.6% - one entry),
  AudioReader.cs (50%), VideoWriter.cs (97.3%), AudioWriter.cs (97.3%).
- The VideoReader/AudioReader gaps (lines 144-169 / 181-205) are the
  "video/audio stream metadata parsed" branches inside LoadMetadataAsync.
- Root cause verified with a standalone probe: JsonNativeAot.Deserialize
  always returns Streams=[] for real ffprobe output. The Data source
  generator's DeserializeArray<T> only supports primitives (string, int,
  double, bool, float, long, decimal, enums) - for complex types like
  MediaStream it silently returns an empty array. Additionally the parser
  flattens arrays into dotted keys, so "streams" never resolves.
- The existing tests pass trivially (PredictedFrameCount >= 0 / Duration
  >= 0 hold for default values even when no stream is parsed).
- Conclusion: the stream-parsing branches are unreachable in production
  through the public API. Fixing them requires changing the Data JSON
  source generator (shared infrastructure) - out of scope.

Remaining opportunities:
- VideoReader/AudioReader stream branches: blocked by the Data JSON source
  generator's inability to deserialize arrays of complex types (shared
  infrastructure, requires production change).

Last commit:
none

Attempts:
1
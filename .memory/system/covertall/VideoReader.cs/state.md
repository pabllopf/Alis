# Coverage State

Target:
./1_Presentation/Extension/Media/FFmpeg/src/Video/VideoReader.cs

Project:
./1_Presentation/Extension/Media/FFmpeg/src/Alis.Extension.Media.FFmpeg.csproj

Test project:
./1_Presentation/Extension/Media/FFmpeg/test/Alis.Extension.Media.FFmpeg.Test.csproj

Agent:
covertall-agent-videoreader

Baseline commit:
ec50af9690dd8708a170fa9d322cd49050fa50d0

Initial line coverage:
81.00% (81/100)

Initial branch coverage:
71.05% (27/38)

Current line coverage:
81.00% (81/100)

Current branch coverage:
71.05% (27/38)

Tests before:
1561

Tests after:
1561

Files modified:
- .memory/system/covertall/VideoReader.cs/state.md (new)
- .memory/system/covertall/VideoReader.cs/attempts/001.md (new)

Tests added:
- none (all reachable code already covered by existing suite)

Commits:
- none (no coverage tests added)

Remaining uncovered lines:
144, 145, 146, 147, 148, 149, 151, 153, 155, 157, 158, 160, 161, 163, 164, 165, 166, 167, 169
(all inside <LoadMetadataAsync>d__19 async state machine)

Remaining uncovered branches:
line 143 (true path), line 151 (both), line 153 (both), line 155 (four), line 165 (both)

Status:
BLOCKED (async state machine block unreachable; see attempts/001.md)

Last update:
2026-08-17T10:45:00Z

## Blocker summary

The uncovered code (lines 144-169 and 11 branches) only executes when
`videoStream != null`, which requires `metadata.Streams` to contain a video stream.
`metadata.Streams` is populated exclusively by the source-generated
`JsonNativeAot.Deserialize<VideoMetadata>` whose generated `DeserializeArray<T>` handles
only primitive types and silently drops complex `MediaStream` array elements
(6_Ideation/Data/generator/HelperMethodsGenerator.cs). Verified empirically with real
ffprobe output, minimal JSON, and a full-fidelity fake-ffprobe probe test (all yield
empty Streams; Width stays 0). Reaching 100% would require either modifying the
repository-wide source generator (shared infra, repo-wide behavioral impact - forbidden
by rules 27/32 and AGENTS.md) or reflecting into the compiler-generated async state
machine (forbidden by rules 9/21 and AOT constraints).

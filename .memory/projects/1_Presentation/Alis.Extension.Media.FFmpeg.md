# Alis.Extension.Media.FFmpeg

tags:
  - presentation,application,extension,documentation

## Overview
FFmpeg multimedia processing wrapper for ALIS. Provides audio/video encoding, decoding, playback, and stream manipulation via FFmpeg CLI integration.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~15 C# files across multiple directories

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Media Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides multimedia processing capabilities for ALIS applications. Wraps FFmpeg command-line tool for audio/video encoding, decoding, transcoding, playback, and stream manipulation.

## Key Components

### FFMpegWrapper
Main static wrapper class:
- Command execution with argument building
- Encoder/decoder querying via regex parsing
- FFmpeg verbosity and banner control
- Synchronous execution with output capture
- Format and codec discovery

### Audio
- **AudioFrame** — Audio sample frame
- **AudioPlayer** — Audio playback
- **AudioReader** — Audio file reading
- **AudioWriter** — Audio file writing
- **Models** — Audio-specific data models

### Video
- **VideoFrame** — Video frame data
- **VideoPlayer** — Video playback
- **VideoReader** — Video file reading
- **VideoWriter** — Video file writing
- **AudioVideoWriter** — Combined A/V writing
- **Models** — Video-specific data models

### Encoding
- **EncoderOptions** — Encoding configuration
- **IEncoderOptionsBuilder** — Builder interface
- **Builders** — Encoder option builders

### Support Types
- **MediaType** — Media type enumeration
- **Verbosity** — FFmpeg log level
- **MuxingSupport** — Format muxing support

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- **FFmpeg** — External native library (must be installed on system)

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Architecture Notes
1. CLI-based FFmpeg integration (process execution)
2. Regex-based FFmpeg output parsing
3. Builder pattern for encoding options
4. Separation of audio/video/encoding concerns
5. Static wrapper for simple API surface

## Platform Requirements
- FFmpeg binary must be installed and available in PATH
- Cross-platform (Windows, macOS, Linux)

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Media.FFmpeg.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Core.Audio]] (4_Operation) — Audio subsystem
- [[Alis.Core.Aspect.Logging]] — Logging infrastructure

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09

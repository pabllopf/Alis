# Extension: Media.FFmpeg

tags:
  - extension,plugin,add-on

## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Media.FFmpeg` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, FFmpeg.AutoGen bindings |

## Purpose

The FFmpeg extension provides media processing capabilities including video/audio encoding, decoding, transcoding, and streaming. It wraps FFmpeg libraries for use in .NET applications.

## Architecture

```
┌─────────────────────────────────────────┐
│           Application Layer             │
├─────────────────────────────────────────┤
│        Alis.Extension.Media.FFmpeg      │
├─────────────────────────────────────────┤
│           FFMpegWrapper                 │
├─────────────────────────────────────────┤
│         FFmpeg.AutoGen (P/Invoke)       │
├─────────────────────────────────────────┤
│         Native FFmpeg Libraries         │
│   (avcodec, avformat, swscale, etc.)    │
└─────────────────────────────────────────┘
```

## Core Components

### FFMpegWrapper

```csharp
public class FFMpegWrapper : IDisposable
```

Main wrapper for FFmpeg operations.

**Responsibilities:**
- Initialize FFmpeg libraries
- Manage codec contexts
- Handle media file I/O
- Perform encoding/decoding operations

**Key Methods:**
- `Initialize(string ffmpegPath)` — Load FFmpeg native libraries
- `OpenInput(string filePath)` — Open media file for reading
- `OpenOutput(string filePath, MediaConfig config)` — Open output file for writing
- `ReadPacket()` — Read compressed packet from input
- `WritePacket(AVPacket packet)` — Write packet to output
- `DecodeFrame(AVPacket packet)` — Decode packet to frame
- `EncodeFrame(AVFrame frame)` — Encode frame to packet

### MediaConfig

```csharp
public class MediaConfig
{
    public string Format { get; init; } // "mp4", "avi", "mkv"
    public string VideoCodec { get; init; } // "h264", "h265", "vp9"
    public string AudioCodec { get; init; } // "aac", "mp3", "opus"
    public int Width { get; init; }
    public int Height { get; init; }
    public int FrameRate { get; init; }
    public int AudioSampleRate { get; init; }
    public int AudioChannels { get; init; }
    public int Bitrate { get; init; }
}
```

### MediaFrame

```csharp
public class MediaFrame : IDisposable
{
    public AVFrame Frame { get; }
    public MediaType Type { get; } // Video, Audio, Subtitle
    public long Timestamp { get; }
    public int StreamIndex { get; }
}
```

### MediaPacket

```csharp
public class MediaPacket : IDisposable
{
    public AVPacket Packet { get; }
    public int StreamIndex { get; }
    public long Dts { get; }
    public long Pts { get; }
    public int Size { get; }
}
```

## Supported Formats

### Container Formats

| Format | Read | Write | Notes |
|--------|------|-------|-------|
| MP4 | ✅ | ✅ | Most common |
| AVI | ✅ | ✅ | Legacy support |
| MKV | ✅ | ✅ | Matroska |
| MOV | ✅ | ✅ | QuickTime |
| WebM | ✅ | ✅ | VP8/VP9 |
| FLV | ✅ | ✅ | Flash Video |

### Video Codecs

| Codec | Read | Write | Notes |
|-------|------|-------|-------|
| H.264 | ✅ | ✅ | Most compatible |
| H.265/HEVC | ✅ | ✅ | Better compression |
| VP8 | ✅ | ✅ | WebM format |
| VP9 | ✅ | ✅ | YouTube |
| AV1 | ⚠️ | ⚠️ | Experimental |

### Audio Codecs

| Codec | Read | Write | Notes |
|-------|------|-------|-------|
| AAC | ✅ | ✅ | Most common |
| MP3 | ✅ | ✅ | Legacy |
| Opus | ✅ | ✅ | Low latency |
| FLAC | ✅ | ✅ | Lossless |
| Vorbis | ✅ | ✅ | Open source |

## Usage Examples

### Transcode Video

```csharp
var ffmpeg = new FFMpegWrapper();
ffmpeg.Initialize("/usr/local/bin/ffmpeg");

using var input = ffmpeg.OpenInput("input.mkv");
using var output = ffmpeg.OpenOutput("output.mp4", new MediaConfig
{
    Format = "mp4",
    VideoCodec = "h264",
    AudioCodec = "aac",
    Bitrate = 5000000
});

while (true)
{
    var packet = ffmpeg.ReadPacket();
    if (packet == null) break;
    
    var frame = ffmpeg.DecodeFrame(packet);
    if (frame != null)
    {
        var encodedPacket = ffmpeg.EncodeFrame(frame);
        if (encodedPacket != null)
        {
            ffmpeg.WritePacket(encodedPacket);
        }
    }
}
```

### Extract Audio

```csharp
// Extract audio track from video
ffmpeg.ExtractAudio("video.mp4", "audio.aac");
```

### Generate Thumbnail

```csharp
// Extract frame at 10 seconds
ffmpeg.ExtractFrame("video.mp4", timestamp: 10.0, "thumbnail.png");
```

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | x64/x86 |
| Linux | ✅ | x64/arm64 |
| macOS | ✅ | x64/arm64 |

## Memory Management

- Native FFmpeg resources are properly freed
- Frame/packet pools reduce allocations
- Automatic cleanup on disposal

## Error Handling

```csharp
try
{
    ffmpeg.Initialize(ffmpegPath);
}
catch (FFmpegNotFoundException ex)
{
    Logger.Error($"FFmpeg not found: {ex.Message}");
    Logger.Info("Please install FFmpeg and add to PATH");
}
catch (CodecNotSupportedException ex)
{
    Logger.Error($"Codec not supported: {ex.Message}");
}
```

## Performance Characteristics

- Hardware acceleration (NVENC, VAAPI, VideoToolbox)
- Multi-threaded encoding/decoding
- Efficient memory usage with frame pools

## Related

- [[extensions/index|Extensions Index]]
- [[system/indexes/services-index|Services Index]]
- [[architecture/repository-overview|Repository Overview]]

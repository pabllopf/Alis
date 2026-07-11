---
title: Alis.Extension.Media.FFmpeg
tags:
  - project
  - media
  - ffmpeg
  - video
  - audio
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Media.FFmpeg

## Overview

FFmpeg media processing extension (Layer 1 - Extension). Provides video and audio encoding/decoding capabilities through FFmpeg bindings.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Media/FFmpeg/src/` |
| **Test Project** | `Alis.Extension.Media.FFmpeg.Test` |
| **Has Samples** | Yes (`Alis.Extension.Media.FFmpeg.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Audio/` - Audio encoding/decoding
- `src/BaseClasses/` - Base FFmpeg wrapper classes
- `src/Encoding/` - Video/Audio encoding
- `src/Video/` - Video processing

## Source Structure

```
src/
  Audio/
  BaseClasses/
  Encoding/
  Video/
```

## Related

- [[Projects Index]]

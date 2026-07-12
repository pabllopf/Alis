---
title: Alis.Core.Audio
tags:
  - operation
  - audio
  - sound
  - platform
status: Draft
license: GPLv3
---

# Alis.Core.Audio

**Layer:** 4_Operation
**Path:** `4_Operation/Audio/src/Alis.Core.Audio.csproj`

## Purpose

Cross-platform audio playback system supporting Windows, macOS, Linux, and Browser targets.

## Architecture

- `IPlayer` — Audio player interface
- `Player` — Main player implementation
- Platform-specific implementations:
  - `WindowsPlayer` — Win32 API-based
  - `MacPlayer` — macOS CoreAudio-based
  - `LinuxPlayer` — Linux ALSA-based
  - `UnixPlayerBase` — Shared POSIX implementation
  - `BrowserPlayer` — WebAssembly/JS interop
  - `OpenAL` — OpenAL abstraction

## Dependencies

- Alis.Core.Aspect (5_Declaration)

## Testing

**Path:** `4_Operation/Audio/test/`

40 test files covering:
- Platform-specific player tests (Windows, macOS, Linux, Browser)
- Edge case and error coverage
- Static method tests
- WAV parsing tests
- Player lifecycle and state tests

## Platform Support

| Platform | Implementation | Test Coverage |
|---|---|---|
| Windows | Win32 API | Extensive |
| macOS | CoreAudio | Moderate |
| Linux | ALSA/POSIX | Extensive |
| Browser | WebAssembly/JS | Extensive |
| Cross-platform | OpenAL fallback | Moderate |

## Related Documents

- [[Alis.Core.Aspect]]
- [[Alis.Core.Graphic]]
- [[testing-overview]]

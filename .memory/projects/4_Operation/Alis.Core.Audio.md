# Alis.Core.Audio

## Overview

The **Alis.Core.Audio** project provides cross-platform audio playback capabilities for the ALIS game engine. It implements a platform-agnostic player pattern that automatically selects the appropriate audio implementation based on the target operating system.

## Purpose

- Abstract audio playback across Windows, macOS, Linux, and Web platforms
- Provide a unified API for playing, pausing, resuming, and stopping audio
- Support looped and non-looped audio playback
- Handle volume control with percentage-based scaling

## Architecture

### Player Pattern

The `Player` class implements the [IPlayer](Interfaces/IPlayer.md) interface and acts as a facade that delegates to platform-specific implementations:

| Platform | Implementation | File |
|----------|---------------|------|
| Windows | `WindowsPlayer` | Players/WindowsPlayer.cs |
| macOS | `MacPlayer` | Players/MacPlayer.cs |
| Linux | `LinuxPlayer` | Players/LinuxPlayer.cs |
| WebAssembly | `BrowserPlayer` (WebPlayer) | Players/BrowserPlayer.cs |
| Unix-based | `UnixPlayerBase` | Players/UnixPlayerBase.cs |

### Platform Detection

The `CheckOs()` method uses conditional compilation to select the appropriate player:

```csharp
#if osxarm64 || osxarm || osxx64 || osx
    return new MacPlayer();
#elif winx64 || winx86 || winarm64 || winarm || win
    return new WindowsPlayer();
#elif linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
    return new LinuxPlayer();
#elif webassembly || browser
    return new WebPlayer();
#endif
```

## Public API

### IPlayer Interface

```csharp
public interface IPlayer
{
    bool Playing { get; }
    bool Paused { get; }
    event EventHandler PlaybackFinished;
    
    Task Play(string fileName);
    Task PlayLoop(string fileName, bool loop);
    Task Pause();
    Task Resume();
    Task Stop();
    Task SetVolume(byte percent);
}
```

### Player Class

Main entry point for audio playback:

- **`Play(string fileName)`** - Play audio file asynchronously
- **`PlayLoop(string fileName, bool loop)`** - Loop audio playback
- **`Pause()`** - Pause current playback
- **`Resume()`** - Resume paused playback
- **`Stop()`** - Stop and clear buffer
- **`SetVolume(byte percent)`** - Set volume 0-100%

## Files

| File | Lines | Description |
|------|-------|-------------|
| Player.cs | 161 | Main player facade |
| BrowserPlayer.cs | - | WebAssembly implementation |
| LinuxPlayer.cs | - | Linux implementation |
| MacPlayer.cs | - | macOS implementation |
| WindowsPlayer.cs | - | Windows implementation |
| UnixPlayerBase.cs | - | Base class for Unix players |
| OpenAL.cs | - | OpenAL wrapper (if used) |

## Dependencies

- **Alis.Core** - Core engine functionality
- Platform-specific APIs:
  - Windows: DirectSound/XAudio2
  - macOS: AVFoundation/AudioUnit
  - Linux: ALSA/PulseAudio
  - Web: Web Audio API

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance and reliability goals.

## Usage Example

```csharp
using Alis.Core.Audio;

var player = new Player();
await player.Play("sounds/background.mp3");
await player.SetVolume(75);

// Loop music
await player.PlayLoop("sounds/theme.mp3", true);

// Control playback
await player.Pause();
await player.Resume();
await player.Stop();
```

## Events

- **`PlaybackFinished`** - Fired when audio playback completes

## Platform Support

| Platform | Status | Implementation |
|----------|--------|---------------|
| Windows | ✅ Full | WindowsPlayer |
| macOS | ✅ Full | MacPlayer |
| Linux | ✅ Full | LinuxPlayer |
| WebAssembly | ✅ Full | BrowserPlayer |

## TODOs

- [ ] Add audio effect support (reverb, echo, etc.)
- [ ] Implement 3D spatial audio
- [ ] Add audio streaming for large files
- [ ] Optimize buffer management for real-time audio

## Related Projects

- [[Alis.Core.Graphic]] - Visual synchronization
- [[Alis.Core.Ecs]] - Audio system integration
- [[Alis.Core.Resource]] - Audio asset loading

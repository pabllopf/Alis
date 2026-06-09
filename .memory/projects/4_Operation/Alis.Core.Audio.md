---
title: Alis.Core.Audio
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: Draft

license: GPLv3

---


## Overview
Audio playback library for ALIS game engine. Provides cross-platform audio playback with platform-specific implementations for Windows, macOS, Linux, and WebAssembly.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: 28 C# files

## Project Details

| Property | Value |
|---|---|
| **Layer** | 4_Operation |
| **Type** | Library (Audio Engine) |
| **Framework** | net8.0 (multi-targeted) |
| **Output Type** | Class Library |
| **Namespace** | Alis.Core.Audio |

## Purpose
Implements a complete audio playback system for game development. Provides cross-platform audio playback, loop support, volume control, and platform-specific implementations using native audio APIs.

## Architecture

### Core Components

#### Player Class
High-level audio playback interface.

**Features:**
- Cross-platform audio playback
- Loop support (play once or loop)
- Volume control (0-100%)
- Pause/Resume/Stop functionality
- Playback finished event
- Platform-specific player selection

**Implementation Details:**
```csharp
public class Player : IPlayer
{
    private readonly IPlayer _internalPlayer;
    
    event EventHandler PlaybackFinished;
    bool Playing { get; }
    bool Paused { get; }
    
    Task Play(string fileName);
    Task PlayLoop(string fileName, bool loop);
    Task Pause();
    Task Resume();
    Task Stop();
    Task SetVolume(byte percent);
}
```

**Platform Detection:**
- Windows: WindowsPlayer (XAudio2 or WaveOut)
- macOS: MacPlayer (AVFoundation)
- Linux: LinuxPlayer (ALSA/PulseAudio)
- WebAssembly: WebPlayer (Web Audio API)

#### IPlayer Interface
Abstract interface for audio players.

**Methods:**
- `Play(string fileName)` - Play audio file
- `PlayLoop(string fileName, bool loop)` - Loop playback
- `Pause()` - Pause current playback
- `Resume()` - Resume paused playback
- `Stop()` - Stop and clear buffer
- `SetVolume(byte percent)` - Set volume (0-100%)

**Properties:**
- `Playing` - Current playback state
- `Paused` - Pause state

### Platform Implementations

#### WindowsPlayer (11KB)
Windows audio implementation.

**Features:**
- XAudio2 or WaveOut API
- Multi-channel audio support
- Buffer management
- Event-driven playback

**Implementation:**
- Uses Windows multimedia API
- Handles WAV file format
- Manages audio buffers
- Provides playback events

#### MacPlayer (2.6KB)
macOS audio implementation.

**Features:**
- AVFoundation framework
- Core Audio integration
- Native macOS audio pipeline
- Efficient memory management

**Implementation:**
- Uses AVAudioPlayer
- Handles macOS audio formats
- Integrates with Cocoa framework
- Provides playback events

#### LinuxPlayer (2.8KB)
Linux audio implementation.

**Features:**
- ALSA or PulseAudio backend
- Low-latency audio playback
- Native Linux audio integration

**Implementation:**
- Uses ALSA library (Advanced Linux Sound Architecture)
- Handles Linux audio devices
- Manages audio streams
- Provides playback events

#### UnixPlayerBase (11KB)
Base class for Unix-like systems.

**Features:**
- Common Unix audio handling
- ALSA integration
- Shared functionality for Linux/macOS

**Implementation:**
- Abstract base class
- Common buffer management
- Shared event handling
- Platform detection

#### BrowserPlayer (14KB)
WebAssembly/Web audio implementation.

**Features:**
- Web Audio API
- HTML5 audio
- Browser audio context
- Cross-browser compatibility

**Implementation:**
- Uses Web Audio API
- Handles browser audio contexts
- Manages audio buffers
- Provides playback events

#### OpenAL (7.6KB)
OpenAL audio library wrapper.

**Features:**
- OpenAL soft library
- 3D audio support
- Audio sources and listeners
- Buffer management

**Implementation:**
- OpenAL function wrapping
- Audio source management
- Listener positioning
- Buffer loading

### Audio Interfaces

#### IPlayer Interface
Core audio playback interface.

**Usage:**
```csharp
var player = new Player();
await player.Play("sound.wav");
await player.SetVolume(50);
await player.Pause();
await player.Resume();
await player.Stop();
```

**Events:**
```csharp
player.PlaybackFinished += (sender, e) => {
    // Handle playback completion
};
```

## Key Components

### Player.cs (7KB)
High-level audio playback interface.

### Platform Files (22 files)
Cross-platform audio implementations:
- **WindowsPlayer.cs** (11KB) - Windows audio
- **MacPlayer.cs** (2.6KB) - macOS audio
- **LinuxPlayer.cs** (2.8KB) - Linux audio
- **UnixPlayerBase.cs** (11KB) - Unix base class
- **BrowserPlayer.cs** (14KB) - Web audio
- **OpenAL.cs** (7.6KB) - OpenAL wrapper

## Dependencies

### Internal
- None (pure .NET with P/Invoke)

### External
- Platform-specific native libraries:
  - Windows: XAudio2, WaveOut
  - macOS: AVFoundation, Core Audio
  - Linux: ALSA, PulseAudio
  - Web: Web Audio API

## Build Configuration

| Property | Value |
|---|---|
| **LangVersion** | 13 |
| **Nullable** | enabled |
| **AllowUnsafeBlocks** | true |
| **Target Frameworks** | 15+ (netstandard2.0–net10.0, net461–net481) |

## Platform Support

| Platform | Status | Implementation |
|---|---|---|
| **Windows** | ✅ Supported | XAudio2/WaveOut |
| **macOS** | ✅ Supported | AVFoundation |
| **Linux** | ✅ Supported | ALSA/PulseAudio |
| **WebAssembly** | ✅ Supported | Web Audio API |

## Audio Formats

**Supported Formats:**
- WAV (uncompressed)
- AIFF (audio interchange file format)
- MP3 (via platform decoders)
- OGG Vorbis (via platform decoders)

**Audio Properties:**
- Sample rate: 44.1kHz, 48kHz, 96kHz
- Bit depth: 16-bit, 24-bit, 32-bit
- Channels: Mono, Stereo, Multi-channel

## Public APIs

### Player Class
```csharp
public class Player : IPlayer
{
    // Events
    event EventHandler PlaybackFinished;
    
    // Properties
    bool Playing { get; }
    bool Paused { get; }
    
    // Playback
    Task Play(string fileName);
    Task PlayLoop(string fileName, bool loop);
    Task Pause();
    Task Resume();
    Task Stop();
    
    // Volume
    Task SetVolume(byte percent); // 0-100%
}
```

### IPlayer Interface
```csharp
public interface IPlayer
{
    bool Playing { get; }
    bool Paused { get; }
    
    Task Play(string fileName);
    Task PlayLoop(string fileName, bool loop);
    Task Pause();
    Task Resume();
    Task Stop();
    Task SetVolume(byte percent);
}
```

## Namespaces

| Namespace | Purpose |
|---|---|
| `Alis.Core.Audio` | Core audio types |
| `Alis.Core.Audio.Interfaces` | Audio interfaces |
| `Alis.Core.Audio.Players` | Platform implementations |

## Audio Pipeline

1. **Initialization**
   - Platform detection
   - Audio device initialization
   - Buffer allocation

2. **Playback**
   - Load audio file
   - Decode audio data
   - Create audio buffer
   - Start playback

3. **Control**
   - Volume adjustment
   - Pause/Resume
   - Stop playback

4. **Completion**
   - Playback finished event
   - Buffer cleanup

## Configuration Usage

**Basic Usage:**
```csharp
var player = new Player();
await player.Play("sounds/music.wav");
await player.SetVolume(75);
```

**Looping:**
```csharp
var player = new Player();
await player.PlayLoop("sounds/background.mp3", loop: true);
```

**Event Handling:**
```csharp
var player = new Player();
player.PlaybackFinished += (sender, e) => {
    Console.WriteLine("Playback finished!");
};
await player.Play("sounds/finish.wav");
```

## EF Core Usage

**None** - Pure audio library, no ORM usage.

## Testing Status

| Test Type | Status |
|---|---|
| **Unit Tests** | Limited - needs expansion |
| **Integration Tests** | Platform-specific tests |
| **Performance Tests** - Audio latency benchmarks |
| **Coverage** | Medium - core paths covered |

## Security-Sensitive Areas

1. **P/Invoke Security**
   - Native function loading
   - Pointer operations
   - Memory marshaling

2. **File Access**
   - Audio file loading
   - Path validation
   - Resource management

3. **Memory Management**
   - Audio buffer allocation
   - Native resource cleanup
   - Event handler management

## Performance-Sensitive Areas

1. **Audio Decoding**
   - Format conversion
   - Sample rate conversion
   - Channel mixing

2. **Buffer Management**
   - Buffer allocation
   - Buffer swapping
   - Latency optimization

3. **Platform Integration**
   - Native audio API calls
   - Event handling
   - Thread synchronization

## Risks

1. **Memory Leaks**
   - Audio buffers not freed
   - Native resources not released
   - Event handlers not removed

2. **Platform Compatibility**
   - Audio format differences
   - Platform-specific bugs
   - Browser limitations

3. **Audio Quality**
   - Sample rate mismatches
   - Channel configuration issues
   - Buffer underruns

4. **Thread Safety**
   - Audio context not thread-safe
   - Requires single-threaded access
   - Platform-specific threading

5. **File Loading**
   - Audio file corruption
   - Missing embedded resources
   - Invalid audio data

## TODOs

- [ ] Expand unit test coverage
- [ ] Add multi-threading support
- [ ] Profile audio latency
- [ ] Add 3D audio support
- [ ] Add audio effects (reverb, delay)
- [ ] Create audio visualization tools
- [ ] Document audio benchmarks

## Complexity Observations

- **High**: Platform abstraction layer
- **High**: Audio format handling
- **Medium**: Buffer management
- **Medium**: Event handling
- **Low**: Basic playback operations

## Related

- [[4_Operation/Alis.Core.Ecs]] - ECS engine
- [[4_Operation/Alis.Core.Graphic]] - Graphics rendering
- [[4_Operation/Alis.Core.Physic]] - Physics simulation
- [[6_Ideation/Alis.Core.Game]] - Game logic

## See Also

- [[projects/4_Operation/Core]] - Core operations
- [[architecture/repository-overview]] - Repository architecture
- [[glossary/audio]] - Audio definition
- [[glossary/playback]] - Playback definition

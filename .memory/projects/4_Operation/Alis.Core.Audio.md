# Audio Project Documentation

## Alis.Core.Audio - Audio System

### Purpose
Cross-platform audio playback system providing unified audio API across Windows, Linux, macOS, and browser platforms. Handles audio file playback, looping, volume control, and playback events.

### Dependencies
- **Alis.Core**: Base abstractions
- **Alis.Core.Aspect.Memory**: Memory aspects for cross-platform detection
- **System.Timers**: Timer-based playback tracking on Windows

### Key Components

#### Core Types
- **Player**: Main audio player class implementing IPlayer interface
- **IPlayer**: Audio playback interface with Play, Pause, Resume, Stop methods
- **Platform-specific Players**: LinuxPlayer, WindowsPlayer, MacPlayer, BrowserPlayer

#### Platform Abstraction
- **UnixPlayerBase**: Base class for Unix-like systems (Linux, macOS)
- **LinuxPlayer**: Uses aplay/mpg123 for audio playback on Linux
- **MacPlayer**: Uses afplay for audio playback on macOS
- **WindowsPlayer**: Uses Windows API with Timer-based playback tracking
- **BrowserPlayer**: Web platform audio implementation

#### Features
- **Async Playback**: Asynchronous Play() and PlayLoop() methods
- **Event Handling**: PlaybackFinished event for completion notifications
- **Volume Control**: SetVolume(byte percent) with validation
- **Cross-platform**: Automatic OS detection and platform-specific implementation
- **File Format Support**: WAV, MP3, and common audio formats

### Data Access
- File path handling (absolute and relative paths)
- Platform-specific audio backend integration
- Process-based audio execution on Unix systems

### Messaging Usage
- PlaybackFinished event for completion handling
- Event-based architecture for audio lifecycle management

### Testing Status
- **Unit Tests**: Partial - needs expansion
- **Integration Tests**: Sample programs demonstrate usage
- **Coverage**: Needs improvement in edge cases and error handling

### Risks
1. **Platform Compatibility**: Heavy reliance on platform-specific tools (aplay, mpg123, afplay)
2. **Resource Management**: WindowsPlayer implements IDisposable but needs careful resource cleanup
3. **Thread Safety**: Async operations may have race conditions in multi-threaded scenarios
4. **File Path Handling**: Cross-platform path separators and encoding issues

### TODOs
- [ ] Expand test coverage to 80%+
- [ ] Add integration tests for all platforms
- [ ] Improve error handling and validation
- [ ] Add support for more audio formats
- [ ] Create comprehensive sample applications

### Complexity Observations
- **Medium**: Platform abstraction layer adds complexity
- **Cross-platform**: Different audio backends per platform
- **Performance**: Generally good, but platform-specific optimizations needed

### Quality Plan
See [[4_Operation/Audio/QualityPlan]] for improvement goals and tracking.

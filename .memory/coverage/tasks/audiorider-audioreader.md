# AudioReader Coverage Task
# File: 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs
# Coverage: 17.9% | Line Coverage: 16.4% | Branch Coverage: 21.7% | Uncovered Lines: 97

## Target Methods
- Constructor (line 69) - validates file exists
- Load(int bitDepth) (line 215) - validates bit depth, state checks
- Dispose pattern (line 99) - standard dispose
- NextFrame overloads (lines 242-274) - requires loaded audio stream

## Testability Assessment
- Constructor: HIGH - can test FileNotFoundException for non-existent files
- Load(bitDepth): MEDIUM - validates bit depth before external calls
- Dispose: LOW - requires DataStream mock or real file
- NextFrame: LOW - requires fully initialized AudioReader with actual audio data

## Approach
1. Test constructor throws for non-existent files
2. Test Load() parameter validation (invalid bit depths)
3. Test Load() state validation (metadata not loaded, already opened)

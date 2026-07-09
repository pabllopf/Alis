# coverage-011 — AudioSource.cs (Complete)

## Summary
Added 6 tests covering the remaining 3 uncovered lines in `AudioSource.cs`:
- **OnUpdate**: empty method body now called explicitly
- **Play with mock**: verifies `player.Play()` is invoked with correct path (non-looping)
- **PlayLoop with mock**: verifies `player.PlayLoop(path, true)` is invoked (looping)
- **FullPath + looping via mock**: verifies FullPathAudioFile takes priority over NameFile
- **Empty name via mock**: verifies empty string passed to Play when no path is set
- **FullPath test with mock**: verifies FullPathAudioFile is used when set

## Files Changed
- `2_Application/Alis/test/Core/Ecs/Components/Audio/AudioSourceCoverageTest.cs` (new, 152 lines) — 6 new xUnit tests

## Commit
- `3fb9404f4` — test: coverage AudioSource.cs

## Coverage Delta
- File: `AudioSource.cs` — was 95.3% (Line: 93.8%, Branch: 100.0%) with 3 ul / 0 branches

## Next
- Increment skip to 11 for next loop iteration

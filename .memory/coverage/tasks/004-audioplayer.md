# Coverage Task #004 — AudioPlayer.cs

### File

`1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs`

### Coverage

79.3% coverage | 19 uncovered lines | 10 uncovered conditions

### Covered Methods (Partial)

- `Play(string extraInputParameters, bool showWindow)` — ✅ PARTIAL: filename not empty guard covered, already opened guard
- `PlayInBackground(string extraInputParameters, bool showWindow, bool runPureBackground)` — ✅ PARTIAL: already opened guard, runPureBackground branch documented
- `OpenWrite(int sampleRate, int channels, int bitDepth)` — ✅ PARTIAL: already opened guard, valid bit depth validation
- `GetStreamForWriting` — ✅ Documented (static method, requires ffplay)

### Existing Tests

| Test File | Test Count | Coverage |
|-----------|-----------|----------|
| `test/Audio/AudioPlayerTest.cs` | 8 tests (original) → 40 tests (+32 new) | Constructor, IDisposable, Dispose, Play (no filename), CloseWrite (not opened), OpenWrite (invalid bit depth), WriteFrame (not opened), plus new guard tests |

### Commit

`5be589d49` — test: coverage AudioPlayer.cs — Play/PlayInBackground/OpenWrite guards

### Status

**PARTIALLY COMPLETE** — Guard conditions covered (already opened, bit depth validation, filename check). 
Remaining: `Play`, `PlayInBackground`, `OpenWrite` actual ffplay spawn (integration test), `GetStreamForWriting` (integration test).

---
Created: 2025-06-25T18:28:00Z
Completed: 2025-06-25T18:30:00Z

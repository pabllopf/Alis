# Coverage Task #005 — Sfml Audios Directory

### Files

`1_Presentation/Extension/Graphic/Sfml/src/Audios/` (9 files, 337 uncovered lines)

| File | Coverage | Uncovered Lines | Status |
|------|----------|-----------------|--------|
| Chunk.cs | 0% | — | pending (requires native SFML) |
| Sound.cs | 0% | — | #005 PARTIAL (property guards) |
| SoundBuffer.cs | 0% | — | pending (requires native SFML) |
| Music.cs | 0% | — | pending (requires native SFML) |
| SoundStream.cs | 0% | — | pending (requires native SFML) |
| SoundRecorder.cs | 0% | — | pending (requires native SFML) |
| SoundBufferRecorder.cs | 0% | — | pending (requires native SFML) |
| Listener.cs | 0% | — | #005 PARTIAL (getter/setter tests) |
| SoundStatus.cs | 0% | — | already covered (enum values) |

### Existing Tests

| Test File | Test Count | Coverage |
|-----------|-----------|----------|
| `test/Audios/SoundTest.cs` | 0 tests (original) → 12 tests (+12 new) | Constructor, IDisposable, Status, property accessors |
| `test/Audios/SoundStatusTest.cs` | 3 tests (original) | Enum values (Stopped, Paused, Playing) |
| `test/Audios/ListenerTest.cs` | 8 tests (new) | GlobalVolume, Position, Direction, UpVector getters/setters |

### Commit

`6bf4b5142` — test: coverage Sfml Audios — Sound properties, Listener getters/setters

### Status

**PARTIALLY COMPLETE** — Sound property accessors and Listener static properties tested.
Remaining: All classes require actual SFML native library for happy path tests.

---
Created: 2025-06-25T18:31:00Z
Completed: 2025-06-25T18:35:00Z

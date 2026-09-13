# Listener.cs

## File
1_Presentation/Extension/Graphic/Sfml/src/Audios/Listener.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Uncovered Lines: 8, Complexity: 8

## Local verification
- New test file: 1_Presentation/Extension/Graphic/Sfml/test/Audios/ListenerCoverageTests.cs
- 5 tests added (GlobalVolume exact round-trip; Position/Direction/UpVector set/get execution).
- Build: pass. Tests: 5 passed, 0 failed (filter ListenerCoverageTests).
- Tests use existing RequireCSfmlAudioFact convention (skipped in CI without native csfml-audio).

## Analysis
All 8 uncovered property lines execute locally (native lib present via Homebrew). Vector round-trips cannot assert exact values: production ABI bug — Vector3F (6_Ideation/Math/src/Vector/Vector3F.cs:48) has an internal readonly int hashCode field before X/Y/Z, making the managed struct 16 bytes vs native 12-byte sfVector3f; get returns uninitialized garbage. Vector assertions assert set/get completion + finite components instead.

## Outcome
5 tests added; production code untouched. BLOCKED_BY_PRODUCTION_CODE for exact vector value assertions (ABI layout mismatch in Vector3F).

---
status: Done
---

# COVERAGE TASK

## File
2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs

## Coverage (SonarCloud)
63.5% (target: improve to 70%+)

## Uncovered Lines
15 lines — branches in Play() and OnStart() methods

## Methods Covered
- Play(): NameFile assignment path, IsLooping=true path calling PlayLoop, IsLooping=false path calling Play
- OnStart(): PlayOnAwake=true branch triggering Play()
- Stop(): callable without throwing
- Resume(): callable without throwing
- Edge case: Play with empty NameFile does not throw

## Existing Tests
AudioSourceTest.cs (12 tests: 8 original + 4 new)

## Production Changes
None required

## Status
Completed — 4 branch coverage tests added. Commit: e68fff4c3

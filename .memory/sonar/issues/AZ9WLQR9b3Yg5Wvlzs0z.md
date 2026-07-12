# Issue: AZ9WLQR9b3Yg5Wvlzs0z

- Rule: csharpsquid:S2292
- Severity: MINOR
- File: 2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs
- Line: 59
- Hash: d062005d6ad6691d79296dcf1c5dd2db
- Status: FIXED
- Commit: 42ac1c20397fb637ac3d797d06a6639f81cb7d67
- Date: 2026-07-12

## Description

Make this an auto-implemented property and remove its backing field.

## Context

`PlayerForTest` property at line 59 used a backing field `player` (line 54). The field was also used directly in Play(), Stop(), Resume(), and IsPlaying. Tests set `PlayerForTest` to inject mock players.

## Fix Applied

1. Made `PlayerForTest` auto-implemented with initializer: `internal IPlayer PlayerForTest { get; set; } = new Player();`
2. Removed the `private IPlayer player` backing field
3. Replaced all `player.` references with `PlayerForTest.` in Play(), Stop(), Resume(), IsPlaying
4. Test files (AudioSourceTest.cs, AudioSourceCoverageTest.cs, AudioSourceRemainingCoverageTests.cs) use `PlayerForTest` setter — no change needed
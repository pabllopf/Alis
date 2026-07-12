# Fix: AZ9WLQR9b3Yg5Wvlzs0z

- Issue: AZ9WLQR9b3Yg5Wvlzs0z
- Rule: S2292
- File: 2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs
- Commit: 42ac1c20397fb637ac3d797d06a6639f81cb7d67
- Date: 2026-07-12
- Status: APPLIED

## Transformation

Converted manual backing-field property to auto-implemented property:
- Removed `private IPlayer player = new Player();` backing field
- Changed `PlayerForTest` from `{ get => player; set => player = value; }` to `{ get; set; } = new Player();`
- Updated 7 internal references from `player.` to `PlayerForTest.`
- Test files continued to work unchanged via the property setter

## Verification

Build: SUCCESS (0 warnings, 0 errors) across all target frameworks.
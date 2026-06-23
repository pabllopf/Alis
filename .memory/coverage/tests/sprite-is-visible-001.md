# Test: Sprite.IsSpriteVisible Coverage

## File
2_Application/Alis/test/Core/Ecs/Components/Render/SpriteIsSpriteVisibleTest.cs

## Methods Tested
- `Sprite.IsSpriteVisible()` — 9 tests covering all branches

## Test Details
1. `SpriteAtCameraCenter_ShouldBeVisible` — zero position, no rotation
2. `SpriteOutsideBoundsX_ShouldNotBeVisible` — far outside on positive X
3. `SpriteOutsideBoundsY_ShouldNotBeVisible` — far outside on positive Y
4. `SpriteAtCameraEdge_ShouldBeVisible` — at culling boundary
5. `SpriteWithMinimalRotation_ShouldUseNoRotationBounds` — rotation < 0.0001f, skips rotation
6. `SpriteWithRotation_ShouldAdjustBounds` — 45° rotation, still visible at center
7. `LargeSpriteFarOutsideX_ShouldNotBeVisible` — outside even without rotation
8. `RotatedSpriteOutsideBounds_ShouldNotBeVisible` — 90° rotation, too far out
9. `SpriteOutsideNegativeX_ShouldNotBeVisible` — far outside on negative X

## Result
All 9 tests pass

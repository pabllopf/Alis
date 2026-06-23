## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs

### Coverage
Current: ~51.8% (overall project)

### Method
`Sprite.IsSpriteVisible(Vector2F, Vector2F, Vector2F, float, Vector2F, Vector2F, float)`

### Existing Tests
- `SpriteTest.cs` (185 lines, 8 tests: constructor, properties, interface implementation)

### Source Code
[See Sprite.cs lines 416-439]

### Approach
Changed visibility from `private static` to `internal static` (minimal visibility adjustment, `InternalsVisibleTo` already configured). Tested all branches:
1. Sprite at camera center (visible, no rotation)
2. Sprite outside bounds X (not visible)
3. Sprite outside bounds Y (not visible)
4. Sprite at camera edge (visible)
5. Sprite with minimal rotation (rotation branch skipped)
6. Sprite with rotation (rotation branch entered)
7. Rotated sprite outside bounds (not visible)
8. Sprite outside negative X (not visible)

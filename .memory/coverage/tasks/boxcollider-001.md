# Coverage Task: BoxCollider.cs

## File
`2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs`

## Coverage
- **Overall**: 24.5%
- **Line Coverage**: 27.7%
- **Branch Coverage**: 6.3%
- **Uncovered Lines**: 201

## Methods Requiring Tests
1. `OnStart(IGameObject self)` - Creates physics body, sets up callbacks
2. `OnExit(IGameObject self)` - Removes body from physics world
3. `Render(GameObject, Vector2F, Vector2F, float)` - Renders collider with shaders
4. `InitializeShaders()` (private) - Creates OpenGL shader program and buffers
5. `RenderBoxCollider(...)` (private) - Renders rectangle with camera transforms
6. `OnCollision(...)` (private) - Invokes IOnCollisionEnter events
7. `OnSeparation(...)` (private) - Invokes IOnCollisionExit events

## Existing Tests
- BoxCollider_DefaultConstructor_ShouldCreateWithDefaultValues ✓
- BoxCollider_Properties_ShouldBeGetAndSettable ✓
- BoxCollider_SettingsConstructor_ShouldCopyAllValues ✓
- BoxColliderSettings_Equality_ShouldWork ✓
- OnUpdate null body branch coverage (partial)

## New Tests Generated
- BoxCollider_OnExit_WhenBodyIsNotNull_ShouldRemoveFromWorld
- BoxCollider_OnExit_WhenBodyIsNull_ShouldReturnEarly
- BoxCollider_OnStart_WhenGameObjectHasTransform_ShouldCreateBody
- BoxCollider_OnStart_WhenGameObjectHasNoTransform_ShouldReturnEarly
- BoxCollider_Render_FirstCall_ShouldInitializeShaders
- BoxCollider_Render_SubsequentCall_ShouldUseCachedShaders
- BoxCollider_OnCollision_WhenCollisionWithTrigger_ShouldInvokeIOnCollisionEnter
- BoxCollider_OnSeparation_WhenSeparationWithTrigger_ShouldInvokeIOnCollisionExit
- BoxCollider_InitializeShaders_ShouldCreateShaderProgram
- BoxCollider_RenderBoxCollider_CalculatesCoordinatesCorrectly
- BoxCollider_AutoTilling_Property_ShouldAllowGetAndSet

## Status
**COMPLETED** - 16/16 tests passed successfully

## Target Framework
- net8.0

## Dependencies
- Moq (for IGameObject, Fixture, Contact mocks)

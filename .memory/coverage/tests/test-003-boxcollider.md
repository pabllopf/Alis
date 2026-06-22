# Test Record #3 — BoxCollider.cs

## Source File

- **Path**: `3_Structuration/Core/src/Alis.Core.Ecs.csproj` (BoxCollider.cs)
- **Class**: `BoxCollider`
- **Namespace**: `Alis.Core.Ecs.Components.Collider`

## Test File

- **Path**: `3_Structuration/Core/test/BoxColliderTest.cs`
- **Class**: `BoxColliderTest`

## Test Cases (21 Tests)

### Default Constructor Tests (14 Tests)

1. **DefaultConstructor_ShouldInitializeWidthTo10** — Validates Width defaults to 10
2. **DefaultConstructor_ShouldInitializeHeightTo10** — Validates Height defaults to 10
3. **DefaultConstructor_ShouldInitializeRotationTo0** — Validates Rotation defaults to 0
4. **DefaultConstructor_ShouldInitializeRelativePositionToZero** — Validates RelativePosition defaults to (0, 0)
5. **DefaultConstructor_ShouldInitializeAutoTillingToFalse** — Validates AutoTilling defaults to false
6. **DefaultConstructor_ShouldInitializeBodyTypeToStatic** — Validates BodyType defaults to Static
7. **DefaultConstructor_ShouldInitializeRestitutionTo05** — Validates Restitution defaults to 0.5f
8. **DefaultConstructor_ShouldInitializeFrictionTo05** — Validates Friction defaults to 0.5f
9. **DefaultConstructor_ShouldInitializeFixedRotationToFalse** — Validates FixedRotation defaults to false
10. **DefaultConstructor_ShouldInitializeMassTo1** — Validates Mass defaults to 1.0f
11. **DefaultConstructor_ShouldInitializeIgnoreGravityToFalse** — Validates IgnoreGravity defaults to false
12. **DefaultConstructor_ShouldInitializeLinearVelocityToZero** — Validates LinearVelocity defaults to (0, 0)
13. **DefaultConstructor_ShouldInitializeAngularVelocityTo0** — Validates AngularVelocity defaults to 0
14. **DefaultConstructor_ShouldInitializeIsTriggerToFalse** — Validates IsTrigger defaults to false

### Property Get/Set Tests (6 Tests)

15. **IsTrigger_Property_ShouldAllowGetAndSet** — Validates IsTrigger property getter/setter
16. **Width_Property_ShouldAllowGetAndSet** — Validates Width property getter/setter
17. **Height_Property_ShouldAllowGetAndSet** — Validates Height property getter/setter
18. **SizeOfTexture_Property_ShouldAllowGetAndSet** — Validates SizeOfTexture property getter/setter
19. **Context_Property_ShouldAllowGetAndSet** — Validates Context property getter/setter
20. **Body_Property_ShouldAllowGetAndSet** — Validates Body property getter/setter

### Constructor With Settings Test (1 Test)

21. **Constructor_WithSettings_ShouldInitializeAllProperties** — Validates settings constructor initializes all 14 properties correctly

### Private Methods (Not Tested - Implementation Details)

- `InitializeShaders()` — OpenGL shader initialization (requires GPU context)
- `RenderBoxCollider(...)` — Box rendering logic (requires full rendering pipeline)
- `OnUpdate(IGameObject)` — Physics update sync (requires Transform component)
- `OnStart(IGameObject)` — Body creation logic (requires full PhysicManager)
- `OnExit(IGameObject)` — Cleanup logic (requires full ECS context)
- `OnCollision(...)` — Collision callback (internal event handler, requires Fixture objects)
- `OnSeparation(...)` — Separation callback (internal event handler, requires Fixture objects)

## Notes

- Tests focus on public constructors and properties only
- All property tests follow Arrange/Act/Assert pattern
- Settings constructor test validates all 14 properties in a single comprehensive test
- Private methods requiring external dependencies (OpenGL, PhysicManager, ECS context) are not tested
- Tests use real objects where possible (Vector2F, BodyType enum) rather than mocks

## Commit Information

- **Commit Hash**: 8fa202ec0
- **Commit Message**: `test: coverage BoxCollider.cs`
- **Date**: 2026-06-22

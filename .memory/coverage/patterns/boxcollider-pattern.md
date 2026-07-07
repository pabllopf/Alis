# Pattern: BoxCollider Testing Limitations

## File

`2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs`

## Current Coverage

- Overall: 28.8%
- Line: 32.0%
- Branch: 10.4%

## Testable Code Paths (Covered)

1. **Constructors** - Both default and settings-based constructors fully tested
2. **Property Getters/Setters** - All public properties tested
3. **OnExit (null body branch)** - Returns early when Body is null
4. **OnExit (non-null body branch)** - Removes body from physics world
5. **OnUpdate (null body branch)** - Returns early when Body is null
6. **OnStart (no Transform)** - Returns early when IGameObject.Has<Transform>() is false

## Untestable Code Paths (Limitations)

### 1. Ref-Returning Get<Transform>() Method

The `IGameObject.Get<T>()` method returns a `ref` value, which Moq cannot mock. This prevents testing:

- `OnUpdate` with Body != null AND Transform exists
- `OnStart` with Transform component present

**Workaround Required**: Integration tests with real GameObject instances, or interface refactoring to expose transform data without ref returns.

### 2. OpenGL Dependencies

The following methods require an OpenGL context and cannot be unit tested:

- `Render()` - Public, requires graphics context
- `InitializeShaders()` - Private, creates OpenGL shaders
- `RenderBoxCollider()` - Private, uploads vertex data to GPU

**Workaround Required**: Mock OpenGL bindings or use headless OpenGL (e.g., Mesa offscreen).

### 3. Private Collision Handlers

- `OnCollision(Fixture, Fixture, Contact)` - Requires real physics fixtures
- `OnSeparation(Fixture, Fixture, Contact)` - Requires real physics fixtures

**Workaround Required**: Internal visibility + test assembly access, or extract interfaces.

## Recommendations

1. **High Priority**: Extract collision handlers to interfaces for testability
2. **Medium Priority**: Add OpenGL mock layer for rendering tests
3. **Low Priority**: Refactor `Get<T>()` to support non-ref returns for testing

## Existing Test Files

- BoxColliderTest.cs (14 tests)
- BoxColliderOnStartCoverageTest.cs (8 tests)
- BoxColliderOnExitCoverageTest.cs (4 tests)
- BoxColliderBuilderTest.cs (10 tests)
- BoxColliderCoverageTest.cs (15 tests)
- BoxColliderFullPathTests.cs (15 tests)
- BoxColliderRuntimeCoverageTest.cs (2 tests)

**Total: 68+ tests, all passing**

## Coverage Gap Analysis

| Method | Coverage | Reason |
|--------|----------|--------|
| Constructors | ~100% | Fully tested |
| Properties | ~100% | Fully tested |
| OnExit | ~90% | Mostly covered |
| OnUpdate (null body) | ~100% | Covered |
| OnUpdate (Body != null) | 0% | Ref-return mock limitation |
| OnStart (no Transform) | ~100% | Covered |
| OnStart (with Transform) | 0% | Ref-return mock limitation |
| Render | 0% | OpenGL dependency |
| InitializeShaders | 0% | OpenGL dependency |
| OnCollision | 0% | Private, Fixture dependency |
| OnSeparation | 0% | Private, Fixture dependency |

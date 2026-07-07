# Coverage Task: BoxCollider.cs

## File

`2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs`

## Coverage

- Overall: 28.8%
- Line: 32.0%
- Branch: 10.4%

## Uncovered Lines

189 lines uncovered (out of 559 total)

## Uncovered Conditions

43 conditions uncovered (out of 48 total)

## Priority Methods (by impact)

1. `OnExit(IGameObject self)` - Public, simpler logic, removes body from physics
2. `OnStart(IGameObject self)` - Public, creates physics body, complex but testable
3. `OnUpdate(IGameObject self)` - Public, updates transform from body (partial coverage exists)
4. `Render(...)` - Public, OpenGL rendering (requires graphics context)
5. `InitializeShaders()` - Private, OpenGL shader initialization
6. `RenderBoxCollider(...)` - Private, renders rectangle vertices
7. `OnCollision(...)` - Private, collision event handling
8. `OnSeparation(...)` - Private, separation event handling

## Existing Tests

- BoxColliderTest.cs (constructors, properties, basic OnUpdate/OnStart/OnExit)
- BoxColliderOnStartCoverageTest.cs (OnStart branches, but all throw due to mock limitations)
- BoxColliderOnExitCoverageTest.cs (OnExit tests)
- BoxColliderBuilderTest.cs (builder pattern)
- BoxColliderCoverageTest.cs (coverage-focused)
- BoxColliderFullPathTests.cs (full path tests)
- BoxColliderRuntimeCoverageTest.cs (runtime coverage)

## Test Strategy

1. **OnExit**: Test body removal when Body is not null
2. **OnStart**: Test early return when Transform doesn't exist (already partially covered)
3. **OnUpdate**: Test null body branch (already covered), test Body != null branch with proper mocking
4. **Render**: Skip for now (requires OpenGL context)
5. **Private methods**: Skip for now (OpenGL dependencies)

## Dependencies

- Alis.Core.Ecs.Components.Collider.BoxCollider
- Alis.Core.Ecs.Components.IGameObject
- Alis.Core.Ecs.Components.Transform
- Alis.Core.Ecs.Systems.Scope.Context
- Alis.Core.Physic.Dynamics.Body
- Alis.Core.Aspect.Math.Vector.Vector2F

## Estimated Coverage Improvement

+5-10% coverage increase for this file

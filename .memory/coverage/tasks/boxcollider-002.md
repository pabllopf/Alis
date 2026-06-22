---
status: Completed
---

# COVERAGE TASK

## File
2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs

## Coverage (SonarCloud)
12.3% (239 uncovered lines)

## Uncovered Lines
OnUpdate method (Has<Transform> + Body not null path), OnStart method (creates body, sets properties), OnExit method (Body != null path), InitializeShaders/Render methods (OpenGL dependent), OnCollision/OnSeparation private methods (ECS fixture-dependent), SizeOfTexture/Context properties

## Method
OnUpdate, OnStart, OnExit, InitializeShaders, Render, OnCollision, OnSeparation, SizeOfTexture getter/setter, Context getter/setter

## Existing Tests
17 existing tests covering constructor defaults, properties, settings constructor, interface implementation

## Tests Added
6 new tests:
- SizeOfTexture_ShouldBeSettable (getter/setter)
- SizeOfTexture_DefaultShouldBeZero (default value)
- Context_ShouldDefaultToNull (default value)
- Body_ShouldBeSettable (getter/setter with full qualified type name)
- BoxColliderSettings_DifferentWidth_ShouldNotBeEqual (record inequality)
- BoxColliderSettings_DifferentHeight_ShouldNotBeEqual (record inequality)
- BoxColliderSettings_DifferentRotation_ShouldNotBeEqual (record inequality)

## Notes
- OnUpdate/OnStart/OnExit with ECS context require IGameObject mock which has ref return limitations with Moq
- InitializeShaders/Render depend on OpenGL (Gl.*) - not unit testable without graphics context
- OnCollision/OnSeparation are private methods requiring full ECS fixture setup
- Body type uses full qualified name Alis.Core.Physic.Dynamics.Body due to namespace conflict with Alis.Core.Ecs.Components.Body

## Status
Committed — 7bd29b432

---
status: Completed
---

# COVERAGE TASK

## File
2_Application/Alis/src/Builder/Core/Ecs/Entity/GameObjectBuilder.cs

## Coverage (SonarCloud)
45.1% (target: improve to 55%+)

## Uncovered Lines
Various WithComponent overloads, Name/Tag/IsActive/IsStatic branches with existing Info

## Methods Covered
- WithComponent<T>() with Animator (struct)
- WithComponent<T>() with BoxCollider (class)
- WithComponent<T>() with Info (record struct)
- WithComponent<T>(T component) with Animator instance
- WithComponent<T>(CameraConfig<T>) with Camera
- WithComponent<T>(SpriteConfig<T>) with Sprite
- WithComponent<T>(AudioSourceConfig<T>) with AudioSource
- WithComponent<T>(BoxColliderConfig<T>) with BoxCollider
- WithComponent<T>(Action<T>) with Info
- Name() after Add(Info) branch
- Tag() after Add(Info) branch
- IsActive() after Add(Info) branch
- IsStatic() after Add(Info) branch

## Existing Tests
GameObjectBuilderTest.cs (23 tests: 10 original + 13 new)

## Pattern Notes
- All config delegate types (CameraConfig<T>, SpriteConfig<T>, etc.) need explicit variable typing to avoid ambiguity with Action<T> overload
- Use Info for Action<T> config tests since Info only implements IOnUpdate
- BoxCollider is a class, others are structs — both work with new() constraint

## Status
Completed — 13 new tests covering WithComponent overloads and Info-path branches. Commit: pending

# Test File: GameObjectBuilderTest

## Location
2_Application/Alis/test/GameObjectBuilderTest.cs

## Framework
xUnit (no Moq needed)

## Test Count
23 tests (10 original + 13 new)

## Test Categories
- **Constructor defaults**: 1 test (creates builder)
- **Build returns instance**: 2 tests (not null, same instance)
- **Name/Tag/Id**: 3 tests (Name, Tag, Id return builder)
- **IsActive/IsStatic**: 4 tests (with bool arg, no args)
- **Transform**: 1 test (with config)
- **WithComponent<T>() no args**: 3 tests (Animator, BoxCollider, Info)
- **WithComponent<T>(T instance)**: 1 test (Animator instance)
- **WithComponent<T>(Config<T>)**: 4 tests (Camera, Sprite, AudioSource, BoxCollider configs)
- **WithComponent<T>(Action<T>)**: 1 test (Info with empty action)
- **Info branch paths**: 4 tests (Name, Tag, IsActive, IsStatic after Add<Info>)

## Pattern Notes
- Config delegate types must be typed explicitly to avoid overload ambiguity
- BoxCollider (class) and Animator/Info (structs) both work with new() constraint

## COVERAGE TASK

### File

4_Operation/Ecs/src/GameObject.cs

### Coverage

74.1%

### Uncovered Lines

~215 lines (SonarCloud)

### Uncovered Conditions

~98

### Methods (new tests planned)

1. `Has(Type)` — non-generic overload
2. `TryHas<T>()` — safe variant
3. `TryHas(Type)` — safe non-generic variant
4. `Set(ComponentId, object)` — boxed set
5. `Set(Type, object)` — typed set
6. `Get(ComponentId)` — boxed get
7. `Get(Type)` — typed get (boxed)
8. `TryGet<T>(out Ref<T>)` — safe generic get
9. `TryGet(Type, out object)` — safe non-generic get
10. Edge cases: Get<T> for missing component, Has<T> on dead entity, Set on dead entity

### Existing Tests

24 tests in `GameObjectPropertiesTest.cs` covering: IsAlive, IsNull, Scene, ComponentTypes, Type
29+ tests in `GameObjectRemoveTest.cs` covering: Remove<T> arities 1-8, Remove(ComponentId), Remove(Type)
5 tests in `GameObjectPerEntityEventsTest.cs` covering: OnDelete, OnComponentAdded, OnComponentRemoved
11 tests across `GameObjectRefTupleTest.cs` and `GameObjectRefTupleTest.5.cs`
8 tests in `GameObjectLocationParametrizedTest.cs`

### Plan

Add ~14 tests to `GameObjectPropertiesTest.cs` covering Has, TryHas, Set, Get, TryGet overloads and exception paths.

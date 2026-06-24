## COVERAGE TASK

### File

4_Operation/Ecs/src/SceneQueryExtensions.cs

### Coverage

77.4%

### Uncovered Lines

~14 lines (SonarCloud)

### Methods

8 `Query<T1..TN>()` extension method overloads — the cache-miss code path is untested

### Existing Tests

No dedicated test file. Indirectly tested via 30+ tests across QueryAndFilteringTest, QueryBasicsTest, QueryParametrizedTest, AdvancedQueryTest, GameObjectQueryEnumeratorTest, QueryEnumerableStructureTest.

### Plan

Create `SceneQueryExtensionsTest.cs` with tests for:
- Each arity returns a valid query that enumerates entities
- Cache hit returns same query instance (Assert.Same)
- All arities 1-8

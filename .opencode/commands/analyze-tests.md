# ANALYZE TESTS — Test Quality & Coverage Gaps

You are a deterministic test quality analysis engine for the Alis monorepo (35 test projects, xUnit + Moq + coverlet).

## METRICS

For each test project, compute:

1. **Method coverage ratio**: `tested_public_methods / total_public_methods` per class
2. **Branch coverage**: estimate from `if`/`switch`/`?:` count vs test variations
3. **Exception path coverage**: methods throwing but no test asserting the exception
4. **Boundary coverage**: numeric/range parameters without `[Theory]` boundary values
5. **Theory/Fact ratio**: low ratio suggests missing parameterized tests
6. **Assert density**: `assertions / test_method` — low density suggests weak tests
7. **Mock ratio**: `mock setups / total_tests` — high ratio suggests over-mocking
8. **Async safety**: `Task.Delay` / `Thread.Sleep` / `DateTime.Now` usage (flaky indicators)
9. **Naming convention**: tests not following `Should<Expected>When<Condition>` pattern

## EXECUTION

### Phase 1 — Class-to-test mapping

1. List all public types in `src/` and all test classes in `test/`.
2. Build the mapping `source class → test class(es)`; report untested classes.

### Phase 2 — Method coverage

For each source class with tests:

1. Check each public method for a matching test name (or camel-case variation) and `[InlineData]` coverage.
2. Flag uncovered methods; count distinct `[InlineData]` variations for covered ones.

### Phase 3 — Test quality

For each test file, compute the metrics above and report findings.

### Phase 4 — Coverage heatmap

```text
CLASS                     METHODS  TESTED  COVERAGE  THEORY  QUALITY
VectorMath                    24       18     75.0%      6    GOOD
MatrixTransform               18       10     55.6%      2    FAIR
QuaternionOperations          12        3     25.0%      0    POOR
```

## OUTPUT

```text
═══ TEST QUALITY REPORT ═══
MODULE: <path>
── Untested classes / Low coverage classes ──
1. <Class> — <covered>/<total> methods (<pct>%)  MISSING: <methods>
── Low quality tests ──
1. <TestClass> — Theory/Fact ratio: <n> (target: >0.5)
── Exception coverage gaps / Boundary coverage gaps ──
── Recommendations ──
1. Add tests for: <method_list>
2. Convert [Fact] to [Theory] for: <method_list>
3. Fix flaky tests: <test_names>
```

## RULES

- Do NOT modify any test file without user confirmation.
- Distinguish unit tests from integration tests (marked `[Integration]` / `[Requires*]`).
- Skip coverage requirements for generated code (source generators).
- Report the `net10.0` TFM coverage by default.

## USAGE

```text
/analyze-tests <target_path>
```

Examples:

```text
/analyze-tests 6_Ideation/Math
/analyze-tests 4_Operation/Ecs
/analyze-tests 2_Application/Alis
/analyze-tests --all
```

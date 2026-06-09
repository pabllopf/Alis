# Testing Analysis — ALIS

## Testing Framework
- **Framework**: xUnit 2.6.6
- **Mocking**: Moq 4.20.70
- **Coverage**: coverlet.collector 6.0.4
- **STA Tests**: Xunit.StaFact 1.1.11

## Test Project Convention
- **Naming**: `{ProjectName}.Test`
- **Location**: Adjacent to source project (e.g., `Alis.Core.Ecs/test/`)
- **SonarQube**: Excluded (`SonarQubeExclude=true`)

## Test Patterns

### Project Reference Pattern
```xml
<ItemGroup>
  <ProjectReference Include="..\Alis.Core.Ecs\src\Alis.Core.Ecs.csproj" />
</ItemGroup>
```

### InternalsVisibleTo Pattern
Directory.Build.props automatically exposes internals to test projects:
```xml
<InternalsVisibleTo Condition="$(AssemblyName.EndsWith('Core'))" />
<InternalsVisibleTo Condition="$(AssemblyName.EndsWith('Extension'))" />
```

## Test Coverage by Layer

| Layer | Test Projects | Coverage Notes |
|-------|--------------|----------------|
| 1_Presentation | ~20 | Extension tests, app integration tests |
| 2_Application | ~14 | Game sample tests (minimal — samples are educational) |
| 3_Structuration | ~5 | Aggregator tests (minimal — structural only) |
| 4_Operation | ~16 | Core engine tests (ECS, Graphic, Audio, Physic) |
| 5_Declaration | ~1 | Aspect aggregator tests (minimal) |
| 6_Ideation | ~24 | Generator output tests (critical — generators must be tested) |

## Testing Strategy

### Unit Tests
- Test individual components in isolation
- Use Moq for dependency mocking
- Test generator output correctness

### Integration Tests
- Test layer interactions
- Test extension integration
- Test game sample functionality

### Generator Tests
- Critical for Ideation layer
- Verify generated code compiles
- Verify generated code behavior
- Test edge cases in generator logic

## Common Test Anti-Patterns to Avoid
- ❌ Testing generated code directly (test the generator instead)
- ❌ Testing aggregator projects (they have no logic)
- ❌ Cross-layer integration tests that depend on specific implementations
- ❌ Missing tests for source generator edge cases

## Related

- [[testing-overview]] — High-level test coverage
- [[tests-index]] — All test projects indexed
- [[code-review-checklist]] — Test review checklist
- [[projects/Testing-Strategy]] — Testing strategy docs
- [[Alis.Sample]] — Sample game testing
- [[onboarding/getting-started]] — Running tests
- [[build-system]] — Test commands
- [[analysis-state]] — Test analysis progress
- [[indexes-summary]] — All indexes overview

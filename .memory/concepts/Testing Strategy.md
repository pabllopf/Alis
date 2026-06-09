# Testing Strategy

Alis uses xUnit testing framework with specialized plugins for cross-platform and UI testing.

## Testing Framework

| Package | Purpose |
|---------|---------|
| **xUnit** | Primary testing framework |
| **Xunit.StaFact** | Single-threaded tests for UI/platform-specific code |
| **Moq** | Mocking library for dependency injection testing |

## Test Organization

Tests are organized by layer to match source structure:

```
1_Presentation/*/tests/  ← Presentation layer tests
2_Application/*/tests/   ← Application layer tests
3_Structuration/*/tests/ ← Core library tests
4_Operation/*/tests/     ← Operation layer tests
5_Declaration/*/tests/   ← Declaration layer tests
6_Ideation/*/tests/      ← Ideation layer tests
```

## Test Output Structure

Test results are organized by target framework:
```text
.test/<TargetFramework>/
  - Test assemblies
  - Test reports
  - Coverage data
```

## Build Configuration

```xml
<ItemGroup>
    <PackageReference Include="xunit" Version="2.9.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2" />
    <PackageReference Include="Xunit.StaFact" Version="1.1.14" />
    <PackageReference Include="Moq" Version="4.20.70" />
</ItemGroup>
```

## Coverage Configuration

Coverage settings in `.config/coverlet.runsettings`:
- Code coverage thresholds
- Exclude patterns for generated code
- Report formats (cobertura, lcov, json)

## Testing Best Practices

1. **Unit tests** - Isolated, fast, no external dependencies
2. **Integration tests** - Test component interactions
3. **UI tests** - Use StaFact for single-threaded UI code
4. **Cross-platform tests** - Test on multiple platforms
5. **AOT compatibility** - Ensure tests work with Native AOT

## See Also
- [[Build System Configuration]]
- [[Multi-Targeting Strategy]]
- [[Layered Architecture]]

## Related
- [[Quality Assurance]] — Code quality
- [[CI/CD Pipeline]] — Automation
- [[Developer Onboarding]] — Testing workflow
- [[Alis Architecture Overview]] — Full architecture
- [[projects/Index]] — Test project docs
- [[tests-index]] — Test coverage index
- [[coverage-map]] — Coverage tracking
- [[code-review-checklist]] — Review checklist
- [[build-system]] — Test configuration
- [[handlers-index]] — Test handler index

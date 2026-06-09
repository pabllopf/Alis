# Testing Strategy

Alis uses xUnit testing framework with specialized plugins for cross-platform testing.

## Testing Framework

- **xUnit** - Primary testing framework
- **Xunit.StaFact** - Single-threaded tests for UI/platform-specific code
- **Moq** - Mocking library for dependency injection testing

## Test Organization

Tests are organized by layer:
- `1_Presentation/*/tests/` - Presentation layer tests
- `2_Application/*/tests/` - Application layer tests
- `3_Structuration/*/tests/` - Core library tests
- `4_Operation/*/tests/` - Operation layer tests
- `5_Declaration/*/tests/` - Declaration layer tests
- `6_Ideation/*/tests/` - Ideation layer tests

## Test Output

Test results are organized by target framework:
```text
.test/<TargetFramework>/
```

## Build Configuration

```xml
<ItemGroup>
    <PackageReference Include="xunit" Version="..." />
    <PackageReference Include="xunit.runner.visualstudio" Version="..." />
    <PackageReference Include="Xunit.StaFact" Version="..." />
    <PackageReference Include="Moq" Version="..." />
</ItemGroup>
```

## Coverage Settings

Coverage configuration in `.config/coverlet.runsettings`:
- Code coverage thresholds
- Exclude patterns
- Report formats

## See Also
- [[Build System Configuration]]
- [[Layered Architecture]]

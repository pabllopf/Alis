# Build System Configuration

Alis uses centralized build configuration through `.config/Config.props`.

## Configuration Files

| File | Purpose |
|------|---------|
| `Config.props` | Multi-targeting, runtime identifiers, analyzers |
| `default.sln` | Default solution file |
| `coverlet.runsettings` | Code coverage settings |
| `xunit.runner.json` | xUnit test runner configuration |
| `SonarQube.Analysis.xml` | SonarQube static analysis rules |

## Centralized Properties

All projects inherit from `Config.props`:

```xml
<Project>
    <PropertyGroup>
        <LangVersion>13</LangVersion>
        <Nullable>disable</Nullable>
        <WarningsAsErrors>true</WarningsAsErrors>
        <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
        <EnableNETAnalyzers>true</EnableNETAnalyzers>
        <AnalysisMode>AllEnabledByDefault</AnalysisMode>
    </PropertyGroup>
    
    <ItemGroup>
        <PackageReference Include="Microsoft.SourceLink.GitHub" Version="8.0.0" PrivateAssets="All"/>
    </ItemGroup>
</Project>
```

## Release Build Settings

- `Deterministic=true` - Reproducible builds
- `ContinuousIntegrationBuild=true` - CI optimization
- `GenerateDocumentationFile=true` - XML docs generation
- `SourceLinkCreate=true` - Source link for debugging

## SonarQube Integration

Static analysis rules defined in `SonarQube.Analysis.xml`:
- Code quality gates
- Security vulnerabilities
- Maintainability issues

## See Also
- [[Multi-Targeting Strategy]]
- [[Layered Architecture]]

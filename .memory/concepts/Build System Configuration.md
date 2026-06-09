# Build System Configuration

tags:
  - concept,theory,documentation

Alis uses centralized build configuration through `.config/Config.props` for consistent settings across all 140+ projects.

## Configuration Files

| File | Purpose |
|------|---------|
| `Config.props` | Multi-targeting, runtime identifiers, analyzers, global properties |
| `default.sln` | Default solution file for IDE integration |
| `coverlet.runsettings` | Code coverage settings and thresholds |
| `xunit.runner.json` | xUnit test runner configuration |
| `SonarQube.Analysis.xml` | SonarQube static analysis rules and quality gates |

## Centralized Properties (Config.props)

```xml
<Project>
    <PropertyGroup>
        <LangVersion>13</LangVersion>
        <Nullable>disable</Nullable>
        <WarningsAsErrors>true</WarningsAsErrors>
        <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
        <EnableNETAnalyzers>true</EnableNETAnalyzers>
        <AnalysisMode>AllEnabledByDefault</AnalysisMode>
        <AnalysisLevel>latest</AnalysisLevel>
    </PropertyGroup>
    
    <ItemGroup>
        <PackageReference Include="Microsoft.SourceLink.GitHub" Version="8.0.0" PrivateAssets="All"/>
    </ItemGroup>
</Project>
```

## Multi-Targeting Configuration

### Debug Target Frameworks
- `netcoreapp2.0`
- `net5.0`, `net8.0`, `net10.0`
- `netstandard2.0`
- `net461`

### Release Target Frameworks (15+ frameworks)
- **.NET Core**: 2.0, 2.1, 2.2, 3.0, 3.1
- **.NET**: 5.0 through 10.0
- **.NET Standard**: 2.0, 2.1
- **.NET Framework**: 4.61, 4.71, 4.72, 4.8, 4.81

## Release Build Settings

- `Deterministic=true` - Reproducible builds
- `ContinuousIntegrationBuild=true` - CI optimization flags
- `GenerateDocumentationFile=true` - XML documentation generation
- `SourceLinkCreate=true` - Source link for remote debugging
- `PublishRepositoryUrl=true` - Publish source URL

## SonarQube Integration

Static analysis rules defined in `SonarQube.Analysis.xml`:
- Code quality gates (maintainability rating A)
- Security vulnerability detection
- Code smells and bugs
- Duplication detection

## Platform-Specific Constants

Build-time constants automatically defined based on `RuntimeIdentifier`:
- `winx64`, `linuxx64`, `browserwasm`, `osxarm64`, etc.

## See Also
- [[Multi-Targeting Strategy]]
- [[Platform-Specific Build Constants]]
- [[Layered Architecture]]

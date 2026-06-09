# Build System — ALIS

## SDK Requirements

```json
{
  "sdk": {
    "version": "10.0.0",
    "rollForward": "latestMajor",
    "allowPrerelease": false
  }
}
```

---

## Build Commands

```bash
# Restore all dependencies
dotnet restore

# Build all projects (Debug)
dotnet build alis.slnx

# Build all projects (Release)
dotnet build alis.slnx -c Release

# Run all tests
dotnet test alis.slnx

# Run tests with coverage
dotnet test alis.slnx /p:CollectCoverage=true

# Create NuGet packages
dotnet pack -c Release
```

---

## Multi-Targeting Configuration

### Debug Mode (6 frameworks)
```
netcoreapp2.0; net5.0; net8.0; net10.0; netstandard2.0; net461
```

### Release Mode (21 frameworks)
```
netcoreapp2.0; netcoreapp2.1; netcoreapp2.2; netcoreapp3.0; netcoreapp3.1;
net5.0; net6.0; net7.0; net8.0; net9.0; net10.0;
netstandard2.0; netstandard2.1;
net461; net471; net472; net48; net481
```

---

## Runtime Identifiers

```
browser-wasm;
win-x64; win-x86;
linux-x64; linux-arm64; linux-arm;
osx-x64; osx-arm64;
android-arm64; android-x64;
ios-arm64; iossimulator-arm64; iossimulator-x64
```

---

## Platform Configurations

| Setting | Value |
|---------|-------|
| Platforms | AnyCPU; x64; x86; arm; arm64 |
| Configurations | Debug; Release |
| LangVersion | 13 |
| Nullable | disable |
| AllowUnsafeBlocks | false (default, per-project override) |
| OutputType | Library |
| NeutralLanguage | en |

---

## Code Analysis

| Setting | Value |
|---------|-------|
| EnableNETAnalyzers | true |
| AnalysisMode | AllEnabledByDefault |
| AnalysisLevel | latest |
| TreatWarningsAsErrors | true |
| WarningsAsErrors | true |
| RunAnalyzersDuringBuild | false (Directory.Build.props) |

---

## Source Link

```xml
<PackageReference Include="Microsoft.SourceLink.GitHub" Version="8.0.0" PrivateAssets="All"/>
<SourceLinkCreate>true</SourceLinkCreate>
<PublishRepositoryUrl>true</PublishRepositoryUrl>
<EmbedUntrackedSources>true</EmbedUntrackedSources>
<ContinuousIntegrationBuild>true</ContinuousIntegrationBuild>
<Deterministic>true</Deterministic>
```

---

## Release Build Features

- `IncludeBuildOutput=false` (source-only packages)
- `IncludeSymbols=false`
- `SymbolPackageFormat=snupkg`
- `DebugType=portable`
- `DebugSymbols=true`
- `GenerateDocumentationFile=true`

---

## Native Library Handling

The build system automatically copies native libraries based on RID:

```
runtimes/<RID>/native/ → CopyToOutputDirectory=PreserveNewest
```

Supported RIDs for native libraries: win-x64, linux-x64, linux-arm64, osx-x64, osx-arm64, and more.

---

## InternalsVisibleTo

All projects expose internals to their test assemblies:
```xml
<InternalsVisibleTo Include="$(AssemblyName).Test"/>
```

---

## NoWarn Suppressions

Key suppressed warnings:
- **CS1685**: Global alias conflicts across assemblies
- **CS0436**: Type override from dependency
- **NU1903/NU1902/NU1904**: Package vulnerability warnings
- **CA1031**: General exception catching
- **CA1062**: Parameter validation (deferred to runtime)
- **ALIS001–ALIS010**: Custom project-specific analyzer rules

---

## CI/CD Workflows

| Workflow | Trigger | Purpose |
|----------|---------|---------|
| [ALIS][CODE] | Push/PR | Code quality checks |
| [ALIS][TEST] | Push/PR | Test execution |
| [ALIS][PUBLISH] | Release | NuGet package publishing |
| [ALIS][BENCHMARK] | Schedule/Push | Performance benchmarks |
| [ALIS][SONARCLOUD] | Push | Main SonarCloud analysis |
| [ALIS][*][SONARCLOUD] | Push | Per-project SonarCloud (35+ workflows) |
| [ALIS][DEPENDENCY][REVIEW] | PR | Dependency review |
| [ALIS][CONTRIBUTORS] | Push | Contributor management |
| [ALIS][CHECK][ISSUES] | Schedule | Issue tracking |

---

## Related Documentation

- [[architecture/repository-overview]] — Architecture overview
- [[system/indexes/architecture-index]] — Architecture patterns
- [[onboarding/getting-started]] — Getting started guide

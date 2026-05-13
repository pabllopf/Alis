# Alis - Build Configuration Cache

## Overview
This cache documents all build configuration for the Alis solution, enabling fast understanding of compilation targets without reading .csproj files.

## Compiler Settings (from Directory.Build.props + Config.props)
| Setting | Value |
|---------|-------|
| **Language Version** | C# 13 (LangVersion=13) |
| **Nullable** | Disabled |
| **Unsafe Blocks** | Disabled (AllowUnsafeBlocks=false) |
| **Warnings as Errors** | true |
| **Treat Warnings as Errors** | true |
| **EnableNETAnalyzers** | true |
| **AnalysisMode** | AllEnabledByDefault |
| **AnalysisLevel** | latest |
| **Output Type** | Library (default) |
| **Neutral Language** | en |
| **EmitCompilerGeneratedFiles** | true |
| **VSTestLogger** | trx (with filename) |
| **TestOutput** | `.test/$(TargetFramework)/` |
| **AssemblyVersion** | 1.0.6 |

## Target Frameworks (TFMs)

### Debug Configuration
| TFM | Purpose |
|-----|---------|
| netcoreapp2.0 | Legacy .NET Core |
| net5.0 | .NET 5 LTS |
| net8.0 | .NET 8 LTS |
| net10.0 | .NET 10 (preview) |
| netstandard2.0 | Cross-platform standard |
| net461 | .NET Framework 4.6.1 |

### Release Configuration (Full)
| TFM | Category |
|-----|----------|
| netcoreapp2.0, 2.1, 2.2, 3.0, 3.1 | .NET Core (legacy) |
| net5.0, 6.0, 7.0, 8.0, 9.0, 10.0 | .NET (modern) |
| netstandard2.0, 2.1 | .NET Standard |
| net461, 471, 472, 48, 481 | .NET Framework |

**Total TFMs in Release: 20 frameworks**

## Runtime Identifiers (RIDs)
| Category | RIDs |
|----------|------|
| **Windows** | win-x64, win-x86, win-arm64 |
| **Linux** | linux-x64, linux-arm64, linux-arm, linux-musl-x64, linux-musl-arm, linux-musl-arm64 |
| **macOS** | osx-x64, osx-arm64 |
| **Web** | browser-wasm |
| **Android (planned)** | android-arm64, android-x64 |
| **iOS (planned)** | ios-arm64, iosimulator-arm64, iosimulator-x64 |

## Build Profiles (`.config/default/`)
| Profile | Purpose |
|---------|---------|
| `default_csproj.props` | Standard library projects |
| `default_app_csproj.props` | Application projects (UI, runtime) |
| `default_test_csproj.props` | Test projects (xunit, Moq, Test.Sdk) |
| `default_sample_csproj.props` | Sample/demo projects |
| `default_generator_csproj.props` | Source generator projects |
| `default_sample_web_csproj.props` | Web sample projects |
| `default_sample_android_csproj.props` | Android sample projects |
| `default_sample_ios_csproj.props` | iOS sample projects |

## Release Build Settings
| Setting | Value |
|---------|-------|
| **IncludeBuildOutput** | false |
| **IncludeSymbols** | false |
| **SymbolPackageFormat** | snupkg |
| **DebugType** | portable |
| **DebugSymbols** | true |
| **PublishRepositoryUrl** | true |
| **EmbedUntrackedSources** | true |
| **ContinuousIntegrationBuild** | true |
| **GenerateDocumentationFile** | true |
| **Deterministic** | true |
| **SourceLinkCreate** | true |

## Version Information
| Property | Value |
|----------|-------|
| **AssemblyVersion** | 1.0.6 (from Directory.Build.props) |
| **Company** | Pablo Perdomo Falcón |
| **Product** | Alis |
| **License** | GNU General Public License v3.0 |
| **Repository** | https://github.com/pabllopf/Alis |

## Conditional Package References
| TFM Group | Packages |
|-----------|----------|
| net461-481 | System.IO.Compression, System.Net.Http, System.Runtime.CompilerServices.Unsafe, System.Memory |
| netcoreapp2.0-3.1 | System.Runtime.CompilerServices.Unsafe, System.Memory |
| netstandard2.0-2.1 | System.Runtime.CompilerServices.Unsafe, System.Memory |

## Analyzer Configuration
| Analyzer | Status |
|----------|--------|
| Microsoft.CodeAnalysis.NetAnalyzers | Enabled (AllEnabledByDefault) |
| Roslynator.Analyzers | Referenced in solution |
| Roslynator.CodeAnalysis.Analyzers | Referenced in solution |
| Roslynator.Formatting.Analyzers | Referenced in solution |

## Suppressed Warnings (Key)
| Warning | Reason |
|---------|--------|
| CS1685 | Global alias definition on different assemblies |
| CS0436 | Overriding dependency version |
| NU1903, NU1902 | Package vulnerability warnings |
| CS0162 | Unreachable code (intentional) |
| NU5128 | Project references in packages |
| CS1591 | Missing XML documentation comments |
| ALIS001-ALIS010 | Custom Alis code analysis rules |
| CA* (all) | Code analysis rules suppressed |

## Native Runtime Packaging
Release builds package native libraries for:
- `runtimes/linux-{x64,arm,arm64,musl-x64,musl-arm,musl-arm64}/lib/{TFM}/`
- `runtimes/osx-{x64,arm64}/lib/{TFM}/`
- `runtimes/win-{x64,x86,arm64}/lib/{TFM}/`

Each TFM from net5.0 through net10.0, netcoreapp2.0-3.1, netstandard2.0-2.1, and net461-481.

## Build Commands
```bash
# Full solution build (Debug)
dotnet build alis.slnx -c Debug

# Full solution build (Release)
dotnet build alis.slnx -c Release

# Build specific module
dotnet build 4_Operation/Ecs/src/Alis.Core.Ecs.csproj

# Run tests (all)
dotnet test alis.slnx

# Run tests (specific module)
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj

# Test output location
.test/{TargetFramework}/{ProjectName}.trx
```

## Project Reference Injection (Debug Mode)
In Debug mode, Config.props auto-injects project references based on layer:
- `1_Presentation` → references `2_Application/Alis.csproj`
- `2_Application` → references `3_Structuration/Core/src/*.csproj`
- `3_Structuration` → references `4_Operation/*/src/*.csproj`
- `4_Operation` → references `5_Declaration/Aspect/src/*.csproj`
- `5_Declaration` → references `6_Ideation/*/src/*.csproj`

## Generator Reference Injection
All layers inject generator projects as analyzers:
- Generators target `netstandard2.0`
- Injected as `Analyzer` with `PrivateAssets=all`
- Output assemblies not referenced (`ReferenceOutputAssembly=false`)

## Custom Suppressed Warnings per Module
| Module | Suppressed Warnings |
|--------|-------------------|
| Time.Test | ALIS009, ALIS010, ALIS001, ALIS003, ALIS002, ALIS005, ALIS006, ALIS007, ALIS008 |
| Sample projects | Similar pattern with custom codes |
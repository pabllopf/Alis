---
title: Build Summary — ALIS
tags:
  - summary
  - overview
  - documentation

status: draft
---


## Build System Overview

### Centralized Configuration
- **Directory.Build.props**: C# 13, net8.0/netstandard2.0, SonarQube, global packages
- **.config/Config.props**: Version 0.1.0, author Pablo, MIT license

### Build Commands
```bash
dotnet restore                    # Restore dependencies
dotnet build alis.slnx            # Build all projects
dotnet test                       # Run all tests
dotnet pack -c Release           # Create NuGet packages
```

### Multi-Targeting
- **Desktop**: net8.0 (Windows, macOS, Linux)
- **Portable**: netstandard2.0 (cross-platform compatibility)
- **Native Runtimes**: 12+ platform/architecture combos

### AOT Support
- PublishAot enabled
- EnableTrimAnalyzer enabled
- IsAotCompatible where applicable

### Code Analysis
- SonarQube with custom NoWarn rules
- ALIS001-ALIS010 custom analyzers
- Test projects excluded from analysis

## Build Pipeline
1. **Restore**: NuGet packages restored via Directory.Build.props
2. **Compile**: C# 13 compilation with nullable reference types
3. **Generate**: Roslyn source generators run (Ideation → Declaration)
4. **Analyze**: SonarQube analysis (excluding tests)
5. **Test**: xUnit tests run with coverlet coverage
6. **Package**: NuGet packages created with native runtime support

## Related

- [[build-system]] — Detailed build configuration
- [[Build System Configuration]] — Config.props details
- [[Multi-Targeting Strategy]] — Framework targets
- [[Platform-Specific Build Constants]] — Platform constants
- [[adr-001-layered-architecture]] — Architecture decision
- [[project-index]] — Framework targets per project
- [[projects/Build-System]] — Build system project docs
- [[code-review-checklist]] — Build checklist
- [[onboarding/getting-started]] — Build commands
- [[ai-context]] — Build reference

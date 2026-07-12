---
title: Conventions Overview
tags:
  - conventions
  - coding-standards
  - style
status: Draft
license: GPLv3
---

# Conventions Overview

## Coding Conventions

| Rule | Standard |
|---|---|
| Language | C# 13 |
| Nullable | Disabled (project-wide) |
| Warnings | Treated as errors |
| Unsafe code | Disallowed |
| Namespaces | Block-scoped (`namespace Foo { }`) |
| `var` | Forbidden for built-in types or when type is apparent |
| Expression-bodied members | Preferred |
| Private fields | `_camelCase` |
| Private static readonly/const | PascalCase |
| Comments | Forbidden — only XML doc comments (`///`) allowed |
| Max line length | 392 characters |
| Language | All English (code, docs, tests, comments) |
| File header | Mandatory (GPLv3 license header) |

## File Organization Convention

```text
<module>/
├── generator/     # Roslyn source generator (netstandard2.0)
├── sample/        # Usage example
├── src/           # Main library
└── test/          # xUnit test project
```

## Build Conventions

- All projects import `.config/Config.props`
- Output directory: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`
- All projects packable via NuGet
- Version follows `Directory.Build.props` (1.0.8)
- InternalsVisibleTo for test assemblies via convention

## Test Conventions

- xUnit + Moq framework
- File naming: `{ClassName}{Suffix}Test.cs`
- Platform-specific tests use custom attributes
- Test results: `.test/<TargetFramework>/`

## Commit Conventions

Based on SonarCloud remediation system:
```
fix(<scope>): resolve sonar <issueType> <ruleKey>
```

General commit style follows conventional commits pattern.

## Architecture Conventions

- Strict 6-layer dependency (enforced by MSBuild)
- Cross-layer dependencies only through immediate lower layer
- Source generators consumed as analyzers, not direct references
- All core projects have zero external NuGet dependencies

## Related Documents

- [[architecture-overview]]
- [[build-pipeline]]
- [[repository-overview]]

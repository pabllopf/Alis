---
title: Layer Violations
tags:
  - dependencies
  - violations
  - architecture
status: Draft
license: GPLv3
---

# Layer Violations

## Current Status

No layer violations detected. The MSBuild configuration in `.config/Config.props` strictly enforces the 6-layer dependency rule through conditional project references.

## Enforcement Mechanism

`Config.props` uses directory-path-based conditional references:

```xml
<ProjectReference Condition="$(ProjectDir.Contains('N_Presentation'))"
                  Include="$(SolutionDir)(N+1)_Application/..."/>
```

This makes reverse dependencies a compile-time error.

## Potential Risk Areas

1. **Release configuration** uses `Compile` includes (not `ProjectReference`) for lower layers — this bypasses normal dependency resolution. Source files from layers 3-6 are compiled directly into the Application project.
2. **Extension projects** in Presentation layer directly reference the Application layer — this is correct architecturally.

## Related Documents

- [[dependency-graph]]
- [[architecture-overview]]
- [[build-pipeline]]

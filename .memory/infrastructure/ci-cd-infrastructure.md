---
title: CI/CD Infrastructure
tags:
  - infrastructure
  - ci
  - cd
  - github-actions
status: Draft
license: GPLv3
---

# CI/CD Infrastructure

## Overview

Alis uses GitHub Actions for continuous integration and deployment, with SonarQube for static analysis.

## Configuration Files

| File | Purpose |
|---|---|
| `.github/workflows/*.yml` | GitHub Actions workflows |
| `.config/SonarQube.Analysis.xml` | SonarQube analysis settings |
| `.config/coverlet.runsettings` | Code coverage thresholds |
| `.config/xunit.runner.json` | Test runner configuration |

## CI Pipeline

```mermaid
flowchart LR
    Push[Git Push] --> CI[GitHub Actions]
    CI --> Restore[dotnet restore]
    Restore --> Build[dotnet build]
    Build --> Test[dotnet test]
    Test --> Coverage[Coverlet Coverage]
    Coverage --> SonarQube[SonarQube Analysis]
    SonarQube --> Report[Quality Report]
```

## Quality Gates

- SonarQube with custom ruleset
- Code coverage via coverlet
- Warning-as-errors enabled
- SonarQube warnings suppressed (noise reduction)

## Test Infrastructure

- xUnit framework with Moq mocking
- Xunit.StaFact for STA thread tests
- Results in TRX format at `.test/<TargetFramework>/`
- Coverage thresholds in `.config/coverlet.runsettings`

## Related

- [[Build Infrastructure]]
- [[Build System]]
- [[Testing Overview]]

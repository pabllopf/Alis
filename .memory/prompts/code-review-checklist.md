---
title: Code Review Checklist — ALIS
tags:
  - prompt
  - ai
  - reference

status: Draft

license: GPLv3

---


## Architecture Compliance
- [ ] Project is in the correct architectural layer
- [ ] Dependencies only reference the immediate lower layer
- [ ] No cross-layer or upward references
- [ ] Aggregator projects contain no hand-written code

## Code Quality
- [ ] C# 13 features used appropriately
- [ ] Nullable reference types enabled where applicable
- [ ] XML documentation comments present on public APIs
- [ ] No SonarQube violations (S4136, S4200, S3925, S3267, CA1816)
- [ ] Test coverage adequate (check coverlet reports)

## Source Generators
- [ ] Generator produces correct output
- [ ] Generated code doesn't need manual modification
- [ ] Generator tests cover edge cases
- [ ] Generator outputs to correct layer (Declaration)

## Testing
- [ ] Test project follows `{ProjectName}.Test` naming
- [ ] Tests use xUnit conventions
- [ ] Mock objects used for dependencies (Moq)
- [ ] Test project excluded from SonarQube

## Build & Packaging
- [ ] Builds successfully on net8.0 and netstandard2.0 (where applicable)
- [ ] Native runtime packages correct for target platform
- [ ] SFML assets included in NuGet package
- [ ] AOT compatibility maintained (if applicable)

## Documentation
- [ ] Project doc exists in `.memory/projects/`
- [ ] README updated (if applicable)
- [ ] Architecture docs updated (if layer structure changed)

## Related

- [[ai-context]] — AI agent reference
- [[conversation-starters]] — Context questions
- [[naming-conventions]] — Naming rules
- [[adr-001-layered-architecture]] — Layer rules
- [[adr-002-aggregator-pattern]] — Aggregator rules
- [[testing/analysis]] — Test patterns and conventions
- [[security/analysis]] — Security best practices
- [[build-system]] — Build configuration
- [[projects/Index]] — Project docs checklist
- [[analysis-state]] — Documentation coverage

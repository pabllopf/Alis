---
title: Testing Overview
tags:
  - testing
  - test
  - quality
  - assurance

status: Draft

license: GPLv3

---


## Test Coverage Status

### Documented Projects with Tests

| Project | Test Project | Coverage | Status |
|---|---|---|---|
| Alis.Core.Ecs | Alis.Core.Ecs.Test | ~30% | Partial |
| Alis.Core.Graphic | Alis.Core.Graphic.Test | ~20% | Limited |

### Projects Without Tests

- Most Extension projects
- Many Sample projects
- Core foundation (Alis.Core)

## Testing Framework

- **xUnit**: Primary testing framework
- **Platform-specific tests**: macOS, Windows, Linux, WebAssembly

## Test Categories

1. **Unit Tests**: Component testing, entity operations
2. **Integration Tests**: Scene management, system interactions
3. **Platform Tests**: Native binding verification
4. **Performance Tests**: Benchmarking critical paths

## Recommendations

1. Increase test coverage to 80%+ for core systems
2. Add automated CI/CD testing
3. Implement property-based testing for ECS queries
4. Add fuzzing tests for asset pack parsing

## Flaky Test Risks

- Platform-specific timing issues
- Native binding initialization races
- Multi-threaded ECS updates

## Related

- [[testing/analysis]] — Detailed testing patterns
- [[tests-index]] — All test projects indexed
- [[code-review-checklist]] — Testing checklist
- [[coverage-map]] — Test coverage tracking
- [[projects/Testing-Strategy]] — Testing strategy doc
- [[Alis.Core.Ecs.Test]] — ECS test documentation
- [[Alis.Core.Graphic.Test]] — Graphic test documentation
- [[onboarding/getting-started]] — Running tests guide
- [[build-system]] — Test commands
- [[build-summary]] — Test pipeline

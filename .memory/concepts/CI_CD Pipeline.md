# CI/CD Pipeline

Alis uses GitHub Actions for continuous integration and deployment.

## GitHub Actions Workflows

### Build Workflow
- Triggers: Push to main, Pull requests
- Jobs: Build all layers, Run tests
- Matrix: Multi-targeting across frameworks

### Release Workflow
- Triggers: Tagged releases
- Jobs: Package distribution, NuGet publishing

## CI/CD Stages

1. **Build** - Compile all `.slnx` files
2. **Test** - Execute test suites
3. **Analyze** - SonarQube static analysis
4. **Package** - Create distributable artifacts
5. **Publish** - Deploy to NuGet or release pages

## Quality Gates

- Build success across all target frameworks
- Test coverage thresholds
- No critical SonarQube issues
- Documentation generation successful

## See Also
- [[Build System Configuration]]
- [[Multi-Targeting Strategy]]

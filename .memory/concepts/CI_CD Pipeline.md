# CI/CD Pipeline

tags:
  - concept,theory,documentation

Alis uses GitHub Actions for continuous integration and automated testing across all target frameworks.

## GitHub Actions Workflows

### Build Workflow
- **Triggers**: Push to main branch, Pull requests
- **Jobs**: 
  - Build all `.slnx` files
  - Run test suites for each target framework
  - Generate code coverage reports
  - SonarQube static analysis

### Release Workflow
- **Triggers**: Tagged releases (v*.*.*)
- **Jobs**:
  - Package distribution
  - NuGet package publishing
  - Documentation generation

## CI/CD Stages

1. **Build** - Compile all projects across 15+ target frameworks
2. **Test** - Execute test suites with coverage reporting
3. **Analyze** - SonarQube static code analysis
4. **Package** - Create distributable artifacts and NuGet packages
5. **Publish** - Deploy to NuGet.org or GitHub Releases

## Quality Gates

- Build success across all target frameworks
- Test coverage thresholds met
- No critical SonarQube issues
- Documentation generation successful
- No security vulnerabilities detected

## Matrix Testing

Tests run across matrix of:
- Target frameworks (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
- Runtime identifiers (win-x64, linux-x64, osx-x64, browser-wasm)
- Configuration (Debug, Release)

## See Also
- [[Build System Configuration]]
- [[Multi-Targeting Strategy]]
- [[Testing Strategy]]

## Related
- [[Quality Assurance]] — Quality gates
- [[Testing Strategy]] — Test automation
- [[Multi-Targeting Strategy]] — Matrix testing
- [[Developer Onboarding]] — CI workflow
- [[Alis Architecture Overview]] — Full architecture
- [[build-system]] — Build configuration
- [[performance-index]] — Performance tracking
- [[project-index]] — Project enumeration

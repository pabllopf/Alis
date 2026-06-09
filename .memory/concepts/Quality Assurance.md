# Quality Assurance

Alis implements comprehensive quality assurance through static analysis, code coverage, and automated testing.

## Static Analysis

### SonarQube
- Code quality gates (maintainability rating A)
- Security vulnerability detection
- Code smells and bugs
- Duplication detection
- Configuration: `.config/SonarQube.Analysis.xml`

### .NET Analyzers
- Enabled for all projects
- Analysis mode: AllEnabledByDefault
- Analysis level: latest
- Warnings treated as errors

## Code Quality Rules

```xml
<PropertyGroup>
    <WarningsAsErrors>true</WarningsAsErrors>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
    <EnableNETAnalyzers>true</EnableNETAnalyzers>
    <AnalysisMode>AllEnabledByDefault</AnalysisMode>
</PropertyGroup>
```

## Code Coverage

- Tool: Coverlet
- Configuration: `.config/coverlet.runsettings`
- Report formats: cobertura, lcov, json
- Exclude patterns for generated code

## Documentation Requirements

- XML documentation (`///`) for all public/protected APIs
- No inline comments (`//` or `/* */`) in code
- Documentation file generated: `GenerateDocumentationFile=true`

## Source Link

- Microsoft.SourceLink.GitHub for remote debugging
- Source URL published: `PublishRepositoryUrl=true`
- Embedded source in release builds

## Quality Gates

1. Build success across all target frameworks
2. Test coverage thresholds met
3. No critical SonarQube issues
4. Documentation generation successful
5. No security vulnerabilities detected

## See Also
- [[Build System Configuration]]
- [[CI/CD Pipeline]]
- [[Testing Strategy]]

## Related
- [[Testing Strategy]] — Testing approach
- [[CI/CD Pipeline]] — Automation pipeline
- [[Developer Onboarding]] — Standards reference
- [[Alis Architecture Overview]] — Full architecture
- [[projects/Index]] — All project docs
- [[tests-index]] — Test coverage index
- [[coverage-map]] — Coverage tracking
- [[code-review-checklist]] — Review checklist
- [[build-system]] — Build configuration

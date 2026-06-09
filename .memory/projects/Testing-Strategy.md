# Testing Strategy

## Overview
ALIS uses a distributed testing approach where each project has its own test project. Test projects auto-discover their source project via regex pattern matching.

## Test Project Structure
Every library project has a corresponding test project:
- **Library**: `src/Alis.Module.csproj`
- **Test**: `test/Alis.Module.Test.csproj`
- **Sample**: `sample/Alis.Module.Sample.csproj`

## Test Project Discovery Pattern
Test projects use MSBuild conditions to find their source project:

```xml
<ItemGroup Condition="!$(ProjectName.Contains('Sample')) AND !$(ProjectName.Contains('Test'))">
  <ProjectReference Include="..\src\Alis.Module.csproj" />
</ItemGroup>

<ItemGroup Condition="$(ProjectName.Contains('Test'))">
  <ProjectReference Include="..\src\Alis.Module.csproj" />
</ItemGroup>
```

For the core Alis.Test project:
```xml
<ProjectReference Include="..\src\Alis.csproj" />
```

## Test Output Configuration
- **Output Directory**: `bin/$(Configuration)/$(RuntimeIdentifier)/test/$(TargetFramework)/`
- **SonarQubeExclude**: true (all test projects)
- **IsTestProject**: Not explicitly set (uses convention)

## Test Project Dependencies
All test projects reference:
- Their corresponding source project
- All generators from all layers (via glob references)

## Test Project Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true

## Test Project Asset Pipeline
All test projects use the same asset pipeline:
- SHA256 hash-based change detection
- Incremental build via manifest file
- Base64-encoded zip archives

## Key Build Targets (All Test Projects)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Running Tests
```bash
# Run all tests
dotnet test Alis.sln

# Run tests for specific project
dotnet test path/to/Alis.Module.Test.csproj

# Run tests with coverage
dotnet test Alis.sln /p:CollectCoverage=true
```

## Notes
- No centralized test framework configuration — each test project uses conventions
- Test projects are excluded from SonarQube analysis
- Sample projects are not tested (no test project for samples)
- Test discovery is automatic via MSBuild conditions

## Related

- [[testing-overview]] — High-level test coverage
- [[testing/analysis]] — Detailed test patterns
- [[tests-index]] — All test projects indexed
- [[projects/Cross-Cutting-Concerns]] — Build config for tests
- [[code-review-checklist]] — Testing checklist
- [[onboarding/getting-started]] — Running tests
- [[build-system]] — Test commands
- [[projects/Build-System]] — Build system docs
- [[coverage-map]] — Test coverage tracking

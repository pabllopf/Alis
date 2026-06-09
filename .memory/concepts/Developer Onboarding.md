# Developer Onboarding

Quick reference for new developers joining the Alis project.

## Prerequisites

- .NET SDK (latest version supporting net10.0)
- C# 13 language support
- Git
- IDE: Visual Studio, Rider, or VS Code

## Getting Started

### Clone Repository
```bash
git clone https://github.com/pabllopf/Alis.git
cd Alis
```

### Restore Dependencies
```bash
dotnet restore alis.slnx
```

### Build Solution
```bash
dotnet build alis.slnx
```

### Run Tests
```bash
dotnet test alis.test.slnx
```

## Architecture Overview

### 6-Layer Structure

```
1_Presentation/  ← User-facing apps + extensions
2_Application/   ← Main app + sample games
3_Structuration/ ← Core foundations
4_Operation/     ← Graphics, audio, media, platform operations
5_Declaration/   ← Contracts, interfaces, metadata
6_Ideation/      ← Experimental modules
```

## Development Workflow

1. Choose appropriate `.slnx` for your work:
   - `alis.core.slnx` - Core library changes
   - `alis.apps.slnx` - Application changes
   - `alis.extensions.slnx` - Extension changes
   - `alis.samples.slnx` - Sample game changes

2. Make changes in appropriate layer
3. Run tests: `dotnet test`
4. Build: `dotnet build`
5. Commit with conventional commit message

## Coding Standards

- C# 13 language features
- XML documentation (`///`) for all public APIs
- No inline comments in code
- Warnings treated as errors
- Multi-targeting for all projects

## Testing

- xUnit framework
- StaFact for UI/platform-specific tests
- Moq for mocking
- Tests organized by layer

## Documentation

- Update relevant `.memory/concepts/` files
- Add wiki-links to related concepts
- Keep documentation concise and focused

## See Also
- [[Layered Architecture]]
- [[Build System Configuration]]
- [[Testing Strategy]]

## Related
- [[Alis Architecture Overview]] — Full architecture
- [[Repository Structure]] — Codebase layout
- [[Solution Files Strategy]] — Build solutions
- [[CI/CD Pipeline]] — Build and test automation
- [[Quality Assurance]] — Code quality
- [[Multi-Targeting Strategy]] — Framework targets
- [[Platform-Specific Build Constants]] — Platform detection
- [[projects/Index]] — All project docs
- [[onboarding/getting-started]] — Quick start guide
- [[code-review-checklist]] — Review checklist

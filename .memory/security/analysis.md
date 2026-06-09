# Security Analysis — ALIS

## Security Extensions
ALIS includes several security-related extensions:

### Alis.Extension.Security
- **Purpose**: Security and encryption utilities
- **Layer**: 1_Presentation
- **Dependencies**: Alis.App.Core

### Alis.Extension.Payment.Stripe
- **Purpose**: Stripe payment integration
- **Layer**: 1_Presentation
- **Dependencies**: Alis.App.Core
- **Security Considerations**:
  - API keys should never be committed to source control
  - Use environment variables or secure configuration
  - Stripe SDK handles PCI compliance

### Alis.Extension.Cloud.DropBox / GoogleDrive
- **Purpose**: Cloud storage integration
- **Layer**: 1_Presentation
- **Security Considerations**:
  - OAuth tokens should be stored securely
  - Token refresh logic must handle expiration
  - User consent flows must be properly implemented

## Security Best Practices

### Configuration
- Never commit API keys, tokens, or secrets
- Use environment variables for sensitive configuration
- Use `Directory.Build.props` for non-sensitive build config only

### Dependencies
- Regularly update NuGet packages for security patches
- Monitor SonarQube security hotspots
- Use `dotnet list package --vulnerable` for vulnerability scanning

### Code Analysis
- SonarQube rules active with custom NoWarn list
- ALIS001-ALIS010 custom analyzers for project-specific rules
- Test projects excluded from SonarQube analysis

### Native Libraries
- SFML native libraries bundled in NuGet packages
- Verify integrity of native binaries
- Use signed packages for distribution

## Related

- [[security-overview]] — High-level security analysis
- [[security-index]] — Security-sensitive areas
- [[Alis.Extension.Security]] — Security extension
- [[Alis.Extension.Payment.Stripe]] — Stripe payment security
- [[Alis.Extension.Cloud.DropBox]] — Dropbox auth security
- [[code-review-checklist]] — Security review items
- [[build-system]] — Secure build configuration
- [[project-index]] — Security extension projects

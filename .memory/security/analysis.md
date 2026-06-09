# Security Analysis — ALIS

tags:
  - project,documentation,reference

## Security Extensions

### Alis.Extension.Security
- **Purpose**: Security and encryption utilities
- **Layer**: 1_Presentation
- **Dependencies**: Alis.App.Core

### Alis.Extension.Payment.Stripe
- **Purpose**: Stripe payment integration
- **Layer**: 1_Presentation
- **Dependencies**: Alis.App.Core
- **External Package**: Stripe.net 49.2.0
- **Security Considerations**:
  - API keys should never be committed to source control
  - Use environment variables or secure configuration
  - Stripe SDK handles PCI compliance

### Alis.Extension.Cloud.DropBox / GoogleDrive
- **Purpose**: Cloud storage integration
- **Layer**: 1_Presentation
- **Dependencies**: Alis.App.Core
- **External Packages**: Dropbox.Api 7.0.0, Google.Apis.Drive.v3 1.68.0.3601
- **Security Considerations**:
  - OAuth tokens should be stored securely
  - Token refresh logic must handle expiration
  - User consent flows must be properly implemented

### Alis.Extension.Network
- **Purpose**: TCP/UDP networking
- **Layer**: 1_Presentation
- **Security Considerations**:
  - No built-in TLS/SSL encryption
  - BufferPool prevents allocation attacks
  - Connection lifecycle must be managed carefully

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
- SonarQube rules active with extensive custom NoWarn list
- ALIS001-ALIS010 custom analyzers for project-specific rules
- Test projects excluded from SonarQube analysis
- TreatWarningsAsErrors=true enforced globally

### Native Libraries
- SFML native libraries bundled in NuGet packages
- GLFW and SDL2 native libraries bundled per RID
- Verify integrity of native binaries in CI/CD

### Memory Safety
- `AllowUnsafeBlocks` defaults to false (per-project override)
- `Span<T>` and `Memory<T>` used for safe memory access
- RAII patterns enforced for native resource disposal

### AOT Compatibility
- No `System.Reflection.Emit` or runtime IL generation
- Source generators produce AOT-compatible code
- Custom JSON parser avoids reflection-based serialization

## Compliance

| Requirement | Status |
|-------------|--------|
| GPLv3 License | ✅ All dependencies open source |
| No Proprietary Code | ✅ Verified |
| SonarQube Quality Gates | ✅ Configured per extension |
| Source Link | ✅ Enabled for debuggability |
| Deterministic Builds | ✅ Enabled in Release |

## Recommendations

1. **Add TLS to Network extension** for production use
2. **Implement SAST/DAST scanning** in CI/CD pipelines
3. **Regular dependency updates** via automated tooling
4. **Security documentation** for extension developers
5. **Audit native library integrity** for SFML/GLFW/SDL2 bindings
6. **Implement rate limiting** in Network extension
7. **Add input sanitization** for user-facing extension APIs

---

## Related Documentation

- [[system/indexes/security-index]] — Security index
- [[system/indexes/architecture-index]] — Architecture patterns
- [[prompts/code-review-checklist]] — Security review checklist

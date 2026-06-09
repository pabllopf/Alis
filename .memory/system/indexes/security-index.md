---
title: Security Index — ALIS
tags: [index,catalog,reference]
---


## Security-Sensitive Areas

| Area | Risk Level | Location | Mitigation |
|------|-----------|----------|------------|
| Native Code Interop | High | 4_Operation (ECS, Graphic, Physic) | Bounds checking, validation, safe marshalling |
| Memory Management | Medium | 4_Operation/Ecs, 6_Ideation/Memory | RAII patterns, disposal, Span<T> safety |
| Unsafe Code | Medium | 4_Operation (AllowUnsafeBlocks per project) | Limited to performance-critical paths |
| Asset Loading | Medium | 6_Ideation/Memory | SHA256 integrity verification |
| Network Communication | High | 1_Presentation/Extension/Network | BufferPool, connection lifecycle management |
| Payment Processing | High | 1_Presentation/Extension/Payment.Stripe | Stripe SDK PCI compliance, no local key storage |
| Cloud Authentication | High | 1_Presentation/Extension/Cloud.* | OAuth token lifecycle, secure storage |
| Source Generators | Low | 6_Ideation/*/generator/ | Compile-time only, no runtime code generation |

---

## Security Patterns

### 1. Input Validation
- All user inputs validated before processing
- ECS queries enforce type safety via archetype system
- Physics engine validates collision boundaries

### 2. Resource Disposal
- RAII patterns for native resources (SFML, GLFW, SDL2 bindings)
- `IDisposable`/`IAsyncDisposable` implemented on resource holders
- `Span<T>` and `Memory<T>` used for safe memory access

### 3. AOT Safety
- No `System.Reflection.Emit` or runtime IL generation
- Source generators produce AOT-compatible code
- `AllowUnsafeBlocks` enabled only where performance demands it

### 4. Secure Configuration
- API keys never committed to source control
- Environment variables recommended for secrets
- `Directory.Build.props` contains only non-sensitive build config

### 5. Code Analysis
- SonarQube integration with custom rules
- .NET Analyzers in `AllEnabledByDefault` mode
- `TreatWarningsAsErrors=true` enforced
- Custom ALIS001–ALIS010 analyzers for project-specific rules
- Test projects excluded from SonarQube analysis

---

## Extension Security

### Alis.Extension.Payment.Stripe
- Stripe SDK handles PCI compliance
- API keys must use environment variables
- No local storage of payment credentials

### Alis.Extension.Cloud.DropBox / GoogleDrive
- OAuth tokens require secure storage
- Token refresh logic must handle expiration
- User consent flows must be properly implemented

### Alis.Extension.Security
- Encryption and authentication utilities
- Should be used for any sensitive data operations

### Alis.Extension.Network
- TCP/UDP networking with buffer pooling
- No built-in TLS — must be added for production use

---

## Compliance

| Requirement | Status |
|-------------|--------|
| GPLv3 License | All dependencies open source |
| No Proprietary Code | Verified |
| SonarQube Quality Gates | Configured per extension |
| Source Link | Enabled for debuggability |

---

## Recommendations

1. **Add TLS to Network extension** for production use
2. **Implement SAST/DAST scanning** in CI/CD
3. **Regular dependency updates** via `dotnet list package --vulnerable`
4. **Security documentation** for extension developers
5. **Audit native library integrity** for SFML/GLFW/SDL2 bindings

---

## Related Documentation

- [[security/analysis]] — Detailed security analysis
- [[system/indexes/architecture-index]] — Architecture patterns
- [[prompts/code-review-checklist]] — Security review checklist

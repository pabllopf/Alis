# Alis.Extension.Security

tags:
  - presentation,application,extension,documentation

## Overview
Security extension for ALIS applications. Provides authentication, authorization, and secure data handling capabilities.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~9 C# files

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Security Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides security infrastructure for ALIS applications including authentication providers, authorization checks, secure storage, and encryption utilities.

## Key Components

### Authentication
- **IAuthenticationProvider** — Authentication interface
- **OAuthProvider** — OAuth 2.0 authentication
- **TokenManager** — Token generation and validation
- **SessionManager** — User session management

### Authorization
- **IAuthorizationHandler** — Permission checking
- **RoleProvider** — Role-based access control
- **PolicyEvaluator** — Policy-based authorization

### Cryptography
- **EncryptionService** — Symmetric/asymmetric encryption
- **HashProvider** — Secure hashing (SHA256, bcrypt)
- **SecureString** — In-memory secure data handling

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- [[Alis.App.Core]] (2_Application) — Core framework

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: enabled

## Architecture Notes
1. Provider-based security model
2. Pluggable authentication strategies
3. Role and policy hybrid authorization
4. Secure memory patterns for sensitive data

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Security.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Extension.Payment.Stripe]] — Payment security
- [[Alis.Core.Aspect.Logging]] — Audit logging

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09

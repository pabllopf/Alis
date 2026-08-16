# Result: WebSocketClientFactory.cs

File: `1_Presentation/Extension/Network/src/WebSocketClientFactory.cs`
CoverageBefore: 94.8% (SonarCloud; Line: 94.4%, Branch: 96.9%, 9 uncovered lines)
CoverageAfter: 97.5% (230/236, local coverlet, WebSocketClientFactory-filtered run)
TestsAdded: 1 (WebSocketClientFactoryTlsCoverageTests.cs: loopback TLS handshake attempt)
Commit: test: coverage WebSocketClientFactory.cs
Status: PARTIALLY_REMEDIATED

## Summary

WebSocketClientFactory.cs is the RFC6455 client factory (35 complexity / 218 LOC). The
committed suite covers the plain-TCP connect, handshake and frame paths; the TLS branch
(`GetStream` isSecure path + `TlsAuthenticateAsClient`) was uncovered because it requires a
real TLS handshake.

## Tests added (WebSocketClientFactoryTlsCoverageTests.cs)

A loopback TLS server (`TcpListener` + server-side `SslStream` authenticated with an
in-memory self-signed certificate generated via `CertificateRequest`) behind a `wss://` URI:
the client's `GetStream` connects, creates the `SslStream`, logs the secure-connection
attempt, invokes `TlsAuthenticateAsClient` (hitting `sslStream.AuthenticateAsClient`) and
fails chain validation (self-signed) — asserted via `ThrowsAnyAsync`. Covers 271-272,
310-312 and 314; zero network beyond loopback.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

- 273, 315-316 — the successful-handshake completion (`TlsAuthenticateAsClient` method end,
  `ConnectionSecured` log and `return sslStream`). The base `ValidateServerCertificate` only
  accepts `SslPolicyErrors.None`, so the handshake can only succeed with a chain-trusted
  certificate — not constructible in-process (self-signed certificates always fail chain
  validation; installing a root into the system trust store is out of scope).

## Verification

- WebSocketClientFactory-filtered run: 78 passed / 0 failed (net8.0, ~195ms).
- Local coverlet: WebSocketClientFactory.cs 230/236 = 97.5% (before: 94.4% line).

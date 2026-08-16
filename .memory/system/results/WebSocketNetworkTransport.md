# Result: WebSocketNetworkTransport.cs

File: `1_Presentation/Extension/Network/src/Core/WebSocketNetworkTransport.cs`
CoverageBefore: 80.1% (SonarCloud); local coverlet baseline 88.8% line (150/169)
CoverageAfter: 97.0% line (164/169, local coverlet, net8.0)
TestsAdded: 6 (WebSocketNetworkTransportFailureCoverageTests.cs)
Commit: test: coverage WebSocketNetworkTransport.cs
Status: PARTIALLY_REMEDIATED

## Summary

WebSocketNetworkTransport.cs (368 LOC, WebSocket transport over TcpListener +
WebSocketServerFactory). The committed suite covered the happy paths (start/stop/broadcast with
real loopback handshakes, receive cancellation, dispose). The remaining uncovered lines were
the error paths: non-open socket sends, broadcast skips, stop/dispose failures and the accept
failure catch.

## Work performed

Added 6 tests to `WebSocketNetworkTransportFailureCoverageTests.cs` (xUnit, net8.0). The file
introduces two minimal `WebSocket` subclasses (ClosedStateSocket, ThrowingCloseSocket) used to
inject deterministic states into the internal `_clientSockets` map via the established
reflection helper pattern:
- `SendAsync_WithNonOpenSocket_ThrowsInvalidOperationException` — covers SendAsync not-open
  guard (lines 130-131).
- `BroadcastAsync_WithExceptAndNonOpenSockets_Completes` / `_WithOnlyNonOpenSocket_Completes` —
  covers the broadcast skip branches (153-154).
- `StopAsync_WithFailingSocket_ThrowsAndResetsState` — covers the StopAsync catch + state reset
  (245-248).
- `Dispose_WithFailingStop_SwallowsAndDisposesSockets` — covers the Dispose swallow block and
  per-socket Dispose loop (268-281).
- `AbortedClientHandshake_DoesNotBreakTransport` — loopback client closing before the handshake;
  exercises the accept loop and the non-websocket-request return path.

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 325-328 — HandleClientAsync catch: requires the stream read / handshake to throw (e.g. a TCP
  RST mid-handshake); ReadHttpHeaderAsync returns an empty header on clean close and the
  transport returns via the non-websocket-request path instead. Not deterministically reachable
  without real socket failure injection.
- 297 — AcceptConnectionsAsync closing-brace line (coverlet attribution artifact of the
  fire-and-forget `_ = HandleClientAsync(...)` continuation).

## Verification

- Targeted run: 6 passed / 0 failed (net8.0).
- Merged suite: 66 passed / 0 failed (net8.0, WebSocketNetworkTransport filter).
- Local coverlet: 164/169 = 97.0% line (was 88.8%).

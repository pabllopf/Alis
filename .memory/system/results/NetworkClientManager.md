# Result: NetworkClientManager.cs

File: `1_Presentation/Extension/Network/src/Client/NetworkClientManager.cs`
CoverageBefore: 83.7% (SonarCloud; Line: 82.2%, Branch: 88.2%, 38 uncovered lines)
CoverageAfter: 98.6% (422/428, local coverlet, full Network suite)
TestsAdded: 1 (NetworkClientManagerExecutionTests.cs: loopback WebSocket connection flow)
Commit: test: coverage NetworkClientManager.cs
Status: PARTIALLY_REMEDIATED

## Summary

NetworkClientManager.cs is the WebSocket client manager (54 complexity / 271 LOC). The
committed suite covered Initialize/Start/Stop/Disconnect/Send/Broadcast and validation paths;
ConnectAsync's entire connection flow (60+ lines: factory connect, local player creation,
receive-loop start, handshake envelope, Connected event) and the message-dispatch path of
ReceiveMessagesAsync were uncovered because they required a live WebSocket peer.

## Tests added (NetworkClientManagerExecutionTests.cs)

A loopback TCP server (TcpListener on 127.0.0.1:0) implementing the repo's handshake
convention: the client's WebSocketClientFactory computes the accept string with SHA512
(`HttpHelper.ComputeSocketAcceptString` deviates from the RFC — the server must mirror it),
so the server parses `Sec-WebSocket-Key`, replies 101 with the SHA512 accept, consumes the
client's masked handshake frame, sends a text frame with a serialized NetworkMessageEnvelope
(using extended 16-bit length framing for >125-byte payloads — the single-byte framing caused
the receive loop to stall), and echoes the close frame. The test registers a handler on the
envelope channel, connects via `NetworkClientManager.ConnectAsync("ws://127.0.0.1:port")`,
and asserts the server payload is dispatched.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

Dispose 445-451 (`catch (Exception) { /* swallow */ }` around `DisconnectAsync().Wait(5s)`):
DisconnectAsync can neither fault (its own catch swallows all exceptions) nor hang (the custom
WebSocket CloseAsync only sends the close frame and returns, and CancelAsync does not block),
so `.Wait(TimeSpan.FromSeconds(5))` can never throw TimeoutException or AggregateException.
Defensive catch, not coverable without production changes.

## Verification

- Full Network suite: 1100 passed / 0 failed (net8.0, ~3s).
- Local coverlet (valid run): NetworkClientManager.cs 422/428 = 98.6%; ConnectAsync 102/102,
  ReceiveMessagesAsync 54/54, all other state machines 100%.

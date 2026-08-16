# Project Coverage State

Project:
./1_Presentation/Extension/Network/src/Alis.Extension.Network.csproj

Test project:
./1_Presentation/Extension/Network/test/Alis.Extension.Network.Test.csproj

Status:
COMPLETED

Agent:
covertall-agent-001

Started:
2026-08-16T20:10:00Z

Last update:
2026-08-16T21:30:00Z

Initial coverage:
97.28% (4432/4556 lines in Network/src)

Current coverage:
97.28%

Tests before:
1106

Tests after:
1106

Files modified:
- none (investigation concluded remaining gaps are not meaningfully testable)

Coverage work:
- Measured baseline: 97.28%.
- Identified uncovered lines:
  - Events.cs (~36 WriteEvent bodies + manifest guard lines)
  - BufferPool.cs 108-110 (finalizer catch block)
  - WebSocketClientFactory.cs 273, 315-316 (TLS authentication paths)
  - WebSocketFrameReader.cs 131-135 (defensive InternalBufferOverflowException catch)
  - WebSocketImplementation.cs 545-548 (dispose-timeout catch)
  - WebSocketNetworkTransport.cs 297, 325-328 (private async accept/handle loops)
  - NetworkClientManager.cs 445-451 (dispose catch block)
- Investigated Events.cs deeply: wrote an EventListener-based test suite
  (EventsEnabledListenerTest + 20+ probes) to enable the EventSource and
  exercise the WriteEvent bodies.
- Root cause: the Events class passes enum values directly to WriteEvent
  (e.g. WriteEvent(24, guid, closeStatus, ...), WriteEvent(28, guid,
  webSocketOpCode, ...), WriteEvent(34, guid, webSocketState, ...)). When an
  EventSource declares such events, enabling it delivers only the manifest
  (EventId 0) and IsEnabled() stays false on this runtime, so the WriteEvent
  bodies can never execute. Verified with minimal standalone reproductions
  (a source with a plain Guid/string/int event works; adding an enum-direct
  WriteEvent breaks the whole source).
- Conclusion: Events.cs WriteEvent lines are not coverable without changing
  production code (converting enum args to strings before WriteEvent), which
  is out of scope for coverage remediation. All probe files removed.

Remaining opportunities:
- Events.cs WriteEvent bodies: blocked by runtime EventSource behavior with
  enum arguments; would require production change.
- TLS/network paths (WebSocketClientFactory, WebSocketNetworkTransport):
  require real sockets/TLS, unsuitable for unit tests.
- Defensive catch blocks and finalizers: low value, not meaningfully testable.

Last commit:
none (no test changes committed; investigation only)

Attempts:
1
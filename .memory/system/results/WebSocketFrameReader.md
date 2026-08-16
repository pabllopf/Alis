# Result: WebSocketFrameReader.cs

File: `1_Presentation/Extension/Network/src/Internal/WebSocketFrameReader.cs`
CoverageBefore: 88.7% (SonarCloud; Line: 88.5%, Branch: 90.0%, 13 uncovered lines)
CoverageAfter: 97.8% (221/226, local coverlet, full Network suite)
TestsAdded: 0 (existing suite covers every reachable line; remaining lines are defensive dead code)
Commit: test: coverage WebSocketFrameReader.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

WebSocketFrameReader.cs is the RFC6455 frame reader (19 complexity / 149 LOC). The committed
suite (WebSocketFrameReaderTest + the loopback/transport suites, 1100 tests total, 0 failed)
covers the class body (86/86), ReadFromCursorAsync (24/24), ReadLength (26/26),
ReadShortLength/ReadLongLength (2/2 each) and ReadAsync's payload/mask paths (76/81).

## Remaining uncovered lines (5) — BLOCKED_BY_PRODUCTION_CODE

- 131-135 — the `catch (InternalBufferOverflowException)` block in ReadAsync. Every
  `BinaryReaderWriter.ReadExactly` call in the method passes a length that is structurally
  ≤ the target buffer count: `minCount = CalculateNumBytesToRead(count, intoBuffer.Count)`
  caps to `bufferSize - bufferSize % 4` (< bufferSize), the 2-byte header read targets an
  8-byte scratch buffer, and the 4-byte mask-key read targets a 4-byte segment. With negative
  counts (huge 64-bit lengths) the underlying stream read throws ArgumentOutOfRangeException
  instead. Defensive catch, unreachable without production changes.

## Verification

- Full Network suite: 1100 passed / 0 failed (net8.0).
- Local coverlet (valid run): WebSocketFrameReader.cs 221/226 = 97.8% (before: 88.5% line).

# WebSocketFrameReader.cs

## Summary
- Status: COMPLETED
- CoverageBefore: 96.2% SonarCloud / 86.0% local
- CoverageAfter: 100.0% lines and branches (local coverlet)
- TestsAdded: WebSocketFrameReaderCoverageTest.cs (2 tests)

## Approach
The file had 5 uncovered lines (131-135): the `catch (InternalBufferOverflowException)` block in `ReadAsync` that rethrows with a descriptive message. The normal `ReadExactly` path guards against buffer overflow (minCount is always <= intoBuffer.Count), so the exception can only surface from a stream that signals it.

Added BufferOverflowInjectingStream and BufferOverflowInjectingStreamAfterBytes — Stream subclasses that yield their data first, then throw `InternalBufferOverflowException` on a subsequent read. Two tests drive `ReadAsync` (unmasked + masked payload paths) across the 5-line catch block.

## Verification
- Both new tests pass.
- Full project suite: 1115/1115 pass.
- coverage.cobertura.xml shows WebSocketFrameReader and all its state machines at line-rate=1, branch-rate=1.
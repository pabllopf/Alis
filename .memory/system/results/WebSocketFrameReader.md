# WebSocketFrameReader.cs

- **File**: `1_Presentation/Extension/Network/src/Internal/WebSocketFrameReader.cs`
- **Coverage Before**: 91.2% (local) / 96.2% (SonarCloud)
- **Coverage After**: 95.6% (local, max testable)
- **Tests Added**: 3
- **Uncovered Lines**: `InternalBufferOverflowException` catch (131-135) — unreachable (`CalculateNumBytesToRead` guarantees minCount ≤ buffer)
- **Status**: COMPLETED

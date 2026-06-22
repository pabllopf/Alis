---
status: Completed
---

# COVERAGE TASK

## File
1_Presentation/Extension/Network/src/HttpHelper.cs

## Coverage
93.1% (5 uncovered lines, 2 uncovered conditions)

## Uncovered Lines/Conditions Targeted
- ReadHttpHeaderAsync while loop exit without header terminator (return empty)
- GetSubProtocols oversized Sec-WebSocket-Protocol throws EntityTooLargeException
- IsWebSocketUpgradeRequest non-GET method returns false

## Existing Tests
HttpHelperTest.cs (18 tests)

## Tests Added
3 tests:
1. ReadHttpHeaderAsync_WithoutTerminator_ReturnsEmpty
2. GetSubProtocols_WithOversizedProtocol_ThrowsEntityTooLargeException
3. IsWebSocketUpgradeRequest_WithNonGetMethod_ReturnsFalse

## Production Changes
None required

## Status
Completed — 3 tests covering edge cases. Commit: 000b8b194

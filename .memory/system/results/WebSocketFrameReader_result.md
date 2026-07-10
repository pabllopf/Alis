# WebSocketFrameReader.cs Coverage Report

## File
`1_Presentation/Extension/Network/src/Internal/WebSocketFrameReader.cs`

## Coverage Summary
- **Coverage Before**: 69.2%
- **Coverage After**: ~82%
- **Tests Added**: 6

## Tests Added

| Test Method | Description |
|---|---|
| `ReadFromCursorAsync_WithMaskKey_AppliesMask` | Covers mask application path in `ReadFromCursorAsync` when cursor frame has non-empty `MaskKey` |
| `ReadAsync_MaskedFrame_ReadsCorrectly` | Covers the masked frame path in `ReadAsync` (isMaskBitSet = true, ToggleMask call) |
| `ReadAsync_ConnectionCloseFrame_ReturnsDecodedFrame` | Covers `ReadAsync` path through `DecodeCloseFrame` with valid close status |
| `DecodeCloseFrame_WithUndefinedCloseStatus_ReturnsEmptyStatus` | Covers `Enum.IsDefined` false branch in `DecodeCloseFrame` |
| `DecodeCloseFrame_WithDescription_ReturnsDescription` | Covers `descCount > 0` branch and valid status in `DecodeCloseFrame` |
| `ReadAsync_ConnectionCloseFrameWithDescription_ReturnsDecodedFrame` | Covers full `ReadAsync`→`DecodeCloseFrame` path with both status and description |

## Branches Covered
1. `ReadFromCursorAsync`: `remainingFrame.MaskKey.Count > 0` → true
2. `ReadAsync`: `isMaskBitSet` → true
3. `ReadAsync`: `opCode == WebSocketOpCode.ConnectionClose` → true
4. `DecodeCloseFrame`: `Enum.IsDefined(...)` → true
5. `DecodeCloseFrame`: `descCount > 0` → true

## Remaining Uncovered
- `catch (InternalBufferOverflowException)` block (lines 131-136) — appears unreachable under current `CalculateNumBytesToRead` logic

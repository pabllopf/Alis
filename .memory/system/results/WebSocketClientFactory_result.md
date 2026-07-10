# WebSocketClientFactory.cs - Coverage Results

## Summary
- **File**: `1_Presentation/Extension/Network/src/WebSocketClientFactory.cs`
- **Coverage Before**: 55.4%
- **Coverage After**: ~78.5% (estimated)
- **Tests Added**: 24
- **Status**: ✅ Completed

## Tests Added
| Test Method | Type | Lines Covered |
|---|---|---|
| Constructor_WithBufferFactory_SetsBufferFactory | Instance | 85 |
| Constructor_WithBufferFactory_Dispose_DoesNotThrow | Instance | 85, 90-94 |
| Dispose_DefaultConstructor_DoesNotThrow | Instance | 90-94, 100-106 |
| Dispose_MultipleCalls_DoesNotThrow | Instance | 90-94, 100-106 |
| Dispose_WithBufferFactory_DoesNotThrow | Instance | 85, 90-94, 100-106 |
| GetSubProtocolFromHeader_WithProtocol_ReturnsProtocol | Static | 199-202 |
| GetSubProtocolFromHeader_WithProtocolTrailingSpaces_ReturnsTrimmed | Static | 199-202 |
| GetSubProtocolFromHeader_WithMultipleProtocols_ReturnsFirst | Static | 199-202 |
| ThrowIfInvalidAcceptString_InvalidAccept_Throws | Static | 215-226 |
| ThrowIfInvalidAcceptString_EmptyAccept_Throws | Static | 215-226 |
| ThrowIfInvalidResponseCode_Non101WithBody_ThrowsWithDetails | Static | 249-260 |
| ThrowIfInvalidResponseCode_Non101WithMultipleBodyLines | Static | 249-261 |
| ValidateServerCertificate_NoErrors_ReturnsTrue | Static | 330-333 |
| ValidateServerCertificate_RemoteCertificateNotAvailable_ReturnsFalse | Static | 335-337 |
| ValidateServerCertificate_RemoteCertificateNameMismatch_ReturnsFalse | Static | 335-337 |
| ValidateServerCertificate_RemoteCertificateChainErrors_ReturnsFalse | Static | 335-337 |
| BuildHandshakeRequest_WithProtocol_IncludesProtocol | Static | 401-409 |
| BuildHandshakeRequest_WithAdditionalHeaders_IncludesHeaders | Static | 401-409 |
| BuildHandshakeRequest_WithProtocolAndHeaders_IncludesBoth | Static | 401-409 |
| ConnectAsync_StreamOverload_WithValidResponse | Instance | 148-154 |
| ConnectAsync_StreamOverload_WithSubProtocol | Instance | 148-154 |
| ConnectAsync_WithSubProtocol | Instance | 168-189 |
| ConnectAsync_WithIncludeExceptionAndExtensions | Instance | 168-189 |
| ConnectAsync_StreamOverload_IncludeExceptionInCloseResponse | Instance | 148-154 |

## Branches Covered
- Constructor `WebSocketClientFactory(Func<MemoryStream>)` 
- `Dispose()` → `Dispose(bool)`
- `Dispose(bool disposing=true)` → `TcpClient?.Dispose()`
- `GetSubProtocolFromHeader` → match.Success=true path
- `ThrowIfInvalidAcceptString` → invalid/empty accept (exception)
- `ThrowIfInvalidResponseCode` → non-101 with body content (builder path)
- `ValidateServerCertificate` → `SslPolicyErrors.None` and error paths
- `BuildHandshakeRequest` → with protocol and additional headers
- `ConnectAsync(Stream, ...)` → public overload with various options

## COVERAGE TASK

### File
1_Presentation/Extension/Network/src/Core/WebSocketNetworkTransport.cs

### Coverage
29.4%

### Uncovered Lines
117 UL

### Method
Various public methods: StartAsync, StopAsync, Dispose, SendAsync, BroadcastAsync, ReceiveAsync

### Existing Tests
- WebSocketNetworkTransportTest.cs (constructor, state, basic error paths)
- WebSocketNetworkTransportRemainingCoverageTests.cs (StartAsync success, StopAsync, BroadcastAsync with exceptClientId)

### Source Code
```csharp
public sealed class WebSocketNetworkTransport : INetworkTransport
{
    // Constructor, SendAsync, BroadcastAsync, ReceiveAsync, StartAsync, StopAsync, Dispose
    // Private: AcceptConnectionsAsync, HandleClientAsync, ReceiveFromClientAsync
}
```

### Target Uncovered Paths
1. StartAsync exception path - catch block (line 206-209) when IPAddress.Parse or TcpListener.Start fails
2. Dispose exception swallowing - catch block (line 268-274) when StopAsync times out
3. BroadcastAsync with empty task list (all clients filtered out)
4. Constructor edge cases (various URI formats)
5. ReceiveAsync while-loop with cancelled token (already partially tested)

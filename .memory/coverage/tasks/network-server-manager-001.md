## COVERAGE TASK

### File
1_Presentation/Extension/Network/src/Server/NetworkServerManager.cs

### Coverage
61.1%

### Uncovered Lines
90 UL

### Method
Various public methods: Constructor, InitializeAsync, StartAsync, StopAsync, ListenAsync, StopListeningAsync, CreateSessionAsync, GetSession, GetActiveSessions, CloseSessionAsync, KickPlayerAsync, SendMessageAsync, BroadcastMessageAsync, RegisterPlayerInSession, Dispose

### Existing Tests
- NetworkServerManagerTest.cs (constructor, initialization, session management, player management, disposal)

### Source Code
```csharp
public sealed class NetworkServerManager : INetworkServerManager
{
    // Constructor, properties, events, InitializeAsync, StartAsync, StopAsync
    // ListenAsync, StopListeningAsync, CreateSessionAsync, GetSession, GetActiveSessions
    // CloseSessionAsync, KickPlayerAsync, SendMessageAsync, BroadcastMessageAsync
    // RegisterMessageHandler, UnregisterMessageHandler, RegisterPlayerInSession
    // GetConnectedPlayers, GetPlayer, Dispose
    // Private: ProcessMessagesAsync
}
```

### Target Uncovered Paths
1. ListenAsync exception path → Error state
2. StopListeningAsync early returns (Uninitialized, Disconnected)
3. StopListeningAsync from Idle state
4. CloseSessionAsync non-existent session
5. KickPlayerAsync non-existent session/player
6. RegisterPlayerInSession without session, duplicate detection
7. GetPlayer/GetConnectedPlayers with null session
8. Dispose after Listen failure

---
title: Alis.Extension.Network
tags: [presentation,application,extension,documentation]
---


## Overview

The **Alis.Extension.Network** project provides a complete WebSocket-based networking solution for ALIS games, supporting multiplayer connectivity, client-server communication, and real-time data exchange.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 53 source files

## Purpose

This extension enables real-time multiplayer functionality through WebSocket protocol implementation, providing both client and server capabilities with automatic reconnection, ping/pong management, and message serialization.

## Architecture

### Design Pattern

Implements **Manager Pattern** for network management:

```csharp
public class NetworkServerManager : AManager, INetworkServerManager
public class NetworkClientManager : AManager, INetworkClientManager
```

### WebSocket Implementation

Complete WebSocket protocol implementation including:

- **WebSocketFrame** - Frame encoding/decoding
- **WebSocketHandshake** - HTTP upgrade to WebSocket
- **PingPongManager** - Connection keep-alive
- **BinaryReaderWriter** - Efficient binary I/O

### Layered Architecture

```
┌─────────────────────────────────────┐
│         Application Layer           │
│  (NetworkManager, SessionManager)   │
├─────────────────────────────────────┤
│         Message Layer               │
│  (NetworkMessageEnvelope, Serializer)│
├─────────────────────────────────────┤
│        Transport Layer              │
│  (WebSocketNetworkTransport)        │
├─────────────────────────────────────┤
│      WebSocket Protocol Layer       │
│  (FrameReader, FrameWriter)         │
└─────────────────────────────────────┘
```

## Components

### Core Managers

| Class | Description | Type |
|-------|-------------|------|
| `NetworkServerManager` | Server-side connection management | Manager |
| `NetworkClientManager` | Client-side connection management | Manager |
| `INetworkServerManager` | Server interface | Interface |
| `INetworkClientManager` | Client interface | Interface |

### Transport Layer

| Class | Description |
|-------|-------------|
| `WebSocketNetworkTransport` | WebSocket protocol implementation |
| `INetworkTransport` | Transport interface |
| `WebSocketServerFactory` | Server factory |
| `WebSocketClientFactory` | Client factory |

### Message System

| Class | Description |
|-------|-------------|
| `NetworkMessageEnvelope` | Message wrapper with metadata |
| `NetworkSerializer` | JSON message serialization |
| `INetworkSerializer` | Serializer interface |

### Connection Management

| Class | Description |
|-------|-------------|
| `NetworkSession` | Active session state |
| `NetworkPlayer` | Player connection info |
| `PlayerConnectionState` | Connection state enum |

### Event System

| Event | Description |
|-------|-------------|
| `OnClientConnected` | New client connected |
| `OnClientDisconnected` | Client disconnected |
| `OnMessageReceived` | Message received |
| `OnServerMessage` | Server broadcast |

## Public API

### Server Setup

```csharp
var serverManager = new NetworkServerManager(context);
var config = new NetworkConfig
{
    Port = 8080,
    MaxConnections = 100,
    EnableCompression = true
};

await serverManager.StartAsync(config);
```

### Client Connection

```csharp
var clientManager = new NetworkClientManager(context);
await clientManager.ConnectAsync("ws://localhost:8080");

// Send message
var message = new NetworkMessageEnvelope
{
    Type = "chat",
    Payload = "Hello, world!"
};

await clientManager.SendAsync(message);
```

### Event Handlers

```csharp
serverManager.OnClientConnected += (sender, args) => 
{
    Logger.Info($"Player {args.Player.Name} connected");
};

serverManager.OnMessageReceived += (sender, args) => 
{
    // Handle incoming message
    ProcessMessage(args.Message);
};

clientManager.OnDisconnected += (sender, args) => 
{
    Logger.Warning("Connection lost");
};
```

### Ping/Pong Management

```csharp
var pingManager = new PingPongManager();
pingManager.KeepAliveInterval = 30000; // 30 seconds

await pingManager.StartAsync(client);
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**Internal Dependencies**:
- `Alis.Core.Aspect.Logging` - Logging aspect
- `Alis.Core.Ecs.Systems.Manager` - Manager base class

**External Dependencies**:
- `System.Net.WebSockets` - Built-in WebSocket support

## Features

### Core Features

1. **WebSocket Protocol** - Full RFC 6455 implementation
2. **Binary Messages** - Efficient binary data transfer
3. **Text Messages** - UTF-8 text support
4. **Ping/Pong** - Automatic connection keep-alive
5. **Reconnection** - Automatic reconnection on disconnect
6. **Message Serialization** - JSON-based serialization

### Advanced Features

1. **Compression** - Permessage-deflate support
2. **Binary Pooling** - Buffer pooling for performance
3. **Event System** - Comprehensive event callbacks
4. **Error Handling** - Robust error recovery

## Usage Example

```csharp
// Server setup
var server = new NetworkServerManager(gameContext);
var config = new NetworkConfig
{
    Port = 9000,
    MaxConnections = 50,
    EnableCompression = true,
    KeepAliveInterval = 30000
};

await server.StartAsync(config);

server.OnClientConnected += (sender, args) => 
{
    Logger.Info($"Player {args.Player.Id} connected");
};

server.OnMessageReceived += async (sender, args) => 
{
    var message = args.Message.Deserialize<ChatMessage>();
    await BroadcastAsync(new ChatMessage 
    { 
        Player = args.Player.Name, 
        Text = message.Text 
    });
};

// Client connection
var client = new NetworkClientManager(gameContext);
await client.ConnectAsync("ws://localhost:9000");

client.OnMessageReceived += (sender, args) => 
{
    var chat = args.Message.Deserialize<ChatMessage>();
    DisplayChatMessage(chat.Player, chat.Text);
};

// Send chat message
var chatMsg = new ChatMessage { Text = "Hello everyone!" };
await client.SendAsync(new NetworkMessageEnvelope 
{ 
    Type = "chat", 
    Payload = chatMsg.Serialize() 
});
```

## Testing

**Test Project**: `Alis.Extension.Network.Test`  
**Sample Projects**: 
- ConsoleGame (multiplayer)
- SimpleChat (chat application)

## Security Considerations

⚠️ **Connection Limits**:
- Set `MaxConnections` to prevent DoS
- Implement authentication for production

⚠️ **Message Validation**:
- Validate all incoming messages
- Sanitize user input

⚠️ **TLS/SSL**:
- Use `wss://` for production
- Implement certificate validation

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | ✓ Unit tests exist |
| Samples | ✓ Multiple samples available |

## Related Projects

- [[projects/1_Presentation/Alis.Extension.Security]] - Secure data handling
- [[Alis.Core.Ecs]] - ECS engine
- [[Alis.Extension.Cloud]] - Cloud storage

## TODO

- [ ] Add integration tests with real WebSocket servers
- [ ] Implement message encryption
- [ ] Add support for binary protocols (Protobuf, MessagePack)
- [ ] Create multiplayer game sample

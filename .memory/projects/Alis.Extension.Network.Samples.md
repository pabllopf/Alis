---
title: Alis.Extension.Network Samples
tags:
  - network
  - samples
  - websocket
  - multiplayer
status: Draft
license: GPLv3
---

# Alis.Extension.Network Samples

## Overview

Six sample projects demonstrating the [[Alis.Extension.Network]] library in client-server configurations.

## SimpleChat

Minimal WebSocket chat demonstration.

### Client (`Alis.Extension.Network.Sample.SimpleChat.Client`)
- **Files**: `Program.cs`, `ChatMessage.cs`, `GameMessage.cs`
- Connects to server, sends/receives `ChatMessage` objects wrapped in `GameMessage`

### Server (`Alis.Extension.Network.Sample.SimpleChat.Server`)
- **Files**: `Program.cs`, `ChatMessage.cs`
- Echo server - broadcasts received messages to all connected clients

## SimpleGame

Multiplayer game framework template.

### Client (`Alis.Extension.Network.Sample.SimpleGame.Client`)
- **Files**: `Program.cs`, `GameEvent.cs`, `Arena.cs`, `MoveSystem.cs`, `PlayerData.cs`, `GameMessage.cs`, `GameState.cs`, `CombatSystem.cs`, `ConsoleRenderer.cs`
- Full multiplayer game client with console-based rendering

### Server (`Alis.Extension.Network.Sample.SimpleGame.Server`)
- **Files**: `Program.cs`, `GameEvent.cs`, `Arena.cs`, `MoveSystem.cs`, `PlayerData.cs`, `GameMessage.cs`, `GameState.cs`, `CombatSystem.cs`
- Server-side game logic (no renderer)

## ConsoleGame

Console-based multiplayer arena game.

### Client (`Alis.Extension.Network.Sample.ConsoleGame.Client`)
- **Files**: Same structure as SimpleGame client
- Arena combat with console rendering

### Server (`Alis.Extension.Network.Sample.ConsoleGame.Server`)
- **Files**: Same structure as SimpleGame server
- Server-side combat and game state management

## Architecture Pattern

All samples follow a shared protocol:
- `GameMessage` - Message envelope
- `GameEvent` - Event type definitions
- `GameState` - State synchronization
- `PlayerData` - Player information
- `Arena` - Game world container
- `MoveSystem` / `CombatSystem` - Game logic systems

## Related

- [[Alis.Extension.Network]]
- [[Samples Index]]
- [[Projects Index]]

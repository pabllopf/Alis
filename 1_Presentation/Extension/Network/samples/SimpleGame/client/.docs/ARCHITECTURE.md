# SimpleGame - Client Architecture Documentation

## Overview

The SimpleGame client is a console-based multiplayer game client that connects to a WebSocket server. It handles rendering, input processing, and local game state synchronization with the authoritative server.

## Architecture Diagram

```
┌─────────────────────────────────────────────────┐
│         Console Input Handler                   │
│  (Parses commands: /move, /attack, /spawn, etc) │
└────────────────────┬────────────────────────────┘
                     │
         ┌───────────▼────────────┐
         │   Command Validation   │
         │  (MoveSystem validates)│
         └───────────┬────────────┘
                     │
         ┌───────────▼─────────────────┐
         │  NetworkClientManager       │
         │  (WebSocket connection)     │
         │  Sends: GameMessage (JSON)  │
         └───────────┬─────────────────┘
                     │
              ╭──────▼──────╮
              │  Server     │
              │  (Process)  │
              ╰──────┬──────╯
                     │
         ┌───────────▼─────────────────┐
         │  Message Handlers           │
         │  - OnGameUpdate()           │
         │  - OnGameEvent()            │
         │  - OnGameChat()             │
         └───────────┬─────────────────┘
                     │
         ┌───────────▼────────────┐
         │    GameState (Local)   │
         │  Players Dictionary    │
         │  Event Log             │
         └───────────┬────────────┘
                     │
         ┌───────────▼─────────────────┐
         │   ConsoleRenderer           │
         │  (Smart rendering)          │
         │  Only refreshes on change   │
         └───────────┬─────────────────┘
                     │
         ┌───────────▼────────────┐
         │   Console Display       │
         │  (800x600 optimized)   │
         └────────────────────────┘
```

## Core Components

### 1. Program.cs - Main Game Loop

**Responsibilities:**
- Initialize network client
- Register event handlers and message handlers
- Main game loop for input processing
- Render loop management
- Connection handling

**Key Methods:**

```csharp
Main(args)
  └─ Initializes everything
     ├─ Creates GameState
     ├─ Initializes NetworkClientManager
     ├─ Connects to ws://127.0.0.1:8889/
     ├─ Starts RenderLoopAsync()
     └─ Runs GameLoopAsync()

RenderLoopAsync()
  └─ Smart rendering loop (only updates on state change)
     ├─ Runs every 100ms
     ├─ Checks _needsRender flag
     ├─ Renders every 5 frames (~500ms) minimum
     └─ Calls ConsoleRenderer.Render()

GameLoopAsync()
  └─ Main input loop
     ├─ Waits for user command
     ├─ Parses command
     ├─ Validates locally (MoveSystem)
     ├─ Sends to server via NetworkClientManager
     └─ Repeats
```

**Key Variables:**

```csharp
_clientManager         // WebSocket connection manager
_gameState            // Local copy of game state
_playerId             // This client's player ID
_playerName           // This client's player name
_connected            // Connection flag
_renderer             // Console UI renderer
_needsRender          // Flag to trigger screen refresh
_renderRunning        // Render loop running flag
```

### 2. GameState.cs - Local Game State

**Responsibilities:**
- Store local player and other players' data
- Maintain arena information
- Keep event log for display

**Key Classes:**

```csharp
GameState
  ├─ Arena (Width: 40, Height: 25)
  ├─ Players: Dictionary<string, PlayerData>
  ├─ LocalPlayerId: string
  └─ EventLog: List<GameEvent>

PlayerData
  ├─ PlayerId, PlayerName
  ├─ X, Y (position)
  ├─ Health, MaxHealth
  ├─ Level, Experience
  ├─ Score, Kills, Deaths
  ├─ IsAlive
  └─ LastActionTime

GameEvent
  ├─ Timestamp
  ├─ EventType (join, leave, move, attack, etc)
  ├─ Description
  ├─ SourcePlayer, TargetPlayer
  └─ Data (optional metadata)

Arena
  ├─ Width: 40 (cells)
  ├─ Height: 25 (cells)
  └─ OccupancyMap (sparse grid)
```

### 3. ConsoleRenderer.cs - Smart Console UI

**Responsibilities:**
- Render compact game display for 800x600
- Show player stats
- Display arena minimap
- Show event log and player list

**Key Features:**

```
Compact Display (30x12 arena representation):
┌────────────────────────────────────┐
│ ●○.○.○.○.○.○.○.○.○.○.○.○.○.○.│
│ .○...○.●.○.○.○.○.○.○.○.○.○.○.│
│ ○.○.○.○.○.○.○.●.○.○.○.○.○.○.○│
│ ......................●...○...│
│ ○.○.○.○.○.○.○.○.○.○.○.○.○.○.│
│ .●.○.○.○.○.○.○.○.○.○.○.○.○.○│
│ ○.○.○.○.○.○.○.○.○.○.●.○.○.○.│
│ .○.○.○.○.○.○.○.○.○.○.○.○.○.○│
│ ○.○.●.○.○.○.○.○.○.○.○.○.○.○.│
│ .○.○.○.○.○.○.○.○.●.○.○.○.○.○│
│ ○.○.○.○.○.○.○.○.○.○.○.○.●.○.│
│ .○.○.○.○.○.○.○.○.○.○.○.○.○.│
└────────────────────────────────────┘

[Alice] HP:████████░░ Lvl:2 Score:45 Kills:1 Pos:(20,12)

Players: ✓ Alice:45 | ✓ Bob:15 | ✕ Charlie:0 | ✓ Diana:32 | ✓ Eve:28

Events: Alice attacked Bob for 12 damage > Bob moved to (25,15) > Diana joined!

Commands: /move X Y | /attack NAME | /spawn | /chat MSG | /stats | /help | /quit
```

**Key Methods:**

```csharp
Render()
  └─ Called from RenderLoopAsync (smart trigger)
     ├─ Console.Clear()
     ├─ DrawArena()          // 30x12 compact display
     ├─ DrawLocalStats()     // Current player info
     ├─ DrawPlayerList()     // Top 5 players by score
     ├─ DrawEvents()         // Last 3 events
     └─ DrawCommands()       // Available commands

GetSmallHealthBar(current, max)
  └─ Returns "████░░░░" style bar (8 chars)

GetHealthBar(current, max)
  └─ Returns "████████████░░░░░░░░" style bar (20 chars)
```

### 4. GameSystems.cs - Client-Side Validation

**Responsibilities:**
- Validate moves before sending to server
- Calculate combat (for preview purposes)
- Prevent obviously invalid commands

**Key Classes:**

```csharp
MoveSystem
  ├─ IsValidMove(x, y)        // Check arena bounds
  │   └─ Returns: x [0-39], y [0-24]
  └─ GetDistance(x1,y1, x2,y2) // Euclidean distance

CombatSystem
  ├─ CalculateDamage(attacker, defender)
  │   ├─ Range check: distance <= 10
  │   ├─ Level scaling: damage = 10 + (level × 2)
  │   └─ Critical: 20% chance × 1.5 multiplier
  └─ GetExperienceReward(defenderLevel)
      └─ XP = max(10, 50 × level / 10)
```

## Command Parsing and Execution Flow

### User Input Processing

```
User Input: "/move 25 15"
    │
    ├─ Parser splits by spaces
    │   └─ Command: "/move"
    │   └─ Args: ["25", "15"]
    │
    ├─ Validate locally
    │   ├─ IsValidMove(25, 15) ✓
    │   └─ Player is alive ✓
    │
    ├─ Update local state (optimistic)
    │   └─ _gameState.Players[_playerId].X = 25
    │   └─ _gameState.Players[_playerId].Y = 15
    │
    ├─ Create GameMessage
    │   ├─ MessageType: "move"
    │   └─ Content: "25,15"
    │
    ├─ Serialize to JSON
    │   └─ {"MessageType":"move","Content":"25,15"}
    │
    └─ Send via NetworkClientManager.BroadcastMessageAsync()
        └─ WebSocket message to server
```

### Available Commands

| Command | Usage | Purpose |
|---------|-------|---------|
| `/move` | `/move X Y` | Move to coordinates (0-39, 0-24) |
| `/attack` | `/attack NAME` | Attack target player by name |
| `/spawn` | `/spawn` | Respawn if dead |
| `/chat` | `/chat MESSAGE` | Send message to all players |
| `/stats` | `/stats` | Show your detailed stats |
| `/players` | `/players` | List all connected players |
| `/help` | `/help` | Show available commands |
| `/quit` | `/quit` | Disconnect and exit |

## Event System

### Event Handlers

The client registers handlers for network messages:

```csharp
RegisterHandlers()
  ├─ "game.update"  → OnGameUpdate()      // State sync
  ├─ "game.move"    → OnGameEvent()       // Movement events
  ├─ "game.attack"  → OnGameEvent()       // Combat events
  ├─ "game.spawn"   → OnGameEvent()       // Respawn events
  └─ "game.chat"    → OnGameChat()        // Chat messages

RegisterEvents()
  ├─ PlayerJoined   → Add to PlayerData dict
  ├─ PlayerLeft     → Remove from PlayerData dict
  ├─ Connected      → Log connection
  ├─ Disconnected   → Set _connected = false
  └─ Error          → Log error message
```

### Event Processing

```
Server sends: game.attack message
    │
    ├─ Deserialize from JSON
    │
    ├─ Call OnGameEvent(senderId, payload)
    │   ├─ Parse event details
    │   ├─ Add to GameState.EventLog
    │   └─ TriggerRender()  // Set _needsRender = true
    │
    └─ Render loop detects _needsRender = true
        └─ Next iteration: calls ConsoleRenderer.Render()
```

## Smart Rendering System

### Rendering Optimization

The client uses a smart rendering system to avoid flickering and allow command input:

```
RenderLoopAsync() runs every 100ms
    │
    ├─ Check _needsRender flag
    │   ├─ True:  Render immediately
    │   └─ False: Check frame counter
    │
    ├─ If frameCounter % 5 == 0 (every 500ms)
    │   └─ Render anyway (periodic update)
    │
    └─ Reset _needsRender = false
       (will be set by event handlers)
```

### When Rendering Triggers

```
_needsRender = true when:
  ├─ Player joins game
  ├─ Player leaves game
  ├─ Game state updates (positions, health, etc)
  ├─ Event occurs (attack, chat, spawn)
  └─ Every 500ms (periodic refresh)

_needsRender = false when:
  └─ Just rendered
```

### Advantages

- **No Flickering**: Only refreshes when needed
- **Readable Input**: Users can type commands without screen clearing
- **Responsive**: State changes show immediately
- **Efficient**: Reduced CPU usage and bandwidth
- **Responsive**: Periodic refresh ensures UI stays current

## Network Communication

### Message Format (JSON)

```json
{
  "MessageType": "move",
  "Content": "25,15"
}
```

### Message Flow

```
Client                          Server
   │                              │
   ├─ Create GameMessage          │
   ├─ Serialize to JSON           │
   ├─ Send via WebSocket ────────►│
   │                              │ Receives
   │                              ├─ Deserialize
   │                              ├─ Validate
   │                              ├─ Process
   │                              ├─ Update state
   │                              └─ Queue event
   │                              │
   │◄───────── Broadcast ─────────┤
   ├─ Receive update              │
   ├─ Deserialize                 │
   ├─ Update local GameState      │
   ├─ Add to EventLog             │
   └─ TriggerRender()             │
```

## Game State Synchronization

### Full State Update (Every ~167ms)

Server broadcasts complete game state:

```
Server sends to Client:
{
  MessageType: "state",
  Content: "
    alice:x:20|alice:y:12|alice:health:90|alice:score:45|alice:alive:true|
    bob:x:25|bob:y:15|bob:health:100|bob:score:10|bob:alive:true|
    ...
  "
}

Client receives and parses:
  ├─ Parse each field
  ├─ Update corresponding PlayerData
  ├─ Track if state changed
  └─ If changed: TriggerRender()
```

### Event-Based Updates (Immediate)

Server broadcasts game events immediately:

```
Server sends to Client:
{
  MessageType: "attack",
  Content: "attack|alice|bob|Alice attacked Bob for 12 damage!"
}

Client receives and parses:
  ├─ Add to EventLog
  ├─ Update stats if applicable
  └─ TriggerRender()
```

## Error Handling

### Connection Errors

```
Connection Lost
    │
    ├─ Disconnected event triggered
    │   ├─ Set _connected = false
    │   ├─ Log: "✗ Disconnected from game"
    │   └─ Exit GameLoopAsync()
    │
    └─ Shutdown
        ├─ Stop RenderLoopAsync()
        ├─ Disconnect from server
        └─ Exit program
```

### Validation Errors

```
Invalid Command (e.g., /move 50 50)
    │
    ├─ Client-side MoveSystem validation fails
    │   └─ Logger.Error("✗ Invalid coordinates!")
    │
    └─ Message not sent to server
        └─ No state change
```

### Server Rejection

```
Server rejects action (already handled server-side)
    │
    ├─ Server doesn't broadcast event
    │
    └─ Client state remains unchanged
```

## Performance Considerations

### Rendering Performance
- Compact display: 30x12 arena (vs original 40x25)
- Console.Clear() only when needed
- Smart render triggering avoids flicker
- ~15-20 lines of output per frame

### Network Performance
- JSON serialization/deserialization
- WebSocket binary transport
- Message batching via queues
- Typical bandwidth: ~1KB per state update

### Memory Usage
- GameState: ~1-2 KB per player
- EventLog: ~100 events × 200 bytes = 20 KB
- Typical: 8 players = ~20 KB + 20 KB = 40 KB

## Testing Recommendations

### Unit Tests

```csharp
TestMoveValidation()
  ├─ IsValidMove(0, 0) == true
  ├─ IsValidMove(39, 24) == true
  ├─ IsValidMove(40, 25) == false
  └─ IsValidMove(-1, -1) == false

TestDistanceCalculation()
  ├─ Distance(0,0 to 3,4) == 5
  └─ Distance(0,0 to 0,0) == 0

TestGameStateUpdate()
  ├─ PlayerData updates correctly
  ├─ EventLog maintains 100 item limit
  └─ Players dict handles additions/removals
```

### Integration Tests

```csharp
TestClientServerConnection()
  ├─ Connect to server
  ├─ Receive player joined event
  └─ Disconnect gracefully

TestMoveSync()
  ├─ Send /move command
  ├─ Receive state update
  └─ Verify position changed

TestCombat()
  ├─ Send /attack command
  ├─ Receive attack event
  ├─ Verify HP changed
  └─ Verify score updated
```

## Future Improvements

1. **Colored Output**: ANSI colors for better visuals
2. **Animations**: Smooth transitions for movement
3. **Sound Effects**: Optional beeps for events
4. **Persistence**: Save player stats
5. **Hotkeys**: Number keys for quick commands
6. **Minimap**: Separate window showing full arena
7. **Lag Compensation**: Client-side prediction
8. **Better Fonts**: Unicode box drawing characters

## Conclusion

The SimpleGame client demonstrates:
- Efficient state management
- Smart UI rendering
- Robust network communication
- Clean separation of concerns
- Responsive user experience

The architecture is scalable and can be extended with new features while maintaining code clarity and performance.


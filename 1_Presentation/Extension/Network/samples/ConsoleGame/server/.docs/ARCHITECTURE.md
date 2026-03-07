# SimpleGame - Server Architecture Documentation

## Overview

The SimpleGame server is an authoritative WebSocket game server that manages all game logic, validates player actions, maintains the single source of truth, and broadcasts state updates to connected clients.

## Architecture Diagram

```
┌──────────────────────────────────────────────┐
│  NetworkServerManager                        │
│  (WebSocket Server on ws://127.0.0.1:8889/) │
└────────────────┬─────────────────────────────┘
                 │
    ┌────────────┼────────────┐
    │            │            │
┌───▼──┐    ┌───▼──┐    ┌───▼──┐
│Client│    │Client│    │Client│
│  1   │    │  2   │    │  3   │
└───┬──┘    └───┬──┘    └───┬──┘
    │           │           │
    └───────────┼───────────┘
                │
    ┌───────────▼────────────┐
    │   Message Handlers     │
    │ - OnPlayerMove()       │
    │ - OnPlayerAttack()     │
    │ - OnPlayerSpawn()      │
    │ - OnGameChat()         │
    └───────────┬────────────┘
                │
    ┌───────────▼──────────────────┐
    │  GameState (Authoritative)   │
    │  - Players Dictionary        │
    │  - Arena Info                │
    │  - Event Queue               ���
    │  - Current Tick              │
    └───────────┬──────────────────┘
                │
    ┌───────────▼────────────┐
    │   GameSystems          │
    │ - MoveSystem           │
    │ - CombatSystem         │
    └───────────┬────────────┘
                │
    ┌───────────▼──────────────┐
    │  Game Tick Loop          │
    │  (30 ticks/second)       │
    │  - Process events        │
    │  - Apply game logic      │
    │  - Broadcast state       │
    └───────────┬──────────────┘
                │
    ┌───────────▼─────────────┐
    │   Broadcast Manager     │
    │ - Send state updates    │
    │ - Send events to all    │
    └───────────┬─────────────┘
                │
    └───────────►Server sends to all clients
```

## Core Components

### 1. Program.cs - Server Entry Point

**Responsibilities:**
- Initialize server infrastructure
- Create game session
- Manage server mode (pure server vs player+server)
- Run tick loop (game update cycle)
- Handle admin commands

**Key Methods:**

```csharp
Main(args)
  └─ Server initialization
     ├─ Ask: "Pure server or player+server? (s/p)"
     ├─ Initialize NetworkServerManager
     ├─ Create GameState
     ├─ If player+server: Add server player
     ├─ Create game session
     ├─ Register handlers and events
     ├─ Start listening on ws://127.0.0.1:8889/
     ├─ Start GameTickLoopAsync()
     └─ Run CommandLoopAsync()

GameTickLoopAsync()
  └─ Game update loop (30 Hz = 33.3ms per tick)
     ├─ Increment tick counter
     ├─ Process queued events
     ├─ Apply game logic (each 5 ticks):
     │  ├─ ProcessMove()
     │  ├─ ProcessAttack()
     │  └─ ProcessSpawn()
     ├─ Every 5 ticks (every ~167ms):
     │  ├─ BroadcastGameStateAsync()
     │  └─ BroadcastGameEventAsync()
     └─ Sleep remaining time

CommandLoopAsync()
  └─ Admin command processing
     ├─ Waits for user input
     ├─ Parses command
     ├─ Executes:
     │  ├─ /players  → List connected players
     │  ├─ /status   → Show server status
     │  ├─ /broadcast → Send to all players
     │  ├─ /reset    → Clear game state
     │  └─ /quit     → Shutdown server
     └─ Loops
```

**Key Variables:**

```csharp
_serverManager         // WebSocket server
_gameState            // Authoritative game state
_tickCounter          // Current game tick
_gameRunning          // Server running flag
_serverIsPlayer       // Whether server also plays
```

### 2. GameState.cs - Authoritative Game State

**Responsibilities:**
- Maintain single source of truth
- Store all player data
- Process game actions with validation
- Manage event queue for broadcasting

**Key Classes:**

```csharp
GameState
  ├─ Arena
  │  ├─ Width: 40 cells
  │  └─ Height: 25 cells
  │
  ├─ Players: Dictionary<string, PlayerData>
  │  └─ Key: playerId, Value: Player stats
  │
  ├─ Events: Queue<GameEvent>
  │  └─ Pending events to broadcast
  │
  └─ CurrentTick: long
     └─ Current game tick number

PlayerData (IJsonSerializable)
  ├─ Identity
  │  ├─ PlayerId
  │  └─ PlayerName
  │
  ├─ Position
  │  ├─ X (0-39)
  │  └─ Y (0-24)
  │
  ├─ Stats
  │  ├─ Health (0-MaxHealth)
  │  ├─ MaxHealth (100 + level×10)
  │  ├─ Level (1+)
  │  ├─ Experience
  │  ├─ Score
  │  ├─ Kills
  │  ├─ Deaths
  │  └─ IsAlive (true/false)
  │
  └─ Meta
     └─ LastActionTime

GameEvent (IJsonSerializable)
  ├─ Timestamp
  ├─ EventType (join, leave, move, attack, spawn, death)
  ├─ Description (user-friendly text)
  ├─ SourcePlayer (who initiated)
  └─ TargetPlayer (who was affected)

Arena
  ├─ Width: 40 cells
  └─ Height: 25 cells
```

**Key Methods:**

```csharp
AddPlayer(playerId, playerName)
  └─ Register new player
     ├─ Create PlayerData
     ├─ Random starting position
     ├─ Initialize stats
     └─ Add to Players dict

RemovePlayer(playerId)
  └─ Unregister player
     └─ Remove from Players dict

ProcessMove(playerId, x, y)
  └─ Validate and execute movement
     ├─ Validate: IsValidMove(x, y)
     ├─ Validate: Player is alive
     ├─ Update: Players[id].X = x
     ├─ Update: Players[id].Y = y
     ├─ Create: GameEvent (type="move")
     └─ Enqueue: Event

ProcessAttack(attackerId, targetName)
  └─ Validate and execute attack
     ├─ Validate: Attacker exists & alive
     ├─ Validate: Target exists & alive
     ├─ Validate: Distance <= 10 cells
     ├─ Calculate: Damage = CombatSystem.CalculateDamage()
     ├─ Apply: Target.Health -= damage
     ├─ Update: Attacker.Score += damage
     ├─ If target dies:
     │  ├─ Target.IsAlive = false
     │  ├─ Target.Deaths++
     │  ├─ Attacker.Kills++
     │  ├─ Attacker.Score += 50 (kill bonus)
     │  ├─ Award XP
     │  ├─ Handle level up
     │  └─ Create GameEvent (type="death")
     └─ Enqueue: Event

ProcessSpawn(playerId)
  └─ Validate and execute respawn
     ├─ Validate: Player exists
     ├─ Validate: Player is dead
     ├─ Reset: X, Y (random position)
     ├─ Reset: Health = MaxHealth
     ├─ Reset: IsAlive = true
     ├─ Create: GameEvent (type="spawn")
     └─ Enqueue: Event

GetPendingEvents()
  └─ Dequeue all pending events
     └─ Returns: List<GameEvent>
```

### 3. GameSystems.cs - Game Logic

**Responsibilities:**
- Calculate game mechanics
- Validate game rules
- Ensure consistency

**Key Classes:**

```csharp
MoveSystem
  ├─ IsValidMove(x, y)
  │  └─ Returns: x in [0-39] AND y in [0-24]
  │
  └─ GetDistance(x1, y1, x2, y2)
     └─ Returns: Euclidean distance between points
        Formula: sqrt((x2-x1)² + (y2-y1)²)

CombatSystem
  ├─ BaseDamage = 10
  ├─ CriticalChance = 20% (1 in 5 chance)
  ├─ CriticalMultiplier = 1.5x
  ├─ MaxAttackDistance = 10 cells
  │
  ├─ CalculateDamage(attacker, defender)
  │  └─ Calculate damage for attack
  │     ├─ Check distance <= MaxAttackDistance
  │     ├─ Base damage = BaseDamage + (level × 2)
  │     ├─ Roll critical (20% chance)
  │     │  └─ If critical: damage *= CriticalMultiplier
  │     └─ Return: final damage amount
  │
  └─ GetExperienceReward(defenderLevel)
     └─ Calculate XP for kill
        └─ Return: max(10, 50 × level / 10)
```

### 4. Message Handlers

**Responsibilities:**
- Receive messages from clients
- Parse and validate
- Process game actions
- Queue events for broadcasting

**Message Flow:**

```
Client sends: /move 25 15
    │
    ├─ NetworkServerManager receives WebSocket message
    │
    ├─ Deserialize GameMessage
    │  ├─ MessageType: "move"
    │  └─ Content: "25,15"
    │
    ├─ Route to handler: OnPlayerMove(senderId, payload)
    │  ├─ senderId = clientId
    │  └─ payload = "25,15"
    │
    ├─ Parse and validate
    │  ├─ Split by ","
    │  ├─ Convert to int x, y
    │  ├─ Call GameState.ProcessMove(playerId, x, y)
    │  └─ Log action
    │
    └─ GameState queues event
       └─ Event will be broadcast next tick
```

**Message Types:**

```
game.move
  └─ Payload: "x,y"
     Example: "25,15"

game.attack
  └─ Payload: "targetName"
     Example: "Alice"

game.spawn
  └─ Payload: "respawning"
     Example: "respawning"

game.chat
  └─ Payload: "message"
     Example: "Hello everyone!"
```

## Game Tick System

### Tick-Based Update Loop

```
Server Clock: 30 ticks per second = 33.3ms per tick

Tick 0 (0ms)
  ├─ _tickCounter = 1
  ├─ Process events (if any)
  └─ Sleep ~33ms

Tick 1 (33ms)
  ├─ _tickCounter = 2
  ├─ Process events
  └─ Sleep ~33ms

Tick 5 (165ms) ← BROADCAST TICK
  ├─ _tickCounter = 6
  ├─ Process events
  ├─ BroadcastGameStateAsync()
  └─ Sleep ~33ms

Tick 10 (330ms) ← BROADCAST TICK
  ├─ _tickCounter = 11
  ├─ Process events
  ├─ BroadcastGameStateAsync()
  └─ Sleep ~33ms

... continues forever
```

### Advantages

```
Benefits of Tick-Based System:
├─ Deterministic: Same input = Same output
├─ Reproducible: Can replay gameplay
├─ Synchronized: All clients see same events in order
├─ Fair: No latency advantages (server authority)
├─ Testable: Can step through manually
└─ Debuggable: Can log tick by tick
```

## State Broadcasting

### Full State Update

**Every 5 ticks (~167ms):**

Server sends complete game state to all connected players:

```
Server creates:
{
  MessageType: "state",
  Content: "
    alice:x:20|alice:y:12|alice:health:90|alice:score:45|alice:alive:true|
    bob:x:25|bob:y:15|bob:health:100|bob:score:10|bob:alive:true|
    ...
  "
}

Broadcast to all clients:
foreach client in connectedClients:
  send(client, "game.update", stateMessage)
```

### Event Broadcasting

**Immediately upon event:**

Server sends game events to all players as they occur:

```
Example 1: Attack Event
{
  MessageType: "attack",
  Content: "attack|alice|bob|Alice attacked Bob for 12 damage!"
}

Example 2: Chat Event
{
  MessageType: "chat",
  Content: "alice:Alice: Hello everyone!"
}

Example 3: Join Event
{
  MessageType: "join",
  Content: "join|alice||Alice entered the arena!"
}
```

### Broadcasting Code

```csharp
BroadcastGameStateAsync()
  └─ Called every 5 ticks
     ├─ Serialize state:
     │  "playerId:field:value|playerId:field:value|..."
     ├─ Create GameMessage
     ├─ Foreach connected player:
     │  └─ Send "game.update" message
     └─ Log broadcast complete

BroadcastGameEventAsync(gameEvent)
  └─ Called immediately when event occurs
     ├─ Foreach connected player:
     │  └─ Send event-type message (e.g., "game.attack")
     └─ Log event broadcast
```

## Event System

### Event Types

```
Join Event
  ├─ Type: "join"
  ├─ Triggered: When player connects
  ├─ SourcePlayer: New player ID
  └─ Example: "Alice entered the arena!"

Leave Event
  ├─ Type: "leave"
  ├─ Triggered: When player disconnects
  ├─ SourcePlayer: Departed player ID
  └─ Example: "Bob left the arena"

Move Event
  ├─ Type: "move"
  ├─ Triggered: After movement validation
  ├─ SourcePlayer: Moving player
  └─ Example: "Alice moved to (25, 15)"

Attack Event
  ├─ Type: "attack"
  ├─ Triggered: After damage applied
  ├─ SourcePlayer: Attacker
  ├─ TargetPlayer: Defender
  └─ Example: "Alice attacked Bob for 12 damage!"

Death Event
  ├─ Type: "death"
  ├─ Triggered: When player HP = 0
  ├─ SourcePlayer: Killer
  ├─ TargetPlayer: Victim
  └─ Example: "Bob was defeated!"

Spawn Event
  ├─ Type: "spawn"
  ├─ Triggered: After respawn
  ├─ SourcePlayer: Respawned player
  └─ Example: "Alice respawned!"
```

### Event Processing Flow

```
Event occurs in game logic
    │
    ├─ Create GameEvent object
    │  ├─ Set Type
    │  ├─ Set SourcePlayer/TargetPlayer
    │  ├─ Set Description
    │  └─ Set Timestamp
    │
    ├─ Queue in GameState.Events
    │
    └─ Next tick: BroadcastGameEventAsync()
       └─ Send to all connected clients
```

## Validation and Anti-Cheating

### Authoritative Server

The server validates all actions because:

```
Why Server Authority?
├─ Prevents cheating
│  ├─ Clients cannot modify stats
│  ├─ Clients cannot change positions arbitrarily
│  ├─ Clients cannot modify other players
│  └─ Movement is strictly within arena
│
├─ Ensures consistency
│  ├─ All players see same state
│  ├─ Actions are atomic (all or nothing)
│  ├─ No conflicting updates
│  └─ Deterministic results
│
└─ Simplifies logic
   ├─ Single source of truth
   ├─ No client-server disagreements
   ├─ Easy to debug
   └─ Easy to replay
```

### Validation Rules

```
Movement Validation
├─ Player must exist: CheckPlayerExists()
├─ Player must be alive: player.IsAlive == true
├─ X must be in range: 0 <= x <= 39
├─ Y must be in range: 0 <= y <= 24
└─ If all pass: Update position

Attack Validation
├─ Attacker must exist: CheckPlayerExists()
├─ Attacker must be alive: attacker.IsAlive == true
├─ Target must exist: FindByName(targetName)
├─ Target must be alive: target.IsAlive == true
├─ Distance must be valid: GetDistance() <= 10
└─ If all pass: Apply damage

Spawn Validation
├─ Player must exist: CheckPlayerExists()
├─ Player must be dead: player.IsAlive == false
├─ Position must be valid: IsValidMove(x, y)
└─ If all pass: Respawn player
```

### Spam Prevention

The server could implement (future):

```csharp
// Prevent spam
private readonly Dictionary<string, long> _lastActionTime = new();

bool CanPerformAction(string playerId)
{
  if (!_lastActionTime.ContainsKey(playerId))
    return true;
  
  long now = DateTime.UtcNow.Ticks;
  long lastAction = _lastActionTime[playerId];
  long timeSinceLastAction = now - lastAction;
  
  // Require 500ms between actions
  return timeSinceLastAction > 500 * TimeSpan.TicksPerMillisecond;
}
```

## Admin Commands

### Command Reference

```
/players
  └─ Display all connected players with stats
     Shows: Name, HP, Score, Level, Position
     Example output:
       ✓ Alice       HP=90/100 Score=45 Lvl=2 Pos=(20,12)
       ✓ Bob         HP=100/100 Score=10 Lvl=1 Pos=(25,15)
       ✕ Charlie     HP=0/100 Score=0 Lvl=1 Pos=(15,8)

/status
  └─ Display server game status
     Shows: Player count, Sessions, State entries, Ticks
     Example output:
       Active Players: 3
       Active Sessions: 1
       Game State Entries: 3
       Tick: 4847
       Pending Events: 5

/broadcast <message>
  └─ Send message to all connected players
     Format: /broadcast Welcome to the arena!
     Client sees: [SERVER]: Welcome to the arena!

/reset
  └─ Clear all game state
     Removes: All players, all events
     Disconnected clients will lose connection
     Use with caution!

/quit
  └─ Shutdown server gracefully
     Disconnects: All clients
     Stops: Game loop, tick system
     Exits: Program
```

## Error Handling

### Connection Errors

```
Client disconnects (network failure)
    │
    ├─ NetworkServerManager detects disconnect
    │
    ├─ PlayerLeft event triggered
    │  ├─ Call RegisteredEvents handler
    │  ├─ Remove from GameState
    │  ├─ Create leave event
    │  └─ Queue event for broadcast
    │
    └─ Next tick: Broadcast leave event to other players
       └─ Other clients update their UI
```

### Validation Failures

```
Client sends: /move 50 50 (out of bounds)
    │
    ├─ OnPlayerMove() receives message
    │
    ├─ GameState.ProcessMove(playerId, 50, 50)
    │  ├─ IsValidMove(50, 50) returns false
    │  └─ Early return: No update, no event
    │
    ├─ Server logs: "Invalid move attempt"
    │
    └─ Client hears nothing (no state change)
       └─ Client realizes move failed
          └─ Can retry
```

### Invalid Actions

```
Client sends: /attack Bob (Bob is dead)
    │
    ├─ OnPlayerAttack() receives message
    │
    ├─ GameState.ProcessAttack(playerId, "Bob")
    │  ├─ FindByName("Bob") finds Bob
    │  ├─ Bob.IsAlive == false
    │  └─ Early return: No damage, no event
    │
    ├─ Server logs: "Attack on dead player"
    │
    └─ Client hears nothing (no state change)
```

## Performance Metrics

### Server Capacity

```
Current Configuration:
├─ Max Players: 8
├─ Arena Size: 40×25 = 1,000 cells
├─ Update Rate: 30 ticks/second
├─ Broadcast Rate: 6 broadcasts/second
└─ Typical Bandwidth: ~50 KB/second (8 players)

Per-Player Overhead:
├─ PlayerData: ~100 bytes
├─ Network: ~1 KB per state update
├─ Memory: ~50 KB per 8 players
└─ CPU: <1% per player (on modern hardware)
```

### Scalability

```
Potential Improvements:
├─ More Players
│  └─ Spatial partitioning (quadtree)
│     └─ Only sync nearby players
│
├─ Larger Arena
│  └─ Multiple rooms/maps
│     └─ Load balance across instances
│
└─ Persistent Data
   └─ Database backend
      └─ Save/load player stats
```

## Testing Recommendations

### Unit Tests

```csharp
TestGameState()
  ├─ AddPlayer() creates valid player
  ├─ RemovePlayer() cleans up
  ├─ ProcessMove() validates bounds
  ├─ ProcessAttack() calculates damage
  └─ ProcessSpawn() resets player

TestCombatSystem()
  ├─ Damage scales with level
  ├─ Critical hits do 1.5× damage
  ├─ Distance check works
  └─ Experience calculation is correct
```

### Integration Tests

```csharp
TestMultiplayer()
  ├─ 2 clients connect successfully
  ├─ State synced between them
  ├─ Player A attacks Player B
  ├─ Damage applied correctly
  ├─ Both clients see event
  └─ Clients disconnect cleanly

TestGameFlow()
  ├─ Game starts
  ├─ Players join
  ├─ Combat occurs
  ├─ Scores update
  ├─ Players respawn
  └─ Server shuts down gracefully
```

## Future Enhancements

```
Short Term:
├─ Spam prevention (rate limiting)
├─ Disconnection recovery (rejoin)
└─ Better logging/diagnostics

Medium Term:
├─ Persistent player data
├─ Multiple game modes
├─ Spectator mode
└─ Admin tools

Long Term:
├─ Microservices architecture
├─ Database backend
├─ Matchmaking system
├─ Seasonal rankings
└─ Guild/clan system
```

## Conclusion

The SimpleGame server demonstrates:
- Authoritative server architecture
- Tick-based game loop
- Deterministic game logic
- Efficient state broadcasting
- Robust error handling
- Scalable design

The architecture can serve as a foundation for more complex multiplayer games while maintaining code clarity and performance.


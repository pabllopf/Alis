# SimpleGame - Network Protocol Documentation

## Overview

SimpleGame uses WebSocket-based communication with JSON-serialized messages. The protocol is designed for real-time multiplayer gaming with server authority.

## Connection Details

```
Protocol: WebSocket (ws)
Address: ws://127.0.0.1:8889/
Format: JSON with IJsonSerializable
Reliability: TCP (guaranteed delivery)
Bidirectional: Yes (full-duplex)
Persistent: Yes (continuous connection)
```

## Message Structure

### Base Message Format

All messages are serialized as JSON from `GameMessage` class:

```csharp
public class GameMessage : IJsonSerializable
{
  public string MessageType { get; set; }
  public string Content { get; set; }
}
```

### JSON Example

```json
{
  "MessageType": "move",
  "Content": "25,15"
}
```

## Message Types and Protocols

### CLIENT → SERVER Messages

#### Movement Request

```
Type: game.move
MessageType: "move"
Content Format: "x,y"

Example:
{
  "MessageType": "move",
  "Content": "25,15"
}

Validation (Server-side):
├─ x must be integer [0-39]
├─ y must be integer [0-24]
├─ Player must be alive
└─ Player must exist

Response:
├─ Success: Broadcast state update
└─ Failure: No response (action rejected silently)
```

#### Attack Request

```
Type: game.attack
MessageType: "attack"
Content Format: "targetPlayerName"

Example:
{
  "MessageType": "attack",
  "Content": "Bob"
}

Validation (Server-side):
├─ Attacker must exist and be alive
├─ Target must exist and be alive
├─ Distance <= 10 cells (Euclidean)
├─ Target name must match exactly
└─ Both players in arena bounds

Response:
├─ Success: Broadcast attack event
└─ Failure: No response (action rejected)
```

#### Spawn Request (Respawn)

```
Type: game.spawn
MessageType: "spawn"
Content Format: "respawning"

Example:
{
  "MessageType": "spawn",
  "Content": "respawning"
}

Validation (Server-side):
├─ Player must exist
├─ Player must be DEAD (IsAlive = false)
├─ New position must be valid (in arena)
└─ Respawn position chosen randomly

Response:
├─ Success: Broadcast spawn event
└─ Failure: No response
```

#### Chat Message

```
Type: game.chat
MessageType: "chat"
Content Format: "message text"

Example:
{
  "MessageType": "chat",
  "Content": "Hello everyone!"
}

Processing:
├─ Find sender player
├─ Create event with message
├─ Broadcast to all players
└─ Include sender name in broadcast

Broadcast Format:
{
  "MessageType": "chat",
  "Content": "Alice: Hello everyone!"
}
```

### SERVER → CLIENT Messages

#### State Update (Broadcast)

```
Type: game.update
Frequency: Every 5 ticks (~167ms)
Sent To: All connected clients

Format:
{
  "MessageType": "state",
  "Content": "playerId:field:value|playerId:field:value|..."
}

Field Examples:
├─ playerId:x:20        (X coordinate)
├─ playerId:y:15        (Y coordinate)
├─ playerId:health:90   (Current health)
├─ playerId:score:45    (Player score)
├─ playerId:alive:true  (Life status)
└─ playerId:level:2     (Player level)

Complete Example:
{
  "MessageType": "state",
  "Content": "alice:x:20|alice:y:12|alice:health:90|alice:score:45|alice:alive:true|bob:x:25|bob:y:15|bob:health:100|bob:score:10|bob:alive:true"
}

Client Processing:
├─ Split by '|' to get field updates
├─ Split each by ':' to parse field
├─ Update local PlayerData
├─ Trigger render if state changed
└─ Cache LastUpdateTick
```

#### Move Event

```
Type: game.move
Triggered: When player moves successfully
Sent To: All connected clients

Format:
{
  "MessageType": "move",
  "Content": "move|playerId|targetId|description"
}

Example:
{
  "MessageType": "move",
  "Content": "move|alice||Alice moved to (25, 15)"
}

Client Processing:
├─ Parse event details
├─ Add to EventLog
├─ Note: State update already sent separately
└─ TriggerRender()
```

#### Attack Event

```
Type: game.attack
Triggered: When attack hits successfully
Sent To: All connected clients

Format:
{
  "MessageType": "attack",
  "Content": "attack|attackerId|targetId|description"
}

Example:
{
  "MessageType": "attack",
  "Content": "attack|alice|bob|Alice attacked Bob for 12 damage!"
}

Client Processing:
├─ Parse attacker and target
├─ Parse damage from description
├─ Add to EventLog
├─ Update local stats (from next state update)
└─ TriggerRender()
```

#### Spawn Event

```
Type: game.spawn
Triggered: When player respawns
Sent To: All connected clients

Format:
{
  "MessageType": "spawn",
  "Content": "spawn|playerId||description"
}

Example:
{
  "MessageType": "spawn",
  "Content": "spawn|alice||Alice respawned!"
}

Client Processing:
├─ Parse player and position
├─ Add to EventLog
├─ Note: Position/Health reset via state update
└─ TriggerRender()
```

#### Chat Event

```
Type: game.chat
Triggered: When any player sends chat
Sent To: All connected clients (including sender)

Format:
{
  "MessageType": "chat",
  "Content": "senderName: message text"
}

Example:
{
  "MessageType": "chat",
  "Content": "Alice: Hello everyone!"
}

Client Processing:
├─ Parse sender name and message
├─ Log to console: "[CHAT] Alice: Hello everyone!"
├─ Add to EventLog
└─ TriggerRender()
```

#### Join Event

```
Type: game.join
Triggered: When new player joins
Sent To: All connected clients

Format:
{
  "MessageType": "join",
  "Content": "join|newPlayerId||description"
}

Example:
{
  "MessageType": "join",
  "Content": "join|bob||Bob entered the arena!"
}

Client Processing:
├─ Parse new player ID and name
├─ Create PlayerData entry
├─ Add to EventLog
├─ Log: "→ Bob entered the arena"
└─ TriggerRender()
```

#### Leave Event

```
Type: game.leave
Triggered: When player disconnects
Sent To: All connected clients (except departed player)

Format:
{
  "MessageType": "leave",
  "Content": "leave|departedPlayerId||description"
}

Example:
{
  "MessageType": "leave",
  "Content": "leave|bob||Bob left the arena"
}

Client Processing:
├─ Parse departed player ID
├─ Remove from Players dict
├─ Add to EventLog
├─ Log: "← Bob left the arena"
└─ TriggerRender()
```

#### Death Event

```
Type: game.death
Triggered: When player's health reaches 0
Sent To: All connected clients

Format:
{
  "MessageType": "death",
  "Content": "death|attackerId|victimId|description"
}

Example:
{
  "MessageType": "death",
  "Content": "death|alice|bob|Bob was defeated by Alice!"
}

Client Processing:
├─ Parse attacker, victim, and description
├─ Update victim IsAlive = false
├─ Update attacker Kills++
├─ Add to EventLog
└─ TriggerRender()
```

## Message Sequence Examples

### Example 1: Simple Movement

```
Timeline: T0ms - T200ms

T0: Client sends move request
    ClientManager.BroadcastMessageAsync("game.move", message)
    WebSocket sends:
    {
      "MessageType": "move",
      "Content": "25,15"
    }

T10: Server receives and validates
     ├─ IsValidMove(25, 15) ✓
     ├─ Player alive ✓
     └─ Position within bounds ✓

T15: Server updates state
     ├─ GameState.Players[playerId].X = 25
     ├─ GameState.Players[playerId].Y = 15
     └─ Enqueue MoveEvent

T20: Next tick (if tick % 5 == 0)
     Server broadcasts:
     {
       "MessageType": "state",
       "Content": "playerId:x:25|playerId:y:15|..."
     }

T30: Client receives state update
     ├─ Parse fields
     ├─ Update local Players[playerId].X = 25
     ├─ Update local Players[playerId].Y = 15
     └─ TriggerRender()

T100-150: Render cycle
     ├─ RenderLoopAsync detects _needsRender = true
     ├─ ConsoleRenderer.Render()
     ├─ Show arena with new position
     └─ User sees updated position

Result: Movement complete in ~100-150ms
```

### Example 2: Combat Sequence

```
Timeline: T0ms - T250ms

T0: Client sends attack request
    {
      "MessageType": "attack",
      "Content": "Bob"
    }

T10: Server validates
     ├─ Find Bob
     ├─ Check alive ✓
     ├─ Check distance <= 10 ✓
     └─ Calculate damage = 12

T15: Server processes
     ├─ Bob.Health -= 12 (now 88/100)
     ├─ Alice.Score += 12
     ├─ Create AttackEvent
     └─ Enqueue event

T20: Broadcast attack event
     Server sends to Alice & Bob:
     {
       "MessageType": "attack",
       "Content": "attack|alice|bob|Alice attacked Bob for 12 damage!"
     }

T30: Clients receive attack event
     ├─ Both add to EventLog
     └─ Both TriggerRender()

T35: Broadcast state update
     Server sends:
     {
       "MessageType": "state",
       "Content": "alice:score:57|bob:health:88|bob:alive:true|..."
     }

T45: Clients receive state update
     ├─ Alice.Score = 57
     ├─ Bob.Health = 88
     └─ TriggerRender()

T150-200: Render cycle
     Both clients see:
     ├─ Event log: "Alice attacked Bob for 12 damage!"
     ├─ Bob's health bar reduced
     ├─ Alice's score increased
     └─ Arena updated

Result: Combat complete in ~150-200ms
```

### Example 3: Player Death

```
Timeline: T0ms - T300ms

T0: Combat leading to death
    ├─ Bob at 10 HP
    ├─ Alice attacks
    └─ Damage = 15 HP

T15: Server processes lethal damage
     ├─ Bob.Health = 10 - 15 = -5 → 0
     ├─ Bob.IsAlive = false
     ├─ Bob.Deaths++
     ├─ Alice.Kills++
     ├─ Alice.Score += 50 (kill bonus)
     ├─ Award 50 XP to Alice
     ├─ Create DeathEvent
     ├─ Create AttackEvent
     └─ Enqueue both events

T20: Broadcast death event
     Server sends to all:
     {
       "MessageType": "death",
       "Content": "death|alice|bob|Bob was defeated by Alice!"
     }

T30: Broadcast attack event
     {
       "MessageType": "attack",
       "Content": "attack|alice|bob|Alice attacked Bob for 15 damage!"
     }

T40: Broadcast state update
     {
       "MessageType": "state",
       "Content": "alice:score:107|alice:kills:2|bob:alive:false|bob:deaths:1|..."
     }

T200: Client renders
     All players see:
     ├─ "Bob was defeated by Alice!"
     ├─ "Alice attacked Bob for 15 damage!"
     ├─ Bob marked as ✕ in arena
     ├─ Alice score: 57 → 107
     └─ Can /chat about it

Result: Death processed and displayed in ~200ms
```

## Error Scenarios

### Scenario: Invalid Movement

```
T0: Client sends
    {
      "MessageType": "move",
      "Content": "50,50"  ← Out of bounds
    }

T10: Server validates
     IsValidMove(50, 50)
     └─ 50 > 39 (X out of bounds)
     └─ Returns false

T15: Server rejects (silently)
     ├─ No GameState update
     ├─ No event created
     ├─ No broadcast sent
     └─ No error message

T30: Client waits for state update
     ├─ Doesn't receive one
     ├─ Local state unchanged
     ├─ Can retry with valid coordinates

Result: Invalid move prevented by server
```

### Scenario: Attack Out of Range

```
T0: Client sends
    {
      "MessageType": "attack",
      "Content": "EnemyAcrossMap"
    }

T10: Server validates
     ├─ Find target ✓
     ├─ Distance check:
     │  Distance = sqrt((30-5)² + (20-5)²)
     │  Distance = sqrt(625 + 225) = 29
     │  29 > 10 (max range)
     │  └─ Fails!

T15: Server rejects
     ├─ No damage applied
     ├─ No event created
     └─ No broadcast

Result: Out of range attack prevented
```

### Scenario: Attack Dead Player

```
T0: Client sends
    {
      "MessageType": "attack",
      "Content": "DeadPlayer"
    }

T10: Server validates
     ├─ Find DeadPlayer ✓
     ├─ Check alive: false
     │  └─ Player is dead
     │  └─ Validation fails!

T15: Server rejects
     ├─ No event created
     └─ No broadcast

Result: Cannot attack dead players
```

## Performance Considerations

### Bandwidth Usage

```
Typical Multiplayer Game (8 players):

Per Tick (33ms):
├─ Game events: ~1-5 KB (variable)
├─ State updates: ~100-500 bytes
├─ Total per tick: ~1-5 KB

Per Second (30 ticks):
├─ Events: ~30-150 KB
├─ State: ~3-15 KB
├─ Total: ~30-165 KB/second
└─ Typical: ~50 KB/second

Per Hour:
├─ Total bandwidth: ~180 MB
├─ For 1 player: ~22 MB
└─ Reasonable for home network
```

### Latency Tolerance

```
Typical Latency (on localhost): 0-10ms
Acceptable Latency: < 100ms

Components:
├─ Client serialization: <1ms
├─ Network round-trip: 0-50ms
├─ Server processing: 1-5ms
├─ Broadcast serialization: <1ms
└─ Client deserialization: <1ms
└─ Total: 2-57ms (typically ~20ms)

User Experience:
├─ 0-50ms:   Feels instant/perfect
├─ 50-100ms: Acceptable, barely noticeable
├─ 100-200ms: Noticeable but playable
└─ 200ms+:   Poor experience
```

## Security Considerations

### Current Implementation

```
Security Measures (Implemented):
├─ Server authority (prevents cheating)
├─ Input validation (prevents crashes)
├─ Bounds checking (prevents exploits)
└─ Closed WebSocket (localhost only)

Potential Vulnerabilities (Unimplemented):
├─ No authentication (anyone can join)
├─ No encryption (traffic visible)
├─ No rate limiting (potential DOS)
└─ No data validation depth (could improve)
```

### Recommendations for Production

```
Before Production Deployment:

Authentication:
├─ Implement login system
├─ Issue auth tokens
├─ Validate on every message
└─ Handle session expiration

Encryption:
├─ Use WSS (WebSocket Secure)
├─ Implement TLS/SSL
├─ Validate certificates
└─ Encrypt sensitive data

Rate Limiting:
├─ Limit messages per second
├─ Implement cooldowns
├─ Track per-player usage
└─ Ban repeat offenders

Input Validation:
├─ Whitelist valid inputs
├─ Reject invalid data types
├─ Log suspicious activity
└─ Implement telemetry
```

## Debugging and Logging

### Message Logging

The server logs every message:

```
Server-side Logging:
├─ [MOVE] playerId → (x, y)
├─ [ATTACK] playerId → targetName: damage dmg!
├─ [SPAWN] playerId respawned at (x, y)
├─ [CHAT] playerName: message
└─ [EVENT] Broadcasted to N clients
```

### Client-side Debugging

```csharp
// Example: Log every message received
private static async Task OnGameUpdate(string senderId, string payload)
{
  Debug.WriteLine($"[Update] {DateTime.Now:HH:mm:ss.fff} - {payload.Substring(0, 100)}");
  // ... process message
}
```

## Conclusion

The SimpleGame network protocol is designed for:
- **Simplicity**: Easy to understand and implement
- **Reliability**: TCP-based with server authority
- **Efficiency**: Compact JSON format with batched updates
- **Extensibility**: Easy to add new message types
- **Debuggability**: Clear message structure and logging

The protocol successfully demonstrates real-time multiplayer communication patterns used in production games.


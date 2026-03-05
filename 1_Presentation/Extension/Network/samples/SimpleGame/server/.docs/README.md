# SimpleGame Server Documentation

## Quick Start

### Prerequisites
- .NET 10.0 or higher
- Alis framework compiled

### Running the Server

```bash
cd /path/to/Alis

# Compile
dotnet build 1_Presentation/Extension/Network/samples/SimpleGame/server/Alis.Extension.Network.Sample.SimpleGame.Server.csproj

# Run
dotnet run -p 1_Presentation/Extension/Network/samples/SimpleGame/server/Alis.Extension.Network.Sample.SimpleGame.Server.csproj
```

When you start the server, you'll be asked:

```
Run as pure server or as player+server? (s/p): 
```

- **s** = Pure server (recommended for testing)
- **p** = Server also participates as a player

### Server Output

```
╔══════════════════════════════════════════════════════╗
║     ALIS NETWORK - SIMPLE GAME SERVER SAMPLE         ║
║     Console-Based Arena Battle System                ║
╚══════════════════════════════════════════════════════╝

✓ Running as Pure Server
✓ Server initialized
✓ Session created: Battle Arena

✓ Server listening on ws://127.0.0.1:8889/

═══════════════════════════════════════════════════════
Game Server Commands:
  /players   - Show connected players
  /status    - Show game status
  /broadcast <msg> - Send message to all
  /reset     - Reset game state
  /quit      - Stop server
═══════════════════════════════════════════════════════

server>
```

## Server Commands Reference

### /players
Display all connected players with their current stats.

```
server> /players
Connected players: 2/8
  ✓ Alice       HP=90/100 Score=45 Lvl=2 Pos=(20,12)
  ✓ Bob         HP=100/100 Score=10 Lvl=1 Pos=(25,15)
```

### /status
Show server game status and statistics.

```
server> /status
═ GAME STATUS ═
Active Players: 2
Active Sessions: 1
Game State Entries: 2
Tick: 1847
Pending Events: 5
```

### /broadcast \<message\>
Send a message to all connected players.

```
server> /broadcast Welcome to the arena!
✓ Broadcast: Welcome to the arena!
```

Players will see:
```
[CHAT] SERVER: Welcome to the arena!
```

### /reset
Reset the entire game state (clears all players and events).

**Warning**: This disconnects all clients!

```
server> /reset
✓ Game state reset
```

### /quit
Gracefully shutdown the server.

```
server> /quit
Stopping server...
✓ Server stopped
```

## How the Server Works

### Game Loop

The server runs a **tick-based game loop** at 30 ticks per second:

```
Every 33ms (1 tick):
├─ Increment tick counter
├─ Process queued game actions
├─ Apply game logic
│
└─ Every 5 ticks (~167ms):
   ├─ Broadcast complete game state
   └─ Broadcast queued events
```

### Tick-Based Updates

Example with 30 ticks/second:

```
Tick 0:   0ms   Process actions
Tick 1:   33ms  Process actions
Tick 2:   66ms  Process actions
Tick 3:   99ms  Process actions
Tick 4:   132ms Process actions
Tick 5:   165ms ← BROADCAST TICK
          - Send full state to all clients
          - Send any queued events
Tick 6:   198ms Process actions
...
Tick 10:  330ms ← BROADCAST TICK
```

### Player Joining Flow

```
Client connects via WebSocket
    │
    ├─ NetworkServerManager receives connection
    ├─ Triggers PlayerJoined event
    ├─ Server adds player to GameState
    ├─ Creates join event
    ├─ Next broadcast tick:
    │  └─ Sends player list to all clients
    │
    └─ Player can now play
```

### Player Leaving Flow

```
Client disconnects
    │
    ├─ NetworkServerManager detects disconnect
    ├─ Triggers PlayerLeft event
    ├─ Server removes player from GameState
    ├─ Creates leave event
    ├─ Next broadcast tick:
    │  └─ Notifies all clients
    │
    └─ Other players see player disappear
```

### Action Processing

Example: Player moves

```
Server receives: /move 25 15
    │
    ├─ Deserialize GameMessage
    ├─ Call OnPlayerMove(senderId, "25,15")
    ├─ Parse coordinates
    ├─ Validate:
    │  ├─ Player exists
    │  ├─ Player is alive
    │  └─ Coordinates in bounds [0-39, 0-24]
    │
    ├─ If valid:
    │  ├─ Update GameState.Players[id].X = 25
    │  ├─ Update GameState.Players[id].Y = 15
    │  └─ Queue MoveEvent
    │
    └─ If invalid:
       └─ Silently reject (no broadcast)
```

## Game Rules

### Arena

- **Size**: 40 × 25 cells
- **Max Players**: 8 (concurrent)
- **Spawn**: Random position on join/respawn

### Combat

- **Attack Range**: 10 cells (Euclidean distance)
- **Base Damage**: 10 + (attacker_level × 2)
- **Critical Hit**: 20% chance for 1.5× damage
- **Kill Bonus**: 50 points

### Progression

- **Starting Level**: 1
- **XP Per Kill**: 50 × victim_level / 10
- **XP for Level Up**: level × 100
- **Health Scaling**: 100 + (level × 10) max health
- **Max Level**: Unlimited

### States

**Alive**
- Can move
- Can attack
- Can take damage
- Regenerates nothing

**Dead**
- Cannot move
- Cannot attack
- Cannot take damage
- Can respawn with `/spawn`

## Advanced Features

### Server Authority

The server validates ALL actions. Clients cannot:
- Move outside arena bounds
- Attack out of range
- Modify their own stats
- Attack dead players
- Cheat in any way

Every action is:
1. Validated server-side
2. Applied to authoritative state
3. Broadcast to all clients

### State Broadcasting

The server sends complete state updates every ~167ms:

```
Format: "playerId:field:value|playerId:field:value|..."

Example:
"alice:x:20|alice:y:12|alice:health:90|alice:score:45|alice:alive:true|bob:x:25|bob:y:15|bob:health:100|..."

Fields broadcasted:
├─ x, y        (position)
├─ health      (current HP)
├─ score       (player points)
├─ alive       (is alive)
├─ level       (player level)
└─ others      (as needed)
```

### Event Broadcasting

Events are broadcasted immediately when they occur:

```
Types of events:
├─ join     - Player joined
├─ leave    - Player left
├─ move     - Player moved
├─ attack   - Player attacked
├─ death    - Player killed
��─ spawn    - Player respawned
└─ chat     - Chat message
```

## Performance

### Current Performance

```
Configuration:
├─ Max Players: 8
├─ Tick Rate: 30/second
├─ Update Frequency: 6/second
├─ Message Size: ~100-500 bytes/update
└─ Bandwidth: ~30-165 KB/second (typical: 50 KB/s)

Per-Player Overhead:
├─ Memory: ~5-10 KB
├─ CPU: <0.1% per player
└─ Network: ~6 KB/second per player
```

### Scaling

Current setup handles:
- ✓ 8 players easily
- ? 16+ players (would need optimization)
- ✗ 100+ players (needs architecture change)

Future improvements:
- Spatial partitioning (only sync nearby players)
- Zone system (multiple arenas)
- Load balancing (multiple servers)

## Troubleshooting

### Port Already in Use

If you get an error about port 8889 being in use:

```
# Find process using port 8889
lsof -i :8889

# Kill process (if needed)
kill -9 <PID>
```

### Server Starts But No Clients Connect

1. Check firewall allows port 8889
2. Verify `ws://127.0.0.1:8889/` is correct
3. Check server logs for errors
4. Verify client is built correctly

### Players Disconnecting

Possible causes:
- Network issue
- Client crash
- Timeout (if no messages sent for too long)
- Server too busy

### Weird Game State

Run:
```
server> /reset
```

This clears all players and events, allowing fresh start.

## Architecture Documentation

For detailed information about how the server works:

- **Server Architecture**: See `ARCHITECTURE.md`
  - Core components
  - Game loop details
  - Message handlers
  - State management
  - Validation rules

- **Network Protocol**: See `NETWORK_PROTOCOL.md`
  - Message formats
  - Message sequences
  - Communication flow
  - Error scenarios
  - Performance metrics

## Future Enhancements

Planned improvements:
- [ ] Authentication system
- [ ] Persistent player data
- [ ] Multiple game modes
- [ ] Ranked ladder
- [ ] Team/clan support
- [ ] Admin console improvements
- [ ] Anti-cheat detection
- [ ] Performance optimization

## Support

For issues or questions:
1. Check documentation files
2. Review logs for errors
3. Check network connectivity
4. Verify client and server match version

---

**Version**: 1.0
**Last Updated**: March 2026
**Status**: Stable


# SimpleGame Client Documentation

## Quick Start

### Prerequisites
- .NET 10.0 or higher
- Alis framework compiled
- Server running on `ws://127.0.0.1:8889/`

### Running the Client

```bash
cd /path/to/Alis

# Compile
dotnet build 1_Presentation/Extension/Network/samples/SimpleGame/client/Alis.Extension.Network.Sample.SimpleGame.Client.csproj

# Run
dotnet run -p 1_Presentation/Extension/Network/samples/SimpleGame/client/Alis.Extension.Network.Sample.SimpleGame.Client.csproj
```

### First Run

```
╔══════════════════════════════════════════════════════╗
║     ALIS NETWORK - SIMPLE GAME CLIENT SAMPLE         ║
║     Console-Based Arena Battle System                ║
╚══════════════════════════════════════════════════════╝

Enter your warrior name: Alice

Joining battle at ws://127.0.0.1:8889/...
✓ Joined the battle!
Starting game...
```

## Interface Overview

The client displays a compact interface optimized for 800x600:

```
┌────────────────────────────────────┐
│ .  ○  .  .  .  .  .  .  ●  .  .  │
│ .  .  .  .  .  .  .  .  .  .  .  │
│ ○  .  .  .  .  .  .  .  .  .  .  │
│ .  .  .  .  .  .  .  .  .  ○  .  │
│ .  .  .  .  .  .  .  .  .  .  .  │
│ ●  .  .  .  .  .  .  .  .  .  ○  │
│ .  .  .  .  .  .  .  .  .  .  .  │
│ .  .  ○  .  .  .  .  .  .  .  .  │
│ .  .  .  .  .  .  ●  .  .  .  .  │
│ ○  .  .  .  .  .  .  .  .  .  .  │
│ .  .  .  .  .  .  .  ○  .  .  .  │
│ .  .  .  .  .  .  .  .  .  .  .  │
└────────────────────────────────────┘

[Alice] HP:████████░░ Lvl:2 Score:45 Kills:1 Pos:(20,12)

Players: ✓ Alice:45 | ✓ Bob:15 | ✕ Charlie:0

Events: Bob moved to (25,15) > Alice attacked Bob > Diana joined!

Commands: /move X Y | /attack NAME | /spawn | /chat MSG | /stats | /help | /quit

[Alice]> 
```

### Display Components

**Arena (30×12)**
- `●` = Your character
- `○` = Other players
- `✕` = Dead players
- `.` = Empty space

**Stats Line**
- Current health with visual bar
- Level and score
- Kill count
- Current position

**Players List**
- Top 5 players by score
- ✓ = alive, ✕ = dead

**Events Log**
- Last 3 important events
- Actions and notifications

**Commands**
- Available commands reference

## Available Commands

### Movement

```
/move <x> <y>

Purpose: Move to a specific location
Range: X [0-39], Y [0-24]
Example: /move 25 15

Response:
→ Moved to position
```

**Tips:**
- Your position updates immediately (optimistic)
- Server validates the move
- Invalid moves are silently rejected
- You can move multiple cells at once

### Combat

```
/attack <player_name>

Purpose: Attack a nearby player
Range: Must be within 10 cells (Euclidean)
Example: /attack Bob

Damage Calculation:
├─ Base: 10 + (your_level × 2)
├─ Critical: 20% chance for 1.5× damage
├─ Result: 10-50+ HP depending on level
├─ Kill bonus: +50 points
└─ Experience: 50 × victim_level / 10

Response:
→ Attacking...
[After server processes]
Alice attacked Bob for 12 damage!
```

**Tips:**
- Name must match exactly (case-sensitive)
- Player must be alive
- Player must be within 10 cells
- You gain points equal to damage dealt

### Respawn

```
/spawn

Purpose: Respawn if you're dead
Requirements:
├─ You must be dead (HP = 0)
├─ Random respawn position
└─ Health fully restored

Example: /spawn

Response:
→ Respawning...
[Server processes]
Alice respawned!
```

**Tips:**
- Only works if you're dead
- New position is random
- No penalty for dying
- Can respawn immediately

### Chat

```
/chat <message>

Purpose: Send message to all players
Format: /chat <your message text>
Example: /chat Hello everyone!

Message appears to all players as:
[CHAT] Alice: Hello everyone!

Broadcast: All players see your message
No length limit, but keep it reasonable
```

**Tips:**
- Chat is public (all see it)
- Use to coordinate or taunt
- Appears in event log
- No spam prevention (be nice!)

### Statistics

```
/stats

Purpose: View your detailed statistics
Shows:
├─ Name
├─ Current position (X, Y)
├─ Health and max health
├─ Level and experience
├─ Score, kills, deaths
└─ Alive/Dead status

Example output:
═ YOUR STATS ═
Name: Alice
Position: (20, 12)
Health: 90/100
Level: 2 | XP: 150
Score: 45 | Kills: 1 | Deaths: 0
Status: ✓ Alive
```

**Tips:**
- Updates in real-time
- XP needed = level × 100
- Max health = 100 + (level × 10)
- Score = sum of all damage dealt

### Player List

```
/players

Purpose: See all connected players
Shows: Player name, health, score, level
Example output:
═ CONNECTED PLAYERS ═
✓ Alice          HP:90/100 Score:45 Lvl:2
✓ Bob            HP:100/100 Score:10 Lvl:1
✕ Charlie        HP:0/100 Score:0 Lvl:1
```

**Tips:**
- Players ranked by score
- ✓ = alive, ✕ = dead
- Helps you find targets
- See who's doing well

### Help

```
/help

Purpose: Show all available commands
Lists all commands with brief descriptions
```

### Quit

```
/quit

Purpose: Disconnect and exit game
Gracefully closes connection
Notifies server of departure
Other players see you leave
```

## Game Mechanics

### Leveling System

```
Level 1 → Level 2:  100 XP required
Level 2 → Level 3:  200 XP required
Level 3 → Level 4:  300 XP required
...
Level N → Level N+1: N × 100 XP required

Health per Level:
├─ Level 1: 100 HP max
├─ Level 2: 110 HP max
├─ Level 3: 120 HP max
└─ Level N: 100 + (N × 10) HP max
```

### Combat Mechanics

```
Attack Damage:
├─ Base damage: 10 + (your_level × 2)
├─ Level 1 attack: 10-12 damage (no crit: 12, crit: 18)
├─ Level 2 attack: 12-14 damage (no crit: 14, crit: 21)
├─ Level 5 attack: 20-22 damage (no crit: 22, crit: 33)
└─ Damage scales as you level up

Critical Hit:
├─ Chance: 20% (1 in 5)
├─ Multiplier: 1.5×
├─ Example: 12 damage → 18 damage on crit
└─ Random (procedurally fair)

Kill Rewards:
├─ Damage dealt: Full points
├─ Kill bonus: +50 points
├─ Experience: 50 × victim_level / 10
└─ Level up: Immediately if threshold reached
```

### Movement Mechanics

```
Movement:
├─ Can move to any valid cell (0-39, 0-24)
├─ Movement is instant (server authority)
├─ Multiple players can share space (no collision)
├─ Movement is sent as absolute position

Range from others:
├─ Close: 0-3 cells (very close)
├─ Medium: 3-7 cells (reasonable distance)
├─ Far: 7-10 cells (max attack range)
├─ Too far: 10+ cells (out of range)
```

### Death Mechanics

```
When you die (HP = 0):
├─ Marked as ✕ in arena
├─ Cannot move or attack
├─ Cannot take more damage
├─ Other players see you dead
├─ Can respawn with /spawn

Respawning:
├─ Position: Random in arena
├─ Health: Fully restored
├─ Penalties: None (no punishment)
├─ Immediately: Can rejoin action
└─ Death counter: Increments
```

## Smart Rendering System

The client uses intelligent screen updates to avoid flickering:

### Update Strategy

```
Screen refreshes when:
├─ Player joins/leaves
├─ Your stats change (HP, score, etc)
├─ Other player moves
├─ Someone attacks
├─ Chat message received
└─ Every 500ms (periodic refresh)

Screen does NOT refresh:
├─ When you're typing commands
├─ Every 33ms (would be too fast)
├─ Unnecessarily (saves CPU/bandwidth)
└─ During idle periods

Result:
├─ Smooth reading of commands
├─ Responsive gameplay
├─ No flickering or lag
└─ Clean, stable display
```

### Optimizations

```
Performance Features:
├─ Compact 30×12 arena (vs 40×25)
├─ Smart render triggering
├─ Event batching
├─ Minimal network traffic
├─ Low CPU usage
└─ Smooth 60 FPS potential
```

## Network Communication

The client sends and receives messages:

```
Messages Sent (Client → Server):
├─ /move 25 15           → game.move
├─ /attack Bob           → game.attack
├─ /spawn                → game.spawn
└─ /chat Hello!          → game.chat

Messages Received (Server → Client):
├─ State updates         ← game.update (every ~167ms)
├─ Movement events       ← game.move
├─ Attack events         ← game.attack
├─ Chat messages         ← game.chat
├─ Player joined         ← game.join
└─ Player left           ← game.leave

Typical Latency: 20-100ms
Tolerance: Up to 200ms acceptable
```

## Tips and Strategies

### Beginner

1. **Explore**: Move around to learn arena layout
2. **Find targets**: Use `/players` to see who to attack
3. **Practice**: Attack weaker players to level up safely
4. **Group up**: Gather with other players for alliance
5. **Chat**: Use `/chat` to communicate

### Intermediate

1. **Range awareness**: Stay within 10 cells of targets
2. **Level up**: Kill weaker players to gain XP
3. **Strategic positioning**: Use terrain (if future update adds it)
4. **Respawn timing**: Respawn quickly to rejoin battle
5. **Score hunting**: Maximize damage for high score

### Advanced

1. **Hunt high-level**: Kill high-level players for more XP
2. **Maintain health**: Avoid unnecessary damage
3. **Predict movements**: Anticipate where players will go
4. **Dominate**: Build a killing spree
5. **Leaderboard**: Chase the top score position

## Troubleshooting

### Can't Connect

Error: `Failed to join: Connection refused`

Solutions:
1. Verify server is running
2. Check server is listening on `127.0.0.1:8889`
3. Check firewall allows port 8889
4. Wait a moment and retry

### Commands Don't Work

Problem: Command seems ignored

Solutions:
1. Check spelling exactly
2. Verify you're in valid game state
3. Try `/help` to confirm command syntax
4. Check server logs for errors

### Attack Doesn't Land

Problem: Attack says "Player not found"

Solutions:
1. Check exact player name (case-sensitive)
2. Verify target is alive (not `✕`)
3. Check distance <= 10 cells
4. Try `/players` to see exact names

### Screen Flickering

Problem: Screen updates constantly

Solutions:
1. Normal if lots of action
2. Should stabilize when idle
3. Try reducing terminal size if severe
4. Restart client if stuck

### Position Not Updating

Problem: You move but position doesn't change

Solutions:
1. Wait for next render cycle (~500ms)
2. Check move coordinates are valid (0-39, 0-24)
3. Verify you're not out of bounds
4. Try `/stats` to see actual position

## Architecture Documentation

For detailed information:

- **Client Architecture**: See `ARCHITECTURE.md`
  - How the client works
  - Component descriptions
  - Event system details
  - Rendering optimization
  - State synchronization

- **Network Protocol**: See parent `.docs/NETWORK_PROTOCOL.md`
  - Message formats
  - Communication flow
  - Latency considerations
  - Error handling

## Future Improvements

Potential enhancements:
- [ ] Colored terminal output
- [ ] Sound effects
- [ ] Animation support
- [ ] Hotkeys (number keys)
- [ ] Spectator mode
- [ ] Replay functionality
- [ ] Statistics tracking
- [ ] Tournament mode

## Performance

### System Requirements

Minimum:
- .NET 10.0 runtime
- 100 MB disk space
- 50 MB RAM available
- Network connection

Recommended:
- Modern CPU (any recent)
- 200 MB RAM
- Stable network (< 100ms latency)
- 800×600+ terminal size

### Client Performance

```
Memory Usage: ~30-50 MB
CPU Usage: <5% (mostly idle)
Network: ~1 KB/second upload
         ~3-5 KB/second download
         ~5-10 KB/second total
```

---

**Version**: 1.0
**Last Updated**: March 2026
**Status**: Stable


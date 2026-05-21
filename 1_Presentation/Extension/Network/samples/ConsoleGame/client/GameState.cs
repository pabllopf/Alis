

using System;
using System.Collections.Generic;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    ///     Local game state for the client
    /// </summary>
    public class GameState
    {
        /// <summary>
        ///     Initializes a new instance of the GameState class
        /// </summary>
        public GameState()
        {
            Arena = new Arena();
            Players = new Dictionary<string, PlayerData>();
            EventLog = new List<GameEvent>();
            LastUpdateTick = 0;
            CurrentTurnPlayerId = string.Empty;
            CurrentTurnPlayerName = "No one";
            TurnTicksRemaining = 0;
        }

        /// <summary>
        ///     Gets or sets the arena
        /// </summary>
        public Arena Arena { get; set; }

        /// <summary>
        ///     Gets or sets the players
        /// </summary>
        public Dictionary<string, PlayerData> Players { get; set; }

        /// <summary>
        ///     Gets or sets the local player id
        /// </summary>
        public string LocalPlayerId { get; set; }

        /// <summary>
        ///     Gets or sets the game events log
        /// </summary>
        public List<GameEvent> EventLog { get; set; }

        /// <summary>
        ///     Gets or sets the last update tick
        /// </summary>
        public long LastUpdateTick { get; set; }

        /// <summary>
        ///     Gets or sets the player id that currently has the turn.
        /// </summary>
        public string CurrentTurnPlayerId { get; set; }

        /// <summary>
        ///     Gets or sets the player name that currently has the turn.
        /// </summary>
        public string CurrentTurnPlayerName { get; set; }

        /// <summary>
        ///     Gets or sets remaining ticks for the current turn.
        /// </summary>
        public int TurnTicksRemaining { get; set; }

        /// <summary>
        ///     Gets or sets the last server message (feedback/errors)
        /// </summary>
        public string LastServerMessage { get; set; } = "";

        /// <summary>
        ///     Gets or sets the last server message timestamp
        /// </summary>
        public long LastServerMessageTime { get; set; } = 0;

        /// <summary>
        ///     Updates player position
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        public void UpdatePlayerPosition(string playerId, int x, int y)
        {
            if (Players.TryGetValue(playerId, out PlayerData player))
            {
                player.X = x;
                player.Y = y;
            }
        }

        /// <summary>
        ///     Updates player health
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="health">The health</param>
        public void UpdatePlayerHealth(string playerId, int health)
        {
            if (Players.TryGetValue(playerId, out PlayerData player))
            {
                player.Health = Math.Max(0, health);
                if (player.Health == 0)
                {
                    player.IsAlive = false;
                }
            }
        }

        /// <summary>
        ///     Adds event to log
        /// </summary>
        /// <param name="gameEvent">The game event</param>
        public void AddEvent(GameEvent gameEvent)
        {
            EventLog.Add(gameEvent);
            if (EventLog.Count > 100)
            {
                EventLog.RemoveAt(0);
            }
        }
    }
}
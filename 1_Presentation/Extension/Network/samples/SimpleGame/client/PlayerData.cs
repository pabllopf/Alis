namespace Alis.Extension.Network.Sample.SimpleGame.Client
{
    /// <summary>
    /// Player data
    /// </summary>
    public class PlayerData
    {
        /// <summary>
        /// Gets or sets the player id
        /// </summary>
        public string PlayerId { get; set; }
        
        /// <summary>
        /// Gets or sets the player name
        /// </summary>
        public string PlayerName { get; set; }
        
        /// <summary>
        /// Gets or sets the x position
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// Gets or sets the y position
        /// </summary>
        public int Y { get; set; }
        
        /// <summary>
        /// Gets or sets the health
        /// </summary>
        public int Health { get; set; }
        
        /// <summary>
        /// Gets or sets the max health
        /// </summary>
        public int MaxHealth { get; set; }
        
        /// <summary>
        /// Gets or sets the level
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// Gets or sets the experience
        /// </summary>
        public int Experience { get; set; }
        
        /// <summary>
        /// Gets or sets the score
        /// </summary>
        public int Score { get; set; }
        
        /// <summary>
        /// Gets or sets the kills
        /// </summary>
        public int Kills { get; set; }
        
        /// <summary>
        /// Gets or sets the deaths
        /// </summary>
        public int Deaths { get; set; }
        
        /// <summary>
        /// Gets or sets if the player is alive
        /// </summary>
        public bool IsAlive { get; set; }
        
        /// <summary>
        /// Gets or sets the last action time
        /// </summary>
        public long LastActionTime { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the PlayerData class
        /// </summary>
        public PlayerData()
        {
            MaxHealth = 100;
            Health = 100;
            Level = 1;
            Experience = 0;
            Score = 0;
            Kills = 0;
            Deaths = 0;
            IsAlive = true;
            LastActionTime = 0;
        }
    }
}
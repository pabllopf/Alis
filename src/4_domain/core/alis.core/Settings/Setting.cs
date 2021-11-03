using Alis.Core.Settings.Configurations;

namespace Alis.Core.Settings
{
    /// <summary>
    /// The setting class
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// Gets or sets the value of the debug
        /// </summary>
        public Debug Debug { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the general
        /// </summary>
        public General General { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the graphic
        /// </summary>
        public Graphic Graphic { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the input
        /// </summary>
        public Input Input { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the particle
        /// </summary>
        public Particle Particle { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the physics
        /// </summary>
        public Physics Physics { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the quality
        /// </summary>
        public Quality Quality { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the time
        /// </summary>
        public Time Time { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the window
        /// </summary>
        public Window Window { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the game object
        /// </summary>
        public GameObject GameObject { get; set; } = new();

        /// <summary>
        /// Gets or sets the value of the scene
        /// </summary>
        public Scene Scene { get; set; } = new();
    }
}
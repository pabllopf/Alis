namespace Alis.Core.Settings.Configurations
{
    /// <summary>
    /// The game object class
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Gets or sets the value of the max components
        /// </summary>
        public int MaxComponents { get; set; } = 64;

        /// <summary>
        /// Gets or sets the value of the has duplicate components
        /// </summary>
        public bool HasDuplicateComponents { get; set; }

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            MaxComponents = 64;
            HasDuplicateComponents = false;
        }
    }
}
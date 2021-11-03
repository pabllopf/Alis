namespace Alis.Core.Settings.Configurations
{
    /// <summary>
    /// The graphic class
    /// </summary>
    public class Graphic
    {
        /// <summary>
        /// Gets or sets the value of the max elements render
        /// </summary>
        public int MaxElementsRender { get; set; } = 128;

        /// <summary>
        /// Resets this instance
        /// </summary>
        public void Reset()
        {
            MaxElementsRender = 128;
        }
    }
}
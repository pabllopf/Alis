
namespace Alis.Editor
{
    /// <summary>Info context </summary>
    public class Info
    {
        /// <summary>The platform</summary>
        private Platform platform;

        /// <summary>The architecture</summary>
        private Architecture architecture;

        /// <summary>The graphics</summary>
        private Graphics graphics;

        /// <summary>Initializes a new instance of the <see cref="Info" /> class.</summary>
        /// <param name="platform">The platform.</param>
        /// <param name="architecture">The architecture.</param>
        /// <param name="graphics">The graphics.</param>
        public Info(Platform platform, Architecture architecture, Graphics graphics)
        {
            this.platform = platform;
            this.architecture = architecture;
            this.graphics = graphics;
        }

        /// <summary>Gets or sets the platform.</summary>
        /// <value>The platform.</value>
        public Platform Platform { get => platform; set => platform = value; }
        
        /// <summary>Gets or sets the architecture.</summary>
        /// <value>The architecture.</value>
        public Architecture Architecture { get => architecture; set => architecture = value; }

        /// <summary>Gets or sets the graphics.</summary>
        /// <value>The graphics.</value>
        public Graphics Graphics { get => graphics; set => graphics = value; }
    }
}

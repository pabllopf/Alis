
namespace Alis.Editor
{
    public class Info
    {
        /// <summary>The platform</summary>
        private Platform platform;

        /// <summary>The architecture</summary>
        private Architecture architecture;

        /// <summary>The graphics</summary>
        private Graphics graphics;

        public Info(Platform platform, Architecture architecture, Graphics graphics)
        {
            this.platform = platform;
            this.architecture = architecture;
            this.graphics = graphics;
        }

        public Platform Platform { get => platform; set => platform = value; }
        public Architecture Architecture { get => architecture; set => architecture = value; }
        public Graphics Graphics { get => graphics; set => graphics = value; }
    }
}

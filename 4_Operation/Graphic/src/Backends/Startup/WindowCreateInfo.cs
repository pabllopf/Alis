using Alis.Core.Graphic.Backends.SDL2;

namespace Alis.Core.Graphic.Backends.Startup
{
    /// <summary>
    /// The window create info
    /// </summary>
    public struct WindowCreateInfo
    {
        /// <summary>
        /// The 
        /// </summary>
        public int X;
        /// <summary>
        /// The 
        /// </summary>
        public int Y;
        /// <summary>
        /// The window width
        /// </summary>
        public int WindowWidth;
        /// <summary>
        /// The window height
        /// </summary>
        public int WindowHeight;
        /// <summary>
        /// The window initial state
        /// </summary>
        public WindowState WindowInitialState;
        /// <summary>
        /// The window title
        /// </summary>
        public string WindowTitle;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowCreateInfo"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="windowWidth">The window width</param>
        /// <param name="windowHeight">The window height</param>
        /// <param name="windowInitialState">The window initial state</param>
        /// <param name="windowTitle">The window title</param>
        public WindowCreateInfo(
            int x,
            int y,
            int windowWidth,
            int windowHeight,
            WindowState windowInitialState,
            string windowTitle)
        {
            X = x;
            Y = y;
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
            WindowInitialState = windowInitialState;
            WindowTitle = windowTitle;
        }
    }
}

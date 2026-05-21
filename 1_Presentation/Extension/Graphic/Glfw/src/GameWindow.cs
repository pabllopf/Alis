

using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw
{
    /// <inheritdoc cref="NativeWindow" />
    public class GameWindow : NativeWindow
    {
        /// <inheritdoc cref="NativeWindow()" />
        public GameWindow()
        {
        }

        /// <inheritdoc cref="NativeWindow(int, int, string)" />
        public GameWindow(int width, int height, string title) : base(width, height, title)
        {
        }

        /// <inheritdoc cref="NativeWindow(int, int, string, Monitor, Window)" />
        public GameWindow(int width, int height, string title, Monitor monitor, Window share) : base(width, height,
            title, monitor, share)
        {
        }
    }
}
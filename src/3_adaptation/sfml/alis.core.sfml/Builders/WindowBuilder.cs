using System.Numerics;
using Alis.Core.Entities;
using Alis.Core.Settings.Configurations;
using Alis.FluentApi;

namespace Alis.Core.Sfml.Builders
{
    /// <summary>
    /// The window builder class
    /// </summary>
    /// <seealso cref="IBuild{Window}"/>
    /// <seealso cref="IResolution{WindowBuilder, int, int}"/>
    public class WindowBuilder :
        IBuild<Window>,
        IResolution<WindowBuilder, int, int>
    {
        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The window</returns>
        public Window Build()
        {
            return Game.Setting.Window;
        }

        /// <summary>
        /// Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The window builder</returns>
        public WindowBuilder Resolution(int x, int y)
        {
            Game.Setting.Window.Resolution = new Vector2(x, y);
            return this;
        }

        /// <summary>
        /// Screens the mode using the specified screen mode
        /// </summary>
        /// <param name="screenMode">The screen mode</param>
        /// <returns>The window builder</returns>
        public WindowBuilder ScreenMode(ScreenMode screenMode)
        {
            Game.Setting.Window.ScreenMode = screenMode;
            return this;
        }
    }
}
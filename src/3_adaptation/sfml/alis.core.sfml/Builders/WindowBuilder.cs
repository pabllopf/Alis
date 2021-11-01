using System.Numerics;
using Alis.Core.Entities;
using Alis.Core.Settings.Configurations;
using Alis.FluentApi;

namespace Alis.Core.Sfml.Builders
{
    public class WindowBuilder :
        IBuild<Window>,
        IResolution<WindowBuilder, int, int>
    {
        public Window Build()
        {
            return Game.Setting.Window;
        }

        public WindowBuilder Resolution(int x, int y)
        {
            Game.Setting.Window.Resolution = new Vector2(x, y);
            return this;
        }

        public WindowBuilder ScreenMode(ScreenMode screenMode)
        {
            Game.Setting.Window.ScreenMode = screenMode;
            return this;
        }
    }
}
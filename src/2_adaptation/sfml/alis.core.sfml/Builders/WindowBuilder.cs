namespace Alis.Core.Sfml.Builders
{
    using FluentApi;
    using Settings.Configurations;

    public class WindowBuilder : 
        IBuild<Window>,
        IResolution<WindowBuilder, int, int>
    {
        public WindowBuilder Resolution(int x, int y)
        {
            Game.Setting.Window.Resolution = new System.Numerics.Vector2(x, y);
            return this;
        }

        public Window Build() => Game.Setting.Window;
    }
}

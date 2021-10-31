namespace Alis.Core.Settings.Configurations
{
    using Models;
    using System.Numerics;

    public class Window
    {
        public Vector2 Resolution { get; set; } = new Vector2(1024, 768);

        public ScreenMode ScreenMode { get; set; } = ScreenMode.Default;

        public void Reset() 
        {
            Resolution = new Vector2(1024, 768);
            ScreenMode = ScreenMode.Default;
        }
    }
}

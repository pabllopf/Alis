using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Windowing.Desktop;

namespace Alis.Core.OpenGL
{
    public class VideoGame : GameWindow
    {
        private GameWindowSettings gameWindowSettings;

        private NativeWindowSettings nativeWindowSettings;

        public VideoGame(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
            this.gameWindowSettings = gameWindowSettings;
            this.nativeWindowSettings = nativeWindowSettings;


            gameWindowSettings.UpdateFrequency = 60;
            gameWindowSettings.RenderFrequency = 60;
        }


        public override void Run()
        {
            base.Run();
        }

        public override void ProcessEvents()
        {
            base.ProcessEvents();
        }

    }
}

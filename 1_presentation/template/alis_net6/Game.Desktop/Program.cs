using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Game.Desktop
{
    public static class Program
    {
        private static float red, green, blue;
        
        public static void Main(string[] args)
        {
            
            
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "LearnOpenTK - Creating a Window",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
                
            };
            
            var gameWindowSettings = new GameWindowSettings()
            {
                
            };

            Window windows;
            
            using (windows =  new Window(gameWindowSettings, nativeWindowSettings))
            {
                windows.RenderFrame += WindowsOnRenderFrame;
                Console.WriteLine("Version: " + GL.GetString(StringName.Version));
                windows.Run();
            }
            
            
            Console.WriteLine("pass");
            
        }

        private static void WindowsOnRenderFrame(FrameEventArgs obj)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            OpenTK.Graphics.ES20.GL.ClearColor(red, green, blue, 1.0f);
            
            red += 0.01f;
            if (red >= 1.0f)
                red -= 1.0f;
            green += 0.02f;
            if (green >= 1.0f)
                green -= 1.0f;
            blue += 0.03f;
            if (blue >= 1.0f)
                blue -= 1.0f;
        }
    }
}
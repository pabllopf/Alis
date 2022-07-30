using System;
using OpenTK.Graphics.ES30;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Alis.Template.Game.Desktop
{
    /// <summary>
    /// The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The blue
        /// </summary>
        private static float red, green, blue;
        
        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
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

        /// <summary>
        /// Windowses the on render frame using the specified obj
        /// </summary>
        /// <param name="obj">The obj</param>
        private static void WindowsOnRenderFrame(FrameEventArgs obj)
        {
            
        }
    }
}
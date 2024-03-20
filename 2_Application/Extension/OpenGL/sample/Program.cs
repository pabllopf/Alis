using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.OpenGL.Enums;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.OpenGL.Sample
{
    public static class Program
    {
        public static void Main()
        {
            IntPtr window = default(IntPtr);
            IntPtr context = default(IntPtr);

            TriangleSample triangleSample = new TriangleSample();
            CubeSample cubeSample = new CubeSample();
            
            Console.WriteLine("Enter the number of the sample you want to run:");
            Console.WriteLine("1. Triangle Sample");
            Console.WriteLine("2. Cube Sample");
            int sampleNumber = Convert.ToInt32(Console.ReadLine());

            switch (sampleNumber)
            {
                case 1:
                    window = triangleSample.Initialize(out context);
                    break;
                case 2:
                    window = cubeSample.Initialize(out context);
                    break;
            }
            
            // Main loop
            bool running = true;
            while (running)
            {
                // Event handling
                while (Sdl.PollEvent(out Event evt) != 0)
                {
                    if (evt.type == EventType.Quit)
                    {
                        running = false;
                    }
                }

                // Clear the screen
                Gl.GlClear(ClearBufferMask.ColorBufferBit);
                // Draw the triangle
                switch (sampleNumber)
                {
                    case 1:
                        triangleSample.Draw();
                        break;
                    case 2:
                        cubeSample.Draw();
                        break;
                }
                
                // Swap the buffers to display the triangle
                Sdl.SwapWindow(window);
            }

            // Cleanup SDL
            Sdl.DeleteContext(context);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
        }
    }
}
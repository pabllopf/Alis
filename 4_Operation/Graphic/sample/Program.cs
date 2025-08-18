using System;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Core.Graphic.Sample.Samples;

namespace Alis.Core.Graphic.Sample
{

    /// <summary>
    /// The program class
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        static void Main()
        {
            INativePlatform platform;
#if OSX
            platform = new Alis.Core.Graphic.Platforms.Osx.MacNativePlatform();
#elif WIN
            platform = new Alis.Core.Graphic.Platforms.Win.WinNativePlatform();
#elif LINUX
            platform = new Alis.Core.Graphic.Platforms.LinuxNativePlatform();
#else
            throw new Exception("Sistema operativo no soportado");
#endif
            
            Console.WriteLine("Elige el ejemplo a mostrar:");
            Console.WriteLine("0: Fondo rojo");
            Console.WriteLine("1: Triángulo blanco");
            Console.WriteLine("2: Cubo (vacío)");
            Console.WriteLine("3: Cuadrado sin rellenar");
            Console.WriteLine("4: Textura personalizada (BMP)");
            Console.Write("Opción: ");
            int option = 0;
            string input = Console.ReadLine();
            int.TryParse(input, out option);
            IExample example = option switch {
                1 => new TriangleExample(),
                2 => new CubeExample(),
                3 => new SquareUnfilledExample(),
                4 => new TextureSampleCustomBmpExample(),
                _ => new SimpleRedExample()
            };
            
            platform.Initialize(800, 600, "C# + OpenGL Platform");
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);
            
            example.Initialize();
            platform.ShowWindow();
            bool running = true;
            while (running)
            {
                running = platform.PollEvents();
                if (platform.TryGetLastKeyPressed(out ConsoleKey key))
                {
                    Console.WriteLine($"Tecla pulsada: {key}");
                }
                example.Draw();
                platform.SwapBuffers();
                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Console.WriteLine($"OpenGL error tras flushBuffer: 0x{glError:X}");
                }
            }
            example.Cleanup();
            platform.Cleanup();
        }
    }
}
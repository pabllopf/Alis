using System;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Sample.Platform;
using Alis.Core.Graphic.Sample.Platform.OSX;
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
            platform = new MacNativePlatform();
#elif WIN
            platform = new Win32NativePlatform();
#elif LINUX
            platform = new LinuxNativePlatform();
#else
            throw new PlatformNotSupportedException("Sistema operativo no soportado");
#endif
            platform.Initialize(800, 600, "C# + OpenGL Platform");
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);
            Console.WriteLine("Elige el ejemplo a mostrar:");
            Console.WriteLine("0: Fondo rojo");
            Console.WriteLine("1: Triángulo blanco");
            Console.WriteLine("2: Cubo (vacío)");
            Console.Write("Opción: ");
            int option = 0;
            var input = Console.ReadLine();
            int.TryParse(input, out option);
            IExample example = option switch {
                1 => new TriangleExample(),
                2 => new CubeExample(),
                _ => new SimpleRedExample()
            };
            example.Initialize();
            platform.ShowWindow();
            bool running = true;
            while (running)
            {
                running = platform.PollEvents();
                if (platform.TryGetLastKeyPressed(out var key))
                {
                    Console.WriteLine($"Tecla pulsada: {key}");
                }
                example.Draw();
                platform.SwapBuffers();
                var glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Console.WriteLine($"OpenGL error tras flushBuffer: 0x{glError:X}");
                }
                System.Threading.Thread.Sleep(10);
            }
            example.Cleanup();
            platform.Cleanup();
        }
    }
}
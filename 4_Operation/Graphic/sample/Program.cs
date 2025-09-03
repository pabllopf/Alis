using System;
using Alis.Core.Aspect.Logging;
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
            platform = new Alis.Core.Graphic.Platforms.Linux.LinuxNativePlatform();
#else
            throw new Exception("Sistema operativo no soportado");
#endif
            
            Logger.Info("Elige el ejemplo a mostrar:");
            Logger.Info("0: Fondo rojo");
            Logger.Info("1: Triángulo blanco");
            Logger.Info("2: Cubo (vacío)");
            Logger.Info("3: Cuadrado sin rellenar");
            Logger.Info("4: Textura personalizada (BMP)");
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
            
            bool ok = platform.Initialize(800, 600, "C# + OpenGL Platform");
            if (!ok)
            {
                Logger.Info("No se pudo inicializar la ventana ni el contexto OpenGL. El programa se cerrará.");
                platform.Cleanup();
                return;
            }
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
                    Logger.Info($"Tecla pulsada: {key}");
                }
                example.Draw();
                platform.SwapBuffers();
                int glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Logger.Info($"OpenGL error tras flushBuffer: 0x{glError:X}");
                }
            }
            example.Cleanup();
            platform.Cleanup();
        }
    }
}
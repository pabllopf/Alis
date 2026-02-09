using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.Platforms.Web;

[assembly: SupportedOSPlatform("browser")]

namespace Alis.Sample.Web
{
    /// <summary>
    /// The test class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Gets or sets the value of the base address
        /// </summary>
        public static Uri BaseAddress { get; internal set; }
        /// <summary>
        /// Gets or sets the value of the demo
        /// </summary>
        private static MeshDemo Demo { get; set;  }
        
        /// <summary>
        /// Frames the time
        /// </summary>
        /// <param name="time">The time</param>
        /// <param name="userData">The user data</param>
        /// <returns>The int</returns>
        [UnmanagedCallersOnly]
        public static int Frame(double time, nint userData)
        {
            Demo.Render();

            return 1;
        }

        /// <summary>
        /// Gets or sets the value of the canvas width
        /// </summary>
        private static int CanvasWidth { get; set; }
        /// <summary>
        /// Gets or sets the value of the canvas height
        /// </summary>
        private static int CanvasHeight { get; set; }
        /// <summary>
        /// Canvases the resized using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public static void CanvasResized(int width, int height)
        {
            CanvasWidth = width;
            CanvasHeight = height;
            Demo?.CanvasResized(CanvasWidth, CanvasHeight);
        }

        /// <summary>
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        /// <exception cref="Exception">BindApi() failed</exception>
        /// <exception cref="Exception">ChoseConfig() failed</exception>
        /// <exception cref="Exception">ChoseConfig() returned no configs</exception>
        /// <exception cref="Exception">CreateContext() failed</exception>
        /// <exception cref="Exception">CreateWindowSurface() failed</exception>
        /// <exception cref="Exception">Display was null</exception>
        /// <exception cref="Exception">Initialize() returned false.</exception>
        /// <exception cref="Exception">MakeCurrent() failed</exception>
        public async static Task Main(string[] args)
        {
            Console.WriteLine($"Hello from dotnet!");

            IntPtr display = EGL.GetDisplay(IntPtr.Zero);
            if (display == IntPtr.Zero)
            {
                throw new Exception("Display was null");
            }

            if (!EGL.Initialize(display, out int major, out int minor))
            {
                throw new Exception("Initialize() returned false.");
            }

            int[] attributeList = new int[]
            {
                EGL.EGL_RED_SIZE  , 8,
                EGL.EGL_GREEN_SIZE, 8,
                EGL.EGL_BLUE_SIZE , 8,
                EGL.EGL_DEPTH_SIZE, 24,
                EGL.EGL_STENCIL_SIZE, 8,
                EGL.EGL_SURFACE_TYPE, EGL.EGL_WINDOW_BIT,
                EGL.EGL_RENDERABLE_TYPE, EGL.EGL_OPENGL_ES3_BIT,
                EGL.EGL_SAMPLES, 16, //MSAA, 16 samples
                EGL.EGL_NONE
            };

            IntPtr config = IntPtr.Zero;
            IntPtr numConfig = IntPtr.Zero;
            if (!EGL.ChooseConfig(display, attributeList, ref config, 1, ref numConfig))
            {
                throw new Exception("ChoseConfig() failed");
            }

            if (numConfig == IntPtr.Zero)
            {
                throw new Exception("ChoseConfig() returned no configs");
            }

            if (!EGL.BindApi(EGL.EGL_OPENGL_ES_API))
            {
                throw new Exception("BindApi() failed");
            }

            int[] ctxAttribs = new int[] { EGL.EGL_CONTEXT_CLIENT_VERSION, 3, EGL.EGL_NONE };
            IntPtr context = EGL.CreateContext(display, config, EGL.EGL_NO_CONTEXT, ctxAttribs);
            if (context == IntPtr.Zero)
            {
                throw new Exception("CreateContext() failed");
            }

            // now create the surface
            IntPtr surface = EGL.CreateWindowSurface(display, config, IntPtr.Zero, IntPtr.Zero);
            if (surface == IntPtr.Zero)
            {
                throw new Exception("CreateWindowSurface() failed");
            }

            if (!EGL.MakeCurrent(display, surface, surface, context))
            {
                throw new Exception("MakeCurrent() failed");
            }
            
            
            Music musicInfo2 = new Music
            {
                Name = "Prince Charming",
                Artist = "Metallica",
                Genre = "Rock and Metal",
                Album = "Reload",
                MusicId = Guid.NewGuid(),
                ReleaseDate = DateTime.Now
            };

            string json = JsonNativeAot.Serialize(musicInfo2);
            Console.WriteLine(json);

            Gl.Initialize(EGL.GetProcAddress);

            Interop.Initialize();
            // ArgumentNullException.ThrowIfNull(BaseAddress); // Ya no es necesario

            Demo = MeshDemo.Load();
            Demo?.CanvasResized(CanvasWidth, CanvasHeight);

            unsafe
            {
                Emscripten.RequestAnimationFrameLoop((IntPtr)(delegate* unmanaged<double, nint, int>)&Frame, nint.Zero);
            }
        }
    }
}

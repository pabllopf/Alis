//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Engine.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Alis.Editor.UI;
    using Alis.Tools;

    /// <summary>Manage the engine</summary>
    internal class Engine
    {
        /// <summary>The information</summary>
        [NotNull]
        private Info info;

        /// <summary>The arguments</summary>
        [NotNull]
        private string[] args; 

        /// <summary>Initializes a new instance of the <see cref="Engine" /> class.</summary>
        /// <param name="args">The arguments.</param>
        public Engine([NotNull] string[] args)
        {
            this.args = args;

            for (int i = 0; i < args.Length;i++) 
            {
                Logger.Log("Arg '" + i + "' " + args[i]);
            }

            info = new Info();
            Logger.Info();
        }

        /// <summary>Gets a value indicating whether [first instance].</summary>
        /// <value>
        /// <c>true</c> if [first instance]; otherwise, <c>false</c>.</value>
        [NotNull]
        private static bool FirstInstance
        {
            get
            {
                _ = new Mutex(true, Assembly.GetEntryAssembly().FullName, out bool created);
                
                if (!created) 
                {
                    Logger.Warning("You can`t open more than 1 intancie of Alis.");
                }

                return created;
            }
        }

        /// <summary>Gets the detect platform.</summary>
        /// <value>The detect platform.</value>
        [NotNull]
        private static Platform DetectPlatform 
        {
            get 
            {
                return
                    RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? Platform.Windows :
                    RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? Platform.MacOS :
                    RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? Platform.Linux :
                    Platform.Unsupported;
            }
        }

        /// <summary>Gets the detect architecture.</summary>
        /// <value>The detect architecture.</value>
        [NotNull]
        private static Architecture DetectArchitecture 
        {
            get 
            {
                return 
                    IntPtr.Size == 8 ? Architecture.X64 :
                    IntPtr.Size == 4 ? Architecture.X86 :
                    Architecture.Unsupported;
            }
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return false or true to indicate the exit value</returns>
        [return: NotNull]
        public int Start()
        {
            Logger.Log("Starting engine");

            if (!FirstInstance)
            {
                throw Logger.Error("There is already an 'Alis instance' running.");
            }

            Logger.Log("Running single instance mode.");

            Platform platform = DetectPlatform;
            if (platform.Equals(Platform.Unsupported)) 
            {
                throw Logger.Error("Platform unsupported. Please use Windows | MacOS | Linux system.");
            }

            Logger.Log("Platform = " + platform);

            Architecture architecture = DetectArchitecture;
            if (architecture.Equals(Architecture.Unsupported)) 
            {
                throw Logger.Error("unsupported architecture. Please use x86 or x64 architecture system.");
            }

            Logger.Log("Architecture = " + architecture);

            Graphics graphics = Graphics.OpenGL;
            bool opengl = Veldrid.GraphicsDevice.IsBackendSupported(Veldrid.GraphicsBackend.OpenGL);
            if (!opengl) 
            {
                throw Logger.Error("Alis use only OpenGL!. Please install the last version of OpenGL 3.0+");
            }

            Logger.Log("API Graphics = OpenGL");

            return new MainWindow(new Info(platform, architecture, graphics)).Start();
        }
    }
}
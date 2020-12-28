//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Engine.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System.Reflection;
    using System.Threading;
    using Alis.Editor.UI;
    using Alis.Editor.Utils;
  
    /// <summary>Manage the engine</summary>
    internal class Engine
    {
        /// <summary>The main window</summary>
        private MainWindow mainWindow;

        /// <summary>Initializes a new instance of the <see cref="Engine" /> class.</summary>
        /// <param name="args">The arguments.</param>
        public Engine(string[] args)
        {
            Debug.Log("Starting Alis...");
            Debug.Log(args.Length > 0 ? " > args:" + string.Join("\n", args) : string.Empty);
        }

        /// <summary>Gets a value indicating whether [first instance].</summary>
        /// <value>
        /// <c>true</c> if [first instance]; otherwise, <c>false</c>.</value>
        private static bool FirstInstance
        {
            get
            {
                _ = new Mutex(true, Assembly.GetEntryAssembly().FullName, out bool created);
                return created;
            }
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return false or true to indicate the exit value</returns>
        public int Start()
        {
            if (!FirstInstance)
            {
                Debug.Error("There is already an Alis instance running.");
                return -1;
            }

            mainWindow = new MainWindow();
            if (!mainWindow.Start()) 
            {
                Debug.Error("Failed to start the main window.");
                return -1;
            }

            return 0;
        }
    }
}

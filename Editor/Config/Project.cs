//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Project.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using System;
    using System.Diagnostics;
    using Alis.Core;
  
    /// <summary>Project define.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Project
    {
        /// <summary>The video game</summary>
        private static VideoGame videoGame;

        /// <summary>The current</summary>
        private static Project current;

        /// <summary>The name</summary>
        private string name;

        /// <summary>The directory</summary>
        private string directory;

        /// <summary>The assets path</summary>
        private string assetsPath;

        /// <summary>The configuration path</summary>
        private string configPath;

        /// <summary>The data path</summary>
        private string dataPath;

        /// <summary>The library path</summary>
        private string libraryPath;

        /// <summary>Initializes a new instance of the <see cref="Project" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="assetsPath">The assets path.</param>
        /// <param name="configPath">The configuration path.</param>
        /// <param name="dataPath">The data path.</param>
        /// <param name="libraryPath">The library path.</param>
        public Project(string name, string directory, string assetsPath, string configPath, string dataPath, string libraryPath)
        {
            this.name = name;
            this.directory = directory;
            this.assetsPath = assetsPath;
            this.configPath = configPath;
            this.dataPath = dataPath;
            this.libraryPath = libraryPath;
        }

        /// <summary>Occurs when [event handler].</summary>
        public static event EventHandler<bool> OnChangeProject;

        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        public static VideoGame VideoGame { get => videoGame; set => videoGame = value; }

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Project Current { get => current; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get => name; set => name = value; }
        
        /// <summary>Gets or sets the directory.</summary>
        /// <value>The directory.</value>
        public string Directory { get => directory; set => directory = value; }
        
        /// <summary>Gets or sets the assets path.</summary>
        /// <value>The assets path.</value>
        public string AssetsPath { get => assetsPath; set => assetsPath = value; }

        /// <summary>Gets or sets the configuration path.</summary>
        /// <value>The configuration path.</value>
        public string ConfigPath { get => configPath; set => configPath = value; }

        /// <summary>Gets or sets the data path.</summary>
        /// <value>The data path.</value>
        public string DataPath { get => dataPath; set => dataPath = value; }

        /// <summary>Gets or sets the library path.</summary>
        /// <value>The library path.</value>
        public string LibraryPath { get => libraryPath; set => libraryPath = value; }

        /// <summary>Changes the project.</summary>
        /// <param name="project">The project.</param>
        /// <param name="game">The game.</param>
        public static void ChangeProject(Project project, VideoGame game) 
        {
            current = project;
            videoGame = game;
            OnChangeProject.Invoke(null, true);
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug method</returns>
        private string GetDebuggerDisplay() => ToString();
    }
}
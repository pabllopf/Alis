//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Project.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor
{
    using Alis.Core.SFML;
    using Alis.Tools;
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Project define.</summary>
    public class Project
    {
        /// <summary>The current</summary>
        [AllowNull]
        private static Project current;

        [AllowNull]
        private static VideoGame game;

        [NotNull]
        private string name;

        /// <summary>The directory</summary>
        [NotNull]
        private string directory;

        /// <summary>The assets path</summary>
        [NotNull]
        private string assetPath;

        /// <summary>The configuration path</summary>
        [NotNull]
        private string configPath;

        /// <summary>The data path</summary>
        [NotNull]
        private string dataPath;

        /// <summary>The library path</summary>
        [NotNull]
        private string libPath;

        static Project() 
        {
            OnChange += Project_OnChange;
        }

        /// <summary>Initializes a new instance of the <see cref="Project" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="directory">The directory.</param>
        public Project(string name, string directory)
        {
            this.name = name;
            this.directory = directory;
            assetPath = directory + "/" + name + "/Assets";
            configPath = directory + "/" + name + "/Config";
            dataPath = directory + "/" + name + "/Data";
            libPath = directory + "/" + name + "/Lib";
        }

        /// <summary>Initializes a new instance of the <see cref="Project" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="assetPath">The asset path.</param>
        /// <param name="configPath">The configuration path.</param>
        /// <param name="dataPath">The data path.</param>
        /// <param name="libPath">The library path.</param>
        [JsonConstructor]
        public Project(string name, string directory, string assetPath, string configPath, string dataPath, string libPath)
        {
            this.name = name;
            this.directory = directory;
            this.assetPath = assetPath;
            this.configPath = configPath;
            this.dataPath = dataPath;
            this.libPath = libPath;
        }

        /// <summary>Occurs when [on change].</summary>
        public static event EventHandler<bool> OnChange;

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty("_Name")]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the directory.</summary>
        /// <value>The directory.</value>
        [JsonProperty("_Directory")]
        public string Directory { get => directory; set => directory = value; }

        /// <summary>Gets or sets the asset path.</summary>
        /// <value>The asset path.</value>
        [JsonProperty("_AssetPath")]
        public string AssetsPath { get => assetPath; set => assetPath = value; }

        /// <summary>Gets or sets the configuration path.</summary>
        /// <value>The configuration path.</value>
        [JsonProperty("_ConfigPath")]
        public string ConfigPath { get => configPath; set => configPath = value; }

        /// <summary>Gets or sets the data path.</summary>
        /// <value>The data path.</value>
        [JsonProperty("_DataPath")]
        public string DataPath { get => dataPath; set => dataPath = value; }
        
        /// <summary>Gets or sets the library path.</summary>
        /// <value>The library path.</value>
        [JsonProperty("_LibPath")]
        public string LibraryPath { get => libPath; set => libPath = value; }

        /// <summary>Gets or sets the video game.</summary>
        /// <value>The video game.</value>
        [JsonIgnore]
        public static VideoGame VideoGame { get => game; set => game = value; }

        /// <summary>Projects the on change.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private static void Project_OnChange(object sender, bool e) => Logger.Info();
    }
}
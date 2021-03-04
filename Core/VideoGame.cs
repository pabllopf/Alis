//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Alis.Tools;
    using System;

    /// <summary>Define your videogame./summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class VideoGame
    {
        /// <summary>The scene manager</summary>
        private SceneManager sceneManager;

        /// <summary>The configuration</summary>
        private Config config;

        /// <summary>The render</summary>
        private Render render;

        /// <summary>The input</summary>
        private Input input;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnStart;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>
        /// Contructor of videogame
        /// </summary>
        /// <param name="config">Config of videogame</param>
        [JsonConstructor()]
        public VideoGame(Config config)
        {
            this.config = config ?? new Config("AlisGame");
            sceneManager = new SceneManager();

            OnCreate += VideoGame_OnCreate;
            OnStart += VideoGame_OnStart;
            OnDestroy += VideoGame_OnDestroy;

            OnCreate?.Invoke(null, true);
        }

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scene">The scene.</param>
        public VideoGame(Config config, params Scene[] scene)
        {
            this.config = config ?? new Config("AlisGame");
            sceneManager = scene != null ? new SceneManager(new List<Scene>(scene)) : new SceneManager(); 
        }

        /// <summary>
        /// Destructor of the videogame
        /// </summary>
        ~VideoGame()
        {
            GC.Collect();
            OnDestroy?.Invoke(null, true);
            Debug.Log("Memory used after full collection: {" + GC.GetTotalMemory(true) + "}");
        }

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [JsonProperty]
        public Config Config { get => config; set => config = value; }

        /// <summary>Gets or sets the render.</summary>
        /// <value>The render.</value>
        [JsonProperty]
        public Render Render { get => render; set => render = value; }
        
        /// <summary>Gets or sets the input.</summary>
        /// <value>The input.</value>
        [JsonProperty]
        public Input Input { get => input; set => input = value; }
        public SceneManager SceneManager { get => sceneManager; set => sceneManager = value; }

        /// <summary>
        /// Start the videogame
        /// </summary>
        public void Start()
        {
            OnStart?.Invoke(null, true);
        }

        /// <summary>
        /// Update every frame the videogame
        /// </summary>
        public void Update()
        {
            
        }

        /// <summary>Videoes the game on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnCreate(object sender, bool e)
        {
            Debug.Event("Create new " + this.GetType() + " instancie. {" + this.GetHashCode() + "}");
        }

        /// <summary>Videoes the game on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnDestroy(object sender, bool e)
        {
            Debug.Event("Destroy " + this.GetType() + " instancie. {" + this.GetHashCode() + "}");
        }

        /// <summary>Videoes the game on start.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void VideoGame_OnStart(object sender, bool e)
        {
            Debug.Event("Start the videogame " + config.Name);
        }
    }
}

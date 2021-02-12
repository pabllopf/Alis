//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define the video game.</summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class VideoGame
    {
        /// <summary>The configuration</summary>
        private ConfigGame config;

        /// <summary>The scenes</summary>
        private List<Scene> scenes;

        /// <summary>The is running</summary>
        private bool isRunning;

        /// <summary>The current scene</summary>
        private Scene currentScene;
        
        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        [JsonConstructor]
        public VideoGame(ConfigGame config) 
        {
            Render.Current = new Render();
            Input.OnPressKeyOnce += Input_OnPressKeyOnce;

            this.config = config;
            scenes = new List<Scene>();

            Debug.Log("Created a new " + GetType() + "(" + config.NameProject + ").");
        }

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="scene">the scenes of game</param>
        public VideoGame(ConfigGame config, params Scene[] scene)
        {
            Render.Current = new Render();
            Input.OnPressKeyOnce += Input_OnPressKeyOnce;

            this.config = config;
            scenes = new List<Scene>(scene);

            if (scenes.Count > 0)
            {
                currentScene = scenes[0];
                currentScene.Start();
                Debug.Warning("CurrentScene: " + currentScene.Name);
            }

            Debug.Log("Created a new " + GetType() + "(" + config.NameProject + ").");
        }

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [JsonProperty]
        public ConfigGame Config { get => config; set => config = value; }

        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        [JsonProperty]
        public List<Scene> Scenes { get => scenes; set => scenes = value; }

        /// <summary>Starts this instance.</summary>
        public static void Start(string path)
        {
            Debug.Log("\n \n Init Load");
            VideoGame videoGame = LocalData.Load<VideoGame>("Data", path);
            Input.OnPressKeyOnce += Input_OnPressKeyOnce;
            videoGame.Run();
        }

        /// <summary>Adds the specified scene.</summary>
        /// <param name="scene">The scene.</param>
        public void Add(Scene scene) 
        {
            if (!scenes.Contains(scene))
            {
                Debug.Log("Added a new scene(" + scene.Name + ") in the Videogame(" + config.NameProject + ")");
                scenes.Add(scene);
                currentScene = scenes[0];
            }
            else 
            {
                Debug.Warning("This scene(" + scene.Name + ") already exists in the Videogame(" + config.NameProject + ").");
            }
        }

        /// <summary>Removes the specified scene.</summary>
        /// <param name="scene">The scene.</param>
        public void Remove(Scene scene)
        {
            if (scenes.Contains(scene))
            {
                scenes.Remove(scene);
                Debug.Log("Removed scene(" + scene.Name + ") in the Videogame(" + config.NameProject + ").");
            }
            else 
            {
                Debug.Warning("You are trying to remove a scene (" + scene.Name + ") that does not exist in the videogame(" + scene.Name + ")");
            }
        }

        /// <summary>Previews the render.</summary>
        /// <returns>Return the data.</returns>
        public byte[] PreviewRender() 
        {
            scenes.ForEach(i => i.Update());
            return Render.Current.FrameBytes();
        }

        private bool starder = false;

        /// <summary>Previews the playing.</summary>
        /// <returns> </returns>
        public byte[] PreviewPlaying() 
        {
            if (starder == false) 
            {
                starder = true;
                currentScene.Start();
            }

            if (scenes.Count > 0)
            {
                currentScene = scenes[0];
                Debug.Warning("CurrentScene: " + currentScene.Name);
            }

            Input.PollEvents();
            currentScene.Update();
            return Render.Current.FrameBytes();
        }

        /// <summary>Runs this instance.</summary>
        public void Run() 
        {
            currentScene = scenes[0];

            isRunning = true;

            currentScene.Start();

            Debug.Log("Run the videogame.");


            while (isRunning) 
            {
                Input.PollEvents();
                currentScene.Update();
                Render.Current.RenderDisplay();

                Thread.Sleep(1);
            }

            Debug.Log("Exit of videogame.");
        }

        /// <summary>Inputs the on press key once.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private static void Input_OnPressKeyOnce(object sender, SFML.Window.Keyboard.Key e)
        {
            Debug.Log(e.ToString());
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}

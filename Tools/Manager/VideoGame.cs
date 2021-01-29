//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>Define the video game.</summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class VideoGame
    {
        /// <summary>The configuration</summary>
        private ConfigGame config;

        public static void Start()
        {
            Debug.Log("\n \n Init Load");

            VideoGame videoGame = LocalData.Load<VideoGame>("Alis");
            videoGame.Run();
        }

        /// <summary>The scenes</summary>
        private List<Scene> scenes;

        /// <summary>The is running</summary>
        private bool isRunning;

        /// <summary>The current scene</summary>
        private Scene currentScene;

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        public ConfigGame Config { get => config; set => config = value; }


        /// <summary>Gets or sets the scenes.</summary>
        /// <value>The scenes.</value>
        public List<Scene> Scenes { get => scenes; set => scenes = value; }
       

        /// <summary>Initializes a new instance of the <see cref="VideoGame" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public VideoGame(ConfigGame config) 
        {
            this.config = config;
            scenes = new List<Scene>();

            Debug.Log("Created a new " + GetType() + "(" + config.NameProject + ").");
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

        /// <summary>Runs this instance.</summary>
        public void Run() 
        {
            isRunning = true;

            currentScene = scenes[0];

            currentScene.Start();

            Debug.Log("Run the videogame.");
            while (isRunning) 
            {
                currentScene.Update();
                Input.PollEvents();
            }

            Debug.Log("Exit of videogame.");
        }


        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}

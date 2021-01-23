//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System.Collections.Generic;

    /// <summary>Define the video game.</summary>
    public class VideoGame
    {
        /// <summary>The configuration</summary>
        private ConfigGame config;

        /// <summary>The scenes</summary>
        private List<Scene> scenes;

        /// <summary>The is running</summary>
        private bool isRunning;

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
            scenes.ForEach(i => i.Start());
            Debug.Log("Run the videogame.");
            while (isRunning) 
            {
                scenes.ForEach(i => i.Update());
            }

            Debug.Log("Exit of videogame.");
        }
    }
}

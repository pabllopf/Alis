//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Build your videogame
    /// </summary>
    /// <remarks>Define a videogame</remarks>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class VideoGame
    {
        /// <summary>
        /// the scenes of the videogame
        /// </summary>
        private List<Scene> scenes;

        /// <summary>
        /// the config of videogame
        /// </summary>
        private Config config;

        /// <summary>
        /// Contructor of videogame
        /// </summary>
        /// <param name="config">Config of videogame</param>
        [JsonConstructor()]
        public VideoGame(Config config)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Destructor of the videogame
        /// </summary>
        ~VideoGame()
        {
            throw new System.NotImplementedException();
        }

        public List<Scene> Scenes { get => scenes; set => scenes = value; }
        
        public Config Config { get => config; set => config = value; }



        /// <summary>
        /// Start the videogame
        /// </summary>
        public void Start()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Update every frame the videogame
        /// </summary>
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}

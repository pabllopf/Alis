//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="VideoGame.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Collections.Generic;

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

        public VideoGame()
        {
            throw new System.NotImplementedException();
        }

        public Config Config
        {
            get => default;
            set
            {
            }
        }

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
    }
}

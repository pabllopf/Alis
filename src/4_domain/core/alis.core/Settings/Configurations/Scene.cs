// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Scene.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using System.Text.Json.Serialization;
using Alis.FluentApi.Validations;

#endregion

namespace Alis.Core.Settings.Configurations
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene
    {
        #region Reset()

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            MaxScenesOfGame = 16;
            MaxGameObjectByScene = 1024;
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        public Scene()
        {
            MaxScenesOfGame = 16;
            MaxGameObjectByScene = 1024;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scene" /> class
        /// </summary>
        /// <param name="maxScenesOfGame">The max scenes of game</param>
        /// <param name="maxGameObjectByScene">The max game object by scene</param>
        [JsonConstructor]
        public Scene(NotNull<int> maxScenesOfGame, NotNull<int> maxGameObjectByScene)
        {
            MaxScenesOfGame = maxScenesOfGame.Value;
            MaxGameObjectByScene = maxGameObjectByScene.Value;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the value of the max scenes of game
        /// </summary>
        [JsonPropertyName("_MaxScenesOfGame")]
        public int MaxScenesOfGame { get; set; } = 16;

        /// <summary>
        ///     Gets or sets the value of the max game object by scene
        /// </summary>
        [JsonPropertyName("_MaxGameObjectByScene")]
        public int MaxGameObjectByScene { get; set; } = 1024;

        #endregion
    }
}
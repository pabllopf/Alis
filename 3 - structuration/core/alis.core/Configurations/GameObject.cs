// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GameObject.cs
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

using System.Text.Json.Serialization;
using Alis.Tools;

namespace Alis.Core.Configurations
{
    /// <summary>
    ///     The game object class
    /// </summary>
    public class GameObject
    {
        /// <summary>
        ///     The has duplicate components
        /// </summary>
        private bool hasDuplicateComponents;

        /// <summary>
        ///     The max components
        /// </summary>
        private int maxComponents;


        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        public GameObject()
        {
            maxComponents = 64;
            hasDuplicateComponents = false;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        /// <param name="maxComponents">The max components</param>
        /// <param name="hasDuplicateComponents">The has duplicate components</param>
        [JsonConstructor]
        public GameObject(int maxComponents, bool hasDuplicateComponents)
        {
            this.maxComponents = maxComponents;
            this.hasDuplicateComponents = hasDuplicateComponents;
        }

        /// <summary>
        ///     Gets or sets the value of the max components
        /// </summary>
        [JsonPropertyName("_MaxComponents")]
        public int MaxComponents
        {
            get
            {
                Logger.Trace($"{nameof(GameObject)}.{nameof(MaxComponents)} '{maxComponents}'");
                return maxComponents;
            }
            set
            {
                Logger.Trace($"{nameof(GameObject)}.{nameof(MaxComponents)} from '{maxComponents}' to '{value}'");
                maxComponents = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the has duplicate components
        /// </summary>
        [JsonPropertyName("_HasDuplicateComponents")]
        public bool HasDuplicateComponents
        {
            get
            {
                Logger.Trace($"{nameof(GameObject)}.{nameof(HasDuplicateComponents)} '{hasDuplicateComponents}'");
                return hasDuplicateComponents;
            }
            set
            {
                Logger.Trace(
                    $"{nameof(GameObject)}.{nameof(HasDuplicateComponents)} from '{hasDuplicateComponents}' to '{value}'");
                hasDuplicateComponents = value;
            }
        }

        /// <summary>
        ///     Resets this instance
        /// </summary>
        public void Reset()
        {
            MaxComponents = 64;
            HasDuplicateComponents = false;
            Logger.Trace();
        }
    }
}
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ScenesMap.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;


namespace Alis.Core.Ecs.Systems.Manager.Scene
{
    /// <summary>
    ///     The scenes map class
    /// </summary>
    public class ScenesMap
    {
        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>
        
        public List<int> Scenes { get; set; } = new List<int>();

        /// <summary>
        ///     Adds the scene using the specified scene id
        /// </summary>
        /// <param name="sceneId">The scene id</param>
        public void AddScene(int sceneId) => Scenes.Add(sceneId);

        /// <summary>
        ///     Removes the scene using the specified scene id
        /// </summary>
        /// <param name="sceneId">The scene id</param>
        public void RemoveScene(int sceneId) => Scenes.Remove(sceneId);

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear() => Scenes.Clear();

        /// <summary>
        ///     Loads this instance
        /// </summary>
        /// <returns>The scenes map</returns>
        public ScenesMap Load()
        {
            /*
            string pathFile = Path.Combine(Environment.CurrentDirectory, "Data", "ScenesMap.json");
            if (!File.Exists(pathFile))
            {
                string json = JsonSerializer.Serialize(this, new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });

                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data")))
                {
                    Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data"));
                }

                File.WriteAllText(pathFile, json);

                return this;
            }

            return JsonSerializer.Deserialize<ScenesMap>(File.ReadAllText(pathFile), new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            });*/

            return new ScenesMap();
        }

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public void Save()
        {
            /*
            string pathFile = Path.Combine(Environment.CurrentDirectory, "Data", "ScenesMap.json");

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data"));
            }

            string json = JsonSerializer.Serialize(this, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            });

            File.WriteAllText(pathFile, json);*/
        }
    }
}
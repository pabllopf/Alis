// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneNameMap.cs
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

using System;
using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Data.Json;
using NotImplementedException = System.NotImplementedException;

namespace Alis.Core.Ecs.System.Manager.Scene
{
    public class ScenesMap
    {
        [JsonPropertyName("_Scenes_")]
        public List<int> Scenes { get; set; } = new List<int>();
        
        public void AddScene(int sceneId) => Scenes.Add(sceneId);
        
        public void RemoveScene(int sceneId) => Scenes.Remove(sceneId);
        
        public void Clear() => Scenes.Clear();

        public ScenesMap Load()
        {
            string pathFile =  Path.Combine(Environment.CurrentDirectory, "Data", "ScenesMap.json");
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
            });
        }
        
        public void Save()
        {
            string pathFile =  Path.Combine(Environment.CurrentDirectory, "Data", "ScenesMap.json");
            
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data"));
            }
            
            string json = JsonSerializer.Serialize(this, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            });
            
            File.WriteAllText(pathFile, json);
        }
    }
}
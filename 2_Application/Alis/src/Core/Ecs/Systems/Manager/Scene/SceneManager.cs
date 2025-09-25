// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManager.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Body;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager.Scene
{
    /// <summary>
    ///     The scene manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class SceneManager : AManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public SceneManager(Context context) : base(context)
        {
            LoadedScenes = new List<Ecs.Scene>();
        }

        public SceneManager(Context context, params Ecs.Scene[] scenes ) : base(context)
        {
            LoadedScenes = new List<Ecs.Scene>(scenes);
            CurrentWorld = LoadedScenes[0];
        }
       

        /// <summary>
        ///     Gets or sets the value of the scene
        /// </summary>
        public Ecs.Scene CurrentWorld { get; set; }
        
        public List<Ecs.Scene> LoadedScenes;
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            if (CurrentWorld == null)
            {
                CurrentWorld = LoadedScenes[0];
            }
        }

        /// <summary>
        ///     Ons the save
        /// </summary>
        public override void OnSave()
        {
            /*
            Logger.Info($"Saving scene: {CurrentWorld.EntityCount}");

            string directory = Path.Combine(Environment.CurrentDirectory, "Data", "Game");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fileWorld = Path.Combine(directory, "CurrentWorld.json");
            File.WriteAllText(fileWorld, JsonSerializer.Serialize(CurrentWorld, new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            }));

            Logger.Info($"Scene saved to: {fileWorld}");
*/
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            CurrentWorld?.Update();
        }

        public void LoadScene(string gameScene)
        {
        }
        
        public void LoadScene(int id)
        {
            CurrentWorld = LoadedScenes[id];
            
            GameObjectQueryEnumerator.QueryEnumerable result = Context.SceneManager.CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnStart).IsAssignableFrom(componentType))
                    {
                        IOnStart onPressKey = (IOnStart) gameObject.Get(componentType);
                        onPressKey.OnStart(gameObject);
                    }
                }
            }
            

        }

        public void AddScene(Ecs.Scene scene)
        {
            LoadedScenes.Add(scene);
        }
    }
}
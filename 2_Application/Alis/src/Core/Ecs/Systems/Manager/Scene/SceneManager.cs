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
using Alis.Core.Aspect.Fluent.Words;
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
            CurrentWorld = new Ecs.Scene();
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
            if (LoadedScenes.Count > 0)
            {
                CurrentWorld = LoadedScenes[0];
            }
            
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IHasContext<Context>).IsAssignableFrom(componentType))
                    {
                        IHasContext<Context> onPressKey = (IHasContext<Context>) gameObject.Get(componentType);
                        onPressKey.Context = Context;
                    }
                }
            }
        }
        
        public override void OnAwake()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnAwake).IsAssignableFrom(componentType))
                    {
                        IOnAwake onPressKey = (IOnAwake) gameObject.Get(componentType);
                        onPressKey.OnAwake(gameObject);
                    }
                }
            }
        }

        public override void OnStart()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
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

        public override void OnPhysicUpdate()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnPhysicUpdate).IsAssignableFrom(componentType))
                    {
                        IOnPhysicUpdate onPressKey = (IOnPhysicUpdate) gameObject.Get(componentType);
                        onPressKey.OnPhysicUpdate(gameObject);
                    }
                }
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

        public override void OnBeforeUpdate()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnBeforeUpdate).IsAssignableFrom(componentType))
                    {
                        IOnBeforeUpdate onPressKey = (IOnBeforeUpdate) gameObject.Get(componentType);
                        onPressKey.OnBeforeUpdate(gameObject);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            CurrentWorld?.Update();
        }

        public override void OnAfterUpdate()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnAfterUpdate).IsAssignableFrom(componentType))
                    {
                        IOnAfterUpdate onPressKey = (IOnAfterUpdate) gameObject.Get(componentType);
                        onPressKey.OnAfterUpdate(gameObject);
                    }
                }
            }
        }

        public override void OnBeforeFixedUpdate()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnBeforeFixedUpdate).IsAssignableFrom(componentType))
                    {
                        IOnBeforeFixedUpdate onPressKey = (IOnBeforeFixedUpdate) gameObject.Get(componentType);
                        onPressKey.OnBeforeFixedUpdate(gameObject);
                    }
                }
            }
        }

        public override void OnFixedUpdate ()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnFixedUpdate).IsAssignableFrom(componentType))
                    {
                        IOnFixedUpdate onPressKey = (IOnFixedUpdate) gameObject.Get(componentType);
                        onPressKey.OnFixedUpdate(gameObject);
                    }
                }
            }
        }

        public override void OnAfterFixedUpdate()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnAfterFixedUpdate).IsAssignableFrom(componentType))
                    {
                        IOnAfterFixedUpdate onPressKey = (IOnAfterFixedUpdate) gameObject.Get(componentType);
                        onPressKey.OnAfterFixedUpdate(gameObject);
                    }
                }
            }
        }

        public override void OnProcessPendingChanges()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnProcessPendingChanges).IsAssignableFrom(componentType))
                    {
                        IOnProcessPendingChanges onPressKey = (IOnProcessPendingChanges) gameObject.Get(componentType);
                        onPressKey.OnProcessPendingChanges(gameObject);
                    }
                }
            }
        }
        
        public override void OnBeforeDraw()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnBeforeDraw).IsAssignableFrom(componentType))
                    {
                        IOnBeforeDraw onPressKey = (IOnBeforeDraw) gameObject.Get(componentType);
                        onPressKey.OnBeforeDraw(gameObject);
                    }
                }
            }
        }

        public override void OnDraw()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnDraw).IsAssignableFrom(componentType))
                    {
                        IOnDraw onPressKey = (IOnDraw) gameObject.Get(componentType);
                        onPressKey.OnDraw(gameObject);
                    }
                }
            }
        }

        public override void OnAfterDraw()
        {
            GameObjectQueryEnumerator.QueryEnumerable result = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnAfterDraw).IsAssignableFrom(componentType))
                    {
                        IOnAfterDraw onPressKey = (IOnAfterDraw) gameObject.Get(componentType);
                        onPressKey.OnAfterDraw(gameObject);
                    }
                }
            }
        }


        public override void OnExit()
        {
            GameObjectQueryEnumerator.QueryEnumerable result2 = CurrentWorld.Query<Not<RigidBody>>().EnumerateWithEntities();
            foreach (GameObject gameObject in result2)
            {
                foreach (ComponentId component in gameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnExit).IsAssignableFrom(componentType))
                    {
                        IOnExit onPressKey = (IOnExit) gameObject.Get(componentType);
                        onPressKey.OnExit(gameObject);
                    }
                }
            }
        }


        public void LoadScene(string gameScene)
        {
        }
        
        public void LoadScene(int id)
        {
            CurrentWorld = LoadedScenes[id];
            
            

        }

        public void AddScene(Ecs.Scene scene)
        {
            LoadedScenes.Add(scene);
        }
    }
}
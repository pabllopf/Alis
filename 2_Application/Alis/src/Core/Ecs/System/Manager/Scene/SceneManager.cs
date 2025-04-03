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
using System.IO;
using System.Reflection;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Core.Ecs.System.Manager.Scene
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
        /// <param name="context"></param>
        public SceneManager(Context context) : base(context)
        {
            Scenes = new List<Entity.Scene>();
            CurrentScene = new Entity.Scene();
            ScenesMap = new ScenesMap();
        }

        /// <summary>
        ///     Gets or sets the value of the scenes map
        /// </summary>
        [JsonPropertyName("_ScenesMap_")]
        public ScenesMap ScenesMap { get; set; }

        /// <summary>
        ///     Gets or sets the value of the current scene
        /// </summary>
        [JsonPropertyName("_CurrentScene_", true, true)]
        public Entity.Scene CurrentScene { get; set; }

        /// <summary>
        ///     Gets or sets the value of the scenes
        /// </summary>

        [JsonPropertyName("_Scenes_")]
        public List<Entity.Scene> Scenes { get; set; }

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public override void OnEnable()
        {
            CurrentScene.OnEnable();
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            ScenesMap.Scenes = new List<int>();

            for (int i = 0; i < Scenes.Count; i++)
            {
                ScenesMap.Scenes.Add(i);
            }

            ScenesMap = ScenesMap.Load();

            string versionCurrent = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace('.', '_');
            for (int i = 0; i < ScenesMap.Scenes.Count; i++)
            {
                string file = Path.Combine(Path.Combine(Environment.CurrentDirectory ?? throw new InvalidOperationException(), "Data", "Scenes"), $"Alis_{versionCurrent}_Scene_{i}.json");

                if (!File.Exists(file))
                {
                    string gameJson = JsonSerializer.Serialize(Scenes[i], new JsonOptions
                    {
                        DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                        SerializationOptions = JsonSerializationOptions.Default
                    });

                    if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes")))
                    {
                        Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes"));
                    }

                    File.WriteAllText(file, gameJson);
                }

                Scenes[i].SetContext(Context);
            }

            if (Scenes.Count > 0)
            {
                CurrentScene = Scenes[0];
                CurrentScene.SetContext(Context);
                CurrentScene.OnInit();
            }
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public override void OnAwake()
        {
            CurrentScene.OnAwake();
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            CurrentScene.OnStart();
        }

        /// <summary>
        ///     Saves this instance
        /// </summary>
        public override void OnSave()
        {
            ScenesMap.Scenes = new List<int>();
            string versionCurrent = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace('.', '_');
            for (int i = 0; i < Scenes.Count; i++)
            {
                Scenes[i].SetContext(Context);

                string gameJson = JsonSerializer.Serialize(Scenes[i], new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });

                string file = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes"), $"Alis_{versionCurrent}_Scene_{i}.json");

                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes")))
                {
                    Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes"));
                }

                File.WriteAllText(file, gameJson);

                ScenesMap.Scenes.Add(i);
                ScenesMap.Save();
            }
        }

        /// <summary>
        ///     Ons the save using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public override void OnSave(string path)
        {
            ScenesMap.Scenes = new List<int>();
            string versionCurrent = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace('.', '_');
            for (int i = 0; i < Scenes.Count; i++)
            {
                Scenes[i].SetContext(Context);

                string gameJson = JsonSerializer.Serialize(Scenes[i], new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });

                string file = Path.Combine(Path.Combine(path, "Data", "Scenes"), $"Alis_{versionCurrent}_Scene_{i}.json");

                if (!Directory.Exists(Path.Combine(path, "Data", "Scenes")))
                {
                    Directory.CreateDirectory(Path.Combine(path, "Data", "Scenes"));
                }

                File.WriteAllText(file, gameJson);

                ScenesMap.Scenes.Add(i);
                ScenesMap.Save();
            }
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            CurrentScene.OnBeforeUpdate();
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            CurrentScene.OnUpdate();
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public override void OnAfterUpdate()
        {
            CurrentScene.OnAfterUpdate();
        }

        /// <summary>
        ///     Ons the process pending changes
        /// </summary>
        public override void OnProcessPendingChanges()
        {
            CurrentScene.OnProcessPendingChanges();
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public override void OnBeforeFixedUpdate()
        {
            CurrentScene.OnBeforeFixedUpdate();
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public override void OnFixedUpdate()
        {
            CurrentScene.OnFixedUpdate();
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public override void OnAfterFixedUpdate()
        {
            CurrentScene.OnAfterFixedUpdate();
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public override void OnDispatchEvents()
        {
            CurrentScene.OnDispatchEvents();
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public override void OnCalculate()
        {
            CurrentScene.OnCalculate();
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public override void OnDraw()
        {
            CurrentScene.OnDraw();
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public override void OnGui()
        {
            CurrentScene.OnGui();
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public override void OnDisable()
        {
            CurrentScene.OnDisable();
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public override void OnReset()
        {
            CurrentScene.OnReset();
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public override void OnStop()
        {
            CurrentScene.OnStop();
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            CurrentScene.OnExit();
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public override void OnDestroy()
        {
            CurrentScene.OnDestroy();
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="scene">The component</param>
        public void Add<T>(T scene) where T : Entity.Scene
        {
            scene.SetContext(Context);
            Scenes.Add(scene);
        }

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : Entity.Scene
        {
            Scenes.Remove(component);
        }

        /// <summary>
        ///     Destroys the game object using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public void DestroyGameObject(GameObject gameObject)
        {
            CurrentScene.Remove(gameObject);
        }

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : Entity.Scene => (T) Scenes.Find(i => i.GetType() == typeof(T));

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : Entity.Scene => Get<T>() != null;

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : Entity.Scene
        {
            Scenes.Clear();
        }

        /// <summary>
        ///     Loads the scene using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void LoadScene(Entity.Scene scene)
        {
            CurrentScene.OnStop();
            CurrentScene.OnExit();

            Entity.Scene selectedScene = Scenes.Find(i => i.Name.Equals(scene.Name));
            string versionCurrent = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace('.', '_');
            string fileCurrentScene = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes"), $"Alis_{versionCurrent}_Scene_{Scenes.IndexOf(selectedScene)}.json");

            CurrentScene = JsonSerializer.Deserialize<Entity.Scene>(
                File.ReadAllText(fileCurrentScene)
                , new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });

            Scenes[Scenes.IndexOf(selectedScene)] = CurrentScene;

            CurrentScene.SetContext(Context);
            CurrentScene.OnInit();
            CurrentScene.OnAwake();
            CurrentScene.OnStart();
        }

        /// <summary>
        ///     Reloads the scene using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        public void ReloadScene(Entity.Scene scene)
        {
            CurrentScene = scene;
        }

        /// <summary>
        ///     Loads the scene using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        public void LoadScene(string name)
        {
            CurrentScene.OnStop();
            CurrentScene.OnExit();

            Entity.Scene selectedScene = Scenes.Find(i => i.Name.Equals(name));
            string versionCurrent = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace('.', '_');
            string fileCurrentScene = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes"), $"Alis_{versionCurrent}_Scene_{Scenes.IndexOf(selectedScene)}.json");

            CurrentScene = JsonSerializer.Deserialize<Entity.Scene>(
                File.ReadAllText(fileCurrentScene)
                , new JsonOptions
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                    SerializationOptions = JsonSerializationOptions.Default
                });

            Scenes[Scenes.IndexOf(selectedScene)] = CurrentScene;

            CurrentScene.SetContext(Context);
            CurrentScene.OnInit();
            CurrentScene.OnAwake();
            CurrentScene.OnStart();
        }

        /// <summary>
        ///     Loads the scene using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void LoadScene(int index)
        {
            CurrentScene.OnStop();
            CurrentScene.OnExit();
            Entity.Scene selectedScene = Scenes[index];

            string versionCurrent = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace('.', '_');
            string fileCurrentScene = Path.Combine(Path.Combine(Environment.CurrentDirectory, "Data", "Scenes"), $"Alis_{versionCurrent}_Scene_{Scenes.IndexOf(selectedScene)}.json");

            CurrentScene = JsonSerializer.Deserialize<Entity.Scene>(File.ReadAllText(fileCurrentScene), new JsonOptions
            {
                DateTimeFormat = "yyyy-MM-dd HH:mm:ss",
                SerializationOptions = JsonSerializationOptions.Default
            });

            Scenes[index] = CurrentScene;

            CurrentScene.SetContext(Context);
            CurrentScene.OnInit();
            CurrentScene.OnAwake();
            CurrentScene.OnStart();
        }
    }
}
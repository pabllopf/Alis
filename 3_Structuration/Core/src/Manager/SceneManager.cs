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

using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Entity;

namespace Alis.Core.Manager
{
    /// <summary>
    /// Scene manager
    /// </summary>
    public class SceneManager : ManagerBase
    {
        /// <summary>
        /// Scene list
        /// </summary>
        public List<Scene> Scenes = new List<Scene>();

        /// <summary>
        /// The current scene
        /// </summary>
        private Scene currentScene;

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManager"/> class
        /// </summary>
        public SceneManager()
        {
            Scenes = new List<Scene>();
            currentScene = new Scene();
        }

        /// <summary>
        /// Inits this instance
        /// </summary>
        internal override void Init()
        {
            if (Scenes.Count > 0)
            {
                currentScene = Scenes[0];
            }
            currentScene.Init();
        }

        /// <summary>
        /// Awakes this instance
        /// </summary>
        public override void Awake()
        {
            for (int i = 0; i < Scenes.Count; i++)
            {
                Logger.Log($"SceneManager::Awake::Scene::'{Scenes[i].Name}'");
            }
            
            Logger.Log($"SceneManager::Awake::currentScene::'{currentScene.Name}'");
            
            currentScene.Awake();
        }
        
        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start() => currentScene.Start();
        
        /// <summary>
        /// Before the update
        /// </summary>
        public override void BeforeUpdate() => currentScene.BeforeUpdate();

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update() => currentScene.Update();

        /// <summary>
        /// Afters the update
        /// </summary>
        public override void AfterUpdate() => currentScene.AfterUpdate();

        /// <summary>
        /// Dispatches the events
        /// </summary>
        public override void DispatchEvents() => currentScene.DispatchEvents();
        
        /// <summary>
        /// Fix the update
        /// </summary>
        public override void FixedUpdate() => currentScene.FixedUpdate();

        /// <summary>
        /// Resets this instance
        /// </summary>
        public override void Reset() => currentScene.Reset();
        
        /// <summary>
        /// Stops this instance
        /// </summary>
        public override void Stop() => currentScene.Stop();

        /// <summary>
        /// Exits this instance
        /// </summary>
        public override void Exit() => currentScene.Exit();
    }
}

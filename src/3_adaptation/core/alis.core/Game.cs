// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Game.cs
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

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Alis.Core.Entities;
using Alis.Core.Systems;

namespace Alis.Core
{
    /// <summary>Define the main logic of game made with ALIS.</summary>
    public class Game
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Game" /> class
        /// </summary>
        public Game()
        {
            IsRunning = true;
            InputSystem = new InputSystem();
            SceneSystem = new SceneSystem(new List<Scene>(){new Scene("Default", new List<GameObject>())});
            PhysicsSystem = new PhysicsSystem();
            RenderSystem = new RenderSystem();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Game" /> class
        /// </summary>
        /// <param name="isRunning">The is running</param>
        /// <param name="renderSystem">The render system</param>
        /// <param name="sceneSystem">The scene system</param>
        [JsonConstructor]
        public Game(bool isRunning, InputSystem inputSystem, RenderSystem renderSystem, SceneSystem sceneSystem,
            PhysicsSystem physicsSystem)
        {
            IsRunning = isRunning;
            InputSystem = inputSystem;
            SceneSystem = sceneSystem;
            PhysicsSystem = physicsSystem;
            RenderSystem = renderSystem;
        }

        /// <summary>Gets a value indicating whether this instance is running.</summary>
        /// <value>
        ///     <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsRunning")]
        private static bool IsRunning { get; set; } = true;

        /// <summary>Gets or sets the render system.</summary>
        /// <value>The render system.</value>
        [JsonIgnore]
        public RenderSystem RenderSystem { get; protected set; }

        /// <summary>Gets or sets the scene system.</summary>
        /// <value>The scene system.</value>
        [JsonIgnore]
        public SceneSystem SceneSystem { get; set; }

        /// <summary>
        ///     Gets or sets the value of the input system
        /// </summary>
        [JsonIgnore]
        public InputSystem InputSystem { get; set; }

        /// <summary>
        ///     Gets or sets the value of the physics system
        /// </summary>
        [JsonIgnore]
        public PhysicsSystem PhysicsSystem { get; set; }

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [JsonPropertyName("_Setting")]
        public static Setting Setting { get; set; } = new Setting();

        /// <summary>Runs this instance.</summary>
        public void Run()
        {
            #region Init()

            InputSystem.Init();
            PhysicsSystem.Init();
            SceneSystem.Init();
            RenderSystem.Init();

            #endregion
            
            #region BeforeAwake()

            InputSystem.BeforeAwake();
            PhysicsSystem.BeforeAwake();
            SceneSystem.BeforeAwake();
            RenderSystem.BeforeAwake();

            #endregion
            
            #region Awake()

            InputSystem.Awake();
            PhysicsSystem.Awake();
            SceneSystem.Awake();
            RenderSystem.Awake();

            #endregion
            
            #region AfterAwake()

            InputSystem.AfterAwake();
            PhysicsSystem.AfterAwake();
            SceneSystem.AfterAwake();
            RenderSystem.AfterAwake();

            #endregion

            #region BeforeStart()

            InputSystem.BeforeStart();
            PhysicsSystem.BeforeStart();
            SceneSystem.BeforeStart();
            RenderSystem.BeforeStart();

            #endregion
            
            #region Start()

            InputSystem.Start();
            PhysicsSystem.Start();
            SceneSystem.Start();
            RenderSystem.Start();

            #endregion
            
            #region AfterStart()

            InputSystem.AfterStart();
            PhysicsSystem.AfterStart();
            SceneSystem.AfterStart();
            RenderSystem.AfterStart();

            #endregion

            while (IsRunning)
            {
                Setting.Time.SyncFixedDeltaTime();

                if (Setting.Time.IsNewFrame())
                {
                    Setting.Time.UpdateTimeStep();

                    for (int i = 0; i < Setting.Time.MaximunAllowedTimeStep; i++)
                    {
                        #region BeforeUpdate()

                        InputSystem.BeforeUpdate();
                        PhysicsSystem.BeforeUpdate();
                        SceneSystem.BeforeUpdate();
                        RenderSystem.BeforeUpdate();

                        #endregion

                        #region Update()

                        InputSystem.Update();
                        PhysicsSystem.Update();
                        SceneSystem.Update();
                        RenderSystem.Update();

                        #endregion

                        #region AfterUpdate()

                        InputSystem.AfterUpdate();
                        PhysicsSystem.AfterUpdate();
                        SceneSystem.AfterUpdate();
                        RenderSystem.AfterUpdate();

                        #endregion
                        
                        #region Draw()

                        InputSystem.Draw();
                        PhysicsSystem.Draw();
                        SceneSystem.Draw();
                        RenderSystem.Draw();
                        
                        #endregion
                    }

                    #region FixedUpdate()

                    InputSystem.FixedUpdate();
                    PhysicsSystem.FixedUpdate();
                    SceneSystem.FixedUpdate();
                    RenderSystem.FixedUpdate();

                    #endregion

                    #region DispatchEvents()

                    InputSystem.DispatchEvents();
                    PhysicsSystem.DispatchEvents();
                    SceneSystem.DispatchEvents();
                    RenderSystem.DispatchEvents();

                    #endregion
                    
                    Setting.Time.CounterFrames();
                }

                Setting.Time.UpdateFixedTime();
            }

            #region Exit()

            InputSystem.Exit();
            PhysicsSystem.Exit();
            SceneSystem.Exit();
            RenderSystem.Exit();

            #endregion
        }


        /// <summary>Resets the game.</summary>
        public void Reset()
        {
            InputSystem.Reset();
            SceneSystem.Reset();
            PhysicsSystem.Reset();
            RenderSystem.Reset();
        }


        /// <summary>Stops this game.</summary>
        public void Stop()
        {
            InputSystem.Stop();
            SceneSystem.Stop();
            PhysicsSystem.Stop();
            RenderSystem.Stop();
        }

        /// <summary>
        ///     Exits
        /// </summary>
        public static void Exit() => IsRunning = false;

        ~Game() => Console.WriteLine(@$"Destroy Game {GetHashCode().ToString()}");
    }
}
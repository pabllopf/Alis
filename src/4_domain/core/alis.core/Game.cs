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

#region

using System;
using System.Text.Json.Serialization;
using Alis.Core.Settings;
using Alis.Core.Systems;
using Alis.FluentApi.Validations;

#endregion

namespace Alis.Core
{
    /// <summary>Define the main logic of game made with ALIS.</summary>
    public class Game
    {
        #region Run()

        /// <summary>Runs this instance.</summary>
        public void Run()
        {
            #region Awake()

            SceneSystem.Awake();
            RenderSystem.Awake();

            #endregion

            #region Start()

            SceneSystem.Start();
            RenderSystem.Start();

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

                        SceneSystem.BeforeUpdate();
                        RenderSystem.BeforeUpdate();

                        #endregion

                        #region Update()

                        SceneSystem.Update();
                        RenderSystem.Update();

                        #endregion

                        #region AfterUpdate()

                        SceneSystem.AfterUpdate();
                        RenderSystem.AfterUpdate();

                        #endregion
                    }

                    #region FixedUpdate()

                    SceneSystem.FixedUpdate();
                    RenderSystem.FixedUpdate();

                    #endregion

                    #region DispatchEvents()

                    SceneSystem.DispatchEvents();
                    RenderSystem.DispatchEvents();

                    #endregion

                    Setting.Time.CounterFrames();
                }

                Setting.Time.UpdateFixedTime();
            }

            #region Exit()

            SceneSystem.Exit();
            RenderSystem.Exit();

            #endregion
        }

        #endregion

        #region Reset()

        /// <summary>Resets the game.</summary>
        public void Reset()
        {
            SceneSystem.Reset();
            RenderSystem.Reset();
        }

        #endregion

        #region Stop()

        /// <summary>Stops this game.</summary>
        public void Stop()
        {
            SceneSystem.Stop();
            RenderSystem.Stop();
        }

        #endregion

        #region Destructor

        ~Game()
        {
            Console.WriteLine(@"destroy");
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="Game" /> class
        /// </summary>
        public Game()
        {
            IsRunning = true;
            RenderSystem = new RenderSystem();
            SceneSystem = new SceneSystem();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Game" /> class
        /// </summary>
        /// <param name="isRunning">The is running</param>
        /// <param name="renderSystem">The render system</param>
        /// <param name="sceneSystem">The scene system</param>
        [JsonConstructor]
        public Game(NotNull<bool> isRunning, NotNull<RenderSystem> renderSystem, NotNull<SceneSystem> sceneSystem)
        {
            IsRunning = isRunning.Value;
            RenderSystem = renderSystem.Value;
            SceneSystem = sceneSystem.Value;
        }

        #endregion

        #region Properties

        /// <summary>Gets a value indicating whether this instance is running.</summary>
        /// <value>
        ///     <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsRunning")]
        private bool IsRunning { get; } = true;

        /// <summary>Gets or sets the render system.</summary>
        /// <value>The render system.</value>
        [JsonIgnore]
        public RenderSystem RenderSystem { get; protected set; } = new RenderSystem();

        /// <summary>Gets or sets the scene system.</summary>
        /// <value>The scene system.</value>
        [JsonIgnore]
        public SceneSystem SceneSystem { get; protected set; } = new SceneSystem();

        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [JsonPropertyName("_Setting")]
        public static Setting Setting { get; set; } = new Setting();

        #endregion
    }
}
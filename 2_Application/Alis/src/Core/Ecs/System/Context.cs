// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Context.cs
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
using System.Threading;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Manager.Time;
using Alis.Core.Ecs.System.Setting;

namespace Alis.Core.Ecs.System
{
    /// <summary>
    ///     The context class
    /// </summary>
    /// <seealso />
    public class Context : IContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        public Context()
        {
            Settings = new Settings();
            TimeManager = new TimeManager(this);
            AudioManager = new AudioManager(this);
            GraphicManager = new GraphicManager(this);
            InputManager = new InputManager(this);
            NetworkManager = new NetworkManager(this);
            PhysicManager = new PhysicManager(this);
            SceneManager = new SceneManager(this);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="settings">The settings</param>
        public Context(Settings settings)
        {
            Settings = settings;
            TimeManager = new TimeManager(this);
            AudioManager = new AudioManager(this);
            GraphicManager = new GraphicManager(this);
            InputManager = new InputManager(this);
            NetworkManager = new NetworkManager(this);
            PhysicManager = new PhysicManager(this);
            SceneManager = new SceneManager(this);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="settings">The settings</param>
        /// <param name="sceneManager">The scene manager</param>
        [JsonConstructor]
        public Context(Settings settings, SceneManager sceneManager)
        {
            Settings = settings;
            TimeManager = new TimeManager(this);
            AudioManager = new AudioManager(this);
            GraphicManager = new GraphicManager(this);
            InputManager = new InputManager(this);
            NetworkManager = new NetworkManager(this);
            PhysicManager = new PhysicManager(this);
            SceneManager = sceneManager;
        }
        
        /// <summary>
        ///     Gets the value of the audio manager
        /// </summary>
        [JsonIgnore]
        public AudioManager AudioManager { get; set; }

        /// <summary>
        ///     Gets the value of the graphic manager
        /// </summary>
        [JsonIgnore]
        public GraphicManager GraphicManager { get; set; }

        /// <summary>
        ///     Gets the value of the input manager
        /// </summary>
        [JsonIgnore]
        public InputManager InputManager { get; set; }

        /// <summary>
        ///     Gets the value of the network manager
        /// </summary>
        [JsonIgnore]
        public NetworkManager NetworkManager { get; set; }

        /// <summary>
        ///     Gets the value of the physic manager
        /// </summary>
        [JsonIgnore]
        public PhysicManager PhysicManager { get; set; }

        /// <summary>
        ///     Gets the value of the time manager
        /// </summary>
        [JsonIgnore]
        public TimeManager TimeManager { get; set; }

        /// <summary>
        ///     The settings
        /// </summary>
        [JsonPropertyName("_Settings_")]
        public Settings Settings { get; set; }

        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        [JsonPropertyName("_SceneManager_")]
        public SceneManager SceneManager { get; set; }
        
        /// <summary>
        ///     Exits this instance
        /// </summary>
        public void Exit() => TimeManager.IsRunning = false;

        /// <summary>
        ///     Sets the scene manager using the specified scene manager
        /// </summary>
        /// <param name="sceneManager">The scene manager</param>
        public void SetSceneManager(SceneManager sceneManager) => SceneManager = sceneManager;
        
          /// <summary>
        ///     Run program
        /// </summary>
        public void Run()
        {
            TimeManager.OnInit();
            AudioManager.OnInit();
            GraphicManager.OnInit();
            InputManager.OnInit();
            NetworkManager.OnInit();
            PhysicManager.OnInit();
            SceneManager.OnInit();
            
           
            TimeManager.OnAwake();
            AudioManager.OnAwake();
            GraphicManager.OnAwake();
            InputManager.OnAwake(); 
            NetworkManager.OnAwake();
            PhysicManager.OnAwake();
            SceneManager.OnAwake();
            
   
            TimeManager.OnStart();
            AudioManager.OnStart();
            GraphicManager.OnStart();
            InputManager.OnStart();
            NetworkManager.OnStart();
            PhysicManager.OnStart();
            SceneManager.OnStart();

            double targetFrameDuration = 1 / Settings.Graphic.TargetFrames;

            double currentTime = TimeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;

            // Variables for calculating FPS
            double lastTime = TimeManager.Clock.Elapsed.TotalSeconds;
            TimeManager.FrameCount = 0;
            TimeManager.TotalFrames = 0;
            TimeManager.AverageFrames = 0;

            // Variables for calculating average FPS
            double totalTime = 0;

            // Variables for SmoothDeltaTime
            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;
            
            while (TimeManager.IsRunning)
            {
                double frameStartTime = TimeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;
                TimeManager.DeltaTime = (float) (newTime - currentTime);

                // Update TimeManager properties
                TimeManager.UnscaledDeltaTime = (float) (newTime - currentTime);
                TimeManager.UnscaledTime += TimeManager.UnscaledDeltaTime;
                TimeManager.UnscaledTimeAsDouble += TimeManager.UnscaledDeltaTime;
                TimeManager.Time = TimeManager.UnscaledTime * TimeManager.TimeScale;
                TimeManager.TimeAsDouble = TimeManager.UnscaledTimeAsDouble * TimeManager.TimeScale;

                // Update MaximumDeltaTime
                TimeManager.MaximumDeltaTime = Math.Max(TimeManager.MaximumDeltaTime, TimeManager.DeltaTime);

                currentTime = newTime;
                accumulator += TimeManager.DeltaTime;

                // Increment frame counter
                TimeManager.FrameCount++;
                TimeManager.TotalFrames++;

                // If a second has passed since the last FPS calculation
                if (newTime - lastTime >= 1.0)
                {
                    // Calculate average FPS
                    totalTime += newTime - lastTime;
                    TimeManager.AverageFrames = (int) (TimeManager.TotalFrames / totalTime);

                    // Reset frame counter and update last time
                    TimeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                TimeManager.OnDispatchEvents();
                AudioManager.OnDispatchEvents();
                GraphicManager.OnDispatchEvents();
                InputManager.OnDispatchEvents();
                NetworkManager.OnDispatchEvents();
                PhysicManager.OnDispatchEvents();
                SceneManager.OnDispatchEvents();
                

                
                TimeManager.OnPhysicUpdate();
                AudioManager.OnPhysicUpdate();
                GraphicManager.OnPhysicUpdate();
                InputManager.OnPhysicUpdate();
                NetworkManager.OnPhysicUpdate();
                PhysicManager.OnPhysicUpdate();
                SceneManager.OnPhysicUpdate();

                
                TimeManager.OnBeforeUpdate();
                AudioManager.OnBeforeUpdate();
                GraphicManager.OnBeforeUpdate();
                InputManager.OnBeforeUpdate();
                NetworkManager.OnBeforeUpdate();
                PhysicManager.OnBeforeUpdate();
                SceneManager.OnBeforeUpdate();
                
             
                TimeManager.OnUpdate();
                AudioManager.OnUpdate();
                GraphicManager.OnUpdate();
                InputManager.OnUpdate();
                NetworkManager.OnUpdate();
                PhysicManager.OnUpdate();
                SceneManager.OnUpdate();
                
           
                TimeManager.OnAfterUpdate();
                AudioManager.OnAfterUpdate();
                GraphicManager.OnAfterUpdate();
                InputManager.OnAfterUpdate();
                NetworkManager.OnAfterUpdate();
                PhysicManager.OnAfterUpdate();
                SceneManager.OnAfterUpdate();
                


                // Run fixed methods
                while (accumulator >= TimeManager.Configuration.FixedTimeStep)
                {
                    TimeManager.InFixedTimeStep = true;

                    TimeManager.FixedTime += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedTimeAsDouble += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedDeltaTime = TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedUnscaledDeltaTime = TimeManager.Configuration.FixedTimeStep / TimeManager.TimeScale;

                    // Update FixedUnscaledTime and FixedUnscaledTimeAsDouble
                    TimeManager.FixedUnscaledTime += TimeManager.FixedUnscaledDeltaTime;
                    TimeManager.FixedUnscaledTimeAsDouble += TimeManager.FixedUnscaledDeltaTime;

                    
                    TimeManager.OnBeforeFixedUpdate();
                    AudioManager.OnBeforeFixedUpdate();
                    GraphicManager.OnBeforeFixedUpdate();
                    InputManager.OnBeforeFixedUpdate();
                    NetworkManager.OnBeforeFixedUpdate();
                    PhysicManager.OnBeforeFixedUpdate();
                    SceneManager.OnBeforeFixedUpdate();
                    
                    
                    TimeManager.OnFixedUpdate();
                    AudioManager.OnFixedUpdate();
                    GraphicManager.OnFixedUpdate();
                    InputManager.OnFixedUpdate();
                    NetworkManager.OnFixedUpdate();
                    PhysicManager.OnFixedUpdate();
                    SceneManager.OnFixedUpdate();
                    
                    
                    TimeManager.OnAfterFixedUpdate();
                    AudioManager.OnAfterFixedUpdate();
                    GraphicManager.OnAfterFixedUpdate();
                    InputManager.OnAfterFixedUpdate();
                    NetworkManager.OnAfterFixedUpdate();
                    PhysicManager.OnAfterFixedUpdate();
                    SceneManager.OnAfterFixedUpdate();
                    

                    accumulator %= TimeManager.Configuration.FixedTimeStep;

                    TimeManager.InFixedTimeStep = false;
                }

           
                TimeManager.OnCalculate();
                AudioManager.OnCalculate();
                GraphicManager.OnCalculate();
                InputManager.OnCalculate();
                NetworkManager.OnCalculate();
                PhysicManager.OnCalculate();
                SceneManager.OnCalculate();
                
                TimeManager.OnDraw();
                AudioManager.OnDraw();
                GraphicManager.OnDraw();
                InputManager.OnDraw();
                NetworkManager.OnDraw();
                PhysicManager.OnDraw();
                SceneManager.OnDraw();
                
          
                TimeManager.OnGui();
                AudioManager.OnGui();
                GraphicManager.OnGui();
                InputManager.OnGui();
                NetworkManager.OnGui();
                PhysicManager.OnGui();
                SceneManager.OnGui();

                // Update SmoothDeltaTime
                smoothDeltaTimeSum += TimeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = TimeManager.DeltaTime;
                
                // Calculate frame duration and sleep if necessary
                double frameEndTime = TimeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int) ((targetFrameDuration - frameDuration) * 1000));
                }
            }


            TimeManager.OnStop();
            AudioManager.OnStop();
            GraphicManager.OnStop();
            InputManager.OnStop();
            NetworkManager.OnStop();
            PhysicManager.OnStop();
            SceneManager.OnStop();

            
            TimeManager.OnExit();
            AudioManager.OnExit();
            GraphicManager.OnExit();
            InputManager.OnExit();
            NetworkManager.OnExit();
            PhysicManager.OnExit();
            SceneManager.OnExit();
        }

        /// <summary>
        /// Runs the preview
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void RunPreview()
        {
        }
    }
}
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
using Alis.Core.Ecs.System.Manager;
using Alis.Core.Ecs.System.Manager.Audio;
using Alis.Core.Ecs.System.Manager.Graphic;
using Alis.Core.Ecs.System.Manager.Input;
using Alis.Core.Ecs.System.Manager.Network;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Ecs.System.Manager.Scene;
using Alis.Core.Ecs.System.Manager.Time;
using Alis.Core.Ecs.System.Operator;
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
        /// The runtime
        /// </summary>
        private readonly Runtime<AManager> runtime;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        public Context()
        {
            Settings = new Settings();
            runtime = new Runtime<AManager>(
                new AudioManager(this),
                new GraphicManager(this),
                new InputManager(this),
                new NetworkManager(this),
                new PhysicManager(this),
                new SceneManager(this),
                new TimeManager(this)
            );
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Context" /> class
        /// </summary>
        /// <param name="settings">The settings</param>
        public Context(Settings settings)
        {
            Settings = settings;
            runtime = new Runtime<AManager>(
                new AudioManager(this),
                new GraphicManager(this),
                new InputManager(this),
                new NetworkManager(this),
                new PhysicManager(this),
                new SceneManager(this),
                new TimeManager(this)
            );
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
            runtime = new Runtime<AManager>(
                new AudioManager(this),
                new GraphicManager(this),
                new InputManager(this),
                new NetworkManager(this),
                new PhysicManager(this),
                sceneManager,
                new TimeManager(this)
            );
        }

        /// <summary>
        ///     Gets the value of the audio manager
        /// </summary>
        [JsonIgnore]
        public AudioManager AudioManager => runtime.Get<AudioManager>();

        /// <summary>
        ///     Gets the value of the graphic manager
        /// </summary>
        [JsonIgnore]
        public GraphicManager GraphicManager => runtime.Get<GraphicManager>();

        /// <summary>
        ///     Gets the value of the input manager
        /// </summary>
        [JsonIgnore]
        public InputManager InputManager => runtime.Get<InputManager>();

        /// <summary>
        ///     Gets the value of the network manager
        /// </summary>
        [JsonIgnore]
        public NetworkManager NetworkManager => runtime.Get<NetworkManager>();

        /// <summary>
        ///     Gets the value of the physic manager
        /// </summary>
        [JsonIgnore]
        public PhysicManager PhysicManager => runtime.Get<PhysicManager>();

        /// <summary>
        ///     Gets the value of the time manager
        /// </summary>
        [JsonIgnore]
        public TimeManager TimeManager => runtime.Get<TimeManager>();

        /// <summary>
        ///     The settings
        /// </summary>
        [JsonPropertyName("_Settings_")]
        public Settings Settings { get; set; }

        /// <summary>
        ///     Gets the value of the scene manager
        /// </summary>
        [JsonPropertyName("_SceneManager_")]
        public SceneManager SceneManager => runtime.Get<SceneManager>();

        /// <summary>
        /// Runs this instance
        /// </summary>
        public void Run()
        {
            runtime.OnInit();
            runtime.OnAwake();
            runtime.OnStart();

            double targetFrameDuration = 1 / Settings.Graphic.TargetFrames;

            double currentTime = TimeManager.Clock.Elapsed.TotalSeconds;
            float accumulator = 0;

            double lastTime = TimeManager.Clock.Elapsed.TotalSeconds;
            TimeManager.FrameCount = 0;
            TimeManager.TotalFrames = 0;
            TimeManager.AverageFrames = 0;

            double totalTime = 0;

            float lastDeltaTime = 0f;
            float smoothDeltaTimeSum = 0f;
            int smoothDeltaTimeCount = 0;

            while (TimeManager.IsRunning)
            {
                double frameStartTime = TimeManager.Clock.Elapsed.TotalSeconds;
                double newTime = frameStartTime;
                TimeManager.DeltaTime = (float)(newTime - currentTime);

                TimeManager.UnscaledDeltaTime = (float)(newTime - currentTime);
                TimeManager.UnscaledTime += TimeManager.UnscaledDeltaTime;
                TimeManager.UnscaledTimeAsDouble += TimeManager.UnscaledDeltaTime;
                TimeManager.Time = TimeManager.UnscaledTime * TimeManager.TimeScale;
                TimeManager.TimeAsDouble = TimeManager.UnscaledTimeAsDouble * TimeManager.TimeScale;

                TimeManager.MaximumDeltaTime = Math.Max(TimeManager.MaximumDeltaTime, TimeManager.DeltaTime);

                currentTime = newTime;
                accumulator += TimeManager.DeltaTime;

                TimeManager.FrameCount++;
                TimeManager.TotalFrames++;

                if (newTime - lastTime >= 1.0)
                {
                    totalTime += newTime - lastTime;
                    TimeManager.AverageFrames = (int)(TimeManager.TotalFrames / totalTime);

                    TimeManager.FrameCount = 0;
                    lastTime = newTime;
                }

                runtime.OnDispatchEvents();

                runtime.OnPhysicUpdate();

                runtime.OnBeforeUpdate();

                runtime.OnUpdate();

                runtime.OnAfterUpdate();

                while (accumulator >= TimeManager.Configuration.FixedTimeStep)
                {
                    TimeManager.InFixedTimeStep = true;

                    TimeManager.FixedTime += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedTimeAsDouble += TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedDeltaTime = TimeManager.Configuration.FixedTimeStep;
                    TimeManager.FixedUnscaledDeltaTime = TimeManager.Configuration.FixedTimeStep / TimeManager.TimeScale;

                    TimeManager.FixedUnscaledTime += TimeManager.FixedUnscaledDeltaTime;
                    TimeManager.FixedUnscaledTimeAsDouble += TimeManager.FixedUnscaledDeltaTime;

                    runtime.OnBeforeFixedUpdate();

                    runtime.OnFixedUpdate();

                    runtime.OnAfterFixedUpdate();

                    accumulator %= TimeManager.Configuration.FixedTimeStep;

                    TimeManager.InFixedTimeStep = false;
                }

                runtime.OnCalculate();
                runtime.OnDraw();
                runtime.OnGui();

                smoothDeltaTimeSum += TimeManager.DeltaTime - lastDeltaTime;
                smoothDeltaTimeCount++;
                TimeManager.SmoothDeltaTime = smoothDeltaTimeSum / smoothDeltaTimeCount;
                lastDeltaTime = TimeManager.DeltaTime;

                double frameEndTime = TimeManager.Clock.Elapsed.TotalSeconds;
                double frameDuration = frameEndTime - frameStartTime;
                if (frameDuration < targetFrameDuration)
                {
                    Thread.Sleep((int)((targetFrameDuration - frameDuration) * 1000));
                }
            }

            runtime.OnStop();
            runtime.OnExit();
        }
        
        /// <summary>
        /// Runs the preview
        /// </summary>
        public void RunPreview() => Console.WriteLine("Run preview");

        /// <summary>
        /// Exits this instance
        /// </summary>
        public void Exit() => Console.WriteLine("Exit");
    }
}
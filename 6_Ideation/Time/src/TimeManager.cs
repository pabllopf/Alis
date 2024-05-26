// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeManager.cs
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
using System.Runtime.Serialization;

namespace Alis.Core.Aspect.Time
{
    /// <summary>
    ///     Provides an interface to get time information.
    /// </summary>
    [Serializable]
    public class TimeManager : ISerializable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeManager" /> class
        /// </summary>
        public TimeManager()
        {
            Clock = new Clock();
            Clock.Start();
        }
        
        /// <summary>
        ///     Gets or sets the value of the configuration
        /// </summary>
        public TimeConfiguration Configuration { get; } = new TimeConfiguration();
        
        /// <summary>
        ///     Gets the value of the clock
        /// </summary>
        public Clock Clock { get; set; }
        
        /// <summary>
        ///     The interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public float DeltaTime { get; set; }
        
        /// <summary>
        ///     The interval in seconds at which physics and other fixed frame rate updateS.
        /// </summary>
        public float FixedDeltaTime { get; set; }
        
        /// <summary>
        ///     The time since the last FixedUpdate started (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedTime { get; set; }
        
        /// <summary>
        ///     The double precision time since the last FixedUpdate started (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double FixedTimeAsDouble { get; set; }
        
        /// <summary>
        ///     The timeScale-independent interval in seconds from the last Runtime.FixedUpdate() phase to the current one (Read
        ///     Only).
        /// </summary>
        public float FixedUnscaledDeltaTime { get; set; }
        
        /// <summary>
        ///     The timeScale-independent time at the beginning of the last Runtime.FixedUpdate() phase (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedUnscaledTime { get; set; }
        
        /// <summary>
        ///     The double precision timeScale-independent time at the beginning of the last FixedUpdate (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double FixedUnscaledTimeAsDouble { get; set; }
        
        /// <summary>
        ///     The total number of frames since the start of the game (Read Only).
        /// </summary>
        public float FrameCount { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the total frames
        /// </summary>
        public int TotalFrames { get; set; }
        
        /// <summary>
        ///     Gets or sets the value of the average frames
        /// </summary>
        public int AverageFrames { get; set; }
        
        /// <summary>
        ///     Returns true if called inside a fixed time step callback (like Runtime FixedUpdate), otherwise returns false.
        /// </summary>
        public bool InFixedTimeStep { get; set; }
        
        /// <summary>
        ///     The maximum value of TimeManager.DeltaTime in any given frame.
        ///     This is a time in seconds that limits the increase of TimeManager.time between two frames.
        /// </summary>
        public float MaximumDeltaTime { get; set; }
        
        /// <summary>
        ///     The real time in seconds since the game started (Read Only).
        /// </summary>
        public float RealtimeSinceStartup => (float) Clock.Elapsed.TotalSeconds;
        
        /// <summary>
        ///     The real time in seconds since the game started (Read Only).
        ///     Double precision version of realtimeSinceStartup.
        /// </summary>
        public double RealtimeSinceStartupAsDouble => Clock.Elapsed.TotalSeconds;
        
        /// <summary>
        ///     A smoothed out TimeManager.DeltaTime (Read Only).
        /// </summary>
        public float SmoothDeltaTime { get; set; }
        
        /// <summary>
        ///     The time at the beginning of this frame (Read Only).
        /// </summary>
        public float Time { get; set; }
        
        /// <summary>
        ///     The double precision time at the beginning of this frame (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double TimeAsDouble { get; set; }
        
        /// <summary>
        ///     The scale at which time passes.
        /// </summary>
        public float TimeScale { get; set; } = 1f;
        
        /// <summary>
        ///     The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public float UnscaledDeltaTime { get; set; }
        
        /// <summary>
        ///     The timeScale-independent time for this frame (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public float UnscaledTime { get; set; }
        
        /// <summary>
        ///     The double precision timeScale-independent time for this frame (Read Only).
        ///     This is the time in seconds since the start of the game.
        /// </summary>
        public double UnscaledTimeAsDouble { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the is running
        /// </summary>
        public bool IsRunning { get; set; } = true;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeManager"/> class
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        protected TimeManager(SerializationInfo info, StreamingContext context)
        {
            Configuration = (TimeConfiguration) info.GetValue("Configuration", typeof(TimeConfiguration));
            Clock = (Clock) info.GetValue("Clock", typeof(Clock));
            DeltaTime = info.GetSingle("DeltaTime");
            FixedDeltaTime = info.GetSingle("FixedDeltaTime");
            FixedTime = info.GetSingle("FixedTime");
            FixedTimeAsDouble = info.GetDouble("FixedTimeAsDouble");
            FixedUnscaledDeltaTime = info.GetSingle("FixedUnscaledDeltaTime");
            FixedUnscaledTime = info.GetSingle("FixedUnscaledTime");
            FixedUnscaledTimeAsDouble = info.GetDouble("FixedUnscaledTimeAsDouble");
            FrameCount = info.GetSingle("FrameCount");
            TotalFrames = info.GetInt32("TotalFrames");
            AverageFrames = info.GetInt32("AverageFrames");
            InFixedTimeStep = info.GetBoolean("InFixedTimeStep");
            MaximumDeltaTime = info.GetSingle("MaximumDeltaTime");
            SmoothDeltaTime = info.GetSingle("SmoothDeltaTime");
            Time = info.GetSingle("Time");
            TimeAsDouble = info.GetDouble("TimeAsDouble");
            TimeScale = info.GetSingle("TimeScale");
            UnscaledDeltaTime = info.GetSingle("UnscaledDeltaTime");
            UnscaledTime = info.GetSingle("UnscaledTime");
            UnscaledTimeAsDouble = info.GetDouble("UnscaledTimeAsDouble");
            IsRunning = info.GetBoolean("IsRunning");
        }
        
        /// <summary>
        /// Gets the object data using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        /// <param name="context">The context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Configuration", Configuration);
            info.AddValue("Clock", Clock);
            info.AddValue("DeltaTime", DeltaTime);
            info.AddValue("FixedDeltaTime", FixedDeltaTime);
            info.AddValue("FixedTime", FixedTime);
            info.AddValue("FixedTimeAsDouble", FixedTimeAsDouble);
            info.AddValue("FixedUnscaledDeltaTime", FixedUnscaledDeltaTime);
            info.AddValue("FixedUnscaledTime", FixedUnscaledTime);
            info.AddValue("FixedUnscaledTimeAsDouble", FixedUnscaledTimeAsDouble);
            info.AddValue("FrameCount", FrameCount);
            info.AddValue("TotalFrames", TotalFrames);
            info.AddValue("AverageFrames", AverageFrames);
            info.AddValue("InFixedTimeStep", InFixedTimeStep);
            info.AddValue("MaximumDeltaTime", MaximumDeltaTime);
            info.AddValue("SmoothDeltaTime", SmoothDeltaTime);
            info.AddValue("Time", Time);
            info.AddValue("TimeAsDouble", TimeAsDouble);
            info.AddValue("TimeScale", TimeScale);
            info.AddValue("UnscaledDeltaTime", UnscaledDeltaTime);
            info.AddValue("UnscaledTime", UnscaledTime);
            info.AddValue("UnscaledTimeAsDouble", UnscaledTimeAsDouble);
            info.AddValue("IsRunning", IsRunning);
        }
    }
}
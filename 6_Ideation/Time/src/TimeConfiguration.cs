// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeConfiguration.cs
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

namespace Alis.Core.Aspect.Time
{
    /// <summary>
    ///     The time class
    /// </summary>
    public class TimeConfiguration
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeConfiguration" /> class
        /// </summary>
        /// <param name="fixedTimeStep">The fixed time step</param>
        /// <param name="maximumAllowedTimeStep">The maximum allowed time step</param>
        /// <param name="timeScale">The time scale</param>
        public TimeConfiguration(float fixedTimeStep = 0.016f, float maximumAllowedTimeStep = 0.10f, float timeScale = 1.00f)
        {
            FixedTimeStep = fixedTimeStep;
            MaximumAllowedTimeStep = maximumAllowedTimeStep;
            TimeScale = timeScale;
        }

        /// <summary>
        ///     A framerate-independent interval that dictates when physics calculations and FixedUpdate() events are performed.
        /// </summary>
        public float FixedTimeStep { get; set; }

        /// <summary>
        ///     A framerate-independent interval that caps the worst case scenario when frame-rate is low.
        ///     Physics calculations and FixedUpdate() events will not be performed for longer time than specified.
        /// </summary>
        public float MaximumAllowedTimeStep { get; set; }

        /// <summary>
        ///     The speed at which time progresses.
        ///     Change this value to simulate bullet-time effects.
        ///     A value of 1 means real-time. A value of .5 means half speed; a value of 2 is double speed.
        /// </summary>
        public float TimeScale { get; set; }

        /// <summary>
        ///     Gets or sets the value of the log output
        /// </summary>
        public bool LogOutput { get; set; } = false;
    }
}
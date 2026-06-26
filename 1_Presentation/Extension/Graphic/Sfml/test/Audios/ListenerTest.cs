// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ListenerTest.cs
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

using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Tests for the Listener class.
    /// </summary>
    public class ListenerTest
    {
        /// <summary>
        ///     Tests that Listener GlobalVolume getter returns a value.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_GlobalVolume_Getter_ShouldReturnNonZero()
        {
            float volume = Listener.GlobalVolume;

            // GlobalVolume is a static property — should return current listener volume (default 100)
        }

        /// <summary>
        ///     Tests that Listener Position getter returns a vector.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_Position_Getter_ShouldReturnVector()
        {
            var position = Listener.Position;

            // Position is a static property — should return current listener position (default 0,0,0)
        }

        /// <summary>
        ///     Tests that Listener Direction getter returns a vector.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_Direction_Getter_ShouldReturnVector()
        {
            var direction = Listener.Direction;

            // Direction is a static property — should return current listener direction (default 0,0,-1)
        }

        /// <summary>
        ///     Tests that Listener UpVector getter returns a vector.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_UpVector_Getter_ShouldReturnVector()
        {
            var upVector = Listener.UpVector;

            // UpVector is a static property — should return current listener up vector (default 0,1,0)
        }

        /// <summary>
        ///     Tests that Listener GlobalVolume can be set.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_GlobalVolume_Setter_ShouldAcceptValue()
        {
            float originalVolume = Listener.GlobalVolume;

            // Set and restore — should not throw
            Listener.GlobalVolume = 50f;
            Listener.GlobalVolume = originalVolume;
        }

        /// <summary>
        ///     Tests that Listener Position can be set.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_Position_Setter_ShouldAcceptValue()
        {
            var originalPosition = Listener.Position;

            // Set and restore — should not throw
            Listener.Position = new Alis.Core.Aspect.Math.Vector.Vector3F(1, 2, 3);
            Listener.Position = originalPosition;
        }

        /// <summary>
        ///     Tests that Listener Direction can be set.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_Direction_Setter_ShouldAcceptValue()
        {
            var originalDirection = Listener.Direction;

            // Set and restore — should not throw
            Listener.Direction = new Alis.Core.Aspect.Math.Vector.Vector3F(0, 0, -1);
            Listener.Direction = originalDirection;
        }

        /// <summary>
        ///     Tests that Listener UpVector can be set.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Listener_UpVector_Setter_ShouldAcceptValue()
        {
            var originalUpVector = Listener.UpVector;

            // Set and restore — should not throw
            Listener.UpVector = new Alis.Core.Aspect.Math.Vector.Vector3F(0, 1, 0);
            Listener.UpVector = originalUpVector;
        }
    }
}

// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ListenerCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     Round-trip coverage tests for the static Listener wrapper.
    /// </summary>
    public class ListenerCoverageTests
    {
        /// <summary>
        ///     Tests that GlobalVolume round-trips through the native setter and getter.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void GlobalVolume_SetThenGet_RoundTripsValue()
        {
            float original = Listener.GlobalVolume;

            Listener.GlobalVolume = 37.5f;
            float read = Listener.GlobalVolume;
            Listener.GlobalVolume = original;

            Assert.Equal(37.5f, read);
        }

        /// <summary>
        ///     Tests that Position accepts a value and its getter completes.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Position_SetThenGet_CompletesWithoutThrowing()
        {
            Vector3F original = Listener.Position;

            Listener.Position = new Vector3F(1.5f, -2.5f, 3.5f);
            Vector3F read = Listener.Position;
            Listener.Position = original;

            Assert.True(float.IsFinite(read.X));
            Assert.True(float.IsFinite(read.Y));
            Assert.True(float.IsFinite(read.Z));
        }

        /// <summary>
        ///     Tests that Direction accepts a value and its getter completes.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Direction_SetThenGet_CompletesWithoutThrowing()
        {
            Vector3F original = Listener.Direction;

            Listener.Direction = new Vector3F(0.25f, 0.5f, -0.75f);
            Vector3F read = Listener.Direction;
            Listener.Direction = original;

            Assert.True(float.IsFinite(read.X));
            Assert.True(float.IsFinite(read.Y));
            Assert.True(float.IsFinite(read.Z));
        }

        /// <summary>
        ///     Tests that UpVector accepts a value and its getter completes.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void UpVector_SetThenGet_CompletesWithoutThrowing()
        {
            Vector3F original = Listener.UpVector;

            Listener.UpVector = new Vector3F(0.0f, 1.0f, 0.0f);
            Vector3F read = Listener.UpVector;
            Listener.UpVector = original;

            Assert.True(float.IsFinite(read.X));
            Assert.True(float.IsFinite(read.Y));
            Assert.True(float.IsFinite(read.Z));
        }

        /// <summary>
        ///     Tests that GlobalVolume accepts the boundary value zero.
        /// </summary>
        [RequireCSfmlAudioFact]
        public void GlobalVolume_SetZero_GetReturnsZero()
        {
            float original = Listener.GlobalVolume;

            Listener.GlobalVolume = 0.0f;
            float read = Listener.GlobalVolume;
            Listener.GlobalVolume = original;

            Assert.Equal(0.0f, read);
        }
    }
}

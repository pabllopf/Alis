// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ListenerTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    ///     The listener tests class
    /// </summary>
    public class ListenerTests
    {
        /// <summary>
        ///     Tests that set global volume does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Listener without native SFML dependencies.")]
        public void SetGlobalVolume_DoesNotThrow()
        {
            Listener.GlobalVolume = 50f;
            Assert.Equal(50f, Listener.GlobalVolume);
        }

        /// <summary>
        ///     Tests that set position does not throw
        /// </summary>
        [Fact(Skip = "Cannot test Listener without native SFML dependencies.")]
        public void SetPosition_DoesNotThrow()
        {
            Listener.Position = new Vector3F(1, 2, 3);
            Vector3F pos = Listener.Position;
            Assert.Equal(1, pos.X);
            Assert.Equal(2, pos.Y);
            Assert.Equal(3, pos.Z);
        }
    }
}
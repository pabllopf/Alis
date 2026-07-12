// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MultiGestureEventTest.cs
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

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The multi gesture event test class
    /// </summary>
    public class MultiGestureEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            MultiGestureEvent evt = new MultiGestureEvent();
            Assert.Equal(0u, evt.type);
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0L, evt.touchId);
            Assert.Equal(0f, evt.dTheta);
            Assert.Equal(0f, evt.dDist);
            Assert.Equal(0f, evt.x);
            Assert.Equal(0f, evt.y);
            Assert.Equal(0, evt.numFingers);
            Assert.Equal(0, evt.padding);
        }
    }
}

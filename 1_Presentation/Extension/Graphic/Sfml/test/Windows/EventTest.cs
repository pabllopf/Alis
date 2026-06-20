// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EventTest.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Tests the <see cref="Event" /> struct.
    /// </summary>
    public class EventTest
    {
        [Fact]
        public void Default_TypeIsNone()
        {
            Event evt = default;
            Assert.Equal(default(EventType), evt.Type);
        }

        [Fact]
        public void Type_CanBeSet()
        {
            Event evt = default;
            evt.Type = EventType.Closed;
            Assert.Equal(EventType.Closed, evt.Type);
        }

        [Fact]
        public void Type_CanBeSetToGainedFocus()
        {
            Event evt = default;
            evt.Type = EventType.GainedFocus;
            Assert.Equal(EventType.GainedFocus, evt.Type);
        }

        [Fact]
        public void TypeAndSizeField_Roundtrip()
        {
            Event evt = default;
            evt.Type = EventType.Resized;
            Assert.Equal(EventType.Resized, evt.Type);
        }

        [Fact]
        public void TypeAndKeyField_Roundtrip()
        {
            Event evt = default;
            evt.Type = EventType.KeyPressed;
            Assert.Equal(EventType.KeyPressed, evt.Type);
        }

        [Fact]
        public void TypeAndMouseMoved_Roundtrip()
        {
            Event evt = default;
            evt.Type = EventType.MouseMoved;
            Assert.Equal(EventType.MouseMoved, evt.Type);
        }
    }
}

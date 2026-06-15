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

using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The event test class
    /// </summary>
    public class EventTest
    {
        /// <summary>
        /// Tests that event default initialization fields have default values
        /// </summary>
        [Fact]
        public void Event_DefaultInitialization_FieldsHaveDefaultValues()
        {
            Event ev = new Event();

            Assert.Equal(EventType.FirstEvent, ev.type);
        }

        /// <summary>
        /// Tests that event explicit layout type field is accessible
        /// </summary>
        [Fact]
        public void Event_ExplicitLayout_TypeFieldIsAccessible()
        {
            Event ev = new Event();

            ev.type = EventType.Quit;

            Assert.Equal(EventType.Quit, ev.type);
        }

        /// <summary>
        /// Tests that event is value type copy is independent
        /// </summary>
        [Fact]
        public void Event_IsValueType_CopyIsIndependent()
        {
            Event original = new Event();
            Event copy = original;

            Assert.Equal(original.type, copy.type);
        }
    }
}

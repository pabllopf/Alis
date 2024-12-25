// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericEventTests.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Structs
{
    /// <summary>
    ///     The generic event tests class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class GenericEventTests 
    {
        /// <summary>
        ///     Tests that generic event initializes properties correctly
        /// </summary>
        [Fact]
        public void GenericEvent_InitializesPropertiesCorrectly()
        {
            EventType expectedType = EventType.Quit;
            uint expectedTimestamp = 123456789;

            GenericEvent genericEvent = new GenericEvent
            {
                type = expectedType,
                timestamp = expectedTimestamp
            };

            Assert.Equal(expectedType, genericEvent.type);
            Assert.Equal(expectedTimestamp, genericEvent.timestamp);
        }
    }
}
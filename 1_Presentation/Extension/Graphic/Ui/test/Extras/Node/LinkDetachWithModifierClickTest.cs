// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LinkDetachWithModifierClickTest.cs
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
using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     Provides unit coverage for <see cref="LinkDetachWithModifierClick" /> struct.
    /// </summary>
    public class LinkDetachWithModifierClickTest
    {
        /// <summary>
        ///     Verifies that the type is a value type (struct).
        /// </summary>
        [Fact]
        public void Type_ShouldBeStruct()
        {
            Type type = typeof(LinkDetachWithModifierClick);

            Assert.True(type.IsValueType);
            Assert.False(type.IsClass);
        }

        /// <summary>
        ///     Verifies that a default instance has a null Modifier.
        /// </summary>
        [Fact]
        public void Modifier_ShouldBeNullOnDefaultInstance()
        {
            LinkDetachWithModifierClick instance = new LinkDetachWithModifierClick();

            Assert.Null(instance.Modifier);
        }

        /// <summary>
        ///     Verifies that Modifier can be assigned and read back.
        /// </summary>
        [Fact]
        public void Modifier_ShouldRoundTripAssignedValue()
        {
            LinkDetachWithModifierClick instance = new LinkDetachWithModifierClick();
            byte[] modifier = { 1, 2, 3 };

            instance.Modifier = modifier;

            Assert.Equal(modifier, instance.Modifier);
        }

        /// <summary>
        ///     Verifies that Modifier can be set to an empty array.
        /// </summary>
        [Fact]
        public void Modifier_ShouldAllowEmptyArray()
        {
            LinkDetachWithModifierClick instance = new LinkDetachWithModifierClick();
            byte[] modifier = Array.Empty<byte>();

            instance.Modifier = modifier;

            Assert.Empty(instance.Modifier);
        }

        /// <summary>
        ///     Verifies that Modifier can be reassigned to a different value.
        /// </summary>
        [Fact]
        public void Modifier_ShouldAllowReassignment()
        {
            LinkDetachWithModifierClick instance = new LinkDetachWithModifierClick();

            instance.Modifier = new byte[] { 1, 2, 3 };
            instance.Modifier = new byte[] { 4, 5, 6, 7 };

            Assert.Equal(new byte[] { 4, 5, 6, 7 }, instance.Modifier);
        }
    }
}

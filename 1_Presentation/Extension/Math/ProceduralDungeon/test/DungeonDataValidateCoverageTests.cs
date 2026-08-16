// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonDataValidateCoverageTests.cs
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
using System.Reflection;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     The dungeon data validate coverage tests class
    /// </summary>
    public class DungeonDataValidateCoverageTests
    {
        /// <summary>
        ///     Sets the private field of the data object.
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="fieldName">The field name</param>
        /// <param name="value">The value</param>
        private static void SetField(DungeonData data, string fieldName, object value)
        {
            FieldInfo field = typeof(DungeonData).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(data, value);
        }

        /// <summary>
        ///     Tests that validate throws when the board is null.
        /// </summary>
        [Fact]
        public void Validate_WithNullBoard_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            SetField(data, "_board", null);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => data.Validate());

            Assert.Contains("_board", ex.Message);
        }

        /// <summary>
        ///     Tests that validate throws when the rooms list is null.
        /// </summary>
        [Fact]
        public void Validate_WithNullRooms_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            SetField(data, "_board", new BoardSquare[2, 2]);
            SetField(data, "_rooms", null);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => data.Validate());

            Assert.Contains("_rooms", ex.Message);
        }

        /// <summary>
        ///     Tests that validate throws when the corridors list is null.
        /// </summary>
        [Fact]
        public void Validate_WithNullCorridors_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            SetField(data, "_board", new BoardSquare[2, 2]);
            SetField(data, "_corridors", null);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => data.Validate());

            Assert.Contains("_corridors", ex.Message);
        }
    }
}

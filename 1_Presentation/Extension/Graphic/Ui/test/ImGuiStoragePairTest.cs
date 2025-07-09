// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStoragePairTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui storage pair test class
    /// </summary>
    public class ImGuiStoragePairTest
    {
        /// <summary>
        ///     Tests that key should set and get correctly
        /// </summary>
        [Fact]
        public void Key_Should_SetAndGetCorrectly()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = 123u;
            Assert.Equal(123u, storagePair.Key);
        }

        /// <summary>
        ///     Tests that value should set and get correctly
        /// </summary>
        [Fact]
        public void Value_Should_SetAndGetCorrectly()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            UnionValue value = new UnionValue {ValueI32 = 123};
            storagePair.Value = value;
            Assert.Equal(value, storagePair.Value);
        }
    }
}
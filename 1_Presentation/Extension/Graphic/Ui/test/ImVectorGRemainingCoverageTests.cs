// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImVectorGRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im vector g remaining coverage tests class
    /// </summary>
    public class ImVectorGRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default size should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultSize_ShouldBeZero()
        {
            ImVectorG<int> vector = default;
            Assert.Equal(0, vector.Size);
        }

        /// <summary>
        ///     Tests that default capacity should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultCapacity_ShouldBeZero()
        {
            ImVectorG<int> vector = default;
            Assert.Equal(0, vector.Capacity);
        }

        /// <summary>
        ///     Tests that default data should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void DefaultData_ShouldBeZero()
        {
            ImVectorG<int> vector = default;
            Assert.Equal(IntPtr.Zero, vector.Data);
        }

        /// <summary>
        ///     Tests that constructor from im vector should copy fields
        /// </summary>
         [RequireCImguiSystemFact]
        public void ConstructorFromImVector_ShouldCopyFields()
        {
            IntPtr data = new IntPtr(42);
            ImVector source = new ImVector(3, 6, data);
            ImVectorG<int> vector = new ImVectorG<int>(source);
            Assert.Equal(3, vector.Size);
            Assert.Equal(6, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }

        /// <summary>
        ///     Tests that direct constructor should set fields
        /// </summary>
         [RequireCImguiSystemFact]
        public void DirectConstructor_ShouldSetFields()
        {
            IntPtr data = new IntPtr(88);
            ImVectorG<int> vector = new ImVectorG<int>(4, 8, data);
            Assert.Equal(4, vector.Size);
            Assert.Equal(8, vector.Capacity);
            Assert.Equal(data, vector.Data);
        }
    }
}

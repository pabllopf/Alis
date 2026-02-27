// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray4Test.cs
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

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The fixed array 4 test class
    /// </summary>
    public class FixedArray4Test
    {
        /// <summary>
        ///     Tests that indexer get should return correct values
        /// </summary>
        [Fact]
        public void Indexer_Get_ShouldReturnCorrectValues()
        {
            FixedArray4<int> array = new FixedArray4<int>();
            array[0] = 10;
            array[1] = 20;
            array[2] = 30;
            array[3] = 40;
            
            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);
            Assert.Equal(30, array[2]);
            Assert.Equal(40, array[3]);
        }

        /// <summary>
        ///     Tests that indexer set should update all values
        /// </summary>
        [Fact]
        public void Indexer_Set_ShouldUpdateAllValues()
        {
            FixedArray4<int> array = new FixedArray4<int>();
            
            array[0] = 100;
            array[1] = 200;
            array[2] = 300;
            array[3] = 400;
            
            Assert.Equal(100, array[0]);
            Assert.Equal(200, array[1]);
            Assert.Equal(300, array[2]);
            Assert.Equal(400, array[3]);
        }

        /// <summary>
        ///     Tests that indexer with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithInvalidIndex_ShouldThrowException()
        {
            FixedArray4<int> array = new FixedArray4<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[4]);
        }

        /// <summary>
        ///     Tests that indexer set with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_SetWithInvalidIndex_ShouldThrowException()
        {
            FixedArray4<int> array = new FixedArray4<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[4] = 100);
        }

        /// <summary>
        ///     Tests that indexer with negative index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithNegativeIndex_ShouldThrowException()
        {
            FixedArray4<int> array = new FixedArray4<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[-1]);
        }

        /// <summary>
        ///     Tests that indexer with double values should work
        /// </summary>
        [Fact]
        public void Indexer_WithDoubleValues_ShouldWork()
        {
            FixedArray4<double> array = new FixedArray4<double>();
            array[0] = 1.1;
            array[1] = 2.2;
            array[2] = 3.3;
            array[3] = 4.4;
            
            Assert.Equal(1.1, array[0]);
            Assert.Equal(2.2, array[1]);
            Assert.Equal(3.3, array[2]);
            Assert.Equal(4.4, array[3]);
        }

        /// <summary>
        ///     Tests that default values should be default for type
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeDefaultForType()
        {
            FixedArray4<int> array = new FixedArray4<int>();
            
            Assert.Equal(0, array[0]);
            Assert.Equal(0, array[1]);
            Assert.Equal(0, array[2]);
            Assert.Equal(0, array[3]);
        }

        /// <summary>
        ///     Tests that updating all indices should work correctly
        /// </summary>
        [Fact]
        public void UpdatingAllIndices_ShouldWorkCorrectly()
        {
            FixedArray4<string> array = new FixedArray4<string>();
            
            array[0] = "One";
            array[1] = "Two";
            array[2] = "Three";
            array[3] = "Four";
            
            Assert.Equal("One", array[0]);
            Assert.Equal("Two", array[1]);
            Assert.Equal("Three", array[2]);
            Assert.Equal("Four", array[3]);
        }
    }
}


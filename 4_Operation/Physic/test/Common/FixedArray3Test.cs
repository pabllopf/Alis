// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray3Test.cs
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
    ///     The fixed array 3 test class
    /// </summary>
    public class FixedArray3Test
    {
        /// <summary>
        ///     Tests that indexer get should return correct values
        /// </summary>
        [Fact]
        public void Indexer_Get_ShouldReturnCorrectValues()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            array[0] = 10;
            array[1] = 20;
            array[2] = 30;
            
            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);
            Assert.Equal(30, array[2]);
        }

        /// <summary>
        ///     Tests that indexer set should update all values
        /// </summary>
        [Fact]
        public void Indexer_Set_ShouldUpdateAllValues()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            
            array[0] = 100;
            array[1] = 200;
            array[2] = 300;
            
            Assert.Equal(100, array[0]);
            Assert.Equal(200, array[1]);
            Assert.Equal(300, array[2]);
        }

        /// <summary>
        ///     Tests that indexer with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithInvalidIndex_ShouldThrowException()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[3]);
        }

        /// <summary>
        ///     Tests that indexer set with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_SetWithInvalidIndex_ShouldThrowException()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[3] = 100);
        }

        /// <summary>
        ///     Tests that indexer with negative index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithNegativeIndex_ShouldThrowException()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[-1]);
        }

        /// <summary>
        ///     Tests that indexer with float values should work
        /// </summary>
        [Fact]
        public void Indexer_WithFloatValues_ShouldWork()
        {
            FixedArray3<float> array = new FixedArray3<float>();
            array[0] = 1.5f;
            array[1] = 2.5f;
            array[2] = 3.5f;
            
            Assert.Equal(1.5f, array[0]);
            Assert.Equal(2.5f, array[1]);
            Assert.Equal(3.5f, array[2]);
        }

        /// <summary>
        ///     Tests that default values should be default for type
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeDefaultForType()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            
            Assert.Equal(0, array[0]);
            Assert.Equal(0, array[1]);
            Assert.Equal(0, array[2]);
        }

        /// <summary>
        ///     Tests that multiple sets on same index should update correctly
        /// </summary>
        [Fact]
        public void MultipleSetsOnSameIndex_ShouldUpdateCorrectly()
        {
            FixedArray3<int> array = new FixedArray3<int>();
            
            array[0] = 10;
            array[0] = 20;
            array[1] = 30;
            array[1] = 40;
            
            Assert.Equal(20, array[0]);
            Assert.Equal(40, array[1]);
        }
    }
}


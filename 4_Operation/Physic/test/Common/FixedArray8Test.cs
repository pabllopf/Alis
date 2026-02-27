// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedArray8Test.cs
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
    ///     The fixed array 8 test class
    /// </summary>
    public class FixedArray8Test
    {
        /// <summary>
        ///     Tests that indexer get should return correct values
        /// </summary>
        [Fact]
        public void Indexer_Get_ShouldReturnCorrectValues()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            for (int i = 0; i < 8; i++)
            {
                array[i] = (i + 1) * 10;
            }
            
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal((i + 1) * 10, array[i]);
            }
        }

        /// <summary>
        ///     Tests that indexer set should update all values
        /// </summary>
        [Fact]
        public void Indexer_Set_ShouldUpdateAllValues()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            array[0] = 100;
            array[1] = 200;
            array[2] = 300;
            array[3] = 400;
            array[4] = 500;
            array[5] = 600;
            array[6] = 700;
            array[7] = 800;
            
            Assert.Equal(100, array[0]);
            Assert.Equal(200, array[1]);
            Assert.Equal(300, array[2]);
            Assert.Equal(400, array[3]);
            Assert.Equal(500, array[4]);
            Assert.Equal(600, array[5]);
            Assert.Equal(700, array[6]);
            Assert.Equal(800, array[7]);
        }

        /// <summary>
        ///     Tests that indexer with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithInvalidIndex_ShouldThrowException()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[8]);
        }

        /// <summary>
        ///     Tests that indexer set with invalid index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_SetWithInvalidIndex_ShouldThrowException()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[8] = 100);
        }

        /// <summary>
        ///     Tests that indexer with negative index should throw exception
        /// </summary>
        [Fact]
        public void Indexer_WithNegativeIndex_ShouldThrowException()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            Assert.Throws<CustomIndexOutOfRangeException>(() => array[-1]);
        }

        /// <summary>
        ///     Tests that indexer with float values should work
        /// </summary>
        [Fact]
        public void Indexer_WithFloatValues_ShouldWork()
        {
            FixedArray8<float> array = new FixedArray8<float>();
            for (int i = 0; i < 8; i++)
            {
                array[i] = (i + 1) * 1.5f;
            }
            
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal((i + 1) * 1.5f, array[i]);
            }
        }

        /// <summary>
        ///     Tests that default values should be default for type
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeDefaultForType()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(0, array[i]);
            }
        }

        /// <summary>
        ///     Tests that first and last indices should work correctly
        /// </summary>
        [Fact]
        public void FirstAndLastIndices_ShouldWorkCorrectly()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            array[0] = 1;
            array[7] = 8;
            
            Assert.Equal(1, array[0]);
            Assert.Equal(8, array[7]);
        }

        /// <summary>
        ///     Tests that middle indices should work correctly
        /// </summary>
        [Fact]
        public void MiddleIndices_ShouldWorkCorrectly()
        {
            FixedArray8<int> array = new FixedArray8<int>();
            
            array[3] = 30;
            array[4] = 40;
            
            Assert.Equal(30, array[3]);
            Assert.Equal(40, array[4]);
        }

        /// <summary>
        ///     Tests that indexer with complex type should work
        /// </summary>
        [Fact]
        public void Indexer_WithComplexType_ShouldWork()
        {
            FixedArray8<string> array = new FixedArray8<string>();
            
            array[0] = "Zero";
            array[7] = "Seven";
            
            Assert.Equal("Zero", array[0]);
            Assert.Equal("Seven", array[7]);
        }
    }
}


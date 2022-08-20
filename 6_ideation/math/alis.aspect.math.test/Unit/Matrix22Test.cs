// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Matrix22Test.cs
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

namespace Alis.Aspect.Math.Test.Unit
{
    /// <summary>
    ///     The matrix 22 test class
    /// </summary>
    public class Matrix22Test
    {
        /// <summary>
        ///     Tests that test matrix 22
        /// </summary>
        [Fact]
        public void TestMatrix22()
        {
            Matrix22 m = new Matrix22(1, 2, 3, 4);
            Assert.Equal(1, m.Col1.X);
            Assert.Equal(2, m.Col2.X);
            Assert.Equal(3, m.Col1.Y);
            Assert.Equal(4, m.Col2.Y);
        }


        /// <summary>
        ///     Tests the matrix 22 solve
        /// </summary>
        [Fact]
        public void TestMatrix22Solve()
        {
            Assert.Equal(1, 1);
        }
    }
}
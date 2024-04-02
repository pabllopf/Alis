// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureRandomTest.cs
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

namespace Alis.Core.Aspect.Security.Test
{
    /// <summary>
    ///     The secure random tests class
    /// </summary>
    public class SecureRandomTests
    {
        /// <summary>
        ///     Tests that test secure random instance
        /// </summary>
        [Fact]
        public void Test_SecureRandom_Instance()
        {
            Assert.NotNull(SecureRandom.Random);
        }

        /// <summary>
        ///     Tests that test secure random generate random number
        /// </summary>
        [Fact]
        public void Test_SecureRandom_GenerateRandomNumber()
        {
            int randomNumber = SecureRandom.Random.Next();
            Assert.InRange(randomNumber, int.MinValue, int.MaxValue);
        }

        /// <summary>
        ///     Tests that test secure random generate random number within range
        /// </summary>
        [Fact]
        public void Test_SecureRandom_GenerateRandomNumberWithinRange()
        {
            int randomNumber = SecureRandom.Random.Next(1, 10);
            Assert.InRange(randomNumber, 1, 10);
        }
    }
}
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Bvec2CoverageTests.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The bvec 2 coverage tests class
    /// </summary>
    public class Bvec2CoverageTests
    {
        /// <summary>
        ///     Tests that the constructor with coordinates sets the components
        /// </summary>
        [Fact]
        public void Bvec2_ConstructorWithCoordinates_SetsComponents()
        {
            Bvec2 vector = new Bvec2(true, false);

            Assert.True(vector.X);
            Assert.False(vector.Y);
        }

        /// <summary>
        ///     Tests that the default initialization has default components
        /// </summary>
        [Fact]
        public void Bvec2_DefaultInitialization_ComponentsHaveDefaultValues()
        {
            Bvec2 vector = default(Bvec2);

            Assert.False(vector.X);
            Assert.False(vector.Y);
        }

        /// <summary>
        ///     Tests that the fields can be mutated independently
        /// </summary>
        [Fact]
        public void Bvec2_MutateFields_ValuesAreUpdated()
        {
            Bvec2 vector = new Bvec2(false, false);

            vector.X = true;
            vector.Y = true;

            Assert.True(vector.X);
            Assert.True(vector.Y);
        }
    }
}
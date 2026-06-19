// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AreaLightBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Components.Light;
using Alis.Core.Ecs.Components.Light;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The area light builder test class
    /// </summary>
    public class AreaLightBuilderTest
    {
        /// <summary>
        /// Tests that constructor no args creates builder
        /// </summary>
        [Fact]
        public void Constructor_NoArgs_CreatesBuilder()
        {
            AreaLightBuilder builder = new AreaLightBuilder();
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns area light instance
        /// </summary>
        [Fact]
        public void Build_ReturnsAreaLightInstance()
        {
            AreaLightBuilder builder = new AreaLightBuilder();
            AreaLight result = builder.Build();
            Assert.NotNull(result);
        }
    }
}

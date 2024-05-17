// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpotLightBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Component.Light;
using Alis.Core.Ecs.Component.Light;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Light
{
    /// <summary>
    /// The spot light builder test class
    /// </summary>
    public class SpotLightBuilderTest
    {
        /// <summary>
        /// Tests that spot light builder default constructor valid input
        /// </summary>
        [Fact]
        public void SpotLightBuilder_DefaultConstructor_ValidInput()
        {
            SpotLightBuilder spotLightBuilder = new SpotLightBuilder();
            
            Assert.NotNull(spotLightBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            SpotLightBuilder spotLightBuilder = new SpotLightBuilder();
            
            SpotLight spotLight = spotLightBuilder.Build();
            
            Assert.NotNull(spotLight);
        }
    }
}
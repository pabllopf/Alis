// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ColliderTest.cs
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

using Alis.Test.Core.Ecs.Component.Collider.Sample;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Collider
{
    /// <summary>
    /// The collider test class
    /// </summary>
    public class ColliderTest
    {
        /// <summary>
        /// Tests that collider default constructor valid input
        /// </summary>
        [Fact]
        public void Collider_DefaultConstructor_ValidInput()
        {
            ColliderSample collider = new ColliderSample();
            
            Assert.NotNull(collider);
        }
        
        /// <summary>
        /// Tests that on start valid input
        /// </summary>
        [Fact]
        public void OnStart_ValidInput()
        {
            ColliderSample collider = new ColliderSample();
            
            collider.OnStart();
        }
        
        /// <summary>
        /// Tests that on update valid input
        /// </summary>
        [Fact]
        public void OnUpdate_ValidInput()
        {
            ColliderSample collider = new ColliderSample();
            
            collider.OnUpdate();
            
        
        }
    }
}
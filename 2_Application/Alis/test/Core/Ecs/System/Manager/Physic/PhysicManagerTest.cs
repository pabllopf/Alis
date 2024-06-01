// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicManagerTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.System.Manager.Physic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Core.Ecs.System.Manager.Physic
{
    /// <summary>
    /// The physic manager test class
    /// </summary>
    public class PhysicManagerTest
    {
        /// <summary>
        /// Tests that test on update
        /// </summary>
        [Fact]
        public void Test_OnUpdate()
        {
            VideoGame videoGame = new VideoGame();
            PhysicManager manager = new PhysicManager();
            manager.OnUpdate();
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test attach
        /// </summary>
        [Fact]
        public void Test_Attach()
        {
            VideoGame videoGame = new VideoGame();
            PhysicManager manager = new PhysicManager();
            Body body = new Body(
                new Vector2(0, 0), // position
                new Vector2(0, 0) // gravityScale
            );
            manager.Attach(body);
            // Asserts would go here
        }
        
        /// <summary>
        /// Tests that test un attach
        /// </summary>
        [Fact]
        public void Test_UnAttach()
        {
            PhysicManager manager = new PhysicManager();
            Body body = new Body(
                new Vector2(0, 0), // position
                new Vector2(0, 0) // gravityScale
            );
            manager.Attach(body);
            manager.UnAttach(body);
            // Asserts would go here
        }
    }
}
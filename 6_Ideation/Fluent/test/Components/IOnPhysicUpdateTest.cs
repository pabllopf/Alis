// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnPhysicUpdateTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnPhysicUpdate interface.
    ///     Tests the OnPhysicUpdate lifecycle method for physics simulation.
    /// </summary>
    public class IOnPhysicUpdateTest
    {
        /// <summary>
        ///     Tests that IOnPhysicUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IOnPhysicUpdate_CanBeImplemented()
        {
            PhysicUpdateHandler handler = new PhysicUpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnPhysicUpdate>(handler);
        }

        /// <summary>
        ///     Tests that OnPhysicUpdate method can be called.
        /// </summary>
        [Fact]
        public void OnPhysicUpdate_CanBeCalled()
        {
            PhysicUpdateHandler handler = new PhysicUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnPhysicUpdate(gameObject);
            Assert.Equal(1, handler.UpdateCount);
        }

        /// <summary>
        ///     Tests that OnPhysicUpdate counts physics steps.
        /// </summary>
        [Fact]
        public void OnPhysicUpdate_CountsPhysicsSteps()
        {
            PhysicUpdateHandler handler = new PhysicUpdateHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 50; i++)
            {
                handler.OnPhysicUpdate(gameObject);
            }

            Assert.Equal(50, handler.UpdateCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnPhysicUpdate.
        /// </summary>
        private class PhysicUpdateHandler : IOnPhysicUpdate
        {
            public int UpdateCount { get; private set; }

            public void OnPhysicUpdate(IGameObject self)
            {
                UpdateCount++;
            }
        }
    }
}
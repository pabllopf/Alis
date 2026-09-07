// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferAddCompEventTest.cs
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

using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests targeting the uncovered AddComp event branch in ProcessAddComponents.
    /// </summary>
    [CollectionDefinition("CommandBufferAddCompEventTest", DisableParallelization = true)]
    public class CommandBufferAddCompEventTest
    {
        /// <summary>
        ///     Ensures the per-entity OnComponentAdded normal event is invoked during Playback
        ///     when a component is added via CommandBuffer.AddComponent, covering the
        ///     HasEvent(AddComp) true-branch and GenericEvent invocation inside ProcessAddComponents.
        /// </summary>
        [Fact]
        public void AddComponent_ViaBuffer_WithSubscribedAddEvent_FiresHandler()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new TestComponent {Value = 1});
                int addCount = 0;
                entity.OnComponentAdded += (_, _) => addCount++;

                CommandBuffer buffer = new CommandBuffer(scene);
                buffer.AddComponent<AnotherComponent>(entity, new AnotherComponent {Name = "test"});
                buffer.Playback();

                Assert.Equal(1, addCount);
            }
        }
    }
}

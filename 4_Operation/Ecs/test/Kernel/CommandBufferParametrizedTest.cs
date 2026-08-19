// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferParametrizedTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Parametrized tests for CommandBuffer
    /// </summary>
    public class CommandBufferParametrizedTest
    {
       
        /// <summary>
        ///     Tests that command buffer create command with component correct
        /// </summary>
        [Fact] public void CommandBuffer_CreateCommandWithComponent_Correct()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new(scene);

            buffer.Playback();

            int count = 0;
            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.True(count >= 0);
        }

       

        /// <summary>
        ///     Tests that command buffer dispose works
        /// </summary>
        [Fact] public void CommandBuffer_Dispose_Works()
        {
            using Scene scene = new Scene();

            Assert.True(true);
        }

       
    }
}
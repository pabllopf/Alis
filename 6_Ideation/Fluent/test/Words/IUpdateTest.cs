// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IUpdateTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IUpdate interface.
    ///     Tests the Update method for modification operations.
    /// </summary>
    public class IUpdateTest
    {
        /// <summary>
        ///     Helper implementation of IUpdate.
        /// </summary>
        private class UpdateHandler : IUpdate<int,int>
        {
            public int UpdateCount { get; private set; }
            public bool WasUpdated { get; private set; }

            public void Update()
            {
                WasUpdated = true;
                UpdateCount++;
            }

            public int Update(int obj) => throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Tests that IUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IUpdate_CanBeImplemented()
        {
            var handler = new UpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IUpdate<int,int>>(handler);
        }

        /// <summary>
        ///     Tests that Update method can be called.
        /// </summary>
        [Fact]
        public void Update_CanBeCalled()
        {
            var handler = new UpdateHandler();
            handler.Update();
            Assert.True(handler.WasUpdated);
        }

        /// <summary>
        ///     Tests that Update increments counter.
        /// </summary>
        [Fact]
        public void Update_IncrementsCounter()
        {
            var handler = new UpdateHandler();
            handler.Update();
            Assert.Equal(1, handler.UpdateCount);
            handler.Update();
            Assert.Equal(2, handler.UpdateCount);
        }

        /// <summary>
        ///     Tests Update called in sequence.
        /// </summary>
        [Fact]
        public void Update_WorksInSequence()
        {
            var handler = new UpdateHandler();
            for (int i = 0; i < 10; i++)
            {
                handler.Update();
            }
            Assert.Equal(10, handler.UpdateCount);
        }
    }
}


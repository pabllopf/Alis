// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDTableRemainingCoverageTests.cs
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

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="IdTable{T}" />, targeting boxed APIs,
    ///     GC-reference cleanup, and event-invoke-with-consume.
    /// </summary>
    public class IdTableRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="IdTable.CreateBoxed" /> stores a boxed value
        ///     and the value is accessible via <see cref="IdTable{T}.Take" />.
        /// </summary>
        [Fact]
        public void CreateBoxed_StoresValue()
        {
            IdTable<int> table = new IdTable<int>();
            int index = table.CreateBoxed(42);
            Assert.Equal(42, table.Take(index));
        }

        /// <summary>
        ///     Tests that <see cref="IdTable.GetValueBoxed" /> retrieves a boxed value
        ///     from the table without removing it.
        /// </summary>
        [Fact]
        public void GetValueBoxed_RetrievesBoxedValue()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot = ref table.Create(out int index);
            slot = 99;

            object boxed = table.GetValueBoxed(index);

            Assert.Equal(99, boxed);
        }

        /// <summary>
        ///     Tests that <see cref="IdTable.TakeBoxed" /> retrieves a boxed value
        ///     from the table.
        /// </summary>
        [Fact]
        public void TakeBoxed_RetrievesBoxedValue()
        {
            IdTable<string> table = new IdTable<string>();
            ref string slot = ref table.Create(out int index);
            slot = "hello";

            object boxed = table.TakeBoxed(index);

            Assert.Equal("hello", boxed);
        }

        /// <summary>
        ///     Tests that <see cref="IdTable.Consume" /> with a reference type (where
        ///     <c>_hasGcReferences</c> is <c>true</c>) clears the stored value to its default.
        /// </summary>
        [Fact]
        public void Consume_WithReferenceType_ClearsValue()
        {
            IdTable<string> table = new IdTable<string>();
            ref string slot = ref table.Create(out int index);
            slot = "value";

            table.Consume(index);

            Assert.Null(table.Take(index));
        }

        /// <summary>
        ///     Tests that <see cref="IdTable.CreateBoxed" /> reuses a recycled index
        ///     after a call to <see cref="IdTable.Consume" />.
        /// </summary>
        [Fact]
        public void CreateBoxed_ReusesRecycledIndex()
        {
            IdTable<int> table = new IdTable<int>();
            int first = table.CreateBoxed(10);
            table.Consume(first);
            int second = table.CreateBoxed(20);

            Assert.Equal(first, second);
            Assert.Equal(20, table.Take(second));
        }

        /// <summary>
        ///     Tests that <see cref="IdTable{T}.InvokeEventWithAndConsume" /> recycles
        ///     the index even when the <c>genericEvent</c> argument is <c>null</c>.
        /// </summary>
        [Fact]
        public void InvokeEventWithAndConsume_WithNullEvent_RecyclesIndex()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot = ref table.Create(out int index);
            slot = 7;

            table.InvokeEventWithAndConsume(null, default, index);

            int recycled = table.CreateBoxed(3);
            Assert.Equal(index, recycled);
        }

        /// <summary>
        ///     Tests that <see cref="IdTable{T}.InvokeEventWithAndConsume" /> works
        ///     with an empty <see cref="GenericEvent" /> (no listeners) and recycles the index.
        /// </summary>
        [Fact]
        public void InvokeEventWithAndConsume_WithEmptyEvent_RecyclesIndex()
        {
            IdTable<int> table = new IdTable<int>();
            ref int slot = ref table.Create(out int index);
            slot = 7;

            GenericEvent emptyEvent = new GenericEvent();
            table.InvokeEventWithAndConsume(emptyEvent, default, index);

            int recycled = table.CreateBoxed(3);
            Assert.Equal(index, recycled);
        }
    }
}

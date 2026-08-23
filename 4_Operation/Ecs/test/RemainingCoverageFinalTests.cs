// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RemainingCoverageFinalTests.cs
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
using System.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The remaining coverage final tests class
    /// </summary>
    public class RemainingCoverageFinalTests
    {
        /// <summary>
        ///     Tests that command buffer with without entity throws
        /// </summary>
        [Fact]
        public void CommandBuffer_With_WithoutEntity_Throws()
        {
            using (Scene scene = new Scene())
            {
                CommandBuffer buffer = new CommandBuffer(scene);

                Assert.Throws<InvalidOperationException>(() => buffer.With(new Position {X = 1, Y = 2}));
            }
        }

        /// <summary>
        ///     Tests that command buffer with boxed without entity throws
        /// </summary>
        [Fact]
        public void CommandBuffer_WithBoxed_WithoutEntity_Throws()
        {
            using (Scene scene = new Scene())
            {
                CommandBuffer buffer = new CommandBuffer(scene);

                Assert.Throws<InvalidOperationException>(() => buffer.WithBoxed(new Position {X = 1, Y = 2}));
            }
        }

        /// <summary>
        ///     Tests that the enumerable helpers grows the array when capacity is exhausted
        /// </summary>
        [Fact]
        public void EnumerableHelpers_GrowsArray_WhenCapacityExhausted()
        {
            int length;
            int[] result = Alis.Core.Ecs.Collections.EnumerableHelpers.ToArray(new HugeEnumerable(), out length);

            Assert.Equal(40, length);
            Assert.True(result.Length >= 40);
        }

        /// <summary>
        ///     Tests that component registry factory for null type throws
        /// </summary>
        [Fact]
        public void ComponentFactory_ForNullType_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Component.GetComponentFactoryFromType(null));
        }

        /// <summary>
        ///     Tests that component registry factory for unregistered type throws
        /// </summary>
        [Fact]
        public void ComponentFactory_ForUnregisteredType_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Component.GetComponentFactoryFromType(typeof(UnregisteredComponent)));
        }

        /// <summary>
        ///     Tests that component id for an unregistered plain type throws through the component table lookup
        /// </summary>
        [Fact]
        public void ComponentId_ForUnregisteredType_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => Component.GetComponentId(typeof(UnregisteredComponent)));
        }
    }

    /// <summary>
    ///     The huge enumerable class used to force array growth
    /// </summary>
    internal sealed class HugeEnumerable : System.Collections.Generic.IEnumerable<int>
    {
        /// <summary>
        ///     The huge enumerator class
        /// </summary>
        internal sealed class HugeEnumerator : System.Collections.Generic.IEnumerator<int>
        {
            private int _index = -1;

            /// <summary>
            ///     Gets the current
            /// </summary>
            public int Current => _index;

            /// <summary>
            ///     Gets the current boxed
            /// </summary>
            object IEnumerator.Current => _index;

            /// <summary>
            ///     Moves the next
            /// </summary>
            public bool MoveNext()
            {
                _index++;
                return _index < 40;
            }

            /// <summary>
            ///     Resets this instance
            /// </summary>
            public void Reset() => _index = -1;

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
            }
        }

        /// <summary>
        ///     Gets the enumerator
        /// </summary>
        public System.Collections.Generic.IEnumerator<int> GetEnumerator() => new HugeEnumerator();

        /// <summary>
        ///     Gets the enumerator boxed
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    /// <summary>
    ///     The unregistered component struct used to test factory lookups
    /// </summary>
    internal struct UnregisteredComponent
    {
    }
}

// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeSameComponentsCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype same components coverage tests class
    /// </summary>
    public class ArchetypeSameComponentsCoverageTests
    {
        /// <summary>
        ///     The same components delegate
        /// </summary>
        /// <param name="stored">The stored</param>
        /// <param name="requested">The requested</param>
        /// <returns>The result</returns>
        private delegate bool SameComponentsDelegate(FastImmutableArray<ComponentId> stored, ReadOnlySpan<ComponentId> requested);

        /// <summary>
        ///     Invokes the private same components method.
        /// </summary>
        /// <param name="stored">The stored</param>
        /// <param name="requested">The requested</param>
        /// <returns>The result</returns>
        private static bool InvokeSameComponents(FastImmutableArray<ComponentId> stored, ComponentId[] requested)
        {
            MethodInfo method = typeof(Archetype).GetMethod("SameComponents",
                BindingFlags.NonPublic | BindingFlags.Static);
            SameComponentsDelegate del = (SameComponentsDelegate) method.CreateDelegate(typeof(SameComponentsDelegate));
            return del(stored, new ReadOnlySpan<ComponentId>(requested));
        }

        /// <summary>
        ///     Tests that same components with different lengths returns false.
        /// </summary>
        [Fact]
        public void SameComponents_WithDifferentLengths_ReturnsFalse()
        {
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(2);
            builder.Add(new ComponentId(1));
            builder.Add(new ComponentId(2));
            FastImmutableArray<ComponentId> stored = builder.ToImmutable();

            bool result = InvokeSameComponents(stored, new[] { new ComponentId(1) });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that same components with different elements returns false.
        /// </summary>
        [Fact]
        public void SameComponents_WithDifferentElements_ReturnsFalse()
        {
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(2);
            builder.Add(new ComponentId(1));
            builder.Add(new ComponentId(2));
            FastImmutableArray<ComponentId> stored = builder.ToImmutable();

            bool result = InvokeSameComponents(stored, new[] { new ComponentId(1), new ComponentId(3) });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that same components with equal content returns true.
        /// </summary>
        [Fact]
        public void SameComponents_WithEqualContent_ReturnsTrue()
        {
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(2);
            builder.Add(new ComponentId(1));
            builder.Add(new ComponentId(2));
            FastImmutableArray<ComponentId> stored = builder.ToImmutable();

            bool result = InvokeSameComponents(stored, new[] { new ComponentId(1), new ComponentId(2) });

            Assert.True(result);
        }
    }
}

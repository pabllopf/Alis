// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IFastImmutableArrayContractTest.cs
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
using Alis.Core.Aspect.Math.Collections;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Collections
{
    /// <summary>
    ///     Tests the IFastImmutableArray contract through reflection.
    /// </summary>
    public class IFastImmutableArrayContractTest
    {
        /// <summary>
        ///     Tests that FastImmutableArray implements IFastImmutableArray.
        /// </summary>
        [Fact]
        public void FastImmutableArray_ImplementsInternalContractInterface()
        {
            Type interfaceType = typeof(FastImmutableArray<int>).Assembly.GetType("Alis.Core.Aspect.Math.Collections.IFastImmutableArray", true);

            Assert.Contains(interfaceType, typeof(FastImmutableArray<int>).GetInterfaces());
        }

        /// <summary>
        ///     Tests that IFastImmutableArray.Array returns the same underlying array instance.
        /// </summary>
        [Fact]
        public void ContractArrayProperty_ReturnsBackingArrayReference()
        {
            int[] backingArray = {4, 8, 15, 16};
            object immutable = new FastImmutableArray<int>(backingArray);
            Type interfaceType = immutable.GetType().Assembly.GetType("Alis.Core.Aspect.Math.Collections.IFastImmutableArray", true);
            object untypedArray = interfaceType.GetProperty("Array")?.GetValue(immutable);

            Assert.Same(backingArray, untypedArray);
        }
    }
}

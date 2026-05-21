

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

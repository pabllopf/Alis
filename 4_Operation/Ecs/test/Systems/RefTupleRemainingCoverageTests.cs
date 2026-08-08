// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefTupleRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="RefTuple{T}" /> types.
    /// </summary>
    public class RefTupleRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity1_CreatesEmptyTuple()
        {
            RefTuple<int> tuple = new RefTuple<int>();

            tuple.Deconstruct(out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity2_CreatesEmptyTuple()
        {
            RefTuple<int, int> tuple = new RefTuple<int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2,T3}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity3_CreatesEmptyTuple()
        {
            RefTuple<int, int, int> tuple = new RefTuple<int, int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2,T3,T4}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity4_CreatesEmptyTuple()
        {
            RefTuple<int, int, int, int> tuple = new RefTuple<int, int, int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2,T3,T4,T5}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity5_CreatesEmptyTuple()
        {
            RefTuple<int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2,T3,T4,T5,T6}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity6_CreatesEmptyTuple()
        {
            RefTuple<int, int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2,T3,T4,T5,T6,T7}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity7_CreatesEmptyTuple()
        {
            RefTuple<int, int, int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int, int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="RefTuple{T1,T2,T3,T4,T5,T6,T7,T8}" /> can be deconstructed.
        /// </summary>
        [Fact]
        public void DefaultConstructor_Arity8_CreatesEmptyTuple()
        {
            RefTuple<int, int, int, int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int, int, int, int>();

            tuple.Deconstruct(out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _, out Ref<int> _);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity1_ReturnsCorrectRefs()
        {
            int[] arr = new int[1];
            arr[0] = 42;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            RefTuple<int> tuple = new RefTuple<int> { Item1 = ref1 };

            tuple.Deconstruct(out Ref<int> r1);

            Assert.Equal(42, (int)r1);
            Assert.Equal(42, (int)tuple.Item1);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity2_ReturnsCorrectRefs()
        {
            int[] arr = new int[2];
            arr[0] = 42;
            arr[1] = 100;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            RefTuple<int, int> tuple = new RefTuple<int, int> { Item1 = ref1, Item2 = ref2 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2);

            Assert.Equal(42, (int)r1);
            Assert.Equal(100, (int)r2);
            Assert.Equal(42, (int)tuple.Item1);
            Assert.Equal(100, (int)tuple.Item2);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2,T3}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity3_ReturnsCorrectRefs()
        {
            int[] arr = new int[3];
            arr[0] = 100;
            arr[1] = 200;
            arr[2] = 300;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            Ref<int> ref3 = new Ref<int>(arr, 2);
            RefTuple<int, int, int> tuple = new RefTuple<int, int, int> { Item1 = ref1, Item2 = ref2, Item3 = ref3 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2, out Ref<int> r3);

            Assert.Equal(100, (int)r1);
            Assert.Equal(200, (int)r2);
            Assert.Equal(300, (int)r3);
            Assert.Equal(100, (int)tuple.Item1);
            Assert.Equal(200, (int)tuple.Item2);
            Assert.Equal(300, (int)tuple.Item3);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2,T3,T4}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity4_ReturnsCorrectRefs()
        {
            int[] arr = new int[4];
            arr[0] = 10;
            arr[1] = 20;
            arr[2] = 30;
            arr[3] = 40;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            Ref<int> ref3 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 3);
            RefTuple<int, int, int, int> tuple = new RefTuple<int, int, int, int> { Item1 = ref1, Item2 = ref2, Item3 = ref3, Item4 = ref4 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4);

            Assert.Equal(10, (int)r1);
            Assert.Equal(20, (int)r2);
            Assert.Equal(30, (int)r3);
            Assert.Equal(40, (int)r4);
            Assert.Equal(10, (int)tuple.Item1);
            Assert.Equal(20, (int)tuple.Item2);
            Assert.Equal(30, (int)tuple.Item3);
            Assert.Equal(40, (int)tuple.Item4);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2,T3,T4,T5}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity5_ReturnsCorrectRefs()
        {
            int[] arr = new int[5];
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            arr[3] = 4;
            arr[4] = 5;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            Ref<int> ref3 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 3);
            Ref<int> ref5 = new Ref<int>(arr, 4);
            RefTuple<int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int> { Item1 = ref1, Item2 = ref2, Item3 = ref3, Item4 = ref4, Item5 = ref5 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5);

            Assert.Equal(1, (int)r1);
            Assert.Equal(2, (int)r2);
            Assert.Equal(3, (int)r3);
            Assert.Equal(4, (int)r4);
            Assert.Equal(5, (int)r5);
            Assert.Equal(1, (int)tuple.Item1);
            Assert.Equal(2, (int)tuple.Item2);
            Assert.Equal(3, (int)tuple.Item3);
            Assert.Equal(4, (int)tuple.Item4);
            Assert.Equal(5, (int)tuple.Item5);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2,T3,T4,T5,T6}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity6_ReturnsCorrectRefs()
        {
            int[] arr = new int[6];
            arr[0] = 100;
            arr[1] = 200;
            arr[2] = 300;
            arr[3] = 400;
            arr[4] = 500;
            arr[5] = 600;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            Ref<int> ref3 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 3);
            Ref<int> ref5 = new Ref<int>(arr, 4);
            Ref<int> ref6 = new Ref<int>(arr, 5);
            RefTuple<int, int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int, int> { Item1 = ref1, Item2 = ref2, Item3 = ref3, Item4 = ref4, Item5 = ref5, Item6 = ref6 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5, out Ref<int> r6);

            Assert.Equal(100, (int)r1);
            Assert.Equal(200, (int)r2);
            Assert.Equal(300, (int)r3);
            Assert.Equal(400, (int)r4);
            Assert.Equal(500, (int)r5);
            Assert.Equal(600, (int)r6);
            Assert.Equal(100, (int)tuple.Item1);
            Assert.Equal(200, (int)tuple.Item2);
            Assert.Equal(300, (int)tuple.Item3);
            Assert.Equal(400, (int)tuple.Item4);
            Assert.Equal(500, (int)tuple.Item5);
            Assert.Equal(600, (int)tuple.Item6);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2,T3,T4,T5,T6,T7}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity7_ReturnsCorrectRefs()
        {
            int[] arr = new int[7];
            arr[0] = 7;
            arr[1] = 14;
            arr[2] = 21;
            arr[3] = 28;
            arr[4] = 35;
            arr[5] = 42;
            arr[6] = 49;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            Ref<int> ref3 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 3);
            Ref<int> ref5 = new Ref<int>(arr, 4);
            Ref<int> ref6 = new Ref<int>(arr, 5);
            Ref<int> ref7 = new Ref<int>(arr, 6);
            RefTuple<int, int, int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int, int, int> { Item1 = ref1, Item2 = ref2, Item3 = ref3, Item4 = ref4, Item5 = ref5, Item6 = ref6, Item7 = ref7 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5, out Ref<int> r6, out Ref<int> r7);

            Assert.Equal(7, (int)r1);
            Assert.Equal(14, (int)r2);
            Assert.Equal(21, (int)r3);
            Assert.Equal(28, (int)r4);
            Assert.Equal(35, (int)r5);
            Assert.Equal(42, (int)r6);
            Assert.Equal(49, (int)r7);
            Assert.Equal(7, (int)tuple.Item1);
            Assert.Equal(14, (int)tuple.Item2);
            Assert.Equal(21, (int)tuple.Item3);
            Assert.Equal(28, (int)tuple.Item4);
            Assert.Equal(35, (int)tuple.Item5);
            Assert.Equal(42, (int)tuple.Item6);
            Assert.Equal(49, (int)tuple.Item7);
        }

        /// <summary>
        ///     Tests deconstruction and field access of <see cref="RefTuple{T1,T2,T3,T4,T5,T6,T7,T8}" />.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity8_ReturnsCorrectRefs()
        {
            int[] arr = new int[8];
            arr[0] = 11;
            arr[1] = 22;
            arr[2] = 33;
            arr[3] = 44;
            arr[4] = 55;
            arr[5] = 66;
            arr[6] = 77;
            arr[7] = 88;
            Ref<int> ref1 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 1);
            Ref<int> ref3 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 3);
            Ref<int> ref5 = new Ref<int>(arr, 4);
            Ref<int> ref6 = new Ref<int>(arr, 5);
            Ref<int> ref7 = new Ref<int>(arr, 6);
            Ref<int> ref8 = new Ref<int>(arr, 7);
            RefTuple<int, int, int, int, int, int, int, int> tuple = new RefTuple<int, int, int, int, int, int, int, int> { Item1 = ref1, Item2 = ref2, Item3 = ref3, Item4 = ref4, Item5 = ref5, Item6 = ref6, Item7 = ref7, Item8 = ref8 };

            tuple.Deconstruct(out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5, out Ref<int> r6, out Ref<int> r7, out Ref<int> r8);

            Assert.Equal(11, (int)r1);
            Assert.Equal(22, (int)r2);
            Assert.Equal(33, (int)r3);
            Assert.Equal(44, (int)r4);
            Assert.Equal(55, (int)r5);
            Assert.Equal(66, (int)r6);
            Assert.Equal(77, (int)r7);
            Assert.Equal(88, (int)r8);
            Assert.Equal(11, (int)tuple.Item1);
            Assert.Equal(22, (int)tuple.Item2);
            Assert.Equal(33, (int)tuple.Item3);
            Assert.Equal(44, (int)tuple.Item4);
            Assert.Equal(55, (int)tuple.Item5);
            Assert.Equal(66, (int)tuple.Item6);
            Assert.Equal(77, (int)tuple.Item7);
            Assert.Equal(88, (int)tuple.Item8);
        }
    }
}

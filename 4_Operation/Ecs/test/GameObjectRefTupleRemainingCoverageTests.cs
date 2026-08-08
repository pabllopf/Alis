// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRefTupleRemainingCoverageTests.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="GameObjectRefTuple{T1}" /> family of ref structs.
    /// </summary>
    public class GameObjectRefTupleRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity1()
        {
            int[] arr = new int[1] { 99 };
            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(99, (int)tuple.Item1);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity2()
        {
            int[] arr1 = new int[1] { 10 };
            int[] arr2 = new int[1] { 20 };
            GameObjectRefTuple<int, int> tuple = new GameObjectRefTuple<int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(10, (int)tuple.Item1);
            Assert.Equal(20, (int)tuple.Item2);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2, T3}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity3()
        {
            int[] arr1 = new int[1] { 11 };
            int[] arr2 = new int[1] { 22 };
            int[] arr3 = new int[1] { 33 };
            GameObjectRefTuple<int, int, int> tuple = new GameObjectRefTuple<int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0),
                Item3 = new Ref<int>(arr3, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(11, (int)tuple.Item1);
            Assert.Equal(22, (int)tuple.Item2);
            Assert.Equal(33, (int)tuple.Item3);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2, T3, T4}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity4()
        {
            int[] arr1 = new int[1] { 1 };
            int[] arr2 = new int[1] { 2 };
            int[] arr3 = new int[1] { 3 };
            int[] arr4 = new int[1] { 4 };
            GameObjectRefTuple<int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0),
                Item3 = new Ref<int>(arr3, 0),
                Item4 = new Ref<int>(arr4, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(1, (int)tuple.Item1);
            Assert.Equal(2, (int)tuple.Item2);
            Assert.Equal(3, (int)tuple.Item3);
            Assert.Equal(4, (int)tuple.Item4);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity5()
        {
            int[] arr1 = new int[1] { 5 };
            int[] arr2 = new int[1] { 10 };
            int[] arr3 = new int[1] { 15 };
            int[] arr4 = new int[1] { 20 };
            int[] arr5 = new int[1] { 25 };
            GameObjectRefTuple<int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0),
                Item3 = new Ref<int>(arr3, 0),
                Item4 = new Ref<int>(arr4, 0),
                Item5 = new Ref<int>(arr5, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(5, (int)tuple.Item1);
            Assert.Equal(10, (int)tuple.Item2);
            Assert.Equal(15, (int)tuple.Item3);
            Assert.Equal(20, (int)tuple.Item4);
            Assert.Equal(25, (int)tuple.Item5);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity6()
        {
            int[] arr1 = new int[1] { 100 };
            int[] arr2 = new int[1] { 200 };
            int[] arr3 = new int[1] { 300 };
            int[] arr4 = new int[1] { 400 };
            int[] arr5 = new int[1] { 500 };
            int[] arr6 = new int[1] { 600 };
            GameObjectRefTuple<int, int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0),
                Item3 = new Ref<int>(arr3, 0),
                Item4 = new Ref<int>(arr4, 0),
                Item5 = new Ref<int>(arr5, 0),
                Item6 = new Ref<int>(arr6, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(100, (int)tuple.Item1);
            Assert.Equal(200, (int)tuple.Item2);
            Assert.Equal(300, (int)tuple.Item3);
            Assert.Equal(400, (int)tuple.Item4);
            Assert.Equal(500, (int)tuple.Item5);
            Assert.Equal(600, (int)tuple.Item6);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6, T7}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity7()
        {
            int[] arr1 = new int[1] { 7 };
            int[] arr2 = new int[1] { 14 };
            int[] arr3 = new int[1] { 21 };
            int[] arr4 = new int[1] { 28 };
            int[] arr5 = new int[1] { 35 };
            int[] arr6 = new int[1] { 42 };
            int[] arr7 = new int[1] { 49 };
            GameObjectRefTuple<int, int, int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0),
                Item3 = new Ref<int>(arr3, 0),
                Item4 = new Ref<int>(arr4, 0),
                Item5 = new Ref<int>(arr5, 0),
                Item6 = new Ref<int>(arr6, 0),
                Item7 = new Ref<int>(arr7, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(7, (int)tuple.Item1);
            Assert.Equal(14, (int)tuple.Item2);
            Assert.Equal(21, (int)tuple.Item3);
            Assert.Equal(28, (int)tuple.Item4);
            Assert.Equal(35, (int)tuple.Item5);
            Assert.Equal(42, (int)tuple.Item6);
            Assert.Equal(49, (int)tuple.Item7);
        }

        /// <summary>
        ///     Verifies that a default-constructed <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6, T7, T8}" /> is usable after field assignment.
        /// </summary>
        [Fact]
        public void DefaultConstruction_Arity8()
        {
            int[] arr1 = new int[1] { 1 };
            int[] arr2 = new int[1] { 2 };
            int[] arr3 = new int[1] { 3 };
            int[] arr4 = new int[1] { 4 };
            int[] arr5 = new int[1] { 5 };
            int[] arr6 = new int[1] { 6 };
            int[] arr7 = new int[1] { 7 };
            int[] arr8 = new int[1] { 8 };
            GameObjectRefTuple<int, int, int, int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = new Ref<int>(arr1, 0),
                Item2 = new Ref<int>(arr2, 0),
                Item3 = new Ref<int>(arr3, 0),
                Item4 = new Ref<int>(arr4, 0),
                Item5 = new Ref<int>(arr5, 0),
                Item6 = new Ref<int>(arr6, 0),
                Item7 = new Ref<int>(arr7, 0),
                Item8 = new Ref<int>(arr8, 0)
            };

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(1, (int)tuple.Item1);
            Assert.Equal(2, (int)tuple.Item2);
            Assert.Equal(3, (int)tuple.Item3);
            Assert.Equal(4, (int)tuple.Item4);
            Assert.Equal(5, (int)tuple.Item5);
            Assert.Equal(6, (int)tuple.Item6);
            Assert.Equal(7, (int)tuple.Item7);
            Assert.Equal(8, (int)tuple.Item8);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity1_ReturnsCorrectValues()
        {
            int[] arr = new int[1] { 42 };
            Ref<int> item1 = new Ref<int>(arr, 0);
            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>
            {
                GameObject = default(GameObject),
                Item1 = item1
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1);

            Assert.Equal(42, (int)r1);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity2_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 42 };
            int[] arr2 = new int[1] { 100 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            GameObjectRefTuple<int, int> tuple = new GameObjectRefTuple<int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2);

            Assert.Equal(42, (int)r1);
            Assert.Equal(100, (int)r2);
        }

        /// <summary>
        ///     Verifies that field values assigned on a <see cref="GameObjectRefTuple{T1}" /> are read back correctly.
        /// </summary>
        [Fact]
        public void FieldAssignmentAndReadback_Arity1()
        {
            int[] arr = new int[1] { 77 };
            GameObjectRefTuple<int> tuple = new GameObjectRefTuple<int>();
            tuple.GameObject = default(GameObject);
            tuple.Item1 = new Ref<int>(arr, 0);

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(77, (int)tuple.Item1);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity3_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 1 };
            int[] arr2 = new int[1] { 2 };
            int[] arr3 = new int[1] { 3 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            Ref<int> item3 = new Ref<int>(arr3, 0);
            GameObjectRefTuple<int, int, int> tuple = new GameObjectRefTuple<int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2,
                Item3 = item3
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2, out Ref<int> r3);

            Assert.Equal(1, (int)r1);
            Assert.Equal(2, (int)r2);
            Assert.Equal(3, (int)r3);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2, T3, T4}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity4_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 10 };
            int[] arr2 = new int[1] { 20 };
            int[] arr3 = new int[1] { 30 };
            int[] arr4 = new int[1] { 40 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            Ref<int> item3 = new Ref<int>(arr3, 0);
            Ref<int> item4 = new Ref<int>(arr4, 0);
            GameObjectRefTuple<int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Item4 = item4
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4);

            Assert.Equal(10, (int)r1);
            Assert.Equal(20, (int)r2);
            Assert.Equal(30, (int)r3);
            Assert.Equal(40, (int)r4);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity5_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 100 };
            int[] arr2 = new int[1] { 200 };
            int[] arr3 = new int[1] { 300 };
            int[] arr4 = new int[1] { 400 };
            int[] arr5 = new int[1] { 500 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            Ref<int> item3 = new Ref<int>(arr3, 0);
            Ref<int> item4 = new Ref<int>(arr4, 0);
            Ref<int> item5 = new Ref<int>(arr5, 0);
            GameObjectRefTuple<int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Item4 = item4,
                Item5 = item5
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5);

            Assert.Equal(100, (int)r1);
            Assert.Equal(200, (int)r2);
            Assert.Equal(300, (int)r3);
            Assert.Equal(400, (int)r4);
            Assert.Equal(500, (int)r5);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity6_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 5 };
            int[] arr2 = new int[1] { 10 };
            int[] arr3 = new int[1] { 15 };
            int[] arr4 = new int[1] { 20 };
            int[] arr5 = new int[1] { 25 };
            int[] arr6 = new int[1] { 30 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            Ref<int> item3 = new Ref<int>(arr3, 0);
            Ref<int> item4 = new Ref<int>(arr4, 0);
            Ref<int> item5 = new Ref<int>(arr5, 0);
            Ref<int> item6 = new Ref<int>(arr6, 0);
            GameObjectRefTuple<int, int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Item4 = item4,
                Item5 = item5,
                Item6 = item6
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5, out Ref<int> r6);

            Assert.Equal(5, (int)r1);
            Assert.Equal(30, (int)r6);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6, T7}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity7_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 7 };
            int[] arr2 = new int[1] { 14 };
            int[] arr3 = new int[1] { 21 };
            int[] arr4 = new int[1] { 28 };
            int[] arr5 = new int[1] { 35 };
            int[] arr6 = new int[1] { 42 };
            int[] arr7 = new int[1] { 49 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            Ref<int> item3 = new Ref<int>(arr3, 0);
            Ref<int> item4 = new Ref<int>(arr4, 0);
            Ref<int> item5 = new Ref<int>(arr5, 0);
            Ref<int> item6 = new Ref<int>(arr6, 0);
            Ref<int> item7 = new Ref<int>(arr7, 0);
            GameObjectRefTuple<int, int, int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Item4 = item4,
                Item5 = item5,
                Item6 = item6,
                Item7 = item7
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5, out Ref<int> r6, out Ref<int> r7);

            Assert.Equal(7, (int)r1);
            Assert.Equal(49, (int)r7);
        }

        /// <summary>
        ///     Verifies that <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6, T7, T8}.Deconstruct" /> returns the expected values.
        /// </summary>
        [Fact]
        public void Deconstruct_Arity8_ReturnsCorrectValues()
        {
            int[] arr1 = new int[1] { 11 };
            int[] arr2 = new int[1] { 22 };
            int[] arr3 = new int[1] { 33 };
            int[] arr4 = new int[1] { 44 };
            int[] arr5 = new int[1] { 55 };
            int[] arr6 = new int[1] { 66 };
            int[] arr7 = new int[1] { 77 };
            int[] arr8 = new int[1] { 88 };
            Ref<int> item1 = new Ref<int>(arr1, 0);
            Ref<int> item2 = new Ref<int>(arr2, 0);
            Ref<int> item3 = new Ref<int>(arr3, 0);
            Ref<int> item4 = new Ref<int>(arr4, 0);
            Ref<int> item5 = new Ref<int>(arr5, 0);
            Ref<int> item6 = new Ref<int>(arr6, 0);
            Ref<int> item7 = new Ref<int>(arr7, 0);
            Ref<int> item8 = new Ref<int>(arr8, 0);
            GameObjectRefTuple<int, int, int, int, int, int, int, int> tuple = new GameObjectRefTuple<int, int, int, int, int, int, int, int>
            {
                GameObject = default(GameObject),
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Item4 = item4,
                Item5 = item5,
                Item6 = item6,
                Item7 = item7,
                Item8 = item8
            };

            tuple.Deconstruct(out GameObject go, out Ref<int> r1, out Ref<int> r2, out Ref<int> r3, out Ref<int> r4, out Ref<int> r5, out Ref<int> r6, out Ref<int> r7, out Ref<int> r8);

            Assert.Equal(11, (int)r1);
            Assert.Equal(88, (int)r8);
        }

        /// <summary>
        ///     Verifies that field values assigned on a <see cref="GameObjectRefTuple{T1, T2}" /> are read back correctly.
        /// </summary>
        [Fact]
        public void FieldAssignmentAndReadback_Arity2()
        {
            int[] arr1 = new int[1] { 10 };
            int[] arr2 = new int[1] { 20 };
            GameObjectRefTuple<int, int> tuple = new GameObjectRefTuple<int, int>();
            tuple.GameObject = default(GameObject);
            tuple.Item1 = new Ref<int>(arr1, 0);
            tuple.Item2 = new Ref<int>(arr2, 0);

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(10, (int)tuple.Item1);
            Assert.Equal(20, (int)tuple.Item2);
        }

        /// <summary>
        ///     Verifies that field values assigned on a <see cref="GameObjectRefTuple{T1, T2, T3}" /> are read back correctly.
        /// </summary>
        [Fact]
        public void FieldAssignmentAndReadback_Arity3()
        {
            int[] arr1 = new int[1] { 100 };
            int[] arr2 = new int[1] { 200 };
            int[] arr3 = new int[1] { 300 };
            GameObjectRefTuple<int, int, int> tuple = new GameObjectRefTuple<int, int, int>();
            tuple.GameObject = default(GameObject);
            tuple.Item1 = new Ref<int>(arr1, 0);
            tuple.Item2 = new Ref<int>(arr2, 0);
            tuple.Item3 = new Ref<int>(arr3, 0);

            Assert.Equal(default(GameObject), tuple.GameObject);
            Assert.Equal(100, (int)tuple.Item1);
            Assert.Equal(200, (int)tuple.Item2);
            Assert.Equal(300, (int)tuple.Item3);
        }
    }
}

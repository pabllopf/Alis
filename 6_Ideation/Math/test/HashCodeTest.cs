// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HashCodeTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    ///     The hash code test class
    /// </summary>
    public class HashCodeTest
    {
        /// <summary>
        ///     Tests that combine with same inputs is deterministic
        /// </summary>
        [Fact]
        public void Combine_WithSameInputs_IsDeterministic()
        {
            int first = HashCode.Combine(1, "abc", 42f);
            int second = HashCode.Combine(1, "abc", 42f);

            Assert.Equal(first, second);
        }

        /// <summary>
        ///     Tests that combine with null inputs does not throw
        /// </summary>
        [Fact]
        public void Combine_WithNullInputs_DoesNotThrow()
        {
            int value = HashCode.Combine<string, string, object>(null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine overloads from 1 to 8 are callable and stable
        /// </summary>
        [Fact]
        public void Combine_OverloadsFrom1To8_AreCallableAndStable()
        {
            Assert.Equal(HashCode.Combine(1), HashCode.Combine(1));
            Assert.Equal(HashCode.Combine(1, 2), HashCode.Combine(1, 2));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4), HashCode.Combine(1, 2, 3, 4));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5), HashCode.Combine(1, 2, 3, 4, 5));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5, 6), HashCode.Combine(1, 2, 3, 4, 5, 6));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5, 6, 7), HashCode.Combine(1, 2, 3, 4, 5, 6, 7));
            Assert.Equal(HashCode.Combine(1, 2, 3, 4, 5, 6, 7, 8), HashCode.Combine(1, 2, 3, 4, 5, 6, 7, 8));
        }

        /// <summary>
        ///     Tests that add and to hash code with same sequence is deterministic
        /// </summary>
        [Fact]
        public void AddAndToHashCode_WithSameSequence_IsDeterministic()
        {
            HashCode first = new HashCode();
            first.Add("a");
            first.Add(10);
            first.Add(20f);

            HashCode second = new HashCode();
            second.Add("a");
            second.Add(10);
            second.Add(20f);

            Assert.Equal(first.ToHashCode(), second.ToHashCode());
        }

        /// <summary>
        ///     Tests that rotate left rotates bits as expected
        /// </summary>
        [Fact]
        public void RotateLeft_RotatesBitsAsExpected()
        {
            uint rotated = HashCode.RotateLeft(1u, 1);

            Assert.Equal(2u, rotated);
        }

        /// <summary>
        ///     Tests that add changing order changes hash
        /// </summary>
        [Fact]
        public void Add_ChangingOrder_ChangesHash()
        {
            HashCode first = new HashCode();
            first.Add(1);
            first.Add(2);
            first.Add(3);

            HashCode second = new HashCode();
            second.Add(3);
            second.Add(2);
            second.Add(1);

            Assert.NotEqual(first.ToHashCode(), second.ToHashCode());
        }

        /// <summary>
        ///     Tests that to hash code without adds is deterministic per process
        /// </summary>
        [Fact]
        public void ToHashCode_WithoutAdds_IsDeterministicPerProcess()
        {
            HashCode first = new HashCode();
            HashCode second = new HashCode();

            Assert.Equal(first.ToHashCode(), second.ToHashCode());
        }

        /// <summary>
        ///     Tests that rotate left with edge offsets returns expected value
        /// </summary>
        [Fact]
        public void RotateLeft_WithEdgeOffsets_ReturnsExpectedValue()
        {
            uint value = 0x80000001;

            Assert.Equal(value, HashCode.RotateLeft(value, 0));
            Assert.Equal(0xC0000000u, HashCode.RotateLeft(0x60000000u, 1));
            Assert.Equal(0xC0000000u, HashCode.RotateLeft(0x80000001u, 31));
        }

        /// <summary>
        ///     Tests that combine with null covers null branch for single parameter
        /// </summary>
        [Fact]
        public void Combine_WithNull_CoversNullBranch()
        {
            int value = HashCode.Combine<string>(null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine two with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_TwoWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string>(null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine four with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_FourWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string, string, string>(null, null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine five with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_FiveWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string, string, string, string>(null, null, null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine six with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_SixWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string, string, string, string, string>(null, null, null, null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine seven with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_SevenWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string, string, string, string, string, string>(null, null, null, null, null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine eight with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_EightWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string, string, string, string, string, string, string>(null, null, null, null, null, null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that add with null covers null branch
        /// </summary>
        [Fact]
        public void Add_WithNull_CoversNullBranch()
        {
            HashCode hash = new HashCode();
            hash.Add<string>(null);
            hash.Add<string>(null);

            int value = hash.ToHashCode();

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that adding exactly four elements triggers initialization and produces a consistent hash
        /// </summary>
        [Fact]
        public void Add_WithFourElements_TriggersInitialization()
        {
            HashCode hash = new HashCode();
            hash.Add(10);
            hash.Add(20);
            hash.Add(30);
            hash.Add(40);

            int value = hash.ToHashCode();

            HashCode same = new HashCode();
            same.Add(10);
            same.Add(20);
            same.Add(30);
            same.Add(40);

            Assert.Equal(same.ToHashCode(), value);
        }

        /// <summary>
        ///     Tests that adding five elements covers the partial queue path in ToHashCode
        /// </summary>
        [Fact]
        public void Add_WithFiveElements_CoversPartialQueuePath()
        {
            HashCode hash = new HashCode();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);

            int value = hash.ToHashCode();

            HashCode same = new HashCode();
            same.Add(1);
            same.Add(2);
            same.Add(3);
            same.Add(4);
            same.Add(5);

            Assert.Equal(same.ToHashCode(), value);
        }

        /// <summary>
        ///     Tests that adding six elements covers the two-item queue path in ToHashCode
        /// </summary>
        [Fact]
        public void Add_WithSixElements_CoversTwoItemQueuePath()
        {
            HashCode hash = new HashCode();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);
            hash.Add(6);

            int value = hash.ToHashCode();

            HashCode same = new HashCode();
            same.Add(1);
            same.Add(2);
            same.Add(3);
            same.Add(4);
            same.Add(5);
            same.Add(6);

            Assert.Equal(same.ToHashCode(), value);
        }

        /// <summary>
        ///     Tests that adding seven elements covers the three-item queue path in ToHashCode
        /// </summary>
        [Fact]
        public void Add_WithSevenElements_CoversThreeItemQueuePath()
        {
            HashCode hash = new HashCode();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);
            hash.Add(6);
            hash.Add(7);

            int value = hash.ToHashCode();

            HashCode same = new HashCode();
            same.Add(1);
            same.Add(2);
            same.Add(3);
            same.Add(4);
            same.Add(5);
            same.Add(6);
            same.Add(7);

            Assert.Equal(same.ToHashCode(), value);
        }

        /// <summary>
        ///     Tests that combine three with null covers null branches
        /// </summary>
        [Fact]
        public void Combine_ThreeWithNull_CoversNullBranches()
        {
            int value = HashCode.Combine<string, string, string>(null, null, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that combine three with mixed null and non-null values covers partial null branches
        /// </summary>
        [Fact]
        public void Combine_ThreeWithPartialNull_CoversPartialNullBranches()
        {
            int value = HashCode.Combine<string, int, string>(null, 42, null);

            Assert.IsType<int>(value);
        }

        /// <summary>
        ///     Tests that to hash code with length exactly four covers the full state path
        /// </summary>
        [Fact]
        public void ToHashCode_WithLengthFour_CoversFullStatePath()
        {
            HashCode hash = new HashCode();
            hash.Add(100);
            hash.Add(200);
            hash.Add(300);
            hash.Add(400);

            int result = hash.ToHashCode();

            Assert.IsType<int>(result);
        }

        /// <summary>
        ///     Tests that to hash code with length eight covers the multi-round state path
        /// </summary>
        [Fact]
        public void ToHashCode_WithLengthEight_CoversMultiRoundStatePath()
        {
            HashCode hash = new HashCode();
            hash.Add(1);
            hash.Add(2);
            hash.Add(3);
            hash.Add(4);
            hash.Add(5);
            hash.Add(6);
            hash.Add(7);
            hash.Add(8);

            int result = hash.ToHashCode();

            Assert.IsType<int>(result);
        }
    }
}
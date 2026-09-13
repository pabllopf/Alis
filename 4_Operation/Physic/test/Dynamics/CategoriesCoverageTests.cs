// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CategoriesCoverageTests.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The categories coverage tests class
    /// </summary>
    public class CategoriesCoverageTests
    {
        /// <summary>
        ///     Tests that none equals zero
        /// </summary>
        [Fact]
        public void None_EqualsZero()
        {
            Assert.Equal(0, (int) Categories.None);
        }

        /// <summary>
        ///     Tests that cat one equals one
        /// </summary>
        [Fact]
        public void Cat1_EqualsOne()
        {
            Assert.Equal(0x00000001, (int) Categories.Cat1);
        }

        /// <summary>
        ///     Tests that cat two equals two
        /// </summary>
        [Fact]
        public void Cat2_EqualsTwo()
        {
            Assert.Equal(0x00000002, (int) Categories.Cat2);
        }

        /// <summary>
        ///     Tests that cat three equals four
        /// </summary>
        [Fact]
        public void Cat3_EqualsFour()
        {
            Assert.Equal(0x00000004, (int) Categories.Cat3);
        }

        /// <summary>
        ///     Tests that cat four equals eight
        /// </summary>
        [Fact]
        public void Cat4_EqualsEight()
        {
            Assert.Equal(0x00000008, (int) Categories.Cat4);
        }

        /// <summary>
        ///     Tests that cat five equals sixteen
        /// </summary>
        [Fact]
        public void Cat5_EqualsSixteen()
        {
            Assert.Equal(0x00000010, (int) Categories.Cat5);
        }

        /// <summary>
        ///     Tests that cat six equals thirty two
        /// </summary>
        [Fact]
        public void Cat6_EqualsThirtyTwo()
        {
            Assert.Equal(0x00000020, (int) Categories.Cat6);
        }

        /// <summary>
        ///     Tests that cat seven equals sixty four
        /// </summary>
        [Fact]
        public void Cat7_EqualsSixtyFour()
        {
            Assert.Equal(0x00000040, (int) Categories.Cat7);
        }

        /// <summary>
        ///     Tests that cat eight equals one hundred twenty eight
        /// </summary>
        [Fact]
        public void Cat8_EqualsOneHundredTwentyEight()
        {
            Assert.Equal(0x00000080, (int) Categories.Cat8);
        }

        /// <summary>
        ///     Tests that cat nine equals two hundred fifty six
        /// </summary>
        [Fact]
        public void Cat9_EqualsTwoHundredFiftySix()
        {
            Assert.Equal(0x00000100, (int) Categories.Cat9);
        }

        /// <summary>
        ///     Tests that cat ten equals five hundred twelve
        /// </summary>
        [Fact]
        public void Cat10_EqualsFiveHundredTwelve()
        {
            Assert.Equal(0x00000200, (int) Categories.Cat10);
        }

        /// <summary>
        ///     Tests that cat eleven equals one thousand twenty four
        /// </summary>
        [Fact]
        public void Cat11_EqualsOneThousandTwentyFour()
        {
            Assert.Equal(0x00000400, (int) Categories.Cat11);
        }

        /// <summary>
        ///     Tests that cat twelve equals two thousand forty eight
        /// </summary>
        [Fact]
        public void Cat12_EqualsTwoThousandFortyEight()
        {
            Assert.Equal(0x00000800, (int) Categories.Cat12);
        }

        /// <summary>
        ///     Tests that cat thirteen equals four thousand ninety six
        /// </summary>
        [Fact]
        public void Cat13_EqualsFourThousandNinetySix()
        {
            Assert.Equal(0x00001000, (int) Categories.Cat13);
        }

        /// <summary>
        ///     Tests that cat fourteen equals eight thousand one hundred ninety two
        /// </summary>
        [Fact]
        public void Cat14_EqualsEightThousandOneHundredNinetyTwo()
        {
            Assert.Equal(0x00002000, (int) Categories.Cat14);
        }

        /// <summary>
        ///     Tests that cat fifteen equals sixteen thousand three hundred eighty four
        /// </summary>
        [Fact]
        public void Cat15_EqualsSixteenThousandThreeHundredEightyFour()
        {
            Assert.Equal(0x00004000, (int) Categories.Cat15);
        }

        /// <summary>
        ///     Tests that cat sixteen equals thirty two thousand seven hundred sixty eight
        /// </summary>
        [Fact]
        public void Cat16_EqualsThirtyTwoThousandSevenHundredSixtyEight()
        {
            Assert.Equal(0x00008000, (int) Categories.Cat16);
        }

        /// <summary>
        ///     Tests that cat seventeen equals six fifty five thirty six
        /// </summary>
        [Fact]
        public void Cat17_EqualsHex10000()
        {
            Assert.Equal(0x00010000, (int) Categories.Cat17);
        }

        /// <summary>
        ///     Tests that cat eighteen equals hex two zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat18_EqualsHex20000()
        {
            Assert.Equal(0x00020000, (int) Categories.Cat18);
        }

        /// <summary>
        ///     Tests that cat nineteen equals hex four zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat19_EqualsHex40000()
        {
            Assert.Equal(0x00040000, (int) Categories.Cat19);
        }

        /// <summary>
        ///     Tests that cat twenty equals hex eight zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat20_EqualsHex80000()
        {
            Assert.Equal(0x00080000, (int) Categories.Cat20);
        }

        /// <summary>
        ///     Tests that cat twenty one equals hex one zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat21_EqualsHex100000()
        {
            Assert.Equal(0x00100000, (int) Categories.Cat21);
        }

        /// <summary>
        ///     Tests that cat twenty two equals hex two zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat22_EqualsHex200000()
        {
            Assert.Equal(0x00200000, (int) Categories.Cat22);
        }

        /// <summary>
        ///     Tests that cat twenty three equals hex four zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat23_EqualsHex400000()
        {
            Assert.Equal(0x00400000, (int) Categories.Cat23);
        }

        /// <summary>
        ///     Tests that cat twenty four equals hex eight zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat24_EqualsHex800000()
        {
            Assert.Equal(0x00800000, (int) Categories.Cat24);
        }

        /// <summary>
        ///     Tests that cat twenty five equals hex one zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat25_EqualsHex1000000()
        {
            Assert.Equal(0x01000000, (int) Categories.Cat25);
        }

        /// <summary>
        ///     Tests that cat twenty six equals hex two zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat26_EqualsHex2000000()
        {
            Assert.Equal(0x02000000, (int) Categories.Cat26);
        }

        /// <summary>
        ///     Tests that cat twenty seven equals hex four zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat27_EqualsHex4000000()
        {
            Assert.Equal(0x04000000, (int) Categories.Cat27);
        }

        /// <summary>
        ///     Tests that cat twenty eight equals hex eight zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat28_EqualsHex8000000()
        {
            Assert.Equal(0x08000000, (int) Categories.Cat28);
        }

        /// <summary>
        ///     Tests that cat twenty nine equals hex one zero zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat29_EqualsHex10000000()
        {
            Assert.Equal(0x10000000, (int) Categories.Cat29);
        }

        /// <summary>
        ///     Tests that cat thirty equals hex two zero zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat30_EqualsHex20000000()
        {
            Assert.Equal(0x20000000, (int) Categories.Cat30);
        }

        /// <summary>
        ///     Tests that cat thirty one equals hex four zero zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat31_EqualsHex40000000()
        {
            Assert.Equal(0x40000000, (int) Categories.Cat31);
        }

        /// <summary>
        ///     Tests that all equals int max value minus one
        /// </summary>
        [Fact]
        public void All_EqualsIntMaxValue()
        {
            Assert.Equal(0x7FFFFFFF, (int) Categories.All);
            Assert.Equal(int.MaxValue, (int) Categories.All);
        }

        /// <summary>
        ///     Tests that all contains every cat flag
        /// </summary>
        [Fact]
        public void All_ContainsEveryCatFlag()
        {
            Assert.True((Categories.All & Categories.Cat1) == Categories.Cat1);
            Assert.True((Categories.All & Categories.Cat15) == Categories.Cat15);
            Assert.True((Categories.All & Categories.Cat31) == Categories.Cat31);
        }

        /// <summary>
        ///     Tests that cat flags are distinct powers of two
        /// </summary>
        [Fact]
        public void CatFlags_AreDistinctPowersOfTwo()
        {
            Categories combined = Categories.Cat1 | Categories.Cat5 | Categories.Cat31;
            Assert.Equal(0x40000011, (int) combined);
            Assert.True((combined & Categories.Cat2) == 0);
        }
    }
}

// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCategoriesCoverageTests.cs
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
using Alis.Core.Physic.Common.Logic;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The controller categories coverage tests class
    /// </summary>
    public class ControllerCategoriesCoverageTests
    {
        /// <summary>
        ///     Tests that none equals zero
        /// </summary>
        [Fact]
        public void None_EqualsZero()
        {
            Assert.Equal(0, (int) ControllerCategories.None);
        }

        /// <summary>
        ///     Tests that cat zero one equals one
        /// </summary>
        [Fact]
        public void Cat01_EqualsOne()
        {
            Assert.Equal(0x00000001, (int) ControllerCategories.Cat01);
        }

        /// <summary>
        ///     Tests that cat zero two equals two
        /// </summary>
        [Fact]
        public void Cat02_EqualsTwo()
        {
            Assert.Equal(0x00000002, (int) ControllerCategories.Cat02);
        }

        /// <summary>
        ///     Tests that cat zero three equals four
        /// </summary>
        [Fact]
        public void Cat03_EqualsFour()
        {
            Assert.Equal(0x00000004, (int) ControllerCategories.Cat03);
        }

        /// <summary>
        ///     Tests that cat zero four equals eight
        /// </summary>
        [Fact]
        public void Cat04_EqualsEight()
        {
            Assert.Equal(0x00000008, (int) ControllerCategories.Cat04);
        }

        /// <summary>
        ///     Tests that cat zero five equals sixteen
        /// </summary>
        [Fact]
        public void Cat05_EqualsSixteen()
        {
            Assert.Equal(0x00000010, (int) ControllerCategories.Cat05);
        }

        /// <summary>
        ///     Tests that cat zero six equals thirty two
        /// </summary>
        [Fact]
        public void Cat06_EqualsThirtyTwo()
        {
            Assert.Equal(0x00000020, (int) ControllerCategories.Cat06);
        }

        /// <summary>
        ///     Tests that cat zero seven equals sixty four
        /// </summary>
        [Fact]
        public void Cat07_EqualsSixtyFour()
        {
            Assert.Equal(0x00000040, (int) ControllerCategories.Cat07);
        }

        /// <summary>
        ///     Tests that cat zero eight equals one hundred twenty eight
        /// </summary>
        [Fact]
        public void Cat08_EqualsOneHundredTwentyEight()
        {
            Assert.Equal(0x00000080, (int) ControllerCategories.Cat08);
        }

        /// <summary>
        ///     Tests that cat zero nine equals two hundred fifty six
        /// </summary>
        [Fact]
        public void Cat09_EqualsTwoHundredFiftySix()
        {
            Assert.Equal(0x00000100, (int) ControllerCategories.Cat09);
        }

        /// <summary>
        ///     Tests that cat ten equals five hundred twelve
        /// </summary>
        [Fact]
        public void Cat10_EqualsFiveHundredTwelve()
        {
            Assert.Equal(0x00000200, (int) ControllerCategories.Cat10);
        }

        /// <summary>
        ///     Tests that cat eleven equals one thousand twenty four
        /// </summary>
        [Fact]
        public void Cat11_EqualsOneThousandTwentyFour()
        {
            Assert.Equal(0x00000400, (int) ControllerCategories.Cat11);
        }

        /// <summary>
        ///     Tests that cat twelve equals two thousand forty eight
        /// </summary>
        [Fact]
        public void Cat12_EqualsTwoThousandFortyEight()
        {
            Assert.Equal(0x00000800, (int) ControllerCategories.Cat12);
        }

        /// <summary>
        ///     Tests that cat thirteen equals four thousand ninety six
        /// </summary>
        [Fact]
        public void Cat13_EqualsFourThousandNinetySix()
        {
            Assert.Equal(0x00001000, (int) ControllerCategories.Cat13);
        }

        /// <summary>
        ///     Tests that cat fourteen equals eight thousand one hundred ninety two
        /// </summary>
        [Fact]
        public void Cat14_EqualsEightThousandOneHundredNinetyTwo()
        {
            Assert.Equal(0x00002000, (int) ControllerCategories.Cat14);
        }

        /// <summary>
        ///     Tests that cat fifteen equals sixteen thousand three hundred eighty four
        /// </summary>
        [Fact]
        public void Cat15_EqualsSixteenThousandThreeHundredEightyFour()
        {
            Assert.Equal(0x00004000, (int) ControllerCategories.Cat15);
        }

        /// <summary>
        ///     Tests that cat sixteen equals thirty two thousand seven hundred sixty eight
        /// </summary>
        [Fact]
        public void Cat16_EqualsThirtyTwoThousandSevenHundredSixtyEight()
        {
            Assert.Equal(0x00008000, (int) ControllerCategories.Cat16);
        }

        /// <summary>
        ///     Tests that cat seventeen equals hex one zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat17_EqualsHex10000()
        {
            Assert.Equal(0x00010000, (int) ControllerCategories.Cat17);
        }

        /// <summary>
        ///     Tests that cat eighteen equals hex two zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat18_EqualsHex20000()
        {
            Assert.Equal(0x00020000, (int) ControllerCategories.Cat18);
        }

        /// <summary>
        ///     Tests that cat nineteen equals hex four zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat19_EqualsHex40000()
        {
            Assert.Equal(0x00040000, (int) ControllerCategories.Cat19);
        }

        /// <summary>
        ///     Tests that cat twenty equals hex eight zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat20_EqualsHex80000()
        {
            Assert.Equal(0x00080000, (int) ControllerCategories.Cat20);
        }

        /// <summary>
        ///     Tests that cat twenty one equals hex one zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat21_EqualsHex100000()
        {
            Assert.Equal(0x00100000, (int) ControllerCategories.Cat21);
        }

        /// <summary>
        ///     Tests that cat twenty two equals hex two zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat22_EqualsHex200000()
        {
            Assert.Equal(0x00200000, (int) ControllerCategories.Cat22);
        }

        /// <summary>
        ///     Tests that cat twenty three equals hex four zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat23_EqualsHex400000()
        {
            Assert.Equal(0x00400000, (int) ControllerCategories.Cat23);
        }

        /// <summary>
        ///     Tests that cat twenty four equals hex eight zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat24_EqualsHex800000()
        {
            Assert.Equal(0x00800000, (int) ControllerCategories.Cat24);
        }

        /// <summary>
        ///     Tests that cat twenty five equals hex one zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat25_EqualsHex1000000()
        {
            Assert.Equal(0x01000000, (int) ControllerCategories.Cat25);
        }

        /// <summary>
        ///     Tests that cat twenty six equals hex two zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat26_EqualsHex2000000()
        {
            Assert.Equal(0x02000000, (int) ControllerCategories.Cat26);
        }

        /// <summary>
        ///     Tests that cat twenty seven equals hex four zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat27_EqualsHex4000000()
        {
            Assert.Equal(0x04000000, (int) ControllerCategories.Cat27);
        }

        /// <summary>
        ///     Tests that cat twenty eight equals hex eight zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat28_EqualsHex8000000()
        {
            Assert.Equal(0x08000000, (int) ControllerCategories.Cat28);
        }

        /// <summary>
        ///     Tests that cat twenty nine equals hex one zero zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat29_EqualsHex10000000()
        {
            Assert.Equal(0x10000000, (int) ControllerCategories.Cat29);
        }

        /// <summary>
        ///     Tests that cat thirty equals hex two zero zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat30_EqualsHex20000000()
        {
            Assert.Equal(0x20000000, (int) ControllerCategories.Cat30);
        }

        /// <summary>
        ///     Tests that cat thirty one equals hex four zero zero zero zero zero zero zero
        /// </summary>
        [Fact]
        public void Cat31_EqualsHex40000000()
        {
            Assert.Equal(0x40000000, (int) ControllerCategories.Cat31);
        }

        /// <summary>
        ///     Tests that all equals int max value
        /// </summary>
        [Fact]
        public void All_EqualsIntMaxValue()
        {
            Assert.Equal(0x7FFFFFFF, (int) ControllerCategories.All);
            Assert.Equal(int.MaxValue, (int) ControllerCategories.All);
        }

        /// <summary>
        ///     Tests that all contains every cat flag
        /// </summary>
        [Fact]
        public void All_ContainsEveryCatFlag()
        {
            Assert.True((ControllerCategories.All & ControllerCategories.Cat01) == ControllerCategories.Cat01);
            Assert.True((ControllerCategories.All & ControllerCategories.Cat15) == ControllerCategories.Cat15);
            Assert.True((ControllerCategories.All & ControllerCategories.Cat31) == ControllerCategories.Cat31);
        }

        /// <summary>
        ///     Tests that cat flags are distinct powers of two
        /// </summary>
        [Fact]
        public void CatFlags_AreDistinctPowersOfTwo()
        {
            ControllerCategories combined = ControllerCategories.Cat01 | ControllerCategories.Cat05 | ControllerCategories.Cat31;
            Assert.Equal(0x40000011, (int) combined);
            Assert.True((combined & ControllerCategories.Cat02) == 0);
        }

        /// <summary>
        ///     Tests that none and cat zero one combined equals cat zero one
        /// </summary>
        [Fact]
        public void None_OrCat01_EqualsCat01()
        {
            ControllerCategories combined = ControllerCategories.None | ControllerCategories.Cat01;
            Assert.Equal(ControllerCategories.Cat01, combined);
        }
    }
}

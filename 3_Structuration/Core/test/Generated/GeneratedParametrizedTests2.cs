// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneratedParametrizedTests2.cs
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

using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Test.Generated
{
    /// <summary>
    ///     Parametrized generated test class 2.
    ///     Contains 100 individual test cases.
    /// </summary>
    public class GeneratedParametrizedTests2
    {
        /// <summary>
        ///     Generates the test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateTestCases()
        {
            yield return new object[] {0, 0};
            yield return new object[] {1, 2};
            yield return new object[] {2, 4};
            yield return new object[] {3, 6};
            yield return new object[] {4, 8};
            yield return new object[] {5, 10};
            yield return new object[] {6, 12};
            yield return new object[] {7, 14};
            yield return new object[] {8, 16};
            yield return new object[] {9, 18};
            yield return new object[] {10, 20};
            yield return new object[] {11, 22};
            yield return new object[] {12, 24};
            yield return new object[] {13, 26};
            yield return new object[] {14, 28};
            yield return new object[] {15, 30};
            yield return new object[] {16, 32};
            yield return new object[] {17, 34};
            yield return new object[] {18, 36};
            yield return new object[] {19, 38};
            yield return new object[] {20, 40};
            yield return new object[] {21, 42};
            yield return new object[] {22, 44};
            yield return new object[] {23, 46};
            yield return new object[] {24, 48};
            yield return new object[] {25, 50};
            yield return new object[] {26, 52};
            yield return new object[] {27, 54};
            yield return new object[] {28, 56};
            yield return new object[] {29, 58};
            yield return new object[] {30, 60};
            yield return new object[] {31, 62};
            yield return new object[] {32, 64};
            yield return new object[] {33, 66};
            yield return new object[] {34, 68};
            yield return new object[] {35, 70};
            yield return new object[] {36, 72};
            yield return new object[] {37, 74};
            yield return new object[] {38, 76};
            yield return new object[] {39, 78};
            yield return new object[] {40, 80};
            yield return new object[] {41, 82};
            yield return new object[] {42, 84};
            yield return new object[] {43, 86};
            yield return new object[] {44, 88};
            yield return new object[] {45, 90};
            yield return new object[] {46, 92};
            yield return new object[] {47, 94};
            yield return new object[] {48, 96};
            yield return new object[] {49, 98};
            yield return new object[] {50, 100};
            yield return new object[] {51, 102};
            yield return new object[] {52, 104};
            yield return new object[] {53, 106};
            yield return new object[] {54, 108};
            yield return new object[] {55, 110};
            yield return new object[] {56, 112};
            yield return new object[] {57, 114};
            yield return new object[] {58, 116};
            yield return new object[] {59, 118};
            yield return new object[] {60, 120};
            yield return new object[] {61, 122};
            yield return new object[] {62, 124};
            yield return new object[] {63, 126};
            yield return new object[] {64, 128};
            yield return new object[] {65, 130};
            yield return new object[] {66, 132};
            yield return new object[] {67, 134};
            yield return new object[] {68, 136};
            yield return new object[] {69, 138};
            yield return new object[] {70, 140};
            yield return new object[] {71, 142};
            yield return new object[] {72, 144};
            yield return new object[] {73, 146};
            yield return new object[] {74, 148};
            yield return new object[] {75, 150};
            yield return new object[] {76, 152};
            yield return new object[] {77, 154};
            yield return new object[] {78, 156};
            yield return new object[] {79, 158};
            yield return new object[] {80, 160};
            yield return new object[] {81, 162};
            yield return new object[] {82, 164};
            yield return new object[] {83, 166};
            yield return new object[] {84, 168};
            yield return new object[] {85, 170};
            yield return new object[] {86, 172};
            yield return new object[] {87, 174};
            yield return new object[] {88, 176};
            yield return new object[] {89, 178};
            yield return new object[] {90, 180};
            yield return new object[] {91, 182};
            yield return new object[] {92, 184};
            yield return new object[] {93, 186};
            yield return new object[] {94, 188};
            yield return new object[] {95, 190};
            yield return new object[] {96, 192};
            yield return new object[] {97, 194};
            yield return new object[] {98, 196};
            yield return new object[] {99, 198};
        }

        /// <summary>
        ///     Tests that parametrized test 2
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="expected">The expected</param>
        [Theory, MemberData(nameof(GenerateTestCases))]
        public void ParametrizedTest_2(int value, int expected)
        {
            Assert.NotNull(value);
            Assert.NotNull(expected);
        }
    }
}
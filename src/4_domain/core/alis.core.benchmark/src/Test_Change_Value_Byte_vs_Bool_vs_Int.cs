// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Test_Change_Value_Byte_vs_Bool_vs_Int.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using BenchmarkDotNet.Attributes;

#endregion

namespace Alis.Core.Benchmark
{
    /// <summary>
    ///     The test change value byte vs bool vs int class
    /// </summary>
    public class Test_Change_Value_Byte_vs_Bool_vs_Int
    {
        /// <summary>
        ///     The truevalue
        /// </summary>
        private const byte truevalue = 1;

        /// <summary>
        ///     The false value
        /// </summary>
        private const byte falseValue = 0;

        /// <summary>
        ///     The is active
        /// </summary>
        public bool isActive;

        /// <summary>
        ///     The is int
        /// </summary>
        private int isInt;

        /// <summary>
        ///     The is static
        /// </summary>
        public byte isStatic;

        /// <summary>
        ///     The repetition
        /// </summary>
        [Params(1000)] public int repetition;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            isStatic = 0;
            isActive = false;
        }

        /// <summary>
        ///     Tests the change value byte
        /// </summary>
        [Benchmark]
        public void Test_Change_Value_Byte()
        {
            isStatic = (isStatic & truevalue) == truevalue ? falseValue : truevalue;
        }

        /// <summary>
        ///     Tests the change value bool
        /// </summary>
        [Benchmark]
        public void Test_Change_Value_Bool()
        {
            isActive = !isActive;
        }

        /// <summary>
        ///     Tests the change value int
        /// </summary>
        [Benchmark]
        public void Test_Change_Value_Int()
        {
            isInt = isInt == 0 ? 1 : 0;
        }
    }
}
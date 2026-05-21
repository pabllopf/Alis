// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RuntimeHelpersTest.cs
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


namespace Alis.Core.Ecs.Test.Redifinition
{
    /// <summary>
    ///     The runtime helpers test class
    /// </summary>
    /// <remarks>
    ///     Tests the RuntimeHelpers utility class that provides runtime type information
    ///     methods, particularly for detecting whether types contain references.
    ///     This is critical for ECS performance optimization.
    /// </remarks>
    public class RuntimeHelpersTest
    {
        /// <summary>
        ///     The test class
        /// </summary>
        private class TestClass
        {
            /// <summary>
            ///     Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }
        }

        /// <summary>
        ///     The pure value struct
        /// </summary>
        private struct PureValueStruct
        {
            /// <summary>
            ///     The
            /// </summary>
            public int X;

            /// <summary>
            ///     The
            /// </summary>
            public int Y;

            /// <summary>
            ///     The
            /// </summary>
            public float Z;
        }

        /// <summary>
        ///     The struct with reference
        /// </summary>
        private struct StructWithReference
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;

            /// <summary>
            ///     The name
            /// </summary>
            public string Name;
        }

        /// <summary>
        ///     The nested struct with reference
        /// </summary>
        private struct NestedStructWithReference
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;

            /// <summary>
            ///     The inner
            /// </summary>
            public StructWithReference Inner;
        }

        /// <summary>
        ///     The struct with array
        /// </summary>
        private struct StructWithArray
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;

            /// <summary>
            ///     The numbers
            /// </summary>
            public int[] Numbers;
        }

        /// <summary>
        ///     The complex pure value struct
        /// </summary>
        private struct ComplexPureValueStruct
        {
            /// <summary>
            ///     The
            /// </summary>
            public int A;

            /// <summary>
            ///     The
            /// </summary>
            public PureValueStruct B;

            /// <summary>
            ///     The
            /// </summary>
            public float C;
        }

        /// <summary>
        ///     The complex mixed struct
        /// </summary>
        private struct ComplexMixedStruct
        {
            /// <summary>
            ///     The
            /// </summary>
            public int A;

            /// <summary>
            ///     The
            /// </summary>
            public PureValueStruct B;

            /// <summary>
            ///     The
            /// </summary>
            public StructWithReference C;
        }

        /// <summary>
        ///     The test enum enum
        /// </summary>
        private enum TestEnum
        {
            /// <summary>
            ///     The value test enum
            /// </summary>
            Value1,

            /// <summary>
            ///     The value test enum
            /// </summary>
            Value2,

            /// <summary>
            ///     The value test enum
            /// </summary>
            Value3
        }
    }
}
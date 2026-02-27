// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IAction8Test.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IAction interface with eight parameters.
    ///     Tests the Run method with eight parameter handling.
    /// </summary>
    public class IAction8Test
    {
        /// <summary>
        ///     Helper implementation for testing eight parameter action.
        /// </summary>
        private class EightParamAction : IAction<int, int, int, int, int, int, int, int>
        {
            public int[] Values { get; } = new int[8];

            public void Run(ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7, ref int arg8)
            {
                Values[0] = arg1;
                Values[1] = arg2;
                Values[2] = arg3;
                Values[3] = arg4;
                Values[4] = arg5;
                Values[5] = arg6;
                Values[6] = arg7;
                Values[7] = arg8;
            }
        }

        /// <summary>
        ///     Tests that IAction with eight parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction8_CanBeImplementedWithEightParameters()
        {
            EightParamAction action = new EightParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, int, int, int, int, int, int, int>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            EightParamAction action = new EightParamAction();
            int v1 = 1, v2 = 2, v3 = 3, v4 = 4, v5 = 5, v6 = 6, v7 = 7, v8 = 8;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8);
            for (int i = 0; i < 8; i++)
            {
                Assert.Equal(i + 1, action.Values[i]);
            }
        }

        /// <summary>
        ///     Tests Run method with maximum parameter count.
        /// </summary>
        [Fact]
        public void Run_WithMaxParameterCount()
        {
            EightParamAction action = new EightParamAction();
            int v1 = 100, v2 = 100, v3 = 100, v4 = 100, v5 = 100, v6 = 100, v7 = 100, v8 = 100;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7, ref v8);
            Assert.All(action.Values, val => Assert.Equal(100, val));
        }
    }
}


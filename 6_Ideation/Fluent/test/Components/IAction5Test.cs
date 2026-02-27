// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IAction5Test.cs
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
    ///     Unit tests for the IAction interface with five parameters.
    ///     Tests the Run method with five parameter handling.
    /// </summary>
    public class IAction5Test
    {
        /// <summary>
        ///     Helper implementation for testing five parameter action.
        /// </summary>
        private class FiveParamAction : IAction<int, int, int, int, int>
        {
            public int[] Values { get; } = new int[5];

            public void Run(ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5)
            {
                Values[0] = arg1;
                Values[1] = arg2;
                Values[2] = arg3;
                Values[3] = arg4;
                Values[4] = arg5;
            }
        }

        /// <summary>
        ///     Tests that IAction with five parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction5_CanBeImplementedWithFiveParameters()
        {
            FiveParamAction action = new FiveParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, int, int, int, int>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            FiveParamAction action = new FiveParamAction();
            int v1 = 10, v2 = 20, v3 = 30, v4 = 40, v5 = 50;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5);
            Assert.Equal(10, action.Values[0]);
            Assert.Equal(20, action.Values[1]);
            Assert.Equal(30, action.Values[2]);
            Assert.Equal(40, action.Values[3]);
            Assert.Equal(50, action.Values[4]);
        }

        /// <summary>
        ///     Tests Run method with all values equal.
        /// </summary>
        [Fact]
        public void Run_WithAllValuesEqual()
        {
            FiveParamAction action = new FiveParamAction();
            int value = 42;
            int v1 = value, v2 = value, v3 = value, v4 = value, v5 = value;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5);
            Assert.All(action.Values, val => Assert.Equal(42, val));
        }
    }
}


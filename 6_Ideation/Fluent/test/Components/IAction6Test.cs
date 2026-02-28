// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAction6Test.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IAction interface with six parameters.
    ///     Tests the Run method with six parameter handling.
    /// </summary>
    public class IAction6Test
    {
        /// <summary>
        ///     Tests that IAction with six parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction6_CanBeImplementedWithSixParameters()
        {
            SixParamAction action = new SixParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, int, int, int, int, int>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            SixParamAction action = new SixParamAction();
            int v1 = 10, v2 = 20, v3 = 30, v4 = 40, v5 = 50, v6 = 60;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6);
            for (int i = 0; i < 6; i++)
            {
                Assert.Equal((i + 1) * 10, action.Values[i]);
            }
        }

        /// <summary>
        ///     Tests Run method with zero values.
        /// </summary>
        [Fact]
        public void Run_WithZeroValues()
        {
            SixParamAction action = new SixParamAction();
            int v1 = 0, v2 = 0, v3 = 0, v4 = 0, v5 = 0, v6 = 0;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6);
            Assert.All(action.Values, val => Assert.Equal(0, val));
        }

        /// <summary>
        ///     Helper implementation for testing six parameter action.
        /// </summary>
        private class SixParamAction : IAction<int, int, int, int, int, int>
        {
            public int[] Values { get; } = new int[6];

            public void Run(ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6)
            {
                Values[0] = arg1;
                Values[1] = arg2;
                Values[2] = arg3;
                Values[3] = arg4;
                Values[4] = arg5;
                Values[5] = arg6;
            }
        }
    }
}
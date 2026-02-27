// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IAction4Test.cs
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
    ///     Unit tests for the IAction interface with four parameters.
    ///     Tests the Run method with four parameter handling.
    /// </summary>
    public class IAction4Test
    {
        /// <summary>
        ///     Helper implementation for testing four parameter action.
        /// </summary>
        private class FourParamAction : IAction<int, int, int, int>
        {
            public int Arg1 { get; private set; }
            public int Arg2 { get; private set; }
            public int Arg3 { get; private set; }
            public int Arg4 { get; private set; }

            public void Run(ref int arg1, ref int arg2, ref int arg3, ref int arg4)
            {
                Arg1 = arg1;
                Arg2 = arg2;
                Arg3 = arg3;
                Arg4 = arg4;
            }
        }

        /// <summary>
        ///     Tests that IAction with four parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction4_CanBeImplementedWithFourParameters()
        {
            var action = new FourParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, int, int, int>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            var action = new FourParamAction();
            int val1 = 10;
            int val2 = 20;
            int val3 = 30;
            int val4 = 40;
            action.Run(ref val1, ref val2, ref val3, ref val4);
            Assert.Equal(10, action.Arg1);
            Assert.Equal(20, action.Arg2);
            Assert.Equal(30, action.Arg3);
            Assert.Equal(40, action.Arg4);
        }

        /// <summary>
        ///     Tests Run method parameter order preservation.
        /// </summary>
        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(100, 200, 300, 400)]
        [InlineData(-1, -2, -3, -4)]
        public void Run_PreservesParameterOrder(int v1, int v2, int v3, int v4)
        {
            var action = new FourParamAction();
            int arg1 = v1, arg2 = v2, arg3 = v3, arg4 = v4;
            action.Run(ref arg1, ref arg2, ref arg3, ref arg4);
            Assert.Equal(v1, action.Arg1);
            Assert.Equal(v2, action.Arg2);
            Assert.Equal(v3, action.Arg3);
            Assert.Equal(v4, action.Arg4);
        }
    }
}


// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IAction2Test.cs
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
    ///     Unit tests for the IAction interface with two parameters.
    ///     Tests the Run method with multiple parameter handling.
    /// </summary>
    public class IAction2Test
    {
        /// <summary>
        ///     Helper implementation for testing two parameter action.
        /// </summary>
        private class TwoParamAction : IAction<int, string>
        {
            public int LastIntValue { get; private set; }
            public string LastStringValue { get; private set; }

            public void Run(ref int arg1, ref string arg2)
            {
                LastIntValue = arg1;
                LastStringValue = arg2;
            }
        }

        /// <summary>
        ///     Tests that IAction with two parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction2_CanBeImplementedWithTwoParameters()
        {
            var action = new TwoParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, string>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            var action = new TwoParamAction();
            int intVal = 42;
            string strVal = "test";
            action.Run(ref intVal, ref strVal);
            Assert.Equal(42, action.LastIntValue);
            Assert.Equal("test", action.LastStringValue);
        }

        /// <summary>
        ///     Tests Run method parameter independence.
        /// </summary>
        [Fact]
        public void Run_HandlesParametersIndependently()
        {
            var action = new TwoParamAction();
            int intVal = 100;
            string strVal = "value";
            action.Run(ref intVal, ref strVal);
            Assert.Equal(100, action.LastIntValue);
            Assert.Equal("value", action.LastStringValue);
        }

        /// <summary>
        ///     Tests IAction with homogeneous parameter types.
        /// </summary>
        [Fact]
        public void IAction2_WithSameParameterTypes()
        {
            var action = new SameTypeAction();
            int val1 = 10;
            int val2 = 20;
            action.Run(ref val1, ref val2);
            Assert.Equal(10, action.FirstValue);
            Assert.Equal(20, action.SecondValue);
        }

        /// <summary>
        ///     Helper implementation with same parameter types.
        /// </summary>
        private class SameTypeAction : IAction<int, int>
        {
            public int FirstValue { get; private set; }
            public int SecondValue { get; private set; }

            public void Run(ref int arg1, ref int arg2)
            {
                FirstValue = arg1;
                SecondValue = arg2;
            }
        }
    }
}


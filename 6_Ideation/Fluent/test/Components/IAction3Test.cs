// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAction3Test.cs
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
    ///     Unit tests for the IAction interface with three parameters.
    ///     Tests the Run method with three parameter handling.
    /// </summary>
    public class IAction3Test
    {
        /// <summary>
        ///     Tests that IAction with three parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction3_CanBeImplementedWithThreeParameters()
        {
            ThreeParamAction action = new ThreeParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, string, double>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            ThreeParamAction action = new ThreeParamAction();
            int intVal = 42;
            string strVal = "test";
            double dblVal = 3.14;
            action.Run(ref intVal, ref strVal, ref dblVal);
            Assert.Equal(42, action.IntValue);
            Assert.Equal("test", action.StringValue);
            Assert.Equal(3.14, action.DoubleValue);
        }

        /// <summary>
        ///     Tests Run method with extreme values.
        /// </summary>
        [Fact]
        public void Run_HandlesExtremeValues()
        {
            ThreeParamAction action = new ThreeParamAction();
            int intVal = int.MaxValue;
            string strVal = string.Empty;
            double dblVal = double.MinValue;
            action.Run(ref intVal, ref strVal, ref dblVal);
            Assert.Equal(int.MaxValue, action.IntValue);
            Assert.Equal(string.Empty, action.StringValue);
            Assert.Equal(double.MinValue, action.DoubleValue);
        }

        /// <summary>
        ///     Helper implementation for testing three parameter action.
        /// </summary>
        private class ThreeParamAction : IAction<int, string, double>
        {
            public int IntValue { get; private set; }
            public string StringValue { get; private set; }
            public double DoubleValue { get; private set; }

            public void Run(ref int arg1, ref string arg2, ref double arg3)
            {
                IntValue = arg1;
                StringValue = arg2;
                DoubleValue = arg3;
            }
        }
    }
}
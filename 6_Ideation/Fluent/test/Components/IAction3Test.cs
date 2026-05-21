

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
            /// <summary>
            ///     Gets or sets the value of the int value
            /// </summary>
            public int IntValue { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the string value
            /// </summary>
            public string StringValue { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the double value
            /// </summary>
            public double DoubleValue { get; private set; }

            /// <summary>
            ///     Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            public void Run(ref int arg1, ref string arg2, ref double arg3)
            {
                IntValue = arg1;
                StringValue = arg2;
                DoubleValue = arg3;
            }
        }
    }
}


using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IAction interface with single parameter.
    ///     Tests the Run method signature and correct invocation.
    /// </summary>
    public class IActionTest
    {
        /// <summary>
        ///     Tests that IAction can be implemented with a single parameter.
        /// </summary>
        [Fact]
        public void IAction_CanBeImplementedWithSingleParameter()
        {
            SingleParamAction action = new SingleParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameter.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameter()
        {
            SingleParamAction action = new SingleParamAction();
            int value = 42;
            action.Run(ref value);
            Assert.Equal(42, action.LastValue);
        }

        /// <summary>
        ///     Tests Run method with different parameter values.
        /// </summary>
        [Theory, InlineData(0), InlineData(1), InlineData(-1), InlineData(int.MaxValue), InlineData(int.MinValue)]
        public void Run_WorksWithVariousParameterValues(int paramValue)
        {
            SingleParamAction action = new SingleParamAction();
            action.Run(ref paramValue);
            Assert.Equal(paramValue, action.LastValue);
        }

        /// <summary>
        ///     Tests IAction with string parameter type.
        /// </summary>
        [Fact]
        public void IAction_WithStringParameterType()
        {
            StringParamAction action = new StringParamAction();
            string value = "test";
            action.Run(ref value);
            Assert.Equal("test", action.LastValue);
        }

        /// <summary>
        ///     Helper implementation for testing single parameter action.
        /// </summary>
        private class SingleParamAction : IAction<int>
        {
            /// <summary>
            ///     Gets or sets the value of the last value
            /// </summary>
            public int LastValue { get; private set; }

            /// <summary>
            ///     Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            public void Run(ref int arg1)
            {
                LastValue = arg1;
            }
        }

        /// <summary>
        ///     Helper implementation for string parameter.
        /// </summary>
        private class StringParamAction : IAction<string>
        {
            /// <summary>
            ///     Gets or sets the value of the last value
            /// </summary>
            public string LastValue { get; private set; }

            /// <summary>
            ///     Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            public void Run(ref string arg1)
            {
                LastValue = arg1;
            }
        }
    }
}


using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IAction interface with seven parameters.
    ///     Tests the Run method with seven parameter handling.
    /// </summary>
    public class IAction7Test
    {
        /// <summary>
        ///     Tests that IAction with seven parameters can be implemented.
        /// </summary>
        [Fact]
        public void IAction7_CanBeImplementedWithSevenParameters()
        {
            SevenParamAction action = new SevenParamAction();
            Assert.NotNull(action);
            Assert.IsAssignableFrom<IAction<int, int, int, int, int, int, int>>(action);
        }

        /// <summary>
        ///     Tests that Run method executes with correct parameters.
        /// </summary>
        [Fact]
        public void Run_ExecutesWithCorrectParameters()
        {
            SevenParamAction action = new SevenParamAction();
            int v1 = 1, v2 = 2, v3 = 3, v4 = 4, v5 = 5, v6 = 6, v7 = 7;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7);
            for (int i = 0; i < 7; i++)
            {
                Assert.Equal(i + 1, action.Values[i]);
            }
        }

        /// <summary>
        ///     Tests Run method with negative values.
        /// </summary>
        [Fact]
        public void Run_WithNegativeValues()
        {
            SevenParamAction action = new SevenParamAction();
            int v1 = -1, v2 = -2, v3 = -3, v4 = -4, v5 = -5, v6 = -6, v7 = -7;
            action.Run(ref v1, ref v2, ref v3, ref v4, ref v5, ref v6, ref v7);
            for (int i = 0; i < 7; i++)
            {
                Assert.Equal(-(i + 1), action.Values[i]);
            }
        }

        /// <summary>
        ///     Helper implementation for testing seven parameter action.
        /// </summary>
        private class SevenParamAction : IAction<int, int, int, int, int, int, int>
        {
            /// <summary>
            ///     Gets the value of the values
            /// </summary>
            public int[] Values { get; } = new int[7];

            /// <summary>
            ///     Runs the arg 1
            /// </summary>
            /// <param name="arg1">The arg</param>
            /// <param name="arg2">The arg</param>
            /// <param name="arg3">The arg</param>
            /// <param name="arg4">The arg</param>
            /// <param name="arg5">The arg</param>
            /// <param name="arg6">The arg</param>
            /// <param name="arg7">The arg</param>
            public void Run(ref int arg1, ref int arg2, ref int arg3, ref int arg4, ref int arg5, ref int arg6, ref int arg7)
            {
                Values[0] = arg1;
                Values[1] = arg2;
                Values[2] = arg3;
                Values[3] = arg4;
                Values[4] = arg5;
                Values[5] = arg6;
                Values[6] = arg7;
            }
        }
    }
}
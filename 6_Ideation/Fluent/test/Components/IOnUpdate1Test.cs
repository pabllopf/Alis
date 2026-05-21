

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnUpdate generic interface with one parameter.
    ///     Tests the Update method with self and one component argument.
    /// </summary>
    public class IOnUpdate1Test
    {
        /// <summary>
        ///     Tests that IOnUpdate can be implemented with one parameter.
        /// </summary>
        [Fact]
        public void IOnUpdate1_CanBeImplemented()
        {
            Update1Handler handler = new Update1Handler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnUpdate<int>>(handler);
        }

        /// <summary>
        ///     Tests that Update method executes with correct parameter.
        /// </summary>
        [Fact]
        public void Update_ExecutesWithCorrectParameter()
        {
            Update1Handler handler = new Update1Handler();
            MockGameObject gameObject = new MockGameObject();
            int value = 42;
            handler.Update(gameObject, ref value);
            Assert.Equal(42, handler.LastValue);
        }

        /// <summary>
        ///     Tests that Update counts invocations correctly.
        /// </summary>
        [Fact]
        public void Update_CountsInvocations()
        {
            Update1Handler handler = new Update1Handler();
            MockGameObject gameObject = new MockGameObject();
            int value = 10;
            handler.Update(gameObject, ref value);
            handler.Update(gameObject, ref value);
            Assert.Equal(2, handler.CallCount);
        }

        /// <summary>
        ///     Tests IOnUpdate with string parameter type.
        /// </summary>
        [Fact]
        public void IOnUpdate1_WithStringParameterType()
        {
            UpdateStringHandler handler = new UpdateStringHandler();
            MockGameObject gameObject = new MockGameObject();
            string value = "test";
            handler.Update(gameObject, ref value);
            Assert.Equal("test", handler.LastValue);
        }


        /// <summary>
        ///     Helper implementation for testing IOnUpdate with one parameter.
        /// </summary>
        private class Update1Handler : IOnUpdate<int>
        {
            /// <summary>
            ///     Gets the value of the is component base
            /// </summary>
            public bool IsComponentBase => true;

            /// <summary>
            ///     Gets or sets the value of the last value
            /// </summary>
            public int LastValue { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg">The arg</param>
            public void Update(IGameObject self, ref int arg)
            {
                LastValue = arg;
                CallCount++;
            }
        }

        /// <summary>
        ///     Helper implementation with string parameter.
        /// </summary>
        private class UpdateStringHandler : IOnUpdate<string>
        {
            /// <summary>
            ///     Gets or sets the value of the last value
            /// </summary>
            public string LastValue { get; private set; }

            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg">The arg</param>
            public void Update(IGameObject self, ref string arg)
            {
                LastValue = arg;
            }
        }
    }
}
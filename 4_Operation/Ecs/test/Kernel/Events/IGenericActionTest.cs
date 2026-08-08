using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    /// The generic action test class
    /// </summary>
    public class IGenericActionTest
    {
        /// <summary>
        /// Tests that invoke with ref type executes action
        /// </summary>
        [Fact] public void Invoke_WithRefType_ExecutesAction()
        {
            TestGenericAction action = new TestGenericAction();
            int value = 42;
            action.Invoke(ref value);
            Assert.Equal(84, value);
        }

        /// <summary>
        /// Tests that invoke with string ref executes action
        /// </summary>
        [Fact] public void Invoke_WithStringRef_ExecutesAction()
        {
            StringGenericAction action = new StringGenericAction();
            string value = "hello";
            action.Invoke(ref value);
            Assert.Equal("hello!", value);
        }

        /// <summary>
        /// Tests that invoke with t param executes action
        /// </summary>
        [Fact] public void Invoke_WithTParam_ExecutesAction()
        {
            TypedGenericAction action = new TypedGenericAction();
            int result = 0;
            action.Invoke(42, ref result);
            Assert.Equal(42, result);
        }

        /// <summary>
        /// The test generic action class
        /// </summary>
        /// <seealso cref="IGenericAction"/>
        internal sealed class TestGenericAction : IGenericAction
        {
            /// <summary>
            /// Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                if (type is int i)
                    type = (T)(object)(i * 2);
            }
        }

        /// <summary>
        /// The string generic action class
        /// </summary>
        /// <seealso cref="IGenericAction"/>
        internal sealed class StringGenericAction : IGenericAction
        {
            /// <summary>
            /// Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                if (type is string s)
                    type = (T)(object)(s + "!");
            }
        }

        /// <summary>
        /// The typed generic action class
        /// </summary>
        /// <seealso cref="IGenericAction{int}"/>
        internal sealed class TypedGenericAction : IGenericAction<int>
        {
            /// <summary>
            /// Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(int param, ref T type)
            {
                if (type is int i)
                    type = (T)(object)(i + param);
            }
        }
    }
}

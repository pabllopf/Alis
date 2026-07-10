using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    public class IGenericActionTest
    {
        [Fact]
        public void Invoke_WithRefType_ExecutesAction()
        {
            var action = new TestGenericAction();
            int value = 42;
            action.Invoke(ref value);
            Assert.Equal(84, value);
        }

        [Fact]
        public void Invoke_WithStringRef_ExecutesAction()
        {
            var action = new StringGenericAction();
            string value = "hello";
            action.Invoke(ref value);
            Assert.Equal("hello!", value);
        }

        [Fact]
        public void Invoke_WithTParam_ExecutesAction()
        {
            var action = new TypedGenericAction();
            int result = 0;
            action.Invoke(42, ref result);
            Assert.Equal(42, result);
        }

        private sealed class TestGenericAction : IGenericAction
        {
            public void Invoke<T>(ref T type)
            {
                if (type is int i)
                    type = (T)(object)(i * 2);
            }
        }

        private sealed class StringGenericAction : IGenericAction
        {
            public void Invoke<T>(ref T type)
            {
                if (type is string s)
                    type = (T)(object)(s + "!");
            }
        }

        private sealed class TypedGenericAction : IGenericAction<int>
        {
            public void Invoke<T>(int param, ref T type)
            {
                if (type is int i)
                    type = (T)(object)(i + param);
            }
        }
    }
}

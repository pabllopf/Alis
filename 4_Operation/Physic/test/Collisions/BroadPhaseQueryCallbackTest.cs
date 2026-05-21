

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The broad phase query callback test class
    /// </summary>
    public class BroadPhaseQueryCallbackTest
    {
        /// <summary>
        ///     Tests that broad phase query callback should be invokable
        /// </summary>
        [Fact]
        public void BroadPhaseQueryCallback_ShouldBeInvokable()
        {
            bool invoked = false;
            BroadPhaseQueryCallback callback = proxyId =>
            {
                invoked = true;
                return true;
            };

            bool result = callback(0);

            Assert.True(invoked);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that callback should receive proxy id parameter
        /// </summary>
        [Fact]
        public void Callback_ShouldReceiveProxyIdParameter()
        {
            int capturedProxyId = -1;
            BroadPhaseQueryCallback callback = proxyId =>
            {
                capturedProxyId = proxyId;
                return true;
            };

            callback(42);

            Assert.Equal(42, capturedProxyId);
        }

        /// <summary>
        ///     Tests that callback should return true to continue query
        /// </summary>
        [Fact]
        public void Callback_ShouldReturnTrue_ToContinueQuery()
        {
            BroadPhaseQueryCallback callback = proxyId => true;

            bool result = callback(0);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that callback should return false to stop query
        /// </summary>
        [Fact]
        public void Callback_ShouldReturnFalse_ToStopQuery()
        {
            BroadPhaseQueryCallback callback = proxyId => false;

            bool result = callback(0);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that callback should be chainable
        /// </summary>
        [Fact]
        public void Callback_ShouldBeChainable()
        {
            int callCount = 0;
            BroadPhaseQueryCallback callback1 = id =>
            {
                callCount++;
                return true;
            };
            BroadPhaseQueryCallback callback2 = id =>
            {
                callCount++;
                return true;
            };

            BroadPhaseQueryCallback combined = callback1 + callback2;

            combined(0);

            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that callback should be removable
        /// </summary>
        [Fact]
        public void Callback_ShouldBeRemovable()
        {
            int callCount = 0;
            BroadPhaseQueryCallback callback1 = id =>
            {
                callCount++;
                return true;
            };
            BroadPhaseQueryCallback callback2 = id =>
            {
                callCount++;
                return true;
            };

            BroadPhaseQueryCallback combined = callback1 + callback2;
            combined -= callback1;

            combined(0);

            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that callback should handle negative proxy ids
        /// </summary>
        [Fact]
        public void Callback_ShouldHandleNegativeProxyIds()
        {
            bool invoked = false;
            BroadPhaseQueryCallback callback = proxyId =>
            {
                invoked = true;
                return true;
            };

            callback(-1);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that callback should handle zero proxy id
        /// </summary>
        [Fact]
        public void Callback_ShouldHandleZeroProxyId()
        {
            bool invoked = false;
            BroadPhaseQueryCallback callback = proxyId =>
            {
                invoked = true;
                return proxyId == 0;
            };

            bool result = callback(0);

            Assert.True(invoked);
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that callback should support multiple invocations
        /// </summary>
        [Fact]
        public void Callback_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            BroadPhaseQueryCallback callback = id =>
            {
                count++;
                return true;
            };

            callback(0);
            callback(1);
            callback(2);

            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that callback should support conditional logic
        /// </summary>
        [Fact]
        public void Callback_ShouldSupportConditionalLogic()
        {
            BroadPhaseQueryCallback callback = proxyId => proxyId > 5;

            bool result1 = callback(3);
            bool result2 = callback(10);

            Assert.False(result1);
            Assert.True(result2);
        }

        /// <summary>
        ///     Tests that callback should handle large proxy ids
        /// </summary>
        [Fact]
        public void Callback_ShouldHandleLargeProxyIds()
        {
            int capturedId = -1;
            BroadPhaseQueryCallback callback = proxyId =>
            {
                capturedId = proxyId;
                return true;
            };

            callback(int.MaxValue);

            Assert.Equal(int.MaxValue, capturedId);
        }
    }
}
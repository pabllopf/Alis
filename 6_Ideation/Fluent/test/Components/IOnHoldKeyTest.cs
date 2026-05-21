

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnHoldKey interface.
    ///     Tests the OnHoldKey lifecycle method for key hold detection.
    /// </summary>
    public class IOnHoldKeyTest
    {
        /// <summary>
        ///     Tests that IOnHoldKey can be implemented.
        /// </summary>
        [Fact]
        public void IOnHoldKey_CanBeImplemented()
        {
            HoldKeyHandler handler = new HoldKeyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnHoldKey>(handler);
        }

        /// <summary>
        ///     Tests that OnHoldKey method can be called.
        /// </summary>
        [Fact]
        public void OnHoldKey_CanBeCalled()
        {
            HoldKeyHandler handler = new HoldKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.A, DateTime.UtcNow, TimeSpan.FromSeconds(1));
            handler.OnHoldKey(self, keyInfo);
            Assert.Equal(1, handler.HoldCount);
        }

        /// <summary>
        ///     Tests that OnHoldKey accumulates hold time.
        /// </summary>
        [Fact]
        public void OnHoldKey_AccumulatesHoldTime()
        {
            HoldKeyHandler handler = new HoldKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo1 = new KeyEventInfo(ConsoleKey.D, DateTime.UtcNow, TimeSpan.FromSeconds(2));
            KeyEventInfo keyInfo2 = new KeyEventInfo(ConsoleKey.D, DateTime.UtcNow, TimeSpan.FromSeconds(1));
            handler.OnHoldKey(self, keyInfo1);
            handler.OnHoldKey(self, keyInfo2);
            Assert.Equal(2, handler.HoldCount);
            Assert.Equal(TimeSpan.FromSeconds(3), handler.TotalHoldTime);
        }


        /// <summary>
        ///     Helper implementation for testing IOnHoldKey.
        /// </summary>
        private class HoldKeyHandler : IOnHoldKey
        {
            /// <summary>
            ///     Gets or sets the value of the hold count
            /// </summary>
            public int HoldCount { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the total hold time
            /// </summary>
            public TimeSpan TotalHoldTime { get; private set; }

            /// <summary>
            ///     Ons the hold key using the specified info
            /// </summary>
            /// <param name="info">The info</param>
            public void OnHoldKey(KeyEventInfo info)
            {
            }

            /// <summary>
            ///     Ons the hold key using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="keyInfo">The key info</param>
            public void OnHoldKey(IGameObject self, KeyEventInfo keyInfo)
            {
                HoldCount++;
                TotalHoldTime += keyInfo.HoldDuration;
            }
        }
    }
}
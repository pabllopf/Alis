

using System;
using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnReleaseKey interface.
    ///     Tests the OnReleaseKey lifecycle method for key release detection.
    /// </summary>
    public class IOnReleaseKeyTest
    {
        /// <summary>
        ///     Tests that IOnReleaseKey can be implemented.
        /// </summary>
        [Fact]
        public void IOnReleaseKey_CanBeImplemented()
        {
            ReleaseKeyHandler handler = new ReleaseKeyHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnReleaseKey>(handler);
        }

        /// <summary>
        ///     Tests that OnReleaseKey method can be called.
        /// </summary>
        [Fact]
        public void OnReleaseKey_CanBeCalled()
        {
            ReleaseKeyHandler handler = new ReleaseKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.Spacebar, DateTime.UtcNow, TimeSpan.FromMilliseconds(50));
            handler.OnReleaseKey(self, keyInfo);
            Assert.Equal(1, handler.ReleaseCount);
        }

        /// <summary>
        ///     Tests that OnReleaseKey counts releases.
        /// </summary>
        [Fact]
        public void OnReleaseKey_CountsReleases()
        {
            ReleaseKeyHandler handler = new ReleaseKeyHandler();
            MockGameObject self = new MockGameObject();
            KeyEventInfo keyInfo = new KeyEventInfo(ConsoleKey.W, DateTime.UtcNow, TimeSpan.FromMilliseconds(200));
            handler.OnReleaseKey(self, keyInfo);
            handler.OnReleaseKey(self, keyInfo);
            Assert.Equal(2, handler.ReleaseCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnReleaseKey.
        /// </summary>
        private class ReleaseKeyHandler : IOnReleaseKey
        {
            /// <summary>
            ///     Gets or sets the value of the release count
            /// </summary>
            public int ReleaseCount { get; private set; }

            /// <summary>
            ///     Ons the release key using the specified info
            /// </summary>
            /// <param name="info">The info</param>
            /// <exception cref="NotImplementedException"></exception>
            public void OnReleaseKey(KeyEventInfo info)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            ///     Ons the release key using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="keyInfo">The key info</param>
            public void OnReleaseKey(IGameObject self, KeyEventInfo keyInfo)
            {
                ReleaseCount++;
            }
        }
    }
}
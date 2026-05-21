

using System;
using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IUpdate interface.
    ///     Tests the Update method for modification operations.
    /// </summary>
    public class IUpdateTest
    {
        /// <summary>
        ///     Tests that IUpdate can be implemented.
        /// </summary>
        [Fact]
        public void IUpdate_CanBeImplemented()
        {
            UpdateHandler handler = new UpdateHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IUpdate<int, int>>(handler);
        }

        /// <summary>
        ///     Tests that Update method can be called.
        /// </summary>
        [Fact]
        public void Update_CanBeCalled()
        {
            UpdateHandler handler = new UpdateHandler();
            handler.Update();
            Assert.True(handler.WasUpdated);
        }

        /// <summary>
        ///     Tests that Update increments counter.
        /// </summary>
        [Fact]
        public void Update_IncrementsCounter()
        {
            UpdateHandler handler = new UpdateHandler();
            handler.Update();
            Assert.Equal(1, handler.UpdateCount);
            handler.Update();
            Assert.Equal(2, handler.UpdateCount);
        }

        /// <summary>
        ///     Tests Update called in sequence.
        /// </summary>
        [Fact]
        public void Update_WorksInSequence()
        {
            UpdateHandler handler = new UpdateHandler();
            for (int i = 0; i < 10; i++)
            {
                handler.Update();
            }

            Assert.Equal(10, handler.UpdateCount);
        }

        /// <summary>
        ///     Helper implementation of IUpdate.
        /// </summary>
        private class UpdateHandler : IUpdate<int, int>
        {
            /// <summary>
            ///     Gets or sets the value of the update count
            /// </summary>
            public int UpdateCount { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the was updated
            /// </summary>
            public bool WasUpdated { get; private set; }

            /// <summary>
            ///     Updates the obj
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The int</returns>
            public int Update(int obj) => throw new NotImplementedException();

            /// <summary>
            ///     Updates this instance
            /// </summary>
            public void Update()
            {
                WasUpdated = true;
                UpdateCount++;
            }
        }
    }
}


using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the IOnProcessPendingChanges interface.
    ///     Tests the OnProcessPendingChanges lifecycle method for entity changes.
    /// </summary>
    public class IOnProcessPendingChangesTest
    {
        /// <summary>
        ///     Tests that IOnProcessPendingChanges can be implemented.
        /// </summary>
        [Fact]
        public void IOnProcessPendingChanges_CanBeImplemented()
        {
            ProcessChangesHandler handler = new ProcessChangesHandler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnProcessPendingChanges>(handler);
        }

        /// <summary>
        ///     Tests that OnProcessPendingChanges method can be called.
        /// </summary>
        [Fact]
        public void OnProcessPendingChanges_CanBeCalled()
        {
            ProcessChangesHandler handler = new ProcessChangesHandler();
            MockGameObject gameObject = new MockGameObject();
            handler.OnProcessPendingChanges(gameObject);
            Assert.Equal(1, handler.ProcessCount);
        }

        /// <summary>
        ///     Tests that OnProcessPendingChanges counts processing cycles.
        /// </summary>
        [Fact]
        public void OnProcessPendingChanges_CountsProcessingCycles()
        {
            ProcessChangesHandler handler = new ProcessChangesHandler();
            MockGameObject gameObject = new MockGameObject();
            for (int i = 0; i < 10; i++)
            {
                handler.OnProcessPendingChanges(gameObject);
            }

            Assert.Equal(10, handler.ProcessCount);
        }


        /// <summary>
        ///     Helper implementation for testing IOnProcessPendingChanges.
        /// </summary>
        private class ProcessChangesHandler : IOnProcessPendingChanges
        {
            /// <summary>
            ///     Gets or sets the value of the process count
            /// </summary>
            public int ProcessCount { get; private set; }

            /// <summary>
            ///     Ons the process pending changes using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnProcessPendingChanges(IGameObject self)
            {
                ProcessCount++;
            }
        }
    }
}
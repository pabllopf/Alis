

using System.Threading;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The thread task test class
    /// </summary>
    public class ThreadTaskTest
    {
        /// <summary>
        ///     Tests that execute should execute action
        /// </summary>
        [Fact]
        public void Execute_ShouldExecuteAction()
        {
            bool actionExecuted = false;
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadTask threadTask = new ThreadTask(token => { actionExecuted = true; }, cts.Token);

            threadTask.Execute(cts.Token);

            System.Threading.Thread.Sleep(1000);

            cts.Cancel();

            Assert.True(actionExecuted);
        }
    }
}
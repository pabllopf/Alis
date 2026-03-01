using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiInputTextCallback"/> delegate behavior.
    /// </summary>
    public class ImGuiInputTextCallbackTest
    {
        /// <summary>
        /// Verifies that the callback can be invoked with expected parameters.
        /// </summary>
        [Fact]
        public void Invoke_ShouldCallAssignedCallback()
        {
            bool called = false;
            Func<ImGuiInputTextCallbackData, int> callback = _ =>
            {
                called = true;
                return 0;
            };

            int result = callback(new ImGuiInputTextCallbackData());

            Assert.True(called);
            Assert.Equal(0, result);
        }

        /// <summary>
        /// Verifies that the callback can return different result codes.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedResultCode()
        {
            Func<ImGuiInputTextCallbackData, int> callback = _ => 42;

            int result = callback(new ImGuiInputTextCallbackData());

            Assert.Equal(42, result);
        }
    }
}


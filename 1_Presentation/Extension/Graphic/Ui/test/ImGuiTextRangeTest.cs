

using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui text range test class
    /// </summary>
    public class ImGuiTextRangeTest
    {
        /// <summary>
        ///     Tests that b should set and get correctly
        /// </summary>
        [Fact]
        public void B_Should_SetAndGetCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(123);
            textRange.B = ptr;
            Assert.Equal(ptr, textRange.B);
        }

        /// <summary>
        ///     Tests that e should set and get correctly
        /// </summary>
        [Fact]
        public void E_Should_SetAndGetCorrectly()
        {
            ImGuiTextRange textRange = new ImGuiTextRange();
            IntPtr ptr = new IntPtr(456);
            textRange.E = ptr;
            Assert.Equal(ptr, textRange.E);
        }
    }
}
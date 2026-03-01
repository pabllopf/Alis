using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformSetWindowTitle"/> delegate behavior.
    /// </summary>
    public class PlatformSetWindowTitleTest
    {
        /// <summary>
        /// Verifies that the delegate receives the expected title pointer.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReceiveExpectedTitlePointer()
        {
            IntPtr expectedTitle = Marshal.StringToHGlobalAnsi("UI Test Window");
            IntPtr captured = IntPtr.Zero;
            PlatformSetWindowTitle callback = (_, title) => captured = title;

            try
            {
                callback(new ImGuiViewportPtr(IntPtr.Zero), expectedTitle);
                Assert.Equal(expectedTitle, captured);
            }
            finally
            {
                Marshal.FreeHGlobal(expectedTitle);
            }
        }
    }
}


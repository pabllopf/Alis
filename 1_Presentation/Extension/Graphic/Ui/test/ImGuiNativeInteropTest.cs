using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Tests for ImGui native wrappers when the native library is unavailable.
    /// </summary>
    public class ImGuiNativeInteropTest
    {
        /// <summary>
        ///     Verifies that MenuItem fails fast when the native library is missing.
        /// </summary>
        [Fact]
        public void MenuItem_RequiresNativeLibrary()
        {
            if (IsCimguiAvailable())
            {
                return;
            }

            bool selected = false;
            Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("Menu", string.Empty, ref selected, true));
        }

        /// <summary>
        ///     Verifies that End fails fast when the native library is missing.
        /// </summary>
        [Fact]
        public void End_RequiresNativeLibrary()
        {
            if (IsCimguiAvailable())
            {
                return;
            }

            Assert.Throws<DllNotFoundException>(() => ImGui.End());
        }

        private static bool IsCimguiAvailable()
        {
            if (NativeLibrary.TryLoad("cimgui", out IntPtr handle))
            {
                NativeLibrary.Free(handle);
                return true;
            }

            return false;
        }
    }
}

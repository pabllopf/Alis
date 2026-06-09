using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal winrt wm info test class
    /// </summary>
    public class InternalWinrtWmInfoTest
    {
        /// <summary>
        /// Tests that internal winrt wm info default initialization property has default value
        /// </summary>
        [Fact]
        public void InternalWinrtWmInfo_DefaultInitialization_PropertyHasDefaultValue()
        {
            InternalWinrtWmInfo info = new InternalWinrtWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
        }

        /// <summary>
        /// Tests that internal winrt wm info set property stores value correctly
        /// </summary>
        [Fact]
        public void InternalWinrtWmInfo_SetProperty_StoresValueCorrectly()
        {
            InternalWinrtWmInfo info = new InternalWinrtWmInfo
            {
                Window = new IntPtr(777)
            };

            Assert.Equal(new IntPtr(777), info.Window);
        }

        /// <summary>
        /// Tests that internal winrt wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalWinrtWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalWinrtWmInfo original = new InternalWinrtWmInfo { Window = new IntPtr(111) };
            InternalWinrtWmInfo copy = original;

            copy.Window = new IntPtr(222);

            Assert.Equal(new IntPtr(111), original.Window);
            Assert.Equal(new IntPtr(222), copy.Window);
        }
    }
}

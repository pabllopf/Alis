using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal android wm info test class
    /// </summary>
    public class InternalAndroidWmInfoTest
    {
        /// <summary>
        /// Tests that internal android wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalAndroidWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalAndroidWmInfo info = new InternalAndroidWmInfo();

            Assert.Equal(IntPtr.Zero, info.Window);
            Assert.Equal(IntPtr.Zero, info.Surface);
        }

        /// <summary>
        /// Tests that internal android wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalAndroidWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalAndroidWmInfo info = new InternalAndroidWmInfo
            {
                Window = new IntPtr(123),
                Surface = new IntPtr(456)
            };

            Assert.Equal(new IntPtr(123), info.Window);
            Assert.Equal(new IntPtr(456), info.Surface);
        }

        /// <summary>
        /// Tests that internal android wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalAndroidWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalAndroidWmInfo original = new InternalAndroidWmInfo { Window = new IntPtr(100) };
            InternalAndroidWmInfo copy = original;

            copy.Window = new IntPtr(200);

            Assert.Equal(new IntPtr(100), original.Window);
            Assert.Equal(new IntPtr(200), copy.Window);
        }
    }
}

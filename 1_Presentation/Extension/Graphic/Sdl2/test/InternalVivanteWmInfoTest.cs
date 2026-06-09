using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal vivante wm info test class
    /// </summary>
    public class InternalVivanteWmInfoTest
    {
        /// <summary>
        /// Tests that internal vivante wm info default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalVivanteWmInfo_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalVivanteWmInfo info = new InternalVivanteWmInfo();

            Assert.Equal(IntPtr.Zero, info.Display);
            Assert.Equal(IntPtr.Zero, info.Window);
        }

        /// <summary>
        /// Tests that internal vivante wm info set properties stores values correctly
        /// </summary>
        [Fact]
        public void InternalVivanteWmInfo_SetProperties_StoresValuesCorrectly()
        {
            InternalVivanteWmInfo info = new InternalVivanteWmInfo
            {
                Display = new IntPtr(1111),
                Window = new IntPtr(2222)
            };

            Assert.Equal(new IntPtr(1111), info.Display);
            Assert.Equal(new IntPtr(2222), info.Window);
        }

        /// <summary>
        /// Tests that internal vivante wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalVivanteWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalVivanteWmInfo original = new InternalVivanteWmInfo { Display = new IntPtr(3333) };
            InternalVivanteWmInfo copy = original;

            copy.Display = new IntPtr(4444);

            Assert.Equal(new IntPtr(3333), original.Display);
            Assert.Equal(new IntPtr(4444), copy.Display);
        }
    }
}

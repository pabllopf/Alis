using System;
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalKmsWmInfoTest
    {
        [Fact]
        public void InternalKmsWmInfo_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalKmsWmInfo info = new InternalKmsWmInfo();

            Assert.Equal(0, info.dev_index);
            Assert.Equal(0, info.drm_fd);
            Assert.Equal(IntPtr.Zero, info.gbm_dev);
        }

        [Fact]
        public void InternalKmsWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalKmsWmInfo original = new InternalKmsWmInfo();
            InternalKmsWmInfo copy = original;

            Assert.Equal(original.dev_index, copy.dev_index);
            Assert.Equal(original.drm_fd, copy.drm_fd);
            Assert.Equal(original.gbm_dev, copy.gbm_dev);
        }
    }
}

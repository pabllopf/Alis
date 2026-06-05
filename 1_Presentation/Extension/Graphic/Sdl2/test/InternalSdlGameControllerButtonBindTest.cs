using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalSdlGameControllerButtonBindTest
    {
        [Fact]
        public void InternalSdlGameControllerButtonBind_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalSdlGameControllerButtonBind bind = new InternalSdlGameControllerButtonBind();

            Assert.Equal(0, bind.bindType);
            Assert.Equal(0, bind.unionVal0);
            Assert.Equal(0, bind.unionVal1);
        }

        [Fact]
        public void InternalSdlGameControllerButtonBind_IsValueType_CopyIsIndependent()
        {
            InternalSdlGameControllerButtonBind original = new InternalSdlGameControllerButtonBind();
            InternalSdlGameControllerButtonBind copy = original;

            Assert.Equal(original.bindType, copy.bindType);
            Assert.Equal(original.unionVal0, copy.unionVal0);
            Assert.Equal(original.unionVal1, copy.unionVal1);
        }
    }
}

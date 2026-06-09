using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal sdl game controller button bind test class
    /// </summary>
    public class InternalSdlGameControllerButtonBindTest
    {
        /// <summary>
        /// Tests that internal sdl game controller button bind default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalSdlGameControllerButtonBind_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalSdlGameControllerButtonBind bind = new InternalSdlGameControllerButtonBind();

            Assert.Equal(0, bind.bindType);
            Assert.Equal(0, bind.unionVal0);
            Assert.Equal(0, bind.unionVal1);
        }

        /// <summary>
        /// Tests that internal sdl game controller button bind is value type copy is independent
        /// </summary>
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

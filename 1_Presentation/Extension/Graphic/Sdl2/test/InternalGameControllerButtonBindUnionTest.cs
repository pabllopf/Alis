using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalGameControllerButtonBindUnionTest
    {
        [Fact]
        public void InternalGameControllerButtonBindUnion_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalGameControllerButtonBindUnion u = new InternalGameControllerButtonBindUnion();

            Assert.Equal(0, u.button);
            Assert.Equal(0, u.axis);
            Assert.Equal(0, u.hat.Hat);
            Assert.Equal(0, u.hat.HatMask);
        }

        [Fact]
        public void InternalGameControllerButtonBindUnion_IsValueType_CopyIsIndependent()
        {
            InternalGameControllerButtonBindUnion original = new InternalGameControllerButtonBindUnion();
            InternalGameControllerButtonBindUnion copy = original;

            Assert.Equal(original.button, copy.button);
            Assert.Equal(original.axis, copy.axis);
        }
    }
}

using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal game controller button bind union test class
    /// </summary>
    public class InternalGameControllerButtonBindUnionTest
    {
        /// <summary>
        /// Tests that internal game controller button bind union default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindUnion_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalGameControllerButtonBindUnion u = new InternalGameControllerButtonBindUnion();

            Assert.Equal(0, u.button);
            Assert.Equal(0, u.axis);
            Assert.Equal(0, u.hat.Hat);
            Assert.Equal(0, u.hat.HatMask);
        }

        /// <summary>
        /// Tests that internal game controller button bind union is value type copy is independent
        /// </summary>
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

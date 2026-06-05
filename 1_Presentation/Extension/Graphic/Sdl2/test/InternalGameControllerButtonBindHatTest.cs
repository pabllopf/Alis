using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class InternalGameControllerButtonBindHatTest
    {
        [Fact]
        public void InternalGameControllerButtonBindHat_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalGameControllerButtonBindHat hat = new InternalGameControllerButtonBindHat();

            Assert.Equal(0, hat.Hat);
            Assert.Equal(0, hat.HatMask);
        }

        [Fact]
        public void InternalGameControllerButtonBindHat_SetProperties_StoresValuesCorrectly()
        {
            InternalGameControllerButtonBindHat hat = new InternalGameControllerButtonBindHat
            {
                Hat = 1,
                HatMask = 2
            };

            Assert.Equal(1, hat.Hat);
            Assert.Equal(2, hat.HatMask);
        }

        [Fact]
        public void InternalGameControllerButtonBindHat_IsValueType_CopyIsIndependent()
        {
            InternalGameControllerButtonBindHat original = new InternalGameControllerButtonBindHat { Hat = 5 };
            InternalGameControllerButtonBindHat copy = original;

            copy.Hat = 10;

            Assert.Equal(5, original.Hat);
            Assert.Equal(10, copy.Hat);
        }
    }
}

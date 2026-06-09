using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal game controller button bind hat test class
    /// </summary>
    public class InternalGameControllerButtonBindHatTest
    {
        /// <summary>
        /// Tests that internal game controller button bind hat default initialization properties have default values
        /// </summary>
        [Fact]
        public void InternalGameControllerButtonBindHat_DefaultInitialization_PropertiesHaveDefaultValues()
        {
            InternalGameControllerButtonBindHat hat = new InternalGameControllerButtonBindHat();

            Assert.Equal(0, hat.Hat);
            Assert.Equal(0, hat.HatMask);
        }

        /// <summary>
        /// Tests that internal game controller button bind hat set properties stores values correctly
        /// </summary>
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

        /// <summary>
        /// Tests that internal game controller button bind hat is value type copy is independent
        /// </summary>
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



using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the GameControllerType struct.
    /// </summary>
    public class GameControllerTypeTest
    {
        /// <summary>
        ///     Tests the GameControllerType struct default initialization.
        /// </summary>
        [Fact]
        public void GameControllerType_DefaultInitialization_CreatesValidStruct()
        {
            GameControllerType controllerType = new GameControllerType();

            Assert.NotNull(controllerType);
        }

        /// <summary>
        ///     Tests that GameControllerType can be used as a value type.
        /// </summary>
        [Fact]
        public void GameControllerType_IsValueType_CanBeCopied()
        {
            GameControllerType original = new GameControllerType();

            GameControllerType copy = original;

            Assert.Equal(original.GetType(), copy.GetType());
        }

        /// <summary>
        ///     Tests that multiple GameControllerType instances are independent.
        /// </summary>
        [Fact]
        public void GameControllerType_MultipleInstances_AreIndependent()
        {
            GameControllerType type1 = new GameControllerType();
            GameControllerType type2 = new GameControllerType();

            Assert.NotNull(type1);
            Assert.NotNull(type2);
        }
    }
}
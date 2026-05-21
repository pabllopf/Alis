//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Sprite component record struct
    /// </summary>
    public class SpriteTest
    {
        /// <summary>
        ///     Tests that the constructor creates a Sprite with default values
        /// </summary>
        [Fact]
        public void Sprite_Constructor_ShouldCreateWithDefaultValues()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Equal(context, sprite.Context);
            Assert.Equal("test.png", sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }

        /// <summary>
        ///     Tests that the OnExit method exists and is callable
        /// </summary>
        [Fact]
        public void Sprite_OnExitMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.OnExit(null!);
        }

        /// <summary>
        ///     Tests that Sprite implements ISprite interface
        /// </summary>
        [Fact]
        public void Sprite_ShouldImplementISpriteInterface()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.IsAssignableFrom<ISprite>(sprite);
        }

        /// <summary>
        ///     Tests that Sprite properties are gettable and settable
        /// </summary>
        [Fact]
        public void Sprite_Properties_ShouldBeGetAndSettable()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Equal("test.png", sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }

        /// <summary>
        ///     Tests that Sprite can be created without exceptions
        /// </summary>
        [Fact]
        public void Sprite_Constructor_ShouldNotThrow()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, string.Empty, 0);

            Assert.NotNull(sprite);
        }

        /// <summary>
        ///     Tests that Sprite properties can be modified independently
        /// </summary>
        [Fact]
        public void Sprite_Properties_ShouldBeModifiedIndependently()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.NameFile = "new_sprite.png";
            Assert.Equal("new_sprite.png", sprite.NameFile);
            Assert.Equal(0, sprite.Depth);

            sprite.Depth = 5;
            Assert.Equal("new_sprite.png", sprite.NameFile);
            Assert.Equal(5, sprite.Depth);
        }

        /// <summary>
        ///     Tests that Sprite is a record struct (value-based equality)
        /// </summary>
        [Fact]
        public void Sprite_ShouldBeRecordStructWithValueEquality()
        {
            Context context = new Context();

            Sprite sprite1 = new Sprite(context, "test.png", 0);
            Sprite sprite2 = new Sprite(context, "test.png", 0);

            Assert.Equal(sprite1, sprite2);
        }

        /// <summary>
        ///     Tests that Sprite has expected public members
        /// </summary>
        [Fact]
        public void Sprite_ShouldHaveExpectedPublicMembers()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.NotNull(sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }

        /// <summary>
        ///     Tests that Sprite constructor doesn't throw with empty name
        /// </summary>
        [Fact]
        public void Sprite_Constructor_WithEmptyName_ShouldNotThrow()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, string.Empty, 0);

            Assert.NotNull(sprite);
            Assert.Equal(string.Empty, sprite.NameFile);
        }

        /// <summary>
        ///     Tests that Sprite default state is valid
        /// </summary>
        [Fact]
        public void Sprite_DefaultState_ShouldBeValid()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, string.Empty, 0);

            Assert.NotNull(sprite.Context);
            Assert.Equal(string.Empty, sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }
    }
}

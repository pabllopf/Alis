

using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Input;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Input
{
    /// <summary>
    ///     Contains unit tests for the <see cref="InputManager" /> class.
    /// </summary>
    public class InputManagerTest
    {
        /// <summary>
        ///     Tests that the constructor creates an InputManager with the provided context.
        /// </summary>
        [Fact]
        public void Constructor_CreatesInputManager_WithContext()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            InputManager inputManager = new InputManager(context);

            Assert.NotNull(inputManager);
            Assert.Same(context, inputManager.Context);
        }

        /// <summary>
        ///     Tests that InputManager inherits from AManager.
        /// </summary>
        [Fact]
        public void InputManager_InheritsFromAManager()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            InputManager inputManager = new InputManager(context);

            Assert.IsAssignableFrom<AManager>(inputManager);
        }

        /// <summary>
        ///     Tests that InputManager has the expected default properties.
        /// </summary>
        [Fact]
        public void InputManager_HasExpectedProperties()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            InputManager inputManager = new InputManager(context);

            Assert.NotNull(inputManager.Id);
            Assert.Equal("Manager", inputManager.Name);
            Assert.Equal("Untagged", inputManager.Tag);
            Assert.True(inputManager.IsEnable);
        }
        
        /// <summary>
        ///     Tests that the InputManager context is set correctly.
        /// </summary>
        [Fact]
        public void InputManager_Context_IsSetCorrectly()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            InputManager inputManager = new InputManager(context);

            Assert.NotNull(inputManager.Context);
            Assert.Same(context, inputManager.Context);
        }

        /// <summary>
        ///     Tests that InputManager implements IManager interface.
        /// </summary>
        [Fact]
        public void InputManager_ImplementsIManagerInterface()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            InputManager inputManager = new InputManager(context);

            Assert.IsAssignableFrom<IManager>(inputManager);
        }

        /// <summary>
        ///     Tests that the InputManager default state is valid.
        /// </summary>
        [Fact]
        public void InputManager_DefaultState_IsValid()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            InputManager inputManager = new InputManager(context);

            Assert.NotNull(inputManager.Id);
            Assert.NotEmpty(inputManager.Id);
            Assert.NotNull(inputManager.Name);
            Assert.NotNull(inputManager.Tag);
            Assert.True(inputManager.IsEnable);
        }

        /// <summary>
        ///     Tests that InputManager properties are accessible.
        /// </summary>
        [Fact]
        public void InputManager_Properties_AreAccessible()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            InputManager inputManager = new InputManager(context);
            inputManager.Name = "Input";
            inputManager.Tag = "InputTag";
            inputManager.IsEnable = false;

            Assert.Equal("Input", inputManager.Name);
            Assert.Equal("InputTag", inputManager.Tag);
            Assert.False(inputManager.IsEnable);
        }

        /// <summary>
        ///     Tests the full constructor with all parameters.
        /// </summary>
        [Theory]
        [InlineData("test-id", "TestInput", "InputTag", true)]
        [InlineData("", "", "", false)]
        public void FullConstructor_SetsAllProperties(string id, string name, string tag, bool isEnable)
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            InputManager inputManager = new InputManager(id, name, tag, isEnable, context);

            Assert.Equal(id, inputManager.Id);
            Assert.Equal(name, inputManager.Name);
            Assert.Equal(tag, inputManager.Tag);
            Assert.Equal(isEnable, inputManager.IsEnable);
        }
    }
}

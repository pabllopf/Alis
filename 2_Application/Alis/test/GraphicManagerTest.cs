

using System;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="GraphicManager" /> class.
    /// </summary>
    public class GraphicManagerTest
    {
        /// <summary>
        ///     Tests that the constructor creates a GraphicManager with the provided context.
        /// </summary>
        [Fact]
        public void Constructor_CreatesGraphicManager_WithContext()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            GraphicManager graphicManager = new GraphicManager(context);

            Assert.NotNull(graphicManager);
            Assert.Same(context, graphicManager.Context);
        }

        /// <summary>
        ///     Tests that GraphicManager inherits from AManager.
        /// </summary>
        [Fact]
        public void GraphicManager_InheritsFromAManager()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            Assert.IsAssignableFrom<AManager>(graphicManager);
        }

        /// <summary>
        ///     Tests that GraphicManager has the expected default properties.
        /// </summary>
        [Fact]
        public void GraphicManager_HasExpectedProperties()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            Assert.NotNull(graphicManager.Id);
            Assert.Equal("Manager", graphicManager.Name);
            Assert.Equal("Untagged", graphicManager.Tag);
            Assert.True(graphicManager.IsEnable);
        }

        /// <summary>
        ///     Tests that the GraphicManager context is set correctly.
        /// </summary>
        [Fact]
        public void GraphicManager_Context_IsSetCorrectly()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            GraphicManager graphicManager = new GraphicManager(context);

            Assert.NotNull(graphicManager.Context);
            Assert.Same(context, graphicManager.Context);
        }

        /// <summary>
        ///     Tests that GraphicManager implements IManager interface.
        /// </summary>
        [Fact]
        public void GraphicManager_ImplementsIManagerInterface()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            Assert.IsAssignableFrom<IManager>(graphicManager);
        }

        /// <summary>
        ///     Tests that the GraphicManager default state is valid.
        /// </summary>
        [Fact]
        public void GraphicManager_DefaultState_IsValid()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            Assert.NotNull(graphicManager.Id);
            Assert.NotEmpty(graphicManager.Id);
            Assert.NotNull(graphicManager.Name);
            Assert.NotNull(graphicManager.Tag);
            Assert.True(graphicManager.IsEnable);
        }

        /// <summary>
        ///     Tests that GraphicManager properties are accessible.
        /// </summary>
        [Fact]
        public void GraphicManager_Properties_AreAccessible()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());

            GraphicManager graphicManager = new GraphicManager(context);
            graphicManager.Name = "Graphic";
            graphicManager.Tag = "GraphicTag";
            graphicManager.IsEnable = false;

            Assert.Equal("Graphic", graphicManager.Name);
            Assert.Equal("GraphicTag", graphicManager.Tag);
            Assert.False(graphicManager.IsEnable);
        }

        /// <summary>
        ///     Tests that the Renderer property is accessible.
        /// </summary>
        [Fact]
        public void GraphicManager_RendererProperty_IsAccessible()
        {
            Context context = new Context(new Alis.Core.Ecs.Systems.Configuration.Setting());
            GraphicManager graphicManager = new GraphicManager(context);

            IntPtr renderer = new IntPtr(1234);
            graphicManager.Renderer = renderer;

            Assert.Equal(renderer, graphicManager.Renderer);
        }
    }
}

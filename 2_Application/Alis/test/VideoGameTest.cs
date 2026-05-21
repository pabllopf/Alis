

using System;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for VideoGame class constructors, delegation, and interface implementations
    /// </summary>
    public class VideoGameTest
    {
        /// <summary>
        ///     Tests that default constructor creates ContextHandler with default Context
        /// </summary>
        [Fact]
        public void VideoGame_DefaultConstructor_ShouldCreateContextHandlerWithDefaultContext()
        {
            VideoGame game = new VideoGame();

            Assert.NotNull(game.Context);
            Assert.NotNull(game.Context.Setting);
            Assert.NotNull(game.Context.InternalRuntime);
        }

        /// <summary>
        ///     Tests that constructor with Setting creates Context with that setting
        /// </summary>
        [Fact]
        public void VideoGame_SettingConstructor_ShouldCreateContextWithProvidedSetting()
        {
            GeneralSetting general = new GeneralSetting(false, "TestGame", "Default Description", "0.0.0",
                "Pablo Perdomo Falcón", "GPL-3.0 license", "app.ico");
            Setting customSetting = new Setting(general, new AudioSetting(), new GraphicSetting(), new InputSetting(), new NetworkSetting(), new PhysicSetting());

            VideoGame game = new VideoGame(customSetting);

            Assert.Same(customSetting, game.Context.Setting);
            Assert.Equal("TestGame", game.Context.Setting.General.Name);
        }

        /// <summary>
        ///     Tests that constructor with Context creates ContextHandler with that context
        /// </summary>
        [Fact]
        public void VideoGame_ContextConstructor_ShouldCreateContextHandlerWithProvidedContext()
        {
            Context context = new Context();

            VideoGame game = new VideoGame(context);

            Assert.Same(context, game.Context);
        }

        /// <summary>
        ///     Tests that constructor with IContextHandler stores handler
        /// </summary>
        [Fact]
        public void VideoGame_ContextHandlerConstructor_ShouldStoreProvidedHandler()
        {
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            Context context = new Context();
            mockHandler.Setup(h => h.Context).Returns(context);

            VideoGame game = new VideoGame(mockHandler.Object);

            Assert.Same(context, game.Context);
        }

        /// <summary>
        ///     Tests that Context property returns handler's context
        /// </summary>
        [Fact]
        public void VideoGame_ContextProperty_ShouldReturnHandlerContext()
        {
            Context expectedContext = new Context();
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            mockHandler.Setup(h => h.Context).Returns(expectedContext);

            VideoGame game = new VideoGame(mockHandler.Object);

            Assert.Same(expectedContext, game.Context);
        }

        /// <summary>
        ///     Tests that Run delegates to contextHandler.Run
        /// </summary>
        [Fact]
        public void VideoGame_Run_ShouldDelegateToContextHandlerRun()
        {
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            Context context = new Context();
            mockHandler.Setup(h => h.Context).Returns(context);

            VideoGame game = new VideoGame(mockHandler.Object);

            game.Run();

            mockHandler.Verify(h => h.Run(), Times.Once);
        }

        /// <summary>
        ///     Tests that Exit delegates to contextHandler.Exit
        /// </summary>
        [Fact]
        public void VideoGame_Exit_ShouldDelegateToContextHandlerExit()
        {
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            Context context = new Context();
            mockHandler.Setup(h => h.Context).Returns(context);

            VideoGame game = new VideoGame(mockHandler.Object);

            game.Exit();

            mockHandler.Verify(h => h.Exit(), Times.Once);
        }

        /// <summary>
        ///     Tests that Save delegates to contextHandler.Save
        /// </summary>
        [Fact]
        public void VideoGame_Save_ShouldDelegateToContextHandlerSave()
        {
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            Context context = new Context();
            mockHandler.Setup(h => h.Context).Returns(context);

            VideoGame game = new VideoGame(mockHandler.Object);

            game.Save();

            mockHandler.Verify(h => h.Save(), Times.Once);
        }

        /// <summary>
        ///     Tests that InitPreview delegates to contextHandler.InitPreview
        /// </summary>
        [Fact]
        public void VideoGame_InitPreview_ShouldDelegateToContextHandlerInitPreview()
        {
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            Context context = new Context();
            mockHandler.Setup(h => h.Context).Returns(context);

            VideoGame game = new VideoGame(mockHandler.Object);

            game.InitPreview();

            mockHandler.Verify(h => h.InitPreview(), Times.Once);
        }

        /// <summary>
        ///     Tests that Preview delegates to contextHandler.Preview
        /// </summary>
        [Fact]
        public void VideoGame_Preview_ShouldDelegateToContextHandlerPreview()
        {
            Mock<IContextHandler<Context>> mockHandler = new Mock<IContextHandler<Context>>();
            Context context = new Context();
            mockHandler.Setup(h => h.Context).Returns(context);

            VideoGame game = new VideoGame(mockHandler.Object);

            game.Preview();

            mockHandler.Verify(h => h.Preview(), Times.Once);
        }

        /// <summary>
        ///     Tests that Create returns new VideoGameBuilder
        /// </summary>
        [Fact]
        public void VideoGame_Create_ShouldReturnNewVideoGameBuilder()
        {
            VideoGameBuilder builder = VideoGame.Create();

            Assert.NotNull(builder);
            Assert.IsType<VideoGameBuilder>(builder);
        }

        /// <summary>
        ///     Tests that Create returns non-null builder
        /// </summary>
        [Fact]
        public void VideoGame_Create_ShouldReturnNonNullBuilder()
        {
            VideoGameBuilder builder = VideoGame.Create();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that VideoGame implements IGame interface
        /// </summary>
        [Fact]
        public void VideoGame_ShouldImplementIGameInterface()
        {
            VideoGame game = new VideoGame();

            Assert.IsAssignableFrom<IGame>(game);
        }
        
        /// <summary>
        ///     Tests that VideoGame is sealed class
        /// </summary>
        [Fact]
        public void VideoGame_ShouldBeSealedClass()
        {
            Type type = typeof(VideoGame);

            Assert.True(type.IsSealed);
        }
    }
}

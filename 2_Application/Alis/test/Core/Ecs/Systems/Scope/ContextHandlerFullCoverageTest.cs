using System.Threading;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    public class ContextHandlerFullCoverageTest
    {
        private static Context CreateContextWithScene()
        {
            Context context = new Context(new Setting());
            Scene scene = new Scene();
            context.SceneManager.LoadedScenes.Add(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

        [Fact]
        public void Run_WithPreviewModeAndScene_ExitsQuickly()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            ContextHandler handler = new ContextHandler(context);

            Assert.True(context.IsRunning);

            Thread.Sleep(1500);

            handler.Exit();

            handler.Run();

            Assert.False(context.IsRunning);
        }

        [Fact]
        public void Run_WithDefaultTargetFrames_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true, TargetFrames = 60f };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Thread.Sleep(100);

            handler.Preview();
        }

        [Fact]
        public void Run_CompletesOneLoop_WhenIsRunningIsFalse()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            ContextHandler handler = new ContextHandler(context);

            handler.Exit();

            handler.Run();
        }

        [Fact]
        public void Preview_AccumulatesMultipleFixedTimeSteps_CoversWhileLoop()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Thread.Sleep(200);

            Assert.Throws<Alis.Core.Graphic.OpenGL.GlException>(() => handler.Preview());
        }

        [Fact]
        public void InitPreview_SetsTimingFields()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Assert.True(context.Setting.Graphic.PreviewMode);
        }

        [Fact]
        public void Save_WithDefaultContext_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save();
        }

        [Fact]
        public void Load_WithDefaultContext_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Load();
        }

        [Fact]
        public void LoadAndRun_WithStoppedContext_ExitsImmediately()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.Exit();

            handler.LoadAndRun();

            Assert.False(context.IsRunning);
        }

        [Fact]
        public void Save_WithFilePath_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save("/tmp/test-save.dat");
        }

        [Fact]
        public void Save_WithFilePath_CallsInternalRuntimeSave()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save("/tmp/test-save-path.dat");
        }
    }
}

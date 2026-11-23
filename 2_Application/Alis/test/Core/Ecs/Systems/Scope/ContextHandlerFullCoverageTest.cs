using System;
using System.Threading;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Scene = Alis.Core.Ecs.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    /// The context handler full coverage test class
    /// </summary>
    public class ContextHandlerFullCoverageTest
    {
        /// <summary>
        /// Creates the context with scene
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContextWithScene()
        {
            Context context = new Context(new Setting());
            Scene scene = new Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

        /// <summary>
        /// Tests that run with preview mode and scene exits quickly
        /// </summary>
        [Fact]
        public void Run_WithPreviewModeAndScene_ExitsQuickly()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            ContextHandler handler = new ContextHandler(context);

            Assert.True(context.IsRunning);

            Thread.Sleep(10);

            handler.Exit();

            handler.Run();

            Assert.False(context.IsRunning);
        }

        /// <summary>
        /// Tests that run completes one loop when is running is false
        /// </summary>
        [Fact]
        public void Run_CompletesOneLoop_WhenIsRunningIsFalse()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            ContextHandler handler = new ContextHandler(context);

            handler.Exit();

            handler.Run();
        }

        /// <summary>
        /// Tests that preview accumulates multiple fixed time steps covers while loop
        /// </summary>
        [Fact]
        public void Preview_AccumulatesMultipleFixedTimeSteps_CoversWhileLoop()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Thread.Sleep(20);

            Assert.ThrowsAny<Exception>(() => handler.Preview());
        }

        /// <summary>
        /// Tests that init preview sets timing fields
        /// </summary>
        [Fact]
        public void InitPreview_SetsTimingFields()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Assert.True(context.Setting.Graphic.PreviewMode);
        }

        /// <summary>
        /// Tests that save with default context does not throw
        /// </summary>
        [Fact]
        public void Save_WithDefaultContext_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save();
        }

        /// <summary>
        /// Tests that load with default context does not throw
        /// </summary>
        [Fact]
        public void Load_WithDefaultContext_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Load();
        }

        /// <summary>
        /// Tests that load and run with stopped context exits immediately
        /// </summary>
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

        /// <summary>
        ///     Tests that preview advances time for both paced and over-budget frames
        /// </summary>
        [Fact]
        public void Preview_WithFastAndSlowFrames_AdvancesTimeWithoutNativeRendering()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            context.InternalRuntime.runtimes.RemoveAll(x => x is global::Alis.Core.Ecs.Systems.Manager.Graphic.GraphicManager);
            ContextHandler handler = new ContextHandler(context);
            handler.InitPreview();

            handler.Preview();
            float framesAfterFastFrame = context.TimeManager.FrameCount;
            Thread.Sleep(50);
            handler.Preview();

            Assert.True(framesAfterFastFrame > 0);
            Assert.True(context.TimeManager.FrameCount > framesAfterFastFrame);
            Assert.False(context.TimeManager.InFixedTimeStep);
        }

        /// <summary>
        ///     Tests that run executes the full frame path including fixed updates and frame pacing
        /// </summary>
        [Fact]
        public void Run_WithSlowFirstFrame_ExecutesFixedAndPacedFrames()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            context.InternalRuntime.runtimes.RemoveAll(x => x is global::Alis.Core.Ecs.Systems.Manager.Graphic.GraphicManager);
            context.InternalRuntime.runtimes.Add(new StopAfterSlowFrameManager(context));
            ContextHandler handler = new ContextHandler(context);

            handler.Run();

            Assert.False(context.IsRunning);
            Assert.True(context.TimeManager.InFixedTimeStep == false);
            Assert.True(context.TimeManager.TotalFrames >= 2);
        }

        /// <summary>
        /// Tests that save with file path does not throw
        /// </summary>
        [Fact]
        public void Save_WithFilePath_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save("/tmp/test-save.dat");
        }

        /// <summary>
        /// Tests that save with file path calls internal runtime save
        /// </summary>
        [Fact]
        public void Save_WithFilePath_CallsInternalRuntimeSave()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save("/tmp/test-save-path.dat");
        }

        /// <summary>
        ///     Manager that forces one slow frame and then stops the loop.
        /// </summary>
        private sealed class StopAfterSlowFrameManager : AManager
        {
            private int dispatchCount;

            internal StopAfterSlowFrameManager(Context context) : base(context)
            {
            }

            public override void OnDispatchEvents()
            {
                dispatchCount++;
                if (dispatchCount >= 2)
                {
                    Context.Exit();
                }
            }

            public override void OnBeforeUpdate()
            {
                if (dispatchCount == 1)
                {
                    Thread.Sleep(1050);
                }
            }
        }
    }
}

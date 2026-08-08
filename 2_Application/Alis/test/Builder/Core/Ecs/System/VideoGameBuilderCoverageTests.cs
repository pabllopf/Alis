using System.Reflection;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs.Systems.Scope;
using Scene = Alis.Core.Ecs.Scene;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System
{
    /// <summary>
    /// The video game builder coverage tests class
    /// </summary>
    public class VideoGameBuilderCoverageTests
    {
        /// <summary>
        /// Tests that run when context is not running exits immediately
        /// </summary>
        [Fact]
        public void Run_WhenContextIsNotRunning_ExitsImmediately()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            FieldInfo contextField = typeof(VideoGameBuilder).GetField("Context", BindingFlags.Instance | BindingFlags.NonPublic);
            Context context = (Context)contextField.GetValue(builder);

            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            Scene scene = new Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;

            context.Exit();

            builder.Run();
        }
    }
}

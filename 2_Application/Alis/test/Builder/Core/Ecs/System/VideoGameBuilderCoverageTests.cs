using System.Reflection;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System
{
    public class VideoGameBuilderCoverageTests
    {
        [Fact]
        public void Run_WhenContextIsNotRunning_ExitsImmediately()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            FieldInfo contextField = typeof(VideoGameBuilder).GetField("Context", BindingFlags.Instance | BindingFlags.NonPublic);
            Context context = (Context)contextField.GetValue(builder);

            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };

            Scene scene = new Scene();
            context.SceneManager.LoadedScenes.Add(scene);
            context.SceneManager.CurrentWorld = scene;

            context.Exit();

            builder.Run();
        }
    }
}

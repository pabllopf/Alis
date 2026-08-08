using System.Reflection;
using Alis.Builder.Core.Ecs.System;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System
{
    /// <summary>
    /// The video game builder remaining coverage tests class
    /// </summary>
    public class VideoGameBuilderRemainingCoverageTests
    {
        /// <summary>
        /// Tests that run calls build and run completes when is running is false
        /// </summary>
        [Fact]
        public void Run_CallsBuildAndRun_CompletesWhenIsRunningIsFalse()
        {
            VideoGameBuilder builder = new VideoGameBuilder();

            builder.World(sb => sb.Add<Scene>(_ => { }));

            FieldInfo contextField = typeof(VideoGameBuilder).GetField("Context", BindingFlags.Instance | BindingFlags.NonPublic);
            Context context = (Context)contextField.GetValue(builder);
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            context.Exit();

            builder.Run();
        }
    }
}

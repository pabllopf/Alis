using System;
using Alis.Builder.Core.Ecs.Entity;
using Alis.Builder.Core.Ecs.System.ManagerBuilders.Scenes;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ManagerBuilders.Scenes
{
    public class SceneManagerBuilderCoverageTest
    {
        [Fact]
        public void Add_WithSceneBuilderConfig_ShouldAddScene()
        {
            Context context = new Context();
            SceneManagerBuilder builder = new SceneManagerBuilder(context);

            SceneManager result = builder
                .Add<Scene>(sb => sb.Name("TestScene"))
                .Build();

            Assert.Single(result.LoadedScenes);
        }

        [Fact]
        public void Add_WithMultipleConfigs_ShouldAddMultipleScenes()
        {
            Context context = new Context();
            SceneManagerBuilder builder = new SceneManagerBuilder(context);

            SceneManager result = builder
                .Add<Scene>(sb => sb.Name("Scene1"))
                .Add<Scene>(sb => sb.Name("Scene2"))
                .Build();

            Assert.Equal(2, result.LoadedScenes.Count);
        }

        [Fact]
        public void Add_ReturnsSameBuilder()
        {
            Context context = new Context();
            SceneManagerBuilder builder = new SceneManagerBuilder(context);

            SceneManagerBuilder result = builder.Add<Scene>(sb => { });

            Assert.Same(builder, result);
        }
    }
}

using Alis.Builder.Core.Ecs.System.ManagerBuilders.Scenes;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ManagerBuilders.Scenes
{
    /// <summary>
    /// The scene manager builder coverage test class
    /// </summary>
    public class SceneManagerBuilderCoverageTest
    {
        /// <summary>
        /// Tests that add with scene builder config should add scene
        /// </summary>
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

        /// <summary>
        /// Tests that add with multiple configs should add multiple scenes
        /// </summary>
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

        /// <summary>
        /// Tests that add returns same builder
        /// </summary>
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

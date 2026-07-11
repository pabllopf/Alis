using System;
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    public class GameObjectBuilderFullCoverageTests
    {
        [Fact]
        public void Name_WhenGameObjectDoesNotHaveInfo_ShouldAddInfo()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);

            GameObject result = builder
                .Name("TestName")
                .Build();

            Assert.True(result.Has<Info>());
            Assert.Equal("TestName", result.Get<Info>().Name);
        }

        [Fact]
        public void Id_ShouldSetInfoId()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);

            GameObjectBuilder result = builder.Id(42);

            Assert.Same(builder, result);
        }

        [Fact]
        public void Id_AfterBuild_ShouldReflectSetId()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);

            builder.Id(99);

            Assert.Equal(99, builder.Build().Get<Info>().Id);
        }
    }
}

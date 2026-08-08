using System;
using System.Reflection;
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;
using Scene = Alis.Core.Ecs.Scene;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    /// <summary>
    /// The game object builder full coverage tests class
    /// </summary>
    public class GameObjectBuilderFullCoverageTests
    {
        /// <summary>
        /// Tests that name when game object does not have info should add info
        /// </summary>
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
        }

        /// <summary>
        /// Tests that id should set info id
        /// </summary>
        [Fact]
        public void Id_ShouldSetInfoId()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);

            GameObjectBuilder result = builder.Id(42);

            Assert.Same(builder, result);
        }
    }
}

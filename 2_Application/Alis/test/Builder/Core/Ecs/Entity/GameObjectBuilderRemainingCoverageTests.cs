using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Builder.Core.Ecs.Entity;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity
{
    public class GameObjectBuilderRemainingCoverageTests
    {
        [Fact]
        public void WithComponent_AudioSourceConfig_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            AudioSourceConfig<AudioSource> config = b => b.File("test.wav").Volume(50).Mute(false);
            GameObjectBuilder result = builder.WithComponent(config);
            Assert.Same(builder, result);
        }

        [Fact]
        public void WithComponent_WithInstance_WithoutIHasContext_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            Info info = new Info();
            GameObjectBuilder result = builder.WithComponent(info);
            Assert.Same(builder, result);
        }
        
        [Fact]
        public void IsActive_NoArgs_WithoutExistingInfo_ReturnsBuilder()
        {
            Context context = new Context();
            Scene scene = new Scene();
            GameObjectBuilder builder = new GameObjectBuilder(scene, context);
            GameObjectBuilder result = builder.IsActive();
            Assert.Same(builder, result);
        }
    }
}

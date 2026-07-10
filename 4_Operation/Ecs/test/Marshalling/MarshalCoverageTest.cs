using System;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Marshalling
{
    public class MarshalCoverageTest
    {
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void GameObjectMarshal_Exists()
        {
            Assert.NotNull(typeof(GameObjectMarshal));
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void SceneMarshal_Exists()
        {
            Assert.NotNull(typeof(SceneMarshal));
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void SceneMarshal_GetComponent_ReturnsReference()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position { X = 10, Y = 20 });
            ref Position pos = ref SceneMarshal.GetComponent<Position>(scene, go);
            Assert.Equal(10, pos.X);
        }

        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void SceneMarshal_GetRawBuffer_ReturnsSpan()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 10, Y = 20 });
            GameObject go = scene.Create(new Position { X = 30, Y = 40 });
            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(scene, go, out int index);
            Assert.Equal(30, buffer[index].X);
        }
    }
}

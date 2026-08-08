using System;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Marshalling
{
    /// <summary>
    /// The marshal coverage test class
    /// </summary>
    public class MarshalCoverageTest
    {
        /// <summary>
        /// Tests that scene marshal exists
        /// </summary>
        [Fact]
        public void SceneMarshal_Exists()
        {
            Assert.NotNull(typeof(SceneMarshal));
        }

        /// <summary>
        /// Tests that scene marshal get component returns reference
        /// </summary>
        [Fact]
        public void SceneMarshal_GetComponent_ReturnsReference()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position { X = 10, Y = 20 });
            ref Position pos = ref SceneMarshal.GetComponent<Position>(scene, go);
            Assert.Equal(10f, pos.X, 5);
        }

        /// <summary>
        /// Tests that scene marshal get raw buffer returns span
        /// </summary>
        [Fact]
        public void SceneMarshal_GetRawBuffer_ReturnsSpan()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 10, Y = 20 });
            GameObject go = scene.Create(new Position { X = 30, Y = 40 });
            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(scene, go, out int index);
            Assert.Equal(30f, buffer[index].X, 5);
        }
    }
}

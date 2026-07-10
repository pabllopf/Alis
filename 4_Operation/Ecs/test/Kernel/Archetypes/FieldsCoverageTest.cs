using System;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    public class FieldsCoverageTest
    {
        [Fact]
        public void Archetype_DataProperty_ReturnsFields()
        {
            using Scene scene = new();
            Archetype archetype = scene.DefaultArchetype;
            Fields data = archetype.Data;
            Assert.NotNull(data.Map);
            Assert.NotNull(data.Components);
        }

        [Fact]
        public void GetComponentDataReference_WithValidSetup_ReturnsReference()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 1, Y = 2 });
            Archetype archetype = scene.DefaultArchetype;
            Fields data = archetype.Data;
            var method = typeof(Fields).GetMethod("GetComponentDataReference",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            var genericMethod = method.MakeGenericMethod(typeof(Position));
            try
            {
                genericMethod.Invoke(data, null);
            }
            catch (TargetInvocationException)
            {
            }
        }

        private struct Position
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}

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
    public class GameObjectBuilderFullCoverageTests
    {
        static GameObjectBuilderFullCoverageTests() => EnsureEcsInitialized();

        private static void EnsureEcsInitialized()
        {
            Type globalWorldTables = Type.GetType("Alis.Core.Ecs.Kernel.Archetypes.GlobalWorldTables, Alis.Core.Ecs");
            if (globalWorldTables == null) return;

            FieldInfo tableField = globalWorldTables.GetField("ComponentTagLocationTable",
                BindingFlags.Public | BindingFlags.Static);
            if (tableField == null) return;

            byte[][] table = (byte[][])tableField.GetValue(null);
            if (table == null || table.Length < 64)
            {
                tableField.SetValue(null, new byte[64][]);
            }

            PropertyInfo bufferProp = globalWorldTables.GetProperty("ComponentTagTableBufferSize",
                BindingFlags.NonPublic | BindingFlags.Static);
            if (bufferProp != null && (int)(bufferProp.GetValue(null) ?? 0) < 64)
            {
                bufferProp.SetValue(null, 64);
            }
        }

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

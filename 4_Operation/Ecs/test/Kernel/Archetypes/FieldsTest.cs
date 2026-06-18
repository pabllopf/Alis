using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    public class FieldsTest
    {
        [Fact]
        public void DefaultConstructor_ShouldInitializeFieldsToNull()
        {
            Fields fields = default;

            Assert.Null(fields.Map);
            Assert.Null(fields.Components);
        }

        [Fact]
        public void Fields_CanSetMap()
        {
            Fields fields = default;
            byte[] map = [1, 2, 3];

            fields.Map = map;

            Assert.Same(map, fields.Map);
        }

        [Fact]
        public void Fields_CanSetComponents()
        {
            Fields fields = default;
            ComponentStorageBase[] components = [];

            fields.Components = components;

            Assert.Same(components, fields.Components);
        }

        [Fact]
        public void StructLayout_ShouldBeSequential()
        {
            Assert.True(typeof(Fields).IsValueType);
            Assert.Equal(LayoutKind.Sequential, typeof(Fields).StructLayoutAttribute.Value);
        }
    }
}

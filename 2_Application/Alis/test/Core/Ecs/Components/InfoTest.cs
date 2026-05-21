

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components;
using Xunit;

namespace Alis.Test.Core.Ecs.Components
{
    /// <summary>
    ///     Tests for the Info component record struct
    /// </summary>
    public class InfoTest
    {
        /// <summary>
        ///     Tests that the default constructor sets expected defaults
        /// </summary>
        [Fact]
        public void Info_DefaultConstructor_ShouldSetExpectedDefaults()
        {
            Info info = new Info();

            Assert.Equal(0, info.Id);
            Assert.False(info.IsStatic);
            Assert.Null(info.Name);
            Assert.Null(info.Tag);
        }

        /// <summary>
        ///     Tests that the Id property is settable
        /// </summary>
        [Fact]
        public void Info_IdProperty_ShouldBeSettable()
        {
            Info info = new Info();

            info.Id = 42;
            Assert.Equal(42, info.Id);
        }

        /// <summary>
        ///     Tests that the IsActive property is settable
        /// </summary>
        [Fact]
        public void Info_IsActiveProperty_ShouldBeSettable()
        {
            Info info = new Info();

            info.IsActive = false;
            Assert.False(info.IsActive);

            info.IsActive = true;
            Assert.True(info.IsActive);
        }

        /// <summary>
        ///     Tests that the IsStatic property is settable
        /// </summary>
        [Fact]
        public void Info_IsStaticProperty_ShouldBeSettable()
        {
            Info info = new Info();

            info.IsStatic = true;
            Assert.True(info.IsStatic);

            info.IsStatic = false;
            Assert.False(info.IsStatic);
        }

        /// <summary>
        ///     Tests that the Name property is settable
        /// </summary>
        [Fact]
        public void Info_NameProperty_ShouldBeSettable()
        {
            Info info = new Info();

            info.Name = "TestEntity";
            Assert.Equal("TestEntity", info.Name);
        }

        /// <summary>
        ///     Tests that the Tag property is settable
        /// </summary>
        [Fact]
        public void Info_TagProperty_ShouldBeSettable()
        {
            Info info = new Info();

            info.Tag = "Player";
            Assert.Equal("Player", info.Tag);
        }

        /// <summary>
        ///     Tests that the OnInit method exists and is callable
        /// </summary>
        [Fact]
        public void Info_OnInitMethod_ShouldExistAndBeCallable()
        {
            Info info = new Info();

            info.OnInit(null!);
        }

        /// <summary>
        ///     Tests that Info implements expected interfaces
        /// </summary>
        [Fact]
        public void Info_ShouldImplementExpectedInterfaces()
        {
            Info info = new Info();

            Assert.IsAssignableFrom<IOnInit>(info);
            Assert.IsAssignableFrom<IOnUpdate>(info);
        }

        /// <summary>
        ///     Tests that all properties can be set independently
        /// </summary>
        [Fact]
        public void Info_AllProperties_ShouldBeSetIndependently()
        {
            Info info = new Info();

            info.Id = 100;
            Assert.Equal(100, info.Id);

            info.IsActive = false;
            Assert.False(info.IsActive);

            info.IsStatic = true;
            Assert.True(info.IsStatic);

            info.Name = "MyEntity";
            Assert.Equal("MyEntity", info.Name);

            info.Tag = "Enemy";
            Assert.Equal("Enemy", info.Tag);
        }
    }
}

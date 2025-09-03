using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    public class ObjectBaseTests
    {
        private class TestObject : ObjectBase
        {
            public bool DestroyCalled { get; private set; }
            public TestObject(IntPtr ptr) : base(ptr) { }
            public override void Destroy(bool disposing)
            {
                DestroyCalled = true;
            }
        }

        [Fact]
        public void Constructor_SetsCPointer()
        {
            IntPtr ptr = new IntPtr(1234);
            TestObject obj = new TestObject(ptr);
            Assert.Equal(ptr, obj.CPointer);
        }

        [Fact]
        public void Dispose_CallsDestroyAndSetsCPointerToZero()
        {
            IntPtr ptr = new IntPtr(5678);
            TestObject obj = new TestObject(ptr);
            obj.Dispose();
            Assert.True(obj.DestroyCalled);
            Assert.Equal(IntPtr.Zero, obj.CPointer);
        }
    }
}


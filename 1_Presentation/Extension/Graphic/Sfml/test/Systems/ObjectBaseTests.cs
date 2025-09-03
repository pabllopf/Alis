using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    /// <summary>
    /// The object base tests class
    /// </summary>
    public class ObjectBaseTests
    {
        /// <summary>
        /// The test object class
        /// </summary>
        /// <seealso cref="ObjectBase"/>
        private class TestObject : ObjectBase
        {
            /// <summary>
            /// Gets or sets the value of the destroy called
            /// </summary>
            public bool DestroyCalled { get; private set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="TestObject"/> class
            /// </summary>
            /// <param name="ptr">The ptr</param>
            public TestObject(IntPtr ptr) : base(ptr) { }
            /// <summary>
            /// Destroys the disposing
            /// </summary>
            /// <param name="disposing">The disposing</param>
            public override void Destroy(bool disposing)
            {
                DestroyCalled = true;
            }
        }

        /// <summary>
        /// Tests that constructor sets c pointer
        /// </summary>
        [Fact]
        public void Constructor_SetsCPointer()
        {
            IntPtr ptr = new IntPtr(1234);
            TestObject obj = new TestObject(ptr);
            Assert.Equal(ptr, obj.CPointer);
        }

        /// <summary>
        /// Tests that dispose calls destroy and sets c pointer to zero
        /// </summary>
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


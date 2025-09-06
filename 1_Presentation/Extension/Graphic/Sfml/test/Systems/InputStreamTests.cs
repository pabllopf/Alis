using System;
using Xunit;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Test.Systems
{
    public class InputStreamTests
    {
        [Fact]
        public void CanAssignAndInvokeCallbacks()
        {
            InputStream inputStream = new InputStream();
            bool readCalled = false, seekCalled = false, tellCalled = false, getSizeCalled = false;
            inputStream.Read = (data, size, userData) => { readCalled = true; return 0; };
            inputStream.Seek = (position, userData) => { seekCalled = true; return 0; };
            inputStream.Tell = (userData) => { tellCalled = true; return 0; };
            inputStream.GetSize = (userData) => { getSizeCalled = true; return 0; };
            inputStream.Read(IntPtr.Zero, 0, IntPtr.Zero);
            inputStream.Seek(0, IntPtr.Zero);
            inputStream.Tell(IntPtr.Zero);
            inputStream.GetSize(IntPtr.Zero);
            Assert.True(readCalled);
            Assert.True(seekCalled);
            Assert.True(tellCalled);
            Assert.True(getSizeCalled);
        }
    }
}


using System;
using Veldrid.MetalBindings;

namespace Veldrid.MTL
{
    /// <summary>
    /// The mtl buffer class
    /// </summary>
    /// <seealso cref="DeviceBuffer"/>
    internal class MTLBuffer : DeviceBuffer
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets the value of the size in bytes
        /// </summary>
        public override uint SizeInBytes { get; }
        /// <summary>
        /// Gets the value of the usage
        /// </summary>
        public override BufferUsage Usage { get; }

        /// <summary>
        /// Gets the value of the actual capacity
        /// </summary>
        public uint ActualCapacity { get; }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                NSString nameNSS = NSString.New(value);
                DeviceBuffer.addDebugMarker(nameNSS, new NSRange(0, SizeInBytes));
                ObjectiveCRuntime.release(nameNSS.NativePtr);
                _name = value;
            }
        }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Gets or sets the value of the device buffer
        /// </summary>
        public MetalBindings.MTLBuffer DeviceBuffer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLBuffer"/> class
        /// </summary>
        /// <param name="bd">The bd</param>
        /// <param name="gd">The gd</param>
        public MTLBuffer(ref BufferDescription bd, MTLGraphicsDevice gd)
        {
            SizeInBytes = bd.SizeInBytes;
            uint roundFactor = (4 - (SizeInBytes % 4)) % 4;
            ActualCapacity = SizeInBytes + roundFactor;
            Usage = bd.Usage;
            DeviceBuffer = gd.Device.newBufferWithLengthOptions(
                (UIntPtr)ActualCapacity,
                0);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                ObjectiveCRuntime.release(DeviceBuffer.NativePtr);
            }
        }
    }
}

using System;
using Vortice.Direct3D11;
using System.Collections.Generic;
using Vortice.DXGI;
using Vortice.Direct3D;

namespace Veldrid.D3D11
{
    /// <summary>
    /// The 11 buffer class
    /// </summary>
    /// <seealso cref="DeviceBuffer"/>
    internal class D3D11Buffer : DeviceBuffer
    {
        /// <summary>
        /// The device
        /// </summary>
        private readonly ID3D11Device _device;
        /// <summary>
        /// The buffer
        /// </summary>
        private readonly ID3D11Buffer _buffer;
        /// <summary>
        /// The access view lock
        /// </summary>
        private readonly object _accessViewLock = new object();
        /// <summary>
        /// The id 11 shader resource view
        /// </summary>
        private readonly Dictionary<OffsetSizePair, ID3D11ShaderResourceView> _srvs
            = new Dictionary<OffsetSizePair, ID3D11ShaderResourceView>();
        /// <summary>
        /// The id 11 unordered access view
        /// </summary>
        private readonly Dictionary<OffsetSizePair, ID3D11UnorderedAccessView> _uavs
            = new Dictionary<OffsetSizePair, ID3D11UnorderedAccessView>();
        /// <summary>
        /// The structure byte stride
        /// </summary>
        private readonly uint _structureByteStride;
        /// <summary>
        /// The raw buffer
        /// </summary>
        private readonly bool _rawBuffer;
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the size in bytes
        /// </summary>
        public override uint SizeInBytes { get; }

        /// <summary>
        /// Gets the value of the usage
        /// </summary>
        public override BufferUsage Usage { get; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _buffer.NativePointer == IntPtr.Zero;

        /// <summary>
        /// Gets the value of the buffer
        /// </summary>
        public ID3D11Buffer Buffer => _buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Buffer"/> class
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <param name="usage">The usage</param>
        /// <param name="structureByteStride">The structure byte stride</param>
        /// <param name="rawBuffer">The raw buffer</param>
        public D3D11Buffer(ID3D11Device device, uint sizeInBytes, BufferUsage usage, uint structureByteStride, bool rawBuffer)
        {
            _device = device;
            SizeInBytes = sizeInBytes;
            Usage = usage;
            _structureByteStride = structureByteStride;
            _rawBuffer = rawBuffer;

            Vortice.Direct3D11.BufferDescription bd = new Vortice.Direct3D11.BufferDescription(
                (int)sizeInBytes,
                D3D11Formats.VdToD3D11BindFlags(usage),
                ResourceUsage.Default);
            if ((usage & BufferUsage.StructuredBufferReadOnly) == BufferUsage.StructuredBufferReadOnly
                || (usage & BufferUsage.StructuredBufferReadWrite) == BufferUsage.StructuredBufferReadWrite)
            {
                if (rawBuffer)
                {
                    bd.MiscFlags = ResourceOptionFlags.BufferAllowRawViews;
                }
                else
                {
                    bd.MiscFlags = ResourceOptionFlags.BufferStructured;
                    bd.StructureByteStride = (int)structureByteStride;
                }
            }
            if ((usage & BufferUsage.IndirectBuffer) == BufferUsage.IndirectBuffer)
            {
                bd.MiscFlags = ResourceOptionFlags.DrawIndirectArguments;
            }

            if ((usage & BufferUsage.Dynamic) == BufferUsage.Dynamic)
            {
                bd.Usage = ResourceUsage.Dynamic;
                bd.CPUAccessFlags = CpuAccessFlags.Write;
            }
            else if ((usage & BufferUsage.Staging) == BufferUsage.Staging)
            {
                bd.Usage = ResourceUsage.Staging;
                bd.CPUAccessFlags = CpuAccessFlags.Read | CpuAccessFlags.Write;
            }

            _buffer = device.CreateBuffer(bd);
        }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
                Buffer.DebugName = value;
                foreach (KeyValuePair<OffsetSizePair, ID3D11ShaderResourceView> kvp in _srvs)
                {
                    kvp.Value.DebugName = value + "_SRV";
                }
                foreach (KeyValuePair<OffsetSizePair, ID3D11UnorderedAccessView> kvp in _uavs)
                {
                    kvp.Value.DebugName = value + "_UAV";
                }
            }
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            foreach (KeyValuePair<OffsetSizePair, ID3D11ShaderResourceView> kvp in _srvs)
            {
                kvp.Value.Dispose();
            }
            foreach (KeyValuePair<OffsetSizePair, ID3D11UnorderedAccessView> kvp in _uavs)
            {
                kvp.Value.Dispose();
            }
            _buffer.Dispose();
        }

        /// <summary>
        /// Gets the shader resource view using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        /// <returns>The id 11 shader resource view</returns>
        internal ID3D11ShaderResourceView GetShaderResourceView(uint offset, uint size)
        {
            lock (_accessViewLock)
            {
                OffsetSizePair pair = new OffsetSizePair(offset, size);
                if (!_srvs.TryGetValue(pair, out ID3D11ShaderResourceView srv))
                {
                    srv = CreateShaderResourceView(offset, size);
                    _srvs.Add(pair, srv);
                }

                return srv;
            }
        }

        /// <summary>
        /// Gets the unordered access view using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        /// <returns>The id 11 unordered access view</returns>
        internal ID3D11UnorderedAccessView GetUnorderedAccessView(uint offset, uint size)
        {
            lock (_accessViewLock)
            {
                OffsetSizePair pair = new OffsetSizePair(offset, size);
                if (!_uavs.TryGetValue(pair, out ID3D11UnorderedAccessView uav))
                {
                    uav = CreateUnorderedAccessView(offset, size);
                    _uavs.Add(pair, uav);
                }

                return uav;
            }
        }

        /// <summary>
        /// Creates the shader resource view using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        /// <returns>The id 11 shader resource view</returns>
        private ID3D11ShaderResourceView CreateShaderResourceView(uint offset, uint size)
        {
            if (_rawBuffer)
            {
                ShaderResourceViewDescription srvDesc = new ShaderResourceViewDescription(_buffer,
                    Format.R32_Typeless,
                    (int)offset / 4,
                    (int)size / 4,
                    BufferExtendedShaderResourceViewFlags.Raw);

                return _device.CreateShaderResourceView(_buffer, srvDesc);
            }
            else
            {
                ShaderResourceViewDescription srvDesc = new ShaderResourceViewDescription
                {
                    ViewDimension = ShaderResourceViewDimension.Buffer
                };
                srvDesc.Buffer.NumElements = (int)(size / _structureByteStride);
                srvDesc.Buffer.ElementOffset = (int)(offset / _structureByteStride);
                return _device.CreateShaderResourceView(_buffer, srvDesc);
            }
        }

        /// <summary>
        /// Creates the unordered access view using the specified offset
        /// </summary>
        /// <param name="offset">The offset</param>
        /// <param name="size">The size</param>
        /// <returns>The id 11 unordered access view</returns>
        private ID3D11UnorderedAccessView CreateUnorderedAccessView(uint offset, uint size)
        {
            if (_rawBuffer)
            {
                UnorderedAccessViewDescription uavDesc = new UnorderedAccessViewDescription(_buffer,
                    Format.R32_Typeless,
                    (int)offset / 4,
                    (int)size / 4,
                    BufferUnorderedAccessViewFlags.Raw);

                return _device.CreateUnorderedAccessView(_buffer, uavDesc);
            }
            else
            {
                UnorderedAccessViewDescription uavDesc = new UnorderedAccessViewDescription(_buffer,
                    Format.Unknown,
                    (int)(offset / _structureByteStride),
                    (int)(size / _structureByteStride)
                    );

                return _device.CreateUnorderedAccessView(_buffer, uavDesc);
            }
        }

        /// <summary>
        /// The offset size pair
        /// </summary>
        private struct OffsetSizePair : IEquatable<OffsetSizePair>
        {
            /// <summary>
            /// The offset
            /// </summary>
            public readonly uint Offset;
            /// <summary>
            /// The size
            /// </summary>
            public readonly uint Size;

            /// <summary>
            /// Initializes a new instance of the <see cref="OffsetSizePair"/> class
            /// </summary>
            /// <param name="offset">The offset</param>
            /// <param name="size">The size</param>
            public OffsetSizePair(uint offset, uint size)
            {
                Offset = offset;
                Size = size;
            }

            /// <summary>
            /// Describes whether this instance equals
            /// </summary>
            /// <param name="other">The other</param>
            /// <returns>The bool</returns>
            public bool Equals(OffsetSizePair other) => Offset.Equals(other.Offset) && Size.Equals(other.Size);
            /// <summary>
            /// Gets the hash code
            /// </summary>
            /// <returns>The int</returns>
            public override int GetHashCode() => HashHelper.Combine(Offset.GetHashCode(), Size.GetHashCode());
        }
    }
}

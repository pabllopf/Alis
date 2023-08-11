using System;
using static Veldrid.OpenGLBinding.OpenGLNative;
using static Veldrid.OpenGL.OpenGLUtil;
using Veldrid.OpenGLBinding;
using System.Diagnostics;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl buffer class
    /// </summary>
    /// <seealso cref="DeviceBuffer"/>
    /// <seealso cref="OpenGLDeferredResource"/>
    internal unsafe class OpenGLBuffer : DeviceBuffer, OpenGLDeferredResource
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The buffer
        /// </summary>
        private uint _buffer;
        /// <summary>
        /// The dynamic
        /// </summary>
        private bool _dynamic;
        /// <summary>
        /// The dispose requested
        /// </summary>
        private bool _disposeRequested;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The name changed
        /// </summary>
        private bool _nameChanged;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get => _name; set { _name = value; _nameChanged = true; } }

        /// <summary>
        /// Gets the value of the size in bytes
        /// </summary>
        public override uint SizeInBytes { get; }
        /// <summary>
        /// Gets the value of the usage
        /// </summary>
        public override BufferUsage Usage { get; }

        /// <summary>
        /// Gets the value of the buffer
        /// </summary>
        public uint Buffer => _buffer;

        /// <summary>
        /// Gets or sets the value of the created
        /// </summary>
        public bool Created { get; private set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposeRequested;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLBuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="sizeInBytes">The size in bytes</param>
        /// <param name="usage">The usage</param>
        public OpenGLBuffer(OpenGLGraphicsDevice gd, uint sizeInBytes, BufferUsage usage)
        {
            _gd = gd;
            SizeInBytes = sizeInBytes;
            _dynamic = (usage & BufferUsage.Dynamic) == BufferUsage.Dynamic;
            Usage = usage;
        }

        /// <summary>
        /// Ensures the resources created
        /// </summary>
        public void EnsureResourcesCreated()
        {
            if (!Created)
            {
                CreateGLResources();
            }
            if (_nameChanged)
            {
                _nameChanged = false;
                if (_gd.Extensions.KHR_Debug)
                {
                    SetObjectLabel(ObjectLabelIdentifier.Buffer, _buffer, _name);
                }
            }
        }

        /// <summary>
        /// Creates the gl resources
        /// </summary>
        public void CreateGLResources()
        {
            Debug.Assert(!Created);

            if (_gd.Extensions.ARB_DirectStateAccess)
            {
                uint buffer;
                glCreateBuffers(1, &buffer);
                CheckLastError();
                _buffer = buffer;

                glNamedBufferData(
                    _buffer,
                    SizeInBytes,
                    null,
                    _dynamic ? BufferUsageHint.DynamicDraw : BufferUsageHint.StaticDraw);
                CheckLastError();
            }
            else
            {
                glGenBuffers(1, out _buffer);
                CheckLastError();

                glBindBuffer(BufferTarget.CopyReadBuffer, _buffer);
                CheckLastError();

                glBufferData(
                    BufferTarget.CopyReadBuffer,
                    (UIntPtr)SizeInBytes,
                    null,
                    _dynamic ? BufferUsageHint.DynamicDraw : BufferUsageHint.StaticDraw);
                CheckLastError();
            }

            Created = true;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposeRequested)
            {
                _disposeRequested = true;
                _gd.EnqueueDisposal(this);
            }
        }

        /// <summary>
        /// Destroys the gl resources
        /// </summary>
        public void DestroyGLResources()
        {
            uint buffer = _buffer;
            glDeleteBuffers(1, ref buffer);
            CheckLastError();
        }
    }
}

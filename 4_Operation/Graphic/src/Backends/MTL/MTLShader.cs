using System;
using System.Text;
using Alis.Core.Graphic.Backends.Metal;

namespace Alis.Core.Graphic.Backends.MTL
{
    /// <summary>
    /// The mtl shader class
    /// </summary>
    /// <seealso cref="Shader"/>
    internal class MTLShader : Shader
    {
        /// <summary>
        /// The device
        /// </summary>
        private readonly MTLGraphicsDevice _device;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets or sets the value of the library
        /// </summary>
        public MTLLibrary Library { get; private set; }
        /// <summary>
        /// Gets or sets the value of the function
        /// </summary>
        public MTLFunction Function { get; private set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Gets the value of the has function constants
        /// </summary>
        public bool HasFunctionConstants { get; }
        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MTLShader"/> class
        /// </summary>
        /// <param name="description">The description</param>
        /// <param name="gd">The gd</param>
        /// <exception cref="VeldridException">Failed to create Metal {description.Stage} Shader. The given entry point \"{description.EntryPoint}\" was not found.</exception>
        public unsafe MTLShader(ref ShaderDescription description, MTLGraphicsDevice gd)
            : base(description.Stage, description.EntryPoint)
        {
            _device = gd;

            if (description.ShaderBytes.Length > 4
                && description.ShaderBytes[0] == 0x4d
                && description.ShaderBytes[1] == 0x54
                && description.ShaderBytes[2] == 0x4c
                && description.ShaderBytes[3] == 0x42)
            {
                DispatchQueue queue = Dispatch.dispatch_get_global_queue(QualityOfServiceLevel.QOS_CLASS_USER_INTERACTIVE, 0);
                fixed (byte* shaderBytesPtr = description.ShaderBytes)
                {
                    DispatchData dispatchData = Dispatch.dispatch_data_create(
                        shaderBytesPtr,
                        (UIntPtr)description.ShaderBytes.Length,
                        queue,
                        IntPtr.Zero);
                    try
                    {
                        Library = gd.Device.newLibraryWithData(dispatchData);
                    }
                    finally
                    {
                        Dispatch.dispatch_release(dispatchData.NativePtr);
                    }
                }
            }
            else
            {
                string source = Encoding.UTF8.GetString(description.ShaderBytes);
                MTLCompileOptions compileOptions = MTLCompileOptions.New();
                Library = gd.Device.newLibraryWithSource(source, compileOptions);
                ObjectiveCRuntime.release(compileOptions);
            }

            Function = Library.newFunctionWithName(description.EntryPoint);
            if (Function.NativePtr == IntPtr.Zero)
            {
                throw new VeldridException(
                    $"Failed to create Metal {description.Stage} Shader. The given entry point \"{description.EntryPoint}\" was not found.");
            }

            HasFunctionConstants = Function.functionConstantsDictionary.count != UIntPtr.Zero;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                ObjectiveCRuntime.release(Function.NativePtr);
                ObjectiveCRuntime.release(Library.NativePtr);
            }
        }
    }
}

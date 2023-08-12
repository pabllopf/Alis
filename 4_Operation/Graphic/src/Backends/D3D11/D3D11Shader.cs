using System;
using System.Text;
using Vortice.D3DCompiler;
using Vortice.Direct3D;
using Vortice.Direct3D11;

namespace Alis.Core.Graphic.Backends.D3D11
{
    /// <summary>
    /// The 11 shader class
    /// </summary>
    /// <seealso cref="Shader"/>
    internal class D3D11Shader : Shader
    {
        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Gets the value of the device shader
        /// </summary>
        public ID3D11DeviceChild DeviceShader { get; }
        /// <summary>
        /// Gets or sets the value of the bytecode
        /// </summary>
        public byte[] Bytecode { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Shader"/> class
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="description">The description</param>
        public D3D11Shader(ID3D11Device device, ShaderDescription description)
            : base(description.Stage, description.EntryPoint)
        {
            if (description.ShaderBytes.Length > 4
                && description.ShaderBytes[0] == 0x44
                && description.ShaderBytes[1] == 0x58
                && description.ShaderBytes[2] == 0x42
                && description.ShaderBytes[3] == 0x43)
            {
                Bytecode = Util.ShallowClone(description.ShaderBytes);
            }
            else
            {
                Bytecode = CompileCode(description);
            }

            switch (description.Stage)
            {
                case ShaderStages.Vertex:
                    DeviceShader = device.CreateVertexShader(Bytecode);
                    break;
                case ShaderStages.Geometry:
                    DeviceShader = device.CreateGeometryShader(Bytecode);
                    break;
                case ShaderStages.TessellationControl:
                    DeviceShader = device.CreateHullShader(Bytecode);
                    break;
                case ShaderStages.TessellationEvaluation:
                    DeviceShader = device.CreateDomainShader(Bytecode);
                    break;
                case ShaderStages.Fragment:
                    DeviceShader = device.CreatePixelShader(Bytecode);
                    break;
                case ShaderStages.Compute:
                    DeviceShader = device.CreateComputeShader(Bytecode);
                    break;
                default:
                    throw Illegal.Value<ShaderStages>();
            }
        }

        /// <summary>
        /// Compiles the code using the specified description
        /// </summary>
        /// <param name="description">The description</param>
        /// <exception cref="VeldridException">Failed to compile HLSL code: {Encoding.ASCII.GetString(error.AsBytes())}</exception>
        /// <returns>The byte array</returns>
        private byte[] CompileCode(ShaderDescription description)
        {
            string profile;
            switch (description.Stage)
            {
                case ShaderStages.Vertex:
                    profile = "vs_5_0";
                    break;
                case ShaderStages.Geometry:
                    profile = "gs_5_0";
                    break;
                case ShaderStages.TessellationControl:
                    profile = "hs_5_0";
                    break;
                case ShaderStages.TessellationEvaluation:
                    profile = "ds_5_0";
                    break;
                case ShaderStages.Fragment:
                    profile = "ps_5_0";
                    break;
                case ShaderStages.Compute:
                    profile = "cs_5_0";
                    break;
                default:
                    throw Illegal.Value<ShaderStages>();
            }

            ShaderFlags flags = description.Debug ? ShaderFlags.Debug : ShaderFlags.OptimizationLevel3;
            Compiler.Compile(description.ShaderBytes, null, null,
                             description.EntryPoint, null,
                             profile, flags, out Blob result, out Blob error);

            if (result == null)
            {
                throw new VeldridException($"Failed to compile HLSL code: {Encoding.ASCII.GetString(error.AsBytes())}");
            }

            return result.AsBytes();
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
                DeviceShader.DebugName = value;
            }
        }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => DeviceShader.NativePointer == IntPtr.Zero;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public override void Dispose()
        {
            DeviceShader.Dispose();
        }
    }
}

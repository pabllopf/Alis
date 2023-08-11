using static Veldrid.OpenGLBinding.OpenGLNative;
using static Veldrid.OpenGL.OpenGLUtil;
using Veldrid.OpenGLBinding;
using System.Text;
using System;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl shader class
    /// </summary>
    /// <seealso cref="Shader"/>
    /// <seealso cref="OpenGLDeferredResource"/>
    internal unsafe class OpenGLShader : Shader, OpenGLDeferredResource
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The shader type
        /// </summary>
        private readonly ShaderType _shaderType;
        /// <summary>
        /// The staging block
        /// </summary>
        private readonly StagingBlock _stagingBlock;

        /// <summary>
        /// The dispose requested
        /// </summary>
        private bool _disposeRequested;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;
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
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposeRequested;

        /// <summary>
        /// The shader
        /// </summary>
        private uint _shader;

        /// <summary>
        /// Gets the value of the shader
        /// </summary>
        public uint Shader => _shader;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLShader"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="stage">The stage</param>
        /// <param name="stagingBlock">The staging block</param>
        /// <param name="entryPoint">The entry point</param>
        public OpenGLShader(OpenGLGraphicsDevice gd, ShaderStages stage, StagingBlock stagingBlock, string entryPoint)
            : base(stage, entryPoint)
        {
#if VALIDATE_USAGE
            if (stage == ShaderStages.Compute && !gd.Extensions.ComputeShaders)
            {
                if (_gd.BackendType == GraphicsBackend.OpenGLES)
                {
                    throw new VeldridException("Compute shaders require OpenGL ES 3.1.");
                }
                else
                {
                    throw new VeldridException($"Compute shaders require OpenGL 4.3 or ARB_compute_shader.");
                }
            }
#endif
            _gd = gd;
            _shaderType = OpenGLFormats.VdToGLShaderType(stage);
            _stagingBlock = stagingBlock;
        }

        /// <summary>
        /// Gets or sets the value of the created
        /// </summary>
        public bool Created { get; private set; }

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
                    SetObjectLabel(ObjectLabelIdentifier.Shader, _shader, _name);
                }
            }
        }

        /// <summary>
        /// Creates the gl resources
        /// </summary>
        /// <exception cref="VeldridException">Unable to compile shader code for shader [{_name}] of type {_shaderType}: {message}</exception>
        private void CreateGLResources()
        {
            _shader = glCreateShader(_shaderType);
            CheckLastError();

            byte* textPtr = (byte*)_stagingBlock.Data;
            int length = (int)_stagingBlock.SizeInBytes;
            byte** textsPtr = &textPtr;

            glShaderSource(_shader, 1, textsPtr, &length);
            CheckLastError();

            glCompileShader(_shader);
            CheckLastError();

            int compileStatus;
            glGetShaderiv(_shader, ShaderParameter.CompileStatus, &compileStatus);
            CheckLastError();

            if (compileStatus != 1)
            {
                int infoLogLength;
                glGetShaderiv(_shader, ShaderParameter.InfoLogLength, &infoLogLength);
                CheckLastError();

                byte* infoLog = stackalloc byte[infoLogLength];
                uint returnedInfoLength;
                glGetShaderInfoLog(_shader, (uint)infoLogLength, &returnedInfoLength, infoLog);
                CheckLastError();

                string message = infoLog != null
                    ? Encoding.UTF8.GetString(infoLog, (int)returnedInfoLength)
                    : "<null>";

                throw new VeldridException($"Unable to compile shader code for shader [{_name}] of type {_shaderType}: {message}");
            }

            _gd.StagingMemoryPool.Free(_stagingBlock);
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
            if (!_disposed)
            {
                _disposed = true;
                if (Created)
                {
                    glDeleteShader(_shader);
                    CheckLastError();
                }
                else
                {
                    _gd.StagingMemoryPool.Free(_stagingBlock);
                }
            }
        }
    }
}

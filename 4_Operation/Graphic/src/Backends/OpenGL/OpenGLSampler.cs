using static Veldrid.OpenGLBinding.OpenGLNative;
using static Veldrid.OpenGL.OpenGLUtil;
using Veldrid.OpenGLBinding;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl sampler class
    /// </summary>
    /// <seealso cref="Sampler"/>
    /// <seealso cref="OpenGLDeferredResource"/>
    internal unsafe class OpenGLSampler : Sampler, OpenGLDeferredResource
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The description
        /// </summary>
        private readonly SamplerDescription _description;
        /// <summary>
        /// The no mipmap state
        /// </summary>
        private readonly InternalSamplerState _noMipmapState;
        /// <summary>
        /// The mipmap state
        /// </summary>
        private readonly InternalSamplerState _mipmapState;
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
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposeRequested;

        /// <summary>
        /// Gets the value of the no mipmap sampler
        /// </summary>
        public uint NoMipmapSampler => _noMipmapState.Sampler;
        /// <summary>
        /// Gets the value of the mipmap sampler
        /// </summary>
        public uint MipmapSampler => _mipmapState.Sampler;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLSampler"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public OpenGLSampler(OpenGLGraphicsDevice gd, ref SamplerDescription description)
        {
            _gd = gd;
            _description = description;

            _mipmapState = new InternalSamplerState();
            _noMipmapState = new InternalSamplerState();
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
                    SetObjectLabel(ObjectLabelIdentifier.Sampler, _noMipmapState.Sampler, string.Format("{0}_WithoutMipmapping", _name));
                    SetObjectLabel(ObjectLabelIdentifier.Sampler, _mipmapState.Sampler, string.Format("{0}_WithMipmapping", _name));
                }
            }
        }

        /// <summary>
        /// Creates the gl resources
        /// </summary>
        private void CreateGLResources()
        {
            GraphicsBackend backendType = _gd.BackendType;
            _noMipmapState.CreateGLResources(_description, false, backendType);
            _mipmapState.CreateGLResources(_description, true, backendType);
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
            _mipmapState.DestroyGLResources();
            _noMipmapState.DestroyGLResources();
        }

        /// <summary>
        /// The internal sampler state class
        /// </summary>
        private class InternalSamplerState
        {
            /// <summary>
            /// The sampler
            /// </summary>
            private uint _sampler;

            /// <summary>
            /// Gets the value of the sampler
            /// </summary>
            public uint Sampler => _sampler;

            /// <summary>
            /// Creates the gl resources using the specified description
            /// </summary>
            /// <param name="description">The description</param>
            /// <param name="mipmapped">The mipmapped</param>
            /// <param name="backend">The backend</param>
            public void CreateGLResources(SamplerDescription description, bool mipmapped, GraphicsBackend backend)
            {
                glGenSamplers(1, out _sampler);
                CheckLastError();

                glSamplerParameteri(_sampler, SamplerParameterName.TextureWrapS, (int)OpenGLFormats.VdToGLTextureWrapMode(description.AddressModeU));
                CheckLastError();
                glSamplerParameteri(_sampler, SamplerParameterName.TextureWrapT, (int)OpenGLFormats.VdToGLTextureWrapMode(description.AddressModeV));
                CheckLastError();
                glSamplerParameteri(_sampler, SamplerParameterName.TextureWrapR, (int)OpenGLFormats.VdToGLTextureWrapMode(description.AddressModeW));
                CheckLastError();

                if (description.AddressModeU == SamplerAddressMode.Border
                    || description.AddressModeV == SamplerAddressMode.Border
                    || description.AddressModeW == SamplerAddressMode.Border)
                {
                    RgbaFloat borderColor = ToRgbaFloat(description.BorderColor);
                    glSamplerParameterfv(_sampler, SamplerParameterName.TextureBorderColor, (float*)&borderColor);
                    CheckLastError();
                }

                glSamplerParameterf(_sampler, SamplerParameterName.TextureMinLod, description.MinimumLod);
                CheckLastError();
                glSamplerParameterf(_sampler, SamplerParameterName.TextureMaxLod, description.MaximumLod);
                CheckLastError();
                if (backend == GraphicsBackend.OpenGL && description.LodBias != 0)
                {
                    glSamplerParameterf(_sampler, SamplerParameterName.TextureLodBias, description.LodBias);
                    CheckLastError();
                }

                if (description.Filter == SamplerFilter.Anisotropic)
                {
                    glSamplerParameterf(_sampler, SamplerParameterName.TextureMaxAnisotropyExt, description.MaximumAnisotropy);
                    CheckLastError();
                    glSamplerParameteri(_sampler, SamplerParameterName.TextureMinFilter, mipmapped ? (int)TextureMinFilter.LinearMipmapLinear : (int)TextureMinFilter.Linear);
                    CheckLastError();
                    glSamplerParameteri(_sampler, SamplerParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                    CheckLastError();
                }
                else
                {
                    OpenGLFormats.VdToGLTextureMinMagFilter(description.Filter, mipmapped, out TextureMinFilter min, out TextureMagFilter mag);
                    glSamplerParameteri(_sampler, SamplerParameterName.TextureMinFilter, (int)min);
                    CheckLastError();
                    glSamplerParameteri(_sampler, SamplerParameterName.TextureMagFilter, (int)mag);
                    CheckLastError();
                }

                if (description.ComparisonKind != null)
                {
                    glSamplerParameteri(_sampler, SamplerParameterName.TextureCompareMode, (int)TextureCompareMode.CompareRefToTexture);
                    CheckLastError();
                    glSamplerParameteri(_sampler, SamplerParameterName.TextureCompareFunc, (int)OpenGLFormats.VdToGLDepthFunction(description.ComparisonKind.Value));
                    CheckLastError();
                }
            }

            /// <summary>
            /// Destroys the gl resources
            /// </summary>
            public void DestroyGLResources()
            {
                glDeleteSamplers(1, ref _sampler);
                CheckLastError();
            }

            /// <summary>
            /// Returns the rgba float using the specified border color
            /// </summary>
            /// <param name="borderColor">The border color</param>
            /// <returns>The rgba float</returns>
            private RgbaFloat ToRgbaFloat(SamplerBorderColor borderColor)
            {
                switch (borderColor)
                {
                    case SamplerBorderColor.TransparentBlack:
                        return new RgbaFloat(0, 0, 0, 0);
                    case SamplerBorderColor.OpaqueBlack:
                        return new RgbaFloat(0, 0, 0, 1);
                    case SamplerBorderColor.OpaqueWhite:
                        return new RgbaFloat(1, 1, 1, 1);
                    default:
                        throw Illegal.Value<SamplerBorderColor>();
                }
            }
        }
    }
}

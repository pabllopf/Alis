using static Veldrid.OpenGLBinding.OpenGLNative;
using static Veldrid.OpenGL.OpenGLUtil;
using Veldrid.OpenGLBinding;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl framebuffer class
    /// </summary>
    /// <seealso cref="Framebuffer"/>
    /// <seealso cref="OpenGLDeferredResource"/>
    internal unsafe class OpenGLFramebuffer : Framebuffer, OpenGLDeferredResource
    {
        /// <summary>
        /// The gd
        /// </summary>
        private readonly OpenGLGraphicsDevice _gd;
        /// <summary>
        /// The framebuffer
        /// </summary>
        private uint _framebuffer;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;
        /// <summary>
        /// The name changed
        /// </summary>
        private bool _nameChanged;
        /// <summary>
        /// The dispose requested
        /// </summary>
        private bool _disposeRequested;
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public override string Name { get => _name; set { _name = value; _nameChanged = true; } }

        /// <summary>
        /// Gets the value of the framebuffer
        /// </summary>
        public uint Framebuffer => _framebuffer;

        /// <summary>
        /// Gets or sets the value of the created
        /// </summary>
        public bool Created { get; private set; }

        /// <summary>
        /// Gets the value of the is disposed
        /// </summary>
        public override bool IsDisposed => _disposeRequested;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLFramebuffer"/> class
        /// </summary>
        /// <param name="gd">The gd</param>
        /// <param name="description">The description</param>
        public OpenGLFramebuffer(OpenGLGraphicsDevice gd, ref FramebufferDescription description)
            : base(description.DepthTarget, description.ColorTargets)
        {
            _gd = gd;
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
                    SetObjectLabel(ObjectLabelIdentifier.Framebuffer, _framebuffer, _name);
                }
            }
        }

        /// <summary>
        /// Creates the gl resources
        /// </summary>
        /// <exception cref="VeldridException"></exception>
        public void CreateGLResources()
        {
            glGenFramebuffers(1, out _framebuffer);
            CheckLastError();

            glBindFramebuffer(FramebufferTarget.Framebuffer, _framebuffer);
            CheckLastError();

            uint colorCount = (uint)ColorTargets.Count;

            if (colorCount > 0)
            {
                for (int i = 0; i < colorCount; i++)
                {
                    FramebufferAttachment colorAttachment = ColorTargets[i];
                    OpenGLTexture glTex = Util.AssertSubtype<Texture, OpenGLTexture>(colorAttachment.Target);
                    glTex.EnsureResourcesCreated();

                    _gd.TextureSamplerManager.SetTextureTransient(glTex.TextureTarget, glTex.Texture);
                    CheckLastError();

                    TextureTarget textureTarget = GetTextureTarget (glTex, colorAttachment.ArrayLayer);

                    if (glTex.ArrayLayers == 1)
                    {
                        glFramebufferTexture2D(
                            FramebufferTarget.Framebuffer,
                            GLFramebufferAttachment.ColorAttachment0 + i,
                            textureTarget,
                            glTex.Texture,
                            (int)colorAttachment.MipLevel);
                        CheckLastError();
                    }
                    else
                    {
                        glFramebufferTextureLayer(
                            FramebufferTarget.Framebuffer,
                            GLFramebufferAttachment.ColorAttachment0 + i,
                            (uint)glTex.Texture,
                            (int)colorAttachment.MipLevel,
                            (int)colorAttachment.ArrayLayer);
                        CheckLastError();
                    }
                }

                DrawBuffersEnum* bufs = stackalloc DrawBuffersEnum[(int)colorCount];
                for (int i = 0; i < colorCount; i++)
                {
                    bufs[i] = DrawBuffersEnum.ColorAttachment0 + i;
                }
                glDrawBuffers(colorCount, bufs);
                CheckLastError();
            }

            uint depthTextureID = 0;
            TextureTarget depthTarget = TextureTarget.Texture2D;
            if (DepthTarget != null)
            {
                OpenGLTexture glDepthTex = Util.AssertSubtype<Texture, OpenGLTexture>(DepthTarget.Value.Target);
                glDepthTex.EnsureResourcesCreated();
                depthTarget = glDepthTex.TextureTarget;

                depthTextureID = glDepthTex.Texture;

                _gd.TextureSamplerManager.SetTextureTransient(depthTarget, glDepthTex.Texture);
                CheckLastError();

                depthTarget = GetTextureTarget (glDepthTex, DepthTarget.Value.ArrayLayer);

                GLFramebufferAttachment framebufferAttachment = GLFramebufferAttachment.DepthAttachment;
                if (FormatHelpers.IsStencilFormat(glDepthTex.Format))
                {
                    framebufferAttachment = GLFramebufferAttachment.DepthStencilAttachment;
                }

                if (glDepthTex.ArrayLayers == 1)
                {
                    glFramebufferTexture2D(
                        FramebufferTarget.Framebuffer,
                        framebufferAttachment,
                        depthTarget,
                        depthTextureID,
                        (int)DepthTarget.Value.MipLevel);
                    CheckLastError();
                }
                else
                {
                    glFramebufferTextureLayer(
                        FramebufferTarget.Framebuffer,
                        framebufferAttachment,
                        glDepthTex.Texture,
                        (int)DepthTarget.Value.MipLevel,
                        (int)DepthTarget.Value.ArrayLayer);
                    CheckLastError();
                }

            }

            FramebufferErrorCode errorCode = glCheckFramebufferStatus(FramebufferTarget.Framebuffer);
            CheckLastError();
            if (errorCode != FramebufferErrorCode.FramebufferComplete)
            {
                throw new VeldridException("Framebuffer was not successfully created: " + errorCode);
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
            if (!_disposed)
            {
                _disposed = true;
                uint framebuffer = _framebuffer;
                glDeleteFramebuffers(1, ref framebuffer);
                CheckLastError();
            }
        }
    }
}

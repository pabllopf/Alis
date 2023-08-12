using System;
using static Alis.Core.Graphic.Backends.OpenGL.OpenGLNative;
using static Alis.Core.Graphic.Backends.OpenGL.OpenGLUtil;

namespace Alis.Core.Graphic.Backends.OpenGL
{
    /// <summary>
    /// A utility class managing the relationships between textures, samplers, and their binding locations.
    /// </summary>
    internal unsafe class OpenGLTextureSamplerManager
    {
        /// <summary>
        /// The dsa available
        /// </summary>
        private readonly bool _dsaAvailable;
        /// <summary>
        /// The max texture units
        /// </summary>
        private readonly int _maxTextureUnits;
        /// <summary>
        /// The last texture unit
        /// </summary>
        private readonly uint _lastTextureUnit;
        /// <summary>
        /// The texture unit textures
        /// </summary>
        private readonly OpenGLTextureView[] _textureUnitTextures;
        /// <summary>
        /// The texture unit samplers
        /// </summary>
        private readonly BoundSamplerStateInfo[] _textureUnitSamplers;
        /// <summary>
        /// The current active unit
        /// </summary>
        private uint _currentActiveUnit = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLTextureSamplerManager"/> class
        /// </summary>
        /// <param name="extensions">The extensions</param>
        public OpenGLTextureSamplerManager(OpenGLExtensions extensions)
        {
            _dsaAvailable = extensions.ARB_DirectStateAccess;
            int maxTextureUnits;
            glGetIntegerv(GetPName.MaxCombinedTextureImageUnits, &maxTextureUnits);
            CheckLastError();
            _maxTextureUnits = Math.Max(maxTextureUnits, 8); // OpenGL spec indicates that implementations must support at least 8.
            _textureUnitTextures = new OpenGLTextureView[_maxTextureUnits];
            _textureUnitSamplers = new BoundSamplerStateInfo[_maxTextureUnits];

            _lastTextureUnit = (uint)(_maxTextureUnits - 1);
        }

        /// <summary>
        /// Sets the texture using the specified texture unit
        /// </summary>
        /// <param name="textureUnit">The texture unit</param>
        /// <param name="textureView">The texture view</param>
        public void SetTexture(uint textureUnit, OpenGLTextureView textureView)
        {
            uint textureID = textureView.GLTargetTexture;

            if (_textureUnitTextures[textureUnit] != textureView)
            {
                if (_dsaAvailable)
                {
                    glBindTextureUnit(textureUnit, textureID);
                    CheckLastError();
                }
                else
                {
                    SetActiveTextureUnit(textureUnit);
                    glBindTexture(textureView.TextureTarget, textureID);
                    CheckLastError();
                }

                EnsureSamplerMipmapState(textureUnit, textureView.MipLevels > 1);
                _textureUnitTextures[textureUnit] = textureView;
            }
        }

        /// <summary>
        /// Sets the texture transient using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="texture">The texture</param>
        public void SetTextureTransient(TextureTarget target, uint texture)
        {
            _textureUnitTextures[_lastTextureUnit] = null;
            SetActiveTextureUnit(_lastTextureUnit);
            glBindTexture(target, texture);
            CheckLastError();
        }

        /// <summary>
        /// Sets the sampler using the specified texture unit
        /// </summary>
        /// <param name="textureUnit">The texture unit</param>
        /// <param name="sampler">The sampler</param>
        public void SetSampler(uint textureUnit, OpenGLSampler sampler)
        {
            if (_textureUnitSamplers[textureUnit].Sampler != sampler)
            {
                bool mipmapped = false;
                OpenGLTextureView texBinding = _textureUnitTextures[textureUnit];
                if (texBinding != null)
                {
                    mipmapped = texBinding.MipLevels > 1;
                }

                uint samplerID = mipmapped ? sampler.MipmapSampler : sampler.NoMipmapSampler;
                glBindSampler(textureUnit, samplerID);
                CheckLastError();

                _textureUnitSamplers[textureUnit] = new BoundSamplerStateInfo(sampler, mipmapped);
            }
            else if (_textureUnitTextures[textureUnit] != null)
            {
                EnsureSamplerMipmapState(textureUnit, _textureUnitTextures[textureUnit].MipLevels > 1);
            }
        }

        /// <summary>
        /// Sets the active texture unit using the specified texture unit
        /// </summary>
        /// <param name="textureUnit">The texture unit</param>
        private void SetActiveTextureUnit(uint textureUnit)
        {
            if (_currentActiveUnit != textureUnit)
            {
                glActiveTexture(TextureUnit.Texture0 + (int)textureUnit);
                CheckLastError();
                _currentActiveUnit = textureUnit;
            }
        }

        /// <summary>
        /// Ensures the sampler mipmap state using the specified texture unit
        /// </summary>
        /// <param name="textureUnit">The texture unit</param>
        /// <param name="mipmapped">The mipmapped</param>
        private void EnsureSamplerMipmapState(uint textureUnit, bool mipmapped)
        {
            if (_textureUnitSamplers[textureUnit].Sampler != null && _textureUnitSamplers[textureUnit].Mipmapped != mipmapped)
            {
                OpenGLSampler sampler = _textureUnitSamplers[textureUnit].Sampler;
                uint samplerID = mipmapped ? sampler.MipmapSampler : sampler.NoMipmapSampler;
                glBindSampler(textureUnit, samplerID);
                CheckLastError();

                _textureUnitSamplers[textureUnit].Mipmapped = mipmapped;
            }
        }

        /// <summary>
        /// The bound sampler state info
        /// </summary>
        private struct BoundSamplerStateInfo
        {
            /// <summary>
            /// The sampler
            /// </summary>
            public OpenGLSampler Sampler;
            /// <summary>
            /// The mipmapped
            /// </summary>
            public bool Mipmapped;

            /// <summary>
            /// Initializes a new instance of the <see cref="BoundSamplerStateInfo"/> class
            /// </summary>
            /// <param name="sampler">The sampler</param>
            /// <param name="mipmapped">The mipmapped</param>
            public BoundSamplerStateInfo(OpenGLSampler sampler, bool mipmapped)
            {
                Sampler = sampler;
                Mipmapped = mipmapped;
            }
        }
    }
}

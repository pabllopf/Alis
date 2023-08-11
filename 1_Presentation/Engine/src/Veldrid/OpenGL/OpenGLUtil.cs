using System;
﻿using System.Diagnostics;
using System.Text;
using Veldrid.OpenGLBinding;
using static Veldrid.OpenGLBinding.OpenGLNative;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl util class
    /// </summary>
    internal static class OpenGLUtil
    {
        /// <summary>
        /// The max label length
        /// </summary>
        private static int? MaxLabelLength;

        /// <summary>
        /// Checks the last error
        /// </summary>
        /// <exception cref="VeldridException"></exception>
        [Conditional("DEBUG")]
        [DebuggerNonUserCode]
        internal static void CheckLastError()
        {
            uint error = glGetError();
            if (error != 0)
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw new VeldridException("glGetError indicated an error: " + (ErrorCode)error);
            }
        }

        /// <summary>
        /// Sets the object label using the specified identifier
        /// </summary>
        /// <param name="identifier">The identifier</param>
        /// <param name="target">The target</param>
        /// <param name="name">The name</param>
        internal static unsafe void SetObjectLabel(ObjectLabelIdentifier identifier, uint target, string name)
        {
            if (HasGlObjectLabel)
            {
                int byteCount = Encoding.UTF8.GetByteCount(name);
                if (MaxLabelLength == null)
                {
                    int maxLabelLength = -1;
                    glGetIntegerv(GetPName.MaxLabelLength, &maxLabelLength);
                    CheckLastError();
                    MaxLabelLength = maxLabelLength;
                }
                if (byteCount >= MaxLabelLength)
                {
                    name = name.Substring(0, MaxLabelLength.Value - 4) + "...";
                    byteCount = Encoding.UTF8.GetByteCount(name);
                }

                Span<byte> utf8bytes = stackalloc byte[128];
                if(byteCount + 1 > 128) utf8bytes = new byte[byteCount + 1];

                fixed (char* namePtr = name)
                fixed (byte* utf8bytePtr = utf8bytes)
                {
                    int written = Encoding.UTF8.GetBytes(namePtr, name.Length, utf8bytePtr, byteCount);
                    utf8bytePtr[written] = 0;
                    glObjectLabel(identifier, target, (uint)byteCount, utf8bytePtr);
                    CheckLastError();
                }
            }
        }

        /// <summary>
        /// Gets the texture target using the specified gl tex
        /// </summary>
        /// <param name="glTex">The gl tex</param>
        /// <param name="arrayLayer">The array layer</param>
        /// <returns>The texture target</returns>
        internal static TextureTarget GetTextureTarget(OpenGLTexture glTex, uint arrayLayer)
        {
            if ((glTex.Usage & TextureUsage.Cubemap) == TextureUsage.Cubemap)
            {
                switch (arrayLayer % 6)
                {
                    case 0:
                        return TextureTarget.TextureCubeMapPositiveX;
                    case 1:
                        return TextureTarget.TextureCubeMapNegativeX;
                    case 2:
                        return TextureTarget.TextureCubeMapPositiveY;
                    case 3:
                        return TextureTarget.TextureCubeMapNegativeY;
                    case 4:
                        return TextureTarget.TextureCubeMapPositiveZ;
                    case 5:
                        return TextureTarget.TextureCubeMapNegativeZ;
                }
            }

            return glTex.TextureTarget;
        }
    }
}

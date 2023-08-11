using System.Collections;
using System.Collections.Generic;

namespace Veldrid.OpenGL
{
    /// <summary>
    /// The open gl extensions class
    /// </summary>
    /// <seealso cref="IReadOnlyCollection{string}"/>
    internal class OpenGLExtensions : IReadOnlyCollection<string>
    {
        /// <summary>
        /// The extensions
        /// </summary>
        private readonly HashSet<string> _extensions;
        /// <summary>
        /// The backend
        /// </summary>
        private readonly GraphicsBackend _backend;
        /// <summary>
        /// The major
        /// </summary>
        private readonly int _major;
        /// <summary>
        /// The minor
        /// </summary>
        private readonly int _minor;

        /// <summary>
        /// Gets the value of the count
        /// </summary>
        public int Count => _extensions.Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGLExtensions"/> class
        /// </summary>
        /// <param name="extensions">The extensions</param>
        /// <param name="backend">The backend</param>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        internal OpenGLExtensions(HashSet<string> extensions, GraphicsBackend backend, int major, int minor)
        {
            _extensions = extensions;
            _backend = backend;
            _major = major;
            _minor = minor;

            TextureStorage = IsExtensionSupported("GL_ARB_texture_storage") // OpenGL 4.2 / 4.3 (multisampled)
                || GLESVersion(3, 0);
            TextureStorageMultisample = IsExtensionSupported("GL_ARB_texture_storage_multisample")
                || GLESVersion(3, 1);
            ARB_DirectStateAccess = IsExtensionSupported("GL_ARB_direct_state_access");
            ARB_MultiBind = IsExtensionSupported("GL_ARB_multi_bind");
            ARB_TextureView = GLVersion(4, 3) || IsExtensionSupported("GL_ARB_texture_view") // OpenGL 4.3
                || IsExtensionSupported("GL_OES_texture_view");
            CopyImage = IsExtensionSupported("GL_ARB_copy_image")
                || GLESVersion(3, 2)
                || IsExtensionSupported("GL_OES_copy_image")
                || IsExtensionSupported("GL_EXT_copy_image");
            ARB_DebugOutput = IsExtensionSupported("GL_ARB_debug_output");
            KHR_Debug = IsExtensionSupported("GL_KHR_debug");

            ComputeShaders = IsExtensionSupported("GL_ARB_compute_shader") || GLESVersion(3, 1);

            ARB_ViewportArray = IsExtensionSupported("GL_ARB_viewport_array") || GLVersion(4, 1);
            TessellationShader = IsExtensionSupported("GL_ARB_tessellation_shader") || GLVersion(4, 0)
                || IsExtensionSupported("GL_OES_tessellation_shader");
            GeometryShader = IsExtensionSupported("GL_ARB_geometry_shader4") || GLVersion(3, 2)
                || IsExtensionSupported("OES_geometry_shader");
            DrawElementsBaseVertex = GLVersion(3, 2)
                || IsExtensionSupported("GL_ARB_draw_elements_base_vertex")
                || GLESVersion(3, 2)
                || IsExtensionSupported("GL_OES_draw_elements_base_vertex");
            IndependentBlend = GLVersion(4, 0) || GLESVersion(3, 2);

            DrawIndirect = GLVersion(4, 0) || IsExtensionSupported("GL_ARB_draw_indirect")
                || GLESVersion(3, 1);
            MultiDrawIndirect = GLVersion(4, 3) || IsExtensionSupported("GL_ARB_multi_draw_indirect")
                || IsExtensionSupported("GL_EXT_multi_draw_indirect");

            StorageBuffers = GLVersion(4, 3) || IsExtensionSupported("GL_ARB_shader_storage_buffer_object")
                || GLESVersion(3, 1);

            ARB_ClipControl = GLVersion(4, 5) || IsExtensionSupported("GL_ARB_clip_control");
            EXT_sRGBWriteControl = _backend == GraphicsBackend.OpenGLES && IsExtensionSupported("GL_EXT_sRGB_write_control");
            EXT_DebugMarker = _backend == GraphicsBackend.OpenGLES && IsExtensionSupported("GL_EXT_debug_marker");

            ARB_GpuShaderFp64 = GLVersion(4, 0) || IsExtensionSupported("GL_ARB_gpu_shader_fp64");

            ARB_uniform_buffer_object = IsExtensionSupported("GL_ARB_uniform_buffer_object");

            AnisotropicFilter = IsExtensionSupported("GL_EXT_texture_filter_anisotropic") || IsExtensionSupported("GL_ARB_texture_filter_anisotropic");
        }

        /// <summary>
        /// The arb directstateaccess
        /// </summary>
        public readonly bool ARB_DirectStateAccess;
        /// <summary>
        /// The arb multibind
        /// </summary>
        public readonly bool ARB_MultiBind;
        /// <summary>
        /// The arb textureview
        /// </summary>
        public readonly bool ARB_TextureView;
        /// <summary>
        /// The arb debugoutput
        /// </summary>
        public readonly bool ARB_DebugOutput;
        /// <summary>
        /// The khr debug
        /// </summary>
        public readonly bool KHR_Debug;
        /// <summary>
        /// The arb viewportarray
        /// </summary>
        public readonly bool ARB_ViewportArray;
        /// <summary>
        /// The arb clipcontrol
        /// </summary>
        public readonly bool ARB_ClipControl;
        /// <summary>
        /// The ext srgbwritecontrol
        /// </summary>
        public readonly bool EXT_sRGBWriteControl;
        /// <summary>
        /// The ext debugmarker
        /// </summary>
        public readonly bool EXT_DebugMarker;
        /// <summary>
        /// The arb gpushaderfp64
        /// </summary>
        public readonly bool ARB_GpuShaderFp64;
        /// <summary>
        /// The arb uniform buffer object
        /// </summary>
        public readonly bool ARB_uniform_buffer_object;

        // Differs between GL / GLES
        /// <summary>
        /// The texture storage
        /// </summary>
        public readonly bool TextureStorage;
        /// <summary>
        /// The texture storage multisample
        /// </summary>
        public readonly bool TextureStorageMultisample;

        /// <summary>
        /// The copy image
        /// </summary>
        public readonly bool CopyImage;
        /// <summary>
        /// The compute shaders
        /// </summary>
        public readonly bool ComputeShaders;
        /// <summary>
        /// The tessellation shader
        /// </summary>
        public readonly bool TessellationShader;
        /// <summary>
        /// The geometry shader
        /// </summary>
        public readonly bool GeometryShader;
        /// <summary>
        /// The draw elements base vertex
        /// </summary>
        public readonly bool DrawElementsBaseVertex;
        /// <summary>
        /// The independent blend
        /// </summary>
        public readonly bool IndependentBlend;
        /// <summary>
        /// The draw indirect
        /// </summary>
        public readonly bool DrawIndirect;
        /// <summary>
        /// The multi draw indirect
        /// </summary>
        public readonly bool MultiDrawIndirect;
        /// <summary>
        /// The storage buffers
        /// </summary>
        public readonly bool StorageBuffers;
        /// <summary>
        /// The anisotropic filter
        /// </summary>
        public readonly bool AnisotropicFilter;

        /// <summary>
        /// Returns a value indicating whether the given extension is supported.
        /// </summary>
        /// <param name="extension">The name of the extensions. For example, "</param>
        /// <returns></returns>
        public bool IsExtensionSupported(string extension)
        {
            return _extensions.Contains(extension);
        }

        /// <summary>
        /// Describes whether this instance gl version
        /// </summary>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <returns>The bool</returns>
        public bool GLVersion(int major, int minor)
        {
            if (_backend == GraphicsBackend.OpenGL)
            {
                if (_major > major)
                {
                    return true;
                }
                else
                {
                    return _major == major && _minor >= minor;
                }
            }

            return false;
        }

        /// <summary>
        /// Describes whether this instance gles version
        /// </summary>
        /// <param name="major">The major</param>
        /// <param name="minor">The minor</param>
        /// <returns>The bool</returns>
        public bool GLESVersion(int major, int minor)
        {
            if (_backend == GraphicsBackend.OpenGLES)
            {
                if (_major > major)
                {
                    return true;
                }
                else
                {
                    return _major == major && _minor >= minor;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>An enumerator of string</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return _extensions.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

//  --------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Executes the managed <see cref="GlShader" /> paths with fake OpenGL function pointers.
    /// </summary>
    [Collection("OpenGLFakeState")]
    public class GlShaderRemainingCoverageTests : IDisposable
    {
        private const string CompileLog = "compile failed";
        private static readonly CreateShader CreateShaderDelegate = FakeCreateShader;
        private static readonly ShaderSourceDel ShaderSourceDelegate = FakeShaderSource;
        private static readonly CompileShader CompileShaderDelegate = FakeCompileShader;
        private static readonly GetShaderiv GetShaderIvDelegate = FakeGetShaderIv;
        private static readonly GetShaderInfoLogDel GetShaderInfoLogDelegate = FakeGetShaderInfoLog;
        private static readonly DeleteShader DeleteShaderDelegate = FakeDeleteShader;

        private static string _capturedSource;
        private static uint _compiledShaderId;
        private static int _deleteResolverRequests;
        private static uint _deletedShaderId;
        private static bool _compileSucceeded;
        private static bool _failDeleteLookup;
        private static uint _nextShaderId;

        /// <summary>
        ///     Tests that a successful compilation exposes the shader state and dispose deletes the shader.
        /// </summary>
        [Fact]
        public void Constructor_WithSuccessfulCompilation_ExposesStateAndDisposeDeletesShader()
        {
            Reset();
            _compileSucceeded = true;
            Gl.Initialize(FakeProcAddress);

            GlShader shader = new GlShader("void main() {}", ShaderType.FragmentShader);

            Assert.Equal(41u, shader.ShaderId);
            Assert.Equal(ShaderType.FragmentShader, shader.ShaderType);
            Assert.Equal(41u, _compiledShaderId);
            Assert.Equal("void main() {}", _capturedSource);
            Assert.Equal(string.Empty, shader.ShaderLog);

            shader.Dispose();

            Assert.Equal(0u, shader.ShaderId);
            Assert.Equal(41u, _deletedShaderId);
        }

        /// <summary>
        ///     Tests that a failed compilation throws an invalid operation with the shader log.
        /// </summary>
        [Fact]
        public void Constructor_WithFailedCompilation_ThrowsWithShaderLog()
        {
            Reset();
            Gl.Initialize(FakeProcAddress);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => new GlShader("void main() {}", ShaderType.VertexShader));

            Assert.Equal(CompileLog, exception.Message);
            Assert.Equal(41u, _compiledShaderId);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        /// <summary>
        ///     Tests that the finalizer swallows a failure while resolving the delete-shader command.
        /// </summary>
        [Fact]
        public void Finalizer_WhenDeleteLookupFails_SwallowsException()
        {
            Reset();
            _compileSucceeded = true;
            _failDeleteLookup = true;
            Gl.Initialize(FakeProcAddress);

            CreateShaderForFinalizer();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Assert.True(_deleteResolverRequests > 0);
        }

        /// <summary>
        ///     Creates a shader that is left for the finalizer.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void CreateShaderForFinalizer()
        {
            GlShader shader = new GlShader("void main() {}", ShaderType.VertexShader);
            Assert.Equal(41u, shader.ShaderId);
        }

        /// <summary>
        ///     Restores the process-wide OpenGL resolver to its uninitialized state.
        /// </summary>
        public void Dispose() => Gl.Initialize(null);

        /// <summary>
        ///     Resets the fake OpenGL state.
        /// </summary>
        private static void Reset()
        {
            _capturedSource = null;
            _compiledShaderId = 0;
            _deleteResolverRequests = 0;
            _deletedShaderId = 0;
            _compileSucceeded = false;
            _failDeleteLookup = false;
            _nextShaderId = 40;
        }

        /// <summary>
        ///     Fake create-shader delegate body.
        /// </summary>
        /// <param name="shaderType">The shader type.</param>
        /// <returns>The generated shader id.</returns>
        private static uint FakeCreateShader(ShaderType shaderType) => ++_nextShaderId;

        /// <summary>
        ///     Fake shader-source delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        /// <param name="count">The source count.</param>
        /// <param name="source">The source strings.</param>
        /// <param name="length">The source lengths.</param>
        private static void FakeShaderSource(uint shader, int count, string[] source, int[] length)
        {
            _capturedSource = source != null && source.Length > 0 ? source[0] : null;
        }

        /// <summary>
        ///     Fake compile-shader delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        private static void FakeCompileShader(uint shader) => _compiledShaderId = shader;

        /// <summary>
        ///     Fake get-shader-parameter delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        /// <param name="parameter">The requested parameter.</param>
        /// <param name="values">The output values.</param>
        private static void FakeGetShaderIv(uint shader, ShaderParameter parameter, int[] values)
        {
            switch (parameter)
            {
                case ShaderParameter.CompileStatus:
                    values[0] = _compileSucceeded ? 1 : 0;
                    break;
                case ShaderParameter.InfoLogLength:
                    values[0] = _compileSucceeded ? 0 : CompileLog.Length;
                    break;
                default:
                    values[0] = 0;
                    break;
            }
        }

        /// <summary>
        ///     Fake get-shader-info-log delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        /// <param name="maxLength">The maximum log length.</param>
        /// <param name="length">The output length.</param>
        /// <param name="infoLog">The output log.</param>
        private static void FakeGetShaderInfoLog(uint shader, int maxLength, int[] length, StringBuilder infoLog)
        {
            infoLog.Clear();
            infoLog.Append(CompileLog);
            length[0] = CompileLog.Length;
        }

        /// <summary>
        ///     Fake delete-shader delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        private static void FakeDeleteShader(uint shader) => _deletedShaderId = shader;

        /// <summary>
        ///     Fake OpenGL function address resolver.
        /// </summary>
        /// <param name="name">The OpenGL function name.</param>
        /// <returns>The fake function pointer.</returns>
        private static IntPtr FakeProcAddress(string name)
        {
            switch (name)
            {
                case "glCreateShader": return Marshal.GetFunctionPointerForDelegate(CreateShaderDelegate);
                case "glShaderSource": return Marshal.GetFunctionPointerForDelegate(ShaderSourceDelegate);
                case "glCompileShader": return Marshal.GetFunctionPointerForDelegate(CompileShaderDelegate);
                case "glGetShaderiv": return Marshal.GetFunctionPointerForDelegate(GetShaderIvDelegate);
                case "glGetShaderInfoLog": return Marshal.GetFunctionPointerForDelegate(GetShaderInfoLogDelegate);
                case "glDeleteShader":
                    _deleteResolverRequests++;
                    return _failDeleteLookup ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(DeleteShaderDelegate);
                default: return IntPtr.Zero;
            }
        }
    }
}

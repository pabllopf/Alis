//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
    ///     Executes the managed <see cref="GlShaderProgram" /> construction, parameter discovery and
    ///     disposal paths with fake OpenGL function pointers.
    /// </summary>
    [Collection("OpenGLFakeState")]
    public class GlShaderProgramExecutionCoverageTests : IDisposable
    {
        private const string AttributeName = "aPosition";
        private const string UniformName = "uColor";
        private const string LinkLog = "link failed";

        private static readonly CreateShader CreateShaderDelegate = FakeCreateShader;
        private static readonly ShaderSourceDel ShaderSourceDelegate = FakeShaderSource;
        private static readonly CompileShader CompileShaderDelegate = FakeCompileShader;
        private static readonly GetShaderiv GetShaderIvDelegate = FakeGetShaderIv;
        private static readonly GetShaderInfoLogDel GetShaderInfoLogDelegate = FakeGetShaderInfoLog;
        private static readonly CreateProgram CreateProgramDelegate = FakeCreateProgram;
        private static readonly AttachShader AttachShaderDelegate = FakeAttachShader;
        private static readonly LinkProgram LinkProgramDelegate = FakeLinkProgram;
        private static readonly GetProgramiv GetProgramIvDelegate = FakeGetProgramIv;
        private static readonly GetProgramInfoLogDel GetProgramInfoLogDelegate = FakeGetProgramInfoLog;
        private static readonly GetActiveAttrib GetActiveAttribDelegate = FakeGetActiveAttrib;
        private static readonly GetActiveUniform GetActiveUniformDelegate = FakeGetActiveUniform;
        private static readonly GetAttribLocation GetAttribLocationDelegate = FakeGetAttribLocation;
        private static readonly GetUniformLocation GetUniformLocationDelegate = FakeGetUniformLocation;
        private static readonly UseProgram UseProgramDelegate = FakeUseProgram;
        private static readonly DetachShader DetachShaderDelegate = FakeDetachShader;
        private static readonly DeleteProgram DeleteProgramDelegate = FakeDeleteProgram;
        private static readonly DeleteShader DeleteShaderDelegate = FakeDeleteShader;

        private static readonly List<uint> AttachedShaderIds = new List<uint>();
        private static readonly List<uint> DeletedShaderIds = new List<uint>();
        private static readonly List<uint> DetachedShaderIds = new List<uint>();

        private static int _activeAttributes;
        private static int _activeUniforms;
        private static int _attribLookupRequests;
        private static uint _deletedProgramId;
        private static int _shaderSourceRequests;
        private static bool _linkSucceeded;
        private static uint _linkedProgramId;
        private static uint _nextProgramId;
        private static uint _nextShaderId;
        private static int _uniformLookupRequests;

        /// <summary>
        ///     Tests that the shader-object constructor links, discovers parameters and leaves child shaders alive.
        /// </summary>
        [Fact]
        public void ShaderConstructor_WithLinkSuccess_RegistersParamsAndKeepsChildrenOnDispose()
        {
            Reset();
            _linkSucceeded = true;
            _activeAttributes = 2;
            _activeUniforms = 2;
            Gl.Initialize(FakeProcAddress);

            GlShader vertex = new GlShader("vertex", ShaderType.VertexShader);
            GlShader fragment = new GlShader("fragment", ShaderType.FragmentShader);
            GlShaderProgram program = new GlShaderProgram(vertex, fragment);

            Assert.Equal(61u, program.ProgramId);
            Assert.Same(vertex, program.VertexShader);
            Assert.Same(fragment, program.FragmentShader);
            Assert.False(program.DisposeChildren);
            Assert.Equal(61u, _linkedProgramId);
            Assert.Equal(new uint[] {41u, 42u}, AttachedShaderIds);
            Assert.Equal(AttributeName, program[AttributeName].Name);
            Assert.Equal(ParamType.Attribute, program[AttributeName].ParamType);
            Assert.Equal(11, program[AttributeName].Location);
            Assert.Equal(UniformName, program[UniformName].Name);
            Assert.Equal(ParamType.Uniform, program[UniformName].ParamType);
            Assert.Equal(12, program[UniformName].Location);
            Assert.Equal(1, _attribLookupRequests);
            Assert.Equal(1, _uniformLookupRequests);
            Assert.Null(program["missing"]);

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
            Assert.Equal(61u, _deletedProgramId);
            Assert.Equal(new uint[] {41u, 42u}, DetachedShaderIds);
            Assert.Empty(DeletedShaderIds);
            Assert.Equal(41u, vertex.ShaderId);
            Assert.Equal(42u, fragment.ShaderId);
        }

        /// <summary>
        ///     Tests that the source constructor owns its shaders and disposes them with the program.
        /// </summary>
        [Fact]
        public void SourceConstructor_WithLinkSuccess_DisposeDeletesChildren()
        {
            Reset();
            _linkSucceeded = true;
            Gl.Initialize(FakeProcAddress);

            GlShaderProgram program = new GlShaderProgram("vertex", "fragment");

            Assert.True(program.DisposeChildren);
            Assert.Equal(61u, program.ProgramId);
            Assert.Equal(41u, program.VertexShader.ShaderId);
            Assert.Equal(42u, program.FragmentShader.ShaderId);
            Assert.Equal(2, _shaderSourceRequests);

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
            Assert.Equal(new uint[] {41u, 42u}, DeletedShaderIds);
            Assert.Equal(0u, program.VertexShader.ShaderId);
            Assert.Equal(0u, program.FragmentShader.ShaderId);
        }

        /// <summary>
        ///     Tests that a failed program link throws an invalid operation with the program log.
        /// </summary>
        [Fact]
        public void SourceConstructor_WithLinkFailure_ThrowsWithProgramLog()
        {
            Reset();
            Gl.Initialize(FakeProcAddress);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => new GlShaderProgram("vertex", "fragment"));

            Assert.Equal(LinkLog, exception.Message);
            Assert.Equal(61u, _linkedProgramId);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
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
            AttachedShaderIds.Clear();
            DeletedShaderIds.Clear();
            DetachedShaderIds.Clear();
            _activeAttributes = 0;
            _activeUniforms = 0;
            _attribLookupRequests = 0;
            _deletedProgramId = 0;
            _shaderSourceRequests = 0;
            _linkSucceeded = false;
            _linkedProgramId = 0;
            _nextProgramId = 60;
            _nextShaderId = 40;
            _uniformLookupRequests = 0;
        }

        /// <summary>
        ///     Fake create-shader delegate body.
        /// </summary>
        /// <param name="shaderType">The shader type.</param>
        /// <returns>The shader id.</returns>
        private static uint FakeCreateShader(ShaderType shaderType) => ++_nextShaderId;

        /// <summary>
        ///     Fake shader-source delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        /// <param name="count">The source count.</param>
        /// <param name="source">The source strings.</param>
        /// <param name="length">The source lengths.</param>
        private static void FakeShaderSource(uint shader, int count, string[] source, int[] length) => _shaderSourceRequests++;

        /// <summary>
        ///     Fake compile-shader delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        private static void FakeCompileShader(uint shader)
        {
        }

        /// <summary>
        ///     Fake get-shader-parameter delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        /// <param name="parameter">The requested parameter.</param>
        /// <param name="values">The output values.</param>
        private static void FakeGetShaderIv(uint shader, ShaderParameter parameter, int[] values)
        {
            values[0] = parameter == ShaderParameter.CompileStatus ? 1 : 0;
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
        }

        /// <summary>
        ///     Fake create-program delegate body.
        /// </summary>
        /// <returns>The program id.</returns>
        private static uint FakeCreateProgram() => ++_nextProgramId;

        /// <summary>
        ///     Fake attach-shader delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="shader">The shader id.</param>
        private static void FakeAttachShader(uint program, uint shader) => AttachedShaderIds.Add(shader);

        /// <summary>
        ///     Fake link-program delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        private static void FakeLinkProgram(uint program) => _linkedProgramId = program;

        /// <summary>
        ///     Fake get-program-parameter delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="parameter">The requested parameter.</param>
        /// <param name="values">The output values.</param>
        private static void FakeGetProgramIv(uint program, ProgramParameter parameter, int[] values)
        {
            switch (parameter)
            {
                case ProgramParameter.LinkStatus:
                    values[0] = _linkSucceeded ? 1 : 0;
                    break;
                case ProgramParameter.InfoLogLength:
                    values[0] = _linkSucceeded ? 0 : LinkLog.Length;
                    break;
                case ProgramParameter.ActiveAttributes:
                    values[0] = _activeAttributes;
                    break;
                case ProgramParameter.ActiveUniforms:
                    values[0] = _activeUniforms;
                    break;
                default:
                    values[0] = 0;
                    break;
            }
        }

        /// <summary>
        ///     Fake get-program-info-log delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="maxLength">The maximum log length.</param>
        /// <param name="length">The output length.</param>
        /// <param name="infoLog">The output log.</param>
        private static void FakeGetProgramInfoLog(uint program, int maxLength, int[] length, StringBuilder infoLog)
        {
            infoLog.Clear();
            infoLog.Append(LinkLog);
            length[0] = LinkLog.Length;
        }

        /// <summary>
        ///     Fake get-active-attrib delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="index">The attribute index.</param>
        /// <param name="bufferSize">The name buffer size.</param>
        /// <param name="length">The output length.</param>
        /// <param name="size">The output size.</param>
        /// <param name="type">The output type.</param>
        /// <param name="name">The output name.</param>
        private static void FakeGetActiveAttrib(uint program, uint index, int bufferSize, int[] length, int[] size,
            ActiveAttribType[] type, StringBuilder name)
        {
            type[0] = ActiveAttribType.Float;
            name.Clear();
            name.Append(AttributeName);
        }

        /// <summary>
        ///     Fake get-active-uniform delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="index">The uniform index.</param>
        /// <param name="bufferSize">The name buffer size.</param>
        /// <param name="length">The output length.</param>
        /// <param name="size">The output size.</param>
        /// <param name="type">The output type.</param>
        /// <param name="name">The output name.</param>
        private static void FakeGetActiveUniform(uint program, uint index, int bufferSize, int[] length, int[] size,
            ActiveUniformType[] type, StringBuilder name)
        {
            type[0] = ActiveUniformType.Float;
            name.Clear();
            name.Append(UniformName);
        }

        /// <summary>
        ///     Fake get-attrib-location delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="name">The attribute name.</param>
        /// <returns>The attribute location.</returns>
        private static int FakeGetAttribLocation(uint program, string name)
        {
            _attribLookupRequests++;
            return 11;
        }

        /// <summary>
        ///     Fake get-uniform-location delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="name">The uniform name.</param>
        /// <returns>The uniform location.</returns>
        private static int FakeGetUniformLocation(uint program, string name)
        {
            _uniformLookupRequests++;
            return 12;
        }

        /// <summary>
        ///     Fake use-program delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        private static void FakeUseProgram(uint program)
        {
        }

        /// <summary>
        ///     Fake detach-shader delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        /// <param name="shader">The shader id.</param>
        private static void FakeDetachShader(uint program, uint shader) => DetachedShaderIds.Add(shader);

        /// <summary>
        ///     Fake delete-program delegate body.
        /// </summary>
        /// <param name="program">The program id.</param>
        private static void FakeDeleteProgram(uint program) => _deletedProgramId = program;

        /// <summary>
        ///     Fake delete-shader delegate body.
        /// </summary>
        /// <param name="shader">The shader id.</param>
        private static void FakeDeleteShader(uint shader) => DeletedShaderIds.Add(shader);

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
                case "glCreateProgram": return Marshal.GetFunctionPointerForDelegate(CreateProgramDelegate);
                case "glAttachShader": return Marshal.GetFunctionPointerForDelegate(AttachShaderDelegate);
                case "glLinkProgram": return Marshal.GetFunctionPointerForDelegate(LinkProgramDelegate);
                case "glGetProgramiv": return Marshal.GetFunctionPointerForDelegate(GetProgramIvDelegate);
                case "glGetProgramInfoLog": return Marshal.GetFunctionPointerForDelegate(GetProgramInfoLogDelegate);
                case "glGetActiveAttrib": return Marshal.GetFunctionPointerForDelegate(GetActiveAttribDelegate);
                case "glGetActiveUniform": return Marshal.GetFunctionPointerForDelegate(GetActiveUniformDelegate);
                case "glGetAttribLocation": return Marshal.GetFunctionPointerForDelegate(GetAttribLocationDelegate);
                case "glGetUniformLocation": return Marshal.GetFunctionPointerForDelegate(GetUniformLocationDelegate);
                case "glUseProgram": return Marshal.GetFunctionPointerForDelegate(UseProgramDelegate);
                case "glDetachShader": return Marshal.GetFunctionPointerForDelegate(DetachShaderDelegate);
                case "glDeleteProgram": return Marshal.GetFunctionPointerForDelegate(DeleteProgramDelegate);
                case "glDeleteShader": return Marshal.GetFunctionPointerForDelegate(DeleteShaderDelegate);
                default: return IntPtr.Zero;
            }
        }
    }
}

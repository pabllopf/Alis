using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Test.OpenGL.Constructs
{
    internal static class GlMock
    {
        private static bool _initialized;
        private static readonly Dictionary<string, IntPtr> ProcTable = new();

        private static uint _nextShaderId = 1;
        private static uint _nextProgramId = 1;
        private static uint _nextBufferId = 1;
        private static uint _nextTextureId = 1;
        private static uint _nextVaoId = 1;

        internal static readonly Dictionary<uint, ShaderType> ShaderTypes = new();
        internal static readonly Dictionary<uint, string> ShaderSources = new();
        internal static readonly Dictionary<uint, bool> ShaderCompiled = new();
        internal static readonly Dictionary<uint, bool> ShaderDeleted = new();
        internal static readonly Dictionary<uint, string> ShaderErrorLogs = new();

        internal static readonly Dictionary<uint, List<uint>> ProgramShaders = new();
        internal static readonly Dictionary<uint, bool> ProgramLinked = new();
        internal static readonly Dictionary<uint, bool> ProgramDeleted = new();
        internal static readonly Dictionary<uint, string> ProgramErrorLogs = new();

        internal static bool FailCompilation;
        internal static bool FailLink;

        internal static void Initialize()
        {
            if (_initialized) return;
            _initialized = true;

            Register("glCreateShader", Marshal.GetFunctionPointerForDelegate((CreateShader)MockCreateShader));
            Register("glShaderSource", Marshal.GetFunctionPointerForDelegate((ShaderSourceDel)MockShaderSource));
            Register("glCompileShader", Marshal.GetFunctionPointerForDelegate((CompileShader)MockCompileShader));
            Register("glGetShaderiv", Marshal.GetFunctionPointerForDelegate((GetShaderiv)MockGetShaderiv));
            Register("glGetShaderInfoLog", Marshal.GetFunctionPointerForDelegate((GetShaderInfoLogDel)MockGetShaderInfoLog));
            Register("glDeleteShader", Marshal.GetFunctionPointerForDelegate((DeleteShader)MockDeleteShader));
            Register("glCreateProgram", Marshal.GetFunctionPointerForDelegate((CreateProgram)MockCreateProgram));
            Register("glAttachShader", Marshal.GetFunctionPointerForDelegate((AttachShader)MockAttachShader));
            Register("glLinkProgram", Marshal.GetFunctionPointerForDelegate((LinkProgram)MockLinkProgram));
            Register("glGetProgramiv", Marshal.GetFunctionPointerForDelegate((GetProgramiv)MockGetProgramiv));
            Register("glUseProgram", Marshal.GetFunctionPointerForDelegate((UseProgram)MockUseProgram));
            Register("glDeleteProgram", Marshal.GetFunctionPointerForDelegate((DeleteProgram)MockDeleteProgram));
            Register("glDetachShader", Marshal.GetFunctionPointerForDelegate((DetachShader)MockDetachShader));
            Register("glGetProgramInfoLog", Marshal.GetFunctionPointerForDelegate((GetProgramInfoLogDel)MockGetProgramInfoLog));
            Register("glGetUniformLocation", Marshal.GetFunctionPointerForDelegate((GetUniformLocation)MockGetUniformLocation));
            Register("glGetAttribLocation", Marshal.GetFunctionPointerForDelegate((GetAttribLocation)MockGetAttribLocation));
            Register("glUniform1i", Marshal.GetFunctionPointerForDelegate((Uniform1I)MockUniform1I));
            Register("glUniform1f", Marshal.GetFunctionPointerForDelegate((Uniform1F)MockUniform1F));
            Register("glUniform2f", Marshal.GetFunctionPointerForDelegate((Uniform2F)MockUniform2F));
            Register("glUniform3f", Marshal.GetFunctionPointerForDelegate((Uniform3F)MockUniform3F));
            Register("glUniform4f", Marshal.GetFunctionPointerForDelegate((Uniform4F)MockUniform4F));
            Register("glUniformMatrix4fv", Marshal.GetFunctionPointerForDelegate((UniformMatrix4FvDel)MockUniformMatrix4Fv));
            Register("glUniformMatrix3fv", Marshal.GetFunctionPointerForDelegate((UniformMatrix3FvDel)MockUniformMatrix3Fv));
            Register("glGenBuffers", Marshal.GetFunctionPointerForDelegate((GenBuffers)MockGenBuffers));
            Register("glBindBuffer", Marshal.GetFunctionPointerForDelegate((BindBuffer)MockBindBuffer));
            Register("glBufferData", Marshal.GetFunctionPointerForDelegate((BufferData)MockBufferData));
            Register("glGenVertexArrays", Marshal.GetFunctionPointerForDelegate((GenVertexArrays)MockGenVertexArrays));
            Register("glBindVertexArray", Marshal.GetFunctionPointerForDelegate((BindVertexArray)MockBindVertexArray));
            Register("glEnableVertexAttribArray", Marshal.GetFunctionPointerForDelegate((EnableVertexAttribArrayDel)MockEnableVertexAttribArray));
            Register("glVertexAttribPointer", Marshal.GetFunctionPointerForDelegate((VertexAttribPointerDel)MockVertexAttribPointer));
            Register("glGenTextures", Marshal.GetFunctionPointerForDelegate((GenTextures)MockGenTextures));
            Register("glBindTexture", Marshal.GetFunctionPointerForDelegate((BindTexture)MockBindTexture));
            Register("glTexParameteri", Marshal.GetFunctionPointerForDelegate((TexParameteri)MockTexParameteri));
            Register("glTexImage2D", Marshal.GetFunctionPointerForDelegate((TexImage2D)MockTexImage2D));
            Register("glViewport", Marshal.GetFunctionPointerForDelegate((Viewport)MockViewport));

            Gl.Initialize(GetProcAddress);
        }

        internal static void Shutdown()
        {
            if (!_initialized) return;
            _initialized = false;
            ProcTable.Clear();

            FieldInfo field = typeof(Gl).GetField("_getProcAddress", BindingFlags.Static | BindingFlags.NonPublic);
            if (field != null)
            {
                field.SetValue(null, null);
            }
        }

        internal static void Reset()
        {
            _nextShaderId = 1;
            _nextProgramId = 1;
            _nextBufferId = 1;
            _nextTextureId = 1;
            _nextVaoId = 1;
            ShaderTypes.Clear();
            ShaderSources.Clear();
            ShaderCompiled.Clear();
            ShaderDeleted.Clear();
            ShaderErrorLogs.Clear();
            ProgramShaders.Clear();
            ProgramLinked.Clear();
            ProgramDeleted.Clear();
            ProgramErrorLogs.Clear();
            FailCompilation = false;
            FailLink = false;
        }

        private static void Register(string name, IntPtr ptr) => ProcTable[name] = ptr;

        private static IntPtr GetProcAddress(string name) =>
            ProcTable.TryGetValue(name, out IntPtr ptr) ? ptr : IntPtr.Zero;

        private static uint MockCreateShader(ShaderType shaderType)
        {
            uint id = _nextShaderId++;
            ShaderTypes[id] = shaderType;
            ShaderSources[id] = null;
            ShaderCompiled[id] = false;
            ShaderDeleted[id] = false;
            ShaderErrorLogs[id] = string.Empty;
            return id;
        }

        private static void MockShaderSource(uint shader, int count, string[] @string, int[] length)
        {
            ShaderSources[shader] = string.Join("\n", @string);
        }

        private static void MockCompileShader(uint shader)
        {
            if (FailCompilation)
            {
                ShaderCompiled[shader] = false;
                ShaderErrorLogs[shader] = "Mock compilation error";
                return;
            }
            ShaderCompiled[shader] = true;
            ShaderErrorLogs[shader] = string.Empty;
        }

        private static void MockGetShaderiv(uint shader, ShaderParameter pname, int[] @params)
        {
            if (pname == ShaderParameter.CompileStatus)
            {
                @params[0] = ShaderCompiled.GetValueOrDefault(shader) ? 1 : 0;
            }
            else if (pname == ShaderParameter.InfoLogLength)
            {
                string log = ShaderErrorLogs.GetValueOrDefault(shader) ?? string.Empty;
                @params[0] = string.IsNullOrEmpty(log) ? 0 : log.Length + 1;
            }
        }

        private static void MockGetShaderInfoLog(uint shader, int maxLength, int[] length, StringBuilder infoLog)
        {
            string log = ShaderErrorLogs.GetValueOrDefault(shader) ?? string.Empty;
            if (infoLog != null)
            {
                infoLog.Append(log);
            }
            if (length != null && length.Length > 0)
            {
                length[0] = log.Length;
            }
        }

        private static void MockDeleteShader(uint shader)
        {
            ShaderDeleted[shader] = true;
        }

        private static uint MockCreateProgram()
        {
            uint id = _nextProgramId++;
            ProgramShaders[id] = new List<uint>();
            ProgramLinked[id] = false;
            ProgramDeleted[id] = false;
            ProgramErrorLogs[id] = string.Empty;
            return id;
        }

        private static void MockAttachShader(uint program, uint shader)
        {
            if (ProgramShaders.ContainsKey(program))
            {
                ProgramShaders[program].Add(shader);
            }
        }

        private static void MockLinkProgram(uint program)
        {
            if (FailLink)
            {
                ProgramLinked[program] = false;
                ProgramErrorLogs[program] = "Mock link error";
                return;
            }
            ProgramLinked[program] = true;
            ProgramErrorLogs[program] = string.Empty;
        }

        private static void MockGetProgramiv(uint program, ProgramParameter pname, int[] @params)
        {
            if (pname == ProgramParameter.LinkStatus)
            {
                @params[0] = ProgramLinked.GetValueOrDefault(program) ? 1 : 0;
            }
            else if (pname == ProgramParameter.ActiveAttributes || pname == ProgramParameter.ActiveUniforms)
            {
                @params[0] = 0;
            }
        }

        private static void MockUseProgram(uint program) { }

        private static void MockDeleteProgram(uint program)
        {
            ProgramDeleted[program] = true;
        }

        private static void MockDetachShader(uint program, uint shader) { }

        private static void MockGetProgramInfoLog(uint program, int maxLength, int[] length, StringBuilder infoLog) { }

        private static int MockGetUniformLocation(uint program, string name) => name.GetHashCode();

        private static int MockGetAttribLocation(uint program, string name) => name.GetHashCode();

        private static void MockUniform1I(int location, int value) { }
        private static void MockUniform1F(int location, float value) { }
        private static void MockUniform2F(int location, float v1, float v2) { }
        private static void MockUniform3F(int location, float v1, float v2, float v3) { }
        private static void MockUniform4F(int location, float v1, float v2, float v3, float v4) { }
        private static void MockUniformMatrix4Fv(int location, int count, bool transpose, float[] value) { }
        private static void MockUniformMatrix3Fv(int location, int count, bool transpose, float[] value) { }

        private static void MockGenBuffers(int n, uint[] buffers)
        {
            for (int i = 0; i < n; i++)
            {
                buffers[i] = _nextBufferId++;
            }
        }

        private static void MockBindBuffer(BufferTarget target, uint buffer) { }

        private static void MockBufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsageHint usage) { }

        private static void MockGenVertexArrays(int n, uint[] arrays)
        {
            for (int i = 0; i < n; i++)
            {
                arrays[i] = _nextVaoId++;
            }
        }

        private static void MockBindVertexArray(uint array) { }

        private static void MockEnableVertexAttribArray(uint index) { }

        private static void MockVertexAttribPointer(uint index, int size, VertexAttribPointerType type, bool normalized, int stride, IntPtr pointer) { }

        private static void MockGenTextures(int n, uint[] textures)
        {
            for (int i = 0; i < n; i++)
            {
                textures[i] = _nextTextureId++;
            }
        }

        private static void MockBindTexture(TextureTarget target, uint texture) { }

        private static void MockTexParameteri(TextureTarget target, TextureParameterName pname, TextureParameter param) { }

        private static void MockTexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr data) { }

        private static void MockViewport(int x, int y, int width, int height) { }
    }
}

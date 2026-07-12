using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramParamCoverageTests : IDisposable
    {
        private static readonly FieldInfo ProcField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        private readonly object _saved;

        public GlShaderProgramParamCoverageTests()
        {
            _saved = ProcField?.GetValue(null);
        }

        public void Dispose()
        {
            ProcField?.SetValue(null, _saved);
        }

        private void InitMocks()
        {
            IntPtr fpCreateProgram = Marshal.GetFunctionPointerForDelegate((CreateProgram)(() => 42u));

            IntPtr fpAttachShader = Marshal.GetFunctionPointerForDelegate((AttachShader)((uint program, uint shader) =>
            {
            }));

            IntPtr fpLinkProgram = Marshal.GetFunctionPointerForDelegate((LinkProgram)((uint program) =>
            {
            }));

            IntPtr fpGetProgramiv = Marshal.GetFunctionPointerForDelegate((GetProgramiv)((uint program, ProgramParameter pname, int[] @params) =>
            {
                if (pname == ProgramParameter.LinkStatus)
                {
                    @params[0] = 1;
                }
                else if (pname == ProgramParameter.InfoLogLength)
                {
                    @params[0] = 0;
                }
                else if (pname == ProgramParameter.ActiveAttributes)
                {
                    @params[0] = 0;
                }
                else if (pname == ProgramParameter.ActiveUniforms)
                {
                    @params[0] = 0;
                }
            }));

            IntPtr fpGetProgramInfoLog = Marshal.GetFunctionPointerForDelegate((GetProgramInfoLogDel)((uint program, int maxLength, int[] length, System.Text.StringBuilder infoLog) =>
            {
            }));

            IntPtr fpUseProgram = Marshal.GetFunctionPointerForDelegate((UseProgram)((uint program) =>
            {
            }));

            IntPtr fpGetUniformLocation = Marshal.GetFunctionPointerForDelegate((GetUniformLocation)((uint program, string name) =>
            {
                return name == "testUniform" ? 5 : -1;
            }));

            IntPtr fpGetAttribLocation = Marshal.GetFunctionPointerForDelegate((GetAttribLocation)((uint program, string name) =>
            {
                return name == "testAttrib" ? 3 : -1;
            }));

            IntPtr fpDetachShader = Marshal.GetFunctionPointerForDelegate((DetachShader)((uint program, uint shader) =>
            {
            }));

            IntPtr fpDeleteProgram = Marshal.GetFunctionPointerForDelegate((DeleteProgram)((uint program) =>
            {
            }));

            IntPtr fpCreateShader = Marshal.GetFunctionPointerForDelegate((CreateShader)((ShaderType type) => 1u));

            IntPtr fpShaderSource = Marshal.GetFunctionPointerForDelegate((ShaderSourceDel)((uint shader, int count, string[] source, int[] length) =>
            {
            }));

            IntPtr fpCompileShader = Marshal.GetFunctionPointerForDelegate((CompileShader)((uint shader) =>
            {
            }));

            IntPtr fpGetShaderiv = Marshal.GetFunctionPointerForDelegate((GetShaderiv)((uint shader, ShaderParameter pname, int[] @params) =>
            {
                if (pname == ShaderParameter.CompileStatus)
                {
                    @params[0] = 1;
                }
            }));

            IntPtr fpGetShaderInfoLog = Marshal.GetFunctionPointerForDelegate((GetShaderInfoLogDel)((uint shader, int maxLength, int[] length, System.Text.StringBuilder infoLog) =>
            {
            }));

            IntPtr fpDeleteShader = Marshal.GetFunctionPointerForDelegate((DeleteShader)((uint shader) =>
            {
            }));

            Dictionary<string, IntPtr> map = new Dictionary<string, IntPtr>
            {
                ["glCreateProgram"] = fpCreateProgram,
                ["glAttachShader"] = fpAttachShader,
                ["glLinkProgram"] = fpLinkProgram,
                ["glGetProgramiv"] = fpGetProgramiv,
                ["glGetProgramInfoLog"] = fpGetProgramInfoLog,
                ["glUseProgram"] = fpUseProgram,
                ["glGetUniformLocation"] = fpGetUniformLocation,
                ["glGetAttribLocation"] = fpGetAttribLocation,
                ["glDetachShader"] = fpDetachShader,
                ["glDeleteProgram"] = fpDeleteProgram,
                ["glCreateShader"] = fpCreateShader,
                ["glShaderSource"] = fpShaderSource,
                ["glCompileShader"] = fpCompileShader,
                ["glGetShaderiv"] = fpGetShaderiv,
                ["glGetShaderInfoLog"] = fpGetShaderInfoLog,
                ["glDeleteShader"] = fpDeleteShader,
            };

            Gl.Initialize(name => map.TryGetValue(name, out IntPtr ptr) ? ptr : IntPtr.Zero);
        }

        [Fact]
        public void GetLocation_WithUniformParam_SetsProgramIdAndLocation()
        {
            InitMocks();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "testUniform");
            using GlShaderProgram program = new GlShaderProgram("void main(){}", "void main(){}");

            param.GetLocation(program);

            Assert.Equal(42u, param.ProgramId);
            Assert.Equal(5, param.Location);
        }

        [Fact]
        public void GetLocation_WithAttributeParam_SetsProgramIdAndLocation()
        {
            InitMocks();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Attribute, "testAttrib");
            using GlShaderProgram program = new GlShaderProgram("void main(){}", "void main(){}");

            param.GetLocation(program);

            Assert.Equal(42u, param.ProgramId);
            Assert.Equal(3, param.Location);
        }

        [Fact]
        public void GetLocation_WhenProgramIdAlreadySet_DoesNotChangeValues()
        {
            InitMocks();

            GlShaderProgramParam param = new GlShaderProgramParam(typeof(float), ParamType.Uniform, "testUniform");
            param.ProgramId = 99u;
            param.Location = 10;
            using GlShaderProgram program = new GlShaderProgram("void main(){}", "void main(){}");

            param.GetLocation(program);

            Assert.Equal(99u, param.ProgramId);
            Assert.Equal(10, param.Location);
        }

        [Fact]
        public void SetValue_FloatArray_Length9_ThrowsWhenGlNotInitialized()
        {
            GlShaderProgramParam param = new GlShaderProgramParam(typeof(Exception), ParamType.Uniform, "m3");
            param.Location = 0;

            Assert.ThrowsAny<Exception>(() => param.SetValue(new float[9]));
        }
    }
}

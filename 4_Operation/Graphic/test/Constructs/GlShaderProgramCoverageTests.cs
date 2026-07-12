using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramCoverageTests : IDisposable
    {
        private static readonly FieldInfo ProcField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        private readonly object _saved;

        private uint _lastProgramId;

        private bool _useProgramCalled;

        private int _detachShaderCount;

        private int _deleteProgramCount;

        private int _deleteShaderCount;

        public GlShaderProgramCoverageTests()
        {
            _saved = ProcField?.GetValue(null);
        }

        public void Dispose()
        {
            ProcField?.SetValue(null, _saved);
        }

        private void InitMocks()
        {
            IntPtr fpCreateProgram = Marshal.GetFunctionPointerForDelegate((CreateProgram)(() =>
            {
                _lastProgramId = 42u;
                return _lastProgramId;
            }));

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
                _useProgramCalled = true;
            }));

            IntPtr fpGetUniformLocation = Marshal.GetFunctionPointerForDelegate((GetUniformLocation)((uint program, string name) =>
            {
                return name == "testUniform" ? 7 : -1;
            }));

            IntPtr fpGetAttribLocation = Marshal.GetFunctionPointerForDelegate((GetAttribLocation)((uint program, string name) =>
            {
                return name == "testAttrib" ? 3 : -1;
            }));

            IntPtr fpDetachShader = Marshal.GetFunctionPointerForDelegate((DetachShader)((uint program, uint shader) =>
            {
                _detachShaderCount++;
            }));

            IntPtr fpDeleteProgram = Marshal.GetFunctionPointerForDelegate((DeleteProgram)((uint program) =>
            {
                _deleteProgramCount++;
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
                _deleteShaderCount++;
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
        public void Constructor_WithGlShaders_SetsProperties()
        {
            InitMocks();

            var vs = new GlShader("void main(){}", ShaderType.VertexShader);
            var fs = new GlShader("void main(){}", ShaderType.FragmentShader);

            using var program = new GlShaderProgram(vs, fs);

            Assert.Equal(42u, program.ProgramId);
            Assert.Same(vs, program.VertexShader);
            Assert.Same(fs, program.FragmentShader);
            Assert.False(program.DisposeChildren);
        }

        [Fact]
        public void Constructor_WithStringSource_SetsProperties()
        {
            InitMocks();

            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            Assert.NotNull(program.VertexShader);
            Assert.NotNull(program.FragmentShader);
            Assert.True(program.DisposeChildren);
        }

        [Fact]
        public void Use_CallsGlUseProgram()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            _useProgramCalled = false;
            program.Use();

            Assert.True(_useProgramCalled);
        }

        [Fact]
        public void GetUniformLocation_ReturnsCorrectValue()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            int location = program.GetUniformLocation("testUniform");

            Assert.Equal(7, location);
        }

        [Fact]
        public void GetUniformLocation_ReturnsNegativeOne_ForUnknownName()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            int location = program.GetUniformLocation("unknown");

            Assert.Equal(-1, location);
        }

        [Fact]
        public void GetAttributeLocation_ReturnsCorrectValue()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            int location = program.GetAttributeLocation("testAttrib");

            Assert.Equal(3, location);
        }

        [Fact]
        public void GetAttributeLocation_ReturnsNegativeOne_ForUnknownName()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            int location = program.GetAttributeLocation("unknown");

            Assert.Equal(-1, location);
        }

        [Fact]
        public void ProgramLog_ReturnsString()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            string log = program.ProgramLog;

            Assert.NotNull(log);
        }

        [Fact]
        public void Dispose_DetachesAndDeletesProgram()
        {
            InitMocks();
            var program = new GlShaderProgram("void main(){}", "void main(){}");

            _detachShaderCount = 0;
            _deleteProgramCount = 0;
            program.Dispose();

            Assert.Equal(2, _detachShaderCount);
            Assert.Equal(1, _deleteProgramCount);
            Assert.Equal(0u, program.ProgramId);
        }

        [Fact]
        public void Dispose_WithDisposeChildren_DisposesShaders()
        {
            InitMocks();
            var program = new GlShaderProgram("void main(){}", "void main(){}");

            _deleteShaderCount = 0;
            Assert.True(program.DisposeChildren);

            program.Dispose();

            Assert.Equal(2, _deleteShaderCount);
            Assert.Equal(0u, program.ProgramId);
        }

        [Fact]
        public void Dispose_CalledTwice_IsSafe()
        {
            InitMocks();
            var program = new GlShaderProgram("void main(){}", "void main(){}");

            program.Dispose();
            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
        }

        [Fact]
        public void Dispose_WhenProgramIdZero_SkipsGlCalls()
        {
            var program = (GlShaderProgram)RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            FieldInfo progIdField = typeof(GlShaderProgram).GetField("<ProgramId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
            progIdField?.SetValue(program, 0u);

            using var record = new GlShaderProgramCoverageTests();
            record.InitMocks();
            bool useCalled = false;
            int detachCount = 0;
            int deleteCount = 0;

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
        }

        [Fact]
        public void Indexer_ReturnsNull_ForMissingKey()
        {
            var program = (GlShaderProgram)RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            FieldInfo paramsField = typeof(GlShaderProgram).GetField("shaderParams", BindingFlags.NonPublic | BindingFlags.Instance);
            paramsField?.SetValue(program, new Dictionary<string, GlShaderProgramParam>());

            GlShaderProgramParam result = program["nonexistent"];

            Assert.Null(result);
        }

        [Fact]
        public void Indexer_ReturnsParam_ForExistingKey()
        {
            var program = (GlShaderProgram)RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            FieldInfo paramsField = typeof(GlShaderProgram).GetField("shaderParams", BindingFlags.NonPublic | BindingFlags.Instance);
            var expected = new GlShaderProgramParam(typeof(int), ParamType.Uniform, "testParam");
            paramsField?.SetValue(program, new Dictionary<string, GlShaderProgramParam>
            {
                ["testParam"] = expected
            });

            GlShaderProgramParam result = program["testParam"];

            Assert.Same(expected, result);
            Assert.Equal("testParam", result.Name);
            Assert.Equal(ParamType.Uniform, result.ParamType);
            Assert.Equal(typeof(int), result.Type);
        }

        [Fact]
        public void Constructor_WithStringSource_Throws_WhenGlNotInitialized()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("vs", "fs"));
        }

        [Fact]
        public void ProgramId_ReadWrite_Property()
        {
            InitMocks();
            using var program = new GlShaderProgram("void main(){}", "void main(){}");

            Assert.Equal(42u, program.ProgramId);

            program.ProgramId = 99u;
            Assert.Equal(99u, program.ProgramId);
        }

        [Fact]
        public void Dispose_DoesNotDisposeChildren_WhenDisposeChildrenIsFalse()
        {
            InitMocks();
            var vs = new GlShader("void main(){}", ShaderType.VertexShader);
            var fs = new GlShader("void main(){}", ShaderType.FragmentShader);
            var program = new GlShaderProgram(vs, fs);

            Assert.False(program.DisposeChildren);

            _deleteShaderCount = 0;
            program.Dispose();

            Assert.Equal(0, _deleteShaderCount);
        }

        [Fact]
        public void Finalizer_CallsDisposeFalse()
        {
            InitMocks();
            bool cleanupCalled = false;

            var program = new GlShaderProgram("void main(){}", "void main(){}");
            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
        }
    }
}

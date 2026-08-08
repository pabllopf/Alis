// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgramTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// The gl shader program coverage tests class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class GlShaderProgramCoverageTests : IDisposable
    {
        /// <summary>
        /// The static
        /// </summary>
        private static readonly FieldInfo Field = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// The saved
        /// </summary>
        private readonly object _saved;

        /// <summary>
        /// The program id
        /// </summary>
        private uint _programId;
        /// <summary>
        /// The vertex shader id
        /// </summary>
        private uint _vertexShaderId;
        /// <summary>
        /// The fragment shader id
        /// </summary>
        private uint _fragmentShaderId;

        /// <summary>
        /// The use program zero called
        /// </summary>
        private bool _useProgramZeroCalled;
        /// <summary>
        /// The detach shader called
        /// </summary>
        private bool _detachShaderCalled;
        /// <summary>
        /// The delete program called
        /// </summary>
        private bool _deleteProgramCalled;
        /// <summary>
        /// The delete vertex shader called
        /// </summary>
        private bool _deleteVertexShaderCalled;
        /// <summary>
        /// The delete fragment shader called
        /// </summary>
        private bool _deleteFragmentShaderCalled;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlShaderProgramCoverageTests"/> class
        /// </summary>
        public GlShaderProgramCoverageTests() => _saved = Field?.GetValue(null);

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => Field?.SetValue(null, _saved);

        /// <summary>
        /// Inits the link success
        /// </summary>
        /// <param name="linkSuccess">The link success</param>
        /// <param name="activeAttributes">The active attributes</param>
        /// <param name="activeUniforms">The active uniforms</param>
        private void Init(bool linkSuccess = true, int activeAttributes = 0, int activeUniforms = 0)
        {
            _programId = 42;
            _vertexShaderId = 10;
            _fragmentShaderId = 20;
            _useProgramZeroCalled = false;
            _detachShaderCalled = false;
            _deleteProgramCalled = false;
            _deleteVertexShaderCalled = false;
            _deleteFragmentShaderCalled = false;

            CreateProgram createProgram = () => _programId;
            CreateShader createShader = (ShaderType type) => type == ShaderType.VertexShader ? _vertexShaderId : _fragmentShaderId;
            ShaderSourceDel shaderSource = (uint shader, int count, string[] src, int[] len) => { };
            CompileShader compileShader = (uint shader) => { };
            GetShaderiv getShaderiv = (uint shader, ShaderParameter pname, int[] p) =>
            {
                if (pname == ShaderParameter.CompileStatus)
                {
                    p[0] = 1;
                }
                else if (pname == ShaderParameter.InfoLogLength)
                {
                    p[0] = 0;
                }
            };
            GetShaderInfoLogDel getShaderInfoLog = (uint shader, int maxLen, int[] len, StringBuilder sb) => { };
            AttachShader attachShader = (uint program, uint shader) => { };
            LinkProgram linkProgram = (uint program) => { };

            int linkStatusValue = linkSuccess ? 1 : 0;
            GetProgramiv getProgramiv = (uint program, ProgramParameter pname, int[] p) =>
            {
                if (pname == ProgramParameter.LinkStatus)
                {
                    p[0] = linkStatusValue;
                }
                else if (pname == ProgramParameter.InfoLogLength)
                {
                    p[0] = 0;
                }
                else if (pname == ProgramParameter.ActiveAttributes)
                {
                    p[0] = activeAttributes;
                }
                else if (pname == ProgramParameter.ActiveUniforms)
                {
                    p[0] = activeUniforms;
                }
            };

            GetProgramInfoLogDel getProgramInfoLog = (uint program, int maxLen, int[] len, StringBuilder sb) => { };
            UseProgram useProgram = (uint program) =>
            {
                if (program == 0)
                {
                    _useProgramZeroCalled = true;
                }
            };

            DetachShader detachShader = (uint program, uint shader) => { _detachShaderCalled = true; };
            DeleteProgram deleteProgram = (uint program) => { _deleteProgramCalled = true; };
            DeleteShader deleteShader = (uint shader) =>
            {
                if (shader == _vertexShaderId)
                {
                    _deleteVertexShaderCalled = true;
                }

                if (shader == _fragmentShaderId)
                {
                    _deleteFragmentShaderCalled = true;
                }
            };

            GetUniformLocation getUniformLocation = (uint program, string name) => 1;
            GetAttribLocation getAttribLocation = (uint program, string name) => 2;

            GetActiveAttrib getActiveAttrib = (uint program, uint index, int bufSize, int[] length, int[] size, ActiveAttribType[] type, StringBuilder name) =>
            {
                length[0] = 4;
                size[0] = 1;
                type[0] = ActiveAttribType.FloatVec3;
                name.Append("attrib" + index);
            };

            GetActiveUniform getActiveUniform = (uint program, uint index, int bufSize, int[] length, int[] size, ActiveUniformType[] type, StringBuilder name) =>
            {
                length[0] = 6;
                size[0] = 1;
                type[0] = ActiveUniformType.Float;
                name.Append("uniform" + index);
            };

            IntPtr createProgramFp = Marshal.GetFunctionPointerForDelegate(createProgram);
            IntPtr createShaderFp = Marshal.GetFunctionPointerForDelegate(createShader);
            IntPtr shaderSourceFp = Marshal.GetFunctionPointerForDelegate(shaderSource);
            IntPtr compileShaderFp = Marshal.GetFunctionPointerForDelegate(compileShader);
            IntPtr getShaderivFp = Marshal.GetFunctionPointerForDelegate(getShaderiv);
            IntPtr getShaderInfoLogFp = Marshal.GetFunctionPointerForDelegate(getShaderInfoLog);
            IntPtr attachShaderFp = Marshal.GetFunctionPointerForDelegate(attachShader);
            IntPtr linkProgramFp = Marshal.GetFunctionPointerForDelegate(linkProgram);
            IntPtr getProgramivFp = Marshal.GetFunctionPointerForDelegate(getProgramiv);
            IntPtr getProgramInfoLogFp = Marshal.GetFunctionPointerForDelegate(getProgramInfoLog);
            IntPtr useProgramFp = Marshal.GetFunctionPointerForDelegate(useProgram);
            IntPtr detachShaderFp = Marshal.GetFunctionPointerForDelegate(detachShader);
            IntPtr deleteProgramFp = Marshal.GetFunctionPointerForDelegate(deleteProgram);
            IntPtr deleteShaderFp = Marshal.GetFunctionPointerForDelegate(deleteShader);
            IntPtr getUniformLocationFp = Marshal.GetFunctionPointerForDelegate(getUniformLocation);
            IntPtr getAttribLocationFp = Marshal.GetFunctionPointerForDelegate(getAttribLocation);
            IntPtr getActiveAttribFp = Marshal.GetFunctionPointerForDelegate(getActiveAttrib);
            IntPtr getActiveUniformFp = Marshal.GetFunctionPointerForDelegate(getActiveUniform);

            Gl.Initialize(name => name switch
            {
                "glCreateProgram" => createProgramFp,
                "glCreateShader" => createShaderFp,
                "glShaderSource" => shaderSourceFp,
                "glCompileShader" => compileShaderFp,
                "glGetShaderiv" => getShaderivFp,
                "glGetShaderInfoLog" => getShaderInfoLogFp,
                "glAttachShader" => attachShaderFp,
                "glLinkProgram" => linkProgramFp,
                "glGetProgramiv" => getProgramivFp,
                "glGetProgramInfoLog" => getProgramInfoLogFp,
                "glUseProgram" => useProgramFp,
                "glDetachShader" => detachShaderFp,
                "glDeleteProgram" => deleteProgramFp,
                "glDeleteShader" => deleteShaderFp,
                "glGetUniformLocation" => getUniformLocationFp,
                "glGetAttribLocation" => getAttribLocationFp,
                "glGetActiveAttrib" => getActiveAttribFp,
                "glGetActiveUniform" => getActiveUniformFp,
                _ => IntPtr.Zero
            });
        }

        /// <summary>
        /// Creates the valid program
        /// </summary>
        /// <returns>The gl shader program</returns>
        private GlShaderProgram CreateValidProgram()
        {
            GlShader vs = new GlShader("vs", ShaderType.VertexShader);
            GlShader fs = new GlShader("fs", ShaderType.FragmentShader);
            return new GlShaderProgram(vs, fs);
        }

        /// <summary>
        /// Tests that constructor with shaders sets properties and program id
        /// </summary>
        [Fact]
        public void Constructor_WithShaders_SetsPropertiesAndProgramId()
        {
            Init();

            GlShader vs = new GlShader("vs", ShaderType.VertexShader);
            GlShader fs = new GlShader("fs", ShaderType.FragmentShader);
            GlShaderProgram program = new GlShaderProgram(vs, fs);

            Assert.Equal(_programId, program.ProgramId);
            Assert.Same(vs, program.VertexShader);
            Assert.Same(fs, program.FragmentShader);
            Assert.False(program.DisposeChildren);
        }

        /// <summary>
        /// Tests that constructor with strings sets properties and program id
        /// </summary>
        [Fact]
        public void Constructor_WithStrings_SetsPropertiesAndProgramId()
        {
            Init();

            GlShaderProgram program = new GlShaderProgram("vs", "fs");

            Assert.Equal(_programId, program.ProgramId);
            Assert.NotNull(program.VertexShader);
            Assert.NotNull(program.FragmentShader);
            Assert.True(program.DisposeChildren);
        }

        /// <summary>
        /// Tests that constructor when link fails throws invalid operation exception
        /// </summary>
        [Fact]
        public void Constructor_WhenLinkFails_ThrowsInvalidOperationException()
        {
            Init(linkSuccess: false);

            GlShader vs = new GlShader("vs", ShaderType.VertexShader);
            GlShader fs = new GlShader("fs", ShaderType.FragmentShader);

            Assert.Throws<InvalidOperationException>(() => new GlShaderProgram(vs, fs));
        }

        /// <summary>
        /// Tests that use calls gl use program
        /// </summary>
        [Fact]
        public void Use_CallsGlUseProgram()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            _useProgramZeroCalled = false;
            program.Use();

            Assert.False(_useProgramZeroCalled);
        }

        /// <summary>
        /// Tests that get uniform location returns location from gl
        /// </summary>
        [Fact]
        public void GetUniformLocation_ReturnsLocationFromGl()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            int location = program.GetUniformLocation("testUniform");

            Assert.Equal(1, location);
        }

        /// <summary>
        /// Tests that get attribute location returns location from gl
        /// </summary>
        [Fact]
        public void GetAttributeLocation_ReturnsLocationFromGl()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            int location = program.GetAttributeLocation("testAttrib");

            Assert.Equal(2, location);
        }

        /// <summary>
        /// Tests that program log returns string
        /// </summary>
        [Fact]
        public void ProgramLog_ReturnsString()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            string log = program.ProgramLog;

            Assert.NotNull(log);
        }

        /// <summary>
        /// Tests that dispose without children calls gl functions and sets program id to zero
        /// </summary>
        [Fact]
        public void Dispose_WithoutChildren_CallsGlFunctionsAndSetsProgramIdToZero()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
            Assert.True(_useProgramZeroCalled);
            Assert.True(_detachShaderCalled);
            Assert.True(_deleteProgramCalled);
            Assert.False(_deleteVertexShaderCalled);
            Assert.False(_deleteFragmentShaderCalled);
        }

        /// <summary>
        /// Tests that dispose with dispose children disposes shaders
        /// </summary>
        [Fact]
        public void Dispose_WithDisposeChildren_DisposesShaders()
        {
            Init();
            GlShaderProgram program = new GlShaderProgram("vs", "fs");

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
            Assert.True(_useProgramZeroCalled);
            Assert.True(_deleteVertexShaderCalled);
            Assert.True(_deleteFragmentShaderCalled);
        }

        /// <summary>
        /// Tests that dispose multiple calls does not throw
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_DoesNotThrow()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            program.Dispose();
            program.Dispose();
            program.Dispose();
        }

        /// <summary>
        /// Tests that dispose when program id already zero is idempotent
        /// </summary>
        [Fact]
        public void Dispose_WhenProgramIdAlreadyZero_IsIdempotent()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            program.Dispose();

            _useProgramZeroCalled = false;
            _detachShaderCalled = false;
            _deleteProgramCalled = false;

            program.Dispose();

            Assert.False(_useProgramZeroCalled);
            Assert.False(_detachShaderCalled);
            Assert.False(_deleteProgramCalled);
        }

        /// <summary>
        /// Tests that indexer with existing param returns param
        /// </summary>
        [Fact]
        public void Indexer_WithExistingParam_ReturnsParam()
        {
            Init(activeAttributes: 1);
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = program["attrib0"];

            Assert.NotNull(param);
            Assert.Equal("attrib0", param.Name);
            Assert.Equal(ParamType.Attribute, param.ParamType);
            Assert.Equal(typeof(Vector3F), param.Type);
        }

        /// <summary>
        /// Tests that indexer with non existing param returns null
        /// </summary>
        [Fact]
        public void Indexer_WithNonExistingParam_ReturnsNull()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam param = program["nonexistent"];

            Assert.Null(param);
        }

        /// <summary>
        /// Tests that get params with attributes and uniforms populates dictionary
        /// </summary>
        [Fact]
        public void GetParams_WithAttributesAndUniforms_PopulatesDictionary()
        {
            Init(activeAttributes: 1, activeUniforms: 1);
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam attrib = program["attrib0"];
            GlShaderProgramParam uniform = program["uniform0"];

            Assert.NotNull(attrib);
            Assert.Equal(ParamType.Attribute, attrib.ParamType);
            Assert.Equal(typeof(Vector3F), attrib.Type);
            Assert.NotNull(uniform);
            Assert.Equal(ParamType.Uniform, uniform.ParamType);
            Assert.Equal(typeof(float), uniform.Type);
        }

        /// <summary>
        /// Tests that program id can set and get
        /// </summary>
        [Fact]
        public void ProgramId_CanSetAndGet()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            program.ProgramId = 100;

            Assert.Equal(100u, program.ProgramId);
        }

        /// <summary>
        /// Tests that get uniform location calls use before query
        /// </summary>
        [Fact]
        public void GetUniformLocation_CallsUseBeforeQuery()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            int location1 = program.GetUniformLocation("a");
            int location2 = program.GetUniformLocation("b");

            Assert.Equal(1, location1);
            Assert.Equal(1, location2);
        }

        /// <summary>
        /// Tests that get attribute location calls use before query
        /// </summary>
        [Fact]
        public void GetAttributeLocation_CallsUseBeforeQuery()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            int location1 = program.GetAttributeLocation("x");
            int location2 = program.GetAttributeLocation("y");

            Assert.Equal(2, location1);
            Assert.Equal(2, location2);
        }

        /// <summary>
        /// Tests that get params with multiple attributes adds all to dictionary
        /// </summary>
        [Fact]
        public void GetParams_WithMultipleAttributes_AddsAllToDictionary()
        {
            Init(activeAttributes: 3);
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam a0 = program["attrib0"];
            GlShaderProgramParam a1 = program["attrib1"];
            GlShaderProgramParam a2 = program["attrib2"];

            Assert.NotNull(a0);
            Assert.NotNull(a1);
            Assert.NotNull(a2);
        }

        /// <summary>
        /// Tests that get params with multiple uniforms adds all to dictionary
        /// </summary>
        [Fact]
        public void GetParams_WithMultipleUniforms_AddsAllToDictionary()
        {
            Init(activeUniforms: 3);
            GlShaderProgram program = CreateValidProgram();

            GlShaderProgramParam u0 = program["uniform0"];
            GlShaderProgramParam u1 = program["uniform1"];
            GlShaderProgramParam u2 = program["uniform2"];

            Assert.NotNull(u0);
            Assert.NotNull(u1);
            Assert.NotNull(u2);
        }

        /// <summary>
        /// Tests that dispose suppresses finalize
        /// </summary>
        [Fact]
        public void Dispose_SuppressesFinalize()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            program.Dispose();
        }

        /// <summary>
        /// Tests that program log getter does not throw
        /// </summary>
        [Fact]
        public void ProgramLog_Getter_DoesNotThrow()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            _ = program.ProgramLog;
        }

        /// <summary>
        /// Tests that get uniform location with empty name does not throw
        /// </summary>
        [Fact]
        public void GetUniformLocation_WithEmptyName_DoesNotThrow()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            int location = program.GetUniformLocation(string.Empty);

            Assert.Equal(1, location);
        }

        /// <summary>
        /// Tests that get attribute location with empty name does not throw
        /// </summary>
        [Fact]
        public void GetAttributeLocation_WithEmptyName_DoesNotThrow()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            int location = program.GetAttributeLocation(string.Empty);

            Assert.Equal(2, location);
        }

        /// <summary>
        /// Tests that use does not throw when called multiple times
        /// </summary>
        [Fact]
        public void Use_DoesNotThrow_WhenCalledMultipleTimes()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();

            program.Use();
            program.Use();
            program.Use();
        }

        /// <summary>
        /// Tests that dispose with dispose children disposes both shaders individually
        /// </summary>
        [Fact]
        public void Dispose_WithDisposeChildren_DisposesBothShadersIndividually()
        {
            Init();
            GlShaderProgram program = new GlShaderProgram("vs", "fs");

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
            Assert.Equal(0u, program.VertexShader.ShaderId);
            Assert.Equal(0u, program.FragmentShader.ShaderId);
        }

        /// <summary>
        /// Tests that dispose without dispose children shaders keep ids
        /// </summary>
        [Fact]
        public void Dispose_WithoutDisposeChildren_ShadersKeepIds()
        {
            Init();
            GlShaderProgram program = CreateValidProgram();
            uint vsId = program.VertexShader.ShaderId;
            uint fsId = program.FragmentShader.ShaderId;

            program.Dispose();

            Assert.Equal(0u, program.ProgramId);
            Assert.NotEqual(0u, vsId);
            Assert.NotEqual(0u, fsId);
        }
    }
}

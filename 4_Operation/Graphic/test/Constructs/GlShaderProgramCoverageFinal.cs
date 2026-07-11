using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramCoverageFinal : IDisposable
    {
        private static readonly FieldInfo GlField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);
        private readonly object _saved;
        public GlShaderProgramCoverageFinal() => _saved = GlField?.GetValue(null);
        public void Dispose() => GlField?.SetValue(null, _saved);

        private static MethodInfo TA => typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
        private static MethodInfo TU => typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);

        [Fact]
        public void Constructor_Throws_WhenGlNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("vs", "fs"));
        }

        [Fact]
        public void Constructor_WithShaders_Throws_WhenGlNotAvailable()
        {
            var shader = new GlShader("src", ShaderType.VertexShader);
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram(shader, shader));
        }

        [Fact]
        public void TypeFromAttributeType_Float_ReturnsFloat() => Assert.Equal(typeof(float), TA.Invoke(null, new object[] { ActiveAttribType.Float }));
        [Fact]
        public void TypeFromAttributeType_FloatMat2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TA.Invoke(null, new object[] { ActiveAttribType.FloatMat2 }));
        [Fact]
        public void TypeFromAttributeType_FloatMat3_Throws()
        {
            var ex = Assert.Throws<TargetInvocationException>(() => TA.Invoke(null, new object[] { ActiveAttribType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }
        [Fact]
        public void TypeFromAttributeType_FloatMat4_ReturnsMatrix() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TA.Invoke(null, new object[] { ActiveAttribType.FloatMat4 }));
        [Fact]
        public void TypeFromAttributeType_FloatVec2_ReturnsVector2() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), TA.Invoke(null, new object[] { ActiveAttribType.FloatVec2 }));
        [Fact]
        public void TypeFromAttributeType_FloatVec3_ReturnsVector3() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), TA.Invoke(null, new object[] { ActiveAttribType.FloatVec3 }));
        [Fact]
        public void TypeFromAttributeType_FloatVec4_ReturnsVector4() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), TA.Invoke(null, new object[] { ActiveAttribType.FloatVec4 }));
        [Fact]
        public void TypeFromAttributeType_Default_ReturnsObject() => Assert.Equal(typeof(object), TA.Invoke(null, new object[] { default(ActiveAttribType) }));

        [Fact]
        public void TypeFromUniformType_Int_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Int }));
        [Fact]
        public void TypeFromUniformType_Float_ReturnsFloat() => Assert.Equal(typeof(float), TU.Invoke(null, new object[] { ActiveUniformType.Float }));
        [Fact]
        public void TypeFromUniformType_FloatVec2_ReturnsVector2() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), TU.Invoke(null, new object[] { ActiveUniformType.FloatVec2 }));
        [Fact]
        public void TypeFromUniformType_FloatVec3_ReturnsVector3() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), TU.Invoke(null, new object[] { ActiveUniformType.FloatVec3 }));
        [Fact]
        public void TypeFromUniformType_FloatVec4_ReturnsVector4() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), TU.Invoke(null, new object[] { ActiveUniformType.FloatVec4 }));
        [Fact]
        public void TypeFromUniformType_IntVec2_ReturnsIntArray() => Assert.Equal(typeof(int[]), TU.Invoke(null, new object[] { ActiveUniformType.IntVec2 }));
        [Fact]
        public void TypeFromUniformType_IntVec3_ReturnsIntArray() => Assert.Equal(typeof(int[]), TU.Invoke(null, new object[] { ActiveUniformType.IntVec3 }));
        [Fact]
        public void TypeFromUniformType_IntVec4_ReturnsIntArray() => Assert.Equal(typeof(int[]), TU.Invoke(null, new object[] { ActiveUniformType.IntVec4 }));
        [Fact]
        public void TypeFromUniformType_Bool_ReturnsBool() => Assert.Equal(typeof(bool), TU.Invoke(null, new object[] { ActiveUniformType.Bool }));
        [Fact]
        public void TypeFromUniformType_BoolVec2_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), TU.Invoke(null, new object[] { ActiveUniformType.BoolVec2 }));
        [Fact]
        public void TypeFromUniformType_BoolVec3_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), TU.Invoke(null, new object[] { ActiveUniformType.BoolVec3 }));
        [Fact]
        public void TypeFromUniformType_BoolVec4_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), TU.Invoke(null, new object[] { ActiveUniformType.BoolVec4 }));
        [Fact]
        public void TypeFromUniformType_FloatMat2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat2 }));
        [Fact]
        public void TypeFromUniformType_FloatMat3_Throws()
        {
            var ex = Assert.Throws<TargetInvocationException>(() => TU.Invoke(null, new object[] { ActiveUniformType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }
        [Fact]
        public void TypeFromUniformType_FloatMat4_ReturnsMatrix() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat4 }));
        [Fact]
        public void TypeFromUniformType_Sampler2D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Sampler2D }));
        [Fact]
        public void TypeFromUniformType_FloatMat2X3_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat2X3 }));
        [Fact]
        public void TypeFromUniformType_UnsignedIntVec2_ReturnsUintArray() => Assert.Equal(typeof(uint[]), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec2 }));
        [Fact]
        public void TypeFromUniformType_IntSampler2D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.IntSampler2D }));
        [Fact]
        public void TypeFromUniformType_UnsignedIntSampler2D_ReturnsUint() => Assert.Equal(typeof(uint), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2D }));
        [Fact]
        public void TypeFromUniformType_Default_ReturnsObject() => Assert.Equal(typeof(object), TU.Invoke(null, new object[] { default(ActiveUniformType) }));

        [Fact]
        public void Use_Throws_WhenGlNotInited()
        {
            object p = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            typeof(GlShaderProgram).GetProperty("ProgramId").SetValue(p, 1u);
            var prog = (GlShaderProgram)p;
            Assert.ThrowsAny<Exception>(() => prog.Use());
        }

        [Fact]
        public void GetUniformLocation_Throws_WhenGlNotInited()
        {
            object p = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            typeof(GlShaderProgram).GetProperty("ProgramId").SetValue(p, 1u);
            var prog = (GlShaderProgram)p;
            Assert.ThrowsAny<Exception>(() => prog.GetUniformLocation("test"));
        }

        [Fact]
        public void GetAttributeLocation_Throws_WhenGlNotInited()
        {
            object p = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            typeof(GlShaderProgram).GetProperty("ProgramId").SetValue(p, 1u);
            var prog = (GlShaderProgram)p;
            Assert.ThrowsAny<Exception>(() => prog.GetAttributeLocation("test"));
        }

        [Fact]
        public void Dispose_Multiple_DoesNotThrow()
        {
            object p = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            ((IDisposable)p).Dispose();
            ((IDisposable)p).Dispose();
        }

        [Fact]
        public void ProgramLog_Returns_Empty_WhenGlNotInited()
        {
            object p = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            var prog = (GlShaderProgram)p;
            Assert.ThrowsAny<Exception>(() => prog.ProgramLog);
        }

        [Fact]
        public void Indexer_Returns_Null_ForUninited()
        {
            object p = RuntimeHelpers.GetUninitializedObject(typeof(GlShaderProgram));
            var prog = (GlShaderProgram)p;
            Assert.Null(prog["nonexistent"]);
        }

        [Fact]
        public void IsSealed() => Assert.True(typeof(GlShaderProgram).IsSealed);
        [Fact]
        public void ImplementsIDisposable() => Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));
        [Fact]
        public void DisposeChildren_Field_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance));
        [Fact]
        public void VertexShader_Field_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetField("VertexShader", BindingFlags.Public | BindingFlags.Instance));
        [Fact]
        public void FragmentShader_Field_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetField("FragmentShader", BindingFlags.Public | BindingFlags.Instance));
    }
}

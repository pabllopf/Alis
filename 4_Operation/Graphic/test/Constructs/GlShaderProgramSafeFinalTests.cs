using System;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramSafeFinalTests
    {
        private static MethodInfo TA => typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
        private static MethodInfo TU => typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);

        [Fact] public void TypeFromAttributeType_Float_ReturnsFloat() => Assert.Equal(typeof(float), TA.Invoke(null, new object[] { ActiveAttribType.Float }));
        [Fact] public void TypeFromAttributeType_FloatMat2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TA.Invoke(null, new object[] { ActiveAttribType.FloatMat2 }));
        [Fact] public void TypeFromAttributeType_FloatMat3_Throws() { var ex = Assert.Throws<TargetInvocationException>(() => TA.Invoke(null, new object[] { ActiveAttribType.FloatMat3 })); Assert.IsType<InvalidOperationException>(ex.InnerException); }
        [Fact] public void TypeFromAttributeType_FloatMat4_ReturnsMatrix() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TA.Invoke(null, new object[] { ActiveAttribType.FloatMat4 }));
        [Fact] public void TypeFromAttributeType_FloatVec2_ReturnsVector2() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), TA.Invoke(null, new object[] { ActiveAttribType.FloatVec2 }));
        [Fact] public void TypeFromAttributeType_FloatVec3_ReturnsVector3() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), TA.Invoke(null, new object[] { ActiveAttribType.FloatVec3 }));
        [Fact] public void TypeFromAttributeType_FloatVec4_ReturnsVector4() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), TA.Invoke(null, new object[] { ActiveAttribType.FloatVec4 }));
        [Fact] public void TypeFromAttributeType_Default_ReturnsObject() => Assert.Equal(typeof(object), TA.Invoke(null, new object[] { default(ActiveAttribType) }));

        [Fact] public void TypeFromUniformType_Int_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Int }));
        [Fact] public void TypeFromUniformType_Float_ReturnsFloat() => Assert.Equal(typeof(float), TU.Invoke(null, new object[] { ActiveUniformType.Float }));
        [Fact] public void TypeFromUniformType_FloatVec2_ReturnsVector2() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), TU.Invoke(null, new object[] { ActiveUniformType.FloatVec2 }));
        [Fact] public void TypeFromUniformType_FloatVec3_ReturnsVector3() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), TU.Invoke(null, new object[] { ActiveUniformType.FloatVec3 }));
        [Fact] public void TypeFromUniformType_FloatVec4_ReturnsVector4() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), TU.Invoke(null, new object[] { ActiveUniformType.FloatVec4 }));
        [Fact] public void TypeFromUniformType_IntVec2_ReturnsIntArray() => Assert.Equal(typeof(int[]), TU.Invoke(null, new object[] { ActiveUniformType.IntVec2 }));
        [Fact] public void TypeFromUniformType_IntVec3_ReturnsIntArray() => Assert.Equal(typeof(int[]), TU.Invoke(null, new object[] { ActiveUniformType.IntVec3 }));
        [Fact] public void TypeFromUniformType_IntVec4_ReturnsIntArray() => Assert.Equal(typeof(int[]), TU.Invoke(null, new object[] { ActiveUniformType.IntVec4 }));
        [Fact] public void TypeFromUniformType_Bool_ReturnsBool() => Assert.Equal(typeof(bool), TU.Invoke(null, new object[] { ActiveUniformType.Bool }));
        [Fact] public void TypeFromUniformType_BoolVec2_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), TU.Invoke(null, new object[] { ActiveUniformType.BoolVec2 }));
        [Fact] public void TypeFromUniformType_BoolVec3_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), TU.Invoke(null, new object[] { ActiveUniformType.BoolVec3 }));
        [Fact] public void TypeFromUniformType_BoolVec4_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), TU.Invoke(null, new object[] { ActiveUniformType.BoolVec4 }));
        [Fact] public void TypeFromUniformType_FloatMat2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat2 }));
        [Fact] public void TypeFromUniformType_FloatMat3_Throws() { var ex = Assert.Throws<TargetInvocationException>(() => TU.Invoke(null, new object[] { ActiveUniformType.FloatMat3 })); Assert.IsType<InvalidOperationException>(ex.InnerException); }
        [Fact] public void TypeFromUniformType_FloatMat4_ReturnsMatrix() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat4 }));
        [Fact] public void TypeFromUniformType_Sampler1D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Sampler1D }));
        [Fact] public void TypeFromUniformType_Sampler2D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Sampler2D }));
        [Fact] public void TypeFromUniformType_Sampler3D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Sampler3D }));
        [Fact] public void TypeFromUniformType_SamplerCube_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.SamplerCube }));
        [Fact] public void TypeFromUniformType_FloatMat2X3_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat2X3 }));
        [Fact] public void TypeFromUniformType_FloatMat2X4_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat2X4 }));
        [Fact] public void TypeFromUniformType_FloatMat3X2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat3X2 }));
        [Fact] public void TypeFromUniformType_FloatMat3X4_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat3X4 }));
        [Fact] public void TypeFromUniformType_FloatMat4X2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat4X2 }));
        [Fact] public void TypeFromUniformType_FloatMat4X3_ReturnsFloatArray() => Assert.Equal(typeof(float[]), TU.Invoke(null, new object[] { ActiveUniformType.FloatMat4X3 }));
        [Fact] public void TypeFromUniformType_UnsignedIntVec2_ReturnsUintArray() => Assert.Equal(typeof(uint[]), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec2 }));
        [Fact] public void TypeFromUniformType_UnsignedIntVec3_ReturnsUintArray() => Assert.Equal(typeof(uint[]), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec3 }));
        [Fact] public void TypeFromUniformType_UnsignedIntVec4_ReturnsUintArray() => Assert.Equal(typeof(uint[]), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec4 }));
        [Fact] public void TypeFromUniformType_IntSampler1D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.IntSampler1D }));
        [Fact] public void TypeFromUniformType_IntSampler2D_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.IntSampler2D }));
        [Fact] public void TypeFromUniformType_UnsignedIntSampler1D_ReturnsUint() => Assert.Equal(typeof(uint), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler1D }));
        [Fact] public void TypeFromUniformType_UnsignedIntSampler2D_ReturnsUint() => Assert.Equal(typeof(uint), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2D }));
        [Fact] public void TypeFromUniformType_Sampler2DMultisample_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Sampler2DMultisample }));
        [Fact] public void TypeFromUniformType_IntSampler2DMultisample_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.IntSampler2DMultisample }));
        [Fact] public void TypeFromUniformType_UnsignedIntSampler2DMultisample_ReturnsUint() => Assert.Equal(typeof(uint), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2DMultisample }));
        [Fact] public void TypeFromUniformType_Sampler2DMultisampleArray_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.Sampler2DMultisampleArray }));
        [Fact] public void TypeFromUniformType_IntSampler2DMultisampleArray_ReturnsInt() => Assert.Equal(typeof(int), TU.Invoke(null, new object[] { ActiveUniformType.IntSampler2DMultisampleArray }));
        [Fact] public void TypeFromUniformType_UnsignedIntSampler2DMultisampleArray_ReturnsUint() => Assert.Equal(typeof(uint), TU.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2DMultisampleArray }));
        [Fact] public void TypeFromUniformType_Default_ReturnsObject() => Assert.Equal(typeof(object), TU.Invoke(null, new object[] { default(ActiveUniformType) }));

        [Fact] public void IsSealed() => Assert.True(typeof(GlShaderProgram).IsSealed);
        [Fact] public void ImplementsIDisposable() => Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));
        [Fact] public void DisposeChildren_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetField("DisposeChildren"));
        [Fact] public void VertexShader_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetField("VertexShader"));
        [Fact] public void FragmentShader_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetField("FragmentShader"));
        [Fact] public void ProgramId_Property_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetProperty("ProgramId"));
        [Fact] public void Indexer_Property_Exists() => Assert.NotNull(typeof(GlShaderProgram).GetProperty("Item", typeof(GlShaderProgramParam), new[] { typeof(string) }));
        [Fact] public void Constructor_Throws_WhenGlNotAvailable() => Assert.ThrowsAny<Exception>(() => new GlShaderProgram("vs", "fs"));
    }
}

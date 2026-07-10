using System;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramFullTests
    {
        private static MethodInfo TypeFromUniformType =>
            typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
        private static MethodInfo TypeFromAttributeType =>
            typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);

        [Fact]
        public void Constructor_ThrowsWhenGlNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("vs", "fs"));
        }

        [Fact]
        public void TypeFromAttributeType_AllCases()
        {
            Assert.Equal(typeof(float), TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.Float }));
            Assert.Equal(typeof(float[]), TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatMat2 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatMat4 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatVec2 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatVec3 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatVec4 }));
            Assert.Equal(typeof(object), TypeFromAttributeType.Invoke(null, new object[] { default(ActiveAttribType) }));
        }

        [Fact]
        public void TypeFromUniformType_BasicTypes()
        {
            Assert.Equal(typeof(int), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.Int }));
            Assert.Equal(typeof(float), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.Float }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatVec2 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatVec3 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatVec4 }));
            Assert.Equal(typeof(bool), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.Bool }));
        }

        [Fact]
        public void TypeFromUniformType_IntVecTypes()
        {
            Assert.Equal(typeof(int[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.IntVec2 }));
            Assert.Equal(typeof(int[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.IntVec3 }));
            Assert.Equal(typeof(int[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.IntVec4 }));
        }

        [Fact]
        public void TypeFromUniformType_BoolVecTypes()
        {
            Assert.Equal(typeof(bool[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.BoolVec2 }));
            Assert.Equal(typeof(bool[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.BoolVec3 }));
            Assert.Equal(typeof(bool[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.BoolVec4 }));
        }

        [Fact]
        public void TypeFromUniformType_Mat2Types()
        {
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat2 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat4 }));
        }

        [Fact]
        public void TypeFromUniformType_Mat2x3Types()
        {
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat2X3 }));
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat2X4 }));
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat3X2 }));
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat3X4 }));
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat4X2 }));
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat4X3 }));
        }

        [Fact]
        public void TypeFromUniformType_SamplerTypes_ReturnInt()
        {
            ActiveUniformType[] samplerTypes = {
                ActiveUniformType.Sampler1D, ActiveUniformType.Sampler2D, ActiveUniformType.Sampler3D,
                ActiveUniformType.SamplerCube, ActiveUniformType.Sampler1DShadow, ActiveUniformType.Sampler2DShadow,
                ActiveUniformType.Sampler2DRect, ActiveUniformType.Sampler2DRectShadow,
                ActiveUniformType.Sampler1DArray, ActiveUniformType.Sampler2DArray, ActiveUniformType.SamplerBuffer,
                ActiveUniformType.Sampler1DArrayShadow, ActiveUniformType.Sampler2DArrayShadow,
                ActiveUniformType.SamplerCubeShadow, ActiveUniformType.Sampler2DMultisample,
                ActiveUniformType.IntSampler1D, ActiveUniformType.IntSampler2D, ActiveUniformType.IntSampler3D,
                ActiveUniformType.IntSamplerCube, ActiveUniformType.IntSampler2DRect,
                ActiveUniformType.IntSampler1DArray, ActiveUniformType.IntSampler2DArray,
                ActiveUniformType.IntSamplerBuffer, ActiveUniformType.IntSampler2DMultisample,
                ActiveUniformType.IntSampler2DMultisampleArray
            };
            foreach (var t in samplerTypes)
                Assert.Equal(typeof(int), TypeFromUniformType.Invoke(null, new object[] { t }));
        }

        [Fact]
        public void TypeFromUniformType_UnsignedSamplerTypes_ReturnUint()
        {
            ActiveUniformType[] types = {
                ActiveUniformType.UnsignedIntSampler1D, ActiveUniformType.UnsignedIntSampler2D,
                ActiveUniformType.UnsignedIntSampler3D, ActiveUniformType.UnsignedIntSamplerCube,
                ActiveUniformType.UnsignedIntSampler2DRect, ActiveUniformType.UnsignedIntSampler1DArray,
                ActiveUniformType.UnsignedIntSampler2DArray, ActiveUniformType.UnsignedIntSamplerBuffer,
                ActiveUniformType.UnsignedIntSampler2DMultisample,
                ActiveUniformType.UnsignedIntSampler2DMultisampleArray
            };
            foreach (var t in types)
                Assert.Equal(typeof(uint), TypeFromUniformType.Invoke(null, new object[] { t }));
        }

        [Fact]
        public void TypeFromUniformType_UnsignedIntVecTypes_ReturnUintArray()
        {
            Assert.Equal(typeof(uint[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec2 }));
            Assert.Equal(typeof(uint[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec3 }));
            Assert.Equal(typeof(uint[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec4 }));
        }

        [Fact]
        public void TypeFromUniformType_Default_ReturnsObject()
        {
            Assert.Equal(typeof(object), TypeFromUniformType.Invoke(null, new object[] { default(ActiveUniformType) }));
        }

        [Fact]
        public void TypeFromUniformType_FloatMat3_Throws()
        {
            var ex = Assert.Throws<TargetInvocationException>(
                () => TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        [Fact]
        public void TypeFromAttributeType_FloatMat3_Throws()
        {
            var ex = Assert.Throws<TargetInvocationException>(
                () => TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        [Fact]
        public void GlShaderProgram_IsSealed() => Assert.True(typeof(GlShaderProgram).IsSealed);

        [Fact]
        public void GlShaderProgram_ImplementsIDisposable() => Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));

        [Fact]
        public void DisposeChildren_Field_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance));
        }

        [Fact]
        public void VertexShader_Field_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetField("VertexShader", BindingFlags.Public | BindingFlags.Instance));
        }

        [Fact]
        public void FragmentShader_Field_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetField("FragmentShader", BindingFlags.Public | BindingFlags.Instance));
        }

        [Fact]
        public void ProgramId_Property_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetProperty("ProgramId"));
        }

        [Fact]
        public void Indexer_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetProperty("Item", typeof(GlShaderProgramParam), new[] { typeof(string) }));
        }
    }
}

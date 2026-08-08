using System;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// The gl shader program full tests class
    /// </summary>
    public class GlShaderProgramFullTests
    {
        /// <summary>
        /// Gets the value of the type from uniform type
        /// </summary>
        private static MethodInfo TypeFromUniformType =>
            typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
        /// <summary>
        /// Gets the value of the type from attribute type
        /// </summary>
        private static MethodInfo TypeFromAttributeType =>
            typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// Tests that constructor throws when gl not available
        /// </summary>
        [Fact]
        public void Constructor_ThrowsWhenGlNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("vs", "fs"));
        }

        /// <summary>
        /// Tests that type from attribute type all cases
        /// </summary>
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

        /// <summary>
        /// Tests that type from uniform type basic types
        /// </summary>
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

        /// <summary>
        /// Tests that type from uniform type int vec types
        /// </summary>
        [Fact]
        public void TypeFromUniformType_IntVecTypes()
        {
            Assert.Equal(typeof(int[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.IntVec2 }));
            Assert.Equal(typeof(int[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.IntVec3 }));
            Assert.Equal(typeof(int[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.IntVec4 }));
        }

        /// <summary>
        /// Tests that type from uniform type bool vec types
        /// </summary>
        [Fact]
        public void TypeFromUniformType_BoolVecTypes()
        {
            Assert.Equal(typeof(bool[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.BoolVec2 }));
            Assert.Equal(typeof(bool[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.BoolVec3 }));
            Assert.Equal(typeof(bool[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.BoolVec4 }));
        }

        /// <summary>
        /// Tests that type from uniform type mat 2 types
        /// </summary>
        [Fact]
        public void TypeFromUniformType_Mat2Types()
        {
            Assert.Equal(typeof(float[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat2 }));
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat4 }));
        }

        /// <summary>
        /// Tests that type from uniform type mat 2x 3 types
        /// </summary>
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

        /// <summary>
        /// Tests that type from uniform type sampler types return int
        /// </summary>
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
            foreach (ActiveUniformType t in samplerTypes)
                Assert.Equal(typeof(int), TypeFromUniformType.Invoke(null, new object[] { t }));
        }

        /// <summary>
        /// Tests that type from uniform type unsigned sampler types return uint
        /// </summary>
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
            foreach (ActiveUniformType t in types)
                Assert.Equal(typeof(uint), TypeFromUniformType.Invoke(null, new object[] { t }));
        }

        /// <summary>
        /// Tests that type from uniform type unsigned int vec types return uint array
        /// </summary>
        [Fact]
        public void TypeFromUniformType_UnsignedIntVecTypes_ReturnUintArray()
        {
            Assert.Equal(typeof(uint[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec2 }));
            Assert.Equal(typeof(uint[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec3 }));
            Assert.Equal(typeof(uint[]), TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec4 }));
        }

        /// <summary>
        /// Tests that type from uniform type default returns object
        /// </summary>
        [Fact]
        public void TypeFromUniformType_Default_ReturnsObject()
        {
            Assert.Equal(typeof(object), TypeFromUniformType.Invoke(null, new object[] { default(ActiveUniformType) }));
        }

        /// <summary>
        /// Tests that type from uniform type float mat 3 throws
        /// </summary>
        [Fact]
        public void TypeFromUniformType_FloatMat3_Throws()
        {
            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(
                () => TypeFromUniformType.Invoke(null, new object[] { ActiveUniformType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that type from attribute type float mat 3 throws
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatMat3_Throws()
        {
            TargetInvocationException ex = Assert.Throws<TargetInvocationException>(
                () => TypeFromAttributeType.Invoke(null, new object[] { ActiveAttribType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that gl shader program is sealed
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsSealed() => Assert.True(typeof(GlShaderProgram).IsSealed);

        /// <summary>
        /// Tests that gl shader program implements i disposable
        /// </summary>
        [Fact]
        public void GlShaderProgram_ImplementsIDisposable() => Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));

        /// <summary>
        /// Tests that dispose children field exists
        /// </summary>
        [Fact]
        public void DisposeChildren_Field_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance));
        }

        /// <summary>
        /// Tests that vertex shader field exists
        /// </summary>
        [Fact]
        public void VertexShader_Field_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetField("VertexShader", BindingFlags.Public | BindingFlags.Instance));
        }

        /// <summary>
        /// Tests that fragment shader field exists
        /// </summary>
        [Fact]
        public void FragmentShader_Field_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetField("FragmentShader", BindingFlags.Public | BindingFlags.Instance));
        }

        /// <summary>
        /// Tests that program id property exists
        /// </summary>
        [Fact]
        public void ProgramId_Property_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetProperty("ProgramId"));
        }

        /// <summary>
        /// Tests that indexer exists
        /// </summary>
        [Fact]
        public void Indexer_Exists()
        {
            Assert.NotNull(typeof(GlShaderProgram).GetProperty("Item", typeof(GlShaderProgramParam), new[] { typeof(string) }));
        }
    }
}

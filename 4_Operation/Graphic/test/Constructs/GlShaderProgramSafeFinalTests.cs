using System;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// The gl shader program safe final tests class
    /// </summary>
    public class GlShaderProgramSafeFinalTests
    {
        /// <summary>
        /// Gets the value of the ta
        /// </summary>
        private static MethodInfo Ta => typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
        /// <summary>
        /// Gets the value of the tu
        /// </summary>
        private static MethodInfo Tu => typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);

        /// <summary>
        /// Tests that type from attribute type float returns float
        /// </summary>
        [Fact] public void TypeFromAttributeType_Float_ReturnsFloat() => Assert.Equal(typeof(float), Ta.Invoke(null, new object[] { ActiveAttribType.Float }));
        /// <summary>
        /// Tests that type from attribute type float mat 2 returns float array
        /// </summary>
        [Fact] public void TypeFromAttributeType_FloatMat2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Ta.Invoke(null, new object[] { ActiveAttribType.FloatMat2 }));
        /// <summary>
        /// Tests that type from attribute type float mat 3 throws
        /// </summary>
        [Fact] public void TypeFromAttributeType_FloatMat3_Throws() { TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() => Ta.Invoke(null, new object[] { ActiveAttribType.FloatMat3 })); Assert.IsType<InvalidOperationException>(ex.InnerException); }
        /// <summary>
        /// Tests that type from attribute type float mat 4 returns matrix
        /// </summary>
        [Fact] public void TypeFromAttributeType_FloatMat4_ReturnsMatrix() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), Ta.Invoke(null, new object[] { ActiveAttribType.FloatMat4 }));
        /// <summary>
        /// Tests that type from attribute type float vec 2 returns vector 2
        /// </summary>
        [Fact] public void TypeFromAttributeType_FloatVec2_ReturnsVector2() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), Ta.Invoke(null, new object[] { ActiveAttribType.FloatVec2 }));
        /// <summary>
        /// Tests that type from attribute type float vec 3 returns vector 3
        /// </summary>
        [Fact] public void TypeFromAttributeType_FloatVec3_ReturnsVector3() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), Ta.Invoke(null, new object[] { ActiveAttribType.FloatVec3 }));
        /// <summary>
        /// Tests that type from attribute type float vec 4 returns vector 4
        /// </summary>
        [Fact] public void TypeFromAttributeType_FloatVec4_ReturnsVector4() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), Ta.Invoke(null, new object[] { ActiveAttribType.FloatVec4 }));
        /// <summary>
        /// Tests that type from attribute type default returns object
        /// </summary>
        [Fact] public void TypeFromAttributeType_Default_ReturnsObject() => Assert.Equal(typeof(object), Ta.Invoke(null, new object[] { default(ActiveAttribType) }));

        /// <summary>
        /// Tests that type from uniform type int returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_Int_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.Int }));
        /// <summary>
        /// Tests that type from uniform type float returns float
        /// </summary>
        [Fact] public void TypeFromUniformType_Float_ReturnsFloat() => Assert.Equal(typeof(float), Tu.Invoke(null, new object[] { ActiveUniformType.Float }));
        /// <summary>
        /// Tests that type from uniform type float vec 2 returns vector 2
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatVec2_ReturnsVector2() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), Tu.Invoke(null, new object[] { ActiveUniformType.FloatVec2 }));
        /// <summary>
        /// Tests that type from uniform type float vec 3 returns vector 3
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatVec3_ReturnsVector3() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), Tu.Invoke(null, new object[] { ActiveUniformType.FloatVec3 }));
        /// <summary>
        /// Tests that type from uniform type float vec 4 returns vector 4
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatVec4_ReturnsVector4() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), Tu.Invoke(null, new object[] { ActiveUniformType.FloatVec4 }));
        /// <summary>
        /// Tests that type from uniform type int vec 2 returns int array
        /// </summary>
        [Fact] public void TypeFromUniformType_IntVec2_ReturnsIntArray() => Assert.Equal(typeof(int[]), Tu.Invoke(null, new object[] { ActiveUniformType.IntVec2 }));
        /// <summary>
        /// Tests that type from uniform type int vec 3 returns int array
        /// </summary>
        [Fact] public void TypeFromUniformType_IntVec3_ReturnsIntArray() => Assert.Equal(typeof(int[]), Tu.Invoke(null, new object[] { ActiveUniformType.IntVec3 }));
        /// <summary>
        /// Tests that type from uniform type int vec 4 returns int array
        /// </summary>
        [Fact] public void TypeFromUniformType_IntVec4_ReturnsIntArray() => Assert.Equal(typeof(int[]), Tu.Invoke(null, new object[] { ActiveUniformType.IntVec4 }));
        /// <summary>
        /// Tests that type from uniform type bool returns bool
        /// </summary>
        [Fact] public void TypeFromUniformType_Bool_ReturnsBool() => Assert.Equal(typeof(bool), Tu.Invoke(null, new object[] { ActiveUniformType.Bool }));
        /// <summary>
        /// Tests that type from uniform type bool vec 2 returns bool array
        /// </summary>
        [Fact] public void TypeFromUniformType_BoolVec2_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), Tu.Invoke(null, new object[] { ActiveUniformType.BoolVec2 }));
        /// <summary>
        /// Tests that type from uniform type bool vec 3 returns bool array
        /// </summary>
        [Fact] public void TypeFromUniformType_BoolVec3_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), Tu.Invoke(null, new object[] { ActiveUniformType.BoolVec3 }));
        /// <summary>
        /// Tests that type from uniform type bool vec 4 returns bool array
        /// </summary>
        [Fact] public void TypeFromUniformType_BoolVec4_ReturnsBoolArray() => Assert.Equal(typeof(bool[]), Tu.Invoke(null, new object[] { ActiveUniformType.BoolVec4 }));
        /// <summary>
        /// Tests that type from uniform type float mat 2 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat2 }));
        /// <summary>
        /// Tests that type from uniform type float mat 3 throws
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat3_Throws() { TargetInvocationException ex = Assert.Throws<TargetInvocationException>(() => Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat3 })); Assert.IsType<InvalidOperationException>(ex.InnerException); }
        /// <summary>
        /// Tests that type from uniform type float mat 4 returns matrix
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat4_ReturnsMatrix() => Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat4 }));
        /// <summary>
        /// Tests that type from uniform type sampler 1 d returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_Sampler1D_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.Sampler1D }));
        /// <summary>
        /// Tests that type from uniform type sampler 2 d returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_Sampler2D_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.Sampler2D }));
        /// <summary>
        /// Tests that type from uniform type sampler 3 d returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_Sampler3D_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.Sampler3D }));
        /// <summary>
        /// Tests that type from uniform type sampler cube returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_SamplerCube_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.SamplerCube }));
        /// <summary>
        /// Tests that type from uniform type float mat 2 x 3 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat2X3_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat2X3 }));
        /// <summary>
        /// Tests that type from uniform type float mat 2 x 4 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat2X4_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat2X4 }));
        /// <summary>
        /// Tests that type from uniform type float mat 3 x 2 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat3X2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat3X2 }));
        /// <summary>
        /// Tests that type from uniform type float mat 3 x 4 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat3X4_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat3X4 }));
        /// <summary>
        /// Tests that type from uniform type float mat 4 x 2 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat4X2_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat4X2 }));
        /// <summary>
        /// Tests that type from uniform type float mat 4 x 3 returns float array
        /// </summary>
        [Fact] public void TypeFromUniformType_FloatMat4X3_ReturnsFloatArray() => Assert.Equal(typeof(float[]), Tu.Invoke(null, new object[] { ActiveUniformType.FloatMat4X3 }));
        /// <summary>
        /// Tests that type from uniform type unsigned int vec 2 returns uint array
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntVec2_ReturnsUintArray() => Assert.Equal(typeof(uint[]), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec2 }));
        /// <summary>
        /// Tests that type from uniform type unsigned int vec 3 returns uint array
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntVec3_ReturnsUintArray() => Assert.Equal(typeof(uint[]), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec3 }));
        /// <summary>
        /// Tests that type from uniform type unsigned int vec 4 returns uint array
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntVec4_ReturnsUintArray() => Assert.Equal(typeof(uint[]), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntVec4 }));
        /// <summary>
        /// Tests that type from uniform type int sampler 1 d returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_IntSampler1D_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.IntSampler1D }));
        /// <summary>
        /// Tests that type from uniform type int sampler 2 d returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_IntSampler2D_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.IntSampler2D }));
        /// <summary>
        /// Tests that type from uniform type unsigned int sampler 1 d returns uint
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntSampler1D_ReturnsUint() => Assert.Equal(typeof(uint), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler1D }));
        /// <summary>
        /// Tests that type from uniform type unsigned int sampler 2 d returns uint
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntSampler2D_ReturnsUint() => Assert.Equal(typeof(uint), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2D }));
        /// <summary>
        /// Tests that type from uniform type sampler 2 d multisample returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_Sampler2DMultisample_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.Sampler2DMultisample }));
        /// <summary>
        /// Tests that type from uniform type int sampler 2 d multisample returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_IntSampler2DMultisample_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.IntSampler2DMultisample }));
        /// <summary>
        /// Tests that type from uniform type unsigned int sampler 2 d multisample returns uint
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntSampler2DMultisample_ReturnsUint() => Assert.Equal(typeof(uint), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2DMultisample }));
        /// <summary>
        /// Tests that type from uniform type sampler 2 d multisample array returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_Sampler2DMultisampleArray_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.Sampler2DMultisampleArray }));
        /// <summary>
        /// Tests that type from uniform type int sampler 2 d multisample array returns int
        /// </summary>
        [Fact] public void TypeFromUniformType_IntSampler2DMultisampleArray_ReturnsInt() => Assert.Equal(typeof(int), Tu.Invoke(null, new object[] { ActiveUniformType.IntSampler2DMultisampleArray }));
        /// <summary>
        /// Tests that type from uniform type unsigned int sampler 2 d multisample array returns uint
        /// </summary>
        [Fact] public void TypeFromUniformType_UnsignedIntSampler2DMultisampleArray_ReturnsUint() => Assert.Equal(typeof(uint), Tu.Invoke(null, new object[] { ActiveUniformType.UnsignedIntSampler2DMultisampleArray }));
        /// <summary>
        /// Tests that type from uniform type default returns object
        /// </summary>
        [Fact] public void TypeFromUniformType_Default_ReturnsObject() => Assert.Equal(typeof(object), Tu.Invoke(null, new object[] { default(ActiveUniformType) }));

        /// <summary>
        /// Tests that is sealed
        /// </summary>
        [Fact] public void IsSealed() => Assert.True(typeof(GlShaderProgram).IsSealed);
        /// <summary>
        /// Tests that implements i disposable
        /// </summary>
        [Fact] public void ImplementsIDisposable() => Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));
        /// <summary>
        /// Tests that constructor throws when gl not available
        /// </summary>
        [Fact] public void Constructor_Throws_WhenGlNotAvailable() => Assert.ThrowsAny<Exception>(() => new GlShaderProgram("vs", "fs"));
    }
}

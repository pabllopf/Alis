using System;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    /// The gl shader program safe tests class
    /// </summary>
    public class GlShaderProgramSafeTests
    {
        /// <summary>
        /// Tests that gl shader program is sealed
        /// </summary>
        [Fact]
        public void GlShaderProgram_IsSealed()
        {
            Assert.True(typeof(GlShaderProgram).IsSealed);
        }

        /// <summary>
        /// Tests that gl shader program implements i disposable
        /// </summary>
        [Fact]
        public void GlShaderProgram_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));
        }

        /// <summary>
        /// Tests that dispose children field exists
        /// </summary>
        [Fact]
        public void DisposeChildren_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(bool), field.FieldType);
        }

        /// <summary>
        /// Tests that vertex shader field exists
        /// </summary>
        [Fact]
        public void VertexShader_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("VertexShader", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(GlShader), field.FieldType);
        }

        /// <summary>
        /// Tests that fragment shader field exists
        /// </summary>
        [Fact]
        public void FragmentShader_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("FragmentShader", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(GlShader), field.FieldType);
        }

        /// <summary>
        /// Tests that program id property exists
        /// </summary>
        [Fact]
        public void ProgramId_Property_Exists()
        {
            PropertyInfo prop = typeof(GlShaderProgram).GetProperty("ProgramId");
            Assert.NotNull(prop);
            Assert.Equal(typeof(uint), prop.PropertyType);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        /// <summary>
        /// Tests that indexer property exists
        /// </summary>
        [Fact]
        public void Indexer_Property_Exists()
        {
            PropertyInfo prop = typeof(GlShaderProgram).GetProperty("Item", typeof(GlShaderProgramParam), new[] { typeof(string) });
            Assert.NotNull(prop);
        }

        /// <summary>
        /// Tests that program log property exists
        /// </summary>
        [Fact]
        public void ProgramLog_Property_Exists()
        {
            PropertyInfo prop = typeof(GlShaderProgram).GetProperty("ProgramLog");
            Assert.NotNull(prop);
            Assert.Equal(typeof(string), prop.PropertyType);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        /// <summary>
        /// Tests that type from attribute type float returns float type
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_Float_ReturnsFloatType()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.Float });
            Assert.Equal(typeof(float), result);
        }

        /// <summary>
        /// Tests that type from attribute type float mat 2 returns float array
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatMat2_ReturnsFloatArray()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatMat2 });
            Assert.Equal(typeof(float[]), result);
        }

        /// <summary>
        /// Tests that type from attribute type float mat 3 throws
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatMat3_Throws()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { ActiveAttribType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that type from attribute type float mat 4 returns matrix 4 x 4
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatMat4_ReturnsMatrix4X4()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatMat4 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), result);
        }

        /// <summary>
        /// Tests that type from attribute type float vec 2 returns vector 2 f
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatVec2_ReturnsVector2F()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatVec2 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), result);
        }

        /// <summary>
        /// Tests that type from attribute type float vec 3 returns vector 3 f
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatVec3_ReturnsVector3F()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatVec3 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), result);
        }

        /// <summary>
        /// Tests that type from attribute type float vec 4 returns vector 4 f
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_FloatVec4_ReturnsVector4F()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatVec4 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), result);
        }

        /// <summary>
        /// Tests that type from attribute type default returns object
        /// </summary>
        [Fact]
        public void TypeFromAttributeType_Default_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { default(ActiveAttribType) });
            Assert.Equal(typeof(object), result);
        }

        /// <summary>
        /// Tests that type from uniform type int returns int
        /// </summary>
        [Fact]
        public void TypeFromUniformType_Int_ReturnsInt()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveUniformType.Int });
            Assert.Equal(typeof(int), result);
        }

        /// <summary>
        /// Tests that type from uniform type float returns float
        /// </summary>
        [Fact]
        public void TypeFromUniformType_Float_ReturnsFloat()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveUniformType.Float });
            Assert.Equal(typeof(float), result);
        }

        /// <summary>
        /// Tests that type from uniform type float mat 3 throws
        /// </summary>
        [Fact]
        public void TypeFromUniformType_FloatMat3_Throws()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { ActiveUniformType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        /// <summary>
        /// Tests that type from uniform type default returns object
        /// </summary>
        [Fact]
        public void TypeFromUniformType_Default_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { default(ActiveUniformType) });
            Assert.Equal(typeof(object), result);
        }

        /// <summary>
        /// Tests that constructor string params throws when gl not available
        /// </summary>
        [Fact]
        public void Constructor_StringParams_ThrowsWhenGlNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("void main(){}", "void main(){}"));
        }

        /// <summary>
        /// Tests that finalizer exists
        /// </summary>
        [Fact]
        public void Finalizer_Exists()
        {
            MethodInfo finalizer = typeof(GlShaderProgram).GetMethod("Finalize", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(finalizer);
        }
    }
}

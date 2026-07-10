using System;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    public class GlShaderProgramSafeTests
    {
        [Fact]
        public void GlShaderProgram_IsSealed()
        {
            Assert.True(typeof(GlShaderProgram).IsSealed);
        }

        [Fact]
        public void GlShaderProgram_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(GlShaderProgram)));
        }

        [Fact]
        public void DisposeChildren_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("DisposeChildren", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(bool), field.FieldType);
        }

        [Fact]
        public void VertexShader_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("VertexShader", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(GlShader), field.FieldType);
        }

        [Fact]
        public void FragmentShader_Field_Exists()
        {
            FieldInfo field = typeof(GlShaderProgram).GetField("FragmentShader", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.Equal(typeof(GlShader), field.FieldType);
        }

        [Fact]
        public void ProgramId_Property_Exists()
        {
            PropertyInfo prop = typeof(GlShaderProgram).GetProperty("ProgramId");
            Assert.NotNull(prop);
            Assert.Equal(typeof(uint), prop.PropertyType);
            Assert.True(prop.CanRead);
            Assert.True(prop.CanWrite);
        }

        [Fact]
        public void Indexer_Property_Exists()
        {
            PropertyInfo prop = typeof(GlShaderProgram).GetProperty("Item", typeof(GlShaderProgramParam), new[] { typeof(string) });
            Assert.NotNull(prop);
        }

        [Fact]
        public void ProgramLog_Property_Exists()
        {
            PropertyInfo prop = typeof(GlShaderProgram).GetProperty("ProgramLog");
            Assert.NotNull(prop);
            Assert.Equal(typeof(string), prop.PropertyType);
            Assert.True(prop.CanRead);
            Assert.False(prop.CanWrite);
        }

        [Fact]
        public void TypeFromAttributeType_Float_ReturnsFloatType()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.Float });
            Assert.Equal(typeof(float), result);
        }

        [Fact]
        public void TypeFromAttributeType_FloatMat2_ReturnsFloatArray()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatMat2 });
            Assert.Equal(typeof(float[]), result);
        }

        [Fact]
        public void TypeFromAttributeType_FloatMat3_Throws()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { ActiveAttribType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        [Fact]
        public void TypeFromAttributeType_FloatMat4_ReturnsMatrix4X4()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatMat4 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Matrix.Matrix4X4), result);
        }

        [Fact]
        public void TypeFromAttributeType_FloatVec2_ReturnsVector2F()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatVec2 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector2F), result);
        }

        [Fact]
        public void TypeFromAttributeType_FloatVec3_ReturnsVector3F()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatVec3 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector3F), result);
        }

        [Fact]
        public void TypeFromAttributeType_FloatVec4_ReturnsVector4F()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveAttribType.FloatVec4 });
            Assert.Equal(typeof(Alis.Core.Aspect.Math.Vector.Vector4F), result);
        }

        [Fact]
        public void TypeFromAttributeType_Default_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromAttributeType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { default(ActiveAttribType) });
            Assert.Equal(typeof(object), result);
        }

        [Fact]
        public void TypeFromUniformType_Int_ReturnsInt()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveUniformType.Int });
            Assert.Equal(typeof(int), result);
        }

        [Fact]
        public void TypeFromUniformType_Float_ReturnsFloat()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { ActiveUniformType.Float });
            Assert.Equal(typeof(float), result);
        }

        [Fact]
        public void TypeFromUniformType_FloatMat3_Throws()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            var ex = Assert.Throws<TargetInvocationException>(() => method.Invoke(null, new object[] { ActiveUniformType.FloatMat3 }));
            Assert.IsType<InvalidOperationException>(ex.InnerException);
        }

        [Fact]
        public void TypeFromUniformType_Default_ReturnsObject()
        {
            MethodInfo method = typeof(GlShaderProgram).GetMethod("TypeFromUniformType", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);
            Type result = (Type)method.Invoke(null, new object[] { default(ActiveUniformType) });
            Assert.Equal(typeof(object), result);
        }

        [Fact]
        public void Constructor_StringParams_ThrowsWhenGlNotAvailable()
        {
            Assert.ThrowsAny<Exception>(() => new GlShaderProgram("void main(){}", "void main(){}"));
        }

        [Fact]
        public void Finalizer_Exists()
        {
            MethodInfo finalizer = typeof(GlShaderProgram).GetMethod("Finalize", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(finalizer);
        }
    }
}

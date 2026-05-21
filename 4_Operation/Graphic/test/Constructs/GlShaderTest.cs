

using System;
using System.Linq;
using System.Reflection;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Constructs
{
    /// <summary>
    ///     Tests for the GlShader class handling individual shader compilation.
    /// </summary>
    public class GlShaderTest
    {
        /// <summary>
        ///     Tests that GlShader class is sealed and cannot be inherited.
        /// </summary>
        [Fact]
        public void GlShader_IsSealed_CannotBeInherited()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(shaderType.IsSealed);
        }

        /// <summary>
        ///     Tests that GlShader class is public.
        /// </summary>
        [Fact]
        public void GlShader_IsPublic_CanBeAccessed()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(shaderType.IsPublic);
        }

        /// <summary>
        ///     Tests that GlShader implements IDisposable interface.
        /// </summary>
        [Fact]
        public void GlShader_ImplementsIDisposable_InterfaceIsCorrect()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(typeof(IDisposable).IsAssignableFrom(shaderType));
        }

        /// <summary>
        ///     Tests that GlShader has ShaderId property.
        /// </summary>
        [Fact]
        public void GlShader_ShaderId_PropertyExists()
        {
            PropertyInfo shaderIdProperty = typeof(GlShader).GetProperty("ShaderId");

            Assert.NotNull(shaderIdProperty);
            Assert.Equal(typeof(uint), shaderIdProperty.PropertyType);
        }

        /// <summary>
        ///     Tests that GlShader has ShaderType property.
        /// </summary>
        [Fact]
        public void GlShader_ShaderType_PropertyExists()
        {
            PropertyInfo shaderTypeProperty = typeof(GlShader).GetProperty("ShaderType");

            Assert.NotNull(shaderTypeProperty);
            Assert.Equal(typeof(ShaderType), shaderTypeProperty.PropertyType);
        }

        /// <summary>
        ///     Tests that GlShader has ShaderLog property.
        /// </summary>
        [Fact]
        public void GlShader_ShaderLog_PropertyExists()
        {
            PropertyInfo shaderLogProperty = typeof(GlShader).GetProperty("ShaderLog");

            Assert.NotNull(shaderLogProperty);
            Assert.Equal(typeof(string), shaderLogProperty.PropertyType);
        }

        /// <summary>
        ///     Tests that GlShader ShaderLog property is read-only.
        /// </summary>
        [Fact]
        public void GlShader_ShaderLog_IsReadOnly()
        {
            PropertyInfo shaderLogProperty = typeof(GlShader).GetProperty("ShaderLog");

            Assert.NotNull(shaderLogProperty);
            Assert.True(shaderLogProperty.CanRead);
            Assert.False(shaderLogProperty.CanWrite);
        }


        /// <summary>
        ///     Tests that GlShader constructor requires source and type parameters.
        /// </summary>
        [Fact]
        public void GlShader_Constructor_ParametersAreCorrect()
        {
            ConstructorInfo[] constructors = typeof(GlShader).GetConstructors();

            ConstructorInfo constructor = constructors.FirstOrDefault();

            Assert.NotNull(constructor);
            ParameterInfo[] parameters = constructor.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType); // source
            Assert.Equal(typeof(ShaderType), parameters[1].ParameterType); // type
        }

        /// <summary>
        ///     Tests that GlShader has destructor for cleanup.
        /// </summary>
        [Fact]
        public void GlShader_HasDestructor_CleanupIsProvided()
        {
            Type shaderType = typeof(GlShader);

            Assert.True(shaderType.IsSealed);
        }

        /// <summary>
        ///     Tests that GlShader properties provide access to shader metadata.
        /// </summary>
        [Fact]
        public void GlShader_Properties_ProvideMetadata()
        {
            Type shaderType = typeof(GlShader);

            PropertyInfo[] properties = shaderType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            Assert.NotEmpty(properties);
            Assert.NotNull(properties.FirstOrDefault(p => p.Name == "ShaderId"));
            Assert.NotNull(properties.FirstOrDefault(p => p.Name == "ShaderType"));
            Assert.NotNull(properties.FirstOrDefault(p => p.Name == "ShaderLog"));
        }

        /// <summary>
        ///     Tests that GlShader class has only public properties and methods expected.
        /// </summary>
        [Fact]
        public void GlShader_PublicMembers_AreCorrect()
        {
            Type shaderType = typeof(GlShader);

            PropertyInfo[] publicProperties = shaderType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] publicMethods = shaderType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            Assert.NotEmpty(publicProperties);
            Assert.Contains(publicMethods, m => m.Name == "Dispose");
        }
    }
}


using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL.Delegates;
using Xunit;

namespace Alis.Core.Graphic.Test.Delegates
{
    /// <summary>
    ///     Tests for the AttachShader delegate validating shader attachment function signature.
    /// </summary>
    public class AttachShaderTest
    {
        /// <summary>
        ///     Tests that AttachShader is a delegate type.
        /// </summary>
        [Fact]
        public void AttachShader_IsDelegate_TypeIsCorrect()
        {
            Type delegateType = typeof(AttachShader);

            Assert.True(delegateType.IsSubclassOf(typeof(MulticastDelegate)));
        }

        /// <summary>
        ///     Tests that AttachShader is public.
        /// </summary>
        [Fact]
        public void AttachShader_IsPublic_CanBeAccessed()
        {
            Type delegateType = typeof(AttachShader);

            Assert.True(delegateType.IsPublic);
        }

        /// <summary>
        ///     Tests that AttachShader has UnmanagedFunctionPointer attribute.
        /// </summary>
        [Fact]
        public void AttachShader_HasUnmanagedFunctionPointerAttribute_InteropIsConfigured()
        {
            Type delegateType = typeof(AttachShader);
            object attribute = delegateType.GetCustomAttributes(typeof(UnmanagedFunctionPointerAttribute), false).FirstOrDefault();

            Assert.NotNull(attribute);
        }

        /// <summary>
        ///     Tests that AttachShader has two parameters.
        /// </summary>
        [Fact]
        public void AttachShader_HasTwoParameters_SignatureIsCorrect()
        {
            Type delegateType = typeof(AttachShader);
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            Assert.NotNull(invokeMethod);
            ParameterInfo[] parameters = invokeMethod.GetParameters();
            Assert.Equal(2, parameters.Length);
        }

        /// <summary>
        ///     Tests that AttachShader first parameter is uint (program).
        /// </summary>
        [Fact]
        public void AttachShader_FirstParameter_IsUint()
        {
            Type delegateType = typeof(AttachShader);
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");
            ParameterInfo[] parameters = invokeMethod.GetParameters();

            Assert.Equal(typeof(uint), parameters[0].ParameterType);
            Assert.Equal("program", parameters[0].Name);
        }

        /// <summary>
        ///     Tests that AttachShader second parameter is uint (shader).
        /// </summary>
        [Fact]
        public void AttachShader_SecondParameter_IsUint()
        {
            Type delegateType = typeof(AttachShader);
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");
            ParameterInfo[] parameters = invokeMethod.GetParameters();

            Assert.Equal(typeof(uint), parameters[1].ParameterType);
            Assert.Equal("shader", parameters[1].Name);
        }

        /// <summary>
        ///     Tests that AttachShader return type is void.
        /// </summary>
        [Fact]
        public void AttachShader_ReturnType_IsVoid()
        {
            Type delegateType = typeof(AttachShader);
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            Assert.NotNull(invokeMethod);
            Assert.Equal(typeof(void), invokeMethod.ReturnType);
        }

        /// <summary>
        ///     Tests that AttachShader uses StdCall calling convention.
        /// </summary>
        [Fact]
        public void AttachShader_UsesStdCallConvention_InteropConventionIsCorrect()
        {
            Type delegateType = typeof(AttachShader);
            UnmanagedFunctionPointerAttribute attribute = (UnmanagedFunctionPointerAttribute) delegateType.GetCustomAttributes(typeof(UnmanagedFunctionPointerAttribute), false)[0];

            Assert.Equal(CallingConvention.StdCall, attribute.CallingConvention);
        }

        /// <summary>
        ///     Tests that AttachShader delegate can be instantiated.
        /// </summary>
        [Fact]
        public void AttachShader_CanBeInstantiated_DelegateCreationIsValid()
        {
            void TestFunction(uint program, uint shader)
            {
            }

            AttachShader delegateInstance = TestFunction;

            Assert.NotNull(delegateInstance);
            Assert.IsType<AttachShader>(delegateInstance);
        }

        /// <summary>
        ///     Tests that AttachShader delegate Invoke method exists.
        /// </summary>
        [Fact]
        public void AttachShader_InvokeMethod_Exists()
        {
            Type delegateType = typeof(AttachShader);
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            Assert.NotNull(invokeMethod);
        }
    }
}


using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms
{
    /// <summary>
    ///     Tests for the INativePlatform interface validating cross-platform window management.
    /// </summary>
    public class INativePlatformTest
    {
        /// <summary>
        ///     Tests that INativePlatform is an interface type.
        /// </summary>
        [Fact]
        public void INativePlatform_IsInterface_TypeIsCorrect()
        {
            Type interfaceType = typeof(INativePlatform);

            Assert.True(interfaceType.IsInterface);
        }

        /// <summary>
        ///     Tests that INativePlatform is public.
        /// </summary>
        [Fact]
        public void INativePlatform_IsPublic_CanBeAccessed()
        {
            Type interfaceType = typeof(INativePlatform);

            Assert.True(interfaceType.IsPublic);
        }


        /// <summary>
        ///     Tests that INativePlatform ShowWindow returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_ShowWindow_ReturnsVoid()
        {
            MethodInfo method = typeof(INativePlatform).GetMethod("ShowWindow");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Tests that INativePlatform HideWindow returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_HideWindow_ReturnsVoid()
        {
            MethodInfo method = typeof(INativePlatform).GetMethod("HideWindow");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Tests that INativePlatform SetTitle returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_SetTitle_ReturnsVoid()
        {
            MethodInfo method = typeof(INativePlatform).GetMethod("SetTitle");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Tests that INativePlatform SetSize returns void.
        /// </summary>
        [Fact]
        public void INativePlatform_SetSize_ReturnsVoid()
        {
            MethodInfo method = typeof(INativePlatform).GetMethod("SetSize");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Tests that INativePlatform IsWindowVisible returns bool.
        /// </summary>
        [Fact]
        public void INativePlatform_IsWindowVisible_ReturnsBoolean()
        {
            MethodInfo method = typeof(INativePlatform).GetMethod("IsWindowVisible");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        ///     Tests that INativePlatform PollEvents returns bool.
        /// </summary>
        [Fact]
        public void INativePlatform_PollEvents_ReturnsBoolean()
        {
            MethodInfo method = typeof(INativePlatform).GetMethod("PollEvents");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }
    }
}
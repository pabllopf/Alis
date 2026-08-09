// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AttachShaderTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Linq;
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

    }
}
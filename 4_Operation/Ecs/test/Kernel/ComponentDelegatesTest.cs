// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentDelegatesTest.cs
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
using System.Reflection;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests for <see cref="ComponentDelegates{T}" /> delegate type definitions.
    /// </summary>
    public class ComponentDelegatesTest
    {
        /// <summary>
        ///     Tests that ComponentDelegates is a static class
        /// </summary>
        [Fact]
        public void ComponentDelegates_IsStaticClass()
        {
            Type type = typeof(ComponentDelegates<Position>);

            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        ///     Tests that DestroyDelegate delegate type exists
        /// </summary>
        [Fact]
        public void DestroyDelegate_Exists()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("DestroyDelegate");

            Assert.NotNull(delegateType);
            Assert.True(typeof(MulticastDelegate).IsAssignableFrom(delegateType.BaseType));
        }

        /// <summary>
        ///     Tests that InitDelegate delegate type exists
        /// </summary>
        [Fact]
        public void InitDelegate_Exists()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("InitDelegate");

            Assert.NotNull(delegateType);
            Assert.True(typeof(MulticastDelegate).IsAssignableFrom(delegateType.BaseType));
        }

        /// <summary>
        ///     Tests that DestroyDelegate has void return type
        /// </summary>
        [Fact]
        public void DestroyDelegate_HasVoidReturnType()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("DestroyDelegate");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            Assert.Equal(typeof(void), invokeMethod.ReturnType);
        }

        /// <summary>
        ///     Tests that InitDelegate has void return type
        /// </summary>
        [Fact]
        public void InitDelegate_HasVoidReturnType()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("InitDelegate");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            Assert.Equal(typeof(void), invokeMethod.ReturnType);
        }

        /// <summary>
        ///     Tests that DestroyDelegate has 1 parameter (ref T)
        /// </summary>
        [Fact]
        public void DestroyDelegate_Has1Parameter()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("DestroyDelegate");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            ParameterInfo[] parameters = invokeMethod.GetParameters();
            Assert.Equal(1, parameters.Length);
        }

        /// <summary>
        ///     Tests that InitDelegate has 2 parameters (GameObject, ref T)
        /// </summary>
        [Fact]
        public void InitDelegate_Has2Parameters()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("InitDelegate");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            ParameterInfo[] parameters = invokeMethod.GetParameters();
            Assert.Equal(2, parameters.Length);
        }

        /// <summary>
        ///     Tests that DestroyDelegate nested type is a delegate type
        /// </summary>
        [Fact]
        public void DestroyDelegate_IsDelegateType()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("DestroyDelegate");

            Assert.True(typeof(MulticastDelegate).IsAssignableFrom(delegateType.BaseType));
        }

        /// <summary>
        ///     Tests that InitDelegate nested type is a delegate type
        /// </summary>
        [Fact]
        public void InitDelegate_IsDelegateType()
        {
            Type delegateType = typeof(ComponentDelegates<Position>).GetNestedType("InitDelegate");

            Assert.True(typeof(MulticastDelegate).IsAssignableFrom(delegateType.BaseType));
        }
    }
}

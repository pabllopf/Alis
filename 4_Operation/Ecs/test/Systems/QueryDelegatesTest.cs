// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryDelegatesTest.cs
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
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for <see cref="QueryDelegates" /> delegate type definitions.
    /// </summary>
    public class QueryDelegatesTest
    {
        /// <summary>
        ///     Tests that Query delegates with 1 type parameter exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With1TypeParameter_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`1");

            Assert.NotNull(delegateType);
            Assert.True(delegateType.IsGenericTypeDefinition);
            Assert.Equal(1, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 2 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With2TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`2");

            Assert.NotNull(delegateType);
            Assert.Equal(2, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 3 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With3TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`3");

            Assert.NotNull(delegateType);
            Assert.Equal(3, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 4 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With4TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`4");

            Assert.NotNull(delegateType);
            Assert.Equal(4, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 5 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With5TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`5");

            Assert.NotNull(delegateType);
            Assert.Equal(5, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 6 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With6TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`6");

            Assert.NotNull(delegateType);
            Assert.Equal(6, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 7 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With7TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`7");

            Assert.NotNull(delegateType);
            Assert.Equal(7, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates with 8 type parameters exist
        /// </summary>
        [Fact]
        public void QueryDelegate_With8TypeParameters_Exists()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`8");

            Assert.NotNull(delegateType);
            Assert.Equal(8, delegateType.GetGenericArguments().Length);
        }

        /// <summary>
        ///     Tests that Query delegates are all delegate types
        /// </summary>
        [Fact]
        public void QueryDelegates_AllAreDelegateTypes()
        {
            for (int i = 1; i <= 8; i++)
            {
                Type delegateType = typeof(QueryDelegates).GetNestedType($"Query`{i}");
                Assert.True(typeof(MulticastDelegate).IsAssignableFrom(delegateType.BaseType));
            }
        }

        /// <summary>
        ///     Tests that Query delegate has void return type
        /// </summary>
        [Fact]
        public void QueryDelegate1_HasVoidReturnType()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`1");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            Assert.Equal(typeof(void), invokeMethod.ReturnType);
        }

        /// <summary>
        ///     Tests that Query delegate with 1 type has 1 ref parameter
        /// </summary>
        [Fact]
        public void QueryDelegate1_HasCorrectParameterCount()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`1");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            ParameterInfo[] parameters = invokeMethod.GetParameters();
            Assert.Equal(1, parameters.Length);
        }

        /// <summary>
        ///     Tests that Query delegate with 8 type has 8 parameters
        /// </summary>
        [Fact]
        public void QueryDelegate8_HasCorrectParameterCount()
        {
            Type delegateType = typeof(QueryDelegates).GetNestedType("Query`8");
            MethodInfo invokeMethod = delegateType.GetMethod("Invoke");

            ParameterInfo[] parameters = invokeMethod.GetParameters();
            Assert.Equal(8, parameters.Length);
        }

        /// <summary>
        ///     Tests that Query delegate class is static
        /// </summary>
        [Fact]
        public void QueryDelegatesClass_IsStatic()
        {
            Type type = typeof(QueryDelegates);

            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }
    }
}

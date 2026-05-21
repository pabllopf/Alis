// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IStoreManagerTest.cs
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
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests to verify IStoreManager interface contract
    /// </summary>
    public class IStoreManagerTest
    {
        /// <summary>
        ///     Tests that i store manager is public interface
        /// </summary>
        [Fact]
        public void IStoreManager_IsPublicInterface()
        {
            Type interfaceType = typeof(IStoreManager);

            Assert.True(interfaceType.IsInterface);
            Assert.True(interfaceType.IsPublic);
        }

        /// <summary>
        ///     Tests that i store manager has is initialized property
        /// </summary>
        [Fact]
        public void IStoreManager_HasIsInitializedProperty()
        {
            PropertyInfo property = typeof(IStoreManager).GetProperty("IsInitialized");

            Assert.NotNull(property);
            Assert.Equal(typeof(bool), property.PropertyType);
            Assert.True(property.CanRead);
            Assert.False(property.CanWrite);
        }

        /// <summary>
        ///     Tests that i store manager has initialize async method
        /// </summary>
        [Fact]
        public void IStoreManager_HasInitializeAsyncMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("InitializeAsync");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(StoreConfiguration), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that i store manager has register product method
        /// </summary>
        [Fact]
        public void IStoreManager_HasRegisterProductMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("RegisterProduct");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(StoreProduct), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that i store manager has register products method
        /// </summary>
        [Fact]
        public void IStoreManager_HasRegisterProductsMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("RegisterProducts");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Single(parameters);
        }

        /// <summary>
        ///     Tests that i store manager has try get product method
        /// </summary>
        [Fact]
        public void IStoreManager_HasTryGetProductMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("TryGetProduct");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that i store manager has get products method
        /// </summary>
        [Fact]
        public void IStoreManager_HasGetProductsMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("GetProducts");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Empty(parameters);
        }

        /// <summary>
        ///     Tests that i store manager has create checkout session async method
        /// </summary>
        [Fact]
        public void IStoreManager_HasCreateCheckoutSessionAsyncMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("CreateCheckoutSessionAsync");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.True(parameters.Length >= 2);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that i store manager has create payment intent async method
        /// </summary>
        [Fact]
        public void IStoreManager_HasCreatePaymentIntentAsyncMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("CreatePaymentIntentAsync");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.True(parameters.Length >= 2);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that i store manager has get payment status async method
        /// </summary>
        [Fact]
        public void IStoreManager_HasGetPaymentStatusAsyncMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("GetPaymentStatusAsync");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.True(parameters.Length >= 1);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        /// <summary>
        ///     Tests that i store manager has refund payment async method
        /// </summary>
        [Fact]
        public void IStoreManager_HasRefundPaymentAsyncMethod()
        {
            MethodInfo method = typeof(IStoreManager).GetMethod("RefundPaymentAsync");

            Assert.NotNull(method);
            ParameterInfo[] parameters = method.GetParameters();
            Assert.True(parameters.Length >= 1);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }
    }
}
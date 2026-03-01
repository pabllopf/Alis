// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IStripeGatewayClientTest.cs
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
using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests to verify IStripeGatewayClient interface contract
    /// </summary>
    public class IStripeGatewayClientTest
    {
        [Fact]
        public void IStripeGatewayClient_IsPublicInterface()
        {
            // Arrange & Act
            Type interfaceType = typeof(IStripeGatewayClient);

            // Assert
            Assert.True(interfaceType.IsInterface);
            Assert.True(interfaceType.IsPublic);
        }

        [Fact]
        public void IStripeGatewayClient_HasConfigureMethod()
        {
            // Arrange & Act
            var method = typeof(IStripeGatewayClient).GetMethod("Configure");

            // Assert
            Assert.NotNull(method);
            var parameters = method.GetParameters();
            Assert.Single(parameters);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void IStripeGatewayClient_HasCreateCheckoutSessionAsyncMethod()
        {
            // Arrange & Act
            var method = typeof(IStripeGatewayClient).GetMethod("CreateCheckoutSessionAsync");

            // Assert
            Assert.NotNull(method);
            var parameters = method.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(StripeCheckoutSessionRequest), parameters[0].ParameterType);
        }

        [Fact]
        public void IStripeGatewayClient_HasCreatePaymentIntentAsyncMethod()
        {
            // Arrange & Act
            var method = typeof(IStripeGatewayClient).GetMethod("CreatePaymentIntentAsync");

            // Assert
            Assert.NotNull(method);
            var parameters = method.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(StripePaymentIntentRequest), parameters[0].ParameterType);
        }

        [Fact]
        public void IStripeGatewayClient_HasGetPaymentIntentAsyncMethod()
        {
            // Arrange & Act
            var method = typeof(IStripeGatewayClient).GetMethod("GetPaymentIntentAsync");

            // Assert
            Assert.NotNull(method);
            var parameters = method.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(string), parameters[0].ParameterType);
        }

        [Fact]
        public void IStripeGatewayClient_HasCreateRefundAsyncMethod()
        {
            // Arrange & Act
            var method = typeof(IStripeGatewayClient).GetMethod("CreateRefundAsync");

            // Assert
            Assert.NotNull(method);
            var parameters = method.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal(typeof(StripeRefundRequest), parameters[0].ParameterType);
        }
    }
}


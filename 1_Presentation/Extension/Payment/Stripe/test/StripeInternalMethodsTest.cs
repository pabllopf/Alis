// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StripeInternalMethodsTest.cs
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
    public class StripeInternalMethodsTest
    {
        #region NormalizeCurrency

        private static string InvokeNormalizeCurrency(string currency)
        {
            MethodInfo method = typeof(StoreManager).GetMethod("NormalizeCurrency",
                BindingFlags.NonPublic | BindingFlags.Static);
            return (string)method.Invoke(null, new object[] { currency });
        }

        [Fact]
        public void NormalizeCurrency_Null_ReturnsUsd()
        {
            string result = InvokeNormalizeCurrency(null);
            Assert.Equal("usd", result);
        }

        [Fact]
        public void NormalizeCurrency_Empty_ReturnsUsd()
        {
            string result = InvokeNormalizeCurrency(string.Empty);
            Assert.Equal("usd", result);
        }

        [Fact]
        public void NormalizeCurrency_Whitespace_ReturnsUsd()
        {
            string result = InvokeNormalizeCurrency("  ");
            Assert.Equal("usd", result);
        }

        [Fact]
        public void NormalizeCurrency_UpperCase_ReturnsLowercase()
        {
            string result = InvokeNormalizeCurrency("EUR");
            Assert.Equal("eur", result);
        }

        [Fact]
        public void NormalizeCurrency_WithSpaces_TrimsAndLowercases()
        {
            string result = InvokeNormalizeCurrency("  GBP  ");
            Assert.Equal("gbp", result);
        }

        [Fact]
        public void NormalizeCurrency_AlreadyLowercase_ReturnsSame()
        {
            string result = InvokeNormalizeCurrency("usd");
            Assert.Equal("usd", result);
        }

        [Fact]
        public void NormalizeCurrency_MixedCase_ReturnsLowercase()
        {
            string result = InvokeNormalizeCurrency("BtC");
            Assert.Equal("btc", result);
        }

        #endregion

        #region ValidateCheckoutRequest

        [Fact]
        public void ValidateCheckoutRequest_Null_ThrowsArgumentNullException()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null }));
            Assert.IsType<ArgumentNullException>(ex.InnerException);
        }

        [Fact]
        public void ValidateCheckoutRequest_EmptyProductName_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = string.Empty,
                Currency = "usd",
                UnitAmount = 100,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentException>(ex.InnerException);
        }

        [Fact]
        public void ValidateCheckoutRequest_EmptyCurrency_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = string.Empty,
                UnitAmount = 100,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentException>(ex.InnerException);
        }

        [Fact]
        public void ValidateCheckoutRequest_ZeroUnitAmount_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 0,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentOutOfRangeException>(ex.InnerException);
        }

        [Fact]
        public void ValidateCheckoutRequest_ZeroQuantity_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 100,
                Quantity = 0,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentOutOfRangeException>(ex.InnerException);
        }

        [Fact]
        public void ValidateCheckoutRequest_NullSuccessUrl_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 100,
                Quantity = 1,
                SuccessUrl = null,
                CancelUrl = new Uri("https://example.com/cancel")
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentException>(ex.InnerException);
        }

        [Fact]
        public void ValidateCheckoutRequest_ValidRequest_DoesNotThrow()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidateCheckoutRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripeCheckoutSessionRequest request = new StripeCheckoutSessionRequest
            {
                ProductName = "Test",
                Currency = "usd",
                UnitAmount = 100,
                Quantity = 1,
                SuccessUrl = new Uri("https://example.com/success"),
                CancelUrl = new Uri("https://example.com/cancel")
            };

            method.Invoke(null, new object[] { request });
        }

        #endregion

        #region ValidatePaymentIntentRequest

        [Fact]
        public void ValidatePaymentIntentRequest_Null_ThrowsArgumentNullException()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidatePaymentIntentRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { null }));
            Assert.IsType<ArgumentNullException>(ex.InnerException);
        }

        [Fact]
        public void ValidatePaymentIntentRequest_ZeroAmount_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidatePaymentIntentRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 0,
                Currency = "usd"
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentOutOfRangeException>(ex.InnerException);
        }

        [Fact]
        public void ValidatePaymentIntentRequest_EmptyCurrency_Throws()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidatePaymentIntentRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 100,
                Currency = string.Empty
            };

            Exception ex = Assert.Throws<TargetInvocationException>(() =>
                method.Invoke(null, new object[] { request }));
            Assert.IsType<ArgumentException>(ex.InnerException);
        }

        [Fact]
        public void ValidatePaymentIntentRequest_ValidRequest_DoesNotThrow()
        {
            MethodInfo method = typeof(StripeGatewayClient).GetMethod("ValidatePaymentIntentRequest",
                BindingFlags.NonPublic | BindingFlags.Static);

            StripePaymentIntentRequest request = new StripePaymentIntentRequest
            {
                Amount = 100,
                Currency = "usd"
            };

            method.Invoke(null, new object[] { request });
        }

        #endregion
    }
}

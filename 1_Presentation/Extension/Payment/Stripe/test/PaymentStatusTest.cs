// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PaymentStatusTest.cs
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

using Xunit;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Tests for PaymentStatus enum
    /// </summary>
    public class PaymentStatusTest
    {
        [Fact]
        public void PaymentStatus_HasCorrectValues()
        {
            // Assert
            Assert.Equal(0, (int)PaymentStatus.Unknown);
            Assert.Equal(1, (int)PaymentStatus.RequiresPaymentMethod);
            Assert.Equal(2, (int)PaymentStatus.RequiresConfirmation);
            Assert.Equal(3, (int)PaymentStatus.RequiresAction);
            Assert.Equal(4, (int)PaymentStatus.Processing);
            Assert.Equal(5, (int)PaymentStatus.RequiresCapture);
            Assert.Equal(6, (int)PaymentStatus.Canceled);
            Assert.Equal(7, (int)PaymentStatus.Succeeded);
        }

        [Fact]
        public void PaymentStatus_CanBeCompared()
        {
            // Arrange
            PaymentStatus status1 = PaymentStatus.Succeeded;
            PaymentStatus status2 = PaymentStatus.Succeeded;
            PaymentStatus status3 = PaymentStatus.Processing;

            // Assert
            Assert.Equal(status1, status2);
            Assert.NotEqual(status1, status3);
        }

        [Fact]
        public void PaymentStatus_CanBeUsedInSwitch()
        {
            // Arrange
            PaymentStatus status = PaymentStatus.Succeeded;
            string result = string.Empty;

            // Act
            switch (status)
            {
                case PaymentStatus.Unknown:
                    result = "unknown";
                    break;
                case PaymentStatus.RequiresPaymentMethod:
                    result = "requires_payment_method";
                    break;
                case PaymentStatus.RequiresConfirmation:
                    result = "requires_confirmation";
                    break;
                case PaymentStatus.RequiresAction:
                    result = "requires_action";
                    break;
                case PaymentStatus.Processing:
                    result = "processing";
                    break;
                case PaymentStatus.RequiresCapture:
                    result = "requires_capture";
                    break;
                case PaymentStatus.Canceled:
                    result = "canceled";
                    break;
                case PaymentStatus.Succeeded:
                    result = "succeeded";
                    break;
            }

            // Assert
            Assert.Equal("succeeded", result);
        }

        [Theory]
        [InlineData(PaymentStatus.Unknown, "Unknown")]
        [InlineData(PaymentStatus.RequiresPaymentMethod, "RequiresPaymentMethod")]
        [InlineData(PaymentStatus.RequiresConfirmation, "RequiresConfirmation")]
        [InlineData(PaymentStatus.RequiresAction, "RequiresAction")]
        [InlineData(PaymentStatus.Processing, "Processing")]
        [InlineData(PaymentStatus.RequiresCapture, "RequiresCapture")]
        [InlineData(PaymentStatus.Canceled, "Canceled")]
        [InlineData(PaymentStatus.Succeeded, "Succeeded")]
        public void PaymentStatus_ToString_ReturnsName(PaymentStatus status, string expectedName)
        {
            // Act
            string result = status.ToString();

            // Assert
            Assert.Equal(expectedName, result);
        }
    }
}


using System.Collections.Generic;

namespace Alis.Extension.Payment.Stripe.Test
{
    /// <summary>
    ///     Shared datasets for high-volume theory tests.
    /// </summary>
    public static class StripeTheoryData
    {
        /// <summary>
        /// Products the registration cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> ProductRegistrationCases()
        {
            string[] currencies = { "usd", "eur", "gbp", "jpy", "mxn", "ars" };

            for (int i = 1; i <= 120; i++)
            {
                string productId = $"bulk_product_{i}";
                string productName = $"Bulk Product {i}";
                long price = 99 + i;
                string currency = currencies[i % currencies.Length];

                yield return new object[]
                {
                    productId,
                    productName,
                    price,
                    currency
                };
            }
        }

        /// <summary>
        /// Currencies the normalization cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> CurrencyNormalizationCases()
        {
            string[] baseCurrencies = { "USD", "EUR", "GBP", "JPY", "MXN", "ARS", "BRL", "CAD", "AUD", "CHF" };

            for (int i = 0; i < 100; i++)
            {
                string raw = baseCurrencies[i % baseCurrencies.Length];
                string variant;

                switch (i % 4)
                {
                    case 0:
                        variant = raw;
                        break;
                    case 1:
                        variant = string.Concat(" ", raw, " ");
                        break;
                    case 2:
                        variant = raw.ToLowerInvariant();
                        break;
                    default:
                        variant = string.Concat("\t", raw.ToLowerInvariant(), "\t");
                        break;
                }

                yield return new object[]
                {
                    i,
                    variant,
                    raw.ToLowerInvariant()
                };
            }
        }

        /// <summary>
        /// Payments the status mapping cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> PaymentStatusMappingCases()
        {
            string[] knownStatuses =
            {
                "requires_payment_method",
                "requires_confirmation",
                "requires_action",
                "processing",
                "requires_capture",
                "canceled",
                "succeeded"
            };

            PaymentStatus[] expectedKnown =
            {
                PaymentStatus.RequiresPaymentMethod,
                PaymentStatus.RequiresConfirmation,
                PaymentStatus.RequiresAction,
                PaymentStatus.Processing,
                PaymentStatus.RequiresCapture,
                PaymentStatus.Canceled,
                PaymentStatus.Succeeded
            };

            for (int i = 0; i < knownStatuses.Length; i++)
            {
                // Canonical case
                yield return new object[] { knownStatuses[i], expectedKnown[i] };
                // Uppercase variant
                yield return new object[] { knownStatuses[i].ToUpperInvariant(), expectedKnown[i] };
                // Padded variant
                yield return new object[] { string.Concat(" ", knownStatuses[i], " "), expectedKnown[i] };
                // Mixed casing variant
                yield return new object[] { Capitalize(knownStatuses[i]), expectedKnown[i] };
            }

            // 62 unknown-status variants to reach exactly 100 rows total.
            for (int i = 1; i <= 62; i++)
            {
                yield return new object[] { $"unknown_status_{i}", PaymentStatus.Unknown };
            }

            // Known unknowns
            yield return new object[] { string.Empty, PaymentStatus.Unknown };
            yield return new object[] { "   ", PaymentStatus.Unknown };
            yield return new object[] { null, PaymentStatus.Unknown };
        }

        /// <summary>
        /// Capitalizes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The string</returns>
        private static string Capitalize(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return char.ToUpperInvariant(value[0]) + value.Substring(1);
        }
    }
}

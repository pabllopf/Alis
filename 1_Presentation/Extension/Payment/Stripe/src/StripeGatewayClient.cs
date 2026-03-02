using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Stripe.Checkout;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     Real Stripe SDK adapter used by StoreManager.
    /// </summary>
    public class StripeGatewayClient : IStripeGatewayClient
    {
        /// <summary>
        /// The configured api key
        /// </summary>
        private string _configuredApiKey;

        /// <summary>
        /// Configures the secret api key
        /// </summary>
        /// <param name="secretApiKey">The secret api key</param>
        /// <exception cref="ArgumentException">Stripe secret API key cannot be null or empty. </exception>
        public void Configure(string secretApiKey)
        {
            if (string.IsNullOrWhiteSpace(secretApiKey))
            {
                throw new ArgumentException("Stripe secret API key cannot be null or empty.", nameof(secretApiKey));
            }

            _configuredApiKey = secretApiKey;
            StripeConfiguration.ApiKey = secretApiKey;
        }

        /// <summary>
        /// Creates the checkout session using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the stripe checkout session response</returns>
        public async Task<StripeCheckoutSessionResponse> CreateCheckoutSessionAsync(
            StripeCheckoutSessionRequest request,
            CancellationToken cancellationToken = default)
        {
            EnsureConfigured();
            ValidateCheckoutRequest(request);

            SessionService service = new SessionService();
            SessionCreateOptions options = new SessionCreateOptions
            {
                Mode = "payment",
                SuccessUrl = request.SuccessUrl.ToString(),
                CancelUrl = request.CancelUrl.ToString(),
                CustomerEmail = request.CustomerEmail,
                Metadata = request.Metadata == null ? null : new Dictionary<string, string>(request.Metadata),
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Quantity = request.Quantity,
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = request.Currency,
                            UnitAmount = request.UnitAmount,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = request.ProductName,
                                Description = request.ProductDescription
                            }
                        }
                    }
                }
            };

            Session session = await service.CreateAsync(options, cancellationToken: cancellationToken).ConfigureAwait(false);

            return new StripeCheckoutSessionResponse
            {
                SessionId = session.Id,
                Url = new Uri(session.Url),
                PaymentIntentId = session.PaymentIntentId
            };
        }

        /// <summary>
        /// Creates the payment intent using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the stripe payment intent response</returns>
        public async Task<StripePaymentIntentResponse> CreatePaymentIntentAsync(
            StripePaymentIntentRequest request,
            CancellationToken cancellationToken = default)
        {
            EnsureConfigured();
            ValidatePaymentIntentRequest(request);

            PaymentIntentService service = new PaymentIntentService();
            PaymentIntentCreateOptions options = new PaymentIntentCreateOptions
            {
                Amount = request.Amount,
                Currency = request.Currency,
                Description = request.Description,
                Metadata = request.Metadata == null ? null : new Dictionary<string, string>(request.Metadata),
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = request.EnableAutomaticPaymentMethods
                }
            };

            if (!string.IsNullOrWhiteSpace(request.CustomerId))
            {
                options.Customer = request.CustomerId;
            }

            PaymentIntent intent = await service.CreateAsync(options, cancellationToken: cancellationToken).ConfigureAwait(false);

            return new StripePaymentIntentResponse
            {
                PaymentIntentId = intent.Id,
                ClientSecret = intent.ClientSecret,
                Status = intent.Status
            };
        }

        /// <summary>
        /// Gets the payment intent using the specified payment intent id
        /// </summary>
        /// <param name="paymentIntentId">The payment intent id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="ArgumentException">Payment intent id cannot be null or empty. </exception>
        /// <returns>A task containing the stripe payment intent response</returns>
        public async Task<StripePaymentIntentResponse> GetPaymentIntentAsync(string paymentIntentId, CancellationToken cancellationToken = default)
        {
            EnsureConfigured();

            if (string.IsNullOrWhiteSpace(paymentIntentId))
            {
                throw new ArgumentException("Payment intent id cannot be null or empty.", nameof(paymentIntentId));
            }

            PaymentIntentService service = new PaymentIntentService();
            PaymentIntent intent = await service.GetAsync(paymentIntentId, cancellationToken: cancellationToken).ConfigureAwait(false);

            return new StripePaymentIntentResponse
            {
                PaymentIntentId = intent.Id,
                ClientSecret = intent.ClientSecret,
                Status = intent.Status
            };
        }

        /// <summary>
        /// Creates the refund using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">Payment intent id cannot be null or empty. </exception>
        /// <returns>A task containing the stripe refund response</returns>
        public async Task<StripeRefundResponse> CreateRefundAsync(StripeRefundRequest request, CancellationToken cancellationToken = default)
        {
            EnsureConfigured();

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.PaymentIntentId))
            {
                throw new ArgumentException("Payment intent id cannot be null or empty.", nameof(request));
            }

            RefundService service = new RefundService();
            RefundCreateOptions options = new RefundCreateOptions
            {
                PaymentIntent = request.PaymentIntentId,
                Amount = request.Amount,
                Reason = MapRefundReason(request.Reason)
            };

            Refund refund = await service.CreateAsync(options, cancellationToken: cancellationToken).ConfigureAwait(false);

            return new StripeRefundResponse
            {
                RefundId = refund.Id,
                AmountRefunded = refund.Amount,
                Currency = refund.Currency,
                Status = refund.Status
            };
        }

        /// <summary>
        /// Maps the refund reason using the specified reason
        /// </summary>
        /// <param name="reason">The reason</param>
        /// <returns>The string</returns>
        private static string MapRefundReason(string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
            {
                return null;
            }

            string normalized = reason.Trim().ToLowerInvariant();
            if (normalized == RefundReasons.Duplicate || normalized == RefundReasons.Fraudulent || normalized == RefundReasons.RequestedByCustomer)
            {
                return normalized;
            }

            return null;
        }

        /// <summary>
        /// Ensures the configured
        /// </summary>
        /// <exception cref="InvalidOperationException">StripeGatewayClient is not configured. Call Configure first.</exception>
        private void EnsureConfigured()
        {
            if (string.IsNullOrWhiteSpace(_configuredApiKey))
            {
                throw new InvalidOperationException("StripeGatewayClient is not configured. Call Configure first.");
            }
        }

        /// <summary>
        /// Validates the checkout request using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">Currency cannot be null or empty. </exception>
        /// <exception cref="ArgumentException">ProductName cannot be null or empty. </exception>
        /// <exception cref="ArgumentOutOfRangeException">Quantity must be greater than zero.</exception>
        /// <exception cref="ArgumentException">SuccessUrl and CancelUrl are required. </exception>
        /// <exception cref="ArgumentOutOfRangeException">UnitAmount must be greater than zero.</exception>
        private static void ValidateCheckoutRequest(StripeCheckoutSessionRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.ProductName))
            {
                throw new ArgumentException("ProductName cannot be null or empty.", nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Currency))
            {
                throw new ArgumentException("Currency cannot be null or empty.", nameof(request));
            }

            if (request.UnitAmount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(request), "UnitAmount must be greater than zero.");
            }

            if (request.Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(request), "Quantity must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(request.SuccessUrl.ToString()) || string.IsNullOrWhiteSpace(request.CancelUrl.ToString()))
            {
                throw new ArgumentException("SuccessUrl and CancelUrl are required.", nameof(request));
            }
        }

        /// <summary>
        /// Validates the payment intent request using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">Amount must be greater than zero.</exception>
        /// <exception cref="ArgumentException">Currency cannot be null or empty. </exception>
        private static void ValidatePaymentIntentRequest(StripePaymentIntentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(request), "Amount must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(request.Currency))
            {
                throw new ArgumentException("Currency cannot be null or empty.", nameof(request));
            }
        }
    }
}


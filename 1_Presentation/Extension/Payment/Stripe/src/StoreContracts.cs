using System.Collections.Generic;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    /// The store configuration class
    /// </summary>
    public class StoreConfiguration
    {
        /// <summary>
        /// Gets or sets the value of the secret api key
        /// </summary>
        public string SecretApiKey { get; set; }

        /// <summary>
        /// Gets or sets the value of the default currency
        /// </summary>
        public string DefaultCurrency { get; set; } = "usd";

        /// <summary>
        /// Gets or sets the value of the success url
        /// </summary>
        public string SuccessUrl { get; set; } = "https://example.com/payment/success";

        /// <summary>
        /// Gets or sets the value of the cancel url
        /// </summary>
        public string CancelUrl { get; set; } = "https://example.com/payment/cancel";

        /// <summary>
        /// Gets or sets the value of the enable automatic payment methods
        /// </summary>
        public bool EnableAutomaticPaymentMethods { get; set; } = true;
    }

    /// <summary>
    /// The store product class
    /// </summary>
    public class StoreProduct
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value of the price in cents
        /// </summary>
        public long PriceInCents { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; } = "usd";

        /// <summary>
        /// Gets or sets the value of the is enabled
        /// </summary>
        public bool IsEnabled { get; set; } = true;
    }

    /// <summary>
    /// The payment status enum
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// The unknown payment status
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// The requires payment method payment status
        /// </summary>
        RequiresPaymentMethod = 1,
        /// <summary>
        /// The requires confirmation payment status
        /// </summary>
        RequiresConfirmation = 2,
        /// <summary>
        /// The requires action payment status
        /// </summary>
        RequiresAction = 3,
        /// <summary>
        /// The processing payment status
        /// </summary>
        Processing = 4,
        /// <summary>
        /// The requires capture payment status
        /// </summary>
        RequiresCapture = 5,
        /// <summary>
        /// The canceled payment status
        /// </summary>
        Canceled = 6,
        /// <summary>
        /// The succeeded payment status
        /// </summary>
        Succeeded = 7
    }

    /// <summary>
    /// The checkout session result class
    /// </summary>
    public class CheckoutSessionResult
    {
        /// <summary>
        /// Gets or sets the value of the session id
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the value of the url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the value of the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the value of the unit amount
        /// </summary>
        public long UnitAmount { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }
    }

    /// <summary>
    /// The payment intent result class
    /// </summary>
    public class PaymentIntentResult
    {
        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the client secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public PaymentStatus Status { get; set; }
    }

    /// <summary>
    /// The refund result class
    /// </summary>
    public class RefundResult
    {
        /// <summary>
        /// Gets or sets the value of the refund id
        /// </summary>
        public string RefundId { get; set; }

        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount refunded
        /// </summary>
        public long AmountRefunded { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public string Status { get; set; }
    }

    /// <summary>
    /// The stripe gateway client interface
    /// </summary>
    public interface IStripeGatewayClient
    {
        /// <summary>
        /// Configures the secret api key
        /// </summary>
        /// <param name="secretApiKey">The secret api key</param>
        void Configure(string secretApiKey);

        /// <summary>
        /// Creates the checkout session using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe checkout session response</returns>
        System.Threading.Tasks.Task<StripeCheckoutSessionResponse> CreateCheckoutSessionAsync(
            StripeCheckoutSessionRequest request,
            System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the payment intent using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe payment intent response</returns>
        System.Threading.Tasks.Task<StripePaymentIntentResponse> CreatePaymentIntentAsync(
            StripePaymentIntentRequest request,
            System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the payment intent using the specified payment intent id
        /// </summary>
        /// <param name="paymentIntentId">The payment intent id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe payment intent response</returns>
        System.Threading.Tasks.Task<StripePaymentIntentResponse> GetPaymentIntentAsync(
            string paymentIntentId,
            System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the refund using the specified request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A system threading tasks task of stripe refund response</returns>
        System.Threading.Tasks.Task<StripeRefundResponse> CreateRefundAsync(
            StripeRefundRequest request,
            System.Threading.CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// The stripe checkout session request class
    /// </summary>
    public class StripeCheckoutSessionRequest
    {
        /// <summary>
        /// Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the value of the product name
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the value of the product description
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the unit amount
        /// </summary>
        public long UnitAmount { get; set; }

        /// <summary>
        /// Gets or sets the value of the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the value of the success url
        /// </summary>
        public string SuccessUrl { get; set; }

        /// <summary>
        /// Gets or sets the value of the cancel url
        /// </summary>
        public string CancelUrl { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer email
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the value of the metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }
    }

    /// <summary>
    /// The stripe checkout session response class
    /// </summary>
    public class StripeCheckoutSessionResponse
    {
        /// <summary>
        /// Gets or sets the value of the session id
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the value of the url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }
    }

    /// <summary>
    /// The stripe payment intent request class
    /// </summary>
    public class StripePaymentIntentRequest
    {
        /// <summary>
        /// Gets or sets the value of the product id
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value of the metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Gets or sets the value of the enable automatic payment methods
        /// </summary>
        public bool EnableAutomaticPaymentMethods { get; set; }
    }

    /// <summary>
    /// The stripe payment intent response class
    /// </summary>
    public class StripePaymentIntentResponse
    {
        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the client secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public string Status { get; set; }
    }

    /// <summary>
    /// The stripe refund request class
    /// </summary>
    public class StripeRefundRequest
    {
        /// <summary>
        /// Gets or sets the value of the payment intent id
        /// </summary>
        public string PaymentIntentId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount
        /// </summary>
        public long? Amount { get; set; }

        /// <summary>
        /// Gets or sets the value of the reason
        /// </summary>
        public string Reason { get; set; }
    }

    /// <summary>
    /// The stripe refund response class
    /// </summary>
    public class StripeRefundResponse
    {
        /// <summary>
        /// Gets or sets the value of the refund id
        /// </summary>
        public string RefundId { get; set; }

        /// <summary>
        /// Gets or sets the value of the amount refunded
        /// </summary>
        public long AmountRefunded { get; set; }

        /// <summary>
        /// Gets or sets the value of the currency
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the value of the status
        /// </summary>
        public string Status { get; set; }
    }
}


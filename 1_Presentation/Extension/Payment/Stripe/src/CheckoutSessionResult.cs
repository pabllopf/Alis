using System;

namespace Alis.Extension.Payment.Stripe
{
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
        public Uri Url { get; set; }

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
}
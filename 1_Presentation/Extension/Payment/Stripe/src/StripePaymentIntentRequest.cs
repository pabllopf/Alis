using System.Collections.Generic;

namespace Alis.Extension.Payment.Stripe
{
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
}
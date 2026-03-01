using System.Collections.Generic;

namespace Alis.Extension.Payment.Stripe
{
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
}
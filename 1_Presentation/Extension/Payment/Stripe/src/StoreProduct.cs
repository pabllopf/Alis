namespace Alis.Extension.Payment.Stripe
{
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
}
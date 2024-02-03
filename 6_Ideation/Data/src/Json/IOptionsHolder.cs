namespace Alis.Core.Aspect.Data.Json
{
    /// <summary>
    ///     Defines an interface for setting or getting options.
    /// </summary>
    public interface IOptionsHolder
    {
        /// <summary>
        ///     Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        JsonOptions Options { get; set; }
    }
}
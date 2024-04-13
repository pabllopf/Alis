using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The sample class class
    /// </summary>
    public class SampleClass2
    {
        /// <summary>
        /// Gets or sets the value of the sample property
        /// </summary>
        [JsonPropertyName("sample")]
        public string SampleProperty { get; set; }
    }
}
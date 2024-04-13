using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The sample class
    /// </summary>
    public class SampleClass
    {
        /// <summary>
        /// Gets or sets the value of the sample property
        /// </summary>
        [JsonPropertyName("SamplePropertyName")]
        public string SampleProperty { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the property without name
        /// </summary>
        public string PropertyWithoutName { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the property without attributes
        /// </summary>
        public string PropertyWithoutAttributes { get; set; }
    }
}
namespace Alis.Core.Aspect.Data.Test.Json
{
    /// <summary>
    /// The sample class with script ignore class
    /// </summary>
    public class SampleClassWithScriptIgnore
    {
        /// <summary>
        /// Gets or sets the value of the property with script ignore
        /// </summary>
        [ScriptIgnore]
        public string PropertyWithScriptIgnore { get; set; }
    }
}
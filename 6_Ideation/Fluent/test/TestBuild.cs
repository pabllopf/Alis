

using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     The test build class
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class TestBuild : IBuild<string>
    {
        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The string</returns>
        public string Build() => "Test";
    }
}
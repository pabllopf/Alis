

using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Aspect.Fluent.Test
{
    /// <summary>
    ///     The test builder class
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class TestHasBuilder : IHasBuilder<string>
    {
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The string</returns>
        public string Builder() => "Test";
    }
}
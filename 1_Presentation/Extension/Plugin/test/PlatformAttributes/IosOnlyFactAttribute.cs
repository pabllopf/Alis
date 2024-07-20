using Xunit;

namespace Alis.Extension.Plugin.Test.PlatformAttributes
{
    /// <summary>
    /// The ios only fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class IosOnlyFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IosOnlyFactAttribute"/> class
        /// </summary>
        public IosOnlyFactAttribute()
        {
            if (!new PluginManager().IsRunningOniOS())
            {
                Skip = "This test is only applicable on iOS";
            }
        }
    }
}
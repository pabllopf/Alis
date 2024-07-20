using Xunit;

namespace Alis.Extension.Plugin.Test.PlatformAttributes
{
    /// <summary>
    /// The android only fact attribute class
    /// </summary>
    /// <seealso cref="FactAttribute"/>
    public class AndroidOnlyFactAttribute : FactAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AndroidOnlyFactAttribute"/> class
        /// </summary>
        public AndroidOnlyFactAttribute()
        {
            if (!new PluginManager().IsRunningOnAndroid())
            {
                Skip = "This test is only applicable on Android";
            }
        }
    }
}
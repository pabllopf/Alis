

using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Input;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Input
{
    /// <summary>
    ///     The audio setting builder class
    /// </summary>
    public class InputSettingBuilder :
        IBuild<InputSetting>
    {
        /// <summary>
        ///     The sensitivity
        /// </summary>
        private float sensitivity = 1.0f;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The audio setting</returns>
        public InputSetting Build() => new InputSetting(sensitivity);

        /// <summary>
        ///     Mouses the sensitivity using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The input setting builder</returns>
        public InputSettingBuilder MouseSensitivity(float value)
        {
            sensitivity = value;
            return this;
        }
    }
}
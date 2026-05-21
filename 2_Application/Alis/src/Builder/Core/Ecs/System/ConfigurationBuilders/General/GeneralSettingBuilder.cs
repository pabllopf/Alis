

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration.General;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders.General
{
    /// <summary>
    ///     The general setting builder class
    /// </summary>
    /// <seealso cref="IBuild{GeneralSetting}" />
    public class GeneralSettingBuilder :
        IBuild<GeneralSetting>,
        IName<GeneralSettingBuilder, string>,
        IVersion<GeneralSettingBuilder, string>,
        IDebug<GeneralSettingBuilder, bool>,
        ILicense<GeneralSettingBuilder, string>,
        IAuthor<GeneralSettingBuilder, string>,
        IDescription<GeneralSettingBuilder, string>,
        IIcon<GeneralSettingBuilder, string>
    {
        /// <summary>
        ///     The general setting
        /// </summary>
        private GeneralSetting generalSetting = new GeneralSetting();

        /// <summary>
        ///     Authors the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Author(string value)
        {
            generalSetting.Author = value;
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The general setting</returns>
        public GeneralSetting Build() => generalSetting;

        /// <summary>
        ///     Debugs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Debug(bool value)
        {
            generalSetting.Debug = value;
            return this;
        }

        /// <summary>
        ///     Descriptions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Description(string value)
        {
            generalSetting.Description = value;
            return this;
        }

        /// <summary>
        ///     Icons the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Icon(string value)
        {
            generalSetting.Icon = value;
            return this;
        }

        /// <summary>
        ///     Licences the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder License(string value)
        {
            generalSetting.License = value;
            return this;
        }

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Name(string value)
        {
            generalSetting.Name = value;
            return this;
        }

        /// <summary>
        ///     Versions the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The general setting builder</returns>
        public GeneralSettingBuilder Version(string value)
        {
            generalSetting.Version = value;
            return this;
        }
    }
}
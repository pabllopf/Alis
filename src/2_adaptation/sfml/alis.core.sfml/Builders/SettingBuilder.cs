namespace Alis.Core.Sfml.Builders
{
    using Settings;
    using Settings.Configurations;
    using FluentApi;
    using System;

    /// <summary>Define a builder. </summary>
    public class SettingBuilder : 
        IBuild<Setting>,
        IGeneral<SettingBuilder, Func<GeneralBuilder, General>>,
        IWindow<SettingBuilder, Func<WindowBuilder, Window>>
    {
        /// <summary>Generals the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public SettingBuilder General(Func<GeneralBuilder, General> value)
        {
            Game.Setting.General = value.Invoke(new GeneralBuilder());
            return this;
        }

        /// <summary>Windows the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public SettingBuilder Window(Func<WindowBuilder, Window> value)
        {
            Game.Setting.Window = value.Invoke(new WindowBuilder());
            return this;
        }

        /// <summary>Builds this instance.</summary>
        /// <returns></returns>
        public Setting Build() => Game.Setting;
    }
}

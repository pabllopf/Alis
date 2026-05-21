

using System;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.General;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Graphic;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Input;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Network;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Physic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration;

namespace Alis.Builder.Core.Ecs.System.ConfigurationBuilders
{
    /// <summary>
    ///     Setting builder
    /// </summary>
    public class SettingsBuilder :
        IBuild<Setting>,
        IAudio<SettingsBuilder, Action<AudioSettingBuilder>>,
        IGeneral<SettingsBuilder, Action<GeneralSettingBuilder>>,
        IGraphic<SettingsBuilder, Action<GraphicSettingBuilder>>,
        IInput<SettingsBuilder, Action<InputSettingBuilder>>,
        INetwork<SettingsBuilder, Action<NetworkSettingBuilder>>,
        IPhysic<SettingsBuilder, Action<PhysicSettingBuilder>>
    {
        /// <summary>
        ///     The setting base
        /// </summary>
        private readonly Setting settingBase = new Setting();

        /// <summary>
        ///     Audio the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Audio(Action<AudioSettingBuilder> value)
        {
            AudioSettingBuilder audioSettingBuilder = new AudioSettingBuilder();
            value(audioSettingBuilder);
            settingBase.Audio = audioSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Build setting
        /// </summary>
        /// <returns></returns>
        public Setting Build() => settingBase;

        /// <summary>
        ///     Generals the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder General(Action<GeneralSettingBuilder> value)
        {
            GeneralSettingBuilder generalSettingBuilder = new GeneralSettingBuilder();
            value(generalSettingBuilder);
            settingBase.General = generalSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Graphics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Graphic(Action<GraphicSettingBuilder> value)
        {
            GraphicSettingBuilder graphicSettingBuilder = new GraphicSettingBuilder();
            value(graphicSettingBuilder);
            settingBase.Graphic = graphicSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Inputs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Input(Action<InputSettingBuilder> value)
        {
            InputSettingBuilder inputSettingBuilder = new InputSettingBuilder();
            value(inputSettingBuilder);
            settingBase.Input = inputSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Networks the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Network(Action<NetworkSettingBuilder> value)
        {
            NetworkSettingBuilder networkSettingBuilder = new NetworkSettingBuilder();
            value(networkSettingBuilder);
            settingBase.Network = networkSettingBuilder.Build();
            return this;
        }

        /// <summary>
        ///     Physics the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The settings builder</returns>
        public SettingsBuilder Physic(Action<PhysicSettingBuilder> value)
        {
            PhysicSettingBuilder physicSettingBuilder = new PhysicSettingBuilder();
            value(physicSettingBuilder);
            settingBase.Physic = physicSettingBuilder.Build();
            return this;
        }
    }
}
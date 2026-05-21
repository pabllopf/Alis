

using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;

namespace Alis.Core.Ecs.Systems.Configuration
{
    /// <summary>
    ///     The setting interface
    /// </summary>
    public interface ISetting
    {
        /// <summary>
        ///     Gets or sets the value of the general
        /// </summary>
        GeneralSetting General { get; set; }

        /// <summary>
        ///     Gets or sets the value of the audio
        /// </summary>

        AudioSetting Audio { get; set; }

        /// <summary>
        ///     Gets or sets the value of the graphic
        /// </summary>

        GraphicSetting Graphic { get; set; }

        /// <summary>
        ///     Gets or sets the value of the input
        /// </summary>

        InputSetting Input { get; set; }

        /// <summary>
        ///     Gets or sets the value of the network
        /// </summary>

        NetworkSetting Network { get; set; }

        /// <summary>
        ///     Gets or sets the value of the physic
        /// </summary>

        PhysicSetting Physic { get; set; }
    }
}
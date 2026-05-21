

namespace Alis.Core.Ecs.Systems.Configuration.General
{
    /// <summary>
    ///     The general setting interface
    /// </summary>
    public interface IGeneralSetting
    {
        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        bool Debug { get; set; }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets the value of the version
        /// </summary>
        string Version { get; set; }

        /// <summary>
        ///     Gets or sets the value of the author
        /// </summary>
        string Author { get; set; }

        /// <summary>
        ///     Gets or sets the value of the license
        /// </summary>
        string License { get; set; }

        /// <summary>
        ///     Gets or sets the value of the icon
        /// </summary>
        string Icon { get; set; }
    }
}
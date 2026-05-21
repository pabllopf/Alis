

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems.Configuration.Input
{
    /// <summary>
    ///     The input setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputSetting(float mouseSensitivity) : IInputSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InputSetting" /> class
        /// </summary>
        public InputSetting() : this(0.1f)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the mouse sensitivity
        /// </summary>
        public float MouseSensitivity { get; set; } = mouseSensitivity;
    }
}
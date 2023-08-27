using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui key data
    /// </summary>
    public unsafe struct ImGuiKeyData
    {
        /// <summary>
        /// The down
        /// </summary>
        public byte Down;
        /// <summary>
        /// The down duration
        /// </summary>
        public float DownDuration;
        /// <summary>
        /// The down duration prev
        /// </summary>
        public float DownDurationPrev;
        /// <summary>
        /// The analog value
        /// </summary>
        public float AnalogValue;
    }
}

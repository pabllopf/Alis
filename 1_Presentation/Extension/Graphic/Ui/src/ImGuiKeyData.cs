

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui key data
    /// </summary>
    public struct ImGuiKeyData
    {
        /// <summary>
        ///     The down
        /// </summary>
        public byte Down { get; set; }

        /// <summary>
        ///     The down duration
        /// </summary>
        public float DownDuration { get; set; }

        /// <summary>
        ///     The down duration prev
        /// </summary>
        public float DownDurationPrev { get; set; }

        /// <summary>
        ///     The analog value
        /// </summary>
        public float AnalogValue { get; set; }
    }
}
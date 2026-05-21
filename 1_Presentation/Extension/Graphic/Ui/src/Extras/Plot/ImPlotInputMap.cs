

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot input map
    /// </summary>
    public struct ImPlotInputMap
    {
        /// <summary>
        ///     The pan
        /// </summary>
        public ImGuiMouseButton Pan { get; set; }

        /// <summary>
        ///     The pan mod
        /// </summary>
        public ImGuiModFlags PanMod { get; set; }

        /// <summary>
        ///     The fit
        /// </summary>
        public ImGuiMouseButton Fit { get; set; }

        /// <summary>
        ///     The select
        /// </summary>
        public ImGuiMouseButton Select { get; set; }

        /// <summary>
        ///     The select cancel
        /// </summary>
        public ImGuiMouseButton SelectCancel { get; set; }

        /// <summary>
        ///     The select mod
        /// </summary>
        public ImGuiModFlags SelectMod { get; set; }

        /// <summary>
        ///     The select horz mod
        /// </summary>
        public ImGuiModFlags SelectHorzMod { get; set; }

        /// <summary>
        ///     The select vert mod
        /// </summary>
        public ImGuiModFlags SelectVertMod { get; set; }

        /// <summary>
        ///     The menu
        /// </summary>
        public ImGuiMouseButton Menu { get; set; }

        /// <summary>
        ///     The override mod
        /// </summary>
        public ImGuiModFlags OverrideMod { get; set; }

        /// <summary>
        ///     The zoom mod
        /// </summary>
        public ImGuiModFlags ZoomMod { get; set; }

        /// <summary>
        ///     The zoom rate
        /// </summary>
        public float ZoomRate { get; set; }
    }
}
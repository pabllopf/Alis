using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui.Extras.ImPlot
{
    /// <summary>
    /// The im plot input map
    /// </summary>
    public struct ImPlotInputMap
    {
        /// <summary>
        /// The pan
        /// </summary>
        public ImGuiMouseButton Pan;
        /// <summary>
        /// The pan mod
        /// </summary>
        public ImGuiModFlags PanMod;
        /// <summary>
        /// The fit
        /// </summary>
        public ImGuiMouseButton Fit;
        /// <summary>
        /// The select
        /// </summary>
        public ImGuiMouseButton Select;
        /// <summary>
        /// The select cancel
        /// </summary>
        public ImGuiMouseButton SelectCancel;
        /// <summary>
        /// The select mod
        /// </summary>
        public ImGuiModFlags SelectMod;
        /// <summary>
        /// The select horz mod
        /// </summary>
        public ImGuiModFlags SelectHorzMod;
        /// <summary>
        /// The select vert mod
        /// </summary>
        public ImGuiModFlags SelectVertMod;
        /// <summary>
        /// The menu
        /// </summary>
        public ImGuiMouseButton Menu;
        /// <summary>
        /// The override mod
        /// </summary>
        public ImGuiModFlags OverrideMod;
        /// <summary>
        /// The zoom mod
        /// </summary>
        public ImGuiModFlags ZoomMod;
        /// <summary>
        /// The zoom rate
        /// </summary>
        public float ZoomRate;
    }
}

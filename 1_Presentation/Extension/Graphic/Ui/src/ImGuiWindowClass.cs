

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui window
    /// </summary>
    public struct ImGuiWindowClass
    {
        /// <summary>
        ///     The class id
        /// </summary>
        public uint ClassId { get; set; }

        /// <summary>
        ///     The parent viewport id
        /// </summary>
        public uint ParentViewportId { get; set; }

        /// <summary>
        ///     The viewport flags override set
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideSet { get; set; }

        /// <summary>
        ///     The viewport flags override clear
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideClear { get; set; }

        /// <summary>
        ///     The tab item flags override set
        /// </summary>
        public ImGuiTabItemFlags TabItemFlagsOverrideSet { get; set; }

        /// <summary>
        ///     The dock node flags override set
        /// </summary>
        public ImGuiDockNodeFlags DockNodeFlagsOverrideSet { get; set; }

        /// <summary>
        ///     The docking always tab bar
        /// </summary>
        public byte DockingAlwaysTabBar { get; set; }

        /// <summary>
        ///     The docking allow unclassed
        /// </summary>
        public byte DockingAllowUnclassed { get; set; }
    }
}
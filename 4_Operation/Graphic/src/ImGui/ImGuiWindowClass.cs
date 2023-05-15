namespace Alis.Core.Graphic.ImGui
{
    /// <summary>
    /// The im gui window
    /// </summary>
    public struct ImGuiWindowClass
    {
        /// <summary>
        /// The class id
        /// </summary>
        public uint ClassId;
        /// <summary>
        /// The parent viewport id
        /// </summary>
        public uint ParentViewportId;
        /// <summary>
        /// The viewport flags override set
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideSet;
        /// <summary>
        /// The viewport flags override clear
        /// </summary>
        public ImGuiViewportFlags ViewportFlagsOverrideClear;
        /// <summary>
        /// The tab item flags override set
        /// </summary>
        public ImGuiTabItemFlags TabItemFlagsOverrideSet;
        /// <summary>
        /// The dock node flags override set
        /// </summary>
        public ImGuiDockNodeFlags DockNodeFlagsOverrideSet;
        /// <summary>
        /// The docking always tab bar
        /// </summary>
        public byte DockingAlwaysTabBar;
        /// <summary>
        /// The docking allow unclassed
        /// </summary>
        public byte DockingAllowUnclassed;
    }
}

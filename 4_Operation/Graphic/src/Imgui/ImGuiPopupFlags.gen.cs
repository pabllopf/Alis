namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im gui popup flags enum
    /// </summary>
    [System.Flags]
    public enum ImGuiPopupFlags
    {
        /// <summary>
        /// The none im gui popup flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The mouse button left im gui popup flags
        /// </summary>
        MouseButtonLeft = 0,
        /// <summary>
        /// The mouse button right im gui popup flags
        /// </summary>
        MouseButtonRight = 1,
        /// <summary>
        /// The mouse button middle im gui popup flags
        /// </summary>
        MouseButtonMiddle = 2,
        /// <summary>
        /// The mouse button mask im gui popup flags
        /// </summary>
        MouseButtonMask = 31,
        /// <summary>
        /// The mouse button default im gui popup flags
        /// </summary>
        MouseButtonDefault = 1,
        /// <summary>
        /// The no open over existing popup im gui popup flags
        /// </summary>
        NoOpenOverExistingPopup = 32,
        /// <summary>
        /// The no open over items im gui popup flags
        /// </summary>
        NoOpenOverItems = 64,
        /// <summary>
        /// The any popup id im gui popup flags
        /// </summary>
        AnyPopupId = 128,
        /// <summary>
        /// The any popup level im gui popup flags
        /// </summary>
        AnyPopupLevel = 256,
        /// <summary>
        /// The any popup im gui popup flags
        /// </summary>
        AnyPopup = 384,
    }
}

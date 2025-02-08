namespace Alis.Core.Graphic.GlfwLib.Enums
{
    /// <summary>
    ///     Used internally to consolidate strongly-typed values for getting/setting window attributes.
    /// </summary>
    internal enum ContextAttributes
    {
        /// <summary>
        /// The client api context attributes
        /// </summary>
        ClientApi = 0x00022001,
        /// <summary>
        /// The context creation api context attributes
        /// </summary>
        ContextCreationApi = 0x0002200B,
        /// <summary>
        /// The context version major context attributes
        /// </summary>
        ContextVersionMajor = 0x00022002,
        /// <summary>
        /// The context version minor context attributes
        /// </summary>
        ContextVersionMinor = 0x00022003,
        /// <summary>
        /// The context version revision context attributes
        /// </summary>
        ContextVersionRevision = 0x00022004,
        /// <summary>
        /// The opengl forward compat context attributes
        /// </summary>
        OpenglForwardCompat = 0x00022006,
        /// <summary>
        /// The opengl debug context context attributes
        /// </summary>
        OpenglDebugContext = 0x00022007,
        /// <summary>
        /// The opengl profile context attributes
        /// </summary>
        OpenglProfile = 0x00022008,
        /// <summary>
        /// The context robustness context attributes
        /// </summary>
        ContextRobustness = 0x00022005
    }
}
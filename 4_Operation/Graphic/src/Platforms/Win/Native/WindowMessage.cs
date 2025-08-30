#if WIN

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// Window messages.
    /// </summary>
    public enum WindowMessage : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Close = 0x0010,
        
        /// <summary>
        /// 
        /// </summary>
        Destroy = 0x0002,
        
        /// <summary>
        /// 
        /// </summary>
        KeyDown = 0x0100,
        
        /// <summary>
        /// 
        /// </summary>
        Size = 0x0005
    }
}

#endif
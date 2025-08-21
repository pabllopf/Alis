#if WIN

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// Window messages.
    /// </summary>
    public enum WindowMessage : uint
    {
        Close = 0x0010,
        Destroy = 0x0002,
        KeyDown = 0x0100,
        Size = 0x0005
    }
}

#endif
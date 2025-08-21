#if OSX
namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    /// Constantes y structs para la plataforma Mac
    /// </summary>
    internal static class MacConstants
    {
        public const ulong NsWindowStyleMaskTitled         = 1UL << 0;
        public const ulong NsWindowStyleMaskClosable       = 1UL << 1;
        public const ulong NsWindowStyleMaskMiniaturizable = 1UL << 2;
        public const ulong NsWindowStyleMaskResizable      = 1UL << 3;
        public const ulong NsBackingStoreBuffered = 2;
        public const long NsApplicationActivationPolicyRegular = 0;
        public const int NsOpenGlpfaOpenGlProfile = 99;
        public const int NsOpenGlProfileVersion32Core = 0x3200;
        public const int NsOpenGlpfaDoubleBuffer = 5;
        public const int NsOpenGlpfaColorSize    = 8;
        public const int NsOpenGlpfaDepthSize    = 12;
        public const uint KCfStringEncodingUtf8 = 0x08000100;
    }
}
#endif


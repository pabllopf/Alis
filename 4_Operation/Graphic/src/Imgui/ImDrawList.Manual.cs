using System.Numerics;
using System.Text;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im draw list ptr
    /// </summary>
    public unsafe partial struct ImDrawListPtr
    {
        /// <summary>
        /// Adds the text using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(Vector2 pos, uint col, string textBegin)
        {
            int textBeginByteCount = Encoding.UTF8.GetByteCount(textBegin);
            byte* nativeTextBegin = stackalloc byte[textBeginByteCount + 1];
            fixed (char* textBeginPtr = textBegin)
            {
                int nativeTextBeginOffset = Encoding.UTF8.GetBytes(textBeginPtr, textBegin.Length, nativeTextBegin, textBeginByteCount);
                nativeTextBegin[nativeTextBeginOffset] = 0;
            }
            byte* nativeTextEnd = null;
            ImGuiNative.ImDrawList_AddText_Vec2(NativePtr, pos, col, nativeTextBegin, nativeTextEnd);
        }

        /// <summary>
        /// Adds the text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="textBegin">The text begin</param>
        public void AddText(ImFontPtr font, float fontSize, Vector2 pos, uint col, string textBegin)
        {
            ImFont* nativeFont = font.NativePtr;
            int textBeginByteCount = Encoding.UTF8.GetByteCount(textBegin);
            byte* nativeTextBegin = stackalloc byte[textBeginByteCount + 1];
            fixed (char* textBeginPtr = textBegin)
            {
                int nativeTextBeginOffset = Encoding.UTF8.GetBytes(textBeginPtr, textBegin.Length, nativeTextBegin, textBeginByteCount);
                nativeTextBegin[nativeTextBeginOffset] = 0;
            }
            byte* nativeTextEnd = null;
            float wrapWidth = 0.0f;
            Vector4* cpuFineClipRect = null;
            ImGuiNative.ImDrawList_AddText_FontPtr(NativePtr, nativeFont, fontSize, pos, col, nativeTextBegin, nativeTextEnd, wrapWidth, cpuFineClipRect);
        }
    }
}

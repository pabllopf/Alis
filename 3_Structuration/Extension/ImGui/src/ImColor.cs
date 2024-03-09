using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Extension.ImGui
{
    /// <summary>
    /// The im color
    /// </summary>
    public struct ImColor
    {
        /// <summary>
        /// The value
        /// </summary>
        public Vector4 Value;

        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImColor_destroy(ref this);
        }

        /// <summary>
        /// Hsv the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <returns>The Hsv</returns>
        public ImColor Hsv(float h, float s, float v)
        {
            const float a = 1.0f;
            ImGuiNative.ImColor_HSV(out ImColor pOut, h, s, v, a);
            return pOut;
        }

        /// <summary>
        /// Hsv the h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        /// <returns>The Hsv</returns>
        public ImColor Hsv(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_HSV(out ImColor pOut, h, s, v, a);
            return pOut;
        }

        /// <summary>
        /// Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        public void SetHsv(float h, float s, float v)
        {
            float a = 1.0f;
            ImGuiNative.ImColor_SetHSV(ref this, h, s, v, a);
        }

        /// <summary>
        /// Sets the hsv using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="s">The </param>
        /// <param name="v">The </param>
        /// <param name="a">The </param>
        public void SetHsv(float h, float s, float v, float a)
        {
            ImGuiNative.ImColor_SetHSV(ref this, h, s, v, a);
        }
    }
}
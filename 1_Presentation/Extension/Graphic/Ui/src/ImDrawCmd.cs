// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 


using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw cmd
    /// </summary>
    public struct ImDrawCmd
    {
        /// <summary>
        ///     The clip rect
        /// </summary>
        public Vector4F ClipRect { get; set; }

        /// <summary>
        ///     The texture id
        /// </summary>
        public IntPtr TextureId { get; set; }

        /// <summary>
        ///     The vtx offset
        /// </summary>
        public uint VtxOffset { get; set; }

        /// <summary>
        ///     The idx offset
        /// </summary>
        public uint IdxOffset { get; set; }

        /// <summary>
        ///     The elem count
        /// </summary>
        public uint ElemCount { get; set; }

        /// <summary>
        ///     The user callback
        /// </summary>
        public IntPtr UserCallback { get; set; }

        /// <summary>
        ///     The user callback data
        /// </summary>
        public IntPtr UserCallbackData { get; set; }

        /// <summary>
        ///     Gets the clip rect
        /// </summary>
        /// <returns>The vector</returns>
        public Vector4F GetClipRect() => ClipRect;

        /// <summary>
        ///     Gets the texture id
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetTextureId() => TextureId;

        /// <summary>
        ///     Gets the vtx offset
        /// </summary>
        /// <returns>The uint</returns>
        public uint GetVtxOffset() => VtxOffset;

        /// <summary>
        ///     Gets the idx offset
        /// </summary>
        /// <returns>The uint</returns>
        public uint GetIdxOffset() => IdxOffset;

        /// <summary>
        ///     Gets the elem count
        /// </summary>
        /// <returns>The uint</returns>
        public uint GetElemCount() => ElemCount;

        /// <summary>
        ///     Gets the user callback
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetUserCallback() => UserCallback;

        /// <summary>
        ///     Gets the user callback data
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetUserCallbackData() => UserCallbackData;

        /// <summary>
        ///     Sets the user callback data using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        public void SetUserCallbackData(IntPtr value) => UserCallbackData = value;

        /// <summary>
        ///     Gets the tex id
        /// </summary>
        /// <returns>The ret</returns>
        public IntPtr GetTexId() => ImGuiNative.ImDrawCmd_GetTexID(ref this);
    }
}
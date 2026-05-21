// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 


using System;

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The clear buffer mask enum
    /// </summary>
    [Flags]
    public enum ClearBufferMask
    {
        /// <summary>
        ///     The depth buffer bit clear buffer mask
        /// </summary>
        DepthBufferBit = 0x00000100,

        /// <summary>
        ///     The accum buffer bit clear buffer mask
        /// </summary>
        AccumBufferBit = 0x00000200,

        /// <summary>
        ///     The stencil buffer bit clear buffer mask
        /// </summary>
        StencilBufferBit = 0x00000400,

        /// <summary>
        ///     The color buffer bit clear buffer mask
        /// </summary>
        ColorBufferBit = 0x00004000
    }
}
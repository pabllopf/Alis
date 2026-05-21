//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 


namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook invoked each frame during the update loop, providing the
    ///     owning entity and 2 additional component references of types
    ///     <typeparamref name="TArg1"/> and <typeparamref name="TArg2"/>.
    /// </summary>
    /// <typeparam name="TArg1">The type of the 1st additional component or data argument.</typeparam>
    /// <typeparam name="TArg2">The type of the 2nd additional component or data argument.</typeparam>
    /// <remarks>
    ///     Only implement one "Update" method per entity to avoid duplicate execution.
    ///     For fewer arguments, use <see cref="IOnUpdate"/> or <see cref="IOnUpdate{TArg}"/>.
    /// </remarks>
    public partial interface IOnUpdate<TArg1, TArg2> : IComponentBase
    {
        /// <summary>
        ///     Invokes the update logic with the owning entity and 2 component references.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        /// <param name="arg1">The 1st additional component reference of type <typeparamref name="TArg1"/>.</param>
        /// <param name="arg2">The 2nd additional component reference of type <typeparamref name="TArg2"/>.</param>
        void Update(IGameObject self, ref TArg1 arg1, ref TArg2 arg2);
    }
}

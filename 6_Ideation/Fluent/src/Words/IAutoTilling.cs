//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 


namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that enables auto-tilling on the target builder.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method for chaining.</typeparam>
    /// <typeparam name="TArgument">The argument type accepted by the fluent method.</typeparam>
    public interface IAutoTilling<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the auto-tilling setting on the builder.
        /// </summary>
        /// <param name="value">The auto-tilling setting to apply.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder AutoTilling(TArgument value);
    }
}
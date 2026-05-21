

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Alis.Core.Audio.Players;

namespace Alis.Core.Audio.Test.Players.Samples
{
    /// <summary>
    ///     The test unix player class
    /// </summary>
    /// <seealso cref="UnixPlayerBase" />
    [ExcludeFromCodeCoverage]
    public class TestUnixPlayer : UnixPlayerBase
    {
        /// <summary>
        ///     Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        public override Task SetVolume(byte percent) =>
            Task.CompletedTask;

        /// <summary>
        ///     Gets the bash command using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The string</returns>
        internal override string GetBashCommand(string fileName) =>
            "bashCommand";
    }
}
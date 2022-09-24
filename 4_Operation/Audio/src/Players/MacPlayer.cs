using System;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    /// The mac player class
    /// </summary>
    /// <seealso cref="UnixPlayerBase"/>
    /// <seealso cref="IPlayer"/>
    internal class MacPlayer : UnixPlayerBase, IPlayer
    {
        /// <summary>
        /// Gets the bash command using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The string</returns>
        protected override string GetBashCommand(string fileName)
        {
            return "afplay";
        }

        /// <summary>
        /// Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        /// <exception cref="ArgumentOutOfRangeException">Percent can't exceed 100</exception>
        public override Task SetVolume(byte percent)
        {
            if (percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent can't exceed 100");

            var tempProcess = StartBashProcess($"osascript -e \"set volume output volume {percent}\"");
            tempProcess.WaitForExit();

            return Task.CompletedTask;
        }
    }
}

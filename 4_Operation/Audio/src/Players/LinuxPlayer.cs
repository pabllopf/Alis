

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The linux player class
    /// </summary>
    /// <seealso cref="UnixPlayerBase" />
    /// <seealso cref="IPlayer" />
    internal class LinuxPlayer : UnixPlayerBase, IPlayer
    {
        /// <summary>
        ///     Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        /// <exception cref="ArgumentOutOfRangeException">Percent can't exceed 100</exception>
        public override Task SetVolume(byte percent)
        {
            if (percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent can't exceed 100");
            }

            Process tempProcess = StartBashProcess($"amixer -M set 'Master' {percent}%");
            tempProcess.WaitForExit();

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Gets the bash command using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>The string</returns>
        internal override string GetBashCommand(string fileName)
        {
            if (Path.GetExtension(fileName).ToLower().Equals(".wav"))
            {
                return "mpg123 -q";
            }

            return "aplay -q";
        }
    }
}
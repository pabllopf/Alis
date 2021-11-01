using Alis.Core.Settings.Configurations;
using Alis.FluentApi;

namespace Alis.Core.Sfml.Builders
{
    /// <summary>Define a builder.</summary>
    public class GeneralBuilder :
        IBuild<General>,
        IName<GeneralBuilder, string>,
        IAuthor<GeneralBuilder, string>
    {
        /// <summary>Sets the author.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public GeneralBuilder Author(string value)
        {
            Game.Setting.General.Author = value;
            return this;
        }

        /// <summary>Builds this instance.</summary>
        /// <returns> </returns>
        public General Build()
        {
            return Game.Setting.General;
        }

        /// <summary>Sets the name.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <br />
        /// </returns>
        public GeneralBuilder Name(string value)
        {
            Game.Setting.General.Name = value;
            return this;
        }
    }
}
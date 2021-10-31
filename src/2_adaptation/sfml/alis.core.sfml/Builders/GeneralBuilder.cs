namespace Alis.Core.Sfml.Builders
{
    using FluentApi;
    using Settings.Configurations;

    /// <summary>Define a builder.</summary>
    public class GeneralBuilder : 
        IBuild<General>,
        IName<GeneralBuilder, string>,
        IAuthor<GeneralBuilder, string>
    {
        /// <summary>Sets the name.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GeneralBuilder Name(string value) 
        {
            Game.Setting.General.Name = value;
            return this;
        }

        /// <summary>Sets the author.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GeneralBuilder Author(string value)
        {
            Game.Setting.General.Author = value;
            return this;
        }

        /// <summary>Builds this instance.</summary>
        /// <returns> </returns>
        public General Build() => Game.Setting.General;

        
    }
}

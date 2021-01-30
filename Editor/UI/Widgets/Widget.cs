//------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Widget.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------------
namespace Alis.Editor.UI.Widgets
{
    /// <summary>Widget define</summary>
    public abstract class Widget
    {
        /// <summary>Draw this instance.</summary>
        public abstract void Draw();

        /// <summary>Opens this instance.</summary>
        public abstract void Open();

        /// <summary>Close this instance.</summary>
        public abstract void Close();
    }
}

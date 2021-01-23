//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="IComponent.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    /// <summary>Define components.</summary>
    public interface IComponent
    {
        /// <summary>Starts this instance.</summary>
        void Start();

        /// <summary>Updates this instance.</summary>
        void Update();
    }
}
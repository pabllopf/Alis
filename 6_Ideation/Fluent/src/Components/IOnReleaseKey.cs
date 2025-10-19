using System;

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    /// Interfaz para gestionar el evento de soltar una tecla
    /// </summary>
    public interface IOnReleaseKey
    {
        /// <summary>
        /// Ons the release key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        void OnReleaseKey(KeyEventInfo info);
    }
}

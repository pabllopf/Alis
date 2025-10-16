using System;

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    /// Interfaz para gestionar el evento de mantener pulsada una tecla
    /// </summary>
    public interface IOnHoldKey
    {
        /// <summary>
        /// Ons the hold key using the specified info
        /// </summary>
        /// <param name="info">The info</param>
        void OnHoldKey(KeyEventInfo info);
    }
}

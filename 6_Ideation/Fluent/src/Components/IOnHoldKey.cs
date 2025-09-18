using System;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    /// Interfaz para gestionar el evento de mantener pulsada una tecla
    /// </summary>
    public interface IOnHoldKey
    {
        void OnHoldKey(KeyEventInfo info);
    }
}

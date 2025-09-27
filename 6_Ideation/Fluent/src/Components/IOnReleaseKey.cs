using System;

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    /// Interfaz para gestionar el evento de soltar una tecla
    /// </summary>
    public interface IOnReleaseKey
    {
        void OnReleaseKey(KeyEventInfo info);
    }
}

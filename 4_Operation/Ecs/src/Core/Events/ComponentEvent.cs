namespace Alis.Core.Ecs.Core.Events;

internal struct ComponentEvent()
{
    internal Event<ComponentID> NormalEvent = new();
    internal GenericEvent? GenericEvent = null;
    public bool HasListeners => NormalEvent.HasListeners || (GenericEvent is { } e && e.HasListeners);
}
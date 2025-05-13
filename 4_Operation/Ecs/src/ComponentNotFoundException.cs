using System;

namespace Alis.Core.Ecs;

internal class ComponentNotFoundException : Exception
{
    public ComponentNotFoundException(Type t)
        : base($"Component of type {t.FullName} not found") { }

    public ComponentNotFoundException(string message)
        : base(message) { }
}
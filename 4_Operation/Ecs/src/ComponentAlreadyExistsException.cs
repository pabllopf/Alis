using System;

namespace Alis.Core.Ecs;

internal class ComponentAlreadyExistsException : Exception
{
    public ComponentAlreadyExistsException(Type t)
        : base($"Component of type {t.FullName} already exists on entity!") { }

    public ComponentAlreadyExistsException(string message)
        : base(message) { }
}
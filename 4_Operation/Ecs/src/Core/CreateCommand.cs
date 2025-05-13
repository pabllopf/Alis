namespace Alis.Core.Ecs.Core;

internal record struct CreateCommand(EntityIDOnly Entity, int BufferIndex, int BufferLength);
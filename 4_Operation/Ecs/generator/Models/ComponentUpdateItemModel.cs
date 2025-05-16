﻿using System;


namespace Alis.Core.Ecs.Generator.Models
{
    internal record struct ComponentUpdateItemModel(
        UpdateModelFlags Flags,
        string FullName, // Alis.Generator.Model.ComponentUpdateItemModel
        string? Namespace, // Alis.Generator.Model
        string ImplInterface, // IComponent
        string HintName, // Alis.Generator.Model.ComponentUpdateItemModel
        string MinimallyQualifiedName, // ComponentUpdateItemModel
        EquatableArray<TypeDeclarationModel> NestedTypes,
        EquatableArray<string> GenericArguments,
        EquatableArray<string> Attributes)
    {
        public static readonly ComponentUpdateItemModel Default = new(default, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, [], [], []);
        public readonly bool HasFlag(UpdateModelFlags updateModelFlags) => Flags.HasFlag(updateModelFlags);

        public readonly bool IsDefault => Flags == UpdateModelFlags.None;

        // ComponentUpdateItemModel
        public readonly ReadOnlySpan<char> Name => FullName.AsSpan(Namespace is null ? 0 : Namespace.Length + 1);

        public readonly bool IsRecord => HasFlag(UpdateModelFlags.IsRecord);
        public readonly bool IsStruct => HasFlag(UpdateModelFlags.IsStruct);
        public readonly bool IsGeneric => HasFlag(UpdateModelFlags.IsGeneric);
    }
}
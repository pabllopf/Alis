using System;
using System.Runtime.InteropServices;


namespace Alis.Core.Ecs.Generator.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct ComponentUpdateItemModel(
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
        /// <summary>
        /// The empty
        /// </summary>
        public static readonly ComponentUpdateItemModel Default = new(default, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, [], [], []);
        /// <summary>
        /// Hases the flag using the specified update model flags
        /// </summary>
        /// <param name="updateModelFlags">The update model flags</param>
        /// <returns>The bool</returns>
        public readonly bool HasFlag(UpdateModelFlags updateModelFlags) => Flags.HasFlag(updateModelFlags);

        /// <summary>
        /// Gets the value of the is default
        /// </summary>
        public readonly bool IsDefault => Flags == UpdateModelFlags.None;

        // ComponentUpdateItemModel
        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public readonly ReadOnlySpan<char> Name => FullName.AsSpan(Namespace is null ? 0 : Namespace.Length + 1);

        /// <summary>
        /// Gets the value of the is record
        /// </summary>
        public readonly bool IsRecord => HasFlag(UpdateModelFlags.IsRecord);
        /// <summary>
        /// Gets the value of the is struct
        /// </summary>
        public readonly bool IsStruct => HasFlag(UpdateModelFlags.IsStruct);
        /// <summary>
        /// Gets the value of the is generic
        /// </summary>
        public readonly bool IsGeneric => HasFlag(UpdateModelFlags.IsGeneric);
    }
}
using Microsoft.CodeAnalysis;

namespace Alis.Core.Ecs.Generator.Models
{
    internal record struct TypeDeclarationModel(bool IsRecord, TypeKind TypeKind, string Name);
}
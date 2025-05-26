using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;

namespace Alis.Core.Ecs.Generator.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct TypeDeclarationModel(bool IsRecord, TypeKind TypeKind, string Name);
}
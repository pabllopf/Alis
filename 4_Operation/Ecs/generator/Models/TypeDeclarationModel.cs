using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;

namespace Alis.Core.Ecs.Generator.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IsRecord"></param>
    /// <param name="TypeKind"></param>
    /// <param name="Name"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct TypeDeclarationModel(bool IsRecord, TypeKind TypeKind, string Name);
}
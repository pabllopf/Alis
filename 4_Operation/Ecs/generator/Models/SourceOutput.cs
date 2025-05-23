using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Generator.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct SourceOutput(string? Name, string Source);
}
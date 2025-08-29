using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Generator.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Source"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct SourceOutput(string Name, string Source);
}
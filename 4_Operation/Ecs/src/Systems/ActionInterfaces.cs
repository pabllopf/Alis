
using static Frent.AttributeHelpers;

namespace Frent.Systems;

/// <summary>
/// An arbitary function with one parameter
/// </summary>
/// <remarks>Used to inline query functions</remarks>


public interface IAction<TArg>
{
    /// Executes the function
    void Run(ref TArg arg);
}
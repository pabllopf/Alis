

namespace Alis.Core.Ecs.Kernel.Events
{
/// <summary>
///     Defines a contract for invoking a generic method with a known first parameter.
///     This interface is used to work around C#'s limitation where delegates cannot 
///     have unbound generic type parameters. By using an interface, we can store 
///     references to methods with unbound generics and invoke them later.
/// </summary>
/// <typeparam name="TParam">The first parameter type that is bound/known when creating the action instance.</typeparam>
/// <remarks>
///     Since delegates cannot be unbound generics (e.g., Action&lt;,&gt; is not valid),
///     we use this interface approach to achieve similar functionality. The interface
///     allows us to store a reference to a method and invoke it with the unbound 
///     generic parameter specified at invocation time.
///     
///     Usage example:
///     <code>
///     // Implement the interface for a specific bound parameter type
///     class StringAction : IGenericAction&lt;string&gt;
///     {
///         public void Invoke&lt;T&gt;(string param, ref T type)
///         {
///             // Implementation here
///             Console.WriteLine($"String: {param}, Type: {typeof(T)}");
///         }
///     }
///     
///     // Use it
///     IGenericAction&lt;string&gt; action = new StringAction();
///     int number = 42;
///     action.Invoke("hello", ref number); // T is inferred as int
///     </code>
/// </remarks>
    public interface IGenericAction<TParam>
    {
        /// <summary>
        ///     Runs the arbitrary generic method that this <see cref="IGenericAction{TParam}" /> represents
        /// </summary>
        /// <typeparam name="T">The unbound generic parameter</typeparam>
        /// <param name="param">The first parameter</param>
        /// <param name="type">The generic parameter</param>
        void Invoke<T>(TParam param, ref T type);
    }

    /// <summary>
    ///     An generic action with known parameter
    /// </summary>
    /// <remarks>Since delegates cannot be unbound generics, we use an interface instead</remarks>
    public interface IGenericAction
    {
        /// <summary>
        ///     Runs the arbitrary generic method that this <see cref="IGenericAction" /> represents
        /// </summary>
        /// <typeparam name="T">The unbound generic parameter</typeparam>
        /// <param name="type">The generic parameter</param>
        void Invoke<T>(ref T type);
    }
}
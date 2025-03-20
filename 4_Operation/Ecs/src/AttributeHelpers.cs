namespace Alis.Core.Ecs
{
    /// <summary>
    /// The attribute helpers class
    /// </summary>
    internal static class AttributeHelpers
    {
        /// <summary>
        /// The debugger display
        /// </summary>
        internal const string DebuggerDisplay = "{DebuggerDisplayString,nq}";

        /// <summary>
        /// The get component ref from
        /// </summary>
        public const string GetComponentRefFrom = "        ref TArg arg = ref b.GetComponentDataReference<TArg>();";
        /// <summary>
        /// The get component ref pattern
        /// </summary>
        public const string GetComponentRefPattern = "|        ref TArg$ arg$ = ref b.GetComponentDataReference<TArg$>();\n|";

        /// <summary>
        /// The inc ref from
        /// </summary>
        public const string IncRefFrom = "            arg = ref Unsafe.Add(ref arg, 1);";
        /// <summary>
        /// The inc ref pattern
        /// </summary>
        public const string IncRefPattern = "|            arg$ = ref Unsafe.Add(ref arg$, 1);\n|";

        /// <summary>
        /// The put arg from
        /// </summary>
        public const string PutArgFrom = "ref arg);";
        /// <summary>
        /// The put arg pattern
        /// </summary>
        public const string PutArgPattern = "|ref arg$, |);";

        /// <summary>
        /// The arg from
        /// </summary>
        public const string TArgFrom = "TArg>";
        /// <summary>
        /// The arg pattern
        /// </summary>
        public const string TArgPattern = "|TArg$, |>";

        /// <summary>
        /// The ref arg from
        /// </summary>
        public const string RefArgFrom = "ref TArg arg";
        /// <summary>
        /// The ref arg pattern
        /// </summary>
        public const string RefArgPattern = "|ref TArg$ arg$, |";

        /// <summary>
        /// The span arg from
        /// </summary>
        public const string SpanArgFrom = "Span<TArg> arg";
        /// <summary>
        /// The span arg pattern
        /// </summary>
        public const string SpanArgPattern = "|Span<TArg$> arg$, |";
    }
}

using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Alis.Core.Aspect.Fluent.Generator
{
    /// <summary>
    /// The aot reflection analyzer class
    /// </summary>
    /// <seealso cref="DiagnosticAnalyzer"/>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AotReflectionAnalyzer : DiagnosticAnalyzer
    {
        // Diagnostic IDs
        /// <summary>
        /// The id reflection api
        /// </summary>
        public const string IdReflectionApi = "ALIS001";
        /// <summary>
        /// The id emit api
        /// </summary>
        public const string IdEmitApi = "ALIS002";
        /// <summary>
        /// The id invoke api
        /// </summary>
        public const string IdInvokeApi = "ALIS003";
        /// <summary>
        /// The id activator api
        /// </summary>
        public const string IdActivatorApi = "ALIS004";
        /// <summary>
        /// The id type get type
        /// </summary>
        public const string IdTypeGetType = "ALIS005";
        /// <summary>
        /// The id dynamic
        /// </summary>
        public const string IdDynamic = "ALIS006";
        /// <summary>
        /// The id serialization
        /// </summary>
        public const string IdSerialization = "ALIS007";
        /// <summary>
        /// The id expression compile
        /// </summary>
        public const string IdExpressionCompile = "ALIS008";
        /// <summary>
        /// The id runtime helpers
        /// </summary>
        public const string IdRuntimeHelpers = "ALIS009";
        /// <summary>
        /// The id unknown reflection
        /// </summary>
        public const string IdUnknownReflection = "ALIS010";

        /// <summary>
        /// The description
        /// </summary>
        private static readonly DiagnosticDescriptor ReflectionApiRule = new DiagnosticDescriptor(
            IdReflectionApi,
            "Use of System.Reflection (possible AOT issue)",
            "Use of reflection API '{0}' may require additional runtime metadata and can break Publish AOT when reflection is disabled",
            "AOT/Reflection",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            description: "Detects direct uses of System.Reflection that usually require access to metadata that AOT may remove if not preserved.");

        /// <summary>
        /// The description
        /// </summary>
        private static readonly DiagnosticDescriptor EmitApiRule = new DiagnosticDescriptor(
            IdEmitApi,
            "Use of Reflection.Emit or dynamic IL generation",
            "Dynamic code generation (Reflection.Emit/DynamicMethod/AssemblyBuilder) is not supported under AOT, usage detected: '{0}'",
            "AOT/CodeGen",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            description: "Detects dynamic code generation APIs that do not work in pure AOT environments.");

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor InvokeApiRule = new DiagnosticDescriptor(
            IdInvokeApi,
            "Invocation via MethodInfo.Invoke / PropertyInfo.GetValue",
            "Dynamic invocation '{0}' depends on runtime metadata and is not compatible with reflection disabled",
            "AOT/Reflection",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor ActivatorRule = new DiagnosticDescriptor(
            IdActivatorApi,
            "Use of Activator.CreateInstance / CreateInstanceFrom",
            "Activator.CreateInstance and variants '{0}' require creating types by name and are not compatible if reflection is disabled or required types are not preserved",
            "AOT/Reflection",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor TypeGetTypeRule = new DiagnosticDescriptor(
            IdTypeGetType,
            "Type.GetType / Assembly.Load",
            "Call to Type.GetType/Assembly.Load '{0}' requires loading types by string which needs metadata not available in AOT if not preserved",
            "AOT/Reflection",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor DynamicRule = new DiagnosticDescriptor(
            IdDynamic,
            "Use of 'dynamic' or IDynamicMetaObjectProvider",
            "Use of 'dynamic' or IDynamicMetaObjectProvider '{0}' requires runtime binders that AOT may remove",
            "AOT/Dynamic",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor SerializationRule = new DiagnosticDescriptor(
            IdSerialization,
            "Reflection-based serializer detected",
            "Serializer using reflection by default '{0}' often fails under AOT if required types are not preserved",
            "AOT/Serialization",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor ExpressionCompileRule = new DiagnosticDescriptor(
            IdExpressionCompile,
            "Expression.Compile() or expression-based code generation",
            "Expression.Compile() generates dynamic IL at runtime and is not supported under AOT, usage detected: '{0}'",
            "AOT/Expression",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor RuntimeHelpersRule = new DiagnosticDescriptor(
            IdRuntimeHelpers,
            "Use of RuntimeHelpers.PrepareMethod or similar",
            "Use of RuntimeHelpers or eager compilation '{0}' may depend on JIT behavior not available in AOT",
            "AOT/Runtime",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary>
        /// The is enabled by default
        /// </summary>
        private static readonly DiagnosticDescriptor UnknownReflectionRule = new DiagnosticDescriptor(
            IdUnknownReflection,
            "Pattern possibly problematic for AOT",
            "Pattern detected that may require runtime reflection: '{0}' review manually for AOT",
            "AOT/ManualReview",
            DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        /// <summary> /// Gets the value of the supported diagnostics /// </summary>
        
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create( ReflectionApiRule, EmitApiRule, InvokeApiRule, ActivatorRule, TypeGetTypeRule, DynamicRule, SerializationRule, ExpressionCompileRule, RuntimeHelpersRule, UnknownReflectionRule);
        
        /// <summary>
        /// Initializes the context
        /// </summary>
        /// <param name="context">The context</param>
        public override void Initialize(AnalysisContext context)
        {
            // Performance
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();

            // Register operations-based actions to reliably catch semantic usage
            context.RegisterOperationAction(AnalyzeInvocation, OperationKind.Invocation);
            context.RegisterOperationAction(AnalyzeObjectCreation, OperationKind.ObjectCreation);
            context.RegisterOperationAction(AnalyzeFieldReference, OperationKind.FieldReference);
            context.RegisterOperationAction(AnalyzePropertyReference, OperationKind.PropertyReference);
            context.RegisterOperationAction(AnalyzeMethodReference, OperationKind.MethodReference);
            context.RegisterOperationAction(AnalyzeConversion, OperationKind.Conversion);

            // Syntax node checks for dynamic keyword and nameof patterns
            context.RegisterSyntaxNodeAction(AnalyzeDynamicUsage, SyntaxKind.IdentifierName);

            // Also inspect Using directives and member access for fully-qualified names
            context.RegisterSyntaxNodeAction(AnalyzeMemberAccess, SyntaxKind.SimpleMemberAccessExpression);
        }

        /// <summary>
        /// Analyzes the invocation using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeInvocation(OperationAnalysisContext context)
        {
            IInvocationOperation invocation = (IInvocationOperation)context.Operation;
            IMethodSymbol method = invocation.TargetMethod;

            string fullName = method.ContainingType?.ToDisplayString() + "." + method.Name;

            // Reflection API calls
            if (IsReflectionType(method.ContainingType))
            {
                // Distinguish emits, invoke, activator, etc.
                if (IsEmitApi(method))
                {
                    Report(context, invocation.Syntax.GetLocation(), EmitApiRule, fullName);
                    return;
                }

                if (IsInvokeApi(method))
                {
                    Report(context, invocation.Syntax.GetLocation(), InvokeApiRule, fullName);
                    return;
                }

                if (IsActivatorApi(method))
                {
                    Report(context, invocation.Syntax.GetLocation(), ActivatorRule, fullName);
                    return;
                }

                if (IsTypeGetTypeApi(method))
                {
                    Report(context, invocation.Syntax.GetLocation(), TypeGetTypeRule, fullName);
                    return;
                }

                // Generic reflection usage
                Report(context, invocation.Syntax.GetLocation(), ReflectionApiRule, fullName);
                return;
            }

            // Expression.Compile
            if (method.ContainingType?.ToDisplayString() == "System.Linq.Expressions.Expression" && method.Name == "Compile")
            {
                Report(context, invocation.Syntax.GetLocation(), ExpressionCompileRule, fullName);
                return;
            }

            // BinaryFormatter / Json serializer detection by method
            if (IsKnownSerializer(method))
            {
                Report(context, invocation.Syntax.GetLocation(), SerializationRule, fullName);
                return;
            }

            // RuntimeHelpers
            if (method.ContainingType?.ToDisplayString() == "System.Runtime.CompilerServices.RuntimeHelpers")
            {
                Report(context, invocation.Syntax.GetLocation(), RuntimeHelpersRule, fullName);
            }
        }

        /// <summary>
        /// Analyzes the object creation using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeObjectCreation(OperationAnalysisContext context)
        {
            IObjectCreationOperation creation = (IObjectCreationOperation)context.Operation;
            ITypeSymbol type = creation.Type;
            string fullName = type?.ToDisplayString();
            if (fullName == null)
            {
                return;
            }

            // new System.Reflection.Emit.DynamicMethod(...) or other emit types
            if (fullName.StartsWith("System.Reflection.Emit") || fullName.Contains("DynamicMethod") || fullName.Contains("AssemblyBuilder"))
            {
                Report(context, creation.Syntax.GetLocation(), EmitApiRule, fullName);
                return;
            }

            // Serialization types like BinaryFormatter
            if (fullName == "System.Runtime.Serialization.Formatters.Binary.BinaryFormatter")
            {
                Report(context, creation.Syntax.GetLocation(), SerializationRule, fullName);
            }
        }

        /// <summary>
        /// Analyzes the field reference using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeFieldReference(OperationAnalysisContext context)
        {
            IFieldReferenceOperation op = (IFieldReferenceOperation)context.Operation;
            string containing = op.Field.ContainingType?.ToDisplayString();
            string name = containing + "." + op.Field.Name;

            if (IsReflectionType(op.Field.ContainingType))
            {
                Report(context, op.Syntax.GetLocation(), ReflectionApiRule, name);
            }
        }

        /// <summary>
        /// Analyzes the property reference using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzePropertyReference(OperationAnalysisContext context)
        {
            IPropertyReferenceOperation op = (IPropertyReferenceOperation)context.Operation;
            string containing = op.Property.ContainingType?.ToDisplayString();
            string name = containing + "." + op.Property.Name;

            if (IsReflectionType(op.Property.ContainingType))
            {
                Report(context, op.Syntax.GetLocation(), ReflectionApiRule, name);
            }
        }

        /// <summary>
        /// Analyzes the method reference using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeMethodReference(OperationAnalysisContext context)
        {
            IMethodReferenceOperation op = (IMethodReferenceOperation)context.Operation;
            string containing = op.Method.ContainingType?.ToDisplayString();
            string name = containing + "." + op.Method.Name;
            if (IsReflectionType(op.Method.ContainingType))
            {
                Report(context, op.Syntax.GetLocation(), ReflectionApiRule, name);
            }
        }

        /// <summary>
        /// Analyzes the conversion using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeConversion(OperationAnalysisContext context)
        {
            // detect casts to dynamic-related interfaces
            IConversionOperation conv = (IConversionOperation)context.Operation;
            ITypeSymbol target = conv.Type;
            if (target == null)
            {
                return;
            }

            string targetName = target.ToDisplayString();
            if (targetName.Contains("IDynamicMetaObjectProvider") || targetName == "dynamic")
            {
                Report(context, conv.Syntax.GetLocation(), DynamicRule, targetName);
            }
        }
        
        /// <summary>
        /// Analyzes the dynamic usage using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeDynamicUsage(SyntaxNodeAnalysisContext context)
        {
            IdentifierNameSyntax id = (IdentifierNameSyntax)context.Node;
        
            // Detecta la palabra clave `dynamic` comparando el texto del token en vez de usar SyntaxKind.DynamicKeyword
            if (string.Equals(id.Identifier.ValueText, "dynamic", StringComparison.Ordinal))
            {
                Report(context, id.GetLocation(), DynamicRule, "dynamic keyword");
                return;
            }
        
            // Heurística para nameof/GetType/GetMethod
            if (id.Identifier.Text.Equals("GetType", StringComparison.Ordinal) || id.Identifier.Text.Equals("GetMethod", StringComparison.Ordinal))
            {
                Report(context, id.GetLocation(), UnknownReflectionRule, id.Identifier.Text);
            }
        }

        /// <summary>
        /// Analyzes the member access using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        private static void AnalyzeMemberAccess(SyntaxNodeAnalysisContext context)
        {
            MemberAccessExpressionSyntax member = (MemberAccessExpressionSyntax)context.Node;
            string text = member.ToString();
            // heurística para detectar cadenas que contengan reflection APIs usadas por nombre
            if (text.Contains("GetMethod(") || text.Contains("GetType(") || text.Contains("GetProperty("))
            {
                Report(context, member.GetLocation(), UnknownReflectionRule, text);
            }
        }

        #region Helpers
        /// <summary>
        /// Reports the context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="location">The location</param>
        /// <param name="rule">The rule</param>
        /// <param name="args">The args</param>
        private static void Report(OperationAnalysisContext context, Location location, DiagnosticDescriptor rule, params object[] args)
        {
            Diagnostic diag = Diagnostic.Create(rule, location, args);
            context.ReportDiagnostic(diag);
        }

        /// <summary>
        /// Reports the context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="location">The location</param>
        /// <param name="rule">The rule</param>
        /// <param name="args">The args</param>
        private static void Report(SyntaxNodeAnalysisContext context, Location location, DiagnosticDescriptor rule, params object[] args)
        {
            Diagnostic diag = Diagnostic.Create(rule, location, args);
            context.ReportDiagnostic(diag);
        }

        /// <summary>
        /// Ises the reflection type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        private static bool IsReflectionType(ITypeSymbol type)
        {
            if (type == null)
            {
                return false;
            }

            string name = type.ToDisplayString();
            // Cubre System.Reflection y subniveles
            if (name.StartsWith("System.Reflection", StringComparison.Ordinal))
            {
                return true;
            }

            // Common reflection/emit related types
            if (name.Contains("System.Type") || name.Contains("System.Reflection.Emit") || name.Contains("System.Reflection.TypeInfo"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ises the emit api using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>The bool</returns>
        private static bool IsEmitApi(IMethodSymbol method)
        {
            string t = method.ContainingType?.ToDisplayString() ?? string.Empty;
            string n = method.Name;
            if (t.StartsWith("System.Reflection.Emit", StringComparison.Ordinal))
            {
                return true;
            }

            if (t.Contains("DynamicMethod") || t.Contains("AssemblyBuilder") || t.Contains("ModuleBuilder"))
            {
                return true;
            }

            if (n.Contains("DefineMethod") || n.Contains("GetILGenerator") || n.Contains("Emit"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ises the invoke api using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>The bool</returns>
        private static bool IsInvokeApi(IMethodSymbol method)
        {
            string t = method.ContainingType?.ToDisplayString() ?? string.Empty;
            string n = method.Name;
            if (t.StartsWith("System.Reflection.MethodInfo", StringComparison.Ordinal) || t.StartsWith("System.Reflection.MemberInfo"))
            {
                return n == "Invoke" || n == "GetValue" || n == "SetValue" || n == "InvokeMember" || n == "GetRuntimeMethod";
            }

            if (t.StartsWith("System.Reflection.PropertyInfo"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ises the activator api using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>The bool</returns>
        private static bool IsActivatorApi(IMethodSymbol method)
        {
            string t = method.ContainingType?.ToDisplayString() ?? string.Empty;
            return t == "System.Activator" && (method.Name.StartsWith("CreateInstance", StringComparison.Ordinal) || method.Name.StartsWith("Create"));
        }

        /// <summary>
        /// Ises the type get type api using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>The bool</returns>
        private static bool IsTypeGetTypeApi(IMethodSymbol method)
        {
            string t = method.ContainingType?.ToDisplayString() ?? string.Empty;
            return (t == "System.Type" && method.Name == "GetType") || (t == "System.Reflection.Assembly" && (method.Name == "Load" || method.Name == "LoadFrom"));
        }

        /// <summary>
        /// Ises the known serializer using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <returns>The bool</returns>
        private static bool IsKnownSerializer(IMethodSymbol method)
        {
            string t = method.ContainingType?.ToDisplayString() ?? string.Empty;
            // heurísticas para detectar uso de serializadores comunes que dependen de reflexión por defecto
            if (t.StartsWith("System.Runtime.Serialization.Formatters.Binary.BinaryFormatter", StringComparison.Ordinal))
            {
                return true;
            }

            if (t.StartsWith("Newtonsoft.Json.JsonConvert", StringComparison.Ordinal))
            {
                return true; // aunque Newtonsoft puede configurarse, la configuración por defecto usa reflexión
            }

            if (t.StartsWith("System.Text.Json.JsonSerializer", StringComparison.Ordinal))
            {
                return true; // System.Text.Json puede requerir metadata para AOT
            }

            if (t.Contains("XmlSerializer"))
            {
                return true; // XmlSerializer genera assemblies dinámicamente o usa reflection
            }

            return false;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using Frent.Components;
using Frent.Core;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Frent.Updating;

/// <summary>
/// Used only for source generation
/// </summary>
public static class GenerationServices
{
    /// <summary>
    /// The user generated type map
    /// </summary>
    internal static readonly Dictionary<Type, (IComponentStorageBaseFactory Factory, int UpdateOrder)> UserGeneratedTypeMap = new();
    /// <summary>
    /// The type attribute cache
    /// </summary>
    internal static readonly Dictionary<Type, HashSet<Type>> TypeAttributeCache = new();
    /// <summary>
    /// The type initers
    /// </summary>
    internal static readonly Dictionary<Type, Delegate> TypeIniters = new();
    /// <summary>
    /// The type destroyers
    /// </summary>
    internal static readonly Dictionary<Type, Delegate> TypeDestroyers = new();

    /// <summary>
    /// Used only for source generation
    /// </summary>
    public static void RegisterInit<T>()
        where T : IInitable
    {
        TypeIniters[typeof(T)] = (ComponentDelegates<T>.InitDelegate)([method: DebuggerHidden, DebuggerStepThrough] static (Entity e, ref T c) => c.Init(e));
    }

    /// <summary>
    /// Used only for source generation
    /// </summary>
    public static void RegisterDestroy<T>()
        where T : IDestroyable
    {
        TypeDestroyers[typeof(T)] = (ComponentDelegates<T>.DestroyDelegate)([method: DebuggerHidden, DebuggerStepThrough] static (ref T c) => c.Destroy());
    }

    /// <summary>
    /// Used only for source generation
    /// </summary>
    public static void RegisterType(Type type, object fact)
    {
        if (fact is not IComponentStorageBaseFactory value)
            throw new InvalidOperationException("Source generation appears to be broken. This method should not be called from user code!");

        if (UserGeneratedTypeMap.TryGetValue(type, out var val))
        {
            if (val.Factory.GetType() != value.GetType())
            {
                throw new Exception($"Attempted to initalize {type.FullName} with {val.GetType().FullName} and {value.GetType().FullName}");
            }
        }
        else
        {
            UserGeneratedTypeMap.Add(type, (value, 0));
        }
    }

    /// <summary>
    /// Used only for source generation
    /// </summary>
    public static void RegisterUpdateMethodAttribute(Type attributeType, Type componentType)
    {
        if (!TypeAttributeCache.TryGetValue(attributeType, out var set))
            set = TypeAttributeCache[attributeType] = [];
        set.Add(componentType);
    }
}
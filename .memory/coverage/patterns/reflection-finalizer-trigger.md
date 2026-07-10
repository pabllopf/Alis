# Pattern: Triggering Finalizer Execution via Reflection

## Problem
Classes with `CriticalFinalizerObject` base class have finalizers that cannot run while the instance
is referenced by a private static list (`_registeredCallbacks`). Testing the finalizer requires making
the instance eligible for GC.

## Solution
Use reflection to clear the private static list, then force GC collections:

```csharp
private static void ClearRegisteredCallbacks()
{
    FieldInfo field = typeof(Gen2GcCallback).GetField(
        "registeredCallbacks",
        BindingFlags.Static | BindingFlags.NonPublic);

    if (field?.GetValue(null) is List<Gen2GcCallback> list)
    {
        list.Clear();
    }
}
```

Then trigger:
```csharp
GC.Collect(2, GCCollectionMode.Forced, blocking: true);
GC.WaitForPendingFinalizers();
```

## Target Isolation
For tests involving dead target objects, allocate and register in a separate method
to allow the JIT to release local references:

```csharp
private static void RegisterTargetInScope(bool[] called)
{
    object target = new object();
    Gen2GcCallback.Register(obj => { called[0] = true; return false; }, target);
}
```

## Applicable To
Any class with private static collections that prevent GC finalization of instances.

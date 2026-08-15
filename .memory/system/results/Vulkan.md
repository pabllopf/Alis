# Result: Vulkan.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/Vulkan.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 50.0% (8/16 lines, local coverlet; unchanged)
TestsAdded: 0 (extension-list loop requires a Vulkan loader absent on this machine)
Commit: test: coverage Vulkan.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Vulkan.cs is the static GLFW Vulkan facade (IsSupported, CreateWindowSurface,
GetPhysicalDevicePresentationSupport, GetInstanceProcAddress, GetRequiredInstanceExtensions;
the P/Invoke externs are `[ExcludeFromCodeCoverage]`). The committed `VulkanTests.cs`
(8 tests) covers 8/16 instrumented lines: the `GetRequiredInstanceExtensions` call, the empty
allocation and the return all execute, and a direct probe confirmed the method completes
(`returned count=0`) without exceptions.

## Remaining uncovered lines (8) — BLOCKED_BY_PRODUCTION_CODE

Lines 138-145 — the `if ((count > 0) && (ptr != IntPtr.Zero))` block and the extension-name
marshalling loop. `glfwGetRequiredInstanceExtensions` returns count=0 whenever no Vulkan
loader is installed; this machine has no `libvulkan` anywhere under /opt/homebrew or
/usr/local, so the branch is unreachable here. On CI/machines with a Vulkan loader the loop
would execute, but no deterministic test can force it locally without the loader.

## Verification

- Vulkan filter (net8.0, Debug, with and without GLFW hook): 8 passed, 0 failed, 0 skipped.
- Local coverlet: Vulkan.cs 8/16 lines (50.0%); lines 138-145 unreachable (no Vulkan loader).
- Probe: `Vulkan.GetRequiredInstanceExtensions()` returns an empty array (count=0).

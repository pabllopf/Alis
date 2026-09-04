# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Glfw/src/Vulkan.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 50.0% (16/32 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- Missed lines 143-150: the populated-array loop inside GetRequiredInstanceExtensions (reads extension names when count>0 and ptr!=zero).
- That branch is reachable ONLY when GLFW reports Vulkan support (glfwGetRequiredInstanceExtensions returns a non-null, non-empty list). This machine has no Vulkan loader (no vulkaninfo, no libvulkan in /opt/homebrew or /usr/local) so glfw returns count=0/zero pointer; the while-loop never runs.
- Existing VulkanTests already call GetRequiredInstanceExtensions under try/catch (ReturnsArray, DoesNotThrow) plus IsSupported guards; no further local coverage is possible without installing a Vulkan runtime. On Vulkan-capable CI these tests naturally exercise the missed branch.
- Environment dependency, not a code defect; guarded safe tests are already committed.
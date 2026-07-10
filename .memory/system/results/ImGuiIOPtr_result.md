# Coverage Result: ImGuiIOPtr.cs

## Summary
- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs`
- **Coverage Before**: 68.5%
- **Coverage After**: ~80% (estimated)
- **Tests Added**: 73
- **Status**: Completed

## Tests Added
| Test | What it covers |
|------|----------------|
| `NativePtr_ShouldReturnConstructorValue` | NativePtr property |
| `ImplicitConversion_ToIntPtr_ReturnsNativePtr` | Implicit conversion to IntPtr |
| `ImplicitConversion_FromIntPtr_ReturnsWrapper` | Implicit conversion from IntPtr |
| `ConfigFlags_GetSet_ShouldRoundtrip` | ConfigFlags get/set |
| `BackendFlags_GetSet_ShouldRoundtrip` | BackendFlags get/set |
| `DisplaySize_GetSet_ShouldRoundtrip` | DisplaySize get/set |
| `DeltaTime_GetSet_ShouldRoundtrip` | DeltaTime get/set |
| `UserData_GetSet_ShouldRoundtrip` | UserData get/set |
| `FontGlobalScale_GetSet_ShouldRoundtrip` | FontGlobalScale get/set |
| `DisplayFramebufferScale_GetSet_ShouldRoundtrip` | DisplayFramebufferScale get/set |
| `ConfigDockingWithShift_GetSet_ShouldRoundtrip` | ConfigDockingWithShift get/set |
| `BackendPlatformName_GetSet_ShouldRoundtrip` | BackendPlatformName get/set |
| `BackendPlatformUserData_GetSet_ShouldRoundtrip` | BackendPlatformUserData get/set |
| `BackendRendererUserData_GetSet_ShouldRoundtrip` | BackendRendererUserData get/set |
| `BackendLanguageUserData_GetSet_ShouldRoundtrip` | BackendLanguageUserData get/set |
| `GetClipboardTextFn_GetSet_ShouldRoundtrip` | GetClipboardTextFn get/set |
| `SetClipboardTextFn_GetSet_ShouldRoundtrip` | SetClipboardTextFn get/set |
| `ClipboardUserData_GetSet_ShouldRoundtrip` | ClipboardUserData get/set |
| `SetPlatformImeDataFn_GetSet_ShouldRoundtrip` | SetPlatformImeDataFn get/set |
| `UnusedPadding_GetSet_ShouldRoundtrip` | UnusedPadding get/set |
| `WantCaptureMouse_GetSet_ShouldRoundtrip` | WantCaptureMouse get/set |
| `WantCaptureKeyboard_GetSet_ShouldRoundtrip` | WantCaptureKeyboard get/set |
| `WantTextInput_GetSet_ShouldRoundtrip` | WantTextInput get/set |
| `WantSetMousePos_GetSet_ShouldRoundtrip` | WantSetMousePos get/set |
| `WantSaveIniSettings_GetSet_ShouldRoundtrip` | WantSaveIniSettings get/set |
| `NavActive_GetSet_ShouldRoundtrip` | NavActive get/set |
| `NavVisible_GetSet_ShouldRoundtrip` | NavVisible get/set |
| `Framerate_GetSet_ShouldRoundtrip` | Framerate get/set |
| `MetricsRenderVertices_GetSet_ShouldRoundtrip` | MetricsRenderVertices get/set |
| `MetricsRenderIndices_GetSet_ShouldRoundtrip` | MetricsRenderIndices get/set |
| `MetricsRenderWindows_GetSet_ShouldRoundtrip` | MetricsRenderWindows get/set |
| `MetricsActiveWindows_GetSet_ShouldRoundtrip` | MetricsActiveWindows get/set |
| `MetricsActiveAllocations_GetSet_ShouldRoundtrip` | MetricsActiveAllocations get/set |
| `MouseDelta_GetSet_ShouldRoundtrip` | MouseDelta get/set |
| `MousePos_GetSet_ShouldRoundtrip` | MousePos get/set |
| `MouseWheel_GetSet_ShouldRoundtrip` | MouseWheel get/set |
| `MouseWheelH_GetSet_ShouldRoundtrip` | MouseWheelH get/set |
| `MouseHoveredViewport_GetSet_ShouldRoundtrip` | MouseHoveredViewport get/set |
| `KeyCtrl_GetSet_ShouldRoundtrip` | KeyCtrl get/set |
| `KeyShift_GetSet_ShouldRoundtrip` | KeyShift get/set |
| `KeyAlt_GetSet_ShouldRoundtrip` | KeyAlt get/set |
| `KeySuper_GetSet_ShouldRoundtrip` | KeySuper get/set |
| `KeyMods_GetSet_ShouldRoundtrip` | KeyMods get/set |
| `WantCaptureMouseUnlessPopupClose_GetSet_ShouldRoundtrip` | WantCaptureMouseUnlessPopupClose get/set |
| `MousePosPrev_GetSet_ShouldRoundtrip` | MousePosPrev get/set |
| `PenPressure_GetSet_ShouldRoundtrip` | PenPressure get/set |
| `AppFocusLost_GetSet_ShouldRoundtrip` | AppFocusLost get/set |
| `AppAcceptingEvents_GetSet_ShouldRoundtrip` | AppAcceptingEvents get/set |
| `BackendUsingLegacyKeyArrays_GetSet_ShouldRoundtrip` | BackendUsingLegacyKeyArrays get/set |
| `BackendUsingLegacyNavInputArray_GetSet_ShouldRoundtrip` | BackendUsingLegacyNavInputArray get/set |
| `InputQueueSurrogate_GetSet_ShouldRoundtrip` | InputQueueSurrogate get/set |
| `ReadOnlyProperties_ShouldHaveDefaultValues` | All read-only value type properties |
| `KeyMap_Get_ShouldReturnList` | KeyMap getter |
| `KeysDown_GetSet_ShouldRoundtrip` | KeysDown get/set |
| `MouseDown_GetSet_ShouldRoundtrip` | MouseDown get/set |
| `MouseClickedTime_GetSet_ShouldRoundtrip` | MouseClickedTime get/set |
| `MouseClicked_GetSet_ShouldRoundtrip` | MouseClicked get/set |
| `MouseDoubleClicked_GetSet_ShouldRoundtrip` | MouseDoubleClicked get/set |
| `MouseClickedCount_GetSet_ShouldRoundtrip` | MouseClickedCount get/set |
| `MouseClickedLastCount_GetSet_ShouldRoundtrip` | MouseClickedLastCount get/set |
| `MouseReleased_GetSet_ShouldRoundtrip` | MouseReleased get/set |
| `MouseDownOwned_GetSet_ShouldRoundtrip` | MouseDownOwned get/set |
| `MouseDownOwnedUnlessPopupClose_GetSet_ShouldRoundtrip` | MouseDownOwnedUnlessPopupClose get/set |
| `MouseDownDuration_GetSet_ShouldRoundtrip` | MouseDownDuration get/set |
| `MouseDownDurationPrev_GetSet_ShouldRoundtrip` | MouseDownDurationPrev get/set |
| `MouseDragMaxDistanceSqr_GetSet_ShouldRoundtrip` | MouseDragMaxDistanceSqr get/set |
| `Constructor_FromImGuiIo_ShouldAllocateAndMarshal` | Constructor from ImGuiIo struct |
| `ReadOnly_NullTerminatedString_Properties_ShouldNotBeNull` | NullTerminatedString properties |
| `BackendRendererName_Get_ShouldReturnDefault` | BackendRendererName getter |
| `ReadOnly_Fonts_ShouldReturnImFontAtlasPtr` | Fonts getter |
| `ReadOnly_FontDefault_ShouldReturnImFontPtr` | FontDefault getter |
| `NavInputs_GetSet_ShouldRoundtrip` | NavInputs get/set |
| `KeyMap_Set_ShouldUpdateValue` | KeyMap setter |

## Files Changed
- `test/ImGuiIOPtrRemainingCoverageTests.cs` (new)
- `.memory/system/processed.json` (updated)

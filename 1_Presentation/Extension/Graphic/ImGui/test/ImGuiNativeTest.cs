// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNativeTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im gui native test class
    /// </summary>
    public class ImGuiNativeTest
    {
        /// <summary>
        ///     Tests that im gui input text callback data clear selection should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiInputTextCallbackData_ClearSelection_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiInputTextCallbackData_ClearSelection(self));
        }

        /// <summary>
        ///     Tests that im gui input text callback data delete chars should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiInputTextCallbackData_DeleteChars_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            int pos = 0;
            int bytesCount = 5;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiInputTextCallbackData_DeleteChars(self, pos, bytesCount));
        }

        /// <summary>
        ///     Tests that im gui input text callback data has selection should return byte
        /// </summary>
        [Fact]
        public void ImGuiInputTextCallbackData_HasSelection_ShouldReturnByte()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiInputTextCallbackData_HasSelection(self));
        }

        /// <summary>
        ///     Tests that im gui input text callback data im gui input text callback data should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiInputTextCallbackData_ImGuiInputTextCallbackData_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiInputTextCallbackData_ImGuiInputTextCallbackData());
        }

        /// <summary>
        ///     Tests that im gui input text callback data insert chars should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiInputTextCallbackData_InsertChars_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            int pos = 0;
            byte[] text = {65, 66, 67};
            byte[] textEnd = {68, 69, 70};
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiInputTextCallbackData_InsertChars(self, pos, text, textEnd));
        }

        /// <summary>
        ///     Tests that im gui input text callback data select all should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiInputTextCallbackData_SelectAll_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiInputTextCallbackData_SelectAll(self));
        }

        /// <summary>
        ///     Tests that im gui io add focus event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddFocusEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            byte focused = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddFocusEvent(self, focused));
        }

        /// <summary>
        ///     Tests that im gui io add input character should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddInputCharacter_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            uint c = 65;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddInputCharacter(self, c));
        }

        /// <summary>
        ///     Tests that im gui io add input characters utf 8 should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddInputCharactersUTF8_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            byte[] str = {65, 66, 67};
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddInputCharactersUTF8(self, str));
        }

        /// <summary>
        ///     Tests that im gui io add input character utf 16 should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddInputCharacterUTF16_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            ushort c = 65;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddInputCharacterUTF16(self, c));
        }

        /// <summary>
        ///     Tests that im gui io add key analog event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddKeyAnalogEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            ImGuiKey key = ImGuiKey.Tab;
            byte down = 1;
            float v = 0.5f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddKeyAnalogEvent(self, key, down, v));
        }

        /// <summary>
        ///     Tests that im gui io add key event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddKeyEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            ImGuiKey key = ImGuiKey.Tab;
            byte down = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddKeyEvent(self, key, down));
        }

        /// <summary>
        ///     Tests that im gui io add mouse button event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddMouseButtonEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            int button = 0;
            byte down = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddMouseButtonEvent(self, button, down));
        }

        /// <summary>
        ///     Tests that im gui io add mouse pos event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddMousePosEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            float x = 100.0f;
            float y = 200.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddMousePosEvent(self, x, y));
        }

        /// <summary>
        ///     Tests that im gui io add mouse viewport event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddMouseViewportEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            uint id = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddMouseViewportEvent(self, id));
        }

        /// <summary>
        ///     Tests that im gui io add mouse wheel event should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_AddMouseWheelEvent_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            float whX = 1.0f;
            float whY = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_AddMouseWheelEvent(self, whX, whY));
        }

        /// <summary>
        ///     Tests that im gui io clear input characters should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_ClearInputCharacters_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_ClearInputCharacters(self));
        }

        /// <summary>
        ///     Tests that im gui io clear input keys should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_ClearInputKeys_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_ClearInputKeys(self));
        }

        /// <summary>
        ///     Tests that im gui io im gui io should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiIO_ImGuiIO_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_ImGuiIO());
        }

        /// <summary>
        ///     Tests that im gui io set app accepting events should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_SetAppAcceptingEvents_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            byte acceptingEvents = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_SetAppAcceptingEvents(self, acceptingEvents));
        }

        /// <summary>
        ///     Tests that im gui io set key event native data should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiIO_SetKeyEventNativeData_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            ImGuiKey key = ImGuiKey.Tab;
            int nativeKeycode = 65;
            int nativeScancode = 66;
            int nativeLegacyIndex = 67;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiIO_SetKeyEventNativeData(self, key, nativeKeycode, nativeScancode, nativeLegacyIndex));
        }

        /// <summary>
        ///     Tests that im gui list clipper begin should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiListClipper_Begin_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            int itemsCount = 10;
            float itemsHeight = 20.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiListClipper_Begin(self, itemsCount, itemsHeight));
        }

        /// <summary>
        ///     Tests that im gui list clipper end should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiListClipper_End_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiListClipper_End(self));
        }

        /// <summary>
        ///     Tests that im gui list clipper force display range by indices should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiListClipper_ForceDisplayRangeByIndices_ShouldInvokeNativeMethod()
        {
            IntPtr self = new IntPtr(1);
            int itemMin = 0;
            int itemMax = 10;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiListClipper_ForceDisplayRangeByIndices(self, itemMin, itemMax));
        }

        /// <summary>
        ///     Tests that im gui list clipper im gui list clipper should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiListClipper_ImGuiListClipper_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiListClipper_ImGuiListClipper());
        }

        /// <summary>
        ///     Tests that im gui list clipper step should return byte
        /// </summary>
        [Fact]
        public void ImGuiListClipper_Step_ShouldReturnByte()
        {
            IntPtr self = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiListClipper_Step(self));
        }

        /// <summary>
        ///     Tests that im gui once upon a frame im gui once upon a frame should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiOnceUponAFrame_ImGuiOnceUponAFrame_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiOnceUponAFrame_ImGuiOnceUponAFrame());
        }

        /// <summary>
        ///     Tests that im gui payload clear should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiPayload_Clear_ShouldInvokeNativeMethod()
        {
            ImGuiPayload self = new ImGuiPayload();
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPayload_Clear(ref self));
        }

        /// <summary>
        ///     Tests that im gui payload im gui payload should return im gui payload
        /// </summary>
        [Fact]
        public void ImGuiPayload_ImGuiPayload_ShouldReturnImGuiPayload()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPayload_ImGuiPayload());
        }

        /// <summary>
        ///     Tests that im gui payload is data type should return byte
        /// </summary>
        [Fact]
        public void ImGuiPayload_IsDataType_ShouldReturnByte()
        {
            ImGuiPayload self = new ImGuiPayload();
            byte[] type = {65, 66, 67};
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPayload_IsDataType(ref self, type));
        }

        /// <summary>
        ///     Tests that im gui payload is delivery should return byte
        /// </summary>
        [Fact]
        public void ImGuiPayload_IsDelivery_ShouldReturnByte()
        {
            ImGuiPayload self = new ImGuiPayload();
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPayload_IsDelivery(ref self));
        }

        /// <summary>
        ///     Tests that im gui payload is preview should return byte
        /// </summary>
        [Fact]
        public void ImGuiPayload_IsPreview_ShouldReturnByte()
        {
            ImGuiPayload self = new ImGuiPayload();
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPayload_IsPreview(ref self));
        }

        /// <summary>
        ///     Tests that im gui platform ime data im gui platform ime data should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiPlatformImeData_ImGuiPlatformImeData_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPlatformImeData_ImGuiPlatformImeData());
        }


        /// <summary>
        ///     Tests that im gui platform io im gui platform io should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiPlatformIO_ImGuiPlatformIO_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPlatformIO_ImGuiPlatformIO());
        }

        /// <summary>
        ///     Tests that im gui platform monitor im gui platform monitor should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiPlatformMonitor_ImGuiPlatformMonitor_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiPlatformMonitor_ImGuiPlatformMonitor());
        }

        /// <summary>
        ///     Tests that im gui storage build sort by key should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_BuildSortByKey_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_BuildSortByKey(self));
        }

        /// <summary>
        ///     Tests that im gui storage clear should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_Clear_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_Clear(self));
        }

        /// <summary>
        ///     Tests that im gui storage get bool should return byte
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetBool_ShouldReturnByte()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            byte defaultVal = 0;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetBool(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage get bool ref should return byte array
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetBoolRef_ShouldReturnByteArray()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            byte defaultVal = 0;
            Assert.Throws<MarshalDirectiveException>(() => ImGuiNative.ImGuiStorage_GetBoolRef(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage get float should return float
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetFloat_ShouldReturnFloat()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            float defaultVal = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetFloat(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage get float ref should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetFloatRef_ShouldReturnIntPtr()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            float defaultVal = 0.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetFloatRef(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage get int should return int
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetInt_ShouldReturnInt()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            int defaultVal = 0;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetInt(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage get int ref should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetIntRef_ShouldReturnIntPtr()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            int defaultVal = 0;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetIntRef(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage get void ptr should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetVoidPtr_ShouldReturnIntPtr()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetVoidPtr(self, key));
        }

        /// <summary>
        ///     Tests that im gui storage get void ptr ref should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStorage_GetVoidPtrRef_ShouldReturnIntPtr()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            IntPtr defaultVal = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_GetVoidPtrRef(self, key, defaultVal));
        }

        /// <summary>
        ///     Tests that im gui storage set all int should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_SetAllInt_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            int val = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_SetAllInt(self, val));
        }

        /// <summary>
        ///     Tests that im gui storage set bool should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_SetBool_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            byte val = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_SetBool(self, key, val));
        }

        /// <summary>
        ///     Tests that im gui storage set float should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_SetFloat_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            float val = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_SetFloat(self, key, val));
        }

        /// <summary>
        ///     Tests that im gui storage set int should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_SetInt_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            int val = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_SetInt(self, key, val));
        }

        /// <summary>
        ///     Tests that im gui storage set void ptr should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStorage_SetVoidPtr_ShouldInvokeNativeMethod()
        {
            ImGuiStorage self = new ImGuiStorage();
            uint key = 1;
            IntPtr val = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStorage_SetVoidPtr(self, key, val));
        }

        /// <summary>
        ///     Tests that im gui storage pair im gui storage pair int should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStoragePair_ImGuiStoragePair_Int_ShouldReturnIntPtr()
        {
            uint key = 1;
            int valI = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStoragePair_ImGuiStoragePair_Int(key, valI));
        }

        /// <summary>
        ///     Tests that im gui storage pair im gui storage pair float should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStoragePair_ImGuiStoragePair_Float_ShouldReturnIntPtr()
        {
            uint key = 1;
            float valF = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStoragePair_ImGuiStoragePair_Float(key, valF));
        }

        /// <summary>
        ///     Tests that im gui storage pair im gui storage pair ptr should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStoragePair_ImGuiStoragePair_Ptr_ShouldReturnIntPtr()
        {
            uint key = 1;
            IntPtr valP = new IntPtr(1);
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStoragePair_ImGuiStoragePair_Ptr(key, valP));
        }

        /// <summary>
        ///     Tests that im gui style im gui style should return int ptr
        /// </summary>
        [Fact]
        public void ImGuiStyle_ImGuiStyle_ShouldReturnIntPtr()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStyle_ImGuiStyle());
        }

        /// <summary>
        ///     Tests that im gui style scale all sizes should invoke native method
        /// </summary>
        [Fact]
        public void ImGuiStyle_ScaleAllSizes_ShouldInvokeNativeMethod()
        {
            ImGuiStyle self = new ImGuiStyle();
            float scaleFactor = 1.5f;
            Assert.Throws<DllNotFoundException>(() => ImGuiNative.ImGuiStyle_ScaleAllSizes(self, scaleFactor));
        }
    }
}
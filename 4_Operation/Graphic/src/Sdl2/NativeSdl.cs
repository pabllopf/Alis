// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeSdl.cs
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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Properties;
using Alis.Core.Graphic.Sdl2.Delegates;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;

namespace Alis.Core.Graphic.Sdl2
{
    /// <summary>
    ///     The native sdl class
    /// </summary>
    internal static class NativeSdl
    {
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2";
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sdl" /> class
        /// </summary>
        static NativeSdl() => EmbeddedDllClass.ExtractEmbeddedDlls("sdl2", DllType.Lib, Sdl2Dlls.GlSdlDllBytes, Assembly.GetAssembly(typeof(Sdl2Dlls)));
        
        /// <summary>
        ///     Sdl the joystick is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickIsHaptic", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickIsHaptic([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the mouse is haptic
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MouseIsHaptic", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalMouseIsHaptic();
        
        /// <summary>
        ///     Sdl the num haptics
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumHaptics", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalNumHaptics();
        
        /// <summary>
        ///     Sdl the close audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_CloseAudioDevice", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalCloseAudioDevice([IsNotNull] uint dev);
        
        /// <summary>
        ///     Internals the sdl get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetAudioDeviceName([IsNotNull] int index, [IsNotNull] int isCapture);
        
        /// <summary>
        ///     Sdl the get audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceStatus", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern AudioStatus InternalGetAudioDeviceStatus([IsNotNull] uint dev);
        
        /// <summary>
        ///     Internals the sdl get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetAudioDriver([IsNotNull] int index);
        
        /// <summary>
        ///     Internals the sdl get current audio driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetCurrentAudioDriver();
        
        /// <summary>
        ///     Sdl the get num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumAudioDevices", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumAudioDevices([IsNotNull] int isCapture);
        
        /// <summary>
        ///     Sdl the get num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumAudioDrivers", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumAudioDrivers();
        
        /// <summary>
        ///     Internals the sdl load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalLoadWAV_RW([IsNotNull] IntPtr src, [IsNotNull] int freeSrc, out AudioSpec spec, out IntPtr audioBuf, out uint audioLen);
        
        /// <summary>
        ///     Sdl the lock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockAudioDevice", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalLockAudioDevice([IsNotNull] uint dev);
        
        /// <summary>
        ///     Sdl the mix audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudio", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalMixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2), IsNotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2), IsNotNull] byte[] src, [IsNotNull] uint len, [IsNotNull] int volume);
        
        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudioFormat", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalMixAudioFormat([IsNotNull] IntPtr dst, [IsNotNull] IntPtr src, [IsNotNull] ushort format, [IsNotNull] uint len, [IsNotNull] int volume);
        
        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudioFormat", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalMixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3), IsNotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3), IsNotNull] byte[] src, [IsNotNull] ushort format, [IsNotNull] uint len, [IsNotNull] int volume);
        
        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalOpenAudioDevice([IsNotNull] IntPtr device, [IsNotNull] int isCapture, ref AudioSpec desired, out AudioSpec obtained, [IsNotNull] int allowedChanges);
        
        /// <summary>
        ///     Internals the sdl open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalOpenAudioDevice([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string device, [IsNotNull] int isCapture, ref AudioSpec desired, out AudioSpec obtained, [IsNotNull] int allowedChanges);
        
        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_PauseAudio", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalPauseAudio([IsNotNull] int pauseOn);
        
        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_PauseAudioDevice", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalPauseAudioDevice([IsNotNull] uint dev, [IsNotNull] int pauseOn);
        
        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockAudioDevice", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalUnlockAudioDevice([IsNotNull] uint dev);
        
        /// <summary>
        ///     Sdl the new audio stream using the specified src format
        /// </summary>
        /// <param name="srcFormat">The src format</param>
        /// <param name="srcChannels">The src channels</param>
        /// <param name="srcRate">The src rate</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dstChannels">The dst channels</param>
        /// <param name="dstRate">The dst rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NewAudioStream", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalNewAudioStream([IsNotNull] ushort srcFormat, [IsNotNull] byte srcChannels, [IsNotNull] int srcRate, [IsNotNull] ushort dstFormat, [IsNotNull] byte dstChannels, [IsNotNull] int dstRate);
        
        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamPut", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalAudioStreamPut([IsNotNull] IntPtr stream, [IsNotNull] IntPtr buf, [IsNotNull] int len);
        
        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamGet", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalAudioStreamGet([IsNotNull] IntPtr stream, [IsNotNull] IntPtr buf, [IsNotNull] int len);
        
        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamAvailable", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalAudioStreamAvailable(IntPtr stream);
        
        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamClear", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalAudioStreamClear([IsNotNull] IntPtr stream);
        
        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeAudioStream", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalFreeAudioStream([IsNotNull] IntPtr stream);
        
        /// <summary>
        ///     Internals the sdl set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipboardText", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetClipboardText([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text);
        
        /// <summary>
        ///     Sdl the peep events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PeepEvents", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalPeepEvents([Out] Event[] events, [IsNotNull] int numEvents, EventAction action, EventType minType, EventType maxType);
        
        /// <summary>
        ///     Sdl the has event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasEvent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalHasEvent(EventType type);
        
        /// <summary>
        ///     Sdl the has events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasEvents", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalHasEvents(EventType minType, EventType maxType);
        
        /// <summary>
        ///     Sdl the flush event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlushEvent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalFlushEvent(EventType type);
        
        /// <summary>
        ///     Sdl the poll event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PollEvent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalPollEvent(out Event sdlEvent);
        
        /// <summary>
        ///     Sdl the push event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PushEvent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalPushEvent(ref Event sdlEvent);
        
        /// <summary>
        ///     Sdl the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetEventFilter", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetEventFilter(SdlEventFilter filter, [IsNotNull] IntPtr userdata);
        
        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetEventFilter", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalGetEventFilter(out IntPtr filter, out IntPtr userdata);
        
        /// <summary>
        ///     Sdl the add event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_AddEventWatch", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalAddEventWatch(SdlEventFilter filter, [IsNotNull] IntPtr userdata);
        
        /// <summary>
        ///     Sdl the del event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DelEventWatch", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalDelEventWatch(SdlEventFilter filter, [IsNotNull] IntPtr userdata);
        
        /// <summary>
        ///     Sdl the event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="state">The state</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_EventState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern byte InternalEventState(EventType type, [IsNotNull] int state);
        
        /// <summary>
        ///     Sdl the register events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RegisterEvents", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalRegisterEvents([IsNotNull] int numEvents);
        
        /// <summary>
        ///     Sdl the get keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyboardFocus", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetKeyboardFocus();
        
        /// <summary>
        ///     Sdl the get keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyboardState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetKeyboardState(out int numKeys);
        
        /// <summary>
        ///     Sdl the get mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetModState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern KeyMods InternalGetModState();
        
        /// <summary>
        ///     Sdl the set mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetModState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetModState(KeyMods modState);
        
        /// <summary>
        ///     Sdl the get key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromScancode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern KeyCode InternalGetKeyFromScancode(SdlScancode scancode);
        
        /// <summary>
        ///     Sdl the get scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromKey", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern SdlScancode InternalGetScancodeFromKey(KeyCode key);
        
        /// <summary>
        ///     Internals the sdl get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetScancodeName(SdlScancode scancode);
        
        /// <summary>
        ///     Internals the sdl get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromName", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern SdlScancode InternalGetScancodeFromName([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        ///     Internals the sdl get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetKeyName(KeyCode key);
        
        /// <summary>
        ///     Internals the sdl get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromName", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern KeyCode InternalGetKeyFromName([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        ///     Sdl the start text input
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_StartTextInput", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalStartTextInput();
        
        /// <summary>
        ///     Sdl the is text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsTextInputActive", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalIsTextInputActive();
        
        /// <summary>
        ///     Sdl the stop text input
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_StopTextInput", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalStopTextInput();
        
        /// <summary>
        ///     Sdl the set text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextInputRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetTextInputRect(ref RectangleI rect);
        
        /// <summary>
        ///     Sdl the has screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasScreenKeyboardSupport", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalHasScreenKeyboardSupport();
        
        /// <summary>
        ///     Sdl the is screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsScreenKeyboardShown", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalIsScreenKeyboardShown([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseFocus", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetMouseFocus();
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetMouseState(out int x, out int y);
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetMouseState([IsNotNull] IntPtr x, out int y);
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetMouseState(out int x, [IsNotNull] IntPtr y);
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetMouseState([IsNotNull] IntPtr x, [IsNotNull] IntPtr y);
        
        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetGlobalMouseState(out int x, out int y);
        
        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetGlobalMouseState([IsNotNull] IntPtr x, [IsNotNull] IntPtr y);
        
        /// <summary>
        ///     Sdl the get relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRelativeMouseState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetRelativeMouseState(out int x, out int y);
        
        /// <summary>
        ///     Sdl the warp mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_WarpMouseInWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalWarpMouseInWindow([IsNotNull] IntPtr window, [IsNotNull] int x, [IsNotNull] int y);
        
        /// <summary>
        ///     Sdl the warp mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WarpMouseGlobal", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalWarpMouseGlobal([IsNotNull] int x, [IsNotNull] int y);
        
        /// <summary>
        ///     Sdl the set relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRelativeMouseMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetRelativeMouseMode(bool enabled);
        
        /// <summary>
        ///     Sdl the capture mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CaptureMouse", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalCaptureMouse(bool enabled);
        
        /// <summary>
        ///     Sdl the get relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRelativeMouseMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalGetRelativeMouseMode();
        
        /// <summary>
        ///     Sdl the create cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateCursor([IsNotNull] IntPtr data, [IsNotNull] IntPtr mask, [IsNotNull] int w, [IsNotNull] int h, [IsNotNull] int hotX, [IsNotNull] int hotY);
        
        /// <summary>
        ///     Sdl the create color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateColorCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateColorCursor([IsNotNull] IntPtr surface, [IsNotNull] int hotX, [IsNotNull] int hotY);
        
        /// <summary>
        ///     Sdl the create system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateSystemCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateSystemCursor(SystemCursor id);
        
        /// <summary>
        ///     Sdl the set cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetCursor([IsNotNull] IntPtr cursor);
        
        /// <summary>
        ///     Sdl the get cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetCursor();
        
        /// <summary>
        ///     Sdl the free cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalFreeCursor([IsNotNull] IntPtr cursor);
        
        /// <summary>
        ///     Sdl the show cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowCursor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalShowCursor([IsNotNull] int toggle);
        
        /// <summary>
        ///     Sdl the get touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchDevice", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern long InternalGetTouchDevice([IsNotNull] int index);
        
        /// <summary>
        ///     Sdl the get num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumTouchFingers", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumTouchFingers(long touchId);
        
        /// <summary>
        ///     Sdl the get touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchFinger", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetTouchFinger([IsNotNull] long touchId, [IsNotNull] int index);
        
        /// <summary>
        ///     Sdl the get touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchDeviceType", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern TouchDeviceType InternalGetTouchDeviceType([IsNotNull] long touchId);
        
        /// <summary>
        ///     Sdl the joystick rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickRumble", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickRumble([IsNotNull] IntPtr joystick, [IsNotNull] ushort lowFrequencyRumble, [IsNotNull] ushort highFrequencyRumble, [IsNotNull] uint durationMs);
        
        /// <summary>
        ///     Sdl the joystick close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickClose", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalJoystickClose([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickEventState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickEventState([IsNotNull] int state);
        
        /// <summary>
        ///     Sdl the joystick get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAxis", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern short InternalJoystickGetAxis([IsNotNull] IntPtr joystick, [IsNotNull] int axis);
        
        /// <summary>
        ///     Sdl the joystick get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAxisInitialState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalJoystickGetAxisInitialState([IsNotNull] IntPtr joystick, [IsNotNull] int axis, out ushort state);
        
        /// <summary>
        ///     Sdl the joystick get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetBall", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickGetBall([IsNotNull] IntPtr joystick, [IsNotNull] int ball, out int dx, out int dy);
        
        /// <summary>
        ///     Sdl the joystick get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetButton", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern byte InternalJoystickGetButton([IsNotNull] IntPtr joystick, [IsNotNull] int button);
        
        /// <summary>
        ///     Sdl the joystick get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetHat", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern byte InternalJoystickGetHat([IsNotNull] IntPtr joystick, [IsNotNull] int hat);
        
        /// <summary>
        ///     Internals the sdl joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalJoystickName([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Internals the sdl joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalJoystickNameForIndex([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumAxes", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickNumAxes([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumBalls", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickNumBalls([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumButtons", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickNumButtons([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumHats", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickNumHats([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickOpen", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalJoystickOpen([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickUpdate", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalJoystickUpdate();
        
        /// <summary>
        ///     Sdl the num joysticks
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumJoysticks", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalNumJoysticks();
        
        /// <summary>
        ///     Sdl the joystick get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceGUID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern Guid InternalJoystickGetDeviceGUID([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern Guid InternalJoystickGetGUID(IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDString", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalJoystickGetGUIDString(Guid guid, [IsNotNull] byte[] pszGuid, [IsNotNull] int cbGuid);
        
        /// <summary>
        ///     Internals the sdl joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern Guid InternalJoystickGetGUIDFromString([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string pchGuid);
        
        /// <summary>
        ///     Sdl the joystick get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceVendor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalJoystickGetDeviceVendor([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceProduct", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalJoystickGetDeviceProduct([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceProductVersion", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalJoystickGetDeviceProductVersion([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceType", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern JoystickType InternalJoystickGetDeviceType([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceInstanceID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickGetDeviceInstanceID([IsNotNull] int deviceIndex);
        
        /// <summary>
        ///     Sdl the joystick get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetVendor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalJoystickGetVendor([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetProduct", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalJoystickGetProduct([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetProductVersion", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalJoystickGetProductVersion([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetType", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern JoystickType InternalJoystickGetType([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAttached", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalJoystickGetAttached([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickInstanceID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalJoystickInstanceID([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickCurrentPowerLevel", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern JoystickPowerLevel InternalJoystickCurrentPowerLevel([IsNotNull] IntPtr joystick);
        
        /// <summary>
        ///     Sdl the joystick from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickFromInstanceID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalJoystickFromInstanceID([IsNotNull] int instanceId);
        
        /// <summary>
        ///     Sdl the lock joysticks
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockJoysticks", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalLockJoysticks();
        
        /// <summary>
        ///     Sdl the unlock joysticks
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockJoysticks", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalUnlockJoysticks();
        
        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRWFromFile([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string file, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string mode);
        
        /// <summary>
        ///     Internals the sdl load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadFile", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalLoadFile([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string file, out IntPtr dataSize);
        
        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Init", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalInit([IsNotNull] InitSettings flags);
        
        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_Quit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalQuit();
        
        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WasInit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalWasInit([IsNotNull] InitSettings flags);
        
        /// <summary>
        ///     Sdl the clear hints
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearHints", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalClearHints();
        
        /// <summary>
        ///     Internals the sdl get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHint", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetHint([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        ///     Internals the sdl set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHint", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalSetHint([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string value);
        
        /// <summary>
        ///     Internals the sdl set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHintWithPriority", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalSetHintWithPriority([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string value, HintPriority priority);
        
        /// <summary>
        ///     Internals the sdl get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHintBoolean", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalGetHintBoolean([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name, bool defaultValue);
        
        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetError();
        
        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetError", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetError([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string fmtAndArgList);
        
        /// <summary>
        ///     Internals the sdl create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindow", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateWindow([IsNotNull, IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string title, [IsNotNull] int x, [IsNotNull] int y, [IsNotNull] int w, [IsNotNull] int h, [IsNotNull] WindowSettings flags);
        
        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindowAndRenderer", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalCreateWindowAndRenderer([IsNotNull] int width, [IsNotNull] int height, [IsNotNull] WindowSettings windowFlags, out IntPtr window, out IntPtr renderer);
        
        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalDestroyWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClosestDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetClosestDisplayMode([IsNotNull] int displayIndex, ref DisplayMode mode, out DisplayMode closest);
        
        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetCurrentDisplayMode([IsNotNull] int displayIndex, out DisplayMode mode);
        
        /// <summary>
        ///     Internals the sdl get current video driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetCurrentVideoDriver();
        
        /// <summary>
        ///     Sdl the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDesktopDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetDesktopDisplayMode([IsNotNull] int displayIndex, out DisplayMode mode);
        
        /// <summary>
        ///     Internals the sdl get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetDisplayName([IsNotNull] int index);
        
        /// <summary>
        ///     Sdl the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayBounds", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetDisplayBounds([IsNotNull] int displayIndex, out RectangleI rect);
        
        /// <summary>
        ///     Sdl the get display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The d dpi</param>
        /// <param name="hDpi">The h dpi</param>
        /// <param name="vDpi">The v dpi</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayDPI", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetDisplayDPI([IsNotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi);
        
        /// <summary>
        ///     Sdl the get display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetDisplayMode([IsNotNull] int displayIndex, [IsNotNull] int modeIndex, out DisplayMode mode);
        
        /// <summary>
        ///     Sdl the get display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayUsableBounds", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetDisplayUsableBounds([IsNotNull] int displayIndex, out RectangleI rect);
        
        /// <summary>
        ///     Sdl the get num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumDisplayModes", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumDisplayModes([IsNotNull] int displayIndex);
        
        /// <summary>
        ///     Sdl the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumVideoDisplays", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumVideoDisplays();
        
        /// <summary>
        ///     Sdl the get num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumVideoDrivers", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumVideoDrivers();
        
        /// <summary>
        ///     Internals the sdl get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetVideoDriver([IsNotNull] int index);
        
        /// <summary>
        ///     Sdl the get window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowBrightness", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern float InternalGetWindowBrightness([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the set window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowOpacity([IsNotNull] IntPtr window, [IsNotNull] float opacity);
        
        /// <summary>
        ///     Sdl the get window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetWindowOpacity([IsNotNull] IntPtr window, out float outOpacity);
        
        /// <summary>
        ///     Sdl the set window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowModalFor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowModalFor([IsNotNull] IntPtr modalWindow, [IsNotNull] IntPtr parentWindow);
        
        /// <summary>
        ///     Sdl the set window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowInputFocus", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowInputFocus([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Internals the sdl get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowData", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetWindowData([IsNotNull] IntPtr window, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name);
        
        /// <summary>
        ///     Sdl the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowDisplayIndex", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetWindowDisplayIndex([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetWindowDisplayMode([IsNotNull] IntPtr window, out DisplayMode mode);
        
        /// <summary>
        ///     Sdl the get window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowFlags", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetWindowFlags([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowFromID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetWindowFromID([IsNotNull] uint id);
        
        /// <summary>
        ///     Sdl the get window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowGammaRamp", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetWindowGammaRamp([IsNotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue);
        
        /// <summary>
        ///     Sdl the get window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowGrab", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalGetWindowGrab([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetWindowID([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowPixelFormat", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern uint InternalGetWindowPixelFormat([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGetWindowMaximumSize([IsNotNull] IntPtr window, out int maxW, out int maxH);
        
        /// <summary>
        ///     Sdl the get window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGetWindowMinimumSize([IsNotNull] IntPtr window, out int minW, out int minH);
        
        /// <summary>
        ///     Sdl the get window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowPosition", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGetWindowPosition([IsNotNull] IntPtr window, out int x, out int y);
        
        /// <summary>
        ///     Sdl the get window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGetWindowSize([IsNotNull] IntPtr window, out int w, out int h);
        
        /// <summary>
        ///     Sdl the get window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowSurface", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetWindowSurface([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Internals the sdl get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetWindowTitle([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the gl bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex w</param>
        /// <param name="texH">The tex h</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_BindTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlBindTexture([IsNotNull] IntPtr texture, out float texW, out float texH);
        
        /// <summary>
        ///     Sdl the gl create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_CreateContext", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGlCreateContext([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_DeleteContext", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGlDeleteContext([IsNotNull] IntPtr context);
        
        /// <summary>
        ///     Internals the sdl gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlLoadLibrary([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string path);
        
        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetProcAddress", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGlGetProcAddress([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string proc);
        
        /// <summary>
        ///     Internals the sdl gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalGlExtensionSupported([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string extension);
        
        /// <summary>
        ///     Sdl the gl reset attributes
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ResetAttributes", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGlResetAttributes();
        
        /// <summary>
        ///     Sdl the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetAttribute", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlGetAttribute([IsNotNull] GlAttr attr, out int value);
        
        /// <summary>
        ///     Sdl the gl get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetSwapInterval", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlGetSwapInterval();
        
        /// <summary>
        ///     Sdl the gl make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_MakeCurrent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlMakeCurrent([IsNotNull] IntPtr window, [IsNotNull] IntPtr context);
        
        /// <summary>
        ///     Sdl the gl get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetCurrentWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGlGetCurrentWindow();
        
        /// <summary>
        ///     Sdl the render is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderIsClipEnabled", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalRenderIsClipEnabled([IsNotNull] IntPtr renderer);
        
        /// <summary>
        ///     Sdl the calculate gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_CalculateGammaRamp", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalCalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp);
        
        /// <summary>
        ///     Internals the sdl get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetPixelFormatName([IsNotNull] uint format);
        
        /// <summary>
        ///     Sdl the pixel format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PixelFormatEnumToMasks", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalPixelFormatEnumToMasks([IsNotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask);
        
        /// <summary>
        ///     Sdl the set palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetPaletteColors", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetPaletteColors([IsNotNull] IntPtr palette, [In] Color[] colors, [IsNotNull] int firstColor, [IsNotNull] int nColors);
        
        /// <summary>
        ///     Sdl the set pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetPixelFormatPalette", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetPixelFormatPalette([IsNotNull] IntPtr format, [IsNotNull] IntPtr palette);
        
        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalBlitSurface([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect);
        
        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalBlitSurface([IsNotNull] IntPtr src, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect);
        
        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalBlitSurface([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, [IsNotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalBlitSurface([IsNotNull] IntPtr src, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dst, [IsNotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the convert surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ConvertSurface", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalConvertSurface([IsNotNull] IntPtr src, [IsNotNull] IntPtr fmt, [IsNotNull] uint flags);
        
        /// <summary>
        ///     Sdl the create rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceWithFormat", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateRGBSurfaceWithFormat([IsNotNull] uint flags, [IsNotNull] int width, [IsNotNull] int height, [IsNotNull] int depth, [IsNotNull] uint format);
        
        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalFillRect([IsNotNull] IntPtr dst, ref RectangleI rect, [IsNotNull] uint color);
        
        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalFillRect([IsNotNull] IntPtr dst, [IsNotNull] IntPtr rect, [IsNotNull] uint color);
        
        /// <summary>
        ///     Sdl the fill rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRects", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalFillRects([IsNotNull] IntPtr dst, [In] RectangleI[] rects, [IsNotNull] int count, [IsNotNull] uint color);
        
        /// <summary>
        ///     Sdl the get clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGetClipRect([IsNotNull] IntPtr surface, out RectangleI rect);
        
        /// <summary>
        ///     Sdl the has color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasColorKey", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalHasColorKey([IsNotNull] IntPtr surface);
        
        /// <summary>
        ///     Sdl the get color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetColorKey", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetColorKey([IsNotNull] IntPtr surface, out uint key);
        
        /// <summary>
        ///     Sdl the get surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceAlphaMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetSurfaceAlphaMod([IsNotNull] IntPtr surface, out byte alpha);
        
        /// <summary>
        ///     Sdl the get surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetSurfaceBlendMode([IsNotNull] IntPtr surface, out BlendModes blendMode);
        
        /// <summary>
        ///     Sdl the get surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceColorMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetSurfaceColorMod([IsNotNull] IntPtr surface, out byte r, out byte g, out byte b);
        
        /// <summary>
        ///     Internals the sdl load bmp rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalLoadBMP_RW([IsNotNull] IntPtr src, [IsNotNull] int freeSrc);
        
        /// <summary>
        ///     Sdl the set clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalSetClipRect([IsNotNull] IntPtr surface, ref RectangleI rect);
        
        /// <summary>
        ///     Sdl the set color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetColorKey", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetColorKey([IsNotNull] IntPtr surface, [IsNotNull] int flag, [IsNotNull] uint key);
        
        /// <summary>
        ///     Sdl the set surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceAlphaMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetSurfaceAlphaMod([IsNotNull] IntPtr surface, [IsNotNull] byte alpha);
        
        /// <summary>
        ///     Sdl the set surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetSurfaceBlendMode([IsNotNull] IntPtr surface, BlendModes blendMode);
        
        /// <summary>
        ///     Sdl the set surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceColorMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetSurfaceColorMod([IsNotNull] IntPtr surface, [IsNotNull] byte r, [IsNotNull] byte g, [IsNotNull] byte b);
        
        /// <summary>
        ///     Sdl the set surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfacePalette", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetSurfacePalette([IsNotNull] IntPtr surface, [IsNotNull] IntPtr palette);
        
        /// <summary>
        ///     Sdl the upper blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpperBlit([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect);
        
        /// <summary>
        ///     Sdl the upper blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpperBlitScaled([IsNotNull] IntPtr src, ref RectangleI srcRect, [IsNotNull] IntPtr dst, ref RectangleI dstRect);
        
        /// <summary>
        ///     Sdl the has clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasClipboardText", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalHasClipboardText();
        
        /// <summary>
        ///     Internals the sdl get clipboard text
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetClipboardText();
        
        /// <summary>
        ///     Internals the sdl game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGameControllerAddMapping([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string mappingString);
        
        /// <summary>
        ///     Sdl the game controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNumMappings", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGameControllerNumMappings();
        
        /// <summary>
        ///     Internals the sdl game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerMappingForIndex([IsNotNull] int mappingIndex);
        
        /// <summary>
        ///     Internals the sdl game controller add mappings from rw using the specified rw
        /// </summary>
        /// <param name="rw">The rw</param>
        /// <param name="freeRw">The free rw</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGameControllerAddMappingsFromRW([IsNotNull] IntPtr rw, [IsNotNull] int freeRw);
        
        /// <summary>
        ///     Internals the sdl game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerMappingForGUID(Guid guid);
        
        /// <summary>
        ///     Internals the sdl game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerMapping([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the is game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsGameController", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalIsGameController([IsNotNull] int joystickIndex);
        
        /// <summary>
        ///     Internals the sdl game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerNameForIndex([IsNotNull] int joystickIndex);
        
        /// <summary>
        ///     Internals the sdl game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerMappingForDeviceIndex([IsNotNull] int joystickIndex);
        
        /// <summary>
        ///     Sdl the game controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerOpen", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerOpen([IsNotNull] int joystickIndex);
        
        /// <summary>
        ///     Internals the sdl game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerName([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetVendor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalGameControllerGetVendor([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetProduct", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalGameControllerGetProduct([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetProductVersion", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ushort InternalGameControllerGetProductVersion([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAttached", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalGameControllerGetAttached([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetJoystick", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerGetJoystick([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerEventState", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGameControllerEventState([IsNotNull] int state);
        
        /// <summary>
        ///     Sdl the game controller update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerUpdate", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGameControllerUpdate();
        
        /// <summary>
        ///     Internals the sdl game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern GameControllerAxis InternalGameControllerGetAxisFromString([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string pchString);
        
        /// <summary>
        ///     Internals the sdl game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerGetStringForAxis(GameControllerAxis axis);
        
        /// <summary>
        ///     Internals the sdl game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern InternalSdlGameControllerButtonBind InternalGameControllerGetBindForAxis([IsNotNull] IntPtr gameController, GameControllerAxis axis);
        
        /// <summary>
        ///     Sdl the game controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxis", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern short InternalGameControllerGetAxis([IsNotNull] IntPtr gameController, GameControllerAxis axis);
        
        /// <summary>
        ///     Internals the sdl game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern GameControllerButton InternalGameControllerGetButtonFromString([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string pchString);
        
        /// <summary>
        ///     Internals the sdl game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerGetStringForButton(GameControllerButton button);
        
        /// <summary>
        ///     Internals the sdl game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern InternalSdlGameControllerButtonBind InternalGameControllerGetBindForButton([IsNotNull] IntPtr gameController, GameControllerButton button);
        
        /// <summary>
        ///     Sdl the game controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButton", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern byte InternalGameControllerGetButton([IsNotNull] IntPtr gameController, GameControllerButton button);
        
        /// <summary>
        ///     Sdl the game controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerRumble", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGameControllerRumble([IsNotNull] IntPtr gameController, [IsNotNull] ushort lowFrequencyRumble, [IsNotNull] ushort highFrequencyRumble, [IsNotNull] uint durationMs);
        
        /// <summary>
        ///     Sdl the game controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerClose", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGameControllerClose([IsNotNull] IntPtr gameController);
        
        /// <summary>
        ///     Sdl the game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerFromInstanceID", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGameControllerFromInstanceID([IsNotNull] int joyId);
        
        /// <summary>
        ///     Sdl the gl get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetDrawableSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGlGetDrawableSize([IsNotNull] IntPtr window, out int w, out int h);
        
        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SetAttribute", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlSetAttribute([IsNotNull] GlAttr attr, [IsNotNull] int value);
        
        /// <summary>
        ///     Sdl the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SetSwapInterval", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlSetSwapInterval([IsNotNull] int interval);
        
        /// <summary>
        ///     Sdl the gl swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SwapWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalGlSwapWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the gl unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_UnbindTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGlUnbindTexture([IsNotNull] IntPtr texture);
        
        /// <summary>
        ///     Sdl the hide window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HideWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalHideWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the maximize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MaximizeWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalMaximizeWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the minimize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MinimizeWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalMinimizeWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the raise window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RaiseWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalRaiseWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the restore window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RestoreWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalRestoreWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the set window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBrightness", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowBrightness([IsNotNull] IntPtr window, float brightness);
        
        /// <summary>
        ///     Internals the sdl set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowData", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalSetWindowData([IsNotNull] IntPtr window, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string name, [IsNotNull] IntPtr userdata);
        
        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowDisplayMode([IsNotNull] IntPtr window, ref DisplayMode mode);
        
        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowDisplayMode([IsNotNull] IntPtr window, [IsNotNull] IntPtr mode);
        
        /// <summary>
        ///     Sdl the set window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowFullscreen", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowFullscreen([IsNotNull] IntPtr window, [IsNotNull] uint flags);
        
        /// <summary>
        ///     Sdl the set window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowGammaRamp", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowGammaRamp([IsNotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue);
        
        /// <summary>
        ///     Sdl the set window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowGrab", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowGrab([IsNotNull] IntPtr window, [IsNotNull] bool grabbed);
        
        /// <summary>
        ///     Sdl the set window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowIcon", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowIcon([IsNotNull] IntPtr window, [IsNotNull] IntPtr icon);
        
        /// <summary>
        ///     Sdl the set window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowMaximumSize([IsNotNull] IntPtr window, [IsNotNull] int maxW, [IsNotNull] int maxH);
        
        /// <summary>
        ///     Sdl the set window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowMinimumSize([IsNotNull] IntPtr window, [IsNotNull] int minW, [IsNotNull] int minH);
        
        /// <summary>
        ///     Sdl the set window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowSize([IsNotNull] IntPtr window, [IsNotNull] int w, [IsNotNull] int h);
        
        /// <summary>
        ///     Sdl the set window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowBordered([IsNotNull] IntPtr window, bool bordered);
        
        /// <summary>
        ///     Sdl the get window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetWindowBordersSize([IsNotNull] IntPtr window, out int top, out int left, out int bottom, out int right);
        
        /// <summary>
        ///     Sdl the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowResizable", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowResizable([IsNotNull] IntPtr window, bool resizable);
        
        /// <summary>
        ///     Internals the sdl set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowTitle", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowTitle([IsNotNull] IntPtr window, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string title);
        
        /// <summary>
        ///     Sdl the show window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalShowWindow([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the update window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateWindowSurface", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpdateWindowSurface([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the update window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateWindowSurfaceRects", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpdateWindowSurfaceRects([IsNotNull] IntPtr window, [In] RectangleI[] rects, [IsNotNull] int numRects);
        
        /// <summary>
        ///     Sdl the set window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowHitTest", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetWindowHitTest([IsNotNull] IntPtr window, SdlHitTest callback, [IsNotNull] IntPtr callbackData);
        
        /// <summary>
        ///     Sdl the get grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGrabbedWindow", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetGrabbedWindow();
        
        /// <summary>
        ///     Sdl the compose custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ComposeCustomBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern BlendModes InternalComposeCustomBlendMode([IsNotNull] BlendFactor srcColorFactor, [IsNotNull] BlendFactor dstColorFactor, [IsNotNull] BlendOperation colorOperation, [IsNotNull] BlendFactor srcAlphaFactor, [IsNotNull] BlendFactor dstAlphaFactor, [IsNotNull] BlendOperation alphaOperation);
        
        /// <summary>
        ///     Sdl the create renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRenderer", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateRenderer([IsNotNull] IntPtr window, [IsNotNull] int index, Renderers flags);
        
        /// <summary>
        ///     Sdl the create software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateSoftwareRenderer", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateSoftwareRenderer([IsNotNull] IntPtr surface);
        
        /// <summary>
        ///     Sdl the create texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateTexture([IsNotNull] IntPtr renderer, [IsNotNull] uint format, [IsNotNull] int access, [IsNotNull] int w, [IsNotNull] int h);
        
        /// <summary>
        ///     Sdl the create texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateTextureFromSurface", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalCreateTextureFromSurface([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr surface);
        
        /// <summary>
        ///     Sdl the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyRenderer", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalDestroyRenderer([IsNotNull] IntPtr renderer);
        
        /// <summary>
        ///     Sdl the destroy texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalDestroyTexture([IsNotNull] IntPtr texture);
        
        /// <summary>
        ///     Sdl the get num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumRenderDrivers", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetNumRenderDrivers();
        
        /// <summary>
        ///     Sdl the get render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDrawBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetRenderDrawBlendMode([IsNotNull] IntPtr renderer, out BlendModes blendMode);
        
        /// <summary>
        ///     Sdl the get render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDrawColor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetRenderDrawColor([IsNotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a);
        
        /// <summary>
        ///     Sdl the get render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDriverInfo", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetRenderDriverInfo([IsNotNull] int index, out RendererInfo info);
        
        /// <summary>
        ///     Sdl the get renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderer", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGetRenderer([IsNotNull] IntPtr window);
        
        /// <summary>
        ///     Sdl the get renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRendererInfo", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetRendererInfo([IsNotNull] IntPtr renderer, out RendererInfo info);
        
        /// <summary>
        ///     Sdl the get renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRendererOutputSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetRendererOutputSize([IsNotNull] IntPtr renderer, out int w, out int h);
        
        /// <summary>
        ///     Sdl the get texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureAlphaMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetTextureAlphaMod([IsNotNull] IntPtr texture, out byte alpha);
        
        /// <summary>
        ///     Sdl the get texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetTextureBlendMode([IsNotNull] IntPtr texture, out BlendModes blendMode);
        
        /// <summary>
        ///     Sdl the get texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureColorMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalGetTextureColorMod([IsNotNull] IntPtr texture, out byte r, out byte g, out byte b);
        
        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalLockTexture([IsNotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch);
        
        /// <summary>
        ///     Sdl the query texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_QueryTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalQueryTexture([IsNotNull] IntPtr texture, out uint format, out int access, out int w, out int h);
        
        /// <summary>
        ///     Sdl the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderClear", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderClear([IsNotNull] IntPtr renderer);
        
        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect);
        
        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleI dstRect);
        
        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopy([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, RendererFlips flips);
        
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointI center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect"></param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointI center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLine", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawLine([IsNotNull] IntPtr renderer, [IsNotNull] int x1, [IsNotNull] int y1, [IsNotNull] int x2, [IsNotNull] int y2);
        
        /// <summary>
        ///     Sdl the render draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLines", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawLines([IsNotNull] IntPtr renderer, [In] PointI[] points, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPoint", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawPoint([IsNotNull] IntPtr renderer, [IsNotNull] int x, [IsNotNull] int y);
        
        /// <summary>
        ///     Sdl the render draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPoints", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawPoints([IsNotNull] IntPtr renderer, [In] PointI[] points, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawRect([IsNotNull] IntPtr renderer, ref RectangleI rect);
        
        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawRect([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect);
        
        /// <summary>
        ///     Sdl the render draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRects", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawRects([IsNotNull] IntPtr renderer, [In] RectangleI[] rects, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderFillRect([IsNotNull] IntPtr renderer, ref RectangleI rect);
        
        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderFillRect([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect);
        
        /// <summary>
        ///     Sdl the render fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRects", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderFillRects([IsNotNull] IntPtr renderer, [In] RectangleI[] rects, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst);
        
        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleF dst);
        
        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyEx([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointF center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, ref PointF center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, ref RectangleF dst, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, ref RectangleI srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flips">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderCopyExF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture, [IsNotNull] IntPtr srcRect, [IsNotNull] IntPtr dstRect, double angle, [IsNotNull] IntPtr center, RendererFlips flips);
        
        /// <summary>
        ///     Sdl the render draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPointF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawPointF([IsNotNull] IntPtr renderer, float x, float y);
        
        /// <summary>
        ///     Sdl the render draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPointsF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLineF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawLineF([IsNotNull] IntPtr renderer, float x1, float y1, float x2, float y2);
        
        /// <summary>
        ///     Sdl the render draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLinesF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawLinesF([IsNotNull] IntPtr renderer, [In] PointF[] points, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawRectF([IsNotNull] IntPtr renderer, ref RectangleF rect);
        
        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawRectF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect);
        
        /// <summary>
        ///     Sdl the render draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectsF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderDrawRectsF([IsNotNull] IntPtr renderer, [In] RectangleF[] rects, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderFillRectF([IsNotNull] IntPtr renderer, RectangleF rect);
        
        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderFillRectF([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect);
        
        /// <summary>
        ///     Sdl the render fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectsF", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderFillRectsF([IsNotNull] IntPtr renderer, [In] RectangleF[] rects, [IsNotNull] int count);
        
        /// <summary>
        ///     Sdl the render get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetClipRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalRenderGetClipRect([IsNotNull] IntPtr renderer, out RectangleI rect);
        
        /// <summary>
        ///     Sdl the render get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetLogicalSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalRenderGetLogicalSize([IsNotNull] IntPtr renderer, out int w, out int h);
        
        /// <summary>
        ///     Sdl the render get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetScale", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalRenderGetScale([IsNotNull] IntPtr renderer, out float scaleX, out float scaleY);
        
        /// <summary>
        ///     Sdl the render get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetViewport", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderGetViewport([IsNotNull] IntPtr renderer, out RectangleI rect);
        
        /// <summary>
        ///     Sdl the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderPresent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalRenderPresent(IntPtr renderer);
        
        /// <summary>
        ///     Sdl the render read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderReadPixels", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderReadPixels([IsNotNull] IntPtr renderer, ref RectangleI rect, [IsNotNull] uint format, [IsNotNull] IntPtr pixels, [IsNotNull] int pitch);
        
        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetClipRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderSetClipRect([IsNotNull] IntPtr renderer, ref RectangleI rect);
        
        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetClipRect", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderSetClipRect([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr rect);
        
        /// <summary>
        ///     Sdl the render set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetLogicalSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderSetLogicalSize([IsNotNull] IntPtr renderer, [IsNotNull] int w, [IsNotNull] int h);
        
        /// <summary>
        ///     Sdl the render set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetScale", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderSetScale([IsNotNull] IntPtr renderer, float scaleX, float scaleY);
        
        /// <summary>
        ///     Sdl the render set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetIntegerScale", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderSetIntegerScale([IsNotNull] IntPtr renderer, bool enable);
        
        /// <summary>
        ///     Sdl the render set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetViewport", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalRenderSetViewportWithRef([IsNotNull] IntPtr renderer, ref RectangleI rect);
        
        /// <summary>
        ///     Sdl the set render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderDrawBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetRenderDrawBlendMode([IsNotNull] IntPtr renderer, BlendModes blendMode);
        
        /// <summary>
        ///     Sdl the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderDrawColor", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetRenderDrawColor([IsNotNull] IntPtr renderer, [IsNotNull] byte r, [IsNotNull] byte g, [IsNotNull] byte b, [IsNotNull] byte a);
        
        /// <summary>
        ///     Sdl the set render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderTarget", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetRenderTarget([IsNotNull] IntPtr renderer, [IsNotNull] IntPtr texture);
        
        /// <summary>
        ///     Sdl the set texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureAlphaMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetTextureAlphaMod([IsNotNull] IntPtr texture, [IsNotNull] byte alpha);
        
        /// <summary>
        ///     Sdl the set texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureBlendMode", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetTextureBlendMode([IsNotNull] IntPtr texture, BlendModes blendMode);
        
        /// <summary>
        ///     Sdl the set texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureColorMod", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalSetTextureColorMod([IsNotNull] IntPtr texture, [IsNotNull] byte r, [IsNotNull] byte g, [IsNotNull] byte b);
        
        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpdateTexture([IsNotNull] IntPtr texture, ref RectangleI rect, [IsNotNull] IntPtr pixels, [IsNotNull] int pitch);
        
        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpdateTexture([IsNotNull] IntPtr texture, [IsNotNull] IntPtr rect, [IsNotNull] IntPtr pixels, [IsNotNull] int pitch);
        
        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalUpdateTexturev2([IsNotNull] IntPtr texture, [IsNotNull] IntPtr rect, [IsNotNull] byte[] pixels, [IsNotNull] int pitch);
        
        /// <summary>
        ///     Sdl the render target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderTargetSupported", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern bool InternalRenderTargetSupported([IsNotNull] IntPtr renderer);
        
        /// <summary>
        ///     Sdl the set window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowPosition", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalSetWindowPosition([IsNotNull] IntPtr window, [IsNotNull] int x, [IsNotNull] int y);
        
        /// <summary>
        ///     Sdl the gl get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetCurrentContext", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalGlGetCurrentContext();
        
        /// <summary>
        ///     Sdl the get performance frequency
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPerformanceFrequency", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ulong InternalGetPerformanceFrequency();
        
        /// <summary>
        ///     Sdl the get performance counter
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPerformanceCounter", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern ulong InternalGetPerformanceCounter();
        
        /// <summary>
        ///     Internals the queue audio using the specified device id
        /// </summary>
        /// <param name="deviceId">The device id</param>
        /// <param name="audioData">The audio data</param>
        /// <param name="wavLength">The wav length</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_QueueAudio", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalQueueAudio(int deviceId, byte[] audioData, uint wavLength);
    }
}
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmscriptenWebScript.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Contains the JavaScript code for WebAssembly bridge functionality.
    ///     This script should be included in the HTML page that hosts the WebAssembly module.
    /// </summary>
    public static class EmscriptenWebScript
    {
        /// <summary>
        ///     Gets the complete JavaScript bridge code as a string
        /// </summary>
        public static string GetBridgeScript()
        {
            return @"
var EmscriptenWebBridge = {
    keyboardCallbacks: { onKeyDown: null, onKeyUp: null, onCharInput: null },
    mouseCallbacks: { onMouseMove: null, onMouseDown: null, onMouseUp: null, onMouseWheel: null },
    gamepadCallbacks: { onGamepadConnect: null, onGamepadDisconnect: null },
    windowCallbacks: { onWindowResize: null, onWindowClose: null, onWindowFocus: null },

    init: function() {
        this.registerKeyboardListeners();
        this.registerMouseListeners();
        this.registerGamepadListeners();
        this.registerWindowListeners();
        this.registerBatteryListeners();
        this.registerOnlineListeners();
    },

    registerKeyboardListeners: function() {
        document.addEventListener('keydown', (event) => {
            if (this.keyboardCallbacks.onKeyDown) {
                try {
                    Module.ccall('onKeyDownCallback', null, 
                        ['number', 'number'], 
                        [event.keyCode, event.location]);
                } catch(e) {}
            }
        });
        document.addEventListener('keyup', (event) => {
            if (this.keyboardCallbacks.onKeyUp) {
                try {
                    Module.ccall('onKeyUpCallback', null, 
                        ['number', 'number'], 
                        [event.keyCode, event.location]);
                } catch(e) {}
            }
        });
        document.addEventListener('keypress', (event) => {
            if (this.keyboardCallbacks.onCharInput) {
                try {
                    Module.ccall('onCharInputCallback', null, 
                        ['number'], 
                        [event.charCode]);
                } catch(e) {}
            }
        });
    },

    registerMouseListeners: function() {
        const canvas = document.querySelector('canvas') || document.body;
        canvas.addEventListener('mousemove', (event) => {
            if (this.mouseCallbacks.onMouseMove) {
                try {
                    Module.ccall('onMouseMoveCallback', null, 
                        ['number', 'number', 'number', 'number'], 
                        [event.clientX, event.clientY, event.pageX, event.pageY]);
                } catch(e) {}
            }
        });
        canvas.addEventListener('mousedown', (event) => {
            if (this.mouseCallbacks.onMouseDown) {
                try {
                    Module.ccall('onMouseDownCallback', null, 
                        ['number', 'number', 'number', 'number', 'number'], 
                        [event.button, event.clientX, event.clientY, event.pageX, event.pageY]);
                } catch(e) {}
            }
        });
        canvas.addEventListener('mouseup', (event) => {
            if (this.mouseCallbacks.onMouseUp) {
                try {
                    Module.ccall('onMouseUpCallback', null, 
                        ['number', 'number', 'number', 'number', 'number'], 
                        [event.button, event.clientX, event.clientY, event.pageX, event.pageY]);
                } catch(e) {}
            }
        });
        canvas.addEventListener('wheel', (event) => {
            event.preventDefault();
            if (this.mouseCallbacks.onMouseWheel) {
                try {
                    Module.ccall('onMouseWheelCallback', null, 
                        ['number', 'number'], 
                        [event.deltaX, event.deltaY]);
                } catch(e) {}
            }
        }, { passive: false });
    },

    registerGamepadListeners: function() {
        window.addEventListener('gamepadconnected', (event) => {
            if (this.gamepadCallbacks.onGamepadConnect) {
                try {
                    Module.ccall('onGamepadConnectCallback', null, 
                        ['number'], 
                        [event.gamepad.index]);
                } catch(e) {}
            }
        });
        window.addEventListener('gamepaddisconnected', (event) => {
            if (this.gamepadCallbacks.onGamepadDisconnect) {
                try {
                    Module.ccall('onGamepadDisconnectCallback', null, 
                        ['number'], 
                        [event.gamepad.index]);
                } catch(e) {}
            }
        });
    },

    registerWindowListeners: function() {
        window.addEventListener('resize', () => {
            if (this.windowCallbacks.onWindowResize) {
                try {
                    Module.ccall('onWindowResizeCallback', null, 
                        ['number', 'number'], 
                        [window.innerWidth, window.innerHeight]);
                } catch(e) {}
            }
        });
        window.addEventListener('beforeunload', () => {
            if (this.windowCallbacks.onWindowClose) {
                try {
                    Module.ccall('onWindowCloseCallback', null, []);
                } catch(e) {}
            }
        });
        window.addEventListener('focus', () => {
            if (this.windowCallbacks.onWindowFocus) {
                try {
                    Module.ccall('onWindowFocusCallback', null, ['number'], [1]);
                } catch(e) {}
            }
        });
        window.addEventListener('blur', () => {
            if (this.windowCallbacks.onWindowFocus) {
                try {
                    Module.ccall('onWindowFocusCallback', null, ['number'], [0]);
                } catch(e) {}
            }
        });
    },

    registerBatteryListeners: function() {
        if (navigator.getBattery) {
            navigator.getBattery().then((battery) => {
                battery.addEventListener('levelchange', () => {});
            });
        }
    },

    registerOnlineListeners: function() {
        window.addEventListener('online', () => {});
        window.addEventListener('offline', () => {});
    },

    createIntArray: function(values) {
        const ptr = Module._malloc(values.length * 4);
        const arr = new Int32Array(Module.HEAPU8.buffer, ptr, values.length);
        arr.set(values);
        return ptr;
    },

    createFloatArray: function(values) {
        const ptr = Module._malloc(values.length * 4);
        const arr = new Float32Array(Module.HEAPU8.buffer, ptr, values.length);
        arr.set(values);
        return ptr;
    },

    createBoolArray: function(values) {
        const ptr = Module._malloc(values.length);
        const arr = new Uint8Array(Module.HEAPU8.buffer, ptr, values.length);
        for (let i = 0; i < values.length; i++) {
            arr[i] = values[i] ? 1 : 0;
        }
        return ptr;
    }
};

function registerKeyboardCallbacks(onKeyDownFunc, onKeyUpFunc, onCharInputFunc) {
    EmscriptenWebBridge.keyboardCallbacks.onKeyDown = onKeyDownFunc;
    EmscriptenWebBridge.keyboardCallbacks.onKeyUp = onKeyUpFunc;
    EmscriptenWebBridge.keyboardCallbacks.onCharInput = onCharInputFunc;
}

function registerMouseCallbacks(onMouseMoveFunc, onMouseDownFunc, onMouseUpFunc, onMouseWheelFunc) {
    EmscriptenWebBridge.mouseCallbacks.onMouseMove = onMouseMoveFunc;
    EmscriptenWebBridge.mouseCallbacks.onMouseDown = onMouseDownFunc;
    EmscriptenWebBridge.mouseCallbacks.onMouseUp = onMouseUpFunc;
    EmscriptenWebBridge.mouseCallbacks.onMouseWheel = onMouseWheelFunc;
}

function registerGamepadCallbacks(onGamepadConnectFunc, onGamepadDisconnectFunc) {
    EmscriptenWebBridge.gamepadCallbacks.onGamepadConnect = onGamepadConnectFunc;
    EmscriptenWebBridge.gamepadCallbacks.onGamepadDisconnect = onGamepadDisconnectFunc;
}

function registerWindowCallbacks(onWindowResizeFunc, onWindowCloseFunc, onWindowFocusFunc) {
    EmscriptenWebBridge.windowCallbacks.onWindowResize = onWindowResizeFunc;
    EmscriptenWebBridge.windowCallbacks.onWindowClose = onWindowCloseFunc;
    EmscriptenWebBridge.windowCallbacks.onWindowFocus = onWindowFocusFunc;
}

function getConnectedGamepads() {
    const gamepads = navigator.getGamepads();
    const connected = [];
    for (let i = 0; i < gamepads.length; i++) {
        if (gamepads[i]) connected.push(i);
    }
    return EmscriptenWebBridge.createIntArray(connected);
}

function getGamepadAxes(gamepadIndex) {
    const gamepads = navigator.getGamepads();
    if (gamepadIndex >= 0 && gamepadIndex < gamepads.length && gamepads[gamepadIndex]) {
        return EmscriptenWebBridge.createFloatArray(gamepads[gamepadIndex].axes);
    }
    return 0;
}

function getGamepadButtons(gamepadIndex) {
    const gamepads = navigator.getGamepads();
    if (gamepadIndex >= 0 && gamepadIndex < gamepads.length && gamepads[gamepadIndex]) {
        const buttons = gamepads[gamepadIndex].buttons;
        const pressed = buttons.map(b => b.pressed);
        return EmscriptenWebBridge.createBoolArray(pressed);
    }
    return 0;
}

function getArrayLength(arrayPtr) {
    if (!window.arrayLengths) window.arrayLengths = new Map();
    return window.arrayLengths.get(arrayPtr) || 0;
}

function getArrayIntElement(arrayPtr, index) {
    const arr = new Int32Array(Module.HEAPU8.buffer, arrayPtr, 100);
    return arr[index];
}

function getArrayFloatElement(arrayPtr, index) {
    const arr = new Float32Array(Module.HEAPU8.buffer, arrayPtr, 100);
    return arr[index];
}

function getArrayBoolElement(arrayPtr, index) {
    const arr = new Uint8Array(Module.HEAPU8.buffer, arrayPtr, 100);
    return arr[index] !== 0;
}

function freeArray(arrayPtr) {
    if (arrayPtr) {
        Module._free(arrayPtr);
        if (window.arrayLengths) window.arrayLengths.delete(arrayPtr);
    }
}

function showCanvas() {
    const canvas = document.querySelector('canvas');
    if (canvas) canvas.style.display = 'block';
}

function hideCanvas() {
    const canvas = document.querySelector('canvas');
    if (canvas) canvas.style.display = 'none';
}

function setWindowTitle(title) {
    document.title = title;
}

function setCanvasSize(width, height) {
    const canvas = document.querySelector('canvas');
    if (canvas) {
        canvas.width = width;
        canvas.height = height;
        canvas.style.width = width + 'px';
        canvas.style.height = height + 'px';
    }
}

function setWindowIcon(iconPath) {
    let link = document.querySelector(""link[rel*='icon']"") || document.createElement('link');
    link.rel = 'icon';
    link.href = iconPath;
    document.head.appendChild(link);
}

function getWindowPositionX() {
    return window.screenX || 0;
}

function getWindowPositionY() {
    return window.screenY || 0;
}

function getDevicePixelRatio() {
    return window.devicePixelRatio || 1.0;
}

function requestFullscreen() {
    const canvas = document.querySelector('canvas') || document.documentElement;
    try {
        if (canvas.requestFullscreen) { canvas.requestFullscreen(); return true; }
        else if (canvas.webkitRequestFullscreen) { canvas.webkitRequestFullscreen(); return true; }
        else if (canvas.mozRequestFullScreen) { canvas.mozRequestFullScreen(); return true; }
        else if (canvas.msRequestFullscreen) { canvas.msRequestFullscreen(); return true; }
    } catch (e) {}
    return false;
}

function exitFullscreen() {
    try {
        if (document.exitFullscreen) { document.exitFullscreen(); return true; }
        else if (document.webkitExitFullscreen) { document.webkitExitFullscreen(); return true; }
        else if (document.mozCancelFullScreen) { document.mozCancelFullScreen(); return true; }
        else if (document.msExitFullscreen) { document.msExitFullscreen(); return true; }
    } catch (e) {}
    return false;
}

function isFullscreenEnabled() {
    return !!(document.fullscreenElement || document.webkitFullscreenElement || 
              document.mozFullScreenElement || document.msFullscreenElement);
}

function lockPointer() {
    const canvas = document.querySelector('canvas') || document.body;
    try {
        if (canvas.requestPointerLock) { canvas.requestPointerLock(); return true; }
        else if (canvas.mozRequestPointerLock) { canvas.mozRequestPointerLock(); return true; }
        else if (canvas.webkitRequestPointerLock) { canvas.webkitRequestPointerLock(); return true; }
    } catch (e) {}
    return false;
}

function unlockPointer() {
    try {
        if (document.exitPointerLock) { document.exitPointerLock(); return true; }
        else if (document.mozExitPointerLock) { document.mozExitPointerLock(); return true; }
        else if (document.webkitExitPointerLock) { document.webkitExitPointerLock(); return true; }
    } catch (e) {}
    return false;
}

function isPointerLocked() {
    return !!(document.pointerLockElement || document.mozPointerLockElement || 
              document.webkitPointerLockElement);
}

function vibrateGamepad(gamepadIndex, leftMotor, rightMotor, duration) {
    const gamepads = navigator.getGamepads();
    if (gamepadIndex >= 0 && gamepadIndex < gamepads.length && gamepads[gamepadIndex]) {
        const gamepad = gamepads[gamepadIndex];
        if (gamepad.vibrationActuator && gamepad.vibrationActuator.playEffect) {
            try {
                gamepad.vibrationActuator.playEffect('dual-rumble', {
                    startDelay: 0, duration: duration * 1000,
                    weakMagnitude: leftMotor, strongMagnitude: rightMotor
                });
                return true;
            } catch (e) {}
        }
    }
    return false;
}

function getSystemTimeMs() {
    return performance.now();
}

function openFileDialog(mimeTypes) {
    return new Promise((resolve) => {
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = mimeTypes || '*/*';
        input.onchange = (e) => {
            const file = e.target.files[0];
            resolve(file ? file.name : null);
        };
        input.click();
    });
}

function saveFile(filename, data, dataLength) {
    try {
        const blob = new Blob([data.slice(0, dataLength)], { type: 'application/octet-stream' });
        const url = URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = filename;
        link.click();
        URL.revokeObjectURL(url);
        return true;
    } catch (e) {
        return false;
    }
}

function copyToClipboard(text) {
    try {
        navigator.clipboard.writeText(text);
        return true;
    } catch (e) {
        return false;
    }
}

function pasteFromClipboard() {
    return navigator.clipboard.readText().catch(() => null);
}

function showAlert(message) {
    alert(message);
}

function showConfirm(message) {
    return confirm(message);
}

function getLanguage() {
    return navigator.language || navigator.userLanguage || 'en';
}

function isOnline() {
    return navigator.onLine;
}

function getBatteryLevel() {
    if (navigator.getBattery) {
        return navigator.getBattery().then((battery) => battery.level).catch(() => 1.0);
    }
    return 1.0;
}

function isCharging() {
    if (navigator.getBattery) {
        return navigator.getBattery().then((battery) => battery.charging).catch(() => false);
    }
    return false;
}

function getOrientation() {
    return window.innerHeight > window.innerWidth ? 0 : 1;
}

function requestCameraPermission() {
    return navigator.mediaDevices.getUserMedia({ video: true })
        .then((stream) => { stream.getTracks().forEach(track => track.stop()); return true; })
        .catch(() => false);
}

function requestMicrophonePermission() {
    return navigator.mediaDevices.getUserMedia({ audio: true })
        .then((stream) => { stream.getTracks().forEach(track => track.stop()); return true; })
        .catch(() => false);
}

function consoleLog(message) {
    console.log(message);
}

function consoleWarn(message) {
    console.warn(message);
}

function consoleError(message) {
    console.error(message);
}

if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', () => {
        if (Module && Module.onRuntime) Module.onRuntime();
        EmscriptenWebBridge.init();
    });
} else {
    if (Module && Module.onRuntime) Module.onRuntime();
    EmscriptenWebBridge.init();
}
";
        }

        /// <summary>
        ///     Gets an HTML template for embedding the WebAssembly module
        /// </summary>
        public static string GetHtmlTemplate()
        {
            return @"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>WebAssembly Game</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #000;
            font-family: Arial, sans-serif;
        }
        canvas {
            display: block;
            width: 100vw;
            height: 100vh;
        }
    </style>
</head>
<body>
    <!-- Include the Emscripten JavaScript runtime -->
    <script async type='text/javascript' src='game.js'></script>
    
    <!-- Include the WebAssembly bridge script -->
    <script>
        // Emscripten bridge code will be inserted here
    </script>
</body>
</html>";
        }
    }
}


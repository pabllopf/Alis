// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameControllerButton.cs
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

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl game controller button enum
    /// </summary>
    public enum GameControllerButton
    {
    /// <summary>
    ///     Invalid or uninitialized button identifier
    /// </summary>
    SdlControllerButtonInvalid = -1,

    /// <summary>
    ///     Bottom face button (typically A on Xbox, Cross on PlayStation)
    /// </summary>
    SdlControllerButtonA,

    /// <summary>
    ///     Right face button (typically B on Xbox, Circle on PlayStation)
    /// </summary>
    SdlControllerButtonB,

    /// <summary>
    ///     Left face button (typically X on Xbox, Square on PlayStation)
    /// </summary>
    SdlControllerButtonX,

    /// <summary>
    ///     Top face button (typically Y on Xbox, Triangle on PlayStation)
    /// </summary>
    SdlControllerButtonY,

    /// <summary>
    ///     Back or select button (typically located in the center)
    /// </summary>
    SdlControllerButtonBack,

    /// <summary>
    ///     Guide or Xbox button (typically located in the center)
    /// </summary>
    SdlControllerButtonGuide,

    /// <summary>
    ///     Start or menu button (typically located in the center)
    /// </summary>
    SdlControllerButtonStart,

    /// <summary>
    ///     Pressing the left analog stick down
    /// </summary>
    SdlControllerButtonLeftStick,

    /// <summary>
    ///     Pressing the right analog stick down
    /// </summary>
    SdlControllerButtonRightStick,

    /// <summary>
    ///     Left shoulder or bumper button
    /// </summary>
    SdlControllerButtonLeftShoulder,

    /// <summary>
    ///     Right shoulder or bumper button
    /// </summary>
    SdlControllerButtonRightShoulder,

    /// <summary>
    ///     Directional pad up direction
    /// </summary>
    SdlControllerButtonDpadUp,

    /// <summary>
    ///     Directional pad down direction
    /// </summary>
    SdlControllerButtonDpadDown,

    /// <summary>
    ///     Directional pad left direction
    /// </summary>
    SdlControllerButtonDpadLeft,

    /// <summary>
    ///     Directional pad right direction
    /// </summary>
    SdlControllerButtonDpadRight,

    /// <summary>
    ///     Miscellaneous button 1 (additional controller button)
    /// </summary>
    SdlControllerButtonMisc1,

    /// <summary>
    ///     Extra paddle button 1 on the back of the controller
    /// </summary>
    SdlControllerButtonPaddle1,

    /// <summary>
    ///     Extra paddle button 2 on the back of the controller
    /// </summary>
    SdlControllerButtonPaddle2,

    /// <summary>
    ///     Extra paddle button 3 on the back of the controller
    /// </summary>
    SdlControllerButtonPaddle3,

    /// <summary>
    ///     Extra paddle button 4 on the back of the controller
    /// </summary>
    SdlControllerButtonPaddle4,

    /// <summary>
    ///     Touchpad press on the controller
    /// </summary>
    SdlControllerButtonTouchpad,

    /// <summary>
    ///     Total number of button entries (sentinel value)
    /// </summary>
    SdlControllerButtonMax
    }
}
// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InternalKmsWmInfoTest.cs
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
using Alis.Extension.Graphic.Sdl2.Structs;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The internal kms wm info test class
    /// </summary>
    public class InternalKmsWmInfoTest
    {
        /// <summary>
        /// Tests that internal kms wm info default initialization fields have default values
        /// </summary>
        [Fact]
        public void InternalKmsWmInfo_DefaultInitialization_FieldsHaveDefaultValues()
        {
            InternalKmsWmInfo info = new InternalKmsWmInfo();

            Assert.Equal(0, info.dev_index);
            Assert.Equal(0, info.drm_fd);
            Assert.Equal(IntPtr.Zero, info.gbm_dev);
        }

        /// <summary>
        /// Tests that internal kms wm info is value type copy is independent
        /// </summary>
        [Fact]
        public void InternalKmsWmInfo_IsValueType_CopyIsIndependent()
        {
            InternalKmsWmInfo original = new InternalKmsWmInfo();
            InternalKmsWmInfo copy = original;

            Assert.Equal(original.dev_index, copy.dev_index);
            Assert.Equal(original.drm_fd, copy.drm_fd);
            Assert.Equal(original.gbm_dev, copy.gbm_dev);
        }
    }
}

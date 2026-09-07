// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManagerDisposeTest.cs
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
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Xunit;

namespace Alis.Extension.Cloud.GoogleDrive.Test
{
    /// <summary>
    ///     Tests targeting the Dispose(bool) false-path branch in GoogleDriveCloudManager.
    /// </summary>
    public class GoogleDriveCloudManagerDisposeTest
    {
        /// <summary>
        ///     A derived class that exposes the protected Dispose(bool) for testing the disposing=false path.
        /// </summary>
        private sealed class TestableGoogleDriveCloudManager : GoogleDriveCloudManager
        {
            public TestableGoogleDriveCloudManager(Context context, DriveService driveService) : base(context, driveService)
            {
            }

            public void InvokeDispose(bool disposing) => Dispose(disposing);
        }

        /// <summary>
        ///     Ensures Dispose(false) does not throw, covering the disposing=false branch
        ///     of Dispose(bool disposing) at line 484 (short-circuit when disposing is false).
        /// </summary>
        [Fact]
        public void Dispose_WithDisposeFalse_DoesNotThrow()
        {
            DriveService service = new DriveService(new BaseClientService.Initializer());
            TestableGoogleDriveCloudManager manager = new TestableGoogleDriveCloudManager(new Context(), service);

            Exception exception = Record.Exception(() => manager.InvokeDispose(false));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Ensures Dispose(false) on an uninitialized manager does not throw.
        /// </summary>
        [Fact]
        public void Dispose_WithDisposeFalse_Uninitialized_DoesNotThrow()
        {
            TestableGoogleDriveCloudManager manager = new TestableGoogleDriveCloudManager(new Context(), null);

            Exception exception = Record.Exception(() => manager.InvokeDispose(false));

            Assert.Null(exception);
        }
    }
}

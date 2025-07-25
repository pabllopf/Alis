// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using System.IO;
using System.Threading;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;

namespace Alis.Extension.Updater.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main
        /// </summary>
        public static void Main()
        {
            Logger.LogLevel = LogLevel.Trace;
            Logger.Log("Start sample program");

            string api = "https://api.github.com/repos/pabllopf/alis/releases";
            GitHubApiService gitHubApiService = new GitHubApiService(api);
            FileService fileService = new FileService();
            string pathProgram = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            UpdateManager updateManager = new UpdateManager(gitHubApiService, "latest", fileService, pathProgram);

            CancellationToken cancellationTokenSource = CancellationToken.None;
            updateManager.Start(cancellationTokenSource).Wait();

            Logger.Log("End sample program");
        }
    }
}
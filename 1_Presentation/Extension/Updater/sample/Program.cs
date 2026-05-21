

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
            Logger.Log("Start sample program");

            string api = "https://api.github.com/repos/pabllopf/alis/releases";
            GitHubApiService gitHubApiService = new GitHubApiService(new Uri(api));
            FileService fileService = new FileService();
            string pathProgram = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            UpdateManager updateManager = new UpdateManager(gitHubApiService, "latest", fileService, pathProgram);

            CancellationToken cancellationTokenSource = CancellationToken.None;
            updateManager.Start(cancellationTokenSource).Wait();

            Logger.Log("End sample program");
        }
    }
}
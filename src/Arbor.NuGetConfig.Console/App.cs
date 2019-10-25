using System;
using System.IO;
using System.Threading.Tasks;

using Serilog;

namespace Arbor.NuGetConfig.Console
{
    public sealed class App : IDisposable
    {
        private readonly ArgHelper _ArgHelper;

        private readonly ILogger _logger;

        private App(ILogger logger, ArgHelper argHelper)
        {
            _logger = logger;
            _ArgHelper = argHelper;
        }

        public static Task<int> CreateAndRun(string[] args)
        {
            App app = CreateApp(args);

            return app.Run(args);
        }

        public void Dispose()
        {
            if (_logger is IDisposable disposable)
                disposable.Dispose();
        }

        private static App CreateApp(string[] args)
        {
            ILogger logger = CreateLogger(args);
            var argHelper = new ArgHelper(logger);
            return new App(logger, argHelper);
        }

        private static ILogger CreateLogger(string[] args)
        {
            return new LoggerConfiguration()
                .WriteTo.Console().CreateLogger();
        }

        private async Task<int> Run(string[] args)
        {
            CreateEmptyConfig createEmptyConfig = _ArgHelper.ParseCreateEmptyConfig(args);

            if (createEmptyConfig is null)
            {
                _logger.Error("Invalid args");
                ShowUsage();
                return 1;
            }

            if (!createEmptyConfig.Directory.Exists)
                createEmptyConfig.Directory.Create();

            var fileInfo = new FileInfo(Path.Combine(createEmptyConfig.Directory.FullName, "nuget.config"));

            if (fileInfo.Exists)
            {
                _logger.Warning("nuget.config already exists");
                return 0;
            }

            await File.WriteAllTextAsync(fileInfo.FullName, NuGetConfigTemplate.Empty);

            _logger.Information("Created nuget.config file '{Path}'", fileInfo.FullName);

            return 0;
        }

        private void ShowUsage()
        {
            _logger.Information("Usage: directory={{Path}}");
        }
    }
}

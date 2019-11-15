using System;
using System.IO;
using System.Linq;

using Serilog;

namespace Arbor.NuGetConfig.Console
{
    internal class ArgHelper
    {
        private readonly ILogger _logger;

        public ArgHelper(ILogger logger) => _logger = logger;

        public CreateEmptyConfig ParseCreateEmptyConfig(string[] args)
        {
            if (args.Length == 0)
            {
                return null;
            }

            var parts = args[0].Split('=', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                return null;
            }

            if (!parts[0].Equals("directory", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            string directory = parts[1];
            DirectoryInfo directoryInfo;

            bool clear = args.Contains("--clear", StringComparer.OrdinalIgnoreCase);

            try
            {
                directoryInfo = new DirectoryInfo(directory);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Could not create directory info " + directory);
                return null;
            }

            return new CreateEmptyConfig(directoryInfo, clear);
        }
    }
}
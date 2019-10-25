using System.IO;

namespace Arbor.NuGetConfig.Console
{
    internal class CreateEmptyConfig
    {
        public CreateEmptyConfig(DirectoryInfo directoryInfo)
        {
            Directory = directoryInfo;
        }

        public DirectoryInfo Directory { get; }
    }
}

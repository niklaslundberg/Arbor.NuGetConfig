using System.IO;

namespace Arbor.NuGetConfig.Console
{
    internal class CreateEmptyConfig
    {
        public CreateEmptyConfig(DirectoryInfo directoryInfo, bool clear)
        {
            Directory = directoryInfo;
            Clear = clear;
        }

        public bool Clear { get; }

        public DirectoryInfo Directory { get; }
    }
}
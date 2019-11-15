using System.IO;

namespace Arbor.NuGetConfig.Console
{
    internal class CreateEmptyConfig
    {
        public CreateEmptyConfig(DirectoryInfo directoryInfo, bool clear)
        {
            Directory = directoryInfo;
            this.Clear = clear;
        }

        public DirectoryInfo Directory { get; }

        public bool Clear { get; }
    }
}

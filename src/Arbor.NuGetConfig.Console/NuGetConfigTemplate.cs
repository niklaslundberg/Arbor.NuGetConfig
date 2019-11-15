namespace Arbor.NuGetConfig.Console
{
    public static class NuGetConfigTemplate
    {
        public const string Clear = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <packageSources>
        </clear>
    </packageSources>
</configuration>";

        public const string Empty = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <config>
    </config>
</configuration>";
    }
}
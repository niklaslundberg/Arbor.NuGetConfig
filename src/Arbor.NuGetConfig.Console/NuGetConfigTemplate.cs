namespace Arbor.NuGetConfig.Console
{
    public static class NuGetConfigTemplate
    {
        public static string Empty = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <config>
    </config>
</configuration>";

        public static string Clear = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <packageSources>
        </clear>
    </packageSources>
</configuration>";
    }
}

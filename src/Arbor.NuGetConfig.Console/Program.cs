using System.Threading.Tasks;

namespace Arbor.NuGetConfig.Console
{
    public static class Program
    {
        public static Task<int> Main(string[] args)
        {
            return App.CreateAndRun(args);
        }
    }
}

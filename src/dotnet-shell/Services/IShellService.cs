using System.Diagnostics;

namespace dotnet_shell.Services
{
    public interface IShellService
    {
        int SpawnShell(string shellExecutable, string arguments = null);
    }

    public class BasicShellService : IShellService
    {
        public int SpawnShell(string shellExecutable, string arguments = null)
        {
            var process = new Process();
            process.StartInfo.FileName = shellExecutable;
            process.StartInfo.Arguments = arguments ?? string.Empty;
            process.StartInfo.WorkingDirectory = System.Environment.CurrentDirectory;
            var result = process.Start();
            if (result) {
                process.WaitForExit();
                return process.Id;
            }
            return -1;
        }
    }
}
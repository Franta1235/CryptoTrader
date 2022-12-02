using System.Diagnostics;
using System.IO;

namespace CryptoTrader.Helper.Python
{
    public class PythonProcess
    {
        private readonly Process _process;
        private readonly StreamWriter _writer;
        private readonly string _scriptPath;

        public PythonProcess(string scriptPath) {
            _scriptPath = scriptPath;
            _process = new Process();
            var info = new ProcessStartInfo {
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            _process.StartInfo = info;
            _process.Start();
            _writer = _process.StandardInput;
            _process.StandardOutput.ReadLine();
            _process.StandardOutput.ReadLine();
            _process.StandardOutput.ReadLine();
            _writer.WriteLine(scriptPath);
            _process.StandardOutput.ReadLine();
        }

        public void Kill() {
            _process.Kill();
        }


        public string CallFunction(string jsonString) {
            _writer.WriteLine($"\"{jsonString}\"");
            return _process.StandardOutput.ReadLine();
        }
    }
}
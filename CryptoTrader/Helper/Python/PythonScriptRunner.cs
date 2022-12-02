using System.Diagnostics;

namespace CryptoTrader.Helper.Python
{
    public class PythonScriptRunner
    {
        /// <summary>
        /// Runs python script
        /// </summary>
        /// <param name="scriptPath">absolute path of script</param>
        /// <param name="jsonString">JSON string</param>
        /// <returns></returns>
        public static string RunJson(string scriptPath, string jsonString) {
            return Run(scriptPath, $"\"{jsonString}\"");
        }

        private static string Run(string scriptPath, object input) {
            const string python = "python";

            var processStartInfo = new ProcessStartInfo(python) {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = $"{scriptPath} {input}"
            };

            var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            var reader = process.StandardOutput;
            var result = reader.ReadLine();
            process.WaitForExit();
            process.Close();
            return result;
        }
    }
}
using System;
using System.Web;
using System.Windows.Forms;

namespace BrowserParamAutoOpen
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var processedArgs = string.Join(" ", args);
            string passthroughText = string.Empty;

            if (!string.IsNullOrEmpty(processedArgs))
            {
                passthroughText = HandleBrowserText(processedArgs);

            }

            if (IsAnotherInstanceRunning(passthroughText))
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IPCServer.StartServer();

            Application.Run(new Form1(passthroughText));
        }

        private static bool IsAnotherInstanceRunning(string args)
        {
            try
            {
                IPCClient.SendArgsToRunningInstance(args);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string HandleBrowserText(string input)
        {
            const string prefix = "autoopen://";
            if (input.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring(prefix.Length);
            }

            string decodedText = HttpUtility.UrlDecode(input);

            return decodedText[..^1];
        }
    }
}
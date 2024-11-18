using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserParamAutoOpen
{
    public static class IPCClient
    {
        private const string PipeName = "BrowserParamAutoOpenPipe";

        public static void SendArgsToRunningInstance(string[] args)
        {
            try
            {
                using (var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
                {
                    pipeClient.Connect(1000);

                    using (var writer = new StreamWriter(pipeClient))
                    {
                        writer.WriteLine(string.Join(" ", args));
                    }
                }
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., logging)
            }
        }
    }
}

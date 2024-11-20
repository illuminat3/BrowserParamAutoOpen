using System;
using System.IO.Pipes;

namespace BrowserParamAutoOpen
{
    public static class IPCClient
    {
        private const string PipeName = "BrowserParamAutoOpenPipe";

        public static void SendArgsToRunningInstance(string args)
        {
            using var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.Out);
            pipeClient.Connect(1000);

            using var writer = new StreamWriter(pipeClient) { AutoFlush = true };
            writer.WriteLine(args);
        }
    }
}

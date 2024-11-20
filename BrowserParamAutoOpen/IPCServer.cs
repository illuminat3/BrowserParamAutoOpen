using System.IO.Pipes;
using System.Web;

namespace BrowserParamAutoOpen
{
    public class IPCServer
    {
        private const string PipeName = "BrowserParamAutoOpenPipe";

        public static event EventHandler<BrowserOpenEventArgs>? OnArgsReceived;

        public static void StartServer()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    using var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In);
                    pipeServer.WaitForConnection();

                    using var reader = new StreamReader(pipeServer);
                    string? argsLine = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(argsLine))
                    {
                        OnArgsReceived?.Invoke(null, new BrowserOpenEventArgs(argsLine));
                    }
                }
            });
        }
    }
}

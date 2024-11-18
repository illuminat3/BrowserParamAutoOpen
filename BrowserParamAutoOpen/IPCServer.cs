using System.IO.Pipes;

namespace BrowserParamAutoOpen
{
    public class IPCServer
    {
        private const string PipeName = "BrowserParamAutoOpenPipe";

        public static void StartServer(Form1 form1)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    using (var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In))
                    {
                        pipeServer.WaitForConnection();

                        using (var reader = new StreamReader(pipeServer))
                        {
                            string argsLine = reader.ReadLine();
                            if (!string.IsNullOrWhiteSpace(argsLine))
                            {
                                string[] args = argsLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                form1.Invoke(new Action(() =>
                                {
                                    form1.ProcessArguments(args);
                                }));
                            }
                        }
                    }
                }
            });
        }
    }
}

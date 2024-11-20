using System.Net.Sockets;

namespace BrowserParamAutoOpen
{
    internal static class Program
    {
        private static Mutex mutex;

        [STAThread]
        static void Main(string[] args)
        {
            const string mutexName = "BrowserParamAutoOpenMutex";
            bool isOwned;

            mutex = new Mutex(true, mutexName, out isOwned);

            if (!isOwned)
            {
                // An instance is already running; pass arguments and focus it
                IPCClient.SendArgsToRunningInstance(args);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
            mutex.ReleaseMutex();
        }
    }
}
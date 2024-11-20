namespace BrowserParamAutoOpen
{
    public partial class Form1 : Form
    {
        public Form1(string args)
        {
            InitializeComponent();
            textBox1.Text = args;
            IPCServer.OnArgsReceived += HandleBrowserOpen;
        }

        private void HandleBrowserOpen(object? sender, BrowserOpenEventArgs e)
        {
            Invoke((MethodInvoker)(() =>
            {
                textBox1.Text = e.Args;
            }));
        }
    }
}

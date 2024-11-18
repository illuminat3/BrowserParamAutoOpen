namespace BrowserParamAutoOpen
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            InitializeComponent();
            ProcessArguments(args);
            IPCServer.StartServer(this);
        }

        public void ProcessArguments(string[] args)
        {

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            this.Activate();
            this.TopMost = true;
            this.TopMost = false;
        }
    }
}

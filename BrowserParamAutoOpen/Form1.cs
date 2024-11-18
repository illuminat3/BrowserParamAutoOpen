using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BrowserParamAutoOpen
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            InitializeComponent();

            // Check if a locationString is passed
            if (args.Length > 0)
            {
                string locationString = args[0]; // Capture the locationString
                DisplayLocation(locationString);
            }
        }

        private void DisplayLocation(string locationString)
        {
            textBox1.Text = locationString;
        }
    }
}
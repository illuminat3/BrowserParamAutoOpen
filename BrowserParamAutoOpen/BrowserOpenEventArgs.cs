using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserParamAutoOpen
{
    public class BrowserOpenEventArgs : EventArgs
    {
        public string Args { get; }

        public BrowserOpenEventArgs(string args)
        {
            Args = args;
        }
    }
}

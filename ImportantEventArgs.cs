using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class ImportantEventArgs : EventArgs
    {
        private bool end = true;
        private string message;
        public bool End
        {
            get { return end; }
            set { this.end = value; }
        }
        public string Message
        {
            get { return message; }
        }
        public ImportantEventArgs(string message)
        {
            this.message = message;
        }
    }
}

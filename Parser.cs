using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _422616Homework5
{
    class Parser
    {
        private readonly List<int> numbers;

        public List<int> Numbers
        {
            get { return numbers; }
        }

        public Parser(string fileName)
        {
            char[] data = System.IO.File.ReadAllText(fileName).ToCharArray();
            numbers = new List<int>();
            foreach (char ch in data)
            {
                numbers.Add(Convert.ToInt32(ch.ToString()));
            }
        }
    }
}

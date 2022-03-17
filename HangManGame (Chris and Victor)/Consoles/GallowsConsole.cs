using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGame__Chris_and_Victor_.Consoles
{
    public class GallowsConsole : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string s)
        {
            Console.Write(s);
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void WriteLine(object o)
        {
            Console.WriteLine(o);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteRedLine(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public void WriteRedLine(object o)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(o);
        }

        public void WriteGreen(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ResetColor();
        }
        public void BadEndClear()
        {
            Console.Clear();
            Console.Beep(100, 1000);
            
        }
    }
}

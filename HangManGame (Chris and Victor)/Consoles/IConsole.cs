using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangManGame__Chris_and_Victor_.Consoles
{
    public interface IConsole
    {
        void WriteLine(string s);
        void WriteLine(object o);
        void WriteLine();
        void Write(string s);
        void Clear();
        string ReadLine();
        ConsoleKeyInfo ReadKey();
        void WriteRedLine(string s);
        void WriteGreen(string s);
        void BadEndClear();
    }
}

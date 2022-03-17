using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangManGame__Chris_and_Victor_.Consoles;

namespace HangManGame__Chris_and_Victor_
{
    public class Program
    {
        static void Main()
        {
            ProgramUI program = new ProgramUI(new GallowsConsole());
            
            program.Run();
        }
    }
}

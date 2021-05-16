using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Komodo Cafe");
            ProgramUI KomodoCafeUI = new ProgramUI();
            KomodoCafeUI.Run();
        }
    }
}

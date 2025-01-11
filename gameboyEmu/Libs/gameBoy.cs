using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Documents;

namespace gameboyEmu.Libs;
class gameBoy
{
    private gameBoy(CPU cpu, MMU ram) { }
    private static gameBoy gb; 

    private static readonly object _lock = new object();

    public static gameBoy GetInstance(CPU cpu, MMU ram)
    {
        if (gb == null)
        {
            lock (_lock)
            {
                if (gb == null)
                {
                    gb = new gameBoy(cpu, ram);

                }
            }

            
        }
        return gb;
    }
}

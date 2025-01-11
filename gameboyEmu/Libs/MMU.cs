using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmu.Libs;
internal class MMU
{
    private int[] ramBank { get; set; } 
public MMU()
    {
        this.ramBank = new int[0xFFFF];
    }


}

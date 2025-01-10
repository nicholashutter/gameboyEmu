using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmu.Libs;
internal class MMU
{
    int[] ramBank; 
public MMU()
    {
        this.ramBank = new int[0xFFFF];
    }


}

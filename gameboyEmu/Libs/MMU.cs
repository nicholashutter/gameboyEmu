using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameboyEmu.Libs;
internal class MMU
{
    private int[] ramBank; 
public MMU()
    {
        this.ramBank = new int[0x200000];
    }

    public void writeRam(byte[] romBuffer)
    {
        for (int i = 0; i < ramBank.Length; i++)
        {
            this.ramBank[i] = romBuffer[i];
        }
        Console.WriteLine("done"); 
    }

    public void dumpRam()
    {
       
    }
}

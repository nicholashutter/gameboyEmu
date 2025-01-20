using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace gameboyEmu.Libs;
internal class MMU
{
    private byte[] ramBank; 
public MMU()
    {
        this.ramBank = new byte[0x200000];
    }

    public void writeRam(byte[] romBuffer)
    {
        
        for (int i = 0; i < ramBank.Length; i++)
        {
            this.ramBank[i] = romBuffer[i];
        }
        
        Debug.WriteLine("Rom Loaded into Ram"); 
    }

    public void dumpRam()
    {
        String ramToString = String.Join(" ", this.ramBank);

        Debug.WriteLine(ramToString);
    }

    public byte getInstruction(int memoryAddress)
    {
        return this.ramBank[memoryAddress]; 
    }
}

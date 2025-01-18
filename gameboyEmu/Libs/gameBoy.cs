using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Documents;

namespace gameboyEmu.Libs;
class gameBoy
{
    //thread safe singleton pattern there will only be one gameBoy and it will track its member CPU and MMU 
    private gameBoy(CPU cpu, MMU ram) { 
        this.cpu = cpu; 
        this.ram = ram; 

    }
    private static gameBoy gb; 

    //lock object that will lock file upon first thread attempting to access 
    private static readonly object _lock = new object();

    //objects intended to hold synchronized instance of CPU and MMU
    protected CPU cpu;
    protected MMU ram;

   

    public static gameBoy GetInstance()
    {
        if (gb == null)
        {
            lock (_lock)
            {
                if (gb == null)
                {
                    MMU ram = new MMU();
                    CPU cpu = new CPU(ram); 
                    gb = new gameBoy(cpu, ram);

                }
            }

            
        }
        return gb;
    }

    public void loadROM(string filePath)
    {
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            var bytesArray = new byte[fileStream.Length];
            fileStream.Read(bytesArray);

            this.ram.writeRam(bytesArray);

            
        };


       
    }
}

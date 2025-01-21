using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Documents;

using System.Diagnostics;

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

    

    public async void loadROM(string filePath)
    {
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                byte[] bytesArray = new byte[fileStream.Length];

                int counter = 0;

                try
                {
                    for (int i = 0; i < fileStream.Length; i++)
                    {
                        bytesArray[i] = reader.ReadByte();
                        counter++; 
                    }

                    this.ram.writeRam(bytesArray);
                }
                catch (Exception e)
                {
                    throw new Exception($"Error Reading File. Successfully Read {counter} bytes from memory."); 
                }
                
            }
            
            
        };

        this.cpu.runCPU(); 
    }
}

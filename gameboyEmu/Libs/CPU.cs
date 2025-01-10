using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Diagnostics;

namespace gameboyEmu.Libs
{
    class CPU
    {

        /*
         * 
         * Accumulator - L, registers 8 bit including flag register
         * All register abbreviations are the official abbreviations 
           the technical documentation usually in uppercase
         */
        //accumulator
        protected byte A { get; set; }
        //flags register
        protected byte F { get; set; }

        protected byte B { get; set; }
        protected byte C { get; set; }
        protected byte D { get; set; }
        protected byte E { get; set; }
        protected byte H { get; set; }
        protected byte L { get; set; }

        /* PC and SP 16 bit */
        //stack pointer 
        protected ushort SP { get; set; }
        //program counter
        protected ushort PC { get; set; }

        //set which interrupt current occuring 
        protected byte IF { get; set; }
        //enable or disable interrupts
        protected byte IE { get; set; }


        //clock will increment based on the cycles each cpu operation takes
        protected int clock { get; set; }

        //current working opcodes
        protected byte opcode1 { get; set; }
        protected byte opcode2 { get; set; }
        //current working operands
        protected byte operand1 { get; set; }
        protected byte operand2 { get; set; }

        /*
         * 
         * State of CPU during full program exeuction 
            CPU is either running, fetching new operation code/extended operation code, fetching new operand, 
            reading a register, pushing machine state onto stack, or stopped/halted 
         */

        protected enum State
        {
            fetchOpCode, fetchExtendedOpCode, fetchOperand, running, interruptRequestReadInteruptFlag, interruptRequestReadInteruptEnabled,
            interruptRequestPush1, interruptRequestPush2, interuptRequestJump, stopped, halted
        }

        public CPU(MMU memory)
        {
            this.A = 0x000;
            this.B = 0x000;
            this.C = 0x000;
            this.D = 0x000;
            this.E = 0x000;
            this.F = 0x000;
            this.SP = 0x000;
            this.IE = 0x000;
            this.opcode1 = 0x00;
            this.opcode2 = 0x00;
            this.operand1 = 0x00;
            this.operand2 = 0x00;
            State state = State.stopped;


        }
        public void resetState()
        {

        }

        /* functions to represent operations */
        private void ADCA_value_r8()
            {
            /*
             Add the value in r8 plus the carry flag to A.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    Set if overflow from bit 3.
                C
                    Set if overflow from bit 7. 
             
             */
        }

        private void ADCA_ptr_HL()
        {
            /*
             Add the byte pointed to by HL plus the carry flag to A.

                Cycles: 2

                Bytes: 1

                Flags: See ADC A,r8
             
             */
        }
    }
}

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

        //current working instructions 
        protected byte instruction { get; set; }

        protected byte instruction2 { get; set; }

        protected byte instruction3 { get; set; }

        //start stop switch for cpu loop 
        protected Boolean isRunning = false;

        /*
         * 
         * State of CPU during full program exeuction 
            CPU is either running, fetching new operation code/extended operation code, fetching new operand, 
            reading a register, pushing machine state onto stack, or stopped/halted 
         */

        protected enum CPUState
        {
            fetch, fetchExtended, execute, interruptRequestReadInteruptFlag, interruptRequestReadInteruptEnabled,
            interruptRequestPush1, interruptRequestPush2, interuptRequestJump, stopped, halted
        }

        CPUState state;

        //Memory Management Unit
        MMU ram;

        public CPU(MMU ram)
        {
            this.A = 0x000;
            this.B = 0x000;
            this.C = 0x000;
            this.D = 0x000;
            this.E = 0x000;
            this.F = 0x000;
            this.SP = 0x000;
            this.IE = 0x000;
            this.instruction = 0x00;
            this.instruction2 = null;
            this.instruction3 = null;

            this.state = CPUState.stopped;

            this.ram = ram;
        }


        public void runCPU()
        {
            this.isRunning = true;
            while (this.isRunning)
            {
                this.PC = 0;
                //fetch 
                this.fetch();
                this.isRunning = false;
                //execute

            }
        }

        private void changeCPUstate(ref int newState)
        {
            this.state = newState;
            if (this.state != CPUState.execute)
            {
                if (this.instruction2 != null)
                {
                    this.instruction2 = null;
                }
                if (this.instruction3 != null)
                {
                    this.instruction3 = null;
                }
            }


            private void fetch()
            {
                // update cpu state 
                this.changeCPUstate(0);
                // get next instruction (entire 8 bit word) from memory
                //ushort instruction = this.ram.getInstruction(); 
                this.instruction = this.ram.getInstruction(this.PC);

                if (instruction == 0xCB)
                {
                    this.state = CPUState.fetchExtended;
                    this.instruction2 = this.ram.getInstruction(this.PC);

                    //probably need to do something with program counter here
                }
                // decode 8 or 16 bit, split into opcode and operand

                this.execute();
            }

            private void execute()
            {
                // update cpu state
                // refer to class members 
                this.changeCPUstate(2);

                if (this.instruction2 != null && this.instruction3 == null)
                {
                    this.instruction = this.instruction2;
                    this.exInstruction = null;
                }

                switch (this.instruction)
                {
                    case 0x00:
                        this.NOP();
                        break;
                    case 0x1000:
                        this.STOP();
                        break;
                    case 0x20:
                        //this.JR NZ, s8();
                        break;
                    case 0x30:
                        //this.JR NC, s8(); 
                        break;
                    case 0x40:
                        //this.LD B, B(); 
                        break;
                    case 0x50:
                        //this.D, B();

                }
            }


            public void resetState()
            {

            }





            private void setDECflags()
            {

            }
            private void setINCflags()
            {

            }
            private void setADDHLflags()
            {

            }
            private void setRLflags()
            {

            }
            private void setDAAflags()
            {

            }
            private void setSCFflags()
            {

            }
            private void setRRflags()
            {

            }
            private void setCPflags()
            {

            }
            private void setCCflags()
            {

            }
            private void setADflags()
            {

            }
            private void setSUBflags()
            {

            }
            private void setANDflags()
            {

            }

            private void setORflags()
            {

            }

            private void setLDHLflags()
            {

            }

            private void setRLflags()
            {

            }

            private void _0x00()
            {

            }

            private void _0x1000()
            {

            }

            private void _0x20()
            {

            }

            private void _0x30()
            {

            }

            private void _0x40()
            {
                
            }

            private void _0x50()
            {

            }

            private void _0x60()
            {

            }

            private void _0x70()
            {

            }

            private void _0x80()
            {
            
            }

            private void _0xA0()
            {

            }

            private void _0xB0()
            {

            }

            private void _0xC0()
            {

            }

            private void _0xD0()
            {

            }

            private void _0xE0()
            {

            }

            private void _0xF0()
            {

            }

            private void _0x01()
            {

            }

            private void _0x11()
            {

            }

            private void _0x21()
            {

            }
            private void _0x31()
            {

            }
            private void _0x41()
            {

            }
            private void _0x51()
            {

            }
            private void _0x61()
            {

            }
            private void _0x71()
            {

            }
            private void _0x81()
            {

            }
            private void _0x91()
            {

            }
            private void _0xA1()
            {

            }
            private void _0xB1()
            {

            }
            private void _0xC1()
            {

            }
            private void _0xD1()
            {

            }
            private void _0xE1()
            {

            }
            private void _0xF1()
            {

            }
            private void _0x02()
            {

            }

            private void _0x12()
            {

            }

            private void _0x22()
            {

            }
            private void _0x32()
            {

            }
            private void _0x42()
            {

            }
            private void _0x52()
            {

            }
            private void _0x62()
            {

            }
            private void _0x72()
            {

            }
            private void _0x82()
            {

            }
            private void _0x92()
            {

            }
            private void _0xA2()
            {

            }
            private void _0xB2()
            {

            }
            private void _0xC2()
            {

            }
            private void _0xD2()
            {

            }
            private void _0xE2()
            {

            }
            private void _0xF2()
            {

            }
            private void _0x03()
            {

            }
            private void _0x13()
            {

            }
            private void _0x23()
            {

            }
            private void _0x33()
            {

            }
            private void _0x43()
            {

            }
            private void _0x53()
            {

            }
            private void _0x63()
            {

            }
            private void _0x73()
            {

            }
            private void _0x83()
            {

            }
            private void _0x93()
            {

            }
            private void _0xA3()
            {

            }
            private void _0xB3()
            {

            }
            private void _0xC3()
            {

            }
            
            private void _0xF3()
            {

            }
            private void _0x04()
            {

            }
            private void _0x14()
            {

            }
            private void _0x24()
            {

            }
            private void _0x34()
            {

            }
            private void _0x44()
            {

            }
            private void _0x54()
            {

            }
            private void _0x64()
            {

            }
            private void _0x74()
            {

            }
            private void _0x84()
            {

            }
            private void _0x94()
            {

            }
            private void _0xA4()
            {

            }
            private void _0xB4()
            {

            }
            private void _0xD4()
            {

            }
            private void _0x05()
            {

            }
            private void _0x15()
            {

            }
            private void _0x25()
            {

            }
            private void _0x35()
            {

            }
            private void _0x45()
            {

            }
            private void _0x55()
            {

            }
            private void _0x65()
            {

            }
            private void _0x75()
            {

            }
            private void _0x85()
            {

            }
            private void _0x95()
            {

            }
            private void _0xA5()
            {

            }
            private void _0xB5()
            {

            }
            private void _0xC5()
            {

            }
            private void _0xD5()
            {

            }
            private void _0xE5()
            {

            }
            private void _0xF5()
            {

            }
            private void _0x06()
            {

            }
            private void _0x16()
            {

            }
            private void _0x26()
            {

            }
            private void _0x36()
            {

            }
            private void _0x46()
            {

            }
            private void _0x56()
            {

            }
            private void _0x66()
            {

            }
            private void _0x76()
            {

            }
            private void _0x86()
            {

            }
            private void _0x96()
            {

            }
            private void _0xA6()
            {

            }
            private void _0xB6()
            {

            }
            private void _0xC6()
            {

            }
            private void _0xD6()
            {

            }
            private void _0xE6()
            {

            }
            private void _0xF6()
            {

            }
            private void _0x07()
            {

            }
            private void _0x17()
            {

            }
            private void _0x27()
            {

            }
            private void _0x37()
            {

            }
            private void _0x47()
            {

            }
            private void _0x57()
            {

            }
            private void _0x67()
            {

            }
            private void _0x77()
            {

            }
            private void _0x87()
            {

            }
            private void _0x97()
            {

            }
            private void _0xA7()
            {

            }
            private void _0xB7()
            {

            }
            private void _0xC7()
            {

            }
            private void _0xD7()
            {

            }
            private void _0xE7()
            {

            }
            private void _0xF7()
            {

            }
            private void _0x08()
            {

            }
            private void _0x18()
            {

            }
            private void _0x28()
            {

            }
            private void _0x38()
            {

            }
            private void _0x48()
            {

            }
            private void _0x58()
            {

            }
            private void _0x68()
            {

            }
            private void _0x78()
            {

            }
            private void _0x88()
            {

            private void _0x98()
            {

            }
            private void _0x0A8()
            {

            }
                private void _0x0B8()
                {

                }
                private void _0x0C8()
                {

                }
                private void _0x0D8()
                {

                }
                private void _0x0E8()
                {

                }
                private void _0x0F8()
                {

                }
        /* 
         * 
         * 
         * functions to represent operations
         * 
         
         */


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

        //Memory Management Unit ram
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
            this.instruction2 = 0x00;
            this.instruction3 = 0x00;

            this.state = CPUState.stopped;

            this.ram = ram;
        }

        //operate CPU methods
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
        private void changeCPUstate(CPUState newState)
        {
            this.state = newState;
            if (this.state != CPUState.execute)
            {
                if (this.instruction2 != 0x00)
                {
                    this.instruction2 = 0x00;
                }
                if (this.instruction3 != 0x00)
                {
                    this.instruction3 = 0x00;
                }
            }

        }
        public void resetState()
        {

        }
        private void fetch()
        {
            // update cpu state 
            this.changeCPUstate(CPUState.fetch);
            // get next instruction (entire 8 bit word) from memory
            //ushort instruction = this.ram.getInstruction(); 
            this.instruction = this.ram.getInstruction(this.PC);

            if (instruction == 0xCB)
            {
                this.changeCPUstate(CPUState.fetchExtended);
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
            this.changeCPUstate(CPUState.execute);

            switch (this.instruction)
            {
                case 0x00:
                    this._0x00();
                    break;
                case 0x10:
                    this._0x10();
                    break;
                case 0x20:
                    this._0x20();
                    break;
                case 0x30:
                    this._0x30();
                    break;
                case 0x40:
                    this._0x40();
                    break;
                case 0x50:
                    this._0x50();
                    break;
                case 0x60:
                    this._0x06();
                    break;
                case 0x07:
                    this._0x07();
                    break;
                case 0x08:
                    this._0x08();
                    break;
                case 0x09:
                    this._0x09();
                    break;
                case 0x0A:
                    this._0x0A();
                    break;
                case 0x0B:
                    this._0x0B();
                    break;
                case 0x0C:
                    this._0x0C();
                    break;
                case 0x0D:
                    this._0x0D();
                    break;
                case 0x0E:
                    this._0x0E();
                    break;
                case 0x0F:
                    this._0x0F();
                    break;
                case 0x11:
                    this._0x11();
                    break;
                case 0x12:
                    this._0x12();
                    break;
                case 0x13:
                    this._0x13();
                    break;
                case 0x14:
                    this._0x14();
                    break;
                case 0x15:
                    this._0x15();
                    break;
                case 0x16:
                    this._0x16();
                    break;
                case 0x17:
                    this._0x17();
                    break;
                case 0x18:
                    this._0x18();
                    break;
                case 0x19:
                    this._0x19();
                    break;
                case 0x1A:
                    this._0x1A();
                    break;
                case 0x1B:
                    this._0x1B();
                    break;
                case 0x1C:
                    this._0x1C();
                    break;
                case 0x1D:
                    this._0x1D();
                    break;
                case 0x1E:
                    this._0x1E();
                    break;
                case 0x1F:
                    this._0x1F();
                    break;
                case 0x21:
                    this._0x21();
                    break;
                case 0x22:
                    this._0x22();
                    break;
                case 0x23:
                    this._0x23();
                    break;
                case 0x24:
                    this._0x24();
                    break;
                case 0x25:
                    this._0x25();
                    break;
                case 0x26:
                    this._0x26();
                    break;
                case 0x27:
                    this._0x27();
                    break;
                case 0x28:
                    this._0x28();
                    break;
                case 0x29:
                    this._0x29();
                    break;
                case 0x2A:
                    this._0x2A();
                    break;
                case 0x2B:
                    this._0x2B();
                    break;
                case 0x2C:
                    this._0x2C();
                    break;
                case 0x2D:
                    this._0x2D();
                    break;
                case 0x2E:
                    this._0x2E();
                    break;
                case 0x2F:
                    this._0x2F();
                    break;
                case 0x31:
                    this._0x31();
                    break;
                case 0x32:
                    this._0x32();
                    break;
                case 0x33:
                    this._0x33();
                    break;
                case 0x34:
                    this._0x34();
                    break;
                case 0x35:
                    this._0x35();
                    break;
                case 0x36:
                    this._0x36();
                    break;
                case 0x37:
                    this._0x37();
                    break;
                case 0x38:
                    this._0x38();
                    break;
                case 0x39:
                    this._0x39();
                    break;
                case 0x3A:
                    this._0x3A();
                    break;
                case 0x3B:
                    this._0x3B();
                    break;
                case 0x3C:
                    this._0x3C();
                    break;
                case 0x3D:
                    this._0x3D();
                    break;
                case 0x3E:
                    this._0x3E();
                    break;
                case 0x3F:
                    this._0x3F();
                    break;
                case 0x41:
                    this._0x41();
                    break;
                case 0x42:
                    this._0x42();
                    break;
                case 0x43:
                    this._0x43();
                    break;
                case 0x44:
                    this._0x44();
                    break;
                case 0x45:
                    this._0x45();
                    break;
                case 0x46:
                    this._0x46();
                    break;
                case 0x47:
                    this._0x47();
                    break;
                case 0x48:
                    this._0x48();
                    break;
                case 0x49:
                    this._0x49();
                    break;
                case 0x4A:
                    this._0x4A();
                    break;
                case 0x4B:
                    this._0x4B();
                    break;
                case 0x4C:
                    this._0x4C();
                    break;
                case 0x4D:
                    this._0x4D();
                    break;
                case 0x4E:
                    this._0x4E();
                    break;
                case 0x4F:
                    this._0x4F();
                    break;
                case 0x51:
                    this._0x51();
                    break;
                case 0x52:
                    this._0x52();
                    break;
                case 0x53:
                    this._0x53();
                    break;
                case 0x54:
                    this._0x54();
                    break;
                case 0x55:
                    this._0x55();
                    break;
                case 0x56:
                    this._0x56();
                    break;
                case 0x57:
                    this._0x57();
                    break;
                case 0x58:
                    this._0x58();
                    break;
                case 0x59:
                    this._0x59();
                    break;
                case 0x5A:
                    this._0x5A();
                    break;
                case 0x5B:
                    this._0x5B();
                    break;
                case 0x5C:
                    this._0x5C();
                    break;
                case 0x5D:
                    this._0x5D();
                    break;
                case 0x5E:
                    this._0x5E();
                    break;
                case 0x5F:
                    this._0x5F();
                    break;
                case 0x61:
                    this._0x61();
                    break;
                case 0x62:
                    this._0x62();
                    break;
                case 0x63:
                    this._0x63();
                    break;
                case 0x64:
                    this._0x64();
                    break;
                case 0x65:
                    this._0x65();
                    break;
                case 0x66:
                    this._0x66();
                    break;
                case 0x67:
                    this._0x67();
                    break;
                case 0x68:
                    this._0x68();
                    break;
                case 0x69:
                    this._0x69();
                    break;
                case 0x6A:
                    this._0x6A();
                    break;
                case 0x6B:
                    this._0x6B();
                    break;
                case 0x6C:
                    this._0x6C();
                    break;
                case 0x6D:
                    this._0x6D();
                    break;
                case 0x6E:
                    this._0x6E();
                    break;
                case 0x6F:
                    this._0x6F();
                    break;
                case 0x70:
                    this._0x70();
                    break;
                case 0x71:
                    this._0x71();
                    break;
                case 0x72:
                    this._0x72();
                    break;
                case 0x73:
                    this._0x73();
                    break;
                case 0x74:
                    this._0x74();
                    break;
                case 0x75:
                    this._0x75();
                    break;
                case 0x76:
                    this._0x76();
                    break;
                case 0x77:
                    this._0x77();
                    break;
                case 0x78:
                    this._0x78();
                    break;
                case 0x79:
                    this._0x79();
                    break;
                case 0x7A:
                    this._0x7A();
                    break;
                case 0x7B:
                    this._0x7B();
                    break;
                case 0x7C:
                    this._0x7C();
                    break;
                case 0x7D:
                    this._0x7D();
                    break;
                case 0x7E:
                    this._0x7E();
                    break;
                case 0x7F:
                    this._0x7F();
                    break;
                case 0x80:
                    this._0x80();
                    break;
                case 0x81:
                    this._0x81();
                    break;
                case 0x82:
                    this._0x82();
                    break;
                case 0x83:
                    this._0x83();
                    break;
                case 0x84:
                    this._0x84();
                    break;
                case 0x85:
                    this._0x85();
                    break;
                case 0x86:
                    this._0x86();
                    break;
                case 0x87:
                    this._0x87();
                    break;
                case 0x88:
                    this._0x88();
                    break;
                case 0x89:
                    this._0x89();
                    break;
                case 0x8A:
                    this._0x8A();
                    break;
                case 0x8B:
                    this._0x8B();
                    break;
                case 0x8C:
                    this._0x8C();
                    break;
                case 0x8D:
                    this._0x8D();
                    break;
                case 0x8E:
                    this._0x8E();
                    break;
                case 0x8F:
                    this._0x8F();
                    break;
                case 0x91:
                    this._0x91();
                    break;
                case 0x92:
                    this._0x92();
                    break;
                case 0x93:
                    this._0x93();
                    break;
                case 0x94:
                    this._0x94();
                    break;
                case 0x95:
                    this._0x95();
                    break;
                case 0x96:
                    this._0x96();
                    break;
                case 0x97:
                    this._0x97();
                    break;
                case 0x98:
                    this._0x98();
                    break;
                case 0x99:
                    this._0x99();
                    break;
                case 0x9A:
                    this._0x9A();
                    break;
                case 0x9B:
                    this._0x9B();
                    break;
                case 0x9C:
                    this._0x9C();
                    break;
                case 0x9D:
                    this._0x9D();
                    break;
                case 0x9E:
                    this._0x9E();
                    break;
                case 0x9F:
                    this._0x9F();
                    break;
                case 0xA0:
                    this._0xA0();
                    break;
                case 0xA1:
                    this._0xA1();
                    break;
                case 0xA2:
                    this._0xA2();
                    break;
                case 0xA3:
                    this._0xA3();
                    break;
                case 0xA4:
                    this._0xA4();
                    break;
                case 0xA5:
                    this._0xA5();
                    break;
                case 0xA6:
                    this._0xA6();
                    break;
                case 0xA7:
                    this._0xA7();
                    break;
                case 0xA8:
                    this._0xA8();
                    break;
                case 0xA9:
                    this._0xA9();
                    break;
                case 0xAA:
                    this._0xAA();
                    break;
                case 0xAB:
                    this._0xAB();
                    break;
                case 0xAC:
                    this._0xAC();
                    break;
                case 0xAD:
                    this._0xAD();
                    break;
                case 0xAE:
                    this._0xAE();
                    break;
                case 0xAF:
                    this._0xAF();
                    break;
                case 0xB0:
                    this._0xB0();
                    break;
                case 0xB1:
                    this._0xB1();
                    break;
                case 0xB2:
                    this._0xB2();
                    break;
                case 0xB3:
                    this._0xB3();
                    break;
                case 0xB4:
                    this._0xB4();
                    break;
                case 0xB5:
                    this._0xB5();
                    break;
                case 0xB6:
                    this._0xB6();
                    break;
                case 0xB7:
                    this._0xB7();
                    break;
                case 0xB8:
                    this._0xB8();
                    break;
                case 0xB9:
                    this._0xB9();
                    break;
                case 0xBA:
                    this._0xBA();
                    break;
                case 0xBB:
                    this._0xBB();
                    break;
                case 0xBC:
                    this._0xBC();
                    break;
                case 0xBD:
                    this._0xBD();
                    break;
                case 0xBE:
                    this._0xBE();
                    break;
                case 0xBF:
                    this._0xBF();
                    break;
                case 0xC0:
                    this._0xC0();
                    break;
                case 0xC1:
                    this._0xC1();
                    break;
                case 0xC2:
                    this._0xC2();
                    break;
                case 0xC3:
                    this._0xC3();
                    break;
                case 0xC5:
                    this._0xC5();
                    break;
                case 0xC6:
                    this._0xC6();
                    break;
                case 0xC7:
                    this._0xC7();
                    break;
                case 0xC8:
                    this._0xC8();
                    break;
                case 0xC9:
                    this._0xC9();
                    break;
                case 0xCA:
                    this._0xCA();
                    break;
                case 0xCC:
                    this._0xCC();
                    break;
                case 0xCD:
                    this._0xCD();
                    break;
                case 0xCE:
                    this._0xCE();
                    break;
                case 0xCF:
                    this._0xCF();
                    break;
                case 0xD0:
                    this._0xD0();
                    break;
                case 0xD1:
                    this._0xD1();
                    break;
                case 0xD2:
                    this._0xD2();
                    break;
                case 0xD4:
                    this._0xD4();
                    break;
                case 0xD5:
                    this._0xD5();
                    break;
                case 0xD6:
                    this._0xD6();
                    break;
                case 0xD7:
                    this._0xD7();
                    break;
                case 0xD8:
                    this._0xD8();
                    break;
                case 0xD9:
                    this._0xD9();
                    break;
                case 0xDA:
                    this._0xDA();
                    break;
                case 0xDC:
                    this._0xDC();
                    break;
                case 0xDE:
                    this._0xDE();
                    break;
                case 0xDF:
                    this._0xDF();
                    break;
                case 0xE0:
                    this._0xE0();
                    break;
                case 0xE1:
                    this._0xE1();
                    break;
                case 0xE2:
                    this._0xE2();
                    break;
                case 0xE5:
                    this._0xE5();
                    break;
                case 0xE6:
                    this._0xE6();
                    break;
                case 0xE7:
                    this._0xE7();
                    break;
                case 0xE8:
                    this._0xE8();
                    break;
                case 0xE9:
                    this._0xE9();
                    break;
                case 0xEA:
                    this._0xEA();
                    break;
                case 0xEE:
                    this._0xEE();
                    break;
                case 0xEF:
                    this._0xEF();
                    break;
                case 0xF0:
                    this._0xF0();
                    break;
                case 0xF1:
                    this._0xF1();
                    break;
                case 0xF2:
                    this._0xF2();
                    break;
                case 0xF3:
                    this._0xF3();
                    break;
                case 0xF5:
                    this._0xF5();
                    break;
                case 0xF6:
                    this._0xF6();
                    break;
                case 0xF7:
                    this._0xF7();
                    break;
                case 0xF8:
                    this._0xF8();
                    break;
                case 0xF9:
                    this._0xF9();
                    break;
                default:
                    new Exception("Yo shit broke");
                    break;
            }
        }


        //shortcut flag methods 
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



        //cpu 8 bit instructions 
        private void _0x00()
        {

        }
        private void _0x10()
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
        { }
        private void _0x98()
        {

        }
        private void _0xA8()
        {

        }
        private void _0xB8()
        {

        }
        private void _0xC8()
        {

        }
        private void _0xD8()
        {

        }
        private void _0xE8()
        {

        }
        private void _0xF8()
        {

        }
        private void _0x09()
        {

        }
        private void _0x19()
        {

        }
        private void _0x29()
        {

        }
        private void _0x39()
        {

        }
        private void _0x49()
        {

        }
        private void _0x59()
        {

        }
        private void _0x69()
        {

        }
        private void _0x79()
        {

        }
        private void _0x89()
        {

        }
        private void _0x99()
        {

        }
        private void _0xA9()
        {

        }
        private void _0xB9()
        {

        }
        private void _0xC9()
        {

        }
        private void _0xD9()
        {

        }
        private void _0xE9()
        {

        }
        private void _0xF9()
        {

        }
        private void _0x0A()
        {

        }
        private void _0x1A()
        {

        }
        private void _0x2A()
        {

        }
        private void _0x3A()
        {

        }
        private void _0x4A()
        {

        }
        private void _0x5A()
        {

        }
        private void _0x6A()
        {

        }
        private void _0x7A()
        {

        }
        private void _0x8A()
        {

        }
        private void _0x9A()
        {

        }
        private void _0xAA()
        {

        }
        private void _0xBA()
        {

        }
        private void _0xCA()
        {

        }
        private void _0xDA()
        {

        }
        private void _0xEA()
        {

        }
        private void _0xFA()
        {

        }
        private void _0x0B()
        {

        }
        private void _0x1B()
        {

        }
        private void _0x2B()
        {

        }
        private void _0x3B()
        {

        }
        private void _0x4B()
        {

        }
        private void _0x5B()
        {

        }
        private void _0x6B()
        {

        }
        private void _0x7B()
        {

        }
        private void _0x8B()
        {

        }
        private void _0x9B()
        {

        }
        private void _0xAB()
        {

        }
        private void _0xBB()
        {

        }
        private void _0xFB()
        {

        }
        private void _0x0C()
        {

        }
        private void _0x1C()
        {

        }
        private void _0x2C()
        {

        }
        private void _0x3C()
        {

        }
        private void _0x4C()
        {

        }
        private void _0x5C()
        {

        }
        private void _0x6C()
        {

        }
        private void _0x7C()
        {

        }
        private void _0x8C()
        {

        }
        private void _0x9C()
        {

        }
        private void _0xAC()
        {

        }
        private void _0xBC()
        {

        }
        private void _0xCC()
        {

        }
        private void _0xDC()
        {

        }
        private void _0x0D()
        {

        }
        private void _0x1D()
        {

        }
        private void _0x2D()
        {

        }
        private void _0x3D()
        {

        }
        private void _0x4D()
        {

        }
        private void _0x5D()
        {

        }
        private void _0x6D()
        {

        }
        private void _0x7D()
        {

        }
        private void _0x8D()
        {

        }
        private void _0x9D()
        {

        }
        private void _0xAD()
        {

        }
        private void _0xBD()
        {

        }
        private void _0xCD()
        {

        }
        private void _0x0E()
        {

        }
        private void _0x1E()
        {

        }
        private void _0x2E()
        {

        }
        private void _0x3E()
        {

        }
        private void _0x4E()
        {

        }
        private void _0x5E()
        {

        }
        private void _0x6E()
        {

        }
        private void _0x7E()
        {

        }
        private void _0x8E()
        {

        }
        private void _0x9E()
        {

        }
        private void _0xAE()
        {

        }
        private void _0xBE()
        {

        }
        private void _0xCE()
        {

        }
        private void _0xDE()
        {

        }
        private void _0xEE()
        {

        }
        private void _0xFE()
        {

        }
        private void _0x0F()
        {

        }
        private void _0x1F()
        {

        }
        private void _0x2F()
        {

        }
        private void _0x3F()
        {

        }
        private void _0x4F()
        {

        }
        private void _0x5F()
        {

        }
        private void _0x6F()
        {

        }
        private void _0x7F()
        {

        }
        private void _0x8F()
        {

        }
        private void _0x9F()
        {

        }
        private void _0xAF()
        {

        }
        private void _0xBF()
        {

        }
        private void _0xCF()
        {

        }
        private void _0xDF()
        {

        }
        private void _0xEF()
        {

        }
        private void _0xFF()
        {

        }


    }
}

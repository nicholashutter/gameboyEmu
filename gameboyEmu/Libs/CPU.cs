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
        protected byte opcode { get; set; }
        //current working operands
        protected byte operand { get; set; }
        

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
            fetchOpCode, fetchExtendedOpCode, fetchOperand, running, interruptRequestReadInteruptFlag, interruptRequestReadInteruptEnabled,
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
            this.opcode = 0x00;
            
            this.operand = 0x00;

            this.state = CPUState.stopped;

            this.ram = ram; 
        }

        public void runCPU()
        {

            while (this.isRunning)
            {

                //fetch 

                //execute

            }
        }

        private void fetch()
        {
            // update cpu state 
            this.state = CPUState.fetchOpCode;
            // get next instruction (entire 8 bit word) from memory
            //ushort instruction = this.ram.getInstruction(); 
            ushort instruction = this.ram.getInstruction(this.PC);
            // decode 8 or 16 bit, split into opcode and operand
            char[] cInstruction = new char[instruction];
            for (int i = 0; instruction > 0; i++)
            {
                int digit = instruction % 10; 
                cInstruction[i] = (char)digit;
                instruction /= 10;
            }
            // if Convert.toHex((cInstruction[location 0 - 7])) == "0xCB"
            //      set some flag that we are operating on 16 bit instruction
            // this.opcode = Convert.toHex((cInstruction[location 0 - 3]))
            // this.operand = Convert.toHex((cInstruction[location 4 - 7]))
            //      update class members
        }

        private void execute(string word)
        {
            // update cpu state
            // refer to class members 
            // take operation and operand and get hashmap 
            // optimize later and replace full iteration with binary search or similar
            // dictionary will pair asm instruction with funciton implementation call 
            //

            if (this.opcode == 0xCB)
            {

            }


            /*
            switch (instruction.ToLower())
            {
                case "00000000":
                    //nop
                    break;
                case "00":
                    //
            }
            */ 
        }

        public void stopCPU()
        {

        }

        public void resetState()
        {

        }

        /* 
         * 
         * 
         * functions to represent operations
         * 
         
         */
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

        private void ADCA_value_n8()
        {
            /*
             
                ADC A,n8

                Add the value n8 plus the carry flag to A.

                Cycles: 2

                Bytes: 2

                Flags: See ADC A,r8

             
             */
        }

        private void ADDA_value_r8()
        {
            /*
             
                ADC A,n8

                Add the value n8 plus the carry flag to A.

                Cycles: 2

                Bytes: 2

                Flags: See ADC A,r8

             
             */
        }

        private void ADDA_ptr_HL()
        {
            /*
             
                Add the byte pointed to by HL to A.

                    Cycles: 2

                    Bytes: 1

                    Flags: See ADD A,r8

             
             */
        }

        private void ADDA_value_n8()
        {
            /*
             
                Add the value n8 to A.

                Cycles: 2

                Bytes: 2

                Flags: See ADD A,r8
             
             */
        }

        private void ADDHL_value_r16()
        {
            /*
             
                Add the value in r16 to HL.

                Cycles: 2

                Bytes: 1

                Flags:

                N
                    0
                H
                    Set if overflow from bit 11.
                C
                    Set if overflow from bit 15. 
             
             */
        }

        private void ADDHL_value_SP()
        {
            /*
             
                
                ADD HL,SP

                Add the value in SP to HL.

                Cycles: 2

                Bytes: 1

                Flags: See ADD HL,r16

             
             */
        }

        private void ADDSP_value_e8()
        {
            /*
             
                
                Add the signed value e8 to SP.

                Cycles: 4

                Bytes: 2

                Flags:

                Z
                    0
                N
                    0
                H
                    Set if overflow from bit 3.
                C
                    Set if overflow from bit 7. 

             
             */
        }

        private void ANDA_value_r8()
        {
            /*
             
                
                Set A to the bitwise AND between the value in r8 and A.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    1
                C
                    0 

             
             */
        }

        private void ANDA_ptr_HL()
        {
            /*
             
               Set A to the bitwise AND between the byte pointed to by HL and A.

                Cycles: 2

                Bytes: 1

                Flags: See AND A,r8

             
             */
        }

        private void ANDA_value_n8()
        {
            /*
             
               Set A to the bitwise AND between the value n8 and A.

                Cycles: 2

                Bytes: 2

                Flags: See AND A,r8

             
             */
        }

        private void BITu3_value_r8()
        {
            /*
             
             Test bit u3 in register r8, set the zero flag if bit not set.

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if the selected bit is 0.
                N
                    0
                H
                    1 
             
             */
        }

        private void BITu3_prt_HL()
        {
            /*
             
             Test bit u3 in the byte pointed by HL, set the zero flag if bit not set.

                Cycles: 3

                Bytes: 2

                Flags: See BIT u3,r8
             
             */
        }

        private void CALLn16()
        {
            /*
             
                 Call address n16.

                    This pushes the address of the instruction after the CALL on the stack, such that RET can pop it later; then, it executes an implicit JP n16.

                    Cycles: 6

                    Bytes: 3

                    Flags: None affected.
             
             */
        }

        private void CALLn16_if_cc()
        {
            /*
             
                 Call address n16 if condition cc is met.

                    Cycles: 6 taken / 3 untaken

                    Bytes: 3

                    Flags: None affected.
             
             */
        }

        private void CCF()
        {
            /*
             
                 Complement Carry Flag.

                    Cycles: 1

                    Bytes: 1

                    Flags:

                    N
                        0
                    H
                        0
                    C
                        Inverted. 
             
             */
        }

        private void CPA_value_r8()
        {
            /*
             
                 ComPare the value in A with the value in r8.

                    This subtracts the value in r8 from A and sets flags accordingly, but discards the result.

                    Cycles: 1

                    Bytes: 1

                    Flags:

                    Z
                        Set if result is 0.
                    N
                        1
                    H
                        Set if borrow from bit 4.
                    C
                        Set if borrow (i.e. if r8 > A). 
             
             */
        }

        private void CPA_ptr_HL()
        {
            /*
             
                 ComPare the value in A with the byte pointed to by HL.

                    This subtracts the byte pointed to by HL from A and sets flags accordingly, but discards the result.

                    Cycles: 2

                    Bytes: 1

                    Flags: See CP A,r8
             
             */
        }

        private void CPA_value_n8()
        {
            /*
             
                 ComPare the value in A with the value n8.

                    This subtracts the value n8 from A and sets flags accordingly, but discards the result.

                    Cycles: 2

                    Bytes: 2

                    Flags: See CP A,r8
             
             */
        }

        private void CPL()
        {
            /*
             
                ComPLement accumulator (A = ~A); also called bitwise NOT.

                Cycles: 1

                Bytes: 1

                Flags:

                N
                    1
                H
                    1 
             
             */
        }

        private void DAA()
        {
            /*
             
               Decimal Adjust Accumulator.

                Designed to be used after performing an arithmetic instruction (ADD, ADC, SUB, SBC) whose inputs were in Binary-Coded Decimal (BCD), adjusting the result to likewise be in BCD.

                The exact behavior of this instruction depends on the state of the subtract flag N:

                If the subtract flag N is set:

                        Initialize the adjustment to 0.
                        If the half-carry flag H is set, then add $6 to the adjustment.
                        If the carry flag is set, then add $60 to the adjustment.
                        Subtract the adjustment from A.
                        Set the carry flag if borrow (i.e. if adjustment > A).

                If the subtract flag N is not set:

                        Initialize the adjustment to 0.
                        If the half-carry flag H is set or A & $F > $9, then add $6 to the adjustment.
                        If the carry flag is set or A > $9F, then add $60 to the adjustment.
                        Add the adjustment to A.
                        Set the carry flag if overflow from bit 7.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                H
                    0
                C
                    Set or reset depending on the operation. 
             
             */
        }

        private void DEC_value_r8()
        {
            /*
             
              Decrement the value in register r8 by 1.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    1
                H
                    Set if borrow from bit 4. 
             
             */
        }

        private void DEC_ptr_r16()
        {
            /*
                Decrement the value in register r16 by 1.

                    Cycles: 2

                    Bytes: 1

                    Flags: None affected.
             
             */
        }

        private void DEC_value_SP()
        {
            /*
                Decrement the value in register SP by 1.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void DI()
        {
            /*
                Disable Interrupts by clearing the IME flag.

                Cycles: 1

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void EI()
        {
            /*
                Disable Interrupts by clearing the IME flag.

                Cycles: 1

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void HALT()
        {
            /*
                Enter CPU low-power consumption mode until an interrupt occurs.

                The exact behavior of this instruction depends on the state of the IME flag, and whether interrupts are pending (i.e. whether ‘[IE] & [IF]’ is non-zero):

                If the IME flag is set:
                    The CPU enters low-power mode until after an interrupt is about to be serviced. The handler is executed normally, and the CPU resumes execution after the HALT when that returns.
                If the IME flag is not set, and no interrupts are pending:
                    As soon as an interrupt becomes pending, the CPU resumes execution. This is like the above, except that the handler is not called.
                If the IME flag is not set, and some interrupt is pending:
                    The CPU continues execution after the HALT, but the byte after it is read twice in a row (PC is not incremented, due to a hardware bug).

                Cycles: -

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void INC_value_r8()
        {
            /*
                Increment the value in register r8 by 1.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    Set if overflow from bit 3. 
             
             */
        }

        private void INC_ptr_HL()
        {
            /*
                Increment the byte pointed to by HL by 1.

                Cycles: 3

                Bytes: 1

                Flags: See INC r8
             
             */
        }

        private void INC_value_r16()
        {
            /*
                Increment the value in register r16 by 1.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void INC_value_SP()
        {
            /*
                Increment the value in register SP by 1.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void JPn16()
        {
            /*
                Jump to address n16; effectively, copy n16 into PC.

                Cycles: 4

                Bytes: 3

                Flags: None affected.
             
             */
        }

        private void JPn16_if_cc()
        {
            /*
                Jump to address n16 if condition cc is met.

                Cycles: 4 taken / 3 untaken

                Bytes: 3

                Flags: None affected.
             
             */
        }

        private void JPHL()
        {
            /*
                Jump to address in HL; effectively, copy the value in register HL into PC.

                Cycles: 1

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void JRn16()
        {
            /*
                Relative Jump to address n16.

                The address is encoded as a signed 8-bit offset from the address immediately following the JR instruction, so the target address n16 must be between -128 and 127 bytes away. For example:

                    JR Label  ; no-op; encoded offset of 0
                Label:
                    JR Label  ; infinite loop; encoded offset of -2

                Cycles: 3

                Bytes: 2

                Flags: None affected.
             
             */
        }

        private void JRn16_if_cc()
        {
            /*
                Relative Jump to address n16 if condition cc is met.

                Cycles: 3 taken / 2 untaken

                Bytes: 2

                Flags: None affected.
             
             */
        }

        private void LDr8_value_r8()
        {
            /*
                Copy (aka Load) the value in register on the right into the register on the left.

                Storing a register into itself is a no-op; however, some Game Boy emulators interpret LD B,B as a breakpoint, or LD D,D as a debug message (such as BGB).

                Cycles: 1

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void LDr8_value_n8()
        {
            /*
               Copy the value n8 into register r8.

                Cycles: 2

                Bytes: 2

                Flags: None affected.
             
             */
        }

        private void LDr16_value_n16()
        {
            /*
               Copy the value n16 into register r16.

                Cycles: 3

                Bytes: 3

                Flags: None affected.
             
             */
        }

        private void LDHL_ptr_r8()
        {
            /*
               Copy the value in register r8 into the byte pointed to by HL.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void LDHL_ptr_n8()
        {
            /*
               Copy the value n8 into the byte pointed to by HL.

                Cycles: 3

                Bytes: 2

                Flags: None affected.
             
             */
        }

        private void LDr8_ptr_HL()
        {
            /*
               Copy the value pointed to by HL into register r8.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void LDr16_ptr_A()
        {
            /*
               Copy the value in register A into the byte pointed to by r16.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void LDn16_ptr_A()
        {
            /*
               Copy the value in register A into the byte at address n16.

                Cycles: 4

                Bytes: 3

                Flags: None affected.
             
             */
        }

        private void LDHn16_ptr_A()
        {
            /*
               Copy the value in register A into the byte at address n16, provided the address is between $FF00 and $FFFF.

                Cycles: 3

                Bytes: 2

                Flags: None affected.
             
             */
        }

        private void LDHC_ptr_A()
        {
            /*
               Copy the value in register A into the byte at address $FF00+C.

                Cycles: 2

                Bytes: 1

                Flags: None affected.

                This is sometimes written as ‘LD [$FF00+C],A’.
             
             */
        }

        private void LDA_ptr_r16()
        {
            /*
               Copy the byte pointed to by r16 into register A.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             
             */
        }

        private void LDA_ptr_n16()
        {
            /*
               Copy the byte at address n16 into register A.

                Cycles: 4

                Bytes: 3

                Flags: None affected.
             
             */
        }

        private void LDHA_ptr_n16()
        {
            /*
              Copy the byte at address n16 into register A, provided the address is between $FF00 and $FFFF.

                Cycles: 3

                Bytes: 2

                Flags: None affected.
             
             */
        }

        private void LDHA_ptr_C()
        {
            /*
             Copy the byte at address $FF00+C into register A.

                Cycles: 2

                Bytes: 1

                Flags: None affected.

                This is sometimes written as ‘LD A,[$FF00+C]’.
             */
        }

        private void LDHLI_ptr_A()
        {
            /*
             Copy the value in register A into the byte pointed by HL and increment HL afterwards.

                Cycles: 2

                Bytes: 1

                Flags: None affected.

                This is sometimes written as ‘LD [HL+],A’, or ‘LDI [HL],A’..
             */
        }

        private void LDHLD_ptr_A()
        {
            /*
             Copy the value in register A into the byte pointed by HL and decrement HL afterwards.

                Cycles: 2

                Bytes: 1

                Flags: None affected.

                This is sometimes written as ‘LD [HL-],A’, or ‘LDD [HL],A’.
             */
        }

        private void LDA_ptr_HLD()
        {
            /*
             Copy the byte pointed to by HL into register A, and decrement HL afterwards.

                Cycles: 2

                Bytes: 1

                Flags: None affected.

                This is sometimes written as ‘LD A,[HL-]’, or ‘LDD A,[HL]’.
             */
        }

        private void LDA_ptr_HLI()
        {
            /*
             Copy the byte pointed to by HL into register A, and increment HL afterwards.

                Cycles: 2

                Bytes: 1

                Flags: None affected.

                This is sometimes written as ‘LD A,[HL+]’, or ‘LDI A,[HL]’.
             */
        }

        private void LDSP_value_n16()
        {
            /*
                Copy the value n16 into register SP.

                Cycles: 3

                Bytes: 3

                Flags: None affected.
             */
        }

        private void LDn16_SP()
        {
            /*
                Copy SP & $FF at address n16 and SP >> 8 at address n16 + 1.

                Cycles: 5

                Bytes: 3

                Flags: None affected.
             */


        }


        private void LDHLSP_signed_e8()
        {
            /*
                Add the signed value e8 to SP and copy the result in HL.

                Cycles: 3

                Bytes: 2

                Flags:

                Z
                    0
                N
                    0
                H
                    Set if overflow from bit 3.
                C
                    Set if overflow from bit 7. 
             */
        }


        private void LDSP_HL()
        {
            /*
               Copy register HL into register SP.

                Cycles: 2

                Bytes: 1

                Flags: None affected.
             */
        }

        private void NOP()
        {
            /*
               No OPeration.

                Cycles: 1

                Bytes: 1

                Flags: None affected.
             */
        }
        private void ORA_value_r8()
        {
            /*
               Set A to the bitwise OR between the value in r8 and A.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    0 
             */
        }

        private void ORA_ptr_HL()
        {
            /*
               Set A to the bitwise OR between the byte pointed to by HL and A.

                Cycles: 2

                Bytes: 1

                Flags: See OR A,r8
             */
        }


        private void ORA_value_n8()
        {
            /*
               Set A to the bitwise OR between the byte pointed to by HL and A.

                Cycles: 2

                Bytes: 1

                Flags: See OR A,r8
             */
        }
        private void POP_AF()
        {
            /*
               Pop register AF from the stack. This is roughly equivalent to the following imaginary instructions:

                    LD F, [SP]  ; See below for individual flags
                    INC SP
                    LD A, [SP]
                    INC SP

                Cycles: 3

                Bytes: 1

                Flags:

                Z
                    Set from bit 7 of the popped low byte.
                N
                    Set from bit 6 of the popped low byte.
                H
                    Set from bit 5 of the popped low byte.
                C
                    Set from bit 4 of the popped low byte. 
             */
        }

        private void POP_r16()
        {
            /*
               Pop register r16 from the stack. This is roughly equivalent to the following imaginary instructions:

                    LD LOW(r16), [SP]   ; C, E or L
                    INC SP
                    LD HIGH(r16), [SP]  ; B, D or H
                    INC SP

                Cycles: 3

                Bytes: 1

                Flags: None affected.
             */
        }

        private void PUSH_AF()
        {
            /*
               Push register AF into the stack. This is roughly equivalent to the following imaginary instructions:

                    DEC SP
                    LD [SP], A
                    DEC SP
                    LD [SP], F.Z << 7 | F.N << 6 | F.H << 5 | F.C << 4

                Cycles: 4

                Bytes: 1

                Flags: None affected.
             */
        }

        private void PUSH_r16()
        {
            /*
               Push register r16 into the stack. This is roughly equivalent to the following imaginary instructions:

                    DEC SP
                    LD [SP], HIGH(r16)  ; B, D or H
                    DEC SP
                    LD [SP], LOW(r16)   ; C, E or L

                Cycles: 4

                Bytes: 1

                Flags: None affected.
             */
        }

        private void RESu3_r8()
        {
            /*
               Set bit u3 in register r8 to 0. Bit 0 is the rightmost one, bit 7 the leftmost one.

                    Cycles: 2

                    Bytes: 2

                    Flags: None affected.
             */
        }

        private void RESu3_ptr_HL()
        {
            /*
               Set bit u3 in the byte pointed by HL to 0. Bit 0 is the rightmost one, bit 7 the leftmost one.

                Cycles: 4

                Bytes: 2

                Flags: None affected.
             */
        }

        private void RET()
        {
            /*
               Return from subroutine. This is basically a POP PC (if such an instruction existed). See POP r16 for an explanation of how POP works.

                Cycles: 4

                Bytes: 1

                Flags: None affected.
             */
        }

        private void RET_if_cc()
        {
            /*
               Return from subroutine if condition cc is met.

                Cycles: 5 taken / 2 untaken

                Bytes: 1

                Flags: None affected.
             */
        }

        private void RETI()
        {
            /*
               Return from subroutine and enable interrupts. This is basically equivalent to executing EI then RET, meaning that IME is set right after this instruction.

                Cycles: 4

                Bytes: 1

                Flags: None affected.
             */
        }

        private void RLr8()
        {
            /*
               Rotate bits in register r8 left, through the carry flag.

                    Cycles: 2

                    Bytes: 2

                    Flags:

                    Z
                        Set if result is 0.
                    N
                        0
                    H
                        0
                    C
                        Set according to result. 
             */
        }

        private void RL_ptr_HL()
        {
            /*
               Rotate the byte pointed to by HL left, through the carry flag.

                  ┏━ Flags ━┓ ┏━━━━━━ [HL] ━━━━━┓
                ┌─╂─   C   ←╂─╂─ b7 ← ... ← b0 ←╂─┐
                │ ┗━━━━━━━━━┛ ┗━━━━━━━━━━━━━━━━━┛ │
                └─────────────────────────────────┘

                Cycles: 4

                Bytes: 2

                Flags: See RL r8
             */
        }

        private void RLA()
        {
            /*
               Rotate register A left, through the carry flag.

                  ┏━ Flags ━┓ ┏━━━━━━━ A ━━━━━━━┓
                ┌─╂─   C   ←╂─╂─ b7 ← ... ← b0 ←╂─┐
                │ ┗━━━━━━━━━┛ ┗━━━━━━━━━━━━━━━━━┛ │
                └─────────────────────────────────┘

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    0
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RLCr8()
        {
            /*
               Rotate register r8 left.

                ┏━ Flags ━┓   ┏━━━━━━━ r8 ━━━━━━┓
                ┃    C   ←╂─┬─╂─ b7 ← ... ← b0 ←╂─┐
                ┗━━━━━━━━━┛ │ ┗━━━━━━━━━━━━━━━━━┛ │
                            └─────────────────────┘

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RLC_ptr_HL()
        {
            /*
               Rotate the byte pointed to by HL left.

                ┏━ Flags ━┓   ┏━━━━━━ [HL] ━━━━━┓
                ┃    C   ←╂─┬─╂─ b7 ← ... ← b0 ←╂─┐
                ┗━━━━━━━━━┛ │ ┗━━━━━━━━━━━━━━━━━┛ │
                            └─────────────────────┘

                Cycles: 4

                Bytes: 2

                Flags: See RLC r8
             */
        }

        private void RLCA()
        {
            /*
               Rotate register A left.

                ┏━ Flags ━┓   ┏━━━━━━━ A ━━━━━━━┓
                ┃    C   ←╂─┬─╂─ b7 ← ... ← b0 ←╂─┐
                ┗━━━━━━━━━┛ │ ┗━━━━━━━━━━━━━━━━━┛ │
                            └─────────────────────┘

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    0
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RRr8()
        {
            /*
               Rotate register r8 right, through the carry flag.

                  ┏━━━━━━━ r8 ━━━━━━┓ ┏━ Flags ━┓
                ┌─╂→ b7 → ... → b0 ─╂─╂→   C   ─╂─┐
                │ ┗━━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛ │
                └─────────────────────────────────┘

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RR_ptr_HL()
        {
            /*
               Rotate the byte pointed to by HL right, through the carry flag.

                  ┏━━━━━━ [HL] ━━━━━┓ ┏━ Flags ━┓
                ┌─╂→ b7 → ... → b0 ─╂─╂→   C   ─╂─┐
                │ ┗━━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛ │
                └─────────────────────────────────┘

                Cycles: 4

                Bytes: 2

                Flags: See RR r8
             */
        }

        private void RRA()
        {
            /*
               Rotate register A right, through the carry flag.

                  ┏━━━━━━━ A ━━━━━━━┓ ┏━ Flags ━┓
                ┌─╂→ b7 → ... → b0 ─╂─╂→   C   ─╂─┐
                │ ┗━━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛ │
                └─────────────────────────────────┘

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    0
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RRCr8()
        {
            /*
               Rotate register A right, through the carry flag.

                  ┏━━━━━━━ A ━━━━━━━┓ ┏━ Flags ━┓
                ┌─╂→ b7 → ... → b0 ─╂─╂→   C   ─╂─┐
                │ ┗━━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛ │
                └─────────────────────────────────┘

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    0
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RRC_ptr_HL()
        {
            /*
               Rotate the byte pointed to by HL right.

                  ┏━━━━━━ [HL] ━━━━━┓   ┏━ Flags ━┓
                ┌─╂→ b7 → ... → b0 ─╂─┬─╂→   C    ┃
                │ ┗━━━━━━━━━━━━━━━━━┛ │ ┗━━━━━━━━━┛
                └─────────────────────┘

                Cycles: 4

                Bytes: 2

                Flags: See RRC r8
             */
        }

        private void RRCA()
        {
            /*
               Rotate register A right.

                  ┏━━━━━━━ A ━━━━━━━┓   ┏━ Flags ━┓
                ┌─╂→ b7 → ... → b0 ─╂─┬─╂→   C    ┃
                │ ┗━━━━━━━━━━━━━━━━━┛ │ ┗━━━━━━━━━┛
                └─────────────────────┘

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    0
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void RSTvec()
        {
            /*
               Call address vec. This is a shorter and faster equivalent to CALL for suitable values of vec.

                Cycles: 4

                Bytes: 1

                Flags: None affected.
             */
        }

        private void SBCA_value_A()
        {
            /*
               Subtract the value in r8 and the carry flag from A.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    1
                H
                    Set if borrow from bit 4.
                C
                    Set if borrow (i.e. if (r8 + carry) > A). 
             */
        }

        private void SBCA_prt_HL()
        {
            /*
               Subtract the byte pointed to by HL and the carry flag from A.

                    Cycles: 2

                    Bytes: 1

                    Flags: See SBC A,r8
             */
        }

        private void SBCA_value_n8()
        {
            /*
               Subtract the value n8 and the carry flag from A.

                Cycles: 2

                Bytes: 2

                Flags: See SBC A,r8
             */
        }

        private void SCF()
        {
            /*
               Set Carry Flag.

                Cycles: 1

                Bytes: 1

                Flags:

                N
                    0
                H
                    0
                C
    1 
             */
        }

        private void SETu3_r8()
        {
            /*
               Set bit u3 in register r8 to 1. Bit 0 is the rightmost one, bit 7 the leftmost one.

                Cycles: 2

                Bytes: 2

                Flags: None affected.
    1 
             */
        }

        private void SETu3_ptr_HL()
        {
            /*
               Set bit u3 in the byte pointed by HL to 1. Bit 0 is the rightmost one, bit 7 the leftmost one.

                Cycles: 4

                Bytes: 2

                Flags: None affected.
    1 
             */
        }

        private void SLAr8()
        {
            /*
               Shift Left Arithmetically register r8.

                ┏━ Flags ━┓ ┏━━━━━━━ r8 ━━━━━━┓
                ┃    C   ←╂─╂─ b7 ← ... ← b0 ←╂─ 0
                ┗━━━━━━━━━┛ ┗━━━━━━━━━━━━━━━━━┛

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    Set according to result. 
                    1 
             */
        }

        private void SLA_ptr_HL()
        {
            /*
               Shift Left Arithmetically the byte pointed to by HL.

                ┏━ Flags ━┓ ┏━━━━━━ [HL] ━━━━━┓
                ┃    C   ←╂─╂─ b7 ← ... ← b0 ←╂─ 0
                ┗━━━━━━━━━┛ ┗━━━━━━━━━━━━━━━━━┛

                Cycles: 4

                Bytes: 2

                Flags: See SLA r8
             */
        }

        private void SRAr8()
        {
            /*
               Shift Right Arithmetically register r8 (bit 7 of r8 is unchanged).

                ┏━━━━━━ r8 ━━━━━━┓ ┏━ Flags ━┓
                ┃ b7 → ... → b0 ─╂─╂→   C    ┃
                ┗━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void SRA_ptr_HL()
        {
            /*
               Shift Right Arithmetically the byte pointed to by HL (bit 7 of the byte pointed to by HL is unchanged).

                ┏━━━━━ [HL] ━━━━━┓ ┏━ Flags ━┓
                ┃ b7 → ... → b0 ─╂─╂→   C    ┃
                ┗━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛

                Cycles: 4

                Bytes: 2

                Flags: See SRA r8 
             */
        }

        private void SRLr8()
        {
            /*
               Shift Right Logically register r8.

                   ┏━━━━━━━ r8 ━━━━━━┓ ┏━ Flags ━┓
                0 ─╂→ b7 → ... → b0 ─╂─╂→   C    ┃
                   ┗━━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    Set according to result. 
             */
        }

        private void SRL_ptr_HL()
        {
            /*
               Shift Right Logically the byte pointed to by HL.

                   ┏━━━━━━ [HL] ━━━━━┓ ┏━ Flags ━┓
                0 ─╂→ b7 → ... → b0 ─╂─╂→   C    ┃
                   ┗━━━━━━━━━━━━━━━━━┛ ┗━━━━━━━━━┛

                Cycles: 4

                Bytes: 2

                Flags: See SRL r8 
             */
        }

        private void STOP()
        {
            /*
               Enter CPU very low power mode. Also used to switch between GBC double speed and normal speed CPU modes.

                The exact behavior of this instruction is fragile and may interpret its second byte as a separate instruction (see the Pan Docs), which is why rgbasm(1) allows explicitly specifying the second byte (STOP n8) to override the default of $00 (a NOP instruction).

                Cycles: -

                Bytes: 2

                Flags: None affected. 
             */
        }

        private void SUBA_value_r8()
        {
            /*
              Subtract the value in r8 from A.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    1
                H
                    Set if borrow from bit 4.
                C
                    Set if borrow (i.e. if r8 > A).  
             */
        }

        private void SUBA_ptr_HL()
        {
            /*
              Subtract the byte pointed to by HL from A.

                Cycles: 2

                Bytes: 1

                Flags: See SUB A,r8
             */
        }

        private void SUBA_value_n8()
        {
            /*
              Subtract the value n8 from A.

                Cycles: 2

                Bytes: 2

                Flags: See SUB A,r8
             */
        }

        private void SWAPr8()
        {
            /*
              Swap the upper 4 bits in register r8 and the lower 4 ones.

                Cycles: 2

                Bytes: 2

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    0 
             */
        }

        private void SWAP_ptr_HL()
        {
            /*
              Swap the upper 4 bits in the byte pointed by HL and the lower 4 ones.

                Cycles: 4

                Bytes: 2

                Flags: See SWAP r8
             */
        }

        private void XORA_value_r8()
        {
            /*
              Set A to the bitwise XOR between the value in r8 and A.

                Cycles: 1

                Bytes: 1

                Flags:

                Z
                    Set if result is 0.
                N
                    0
                H
                    0
                C
                    0 
             */
        }

        private void XORA_ptr_HL()
        {
            /*
              Set A to the bitwise XOR between the byte pointed to by HL and A.

                Cycles: 2

                Bytes: 1

                Flags: See XOR A,r8
             */
        }

        private void XORA_value_n8()
        {
            /*
              Set A to the bitwise XOR between the value n8 and A.

                Cycles: 2

                Bytes: 2

                Flags: See XOR A,r8
             */
        }
    }
}


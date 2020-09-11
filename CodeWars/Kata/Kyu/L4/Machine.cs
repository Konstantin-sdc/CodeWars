namespace CodeWars.Kata.Kyu.L4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Machine
    {
        private static readonly char[] _commandSymbols = new char[] { 'a', 'b', 'c', 'd' };

        private Cpu _cpu;

        public Machine(Cpu cpu = null)
        {
            _cpu = cpu;
        }

        public void Exec(string op)
        {
            // Implement me!
            #region Instructions
            // Stack operations
            //push[reg | int]: Pushes a register[reg] or an immediate value[int] to the stack.
            //pop: Pops a value of the stack, discarding the value.
            //pop[reg]: Pops a value of the stack, into the given register[reg].
            //pushr: Pushes the general registers onto the stack, in order. (a, b, c, d)
            //pushrr: Pushes the general registers onto the stack, in reverse order. (d, c, b, a)
            //popr: Pops values off the stack, and loads them into the general registers, in order so that the two executions `pushr()` 
            //  and `popr()` would leave the registers unchanged.
            //poprr: Pops values off the stack, and loads them into the general registers, in order so that the two executions `pushr()` 
            //  and `poprr()` would invert the values of the registers from left to right.

            //mov[reg | int], [reg2]: Stores the value from[reg | int] into the register[reg2].

            // Arithmetic operations
            //add[reg | int]: Pops[reg | int] arguments off the stack, storing the sum in register a.
            //sub[reg | int]: Pops[reg | int] arguments off the stack, storing the difference in register a.
            //mul[reg | int]: Pops[reg | int] arguments off the stack, storing the product in register a.
            //div[reg | int]: Pops[reg | int] arguments off the stack, storing the quotient in register a.
            //and[reg | int]: Pops[reg | int] arguments off the stack, performing a bit-and operation, and storing the result in register a.
            //or[reg | int] : Pops[reg | int] arguments off the stack, performing a bit-or operation, and storing the result in register a.
            //xor[reg | int]: Pops[reg | int] arguments off the stack, performing a bit-xor operation, and storing the result in register a.

            // Variants for arithmetic operations.Examples for add
            //add 5: Adds the top 5 values of the stack, storing the result in register a.
            //add 5, b: Adds the top 5 values of the stack, storing the result in register b instead.
            //adda 5: Pushes the value of register A onto the stack, then adds the top 5 values of the stack, and stores the result in register a.
            //adda 5, b: Pushes the value of register A onto the stack, adds the top 5 values of the stack, and stores the result in register b.

            //mov 3, a: Stores the number 3 in register a.
            //add a: Adds the top a values of the stack(in this case 3), storing the result in register a.
            #endregion

            #region Operator variants

            #endregion
        }
    }

    public class Cpu : ICpu
    {
        public int PopStack() => throw new NotImplementedException();
        public void PrintStack() => throw new NotImplementedException();
        public int ReadReg(string name) => throw new NotImplementedException();
        public void WriteReg(string name, int value) => throw new NotImplementedException();
        public void WriteStack(int value) => throw new NotImplementedException();
    }

    internal interface ICpu
    {
        /// <summary>Returns the value of the named register.</summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int ReadReg(string name);

        /// <summary>Stores the value into the given register.</summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void WriteReg(string name, int value);

        /// <summary>Pops the top element of the stack, returning the value.</summary>
        /// <returns></returns>
        int PopStack();

        /// <summary>Pushes an element onto the stack.</summary>
        /// <param name="value"></param>
        void WriteStack(int value);

        /// <summary>Prints the contents of the stack to System.Console.</summary>
        void PrintStack();
    }
}

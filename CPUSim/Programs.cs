using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    internal class Programs
    {
        Logic _logic;

        internal Logic Logic
        {
            //For being able to check values in a Console.
            get { return _logic; }
        }
        internal Programs()
        {
            _logic = new Logic();
        }
        internal void TrySubtracting()
        {
            _logic = new Logic();
            List<string> instructions = new List<string>();
            //Setting up
            _logic.RAM[20] = 11;
            _logic.RAM[21] = 20;
            //The actual Program
            instructions.Add("010021");
            instructions.Add("030020");
            instructions.Add("060022");
            //instructions.Add("990000");
            //instruction "990000" shuts down the program,
            //so it's commented out in order to dispay the output below.

            //Instructions are set up as List<> of strings and passed on 
            //to _logic.runProgram() Method, in order to be executed.
            _logic.RunProgram(instructions);

            for (int i = 0; i < _logic.RAM.Length; i++)
            {
                
            Console.WriteLine($"Address {i.ToString("D2")}: {_logic.RAM[i].ToString("D6")}");
            }

            Console.WriteLine($"Result: {_logic.RAM[22]}");

        }

        internal void TrySubtractingAgain()
        {

        }
    }
}

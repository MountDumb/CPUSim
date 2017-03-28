using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSim
{
    internal enum OpCodes
    {
        LOAD = 01,
        ADD = 02,
        SUBTRACT = 03,
        DIVIDE = 04,
        MULTIPLY = 05,
        STORE = 06,
        JUMP = 07,
        TEST_ZERO = 08,
        TEST_GREATER_THAN = 09,
        STOP = 99

    }

    internal class Logic
    {
        //represents 40 RAM addresses
        uint[] _ram;

        uint _accumulator;
        uint _programCounter;
        OpCodes _command;

        #region Properties
        internal uint[] RAM
        {
            get { return _ram; }
            set { _ram = value; }
            
        }

        internal uint Accumulator
        {
            get { return _accumulator; }
        }
        #endregion

        internal Logic()
        {
            _ram = new uint[40];
            _accumulator = 0; 
            //_programCounter keeps track of the current step in a set of instructions.
            _programCounter = 0;
            
        }

        internal void RunProgram(List<string> instructions)
        {
            while (instructions.Count > _programCounter)
            {
                TakeCommand(instructions[(int)_programCounter]);
            }
            
        }

        private void TakeCommand(string inputString)
        {
            //Puts the instruction into memory, so it can be executed. _programCounter points to where the instruction is stored.
            _ram[_programCounter] = uint.Parse(inputString);

            _command = (OpCodes)(int.Parse(inputString.Substring(0, 2)));
            uint inputValue = uint.Parse(inputString.Substring(2));

            switch (_command)
            {
                case OpCodes.LOAD:
                    Load(inputValue);
                    break;
                case OpCodes.ADD:
                    Add(inputValue);
                    break;
                case OpCodes.SUBTRACT:
                    Subtract(inputValue);
                    break;
                case OpCodes.DIVIDE:
                    Divide(inputValue);
                    break;
                case OpCodes.MULTIPLY:
                    Multiply(inputValue);
                    break;
                case OpCodes.STORE:
                    Store(inputValue);
                    break;
                case OpCodes.JUMP:
                    Jump(inputValue);
                    break;
                case OpCodes.TEST_ZERO:
                    TestZero();
                    break;
                case OpCodes.TEST_GREATER_THAN:
                    TestGreaterThan(inputValue);
                    break;
                    
                case OpCodes.STOP:
                    Exit();
                    break;
                
            }
        }

        void Load(uint inputValue)
        {
            _accumulator = _ram[inputValue];
            _programCounter++;
        }

        void Add(uint inputValue)
        {
            _accumulator += _ram[inputValue];
            _programCounter++;
        }

        void Subtract(uint inputValue)
        {
            _accumulator -= _ram[inputValue];
            _programCounter++;
        }

        void Divide(uint inputValue)
        {
            _accumulator = _accumulator / _ram[inputValue];
            _programCounter++;
        }
        void Multiply(uint inputValue)
        {
            _accumulator = _accumulator * _ram[inputValue];
            _programCounter++;
        }

        void Store(uint inputValue)
        {
            _ram[inputValue] = _accumulator;
            _programCounter++;
        }

        void Jump(uint inputValue)
        {
            _programCounter = inputValue;
        }

        void TestZero()
        {
            if (_accumulator == 0)
            {
                _programCounter++;
            }
            else
            {
                _programCounter += 2;
            }
        }

        void TestGreaterThan(uint inputValue)
        {
            if (_accumulator.CompareTo(inputValue) == 1 || _accumulator.CompareTo(inputValue) == 1)
            {
                _programCounter++;
            }
            else
            {
                _programCounter += 2;
            }
        }
        void Exit()
        {
            Environment.Exit(0);
        }
    }
}

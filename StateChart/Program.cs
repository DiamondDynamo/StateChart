/// <summary>
/// Written by: Charley Bein
/// Date: 2018-03-04
/// Program Name: StateChart
/// Description: Take user input to move between states on the provided state chart, and display the movements with a time stamp
/// </summary>

using System;

namespace StateChart
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Take user input and pass it to the controller to move between states, as stored in the state variables
            /// </summary>
            Controller ctrl = new Controller();
            bool quit = false;
            while (!quit)
            {
                Console.Write("Choose an action (a, b, c, d, e, f, or q to quit): ");
                string input = Console.ReadLine();
                switch (input[0])
                {
                    case 'a':
                    case 'A':
                        ctrl.EventA();
                        break;
                    case 'b':
                    case 'B':
                        ctrl.EventB();
                        break;
                    case 'c':
                    case 'C':
                        ctrl.EventC();
                        break;
                    case 'd':
                    case 'D':
                        ctrl.EventD();
                        break;
                    case 'e':
                    case 'E':
                        ctrl.EventE();
                        break;
                    case 'f':
                    case 'F':
                        ctrl.EventF();
                        break;
                    case 'q':
                    case 'Q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Input was not a valid event: " + input);
                        break;
                }
            }
        }
    }

    class Controller
    {
        private int stateLevelA = 0;
        private int stateLevelB = 0;
        private int stateLevelC = 0;
        private int stateLevelD = 0;
        private int stateLevelE = 0;
        private int stateLevelF = 0;
        private int history = 0;

        public Controller()
        {
            stateLevelA = 1;
            stateLevelB = 4;
            history = stateLevelB;
            Console.WriteLine("Initializing statechart. Level A initialized to 1 and level B initialized to 4");
        }

        /// <summary>
        /// For each event, check if the current state has a valid transition with that event, and if it does, execute that transition
        /// </summary>
        public void EventA()
        {
            switch (stateLevelA)
            {
                case 1:
                    if (stateLevelB == 5)
                    {
                        stateLevelB = 4;
                        history = stateLevelB;
                        Console.WriteLine("Moving from state 5 to 4 at level B");
                        printTime();
                    }
                    break;
                case 2:
                    if(stateLevelC == 6)
                    {
                        if(stateLevelD == 9)
                        {
                            stateLevelD = 8;
                            Console.WriteLine("Moving from state 9 to 8 at level D");
                            printTime();
                        }
                        if(stateLevelF == 12)
                        {
                            stateLevelF = 13;
                            Console.WriteLine("Moving from state 12 to 13 at level F");
                            printTime();
                        }
                    }
                    break;
                case 3:
                default:
                    break;
            }
        }
        public void EventB()
        {
            switch (stateLevelA)
            {
                case 1:
                    if(stateLevelB == 4)
                    {
                        stateLevelB = 5;
                        history = stateLevelB;
                        Console.WriteLine("Moving from state 4 to 5 at level B");
                        printTime();
                    }
                    break;
                case 2:
                    if(stateLevelC == 6)
                    {
                        if(stateLevelD == 8)
                        {
                            stateLevelD = 9;
                            Console.WriteLine("Moving from 8 to 9 at level D");
                            printTime();
                        } else
                        {
                            Console.WriteLine("Invalid command for level D");
                            printTime();
                        }
                    } else if(stateLevelC == 7)
                    {
                        stateLevelA = 1;
                        stateLevelB = history;
                        Console.WriteLine("Moving from state 2 to 1 at level A, setting level A to the store state in history, {0}", history);
                        printTime();
                    }
                    break;
                case 3:
                default:
                    break;
            }
        }
        public void EventC()
        {
            switch (stateLevelA)
            {
                case 2:
                    if(stateLevelC == 6)
                    {
                        if (stateLevelE == 10)
                        {
                            stateLevelE = 11;
                            Console.WriteLine("Moving from state 10 to 11 at level E");
                            printTime();
                        } else if(stateLevelE == 11)
                        {
                            stateLevelE = 10;
                            Console.WriteLine("Moving from state 11 to 10 at level E");
                            printTime();
                        }
                        if(stateLevelF == 13)
                        {
                            stateLevelF = 12;
                            Console.WriteLine("Moving from state 13 to 12 at level F");
                            printTime();
                        }
                    }
                    break;
                case 1:
                case 3:
                default:
                    break;
            }
        }
        public void EventD()
        {
            switch (stateLevelA)
            {
                case 1:
                    stateLevelA = 3;
                    Console.WriteLine("Moving from state 1 to 3 at level A");
                    printTime();
                    break;
                case 2:
                    if(stateLevelC == 6)
                    {
                        stateLevelC = 7;
                        Console.WriteLine("Moving from state 6 to 7 at level C");
                        printTime();
                    }
                    break;
                case 3:
                default:
                    break;
            }
        }
        public void EventE()
        {
            switch (stateLevelA)
            {
                case 2:
                    if(stateLevelC == 7)
                    {
                        stateLevelC = 6;
                        stateLevelD = 9;
                        stateLevelE = 11;
                        stateLevelF = 13;
                        Console.WriteLine("Moving from state 7 to 8 at level C, setting inital states for levels D (9), E (11), and F (13)");
                        printTime();
                    }
                    break;
                case 3:
                    stateLevelA = 1;
                    stateLevelB = 5;
                    Console.WriteLine("Moving from state 3 to 1 at level A, and setting level B's state to 5");
                    printTime();
                    break;
                case 1:
                default:
                    break;
            }
        }
        public void EventF()
        {
            switch (stateLevelA)
            {
                case 1:
                    stateLevelA = 2;
                    stateLevelC = 7;
                    Console.WriteLine("Moving from state 1 to 2 at level A, and setting level C to its initial value, 7");
                    printTime();
                    break;
                case 2:
                case 3:
                default:
                    break;
            }
        }

        /// <summary>
        /// Print the current time and date
        /// </summary>
        private void printTime()
        {
            DateTime timer = DateTime.Now;
            string timeStamp = timer.ToString("s");
            Console.WriteLine(timeStamp);
            Console.WriteLine();
        }
    }
}

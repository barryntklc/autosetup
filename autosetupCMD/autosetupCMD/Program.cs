using System;
using System.Linq;

namespace autosetupCMD
{
    class Program
    {
        static bool DEBUG = false;

        static void Main(string[] args)
        {
            int oper = -1;
            while(oper != 6)
            {
                Console.Clear();

                if (DEBUG)
                {
                    Console.WriteLine();
                    Console.WriteLine("previous operation = [" + oper + "]");
                    Console.WriteLine();
                }

                oper = MainMenu();

                switch(oper)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
        }

        static Int32 MainMenu()
        {
            int oper = -1;
            while (oper == -1)
            {
                Console.Write(@"autosetup CMD console
What would you like to do?

    [1] Activate the local administrator account.
    [2] Change this computer's network settings.
    [3] Move a user's files to a separate drive.
    [4] Configure this computer from a JSON file.
    [5] Reimage this computer.
    [6] Exit.

");
                oper = GetIntKey();
            }
            return oper;
        }

        static void OptionActivateAdmin()
        {

        }

        static void OptionNetworkSetup()
        {

        }

        static String GetString()
        {
            Console.Write(": ");
            return Console.ReadLine();
        }

        static Int32 GetInt()
        {
            Console.Write(": ");
            String strbuffer = Console.ReadLine();
            if (strbuffer.All(char.IsDigit))
            {
                return Int32.Parse(strbuffer);
            } else
            {
                return -1;
            }
        }

        static Int32 GetIntKey()
        {
            Console.Write(": ");
            char charbuffer = Console.ReadKey().KeyChar;
            if (char.IsNumber(charbuffer))
            {
                return Int32.Parse(charbuffer.ToString());
            }
            else
            {
                return -1;
            }
        }

        static String[] GetIPDetails()
        {
            String[] buffer = new String[3];

            return buffer;
        }
    }
}

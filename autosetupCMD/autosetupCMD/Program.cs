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
            while(oper != 0)
            {
                Console.Clear();

                if (DEBUG)
                {
                    Console.WriteLine();
                    Console.WriteLine("previous operation = [" + oper + "]");
                    Console.WriteLine();
                }

                oper = MainMenu();
                Console.Clear();
                switch(oper)
                {
                    case 1:
                        OptionActivateAdmin();
                        break;
                    case 2:
                        OptionNetworkSetup();
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
    [3] Move a user's files to a separate drive. (Not Implemented)
    [4] Configure this computer from a JSON file. (Not Implemented)
    [5] Reimage this computer. (Not Implemented)
    [0] Exit.

");
                oper = GetIntKey();
            }
            return oper;
        }

        static void OptionActivateAdmin()
        {
            System.Diagnostics.Process.Start("CMD.exe", @"/C @echo off & echo Activating local administrator... & net user administrator /active:yes & pause");
        }

        static void OptionNetworkSetup()
        {
            String defaultzone = "128.171";
            String[] defaultdns = { "128.171.106.15", "128.171.107.11" };

            Console.WriteLine("Enter this computer's IP address");
            bool ipvalid = false;
            while (ipvalid == false)
            {
                String IPAddr = GetString();
                String[] defaults = GetDefaultIPs(defaultzone, IPAddr);
                if (!(defaults[0].Equals("0") || defaults[1].Equals("0") || defaults[2].Equals("0")))
                {
                    IPAddr = defaults[0];

                    String Subnet = "0";
                    bool SubnetValid = false;
                    while (SubnetValid == false)
                    {
                        Console.WriteLine("Enter this computer's Subnet address (" + defaults[1] + ")");
                        Subnet = GetString();
                        if (Subnet.Trim().Equals(""))
                        {
                            Subnet = defaults[1];
                            SubnetValid = true;
                        } else
                        {
                            Subnet = GetIP(defaultzone, Subnet); //TODO validate subnet separately
                            if (!Subnet.Equals("0"))
                            {
                                SubnetValid = true;
                            }else
                            {
                                Console.WriteLine("Subnet address is invalid.");
                            }
                        }
                    }

                    String Gateway = "0";
                    bool GatewayValid = false;
                    while (GatewayValid == false)
                    {
                        Console.WriteLine("Enter this computer's Gateway address (" + defaults[2] + ")");
                        Gateway = GetString();
                        if (Gateway.Trim().Equals(""))
                        {
                            Gateway = defaults[2];
                            GatewayValid = true;
                        }
                        else
                        {
                            Gateway = GetIP(defaultzone, Gateway);
                            if (!Gateway.Equals("0"))
                            {
                                GatewayValid = true;
                            } else
                            {
                                Console.WriteLine("Gateway address is invalid.");
                            }
                        }
                    }

                    Console.WriteLine("IPAddr: " + IPAddr);
                    Console.WriteLine("Subnet: " + Subnet);
                    Console.WriteLine("Gateway: " + Gateway);

                    //enter dns
                    Console.WriteLine("Are you sure you want to change your IP settings?");
                } else
                {
                    Console.WriteLine("Invalid IP settings.");
                }
            }
            
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

        static String GetIP(String Zone, String IP)
        {
            String IPBuffer = "0";
            bool valid = true;
            int periodnum = 0;
            foreach (char c in IP)
            {
                if (c == '.')
                {
                    periodnum++;
                }
            }
            //Console.WriteLine(periodnum);
            if (periodnum == 1 || periodnum == 3)
            {
                String[] sections = IP.Split('.');
                foreach (String s in sections)
                {
                    //Console.WriteLine("section: " + s + " ");
                    if (!s.All(char.IsDigit))
                    {
                        valid = false;
                    }
                }
                //Console.WriteLine(valid);
                if (valid == true)
                {
                    if (periodnum == 1)
                    {
                        IPBuffer = Zone + "." + sections[0] + "." + sections[1];
                    }
                    else if (periodnum == 3)
                    {
                        IPBuffer = IP;
                    }
                }
            }
            return IPBuffer;
        }

        static String[] GetDefaultIPs(String Zone, String IP)
        {
            String[] Buffer = new string[] { "0", "0", "0" };
            bool valid = true;
            int periodnum = 0;
            foreach (char c in IP)
            {
                if (c == '.')
                {
                    periodnum++;
                }
            }
            //Console.WriteLine(periodnum);
            if (periodnum == 1 || periodnum == 3)
            {
                String[] sections = IP.Split('.');
                foreach (String s in sections) {
                    //Console.WriteLine("section: " + s + " ");
                    if (!s.All(char.IsDigit))
                    {
                        valid = false;
                    }
                }
                //Console.WriteLine(valid);
                if (valid == true)
                {
                    Buffer = new string[3];
                    Buffer[1] = "255.255.255.0";
                    if (periodnum == 1)
                    {
                        Buffer[0] = Zone + "." + sections[0] + "." + sections[1];
                        Buffer[2] = Zone + "." + sections[0] + ".1";
                    } else if (periodnum == 3)
                    {
                        Buffer[0] = IP;
                        Buffer[2] = sections[0] + "." + sections[1] + "." + sections[2] + ".1";
                    }
                }
            }
            return Buffer;
        }

        static bool ValidIP(String IP)
        {
            String[] sections = IP.Split('.');
            foreach (String s in sections)
            {
                if (!s.All(char.IsDigit))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

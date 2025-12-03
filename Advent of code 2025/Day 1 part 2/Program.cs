using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1_part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FILEName = "Input.txt";
            StreamReader SR = new StreamReader(FILEName);
            string temp = SR.ReadToEnd();
            temp = temp.Replace("\r", "");
            string[] AllString = temp.Split('\n');
            int ValueofDial = 50;
            int Password = 0;
            foreach (string s in AllString)
            {
                string LorR = s.Substring(0, 1);
                string Rotation = s.Substring(1);
                int Amount = int.Parse(Rotation);
                if (LorR == "L")
                {
                    for (int i = 0; i < Amount;i++)
                    {
                        ValueofDial--;
                        if (ValueofDial == 0)
                        {
                            Password++;
                        }
                        if (ValueofDial < 0)
                        {
                            ValueofDial = 99;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Amount; i++)
                    {
                        ValueofDial++;
                        if (ValueofDial > 99)
                        {
                            ValueofDial = 0;
                            Password++;
                        }
                    }
                }
                Console.WriteLine(Password + "," + ValueofDial + "," + LorR + "," + Rotation);
               
            }
            SR.Close();
            Console.WriteLine(Password);
        }
    }
}

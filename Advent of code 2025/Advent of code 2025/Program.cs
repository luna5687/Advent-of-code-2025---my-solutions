using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Day1
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
                    if (ValueofDial - Amount < 0)
                    {
                        ValueofDial = 100 + (ValueofDial - Amount);
                        Password++;
                        while (ValueofDial < 0)
                        {
                            Password++;
                            ValueofDial = 100 + ValueofDial;
                        }
                        
                    }
                    else ValueofDial = ValueofDial - Amount;
                }
                else
                {
                    if (ValueofDial + Amount > 99)
                    {
                        Password++;
                        ValueofDial = (ValueofDial + Amount) - 100;
                        while (ValueofDial > 99)
                        {
                            Password++;
                            ValueofDial = ValueofDial - 100;
                        }
                    }
                    else ValueofDial = ValueofDial + Amount;
                }
                Console.WriteLine(Password + "," + ValueofDial+","+LorR+","+Rotation);
               // if (ValueofDial == 0) Password++;
            }
            SR.Close();
            Console.WriteLine(Password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FILEName = "Input.txt";
            StreamReader SR = new StreamReader(FILEName);
            string temp = SR.ReadToEnd();
            string[] AllString = temp.Split(',');
            SR.Close();
            uint output = 0;
            foreach (string s in AllString)
            {
                string[] IdRange = s.Split('-');
                uint start = uint.Parse(IdRange[0]);
                uint End = uint.Parse(IdRange[1]);
                for (uint i = start; i <= End; i++)
                {
                    if (CheckRepeating(i))
                    {
                        output += i;
                    }
                }
            }
            Console.WriteLine(output);

        }
        static bool CheckRepeating(uint input)
        {
            List<bool> result = new List<bool>();
            for (int i = 1;i<=input.ToString().Length;i++)
            {
                string temp = input.ToString().Substring(0,i);
                if (input.ToString().Length % temp.Length == 0)
                {
                    bool Repating = true;
                    for (int j = 0;j<input.ToString().Length;j+=temp.Length)
                    {
                        if (input.ToString().Substring(j,temp.Length) != temp)
                        {
                            Repating = false;
                        }
                    }
                    result.Add(Repating);
                }
            }

            return result.IndexOf(true) != -1;
        }
    }
}

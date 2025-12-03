using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileName = "Input.txt";
            StreamReader SR = new StreamReader(FileName);
            string Input = SR.ReadToEnd();
            Input = Input.Replace("\r", "");
            string[] Inputs = Input.Split('\n');
            List<int> IndivualJoltages = new List<int>();
            string temp;
            List<int> AllInts = new List<int>();
            foreach (string s in Inputs)
            {
                AllInts = new List<int>();
                for (int i =0; i < s.Length-1; i++)
                {
                    for (int j = i+1; j < s.Length; j++)
                    {
                        if (j != i)
                        {
                            AllInts.Add(int.Parse(s[i].ToString() + s[j].ToString()));
                        }
                    }
                }
                AllInts.Sort();
                AllInts.Reverse();
                IndivualJoltages.Add(AllInts[0]);
            }
            int output = 0;
            foreach (int i in IndivualJoltages)
            {
                Console.WriteLine(i);
                output+= i;
            }
            Console.WriteLine(output);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day5_part2.start();
        }
        public static string GetFileContence()
        {
            string output;
            StreamReader SR = new StreamReader("Input.txt");
            output = SR.ReadToEnd().Replace("\r", "");
            SR.Close();
            return output;
        }
    }
    public class Day5_part1
    {
       static public void start()
        {
            string input = Program.GetFileContence();
            string[] TempStringArray = input.Split(' ');
            string[] Ranges = TempStringArray[0].Split('\n');
            string[] Food = TempStringArray[1].Split('\n');
            ulong countFresh = 0;
            foreach (string s in Food)
            {
                if (s!="" &&  IsInaRage(s,Ranges)) countFresh++;
            }
            Console.WriteLine(countFresh);
        }
       static private bool IsInaRage(string input, string[] Ranges)
        {
            ulong Id = ulong.Parse(input);
            foreach (string s in Ranges)
            {
                if (s!=""&& Id >= ulong.Parse(s.Split('-')[0]) && Id <= ulong.Parse(s.Split('-')[1])) return true;
            }
            return false;
        }
    }
    static public class Day5_part2
    {
        public static void start()
        {
            string input = Program.GetFileContence();
            string[] TempStringArray = input.Split(' ');
            string[] Ranges = TempStringArray[0].Split('\n');
            string[] Food = TempStringArray[1].Split('\n');

            ulong TotalFood = ulong.Parse(Ranges[0].Split('-')[1]) - ulong.Parse(Ranges[0].Split('-')[0]) +1;
            List<ulong[]> UsedRanges = new List<ulong[]>();

            ulong RangeCount =0;

            for (int i = 0; i < Ranges.Length; i++)
            {
                if (Ranges[i] != "")
                {
                    ulong FirstValule = ulong.Parse(Ranges[i].Split('-')[0]);
                    ulong SecondValue = ulong.Parse(Ranges[i].Split('-')[1]);
                    
                }
            }


            Console.WriteLine(RangeCount);
            
        }
        static private bool IsInaRage(string input, string[] Ranges,int upto)
        {
            ulong Id = ulong.Parse(input);
            for (int i = 0;i<Ranges.Length && i < upto;i++)
            {
                string s = Ranges[i];
                if (s != "" && Id >= ulong.Parse(s.Split('-')[0]) && Id <= ulong.Parse(s.Split('-')[1])) return true;
            }
            return false;
        }
    }


}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
    static public class Part1
    {
        static public void start()
        {
            string input = Program.GetFileContence();
            string[] Lines = input.Split('\n');
            List<string[]> Parts = new List<string[]>();
            foreach (string Line in Lines)
            {
                Parts.Add(Line.Trim(' ').Split(' '));
            }
            List<ulong> Answeres = new List<ulong>();

            for (int i = 0; i < Parts[0].Length; i++)
            {
                if (Parts[i][Parts[0].Length] == "*")
                {
                    Answeres.Add(1);
                    for (int j = 0; j < Parts[i].Length-1;j++)
                    {
                        Answeres[i] *= ulong.Parse(Parts[i][j]); 
                    }
                }
                else
                {
                    Answeres.Add(0);
                    for (int j = 0; j < Parts[i].Length - 1; j++)
                    {
                        Answeres[i] += ulong.Parse(Parts[i][j]);
                    }
                }
            }
            ulong Total = 0;
            foreach (ulong i in Answeres)
            {
                Total += i;
            }
            Console.WriteLine(Total);
        }

    }

}

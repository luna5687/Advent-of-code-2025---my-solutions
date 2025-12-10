using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10
{
    internal class Program
    {
        public static bool CheckIsEqual(List<bool> a, List<bool> b)
        {
            for ( int i = 0; i < a.Count; i++ )
            {
                if ( a[i] != b[i] ) return false;
            }
            return true;
        }
        public static string GetLights(string input)
        {
            return Regex.Match(input, @"\[(\.|#)+\]").Value;
        }
        public static string GetJoltages(string input)
        {
            return Regex.Match(input, @"{\w+}").Value;
        }
        public static string[] GetWires(string input)
        {
            string output = Regex.Match(input, @"\](\w|\W)+{").Value;
            output = output.Substring(1, output.Length - 2);
            return output.Trim(' ').Split(' ');
        }
        public static string GetFileContence()
        {
            string output;
            StreamReader SR = new StreamReader("Input.txt");
            output = SR.ReadToEnd().Replace("\r","");
            SR.Close();
            return output;
        }
        static void Main(string[] args)
        {
            Part1.Start();
        }
    }
}

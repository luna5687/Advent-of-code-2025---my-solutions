using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Day_9
{
    internal class Program
    {
        public static string GetFileContence()
        {
            string output;
            StreamReader SR = new StreamReader("Input.txt");
            output = SR.ReadToEnd().Replace("\r", "");
            SR.Close();
            return output;
        }
        static void Main(string[] args)
        {
            Part1.Start();
        }
    }
    public class Part1
    {
        public static void Start()
        {
            
            List<ulong> PossibleValues = new List<ulong>();
            string input = Program.GetFileContence();
            List<ulong[]> TileLocations = new List<ulong[]>();
            string[] Lines = input.Split('\n');
            foreach (string line in Lines)
            {
                ulong[] temp = { ulong.Parse(line.Split(',')[0]), ulong.Parse(line.Split(',')[1]) };
                TileLocations.Add(temp);

            }
            for (int i = 0; i < TileLocations.Count; i++)
            {
                for (int j = 0; j < TileLocations.Count; j++)
                {
                    if (j!=i)
                    {
                        ulong x;
                        ulong Y;
                        if (TileLocations[i][0] > TileLocations[j][0])
                        {
                            x = TileLocations[i][0] - TileLocations[j][0] + 1;
                        }
                        else if (TileLocations[i][0] < TileLocations[j][0])
                        {
                            x = TileLocations[j][0] - TileLocations[i][0] + 1;
                        }
                        else
                        {
                            x = 1;
                        }
                        if (TileLocations[i][1] > TileLocations[j][1])
                        {

                            Y = TileLocations[i][1] - TileLocations[j][1] + 1;
                        }
                        else if (TileLocations[i][1] < TileLocations[j][1])
                        {
                            Y = TileLocations[j][1] - TileLocations[i][1] + 1;
                        }
                        else
                        {
                            Y = 1;
                        }
                        PossibleValues.Add(x * Y);

                    }
                }
            }
            PossibleValues.Sort();
            PossibleValues.Reverse();
            Console.WriteLine(PossibleValues[0]);
        }
    }

}

using System;
using System.Collections.Generic;

namespace Day10
{
    public class Part1
    {
        static private List<bool> CurrentLights;
        public static void Start()
        {
            string input = Program.GetFileContence();
            int total = 0;
            foreach (string line in input.Split('\n'))
            {
                string Lights = Program.GetLights(line);
                string[] wires = Program.GetWires(line);
                List<bool> TargetLights = new List<bool>();
                CurrentLights = new List<bool>();
                foreach (char s in Lights)
                {
                    if (s == '#')
                    {
                        TargetLights.Add(true);
                    }
                    else if (s == '.') TargetLights.Add(false);
                }
                for (int i = 0; i < TargetLights.Count; i++)
                {
                    CurrentLights.Add(false);
                }
                List<int[]> AllWires = new List<int[]>();
                foreach (string w in wires)
                {
                    List<int> intListtemp = new List<int>();
                    string StringTemp = w.Substring(1, w.Length - 2);
                    foreach (string s in StringTemp.Split(','))
                    {
                        intListtemp.Add(int.Parse(s));
                    }
                    AllWires.Add(intListtemp.ToArray());
                }
                List<int> LigthsNeedChanging = new List<int>();
                for (int i = 0; i < TargetLights.Count; i++)
                {
                    if (TargetLights[i]) LigthsNeedChanging.Add(i);
                }
                List<int> QuededButtonPresses = new List<int>();
                SwitchLights(AllWires[FindbuttonWithValues(AllWires, LigthsNeedChanging)]);
                int countPresses = 1;
                while (!Program.CheckIsEqual(TargetLights,CurrentLights))
                {
                    LigthsNeedChanging = GetDifferences(TargetLights);
                    SwitchLights(AllWires[FindbuttonWithValues(AllWires, LigthsNeedChanging)]);
                    countPresses++;
                }
                Console.WriteLine(countPresses);
            }
        }
        static List<int> GetDifferences(List<bool> Target)
        {
            List<int> output = new List<int>();
            for (int i = 0;i<Target.Count;i++)
            {
                if (Target[i] != CurrentLights[i]) output.Add(i);  
            }
            return output;
        }
        static int FindbuttonWithValues(List<int[]> AllButtons, List<int> Values)
        {
            int button = 0;
            List<int> Overlap = new List<int>();
            for (int i = 0; i < AllButtons.Count; i++)
            {
                Overlap.Add(0);
            }
            int LargestOverlapIndex = 0;
            for (int i = 0; i < AllButtons.Count; i++)
            {
                foreach (int B in AllButtons[i])
                {
                    if (Values.Contains(B))
                    { Overlap[i]++; LargestOverlapIndex = i; }
                }
            }
            

            for (int i =0; i < Overlap.Count; i++)
            {
                if (Overlap[i] > Overlap[LargestOverlapIndex])
                {
                    LargestOverlapIndex=i;
                }
                else if (Overlap[i] == Overlap[LargestOverlapIndex])
                {
                    if (AllButtons[i].Length < AllButtons[LargestOverlapIndex].Length)
                    {
                        LargestOverlapIndex = i;
                    }
                }
            }
            return button=LargestOverlapIndex;
        }
        static void SwitchLights(int[] LigthsToSwitch)
        {
            foreach (int i in LigthsToSwitch)
            {
                CurrentLights[i] = !CurrentLights[i];
            }
        }
        static void SwitchLights(int LigthsToSwitch)
        {
                CurrentLights[LigthsToSwitch] = !CurrentLights[LigthsToSwitch];
        }
    }
}

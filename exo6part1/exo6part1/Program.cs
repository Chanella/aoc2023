using System.Collections.Generic;
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string line;
        int way = 1;
        List<int> Times = new List<int>();
        List<int> Distances = new List<int>();
        List<int> ways= new List<int>();
        int a = 0;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                //Read the first line of text
                line = sr.ReadLine();
                Console.WriteLine("bnjou");

                //Continue to read until you reach end of file
                foreach (string s in line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList())
                {
                    if (int.TryParse(s, out a))
                        Times.Add(a);
                }
                line = sr.ReadLine();

                foreach (string s in line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList())
                {
                    if (int.TryParse(s, out a))
                        Distances.Add(a);
                }

                foreach(int y in Times) { ways.Add(0); }

                //Pour toutes les courses
                for (int x = 0; x < Times.Count; x++)
                {
                    //check de ttes les valeurs possible entre 1 et le temps max
                    for (int i = 1; i < Times[x]; i++)
                    {
                        //Si le temps multiplié par la  
                        if ( i * (Times[x] - i) > Distances[x])
                        {
                            ways[x]++;
                        }
                    }
                }

                foreach(int w in ways)
                {
                    way *= w;
                }

                Console.WriteLine("le plus petit est " + way);
                //close the file
                sr.Close();
                Console.ReadLine();
                //write the line to console window

            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }

    }

}
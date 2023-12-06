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
        int way = 0;
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

                double Time = double.Parse(line.Replace(" ", "").Replace("Time:", ""));

                line = sr.ReadLine();

                List<string> p = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                p.RemoveAt(0);

                string wesh2 = string.Empty;

                foreach (string çamesoule in p)
                {
                    wesh2 += çamesoule;
                }

                double Distance = double.Parse(line.Replace(" ", "").Replace("Distance:", ""));


                //check de ttes les valeurs possible entre 1 et le temps max
                for (double i = 1; i < Time; i++)
                {
                    //Si le temps multiplié par la  
                    if ( i * (Time - i) > Distance)
                    {
                            way++;
                    }
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
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
        double pluspetit = 0;
        List<double> seeds = new List<double>();
        List<double> map = new List<double>();
        List<bool> visited = new List<bool>();  
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                //Read the first line of text
                line = sr.ReadLine();
                Console.WriteLine("bnjou");
                
                //Continue to read until you reach end of file

                while (line != null)
                {
                    if (line.StartsWith("seeds:"))
                    {
                        line = line.Trim("seeds:".ToCharArray());

                        foreach (string seed in line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList())
                        {
                            seeds.Add(double.Parse(seed));
                        }
                        for (int i = 0; i < seeds.Count; i++) { visited.Add(false); }
                    }

                    if (line.StartsWith("seed-") || line.StartsWith("soil-") || line.StartsWith("fertilizer-") || line.StartsWith("water-") || line.StartsWith("light-") || line.StartsWith("temperature-") || line.StartsWith("humidity-"))
                    {
                        line = sr.ReadLine();
                        for (int i = 0; i < seeds.Count; i++) { visited[i] = false; }
                        while (line != string.Empty && line != null)
                        {

                            map.Clear();
                            foreach(string seed in line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()) 
                            {
                                map.Add(Double.Parse(seed));
                            }

                            for (int incr = 0; incr < seeds.Count; incr++)
                            {
                                //si la valeur de la seed est superieur a la seconde colonne et inferieure à la valeur de la seconde colonne + le range de la 3e
                                if (seeds[incr] > map[1] && seeds[incr] < (map[1] + map[2]) && !visited[incr])
                                {
                                    //on regarde combien de dif il y a entre le premier element et la seed
                                    double diff =  seeds[incr] - map[1];
                                    seeds[incr] = map[0] + diff;
                                    visited[incr] = true;
                                }
                            }
                            line = sr.ReadLine();
                        }
                    }
                    
                    line = sr.ReadLine();
                }
                
                for(int i = 0; i < seeds.Count; i++)
                {
                    if (seeds[i] <= pluspetit || pluspetit == 0) 
                    { 
                        pluspetit = seeds[i]; 
                    }
                }
                Console.WriteLine("le plus petit est " + pluspetit);
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

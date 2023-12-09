using System.Collections.Generic;
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Xml.Linq;
using System.ComponentModel;

internal class Program
{

    private static void Main(string[] args)
    {
        string line;
        double count = 0;
        List<List<int>> main = new List<List<int>>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                //Read the first line of text
                line = sr.ReadLine();
                Console.WriteLine("bnjou");
                main.Add(new List<int>());

                while (line != null)
                {
                    main[0] = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => Int32.Parse(x)).ToList();
                    int y = 0;
                    //construction de nos suites de listes
                    while (main[y].Any(x => x != 0))
                    {
                        y++;
                        if (main.Count <= y)
                            main.Add(new List<int>());
                        for (int i = 0; i < main[y-1].Count-1; i++)
                        {
                            if (main[y].Count <= i)
                                main[y].Add(main[y - 1][i + 1] - main[y - 1][i]);
                            else main[y][i] = main[y - 1][i + 1] - main[y - 1][i];
                        }

                        
                    }

                    //on determine le dernier element
                    while (y > -1)
                    {
                        count += main[y].Last();
                        y--;
                    }

                    for (int a = 1; a < main.Count; a++)
                    {
                        main[a].Clear();
                    }

                    line = sr.ReadLine();
                }
               
                Console.WriteLine("l'addition est: " + count);
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

using System.Collections.Generic;
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Xml.Linq;

internal class Program
{
    public class Maps{
        public string id;
        public string dirL;
        public string dirR;

        public Maps(string id, string dirL, string dirR)
        {
            this.id = id;
            this.dirL = dirL;
            this.dirR = dirR;
        }

        public string getid()
        {
            return this.id;
        }

    }
    private static void Main(string[] args)
    {
        string line;
        double count = 0;
        List<string> directions = new List<string>();
        List<Maps> maps = new List<Maps>();
        List <Maps> current = new List<Maps>();
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                //Read the first line of text
                line = sr.ReadLine();
                Console.WriteLine("bnjou");

                //on recup la premiere ligne 
                directions = line.ToCharArray().ToList().Select(x => x.ToString()).ToList();

                //on passe le saut de ligne
                line = sr.ReadLine();

                //op c'est parti pour le mapping chelou
                line = sr.ReadLine();

                while (line != null)
                {
                    line = line.Replace("=", "").Replace("(", "").Replace(")", "").Replace(",", "");
                    
                    maps.Add(new Maps(line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0], line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1], line.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]));

                    line = sr.ReadLine();
                }

                int i = 0;

                current = maps.FindAll(x => x.id.EndsWith('A'));
                int a = current.Count;

                while (current.FindAll(x => x.id.EndsWith('Z')).Count < a)
                {
                    if (i < directions.Count)
                    {
                        if (directions[i] == "R")
                        {
                            for (int m = 0; m < current.Count; m++)
                            {
                                current[0] = maps.Find(x => x.id == current[0].dirR);
                            }
                        }
                        else
                        {
                            for (int m = 0; m < current.Count; m++)
                            {
                                current[0] = maps.Find(x => x.id == current[0].dirL);
                            }
                        }
                        i++;
                        count++;
                    }
                    else i = 0;
                }


                Console.WriteLine("le plus petit est " + count);
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
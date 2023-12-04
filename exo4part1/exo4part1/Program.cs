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
        int worth = -1;
        double somme = 0;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                //Read the first line of text
                line = sr.ReadLine();
                Console.WriteLine("bnjou");
                List<string> loto = new List<string>();
                List<string> hand = new List<string>();
                char[] separators = { ':', '|' };
                //Continue to read until you reach end of file

                while (line != null)
                {
                    loto = line.Split(separators, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                    hand = line.Split(separators, StringSplitOptions.RemoveEmptyEntries)[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach(string value in loto)
                    {
                        if (hand.Contains(value)) { worth++; }
                    }

                    if (worth > -1) { somme += Math.Pow(2, worth); }
                    
                    worth = -1;
                    line = sr.ReadLine();
                }

                //Console.WriteLine("la somme des lignes invalide est " + somme);   
                Console.WriteLine("la somme des pouvoirs des lignes est " + somme);
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
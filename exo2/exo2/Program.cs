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
        bool invalid = false;
        int red = 0, blue = 0, green = 0;
        string[] separateurs = {":", ";", "," };
        List<string> decoupe = new List<string>();
        List<string> decoupedecoupe = new List<string>();
        int somme = 0, value;
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
                    /*PART 1 
                    decoupe = line.Split(separateurs, StringSplitOptions.None).ToList();

                    foreach (string str in decoupe)
                    {
                        if (str.StartsWith("Game")) continue;
                        else
                        {
                            decoupedecoupe = str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                            if ((decoupedecoupe[1] == "red" && Int32.Parse(decoupedecoupe[0]) > 12) || (decoupedecoupe[1] == "blue" && Int32.Parse(decoupedecoupe[0]) > 14) || (decoupedecoupe[1] == "green" && Int32.Parse(decoupedecoupe[0]) > 13))
                            {                               
                                invalid = true;
                            }
                        }
                        decoupedecoupe.Clear();
                    }
                    if (invalid == false) somme += Int32.Parse(decoupe[0].Split(" ")[1]);
                    *invalid = false;
                    */
                    //PART2
                    decoupe = line.Split(separateurs, StringSplitOptions.None).ToList();
                    foreach (string str in decoupe)
                    {
                        if (str.StartsWith("Game")) continue;
                        else
                        {
                            value = Int32.Parse(str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()[0]);
                            switch (str.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()[1])
                            {                             
                                case "red":
                                    if (value > red) red = value;
                                    break;
                                case "blue":
                                    if (value > blue) blue = value;
                                    break;
                                case "green":
                                    if (value > green) green = value;
                                    break;
                            }
                        }
                    }                
                    somme += (red * blue * green);
                    red = 0;
                    blue = 0;
                    green = 0;
                    decoupe.Clear();
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
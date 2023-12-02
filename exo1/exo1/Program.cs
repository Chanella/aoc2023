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
        string flowline = string.Empty;
        string concatintligne = string.Empty;
        long somme = 0;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                //Read the first line of text
                line = sr.ReadLine();
                int a;
                Console.WriteLine("bnjou");
                //Continue to read until you reach end of file
                List<int> linenumbers = new List<int>();
                while (line != null)
                {
                    //PART 1
                    /*foreach (char c in line.ToArray())
                    {
                        if (Int32.TryParse(c.ToString(), out a))
                        {
                            linenumbers.Add(a);
                        }                       
                    }
                    concatintligne = linenumbers.First().ToString() + linenumbers.Last().ToString();
                    
                    
                    somme += Int32.Parse(concatintligne);
                    concatintligne = string.Empty;
                    */

                    //  PART 2

                    foreach (char c in line.ToArray())
                    {
                        if (Int32.TryParse(c.ToString(), out a))
                        {
                            linenumbers.Add(a);
                            flowline = string.Empty;
                        }
                        else
                        {
                            flowline += c.ToString();
                            if (flowline.Contains("one"))
                            {
                                linenumbers.Add(1);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("two"))
                            {
                                linenumbers.Add(2);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("three"))
                            {
                                linenumbers.Add(3);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("four"))
                            {
                                linenumbers.Add(4);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("five"))
                            {
                                linenumbers.Add(5);
                                flowline = flowline.Remove(0, flowline.Length-1);
                            }
                            if (flowline.Contains("six"))
                            {
                                linenumbers.Add(6);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("seven"))
                            {
                                linenumbers.Add(7);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("eight"))
                            {
                                linenumbers.Add(8);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                            if (flowline.Contains("nine")) 
                            {
                                linenumbers.Add(9);
                                flowline = flowline.Remove(0, flowline.Length - 1);
                            }
                        }
                    }

                    concatintligne = linenumbers.First().ToString() + linenumbers.Last().ToString();


                    somme += Int32.Parse(concatintligne);
                    concatintligne = string.Empty;

                    flowline = string.Empty;
                    linenumbers.Clear();
                    line = sr.ReadLine();
                }
                Console.WriteLine("la somme est " + somme);
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
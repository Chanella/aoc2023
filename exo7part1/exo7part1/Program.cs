using System.Collections.Generic;
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Xml.Linq;
using System.Net.Http.Headers;

public class hand
{
    public List<char> cards;
    public int bid;
    int type;

    public  hand()
    {
        cards = new List<char>();
        bid = 0;
    }
    public hand(List<char> c, int b)
    {
        this.cards = c;
        bid = b;
        type = 0;
    }

    public int assigntype()
    {
        List<char> list = new List<char>();
        list = cards;

        int a = 0;

        int t = list.FindAll(x => x == list[a]).Count();

        if (t == 5)
        {
            this.type = 6;
            return this.type;
        }
        else if (t == 4)
        {
            this.type = 5;
            return this.type;
        }
        else
        {
            list.Remove(list[0]);
            // il y a 3 pareils
            if (list.Count == 2)
            {
                //check s'il reste 2 pareils ou pas
                if (list[0].Equals(list[1]))
                    this.type = 4;
                else this.type = 3;
                
                return this.type;
            }
             while (list.Count > 1) 
            {
                //t = list.FindAll(x => x == list[0]).Count();
                
                list.Remove(list[0]);
                if (list.Count == 0)
                {
                    this.type = 6;
                    return this.type;
                }
                if (list.Count == 1)
                {
                    this.type = 5;
                    return this.type;
                }

                // il y a 3 pareils
                if (t == 3)
                {
                   //check s'il reste 2 pareils ou pas
                   if (list[0].Equals(list[1]))
                      this.type = 4;
                        else this.type = 3;

                        return this.type;
                }
                    // il y a deux pareils
                    if (list.Count == 3)
                {
                    
                    if (t == 3) { this.type = 4; return this.type; }
                    if (t == 2) { this.type = 2; return this.type; }
                    if (t == 1 ) { list.Remove(list[0]); }
                }
                if (list.Count == 4)
                {
                    t = list.FindAll(x => x == list[a]).Count();
                    if (t == 3) { this.type = 4; return this.type; }
                    if (t == 2) { this.type = 2; return this.type; }
                }
            }
            

        
        }




        return type;

    }

    public int getType { get { return type; } }

    public int getbid()
    {
        return bid;
    }
    public char getcard(int c)
    { return cards[c]; }
    
}


internal class Program
{
    private static void Main(string[] args)
    {
        string line;
        int way = 1;
        List<hand> cards = new List<hand>();

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
                    hand h = new hand(line.Split(" ")[0].ToCharArray().ToList(),Int32.Parse(line.Split(" ")[1]));
                    //on cherche a savoir ou ajouter la main dans la liste des mains
                    /*
                     * 5 Cartes pareilles => type 6
                     * 4 cartes pareilles => type 5
                     * 3 cartes pareilles et deux aussi => 4
                     * 3 cartes pareilles et deux non => 3
                     * 2 cartes pareille et 2 cartes aussi = > 2
                     * 2 cartes pareilles solo => 1
                     * nada => 0
                     * */

                    if (cards.Count == 0) 
                    { 

                        cards.Add(h); 
                    }

                    else
                    { 
                        foreach (hand hd in cards)
                        {

                        }
                    }



                    cards.Add(h);
                    line = sr.ReadLine();
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
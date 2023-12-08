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
    public List<int> cards;
    public int bid;
    int type;

    public hand(List<char> c, int b)
    {
        this.cards = Convert(c);
        bid = b;
        type = assigntype();
    }

    public List<int> Convert(List<char> c)
    {
        List<int> result = new List<int>();
        foreach (char ch in c)
        {
            switch (ch)
            {
                case 'A':
                    result.Add(14);
                    break;
                case 'K':
                    result.Add(13);
                    break;
                case 'Q':
                    result.Add(12);
                    break;
                case 'J':
                    result.Add(1);
                    break;
                case 'T':
                    result.Add(10);
                    break;
                default:
                    result.Add(Int32.Parse(ch.ToString()));
                    break;
            }
        }
        return result;
    }

    public int assigntypewithJ(List<string> list)
    {
        int number = list.RemoveAll(x => x == "1");
        // 5 J pareils
        if (list.Count == 0)
        {
            return 6;
        }
        // 4 J pareils
        if (list.Count == 1)
        {
            return 6;
        }

        // il y a 3 J pareils
        if (list.Count == 2)
        {
            if (list[0] == list[1]) type = 6;
            else type = 5;

            return type;
        }

        // il y a deux pareils
        if (list.Count == 3)
        {
            //this.type = 1;
            string s = list[0];
            list.RemoveAll(x => x == s);
            if (list.Count == 0) type = 6;
            if (list.Count == 1)
            {
                type = 5;
            }
            if (list.Count == 2)
            {
                if (list[0] == list[1]) type = 5;
                else type = 3;
            }
            return this.type;
        }
        if (list.Count == 4)
        {
            string s = list[0];
            list.RemoveAll(x => x == s);

            // 4 pareils + J
            if (list.Count == 0)
            {
                this.type = 6;
            }

            // 3 pareils + J + 1 diffs
            if (list.Count == 1) { this.type = 5; }

            //2 pareils + J
            if (list.Count == 2)
            {
                this.type = 3;
                // 2 pareils - 2 pareils + J
                if (list[0] == list[1]) this.type++;
            }
            //nada + J
            if (list.Count == 3)
            {
                s = list[0];
                list.RemoveAll(x => x == s);
                
                // 3 pareils + J + 1 diffs
                if (list.Count == 0)
                {
                    return 5;
                }

                // 2 pareils only + J
                if (list.Count == 1)
                {
                    return 3;
                }

                //nada
                if (list.Count == 2)
                {
                    // 2 pareils only + j
                    if (list[0] == list[1])
                        this.type = 3;
                    else this.type = 1;
                }
                
            }
        }
        return type;
    }

    public int assigntype()
    {
        List<string> list = new List<string>();
        list = this.cards.Select(x => x.ToString()).ToList();
        if (list.Contains("1")) return this.assigntypewithJ(list);

        list.RemoveAll(x => x == cards[0].ToString());
        // 5 pareils
        if (list.Count == 0)
        {
            return 6;
        }
        // 4 pareils
        if (list.Count == 1)
        {
            return 5;
        }

        // il y a 3 pareils
        if (list.Count == 2)
        {
            this.type = 3;
            if (list[0] == list[1]) this.type++;

            return this.type;
        }

        // il y a deux pareils
        if (list.Count == 3)
        {
            this.type = 1;
            string s = list[0];
            list.RemoveAll(x => x == s);
            if (list.Count == 0) this.type += 3;
            if (list.Count == 1)
            {
                this.type++;
            }
            if (list.Count == 2)
            {
                if (list[0] == list[1]) this.type++;
            }
            return this.type;
        }
        if (list.Count == 4)
        {
            string s = list[0];
            list.RemoveAll(x => x == s);

            // 4 pareils
            if (list.Count == 0)
            {
                this.type = 5;
            }

            // 3 pareils - 2 diffs
            if (list.Count == 1) { this.type = 3; }

            //2 pareils
            if (list.Count == 2)
            {
                this.type = 1;
                // 2 pareils - 2 pareils
                if (list[0] == list[1]) this.type++;
            }
            //
            if (list.Count == 3)
            {
                s = list[0];
                list.RemoveAll(x => x == s);
                // 3 pareils - 2 diffs
                if (list.Count == 0)
                {
                    return 3;
                }

                // 2 pareils only
                if (list.Count == 1)
                {
                    return 1;
                }

                //nada
                if (list.Count == 2)
                {
                    // 2 pareils only
                    if (list[0] == list[1])
                        this.type = 1;
                }
                else this.type = 0;
            }
        }
        return this.type;
    }

    public int getType { get { return type; } }

    public int getbid()
    {
        return bid;
    }
    public int getcard(int c)
    { return cards[c]; }

}


internal class Program
{
    private static void Main(string[] args)
    {
        string line;
        double way = 0;
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
                    hand h = new hand(line.Split(" ")[0].ToCharArray().ToList(), Int32.Parse(line.Split(" ")[1]));
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

                    cards.Add(h);
                    line = sr.ReadLine();
                }

                IEnumerable<hand> query = from hands in cards
                                          orderby hands.getType, hands.cards[0], hands.cards[1], hands.cards[2], hands.cards[3], hands.cards[4]
                                          select hands;
                int i = 1;
                foreach (hand h in query)
                {
                    way += i * h.bid;
                    i++;
                }

                Console.WriteLine("le total winnings est " + way);
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
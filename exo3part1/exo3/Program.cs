using System.Collections.Generic;
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Xml.Linq;
using System.Linq.Expressions;

internal class Program
{
    static bool thereissymbol(List<string> lignes, int x, int y)
    {
        int t;
        try
        {
            //tests sans coin ou bord
            if (y > 0 && y < lignes.Count-1)
            {
                List<char> ligneprecedente = lignes[y - 1].ToList();
                List<char> lignesuivante = lignes[y + 1].ToList();
                List<char> ligne = lignes[y].ToList();
                if (x > 0 && x < ligneprecedente.Count-1)
                {
                    if (!Int32.TryParse(ligneprecedente[x].ToString(), out t) && ligneprecedente[x] != '.') return true;
                    if (!Int32.TryParse(ligneprecedente[x - 1].ToString(), out t) && ligneprecedente[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligneprecedente[x + 1].ToString(), out t) && ligneprecedente[x + 1] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x].ToString(), out t) && lignesuivante[x] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x - 1].ToString(), out t) && lignesuivante[x - 1] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x + 1].ToString(), out t) && lignesuivante[x + 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x - 1].ToString(), out t) && ligne[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x + 1].ToString(), out t) && ligne[x + 1] != '.') return true;
                }
            }
            //test avec la premiere ligne
            if (y == 0)
            {
                List<char> lignesuivante = lignes[y + 1].ToList();
                List<char> ligne = lignes[y].ToList();
                if (x > 0 && x < ligne.Count-1)
                {
                    if (!Int32.TryParse(lignesuivante[x].ToString(), out t) && lignesuivante[x] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x - 1].ToString(), out t) && lignesuivante[x - 1] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x + 1].ToString(), out t) && lignesuivante[x + 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x - 1].ToString(), out t) && ligne[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x + 1].ToString(), out t) && ligne[x + 1] != '.') return true;
                }
                //le premier coin en haut à gauche
                if (x == 0)
                {
                    if (!Int32.TryParse(lignesuivante[x].ToString(), out t) && lignesuivante[x] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x + 1].ToString(), out t) && lignesuivante[x + 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x + 1].ToString(), out t) && ligne[x + 1] != '.') return true;
                }
                //le coin en haut à droite
                if (x == ligne.Count-1)
                {
                    if (!Int32.TryParse(lignesuivante[x].ToString(), out t) && lignesuivante[x] != '.') return true;
                    if (!Int32.TryParse(lignesuivante[x - 1].ToString(), out t) && lignesuivante[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x - 1].ToString(), out t) && ligne[x - 1] != '.') return true;
                }
            }
            // test avec la derniere ligne
            if (y == lignes.Count-1)
            {
                List<char> ligneprecedente = lignes[y - 1].ToList();
                List<char> ligne = lignes[y].ToList();
                if (x > 0 && x < ligneprecedente.Count-1)
                {
                    if (!Int32.TryParse(ligneprecedente[x].ToString(), out t) && ligneprecedente[x] != '.') return true;
                    if (!Int32.TryParse(ligneprecedente[x - 1].ToString(), out t) && ligneprecedente[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligneprecedente[x + 1].ToString(), out t) && ligneprecedente[x + 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x - 1].ToString(), out t) && ligne[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x + 1].ToString(), out t) && ligne[x + 1] != '.') return true;
                }
                //le coin en bas à gauche
                if (x == 0)
                {
                    if (!Int32.TryParse(ligneprecedente[x].ToString(), out t) && ligneprecedente[x] != '.') return true;
                    if (!Int32.TryParse(ligneprecedente[x + 1].ToString(), out t) && ligneprecedente[x + 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x + 1].ToString(), out t) && ligne[x + 1] != '.') return true;
                }
                //le coin en bas à droite
                if (x == ligne.Count-1)
                {
                    if (!Int32.TryParse(ligneprecedente[x].ToString(), out t) && ligneprecedente[x] != '.') return true;
                    if (!Int32.TryParse(ligneprecedente[x - 1].ToString(), out t) && ligneprecedente[x - 1] != '.') return true;
                    if (!Int32.TryParse(ligne[x - 1].ToString(), out t) && ligne[x - 1] != '.') return true;
                }
            }
        }
        catch(ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
        

        return false;
    }
    private static void Main(string[] args)
    {
        string line;
        int somme = 0;
        List<string> lines = new List<string>();
        string fichier = "input.txt";
        int chiffre;
        string nombre = string.Empty;
        int abs = 0, ord = 0;
        bool part = false;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader(fichier))
            {
                lines = File.ReadAllLines(fichier).ToList();
                //Read the first line of text
                line = sr.ReadLine();
                Console.WriteLine("bnjou");
                //Continue to read until you reach end of file

                while (line != null)
                {
                    foreach (char s in line) 
                    {
                        
                        if (Int32.TryParse(s.ToString(), out chiffre))
                        {
                            nombre += s;
                            if (!part)
                            {
                                part = thereissymbol(lines, abs, ord);
                            }
                        }
                        else
                        {
                            if (part) 
                                somme += Int32.Parse(nombre);
                            nombre = string.Empty;
                            part = false;
                        }
                        abs++;
                    }
                    abs = 0;
                    ord++;
                    line = sr.ReadLine();
                }

                //Console.WriteLine("la somme des lignes invalide est " + somme);   
                Console.WriteLine("la somme des parts est " + somme);
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
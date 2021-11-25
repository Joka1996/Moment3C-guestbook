using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Moment3
{

    class Program
    {

        static void Main(string[] args)
        {
            //kommandon 
            Console.WriteLine("Hej från gästboken, skriv ditt inlägg.");
            Console.WriteLine("Alternativ:");
            Console.WriteLine("1.Skriv inlägg:");
            Console.WriteLine("2.Visa alla inlägg");
            Console.WriteLine("3.Radera inlägg efter index");
            Console.WriteLine("Tryck på 'x' för att avsluta ");

            // här lagras txtfilen. Måste anpassas, och skapa en egen fil.
           string filePath = @"C:\Users\Jollan\Documents\c#moment3.txt";

            //instans
            var userInput = Console.ReadLine();
            var post = new Post();

            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        //skicka till klassen och sparar till txt-fil
                        Console.WriteLine("Författare:");
                        var author = Console.ReadLine();
                        Console.WriteLine("Ditt inlägg:");
                        var content = Console.ReadLine();
                        post.GuestBook.Add(new Post {Author = author, Content = content });
                        //spara till text-filen. 
                        using (StreamWriter sw = File.AppendText(filePath))
                        {
                            sw.WriteLine("Författare: " + author + " - " + content + " *");
                            sw.Close();
                        }
                           
                        //gammalt 
                        /*for (int i = 0; i < post.GuestBook.Count; i++)
                        {
                           var one =  post.GuestBook[i].Id;
                            var two = post.GuestBook[i].Author;
                            var three = post.GuestBook[i].Content;

                            }*/
                        break;
                       
                    case "2":
                        //Läs textfilen.
                        string[] posts = File.ReadAllLines(filePath);
                        for (int i = posts.GetLowerBound(0); i <= posts.GetUpperBound(0); i++)
                            //skriv ut innehållet i textfilen.
                        Console.WriteLine("[{0,2}]: {1}", i, posts[i]);


                        /*
                        using (StreamReader sr = File.OpenText(filePath))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        //gammal lösning.
                        /*for (int i = 0; i < post.GuestBook.Count; i++)
                        {

                            Console.WriteLine($" {post.GuestBook[i].Id} || Författare: {post.GuestBook[i].Author} - {post.GuestBook[i].Content}");
                        }*/

                        break;
                    case "3":
                        //ange ett id i konsolen som sedan konventeras
                        Console.WriteLine("Skriv ID att radera");
                        var delete = Convert.ToInt32(Console.ReadLine());
                      //Hämta filen och gör om till lista.
                        List<string> ReadFile = File.ReadAllLines(filePath).ToList();

                        //radera angivet id, alltså index.
                        ReadFile.RemoveAt(delete);
                        Console.WriteLine("Raderad..");
                        // ersätt den gamla filen med den nya.
                        File.WriteAllLines(filePath, ReadFile);

                        /* 
                         string[] lines = File.ReadAllLines(filePath);
                         var listLines = new List<string>(lines);
                         * lines.
                         foreach (var line in lines)
                           {
                             line.RemoveAt(delete);
                           }*/


                        /*
               
                         post.GuestBook.RemoveAt(delete);
                         Console.WriteLine("Borttagen..");*/
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Välj alternativ 1-3.");
                        break;

                }

                Console.WriteLine("Välj val");
                userInput = Console.ReadLine();
           
            }
        }

    }
}

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
            //kalla på alternativen
            options();

            //instans
            var userInput = Console.ReadLine();
            var guest = new Guest();

            while (true)
            {
                switch (userInput)
                {
                    case "1": //LÄGG TILL
                        //skicka till klassen och sparar till txt-fil
                        Console.WriteLine("Författare:");
                        var author = Console.ReadLine();
                        Console.WriteLine("Ditt inlägg:");
                        var content = Console.ReadLine();

                        // skicka till klassen Guest och funktionen AddPost tar emot parametrarna.
                        guest.AddPost(author, content);

                        //hämta på alternativen
                        options();
                        break;
                    case "2": // LÄSA 
                        //Hämta funktion för att läsa ut.            
                        guest.ReadPost();

                        break;
                    case "3": // RADERA
                        //ange ett id i konsolen som sedan konventeras
                        Console.WriteLine("Skriv ID att radera");
                        var delete = Convert.ToInt32(Console.ReadLine());
                        guest.DeletePost(delete);
                        //hämta alternativen
                        options();
                        break;
                    case "4": // RENSA KONSOLEN
                        Console.Clear();
                        //rensa konsollen och kalla på options-funktionen
                        options();
                        break;
                    case "x": // STOPP 
                        return;
                    default:
                        Console.WriteLine("Välj alternativ 1-4.");
                        break;
                }
                
                Console.WriteLine("Välj ett alternativ 1-4");
                userInput = Console.ReadLine();
           
            }

            //funktion för kommandon så de kan kallas på vid rensning av konsol.
            static void options()
            {     
            //kommandon 
            Console.WriteLine("Hej från gästboken, skriv ditt inlägg.");
            Console.WriteLine("Alternativ:");
            Console.WriteLine("1.Skriv inlägg");
            Console.WriteLine("2.Visa alla inlägg");
            Console.WriteLine("3.Radera inlägg efter index");
            Console.WriteLine("4.Rensa konsolen");
            Console.WriteLine("Tryck på 'x' för att avsluta ");

            }
        }

    }
}

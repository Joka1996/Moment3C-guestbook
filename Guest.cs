using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Moment3
{
   public class Guest
    {

        // Hämta textfilen, lagra i variabel. filen ligger i bin/debug/netcoreapp3.1/c#moment3
        string filePath = "c#moment3.txt";

        //lägg till post
        public void AddPost(string author, string content)
        {
            //skicka till klassen Post och lägg till
            var post = new Post();
            if(author == ""|| content == "")
            {
                Console.WriteLine("Ej tillåtet att lägga till tomma inlägg!");
            } else
            {
                post.GuestBook.Add(new Post { Author = author, Content = content });
                Console.WriteLine("Inlägg skapat!");
                //om ingen text-fil finns skapas en, ett meddelande skrivs till konsolen.
                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        Console.WriteLine("Textfil skapad: c#moment3.txt ");
                    }
                }

                //spara till txt-fil, append för att lägga till och inte skriva över redan sparat innehåll.
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine("Författare: " + author + " - " + content);
                    sw.Close();
                }
            }
            //Rensa konsolen efter tre sekunder.
            System.Threading.Thread.Sleep(3000);
            Console.Clear();
        }
        //läs ut poster
        public void ReadPost()
        {
            //kontroll om text-filen finns
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Det finns ännu inga inlägg, skapa ett nytt!");
            } else
            {
                // läs in textfilen för om till array och loopa igenom samt lägg ill index.
                string[] posts = File.ReadAllLines(filePath);
                for (int i = posts.GetLowerBound(0); i <= posts.GetUpperBound(0); i++)
                    //skriv ut innehållet i textfilen.
                    Console.WriteLine("[{0,2}]: {1}", i, posts[i]);
            }
           
                
        }
        //Ta bort en post
        public void DeletePost(int delete)
        {
 
        //Hämta filen och gör om till lista.
        List<string> ReadFile = File.ReadAllLines(filePath).ToList();

        //radera angivet id, alltså index.
        ReadFile.RemoveAt(delete);
        Console.WriteLine($"ID nr:[{delete}] är raderad..");
        // ersätt den gamla filen med den nya.
        File.WriteAllLines(filePath, ReadFile);

        //Rensa konsolen efter tre sekunder.
        System.Threading.Thread.Sleep(3000);
        Console.Clear();
        }
    }
}

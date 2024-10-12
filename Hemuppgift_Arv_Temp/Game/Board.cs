using Hemuppgift_Arv_Temp.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp
{
    public class Board
    {
        //Attribut
        public int NoPins { get; set; }
       
        
        
        //Metoder

        //Metod som skapar en lista med så många pins som man vill spela med
        public void SetUp(int input) 
        {
            while (NoPins <8) 
            { 
                if (input > 7)
                {
                    NoPins = input;
                    Console.WriteLine($"Spelet är förberett med {NoPins} st nypolerade stickor. LET´S GET READY TO RUMBLE!!");
                }
                else 
                { 
                    Console.WriteLine("det måste finnas minst 8 pins skriv in ett nytt antal");
                    string newnmbr = Console.ReadLine();
                    
                    bool isnumber = int.TryParse(newnmbr, out int nmbr);
                    if (isnumber)
                    {
                       NoPins = nmbr;
                    }
                    else
                    {
                        Console.WriteLine("Fortfarande för lågt nummer eller fel inmatning");
                    }
                    
                }
            }
        }
        //Metod för att ta pins
        public void TakePins(int input)
        {
            bool loop = true;
            while (loop == true)
            {
                if (input > 0 && input < 3 && input <= NoPins)
                {
                    NoPins -= input;
                    Console.WriteLine($"Nu finns det {NoPins} kvar");
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Du måste välja 1 eller 2 pins och du kan inte välja fler än vad som finns på brädet, ganska logiskt va?? Prova igen så får vi se om du lyckas nu");
                    string newnmbr = Console.ReadLine();

                    bool isnumber = int.TryParse(newnmbr, out int nmbr);
                    if (isnumber)
                    {
                        input = nmbr;
                    }
                    else
                    {
                        Console.WriteLine("Antingen försöker du ta fler pins än vad som finns eller så är det fel inmatning eller så driver du med mig...");
                    }
                }

            }
        }
        //Metod som returnerar hur många pins som är kvar på brädet
        public int GetNoPins() 
        { 
            return NoPins; 
        }

    }
}

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
                    Console.WriteLine("Du måste välja en eller 2 pins och du kan inte välja fler än vad som finns på brädet, prova igen");
                    string newnmbr = Console.ReadLine();

                    bool isnumber = int.TryParse(newnmbr, out int nmbr);
                    if (isnumber)
                    {
                        input = nmbr;
                    }
                    else
                    {
                        Console.WriteLine("Antingen försöker du ta fler pins än vad som finns eller så är det fel inmatning");
                    }
                }

            }
        }

        public int GetNoPins() 
        { 
            return NoPins; 
        }

    }
}

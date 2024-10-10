using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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
            if (input > 0)
            {
                NoPins = input;
                Console.WriteLine("Spelet är förberett varsågod att börja");
            }
            else { Console.WriteLine("det måste finnas pins"); }
           
        }

        public void TakePins(int input)
        {
           NoPins -= input;
            Console.WriteLine($"Nu finns det {NoPins} kvar");
        }

        public int GetNoPins() 
        { 
            return NoPins; 
        }

    }
}

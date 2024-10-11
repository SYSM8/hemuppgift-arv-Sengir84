using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    internal class HumanPlayer : Player
    {
        //Mänsklig ta pins metod
        public override int TakePins(Board board)
        {
            int nmbr;
            bool isnumber = false;

            while (!isnumber) 
            {
                Console.WriteLine("Hur många pins vill du ta?");
                string input = Console.ReadLine();

                isnumber = int.TryParse(input, out nmbr);

                if (isnumber) 
                {
                    board.TakePins(nmbr); 
                    return board.NoPins; 
                }
                else 
                {
                    Console.WriteLine("Vet du hur tråkigt det är med felhantering?? Skriv rätt nu för fan!");
                   
                }
            }
            return board.NoPins; //Hit borde den aldrig nå
        }
    }
}

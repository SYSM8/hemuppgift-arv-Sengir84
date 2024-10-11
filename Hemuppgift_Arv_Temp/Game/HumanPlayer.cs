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
            Console.WriteLine("Hur många pins vill du ta?");
            int input = Convert.ToInt32(Console.ReadLine());
            board.TakePins(input);
            return board.NoPins;
            
            


        }
        
    }
}

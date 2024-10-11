using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class ComputerPlayer : Player
    {
        //Metod för att Datorn ska ta 1 eller 2 stickor på random från brädet
        public override int TakePins(Board board) 
        {
            Random rng = new Random();  
            int cptTake = rng.Next(1,3);
            Console.WriteLine($"Motståndaren tar {cptTake}");
            board.TakePins(cptTake);
            return board.NoPins;
        }
    }
}

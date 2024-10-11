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
        
        public void CptPlayer(string user)
        {
            ComputerPlayer computerPlayer = new ComputerPlayer();
            computerPlayer.Playr(user);

        }
        public override int TakePins(Board board) 
        {
            Random rng = new Random();  
            int cptTake = rng.Next(1,3);
            board.NoPins = board.NoPins - cptTake;
            return board.NoPins;
        }
    }
}

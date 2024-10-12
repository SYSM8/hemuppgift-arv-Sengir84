using Hemuppgift_Arv_Temp.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp
{
    public class AdvancedComputer : Player
    {
        
        public override int TakePins(Board board)
        {
            int leavepins = board.NoPins % 3;

            if (board.NoPins == 1 || board.NoPins == 2)
            {
                if (board.NoPins == 1)
                {
                    board.TakePins(1);
                    return board.NoPins;
                }
                else
                {
                    board.TakePins(2);
                    return board.NoPins;
                }
            }
            //om leavepins = 0 är vi i en multipel av 3
            else if (leavepins == 0 || leavepins == 1)
            {
                board.TakePins(1);
                return board.NoPins;
            }
            else if (leavepins == 2)
            {
                board.TakePins(2);
                return board.NoPins;
            }
            return 0; // hit borde man inte komma
        }
    }
}

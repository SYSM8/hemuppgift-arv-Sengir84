using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    //abstract klass som ärvs av ComputerPlayer och HumanPlayer
    public abstract class Player
    {
        //Fields
        public string UserId { get; set; }

        //Metoder
        
        // Sätter UserId
        public void Playr(string userId)
        {
           UserId = userId;
        }
        //Returnerar userid
        public string GetUserId()
        {
            return UserId;
        }
        //Takepins metoden som overridas i de ComputerPlayer och HumanPlayer
        public abstract int TakePins(Board board);
       
    }
    
}

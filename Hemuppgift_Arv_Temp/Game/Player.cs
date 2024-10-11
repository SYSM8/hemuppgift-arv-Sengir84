using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public abstract class Player
    {
        //Fields
        public string UserId { get; set; }

        //Metoder
        public void Playr(string userId)
        {
           UserId = userId;
        }
        public string GetUserId()
        {
            return UserId;
        }
        public abstract int TakePins(Board board);
       
    }
    
}

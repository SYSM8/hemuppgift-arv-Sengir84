using Hemuppgift_Arv_Temp.Game;
using System.Threading.Channels;

namespace Hemuppgift_Arv_Temp
{
    public class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            //Skapa objektet board
            Board board = new Board();

            //Start av spelet
            Console.WriteLine("Hur många pins vill du spela med?");
            board.SetUp(InputHandling(Console.ReadLine()));

            Console.WriteLine("Hur många pins vill du ta?");
            board.TakePins(InputHandling(Console.ReadLine()));

            ComputerPlayer cptPlayer = new ComputerPlayer();
            cptPlayer.Playr("Hans");
            Console.WriteLine($"Du ska möta {cptPlayer.UserId}");
            cptPlayer.TakePins(board);
            HumanPlayer human=new HumanPlayer();
            human.TakePins(board);
            
        }









        //Metod för att kontrollera att det är en siffra annars returneras noll
        static int InputHandling(string input)
        {
            bool isnumber = int.TryParse(input, out int nmbr);
            if (isnumber)
            {
                return nmbr;
            }
            else 
            {
                return 0;             
            }
            
        }

    }
}

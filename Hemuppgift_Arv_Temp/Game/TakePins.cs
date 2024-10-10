using System.Threading.Channels;

namespace Hemuppgift_Arv_Temp
{
    public class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.WriteLine("hur många pins?");
            
            board.SetUp(InputHandling(Console.ReadLine()));
            
            
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

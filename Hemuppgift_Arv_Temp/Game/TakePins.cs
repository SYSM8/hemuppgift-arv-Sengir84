using Hemuppgift_Arv_Temp.Game;
using System.Globalization;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace Hemuppgift_Arv_Temp
{
    public class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            //Skapa objekteten Board, ComputerPlayer och HumanPlayer
            Board board = new Board();
            
            Player cptPlayer = new ComputerPlayer();
            
            Player human = new HumanPlayer();

            //Namnge spelare
            Console.WriteLine("Spelarens namn?");
            human.Playr(Console.ReadLine());

            Console.WriteLine("Datorns namn?");
            cptPlayer.Playr(Console.ReadLine());

            //Välj antal pins att börja med
            Console.WriteLine("Hur många pins vill du spela med?");
            board.SetUp(InputHandling(Console.ReadLine()));
           
            //Coinflip för att bestämma vem som börjar
            Console.WriteLine("Vem börjar? 1 eller 2");
            string choice = Console.ReadLine();
            //Bool som sätter vem som börjar efter coinflip
            bool playerstart = CoinFlip(choice);

            //Gameplay
            while (board.NoPins > 0)
            {
                if (playerstart == true)
                {
                    human.TakePins(board);
                    if (board.NoPins == 0) 
                    {
                        Console.WriteLine("Du tog den sista! Grattis osv");
                    }
                }
                else if (playerstart == false)
                {
                    cptPlayer.TakePins(board);
                    if (board.NoPins == 0)
                    {
                        Console.WriteLine($"{cptPlayer.UserId} tog den sista! Var detta verkligen det bästa du kunde åstadkomma??");
                    }
                }
                if (playerstart == true) 
                { 
                    playerstart = false;
                }
                else
                {
                    playerstart = true;
                }
            }
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

        static bool CoinFlip(string input)
        {
                     
            int choice = InputHandling(input);
            Random rng = new Random();
            int flip = rng.Next(1, 3);
            Console.WriteLine(flip);
            if (flip == 1)
            {
                
                if (flip == choice)
                {
                    Console.WriteLine("Congrats you start");
                    return true;
                }
                else
                {
                    Console.WriteLine("You failed the flip, computer starts");
                    return false;
                }
                
            }
            else if (flip == 2)
            {
                
                if (choice == flip)
                {
                    Console.WriteLine("Congrats you start");
                    return true;

                }
                else
                {
                    Console.WriteLine("You failed the flip, computer starts");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("Hit borde den aldrig komma");
                return false;
            }
           
        }

    }
}

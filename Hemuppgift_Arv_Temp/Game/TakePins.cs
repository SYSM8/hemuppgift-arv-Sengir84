using Hemuppgift_Arv_Temp.Game;
using System.Drawing;
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
            Board board = new Board();
            Player human = new HumanPlayer();
            Player cptPlayer;
            Console.WriteLine("Vad heter du?");
            human.PlayerName(Console.ReadLine()); 
           
                        
            //Namnge spelare
            Console.WriteLine($"Välkommen till Take pins {human.PlayerName} \n---------------------------------------------------");
            Console.WriteLine("\n             Meny\n---------------------------");
            Console.WriteLine("1) Svårighetsgrad");
            Console.WriteLine("3) Starta spelet");
            Console.WriteLine("5) Avsluta");

            switch (InputHandling(Console.ReadLine()))
            {
                case 1:
                    { 
                        Console.WriteLine("Svårighetsgrad 1 = Lätt, 2 = Svår");
                        int val = InputHandling(Console.ReadLine());
                        if (val == 1)
                        {
                            cptPlayer = new ComputerPlayer();
                            Console.WriteLine("Vill du välja namn på datorspelaren? (J/N)");
                            string chooseName = Console.ReadLine();
                            chooseName.ToUpper();
                           
                            if (chooseName == "J")
                            {
                                Console.Write("Namn:");
                                cptPlayer.PlayerName(Console.ReadLine());
                                break;
                            }
                            else if (chooseName == "N")
                            {
                                cptPlayer.PlayerName("Easy computer");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Skriv bara J eller N");
                                break;
                            }
                            
                        }
                        else if (val == 2)
                        {
                            cptPlayer = new AdvancedComputer();
                            Console.WriteLine("Vill du välja namn på datorspelaren? (J/N)");
                            string chooseName = Console.ReadLine();
                            chooseName.ToUpper();
                            if (chooseName == "J")
                            {
                                Console.Write("Namn:");
                                cptPlayer.PlayerName(Console.ReadLine());
                                break;
                            }
                            else if (chooseName == "N")
                            {
                                cptPlayer.PlayerName("Hard computer");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Skriv bara J eller N");
                                break;
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Du kan bara välja 1 eller 2");
                            break;
                        }
                    }
                
                case 2: 
                    {
                        //Skapa objekteten Board, ComputerPlayer och HumanPlayer
                        
                        board.NoPins = 21;
                        break;
                    }
            }
           

            

            //Välj antal pins att börja med
            Console.WriteLine("Hur många pins vill du spela med? (minst 8)");
            string input = Console.ReadLine();
            board.SetUp(InputHandling(input));
            
           
            //Coinflip för att bestämma vem som börjar
            Console.WriteLine("50/50 vem som börjar. Välj 1 eller 2");
            string choice = Console.ReadLine();
            //Bool som sätter vem som börjar efter coinflip
            bool playerstart = CoinFlip(choice);

            //Gameplay
            while (board.NoPins > 0)
            {
                //Spelares tur
                if (playerstart == true)
                {
                    human.TakePins(board);
                    if (board.NoPins == 0) 
                    {
                        Console.WriteLine("Du tog den sista! Grattis osv");
                    }
                }
                //Datorns tur
                else if (playerstart == false)
                {
                    cptPlayer.TakePins(board);
                    if (board.NoPins == 0)
                    {
                        Console.WriteLine($"{cptPlayer.UserId} tog den sista! Var detta verkligen det bästa du kunde åstadkomma??");
                    }
                }
                //if sats för att ändra vilken spelares tur det är
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
        //Coinflip metod för att bestämma vem som börjar
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
                    Console.WriteLine("Happ, grattis antar jag. Du får börja!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Hur svårt ska det vara att gissa rätt på en 50/50, SKÄRP DIG NU! Jaja jag börjar väl då");
                    return false;
                }
                
            }
            else if (flip == 2)
            {
                
                if (choice == flip)
                {
                    Console.WriteLine("Oooohh du gissa rätt på en 50/50 ladida... Jaja du får väl börja då");
                    return true;

                }
                else
                {
                    Console.WriteLine("Hahahahahahaha... Jag börjar");
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

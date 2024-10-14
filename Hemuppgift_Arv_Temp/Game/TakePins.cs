using Hemuppgift_Arv_Temp.Game;
using System.Drawing;
using System.Globalization;
using System.Security.Principal;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace Hemuppgift_Arv_Temp
{
    //SVAR PÅ FRÅGORNA
    //A) Superklass eller Basklass
    //B) Inga, det går inte att skapa en new Player för att den är abstract och de andra har ingen konstruktor för att ta emot ett namn
    public class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            //Här skapas Board/Human player och computer player
      #region Objekt
            Board board = new Board();
            Player human = new HumanPlayer();
            Player cptPlayer = new ComputerPlayer();
            cptPlayer.UserId = "The grinch";
       #endregion
            //Namnge spelare
            Console.WriteLine("Vad heter du?");
            human.PlayerName(Console.ReadLine());
            

      #region Meny
            bool loop = true;
            while (loop)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Välkommen till Take pins {human.UserId} \n---------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n\tMeny\n---------------------------");
                Console.WriteLine("1) Svårighetsgrad");
                Console.WriteLine("2) Starta spelet");
                Console.WriteLine("3) Avsluta");

                switch (InputHandling(Console.ReadLine()))
                {
                    //Välj svårighetsgrad på AI och möjlighet att döpa den. Default = Lätt
                    case 1:
                        {
                            Console.WriteLine("Svårighetsgrad 1 = Lätt, 2 = Svår");
                            int val = InputHandling(Console.ReadLine());
                           //Lätt AI som tar random hela tiden
                            if (val == 1)
                            {
                                cptPlayer = new ComputerPlayer();
                             //Möjlighet att döpa motståndaren om man vill
                                Console.WriteLine("Vill du välja namn på datorspelaren? (J/N)");
                                string chooseName = Console.ReadLine();

                                if (chooseName.ToUpper() == "J")
                                {
                                    Console.Write("Namn:");
                                    cptPlayer.PlayerName(Console.ReadLine());
                                    loop = false;
                                    break;
                                }
                                else if (chooseName.ToUpper() == "N")
                                {
                                    cptPlayer.PlayerName("Easy computer");
                                    loop = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Skriv bara J eller N");
                                    break;
                                }

                            }
                            //Hard AI som försöker ta så att där är en multipel av 3 kvar till motståndaren
                            else if (val == 2)
                            {
                                cptPlayer = new AdvancedComputer();
                             //Möjlighet att döpa motståndaren om man vill   
                                Console.WriteLine("Vill du välja namn på datorspelaren? (J/N)");
                                string chooseName = Console.ReadLine();

                                if (chooseName.ToUpper() == "J")
                                {
                                    Console.Write("Namn:");
                                    cptPlayer.PlayerName(Console.ReadLine());
                                    loop = false;
                                    break;
                                }
                                else if (chooseName.ToUpper() == "N")
                                {
                                    cptPlayer.PlayerName("Hard computer");
                                    loop = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Skriv bara J eller N");
                                    break;
                                }

                            }
                            //Om något annat än 1 eller 2 skrivs in
                            else
                            {
                                Console.WriteLine("Du kan bara välja 1 eller 2");
                                break;
                            }
                        }
                        //Startar spelet
                    case 2:
                        {
                            loop = false;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Ger du upp redan fegis?");
                            Environment.Exit(0);
                            break;
                        }
                }
            }
            #endregion


            #region Coinflip
            //Coinflip för att bestämma vem som börjar
            string choice = "temp";
            bool flip = true;
            while (flip == true)
            {
                Console.WriteLine("50/50 vem som börjar. Välj 1 eller 2");
                choice = Console.ReadLine();

                if (choice == "1" || choice == "2")
                {
                    flip = false;
                }
                else
                {
                    Console.WriteLine("Välj 1 eller 2");
                }
            }
            #endregion

           //Bool som avgör vems runda det är
           bool playerstart = CoinFlip(choice);
           
           board.SetUp(21);
           //En readline för att man ska hinna läsa utskriften innan fönstret rensas
           Console.ReadLine();
           //Rensar fönstret från all gammal text
           Console.Clear();
 
 #region Gameplay
            //Gameplay
            while (board.NoPins > 0)
            {
                
                //Spelares tur
                if (playerstart == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"-------------------------------\nNu är det {human.UserId} som spelar.");
                    human.TakePins(board);
                    //kontrollerar om spelaren tagit den sista
                    if (board.NoPins == 0) 
                    {
                        Console.WriteLine("Du tog den sista! Grattis osv");
                    }
                }
                //Datorns tur
                else if (playerstart == false)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"-------------------------------\nNu är det {cptPlayer.UserId} som spelar.");
                    cptPlayer.TakePins(board);
                    //Kontrollerar om datorn tagit den sista
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
            #endregion
        }




        #region Metoder

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
            Console.WriteLine($"Du gissade på: {input} Det blev: {flip}\n");

            
                //Om rng blir 1
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
                //Om rng blir 2
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
                //Krävdes en retur här men den borde aldrig komma hit
                else
                {
                    Console.WriteLine("Hit borde den aldrig komma");
                    return false;
                }
               

        }
        #endregion
    }
}

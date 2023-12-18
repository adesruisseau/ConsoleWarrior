using ConsoleApp1.Assets.Encounters;
using ConsoleApp1.Assets.Models;
using ConsoleApp1.Assets.Player;
using ConsoleApp1.Assets.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RunGame();   
        }

        static void RunGame(bool isRestart = false, Player player = null)
        {
            bool skipRestart = false;
            Console.Clear();
            Console.WriteLine(AsciiArt.CoverArt());
            if (isRestart)
            {
                Console.WriteLine("Do you want to skip the intro? [Y]/[n]");
                var skipIntroInput = Console.ReadLine().ToString().ToLower();
                if (skipIntroInput.Equals("y"))
                {
                    skipRestart = true;
                    player = Player.CreatePlayer(player.Name);
                }
            }

            if (!skipRestart)
            {
                Console.WriteLine("TUTORIAL: ");
                Console.WriteLine("This is a text-based adventure, and will often require your input for actions.");
                Console.WriteLine();
                Console.WriteLine("You will often see text like this:");
                Console.WriteLine("Do you want to complete Action [1]    Action [2]    Action [3]");
                Console.WriteLine("Enter the corresponding                       ^               ");
                Console.WriteLine("key for the decision you choose.              |               ");
                Console.WriteLine("For example, to choose Action 2     ----------.               ");
                Console.WriteLine("Type the number '2' and press enter.                          ");
                Console.WriteLine();
                Console.WriteLine("Be mindful of the choices you make, and good luck.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();


                Console.WriteLine("Please enter your name: ");
                var name = Console.ReadLine();
                player = Player.CreatePlayer(name);

                Console.Clear();
                Console.WriteLine(AsciiArt.Door(player));

                EncounterEngine.Encounter1();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                EncounterEngine.Encounter2(player);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.Clear();

            }
            RoomEngine.GenerateNextArea(player);


            if (player.Died)
            {
                Console.WriteLine("Sorry you died. Play again?");
                Console.WriteLine("Press any key to restart ...");
                Console.ReadKey();
                Console.ReadKey();
                RunGame(true, player);
            }
            
        }

        
    }
}

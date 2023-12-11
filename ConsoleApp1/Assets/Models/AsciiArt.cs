using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Assets.Enemies;
using ConsoleApp1.Assets.Player;
using ConsoleApp1.Assets.Rooms;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1.Assets.Models
{
    public static class AsciiArt
    {
        public static StringBuilder CoverArt()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("   _____ ____  _   _  _____  ____  _      ______ ");
            sb.AppendLine("  / ____/ __ \\| \\ | |/ ____|/ __ \\| |    |  ____| ");
            sb.AppendLine(" | |   | |  | |  \\| | (___ | |  | | |    | |__   ");
            sb.AppendLine(" | |   | |  | | . ` |\\___ \\| |  | | |    |  __|  ");
            sb.AppendLine(" | |___| |__| | |\\  |____) | |__| | |____| |____ ");
            sb.AppendLine("  \\_____\\____/|_| \\_|_____/ \\____/|______|______|");
            sb.AppendLine(" __          __     _____  _____  _____ ____  _____");
            sb.AppendLine(" \\ \\        / /\\   |  __ \\|  __ \\|_   _/ __ \\|  __ \\ ");
            sb.AppendLine("  \\ \\  /\\  / /  \\  | |__) | |__) | | || |  | | |__) |");
            sb.AppendLine("   \\ \\/  \\/ / /\\ \\ |  _  /|  _  /  | || |  | |  _  / ");
            sb.AppendLine("    \\  /\\  / ____ \\| | \\ \\| | \\ \\ _| || |__| | | \\ \\ ");
            sb.AppendLine("     \\/  \\/_/    \\_\\_|  \\_\\_|  \\_\\_____\\____/|_|  \\_\\");
            sb.AppendLine("---------------------------------------------------------------");
            sb.AppendLine("-----------By: GalaxyRacerVR & Alexstrips (2023)---------------");
            sb.AppendLine("---------------------------------------------------------------");
            return sb;
        }

        public static StringBuilder Door(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("      ______              ");
            sb.AppendLine("   ,-' ;  ! `-.           ");
            sb.AppendLine("  / :  !  :  . \\    (\\   ");
            sb.AppendLine(" |_ ;   __:  ;  |   .'.   ");
            sb.AppendLine(" )| .  :)(.  !  |   | |   ");
            sb.AppendLine(" |\"    (##)  _  |   | |   ");
            sb.AppendLine(" |  :  ;`'  (_) (  `````  ");
            sb.AppendLine(" |  :  :  .     |   ---   ");
            sb.AppendLine(" )_ !  ,  ;  ;  |         ");
            sb.AppendLine(" || .  .  :  :  |         ");
            sb.AppendLine(" |\" .  |  :  .  |        ");
            sb.AppendLine(" |mt-2_;----.___|         ");
            GetPlayerInfoFooter(player, sb);
            return sb;
        }

        public static StringBuilder Sword(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  ,.");
            sb.AppendLine("  \\%`.");
            sb.AppendLine("   `.%`.");
            sb.AppendLine("     `.%`.");
            sb.AppendLine("       `.%`.");
            sb.AppendLine("         `.%`.");
            sb.AppendLine("           `.%`.    __");
            sb.AppendLine("             `.%`.  \\ \\");
            sb.AppendLine("               `.%`./_/");
            sb.AppendLine("                 `./ /.");
            sb.AppendLine("                __ /\\/:/;.");
            sb.AppendLine("                \\__ /  `:/;.");
            sb.AppendLine("                        `:/;.,    ");
            sb.AppendLine("                          `:/ ;");
            GetPlayerInfoFooter(player, sb);
            return sb;
        }






        public static StringBuilder StraightHallwayTwoDoors(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" .  .  .  .  /   \\  . . .  . .");
            sb.AppendLine(". .  .  .  ./-----\\.  .  .. . ");
            sb.AppendLine(".  . ----. /       \\ ---- .  .");
            sb.AppendLine(" .  .|  | /---------\\|  |. .. ");
            sb.AppendLine(".  . | o|/           |o |.  .  ");
            sb.AppendLine(" .  .|  /-------------\\ | .  .");
            sb.AppendLine(". .  | /               \\|. .  ");
            sb.AppendLine(" .  .|/                 \\ .  .");
            sb.AppendLine(".  . /-------------------\\ .  ");
            sb.AppendLine(" .. /                     \\  .");
            sb.AppendLine(" . /                       \\. ");
            sb.AppendLine(". /                         \\.");
            sb.AppendLine(" /---------------------------\\");
            GetPlayerInfoFooter(player, sb);
            return sb;
        }

        public static StringBuilder StraightHallwayOneDoor(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("  .  .  .  .  /   \\  . . .  . .");
            Console.WriteLine(".. .  .  .  ./-----\\.  .  .. . ");
            Console.WriteLine("..  . ----. /       \\ . . .  . ");
            Console.WriteLine("  .  .|  | /---------\\   . ..  ");
            Console.WriteLine("..  . | o|/           \\   .  . ");
            Console.WriteLine("  .  .|  /-------------\\   .  .");
            Console.WriteLine(".. .  | /               \\ . .  ");
            Console.WriteLine("  .  .|/                 \\ .  .");
            Console.WriteLine("..  . /-------------------\\ .  ");
            Console.WriteLine("  .. /                     \\  .");
            Console.WriteLine("  . /                       \\. ");
            Console.WriteLine(".. /                         \\.");
            Console.WriteLine("  /---------------------------\\");
            GetPlayerInfoFooter(player, sb);
            
            return sb;
        }

        public static StringBuilder DeadEndHallwayTwoDoors(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" .  .  . .|-_-_-_-_-|. . .  . .");
            sb.AppendLine(". .  .  . |_-_-_-_-_|  .  .. . ");
            sb.AppendLine(".  . ----.|-_-_-_-_-|---- .  . ");
            sb.AppendLine(" .  .|  | /---------\\|  |. .. ");
            sb.AppendLine(".  . | o|/           |o |.  .  ");
            sb.AppendLine(" .  .|  /-------------\\ | .  .");
            sb.AppendLine(". .  | /               \\|. .  ");
            sb.AppendLine(" .  .|/                 \\ .  .");
            sb.AppendLine(".  . /-------------------\\ .  ");
            sb.AppendLine(" .. /                     \\  .");
            sb.AppendLine(" . /                       \\. ");
            sb.AppendLine(". /                         \\.");
            sb.AppendLine(" /---------------------------\\");
            GetPlayerInfoFooter(player, sb);
            return sb;
        }


        public static StringBuilder RoomOneDoor(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/////////////////////////////|______________________________________________");
            sb.AppendLine("/////////////////////////////|______________________________________________");
            sb.AppendLine("/////////////////////////////|______________________________________________");
            sb.AppendLine("/////////////////////////////|______________________________________________");
            sb.AppendLine("/////////////////////////////|_________|=======|____________________________");
            sb.AppendLine("/////////////////////////////|_________E       |____________________________");
            sb.AppendLine("///////////////,'|///////////|_________|       |_______________________(0)__");
            sb.AppendLine("////////////.' | |///////////|_________|       |________________________T___");
            sb.AppendLine("///////////|   | |///////////|_________|     -6|____________________________");
            sb.AppendLine("///////////|   |/|///////////|_________E       |____________________________");
            sb.AppendLine("///////////|  /| |///////////|_________|       |____________________________");
            sb.AppendLine("///////////|/  | |//////////                                                ");
            sb.AppendLine("///////////|   |.'/////////                                                 ");
            sb.AppendLine("///////////|  .'//////////                                                  ");
            sb.AppendLine("///////////|.'///////////                                                   ");
            sb.AppendLine("////////////////////////                                                    ");
            sb.AppendLine("///////////////////////                                                     ");
            sb.AppendLine("//////////////////////                                                      ");
            sb.AppendLine("/////////////////////                                                       ");
            sb.AppendLine("////////////////////                                                        ");
            GetPlayerInfoFooter(player, sb);
            return sb;
        }

        public static StringBuilder Room2(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ____________________________________________________________________");
            sb.AppendLine("| **  **  **  **  **  **  **  **  **  **  **  **  **  **  **  **  ** |");
            sb.AppendLine("|\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/\\__/| ");
            sb.AppendLine("|!!!!!!!!!!!!}                                          {!!!!!!!!!!!!|");
            sb.AppendLine("|!!!!!!!!!!!}                                            {!!!!!!!!!!!|");
            sb.AppendLine("|!!!!!!!!!!}                                              {!!!!!!!!!!|");
            sb.AppendLine("|!!!!!!!!!}                  |   |                         {!!!!!!!!!|");
            sb.AppendLine("|!!!!!!!!}                  /     \\             _           {!!!!!!!!|");
            sb.AppendLine("|!!!!!!!}                  =========           /_\\           {!!!!!!!|");
            sb.AppendLine("|!!!!!!}          .===.     |.....|     .===.   |             {!!!!!!|");
            sb.AppendLine("|!!!!!!}_________o.....o____|:___:|____o.....o__|_____________{!!!!!!|");
            sb.AppendLine("|!!!!!!}         |=====|    =======    |=====| _|_            {!!!!!!|");
            sb.AppendLine("|,-,!!}                                                        {!!,-,|");
            sb.AppendLine("|,-,!}                                                          {!,-,|");
            sb.AppendLine("|,-,}                                                            {,-,|");
            sb.AppendLine("|,-}                                                              {-,|");
            GetPlayerInfoFooter(player, sb);
            return sb;
        }


        public static StringBuilder Room3(Player.Player player)
        {
            StringBuilder sb = new StringBuilder();
              sb.AppendLine("           _I_");
              sb.AppendLine("         .~'_`~.");
              sb.AppendLine("   /(  ,^ .~ ~. ^.  )\\");
              sb.AppendLine("   \\ \\/ .^ |   ^. \\/ /");
              sb.AppendLine("    Y  /   |     \\  Y            ___.oOo.___ ");
              sb.AppendLine("    | Y    |      Y |           |           |");
              sb.AppendLine("    | |    |      | |           |           |");
              sb.AppendLine("    | |   _|___   | |           |           |");
              sb.AppendLine("    | |  /____/|  | |           |           |");
              sb.AppendLine("    |.| |   __/|__|.|           |           |");
              sb.AppendLine("    |.| |   __/|  |.|          _|___________|_");
              sb.AppendLine("    |:| |   __//  |:|         '^^^^^^^^^^^^^^^`");
              sb.AppendLine("    |:| |_____/   |:|");
              sb.AppendLine("____|_|/          |_|_____________________________");
              sb.AppendLine("____]H[           ]H[_____________________________");
              sb.AppendLine("     /             \\");
              GetPlayerInfoFooter(player, sb);
            return sb;
        }






        public static StringBuilder GetRoomAscii(RoomOrHallTypes roomType, Player.Player player)
        {
            return GetRoomAscii((int)roomType, player);
        }

        public static StringBuilder GetRoomAscii(int roomType, Player.Player player)
        {
            switch (roomType)
            {
                case 0:
                    return RoomOneDoor(player);
                case 1:
                    return DeadEndHallwayTwoDoors(player);
                case 2:
                    return StraightHallwayTwoDoors(player);
                case 3:
                    return Room2(player);
                case 4:
                    return Room3(player);
                default: 
                    return null;

            }
        }


        public static StringBuilder GoblinArt(Player.Player player, EnemyBase enemy)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("             ,      ,            ");
            sb.AppendLine("            /(.-\"\"-.)\\           ");
            sb.AppendLine("        |\\  \\/      \\/  /|       ");
            sb.AppendLine("        | \\ / =.  .= \\ / |       ");
            sb.AppendLine("        \\( \\   o\\/o   / )/       ");
            sb.AppendLine("         \\_, '-/  \\-' ,_/        ");
            sb.AppendLine("           /   \\__/   \\          ");
            sb.AppendLine("           \\ \\__/\\__/ /          ");
            sb.AppendLine("         ___\\ \\|--|/ /___        ");
            sb.AppendLine("       /`    \\      /    `\\      ");
            sb.AppendLine("      /       '----'       \\     ");
            GetPlayerInfoFooter(player, sb);
            GetEnemyInfoFooter(enemy, sb);
            return sb;
        }

        public static StringBuilder SkeletonArt(Player.Player player, EnemyBase enemy)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                              _.--\"\"-._");
            sb.AppendLine("  .                         .\"         \".");
            sb.AppendLine(" / \\    ,^.         /(     Y             |      )\\");
            sb.AppendLine("/   `---. |--'\\    (  \\__..'--   -   -- -'\"\"-.-'  )");
            sb.AppendLine("|        :|    `>   '.     l_..-------.._l      .'");
            sb.AppendLine("|      __l;__ .'      \"-.__.||_.-'v'-._||`\"----\"");
            sb.AppendLine(" \\  .-' | |  `              l._       _.'");
            sb.AppendLine("  \\/    | |                   l`^^'^^'j");
            sb.AppendLine("        | |                _   \\_____/     _");
            sb.AppendLine("        j |               l `--__)-'(__.--' |");
            sb.AppendLine("        | |               | /`---``-----'\"1 |  ,-----.");
            sb.AppendLine("        | |               )/  `--' '---'   \\'-'  ___  `-.");
            sb.AppendLine("        | |              //  `-'  '`----'  /  ,-'   I`.  \\");
            sb.AppendLine("      _ L |_            //  `-.-.'`-----' /  /  |   |  `. \\");
            sb.AppendLine("     '._' / \\         _/(   `/   )- ---' ;  /__.J   L.__.\\ :");
            sb.AppendLine("      `._;/7(-.......'  /        ) (     |  |            | |");
            sb.AppendLine("      `._;l _'--------_/        )-'/     :  |___.    _._./ ;");
            sb.AppendLine("        | |                 .__ )-'\\  __  \\  \\  I   1   / /");
            sb.AppendLine("        `-'                /   `-\\-(-'   \\ \\  `.|   | ,' /");
            sb.AppendLine("                           \\__  `-'    __/  `-. `---'',-'");
            sb.AppendLine("                              )-._.-- (        `-----'");
            GetPlayerInfoFooter(player, sb);
            GetEnemyInfoFooter(enemy, sb);
            return sb;
        }

        public static StringBuilder VampireArt(Player.Player player, EnemyBase enemy)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("              __.......__");
            sb.AppendLine("            .-:::::::::::::-.");
            sb.AppendLine("          .:::''':::::::''':::.");
            sb.AppendLine("        .:::'     `:::'     `:::. ");
            sb.AppendLine("   .'\\  ::'   ^^^  `:'  ^^^   '::  /`.");
            sb.AppendLine("  :   \\ ::   _.__       __._   :: /   ;");
            sb.AppendLine(" :     \\`: .' ___\\     /___ `. :'/     ; ");
            sb.AppendLine(":       /\\   (_|_)\\   /(_|_)   /\\       ;");
            sb.AppendLine(":      / .\\   __.' ) ( `.__   /. \\      ;");
            sb.AppendLine(":      \\ (        {   }        ) /      ; ");
            sb.AppendLine(" :      `-(     .  ^\"^  .     )-'      ;");
            sb.AppendLine("  `.       \\  .'<`-._.-'>'.  /       .'");
            sb.AppendLine("    `.      \\    \\;`.';/    /      .'");
            sb.AppendLine(" jgs  `._    `-._       _.-'    _.'");
            sb.AppendLine("       .'`-.__ .'`-._.-'`. __.-'`.");
            sb.AppendLine("     .'       `.         .'       `.");
            sb.AppendLine("   .'           `-.   .-'           `.");
            GetPlayerInfoFooter(player, sb);
            GetEnemyInfoFooter(enemy, sb);
            return sb;
        }


        public static StringBuilder MinotaurArt(Player.Player player, EnemyBase enemy)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("        .      .             ");
            sb.AppendLine("        |\\____/|             ");
            sb.AppendLine("       (\\|----|/)            ");
            sb.AppendLine("        \\ 0  0 /             ");
            sb.AppendLine("         |    |          ");
            sb.AppendLine("      ___/\\../\\____          ");
            sb.AppendLine("     /     --       \\            ");
            sb.AppendLine("    /  \\         /   \\           ");
            sb.AppendLine("   |    \\___/___/(   |           ");
            sb.AppendLine("   \\   /|  }{   | \\  )           ");
            sb.AppendLine("    \\  ||__}{__|  |  |           ");
            sb.AppendLine("     \\  |;;;;;;;\\  \\ / \\_______          ");
            sb.AppendLine("      \\ /;;;;;;;;| [,,[|======'          ");
            sb.AppendLine("        |;;;;;;/ |     /             ");
            sb.AppendLine("        ||;;|\\   |           ");
            sb.AppendLine("        ||;;/|   /           ");
            sb.AppendLine("        \\_|:||__|            ");
            sb.AppendLine("         \\ ;||  /            ");
            sb.AppendLine("         |= || =|            ");
            sb.AppendLine("         |= /\\ =|            ");
            sb.AppendLine("         /_/  \\_\\            ");
            GetPlayerInfoFooter(player, sb);
            GetEnemyInfoFooter(enemy, sb);
            return sb;
        }

        public static StringBuilder GhostArt(Player.Player player, EnemyBase enemy)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("            .--,   ");
            sb.AppendLine("           /  (   ");
            sb.AppendLine("          /    \\   ");
            sb.AppendLine("         /      \\    ");
            sb.AppendLine("        /  0  0  \\   ");
            sb.AppendLine("((()   |    ()    |   ()))   ");
            sb.AppendLine("\\  ()  (  .____.  )  ()  /   ");
            sb.AppendLine(" |` \\_/ \\  `\"\"`  / \\_/ `|   ");
            sb.AppendLine(" |       `.'--'.`       |   ");
            sb.AppendLine("  \\        `\"\"`        /   ");
            sb.AppendLine("   \\                  /   ");
            sb.AppendLine("    `.              .'    ,   ");
            sb.AppendLine("     |`             |  _.'|   ");
            sb.AppendLine("     |              `-'  /   ");
            sb.AppendLine("     \\                 .'   ");
            sb.AppendLine("      `.____________.-'   ");
            GetPlayerInfoFooter(player, sb);
            GetEnemyInfoFooter(enemy, sb);
            return sb;
        }

        public static StringBuilder SpiderArt(Player.Player player, EnemyBase enemy)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("              ( ");
            sb.AppendLine("               ) ");
            sb.AppendLine("              ( ");
            sb.AppendLine("        /\\  .-\"\"\"-.  /\\ ");
            sb.AppendLine("       //\\\\/  ,,,  \\//\\\\ ");
            sb.AppendLine("       |/\\| ,;;;;;, |/\\| ");
            sb.AppendLine("       //\\\\\\;-\"\"\"-;///\\\\ ");
            sb.AppendLine("      //  \\/   .   \\/  \\\\ ");
            sb.AppendLine("     (| ,-_| \\ | / |_-, |) ");
            sb.AppendLine("       //`__\\.-.-./__`\\\\ ");
            sb.AppendLine("      // /.-(() ())-.\\ \\\\ ");
            sb.AppendLine("     (\\ |)   '---'   (| /) ");
            sb.AppendLine("      ` (|           |) ` ");
            sb.AppendLine("        \\)           (/ ");
            GetPlayerInfoFooter(player, sb);
            GetEnemyInfoFooter(enemy, sb);
            return sb;
        }



        public static StringBuilder GetEnemyAscii(EnemyType enemyType, Player.Player player, EnemyBase enemy)
        {
            return GetEnemyAscii((int)enemyType, player, enemy);
        }

        public static StringBuilder GetEnemyAscii(int enemyType, Player.Player player, EnemyBase enemy)
        {
            switch (enemyType)
            {
                case 1:
                    return VampireArt(player, enemy);
                case 2:
                    return SkeletonArt(player, enemy);
                case 3:
                    return GoblinArt(player, enemy);
                case 4:
                    return MinotaurArt(player, enemy);
                case 5:
                    return GhostArt(player, enemy);
                case 6:
                default:
                    return SpiderArt(player, enemy);
            }
        }

        public static void GetPlayerInfoFooter(Player.Player player, StringBuilder sb)
        {
            sb.AppendLine("---------------------------------------------------------------");
            sb.AppendLine("---------------------------------------------------------------");
            sb.AppendLine($"Name: {player.Name}   Level: {player.Level}   HP: {player.CurrentHP}/{player.MaxHP}   Mana: {player.CurrentMana}/{player.MaxMana}");
            sb.AppendLine($"Weapon: {player.Weapon.Name}   Damage: {player.Weapon.MinDamage} - {player.Weapon.MaxDamage}");
            sb.AppendLine("---------------------------------------------------------------");
        }

        public static void GetEnemyInfoFooter(EnemyBase enemy, StringBuilder sb)
        {
            sb.AppendLine($"Enemy: {enemy.Name}   Level: {enemy.Level}   HP: {enemy.CurrentHP}/{enemy.MaxHP}");
            sb.AppendLine($"Weapon: {enemy.Weapon.Name}   Damage: {enemy.Weapon.MinDamage} - {enemy.Weapon.MaxDamage}");
        }




        public static StringBuilder GetHook1Art()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("    ,-----------. ");
            sb.AppendLine("   (_\\ ~-. *_.~  \\ ");
            sb.AppendLine("      | ~-_.,  `= | ");
            sb.AppendLine("      |  --`~ `~  | ");
            sb.AppendLine("      | -!~ =,.'  | ");
            sb.AppendLine("      |           | ");
            sb.AppendLine("      ~-_-~__`~~-`' ");
            return sb;
        }

        public static StringBuilder GetHook1ArtifactArt() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("          #### ");
            sb.AppendLine("       ########## ");
            sb.AppendLine("      ####    #### ");
            sb.AppendLine("     #     #      # ");
            sb.AppendLine("     #    ###     # ");
            sb.AppendLine("    #      #      # ");
            sb.AppendLine("   ##      #       ## ");
            sb.AppendLine("  ##                ## ");
            sb.AppendLine("  #  ### # # # # ##  # ");
            sb.AppendLine(" ##  # # # # ### #   ## ");
            sb.AppendLine(" #   # # ### # # ##    # ");
            sb.AppendLine("######################## ");
            sb.AppendLine("######################## ");
            return sb;
        }

        public static StringBuilder AngelArt() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("           ___ ");
            sb.AppendLine("    ,_    '---'    _, ");
            sb.AppendLine("    \\ `-._|\\_/|_.-' / ");
            sb.AppendLine("     |   =)'T'(=   | ");
            sb.AppendLine("      \\   /`\"`\\   / ");
            sb.AppendLine("       '._\\) (/_.' ");
            sb.AppendLine("           | | ");
            sb.AppendLine("          /\\ /\\ ");
            sb.AppendLine("          \\ T / ");
            sb.AppendLine("          (/ \\)\\ ");
            sb.AppendLine("               )) ");
            sb.AppendLine("              (( ");
            sb.AppendLine("               \\) ");
            return sb;
        }

        public static StringBuilder UpgradePlayerAbilitiesArt(Player.Player player )
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" <<<<<< UPGRADE >>>>>>> ");
            sb.AppendLine(" ----CORE STATS ");
            sb.AppendLine(" Strength - All weapons now do +1 additional damage. ");
            sb.AppendLine(" Endurance - Your health is permanently increased by 10 % ");
            sb.AppendLine(" Wisdom - Your mana pool is permanently increased by 2 ");
            sb.AppendLine(" Luck - Your chance of finding weapons and potions is increased by 10 % ");
            sb.AppendLine("  ");
            sb.AppendLine(" ----SPELLS ");
            sb.AppendLine(" Rejuvination * -Healing spell is 25 % more effective. [1 mana] ");
            sb.AppendLine(" Fast Strike -You attack twice next round. [1 mana] ");
            sb.AppendLine(" Powerful Strike* -Deal an additional 1 - 4 Damage[1 mana] ");
            sb.AppendLine(" Lifesteal * -you lifesteal 50 % of damage done to an enemy, rounded up. [1 mana] ");
            sb.AppendLine("  ");
            sb.AppendLine(" *This is active for the entire combat encounter ");
            return sb;

        }
    }
}

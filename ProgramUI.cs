using Brooklyn99.RoomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Brooklyn99.RoomTypes.Room;

namespace Brooklyn99
{
    public class ProgramUI
    {

        public void Run()
        {
            Room currentRoom = elevator;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine($"|{" ",-30}Another day at the Brooklyn Nine-Nine.\n\n\n" +
                $"{" ",-20}You, Detective Rosa Diaz, are getting ready for another day of work,\n" +
                $"{" ",-24}when you suddenly remember that it is the day before Halloween.\n" +
                $"{" ",-30}On top of making fun of Boyle's costume,\n" +
                $"{" ",-21}you are also going to have escape dealing with Jake's heist plans.\n" +
                $"{" ",-40}Welcome to Halloween Heist\n" +
                $"{" ",-45}Hide and Seek\n\n");
            Console.WriteLine($"{" ",-30}You can use these words and letters to play the game...");
            Console.WriteLine($"{" ",-33}  'go' 'head' 'leave' 'exit'  Go to an adjacent room.");
            Console.WriteLine(" ");
            Console.WriteLine($"{" ",-27}'m' / 'map':   Allows you to see the items in your inventory.");
            Console.WriteLine($"{" ",-35}'q' / 'quit':        Quits the game.");
            ImTheMap();
            Console.ReadKey();

            Console.WriteLine(currentRoom.Name.ToUpper());
            Console.WriteLine(currentRoom.Description);

            bool foundPeralta = false;
            int count = 0;

            while (!foundPeralta)
            {
                string command = Console.ReadLine().ToLower();

                if (command.Contains("go") || command.Contains("head") || command.Contains("leave") || command.Contains("exit"))
                {
                    Console.WriteLine(currentRoom.Name.ToUpper());
                    Console.WriteLine(currentRoom.Description);
                    Console.Clear();
                    bool foundExit = false;

                    foreach (string exit in currentRoom.Exits)
                    {
                        string currentOccupant = GetRandomNpcs();
                        if (command.Contains(exit) && Rooms.ContainsKey(exit))
                        {

                            currentRoom = Rooms[exit];
                            if (count == 0)
                            {
                                Console.WriteLine("0900");
                            }
                            else if (count == 1)
                            {
                                Console.WriteLine("1100");
                            }
                            else if (count == 2)
                            {
                                Console.WriteLine("1300");
                            }
                            else if (count == 3)
                            {
                                Console.WriteLine("1500");
                            }
                            else if (count == 4)
                            {
                                Console.WriteLine("1700");
                                YouWonTheGame();
                                Console.ReadKey();
                                foundPeralta = true;
                            }

                            Console.WriteLine(currentRoom.Name.ToUpper());
                            Console.WriteLine(currentRoom.Description);
                            Console.WriteLine($"{" ",-5} In {currentRoom.Name.ToUpper()} you see {currentOccupant}.\n" +
                                $"\n" +
                                $"{" ",-20} What would you like to do?");

                            if (currentOccupant.Contains(Jake.Name))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("                     Doesn't matter what you want to do! \n" +
                                                  "    Jake found you before you could go home for the day. Better luck next year.\n" +
                                                  "             For now, you need to help plan Jake's stupid heist.\n\n\n\n");
                                YouLostTheGame();
                                Console.WriteLine("                                Created By\n\n" +
                                                  "                              Marley & David");

                                Console.ReadKey();
                                foundPeralta = true;
                            }

                            foundExit = true;
                            count++;
                            break;
                        }
                    }
                    if (!foundExit)
                    {
                        Console.WriteLine("Last time I checked I can't teleport. Try asking me to go somewhere I can actually get to.");
                    }
                }
                else if (command.Contains("help") || command.Contains("h"))
                {
                    Console.WriteLine(" 'go' / 'head' / 'leave' / 'exit' + room name :  Go to an adjacent room.");
                    Console.WriteLine(" ");
                    Console.WriteLine(" 'm' / 'map':   Allows you to see the map of the precinct.");
                    Console.WriteLine(" ");
                    Console.WriteLine(" 'q' / 'quit':        Quits the game.");
                    Console.WriteLine("  ");
                    Console.ReadKey();
                    return;
                }
                else if (command.Contains("map") || command.Contains("m"))
                {
                    ImTheMap();
                }
                else if (command.Contains("quit") || command.Contains("q"))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    YouLostTheGame();
                    Console.ReadKey();
                    foundPeralta = true;                    
                }
                else
                {
                    Console.WriteLine("I hate small talk.");
                }
            }

        }

        public void Intro()
        {
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,, *//,,%@#,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.@&&@@&& &@&%&&@&@&@@@@,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,(&@@@@@&&@&@&@&&&&@@&&&%@@@%,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.,,.#&&&&&&@@&&&%&%&&@&@&@@@@@&&@@@@(,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,.,,,,.,@@@&&%@@@@@@@@&@@@@@&&#&&&%&&@@&@@@%(,,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,..........@@@% &@@@@&& &% &@@&&% (%&& &%&&@@@&% &@@@(#,,,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,,,,,,, ...........*@@@&&&&@@@@&% &%#(/(*,,,*/(%&&&@@@&@&&@@&@@@*..,,,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,,,, ...............,@@@&&&&@&@@@&@#/**,,,,,,,,*/#%&@@@@&@@@@@@@#,,....,,,,,,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,,,,, ................(*@&& &% &@@@@#@&#/**,,.,,,,,,***(%&@@@@@@@@@@@@&,,......,,,,,,,,,,,,,,");
            Console.WriteLine(",,,,,,,,,, ...................%/%&& &@@@&&@% &#(*****,*****##%%//#&@@@@@&@@@@&@@%(.........,,,,,,,,,,");
            Console.WriteLine(",,,,,,,, ....................@(@@@@@@@@&&@&% &@@@##/*,*##%@@&@#(/(&@&@&&&@@@@@@%(,,.........,,,,,,,,,");
            Console.WriteLine(",,,,,, ...................... / &@@@@@@@@@@&#((#(//*/,.*,*////*,,*(%&@@@@@&@%&@@#&*............,,,,.,");
            Console.WriteLine(".,,, .......................*(@@&&@@@@&@@@#//*,,,**..,,,,,,,,,*(#&#&@&%&@&@&&@@/*,...............,,,,");
            Console.WriteLine(".,, .......................*&& &@@&@@&&@@@@@#/*,,,/*..,**,,,,**(##%%&&&&%@&@@#@#&%.................,,");
            Console.WriteLine(".......................... &&@&@@@&%&&@@@@@&#/***(%((&#*,,,*/(((%%@&&&@%&%&&&@@%&%..................,");
            Console.WriteLine("...........................@@&@@@@@@@@@@%@@&#//***,,,,,,**///(%@@&&&@@@@&&@@@&@&(....................");
            Console.WriteLine("..........................#,@@@@@@@@@@@@@@@@@#((((#((/(/(//(#@&@@&@&@#&&&@&&@@@@&&,..................");
            Console.WriteLine("..........................&%@&@&&&&@@&@@@@@@&@#((((((((//(#%&@@@#&@@@@&&@&@&@&/&&*...................");
            Console.WriteLine("..........................&#&&@@&@@@@@@@@@&@&&%&(/*****(%%##%&@@@&@@@@&&@@@@@&%@/&...................");
            Console.WriteLine(".........................**/ &@@@&&%@@@@@@@%@&&##%%%%%%%##((((%@@@&@&@@@&&@@@@@/#.&,.................");
            Console.WriteLine(".......................&&&& &@@@@&%&&@@&&&&@@&#((######(//////(@@&&&@@@&@&@@@@&&@@/&.................");
            Console.WriteLine(".....................&&&&&& &@&@@@@@&@&%&&@@&#(/////////******(@&@&&&@@@&@@%@&@%@@&&,................");
            Console.WriteLine("...................&&##&%%%@@@&&@&&&&&@@&%%#/**,*,,**,,,,*,,*&&&&&&&&@&&@&@@@&&@@&&%%................");
            Console.WriteLine(".................. &&%% &#@%@&&&%@@@&@@&@@@##*,,,..,,,..,..,.,&&@@&&%&@@@&&@@&&@&%@&@%&&%............");
            Console.WriteLine(".................&&&&&& &#&%&&&@@&@%&@@&@&%*,.,,,/,.........@@&&&@&&&&%&&@&&&&&%&%&&%&&&&............");
            Console.WriteLine("................&&%&&&%%%&&%&%&%%&&&%&@@&&*,.,,,...,....,,&&&&&&&@@&&@@&&@@@&&%#%%&&&&&&.............");
            Console.WriteLine("...............&& &%#&%&@&%%&%%(%&@@@@@&%*,,,,,,.,, ..,....,&@@&@@%%%&/&&%@%%&%%&%&%%&%&&%...........");
            Console.WriteLine(".............#&&&&%&&%%%%%@&%%#&&@&&&&&&&,,,,,,,,.,..,,,,&&&&&&&@&%%&%%%%%%%%%&%&&%&&%&&&&...........");
            Console.WriteLine(".............&&&&&&&&%%%% &#*/%%&&&&@@&&&&&,,,,,,,,,,,,.&&&&&@&&&&#%#%%&%%@&@@*%&&&@&&&&&&&..........");
            Console.WriteLine("............ %&&&&&&% &%%#//(##&&&&&&&&&@@&&&,,,,,,,*,,&&&&&&&&&&&&###%&&%%&%##@&&&@&&&&&&&&&........");
            Console.WriteLine("............ &&&&&&&& &(%#%%#%@&&&&&&&&&&&&@@/*,*****&&@&&&&&&&&&&&(###%%&&&%&@&%&%@@&&&%&&&&........");
            Console.WriteLine("...........&&&&&&&&@&&%% &%%@&&&&&&&&&&&&&&&& ****/ &@@&&&&&&&&&&&&% (##(%%%&&%&&&&&&@&&%&&&&&&&.....");
            Console.WriteLine(".......... &&&&&&&& &@ %%%%&&&&&&&&&&&&&&&&&&&&//&&&&&&&&&&&&&&&&&%(%/#&#&%&@%&&&&&@&&&&&&&&&&&......");
            Console.WriteLine(".........%&&&&&&&& &@&%&& &@&&&&&&&&&&&&&&%&&&& (&&&&&&&&&&&&&&&&&&##%(&%&&&%&%&&&&&@&&&&&&&&&@@.....");
            Console.WriteLine("........&%@&&&&&&@&&&&@&&@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&##%&##@%&%&&&&&&@@@&&&&&&&&@&........");
            Console.WriteLine("........&@% &%&&&&&&&&@@&@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%#(##@%&&&&&&&&&&@@&&&&&&&&&&#......");
            Console.WriteLine(".......&&% &%&&&&@@&& &@#@&@@@@&@&&&&&&&&&&&&&&@&&&&&&&&&&&&&&&&&%&%%%@&%&&&&&&&&&&@@@&&&&&&@&&&.....");
            Console.WriteLine("...... &&&& &%&&&&@&& &% &@@&@@@@@@@@@@@&&&&&&&&&&@@&&&&&&&&&&&&&&&&% &#@&%&&&&&&&&&&&@@@&&&&&&&&@&*.");
            Console.WriteLine(".....%&&&&&& &@&@@&&&&&&@@@@@@@@@@&&&&&&&&&&&&@&&&&&&&&&&&&&&&&@&&&&&&%&&&&&&&& &@@@@@&&&&&&&&&& &...");
            Console.WriteLine(".....&&@&&&&&&&&@&&&&&&&& &@@@@@@&&&&&&&&&&&&&&@@&&&&&&&&&&&& &@&&&&&&&&&&&&&&@&@&@@@@&&&&&&@@&@&....");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(".s5SSSs.                                                                                .s5SSSs.  ");
            Console.WriteLine("       SS. .s5SSSs.  .s5SSSSs. .s5SSSs.  .s5SSSs.  .s5SSSSs. s.  .s    s.  .s5SSSs.            SS. s.  .s5SSSs.  .s5SSSSs.   ");
            Console.WriteLine("sS    S%S       SS.    SSS          SS.       SS.    SSS    SS.       SS.       SS.     sS    S%S SS.       SS.       SSS    ");
            Console.WriteLine("SS    S%S sS    `:;    S%S    sS    `:; sS    `:;    S%S    S%S sS    S%S sS    `:;     SS    S%S S%S sS    S%S     sSSS     ");
            Console.WriteLine("SS    S%S SSSs.        S%S    SSSs.     SS           S%S    S%S SS    S%S SSSs.         SS    S%S S%S SSSs. S%S    sSS       ");
            Console.WriteLine("SS    S%S SS           S%S    SS        SS           S%S    S%S  SS   S%S SS            SS    S%S S%S SS    S%S   sSS        ");
            Console.WriteLine("SS    `:; SS           `:;    SS        SS           `:;    `:;  SS   `:; SS            SS    `:; `:; SS    `:;  sSS         ");
            Console.WriteLine("SS    ;,. SS    ;,.    ;,.    SS    ;,. SS    ;,.    ;,.    ;,.   SS  ;,. SS    ;,.     SS    ;,. ;,. SS    ;,. sSS          ");
            Console.WriteLine(";;;;;;;:' `:;;;;;:'    ;:'    `:;;;;;:' `:;;;;;:'    ;:'    ;:'    `:;;:' `:;;;;;:'     ;;;;;;;:' ;:' :;    ;:' `:;;;;;:'    ");
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            Console.WriteLine("s.  .s    s. ");
            Console.WriteLine("SS.       SS. ");
            Console.WriteLine("S%S sSs.  S%S ");
            Console.WriteLine("S%S SS `S.S%S ");
            Console.WriteLine("S%S SS  `sS%S ");
            Console.WriteLine("`:; SS    `:; ");
            Console.WriteLine(";,. SS    ;,. ");
            Console.WriteLine(";:' :;    ;:' ");
            Console.WriteLine("  ");
            Console.WriteLine(".s5SSSSs.                         .s5SSSs.   ");
            Console.WriteLine("SSS    .s    s.  .s5SSSs.            SS. .s5SSSs.  .s5SSSs.  .s5SSSs.  .s5SSSSs. ");
            Console.WriteLine("S%S          SS.       SS.     sS    `:;       SS.       SS.       SS.    SSS    ");
            Console.WriteLine("S%S    sS    S%S sS    `:;     SS        sS    S%S sS    `:; sS    S%S    S%S    ");
            Console.WriteLine("S%S    SSSs. S%S SSSs.         SS        SS .sS;:' SSSs.     SSSs. S%S    S%S    ");
            Console.WriteLine("S%S    SS    S%S SS            SS        SS    ;,  SS        SS    S%S    S%S    ");
            Console.WriteLine("`:;    SS    `:; SS            SS   ``:; SS    `:; SS        SS    `:;    `:;    ");
            Console.WriteLine(";,.    SS    ;,. SS    ;,.     SS    ;,. SS    ;,. SS    ;,. SS    ;,.    ;,.    ");
            Console.WriteLine(";:'    :;    ;:' `:;;;;;:'     `:;;;;;:' `:    ;:' `:;;;;;:' :;    ;:'    ;:'    ");
            Console.WriteLine("  ");
            Console.WriteLine(".s    s.                                                                                       .s    s.  ");
            Console.WriteLine("      SS. .s5SSSs.  .s        .s        .s5SSSs.  .s s.  s.  .s5SSSs.  .s5SSSs.  .s    s.            SS. .s5SSSs.  s.  .s5SSSs.  .s5SSSSs. ");
            Console.WriteLine("sS    S%S       SS.                           SS.    SS. SS.       SS.       SS.       SS.     sS    S%S       SS. SS.       SS.    SSS    ");
            Console.WriteLine("SS    S%S sS    S%S sS        sS        sS    S%S sS S%S S%S sS    `:; sS    `:; sSs.  S%S     SS    S%S sS    `:; S%S sS    `:;    S%S    ");
            Console.WriteLine("SSSs. S%S SSSs. S%S SS        SS        SS    S%S SS S%S S%S SSSs.     SSSs.     SS `S.S%S     SSSs. S%S SSSs.     S%S `:;;;;.      S%S    ");
            Console.WriteLine("SS    S%S SS    S%S SS        SS        SS    S%S SS S%S S%S SS        SS        SS  `sS%S     SS    S%S SS        S%S       ;;.    S%S    ");
            Console.WriteLine("SS    `:; SS    `:; SS        SS        SS    `:; SS `:; `:; SS        SS        SS    `:;     SS    `:; SS        `:;       `:;    `:;    ");
            Console.WriteLine("SS    ;,. SS    ;,. SS    ;,. SS    ;,. SS    ;,. SS ;,. ;,. SS    ;,. SS    ;,. SS    ;,.     SS    ;,. SS    ;,. ;,. .,;   ;,.    ;,.    ");
            Console.WriteLine(":;    ;:' :;    ;:' `:;;;;;:' `:;;;;;:' `:;;;;;:' `:;;:'`::' `:;;;;;:' `:;;;;;:' :;    ;:'     :;    ;:' `:;;;;;:' ;:' `:;;;;;:'    ;:'    ");
            Console.ReadKey();
        }
        public void YouWonTheGame()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                              Congradulations!!                                                   ");
            Console.WriteLine("    `8.`8888.      ,8'  ,o888888o.     8 8888      88    `8.`888b                  ,8'  ,o888888o.     b.             8    ");
            Console.WriteLine("    `8.`8888.    , 8'. 8888     `88.   8 8888      88     `8.`888b                ,8'. 8888     `88.   888o.          8    ");
            Console.WriteLine("     `8.`8888.  , 8',8 8888       `8b  8 8888      88      `8.`888b              ,8',8 8888       `8b  Y88888o.       8    ");
            Console.WriteLine("      `8.`8888., 8' 88 8888        `8b 8 8888      88        `8.`888b     .b    ,8' 88 8888        `8b.`Y888888o.     8    ");
            Console.WriteLine("        `8.`88888'  88 8888         88 8 8888      88         `8.`888b    88b  ,8'  88 8888         88 8o. `Y888888o. 8    ");
            Console.WriteLine("         `8. 8888   88 8888         88 8 8888      88          `8.`888b.`888b, 8'   88 8888         88 8`Y8o. `Y88888o8   ");
            Console.WriteLine("          `8 8888   88 8888,        8P 8 8888      88           `8.`888b8.`8888'    88 8888        ,8P 8   `Y8o. `Y8888   ");
            Console.WriteLine("           8 8888   `8 8888,        8P ` 8888,    8P             `8.`888`8.`88'     `8 8888       ,8P  8      `Y8o. `Y8   ");
            Console.WriteLine("           8 8888    ` 8888,       88'   8888   ,d8P              `8.`8' `8,`'       ` 8888     ,88'   8         `Y8o.`   ");
            Console.WriteLine("           8 8888      `8888888P'        `Y88888P'                 `8.`   `8'           `8888888P'     8            `Yo   ");
            Console.WriteLine("                                                                                 .                     .         .                           ");
            Console.WriteLine(" 8888888 8888888888 8 8888        8 8 8888888888           , o888888o.          .8.                  , 8.       , 8.          8 8888888888   ");
            Console.WriteLine("       8 8888       8 8888        8 8 8888                 8888     `88.       .888.                , 888.     , 888.         8 8888         ");
            Console.WriteLine("       8 8888       8 8888        8 8 8888              ,8 8888       `8.     :88888.                .`8888.   .`8888.        8 8888         ");
            Console.WriteLine("       8 8888       8 8888        8 8 8888              88 8888              . `88888.            , 8.`8888. , 8.`8888.       8 8888         ");
            Console.WriteLine("       8 8888       8 8888        8 8 888888888888      88 8888             .8. `88888.           , 8'8.`8888,8^8.`8888.      8 888888888888 ");
            Console.WriteLine("       8 8888       8 8888        8 8 8888              88 8888            .8`8. `88888.         , 8' `8.`8888' `8.`8888.     8 8888         ");
            Console.WriteLine("       8 8888       8 8888888888888 8 8888              88 8888   8888888 .8' `8. `88888.        ,8'   `8.`88'   `8.`8888.    8 8888         ");
            Console.WriteLine("       8 8888       8 8888        8 8 8888              `8 8888       .8'.8'   `8. `88888.     , 8'     `8.`'     `8.`8888.   8 8888         ");
            Console.WriteLine("       8 8888       8 8888        8 8 8888                 8888    , 88'.888888888. `88888.    ,8'       `8        `8.`8888.  8 8888         ");
            Console.WriteLine("       8 8888       8 8888        8 8 888888888888          `8888888P' .8'       `8. `88888. , 8'         `         `8.`8888. 8 888888888888 \n\n\n");
            Console.WriteLine("                                                       PUT THAT IN A PIPE AND SMOKE IT JAKE!!!");
            string playAgain = Console.ReadLine();
            if (playAgain.Contains("y") || playAgain.Contains("yes")) 
            {
                Run();
            } else if (playAgain.Contains("n") || playAgain.Contains("no"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                YouLostTheGame();
            }
        }
        public void YouLostTheGame()
        {
            Console.WriteLine("  @@@@@@@   @@@@@@  @@@@@@@@@@  @@@@@@@@     @@@@@@  @@@  @@@ @@@@@@@@ @@@@@@@  ");
            Console.WriteLine(" !@@       @@!  @@@ @@! @@! @@! @@!         @@!  @@@ @@!  @@@ @@!      @@!  @@@ ");
            Console.WriteLine(" !@! @!@!@ @!@!@!@! @!! !!@ @!@ @!!!:!      @!@  !@! @!@  !@! @!!!:!   @!@!!@! ");
            Console.WriteLine(" :!!   !!: !!:  !!! !!:     !!: !!:         !!:  !!!  !: .:!  !!:      !!: :!! ");
            Console.WriteLine("  :: :: :   :   : :  :      :   : :: ::      : :. :     ::    : :: ::   :   : : \n\n\n");
            Console.WriteLine("                       Thank you for playing our game!!            \n\n\n\n");
            Console.WriteLine("                               Created By\n\n" +
                              "                             Marley & David");
        }
        public void ImTheMap()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("       _____________________________________                                      ");
            Console.WriteLine("      ||        ||  h  ||                  ||            ______________           ");
            Console.WriteLine("      ||bathroom||  a  ||   Interrogation  ||           ||            ||          ");
            Console.WriteLine("      ||________||  l  ||       Room       ||           ||  Briefing  ||       || ");
            Console.WriteLine("                ||  l  ||__________________||           ||    Room    ||       || ");
            Console.WriteLine("   _____________||  w                    ||             ||____________||       || ");
            Console.WriteLine("  ||            ||  a       Kitchen      ||                                    || ");
            Console.WriteLine("  || Waiting    ||  y                                                          || ");
            Console.WriteLine("  ||  Room      ||                                                             || ");
            Console.WriteLine("  ||____                                                        _______________|| ");
            Console.WriteLine("  || Elevator                    Bullpen                       ||         || ");
            Console.WriteLine("  ||___||______                                                ||  Copy   || ");
            Console.WriteLine("  ||          ||                                               ||  Room   || ");
            Console.WriteLine("  || Holding  ||                                               ||_________|| ");
            Console.WriteLine("  ||   Cell   ||                                               ||         || ");
            Console.WriteLine("  ||__________||_____________                                  || Captain || ");
            Console.WriteLine("              ||            ||                                 ||  Holt's || ");
            Console.WriteLine("              ||    Break   ||                                 ||  Office || ");
            Console.WriteLine("              ||     Room   ||_________________________________||_________|| ");
            Console.WriteLine("              ||____________||                                      || ");
            Console.WriteLine("                            ||               Balcony                || ");
            Console.WriteLine("                            ||______________________________________|| ");
        }
        public static Room bullpen = new Room("bullpen",
            "    Ah the bullpen. Lively as ever even with criminals in costumes \n" +
            "              and, like always, Jake's stupid mess. \n" +
            "          You may choose almost any room to enter next.\n" +
            "     (except for interrogation, the bathroom, and the elevator) \n",
            new List<string> { "kitchen", "captains office", "balcony", "breakroom", "holding cell", "waiting room", "hallway", "briefing room", "copy room" },
            new List<People> { }
            );
        public static Room kitchen = new Room("kitchen",
            "    You've gone to the kitchen to avoid the chaos \n" +
            "      but you forgot that Hitchcock and Scully \n" +
            "       were eating sourkraut sausages earlier. \n" +
            "        The OBVIOUS exits are the bullpen or \n" +
            "                 or the hallway. \n",
            new List<string> { "bullpen", "hallway" },
            new List<People> { }
            );
        public static Room interrogationRoom = new Room("interrogation room",
            "    You've gone to the interrogation room to see if \n" +
            "     you can hide in here for the rest of the day, \n" +
            "          but it smells like Scully's feet... \n" +
            "          The OBVIOUS exit is the hallway. \n",
            new List<string> { "hallway" },
            new List<People> { }
            );
        public static Room hallway = new Room("hallway",
            "       You're now in the hallway, \n" +
            "         You have three choices,\n" +
            "   the kitchen, the interrogation room, \n" +
            "           or the bathroom. \n",
            new List<string> { "kitchen", "interrogation room", "bathroom", },
            new List<People> { }
            );
        public static Room bathroom = new Room("bathroom",
            "  You're now in the bathroom, You can go back into the hallway or \n" +
            "         hide out in a stall if you need a break. \n" +
            " \n" +
            "           You can go back out to the hallway. \n",
            new List<string> { "hallway" },
            new List<People> { }
            );
        public static Room briefingRoom = new Room("briefing room",
            "     You've gone into the Briefing Room. \n" +
            "     Good thing it is almost the weekend \n" +
            "       and no one wants to be in here.\n" +
            "              On a serious note,\n" +
            "      why do all of these rooms just \n" +
            "         connect to the bullpen? \n",
            new List<string> { "bullpen" },
            new List<People> { }
            );
        public static Room copyRoom = new Room("copy room",
            "         You're in the Copy Room now... \n" +
            "      It's stupid in here and you hate it. \n" +
            " \n" +
            "       You can go back out to the bullpen \n",
            new List<string> { "bullpen" },
            new List<People> { }
        );
        public static Room captainsOffice = new Room("Captain's Office",
            "    You tried to get into Captain Holt's Office but \n" +
            "    the door was locked in preparation of the heist. \n" +
            "To bad someone would notice you smashing his office window. \n" +
            " \n" +
            "  Move back to the bullpen before choosing a different room. \n",
            new List<string> { "bullpen" },
            new List<People> { }
        );
        public static Room balcony = new Room("balcony",
            "    You're on the balcony, you can look out to the\n" +
            "        New York skyline or enjoy the stale \n" +
            "  cigarette smell from Amy's dirty little secret.\n" +
            " \n" +
            "     Obviously from here you can go to the bullpen \n",
            new List<string> { "bullpen" },
            new List<People> { }
        );
        public static Room breakRoom = new Room("break room",
            "   You've entered into the Break Room, \n" +
            "  Would you like to sit down or move on? \n" +
            " \n" +
            "      The OBVIOUS exit is the bullpen. \n",
            new List<string> { "bullpen" },
            new List<People> { }
        );
        public static Room holdingCell = new Room("holding cell",
            "    You have walked up to the holding cell which is " +
            "        filled with drunk people in customes. " +
            " \n" +
            "          The OBVIOUS exit is the Bullpen. \n",
            new List<string> { "bullpen" },
            new List<People> { }
        );
        public static Room elevator = new Room("elevator",
            "       You are at the elevator, \n" +
            "    Do you want to leave the Game? \n" +
            "       If so, type 'q' or 'quit' \n" +
            "                 If not," +
            "   the OBVIOUS exits are the bullpen\n" +
            "         and the waiting room.",
            new List<string> { "bullpen", "waiting room" },
            new List<People> { }
        );
        public static Room waitingRoom = new Room("waiting room",
            "      You chose to enter the waiting room, \n" +
            "  You can hang out with the 'soon to be booked'\n" +
            "           or choose a different room. \n" +
            " \n" +
            "The OBVIOUS exits are the bullpen and the elevator. \n",
            new List<string> { "bullpen", "elevator" },
            new List<People> { }
        );

        public static People Jake = new People("Jake", " Hey there Rosa! Wanna help me plan a heist?!??' ");
        public static People Amy = new People("Amy", " 'Rosa! I could use some help taking Peralta down and winning this heist.' ");
        public static People Captain = new People("Cpt. Holt", " 'Don't you have some work to do Detective Diaz?' ");
        public static People Charles = new People("Charles", " 'OH BEST-FRIEND!! I FOUND ROSA!!' ");
        public static People Terry = new People("Terry", " 'You hiding from Peralta as well? Terry hates heists.' ");
        public static People Scully = new People("Scully", " 'Hitchcock! Are you eating without me??' ");
        public static People Hitchcock = new People("Hitchcock", " 'Scully! Are you eating without me??' ");
        public static People Gina = new People("Gina", " 'Well well well... What do we have here? A heist hider??' ");

        private Dictionary<string, Room> Rooms = new Dictionary<string, Room>
        {
            { "bullpen", bullpen },
            { "kitchen", kitchen },
            { "interrogation room", interrogationRoom },
            { "bathroom", bathroom },
            { "briefing room", briefingRoom },
            { "copy room", copyRoom },
            { "captains office", captainsOffice },
            { "balcony", balcony },
            { "break room", breakRoom },
            { "holding cell", holdingCell },
            { "elevator", elevator },
            { "waiting room", waitingRoom },
            { "hallway", hallway }
        };

        Dictionary<string, People> People = new Dictionary<string, People>
        {
            { "Jake", Jake},
            { "Amy", Amy},
            { "Cpt Holt", Captain},
            { "Terry", Terry},
            { "Charles", Charles},
            { "Gina", Gina},
            { "Scully", Scully },
            { "Hitchcock", Hitchcock }
        };

        Random _random = new Random();
        static string GetRandomNpcs()
        {
            Random random = new Random();
            People[] randomNpcs = new People[] { Amy, Captain, Terry, Charles, Gina, Scully, Hitchcock, Jake };
            int randomNumber = random.Next(0, randomNpcs.Length);
            People people = randomNpcs.ElementAt(randomNumber);
            return $"{people.Name} \n" +
                $"{people.Converstation}";
        }
    }
}

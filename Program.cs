using System;

namespace Brooklyn99
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI game = new ProgramUI();
            game.Intro();
            game.Run();
        }
    }
}

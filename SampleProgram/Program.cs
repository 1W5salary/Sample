using ChessLib;
using System;
using System.Collections.Generic;

namespace SampleProgram
{
    public static class Program
    {
        public static void Main()
        {
            var game = new ComplexGame();
            var knight = new Knight();
            var quee = new Queen();
            var bishop = new Bishop();
            game.Play(20, knight, bishop, quee);



            // game.Play(0, knight, bishop, quee);
            // game.Play(-5, knight, bishop, quee);
            // game.Play(1);
            // game.Play(0);


            Console.WriteLine("Press any key ...");
            Console.ReadKey();



        }
    }
}
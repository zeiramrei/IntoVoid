﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntoVoid
{
    class MainGame
    {
        static void Main(string[] args)
        {
            var board = new GameBoard();
            Player player = new Player();

            bool ifGameOn = true;
            bool ifFightOn = false;

            board.LoadLevel();
            Console.CursorVisible = false;

            //bool fight = false;
            while (ifGameOn) 
            {
                // render the map
                //Console.Clear();
                board.RenderBoard();
                //board.WritePlayerPos();


                // player can move (Added support for caps lock characters)
                char input = Console.ReadKey(true).KeyChar.ToString().ToLower()[0];
                Console.WriteLine();
                board.TryMovePlayer(input);

                // Check if new level
                board.CheckIfGoal();

                // Check if found an enemy
                ifFightOn = board.CheckIfEnemy();

                if (ifFightOn)
                {
                    FightOn fightOn = new FightOn();
                    fightOn.FightOnEvent(player, board.GetLevel());

                    ifFightOn = false;
                    board.RenderBoardAfterFight();
                }

                // For testing stuff can be removed later on
                #if debug
                    //code in this block will only be executed on debug and not release
                #endif



            }
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}

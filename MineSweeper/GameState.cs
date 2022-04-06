using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class GameState
    {
        public enum State
        {
            None,
            Ingame,
            Won,
            Lost,
        };

        public Board Board { get; private set; }
        public State state;
        //TODO: public List<Command> SavedCommands;

        public GameState(IRandomGenerator random, int width, int height)
        {
            //TODO: Probably no reason to have these two as seperate calls, both could be done in ctor
            Board = new Board(random, width, height);
            Board.Initialize();
        }
    }
}

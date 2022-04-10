using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class Score
    {

        public int Id { get; set; }

        public int Points { get; set; }

        public string PlayerName { get; set; }

        public DateTime TimeStamp { get; set; }


        public Score(int points, string playerName, DateTime timestamp)
        {
            Points = points;
            PlayerName = playerName;
            TimeStamp = timestamp;

        }

    }
}

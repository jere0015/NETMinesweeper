using System;

namespace MineSweeper.Blazor.Server.Data
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public float Time { get; set; }
        public DateTime Date { get; set; }
    }
}

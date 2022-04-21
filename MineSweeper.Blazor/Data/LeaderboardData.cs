using System;

namespace MineSweeper.Blazor.Data
{
    public class LeaderboardData
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public float Time { get; set; }
        public DateTime Date { get; set; }
    }
}

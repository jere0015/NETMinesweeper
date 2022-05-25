using Microsoft.EntityFrameworkCore;
using MineSweeper.API.Score.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeper.API.Score.Context

{
    public class ScoreContext : DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options) : base(options)
        {
            // Make sure context exists
            Database.EnsureCreated();

        }

        public DbSet<Models.Score> Scores { get; set; }



    }
}

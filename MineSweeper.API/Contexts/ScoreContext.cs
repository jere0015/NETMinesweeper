using Microsoft.EntityFrameworkCore;
using MineSweeper.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeper.API.Contexts
{
    public class ScoreContext : DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options) : base(options)
        {
            // Make sure context exists
            Database.EnsureCreated();

        }

        public DbSet<Score> Scores { get; set; } = null!;

        

    }
}

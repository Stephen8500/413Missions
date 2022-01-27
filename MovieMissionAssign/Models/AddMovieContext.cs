using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMissionAssign.Models
{
    public class AddMovieContext : DbContext
    {
        //constructor
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options)
        {
            //leave blank for now
        }

        public DbSet<MovieForm> Movies { get; set; }

        //initial entries to db (seeded in)
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieForm>().HasData(
                new MovieForm
                {
                    MovieId = 1,
                    Title = "The Dark Knight",
                    Category = "Action",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new MovieForm
                {
                    MovieId = 2,
                    Title = "Tenet",
                    Category = "Action",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new MovieForm
                {
                    MovieId = 3,
                    Title = "Inception",
                    Category = "Action",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                }
            );
        }
    }
}

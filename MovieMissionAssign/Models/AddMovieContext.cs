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
        public DbSet<Category> Categories { get; set; }
        
        //initial entries to db (seeded in)
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action"},
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Fantasy" },
                new Category { CategoryId = 5, CategoryName = "Horror" },
                new Category { CategoryId = 6, CategoryName = "Mystery" },
                new Category { CategoryId = 7, CategoryName = "Romance" },
                new Category { CategoryId = 8, CategoryName = "Thriller" },
                new Category { CategoryId = 9, CategoryName = "Western" }
            );

            mb.Entity<MovieForm>().HasData(
                new MovieForm
                {
                    MovieId = 1,
                    Title = "The Dark Knight",
                    CategoryId = 1,
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new MovieForm
                {
                    MovieId = 2,
                    Title = "Tenet",
                    CategoryId = 1,
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new MovieForm
                {
                    MovieId = 3,
                    Title = "Inception",
                    CategoryId = 1,
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                }
            );
        }
    }
}

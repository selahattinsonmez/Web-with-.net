using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext()
        {

        }

        public MovieAppContext(DbContextOptions<MovieAppContext> options) : base(options)
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<MovieActor>().HasKey(q =>
            new {
                q.ActorId,
                q.MovieId
            });

            modelBuilder.Entity<MovieCategory>().HasKey(q =>
          new {
              q.CategoryId,
              q.MovieId
          });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasOne(d => d.movie)
                .WithMany(p => p.MovieActors)
                 .HasForeignKey(d => d.MovieId)
                 .HasPrincipalKey(d => d.MovieId)
                 .HasConstraintName("FK_MovieActor_Movie");

                entity.HasOne(d => d.actor)
                    .WithMany(p => p.MovieActors)
                    .HasForeignKey(d => d.ActorId)
                    .HasPrincipalKey(d => d.ActorId)
                    .HasConstraintName("FK_MovieActor_Actor");
            });

           modelBuilder.Entity<MovieCategory>(entity =>
            {
                entity.HasOne(d => d.movie)
                .WithMany(p => p.MovieCategories)
                 .HasForeignKey(d => d.MovieId)
                 .HasConstraintName("FK_MovieCategory_Movie");

                entity.HasOne(d => d.category)
                    .WithMany(p => p.MovieCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_MovieCategory_Category");
            });
        }
    }
}
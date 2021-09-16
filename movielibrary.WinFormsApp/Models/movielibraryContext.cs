using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace movielibrary.WinFormsApp.Models
{
    public partial class movielibraryContext : DbContext
    {
        public movielibraryContext()
        {
        }

        public movielibraryContext(DbContextOptions<movielibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActor> MovieActors { get; set; }
        public virtual DbSet<MovieDirector> MovieDirectors { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConfigurationManager.ConnectionStrings["DBmovielibrary"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.ToTable("actor");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.DeathDate)
                    .HasColumnType("date")
                    .HasColumnName("death_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .HasColumnName("photo");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("director");

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.DeathDate)
                    .HasColumnType("date")
                    .HasColumnName("death_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .HasColumnName("photo");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("movie");

                entity.HasIndex(e => e.Title, "title")
                    .IsUnique();

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Photo)
                    .HasMaxLength(50)
                    .HasColumnName("photo");

                entity.Property(e => e.ReleaseCountry)
                    .HasMaxLength(10)
                    .HasColumnName("release_country");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_actor");

                entity.HasIndex(e => e.ActorId, "actor_id");

                entity.HasIndex(e => e.MovieId, "movie_id");

                entity.Property(e => e.ActorId).HasColumnName("actor_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Actor)
                    .WithMany()
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("movie_actor_ibfk_2");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("movie_actor_ibfk_1");
            });

            modelBuilder.Entity<MovieDirector>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movie_director");

                entity.HasIndex(e => e.DirectorId, "director_id");

                entity.HasIndex(e => e.MovieId, "movie_id");

                entity.Property(e => e.DirectorId).HasColumnName("director_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.HasOne(d => d.Director)
                    .WithMany()
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("movie_director_ibfk_2");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("movie_director_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

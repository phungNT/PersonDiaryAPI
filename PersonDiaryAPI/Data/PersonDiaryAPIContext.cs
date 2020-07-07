using Microsoft.EntityFrameworkCore;
using PersonDiaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiaryAPI.Data
{
    public class PersonDiaryAPIContext : DbContext
    {
        public PersonDiaryAPIContext(DbContextOptions<PersonDiaryAPIContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Diary> Diarys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Diary - User 
            modelBuilder.Entity<Diary>()
            .HasOne<User>(d => d.user)
            .WithMany(u => u.diarys);
        }

    }
}
using A.NETLabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.NETLabb4.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<UserHobby> UserHobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Data for User
            modelBuilder.Entity<User>().
                HasData(new User
                {
                    UserID = 1,
                    Name = "Hanna Lahtinen",
                    Adress = "Storgatan 16",
                    PhoneNumber = "0738987647"
                });
            modelBuilder.Entity<User>().
                HasData(new User
                {
                    UserID = 2,
                    Name = "Jennifer Gergi",
                    Adress = "Nyhemsgatan 11",
                    PhoneNumber = "0729098478"
                });
            modelBuilder.Entity<User>().
                HasData(new User
                {
                    UserID = 3,
                    Name = "Karl Levin",
                    Adress = "Storgatan 2",
                    PhoneNumber = "0737645387"
                });


            //Seed Data for Hobby
            modelBuilder.Entity<Hobby>().
                HasData(new Hobby
                {
                    HobbyID = 1,
                    HobbyName = "Painting",
                    Description = "Painting is the practice of applying paint, pigment, " +
                    "color or other medium to a solid surface."
                });
            modelBuilder.Entity<Hobby>().
                HasData(new Hobby
                {
                    HobbyID = 2,
                    HobbyName = "Dance",
                    Description = "Dance is a performing art form consisting of sequences " +
                    "of movement, either improvised or purposefully selected."
                });
            modelBuilder.Entity<Hobby>().
                HasData(new Hobby
                {
                    HobbyID = 3,
                    HobbyName = "Soccer",
                    Description = "Soccer is a sport where the objective is to score in the " +
                    "opposite teams goal."
                });
            modelBuilder.Entity<Hobby>().
                HasData(new Hobby
                {
                    HobbyID = 4,
                    HobbyName = "Karate",
                    Description = "Karate is a martial art developed in the Ryukyu Kingdom."
                });
            modelBuilder.Entity<Hobby>().
                HasData(new Hobby
                {
                    HobbyID = 5,
                    HobbyName = "Swimming",
                    Description = "Swimming is the self-propulsion of a person through water, " +
                    "or other liquid, usually for recreation, sport, exercise, or survival."
                });


            //Seed Data for UserHobby
            modelBuilder.Entity<UserHobby>().
                HasData(new UserHobby
                {
                    UserHobbyID = 1,
                    UserID = 1,
                    HobbyID = 1,
                    WebsiteLink = "https://www.britannica.com/art/painting",
                });
            modelBuilder.Entity<UserHobby>().
                HasData(new UserHobby
                {
                    UserHobbyID = 2,
                    UserID = 1,
                    HobbyID = 2,
                    WebsiteLink = "https://justdancenow.com/?msclkid=a6db88d8a6f011ecb496d62156d715c2",
                });
            modelBuilder.Entity<UserHobby>().
                HasData(new UserHobby
                {
                    UserHobbyID = 3,
                    UserID = 2,
                    HobbyID = 3,
                    WebsiteLink = "https://nr.soccerway.com/?msclkid=c254e7a3a6f011ecbe9cf1576f5c8b26",
                });
            modelBuilder.Entity<UserHobby>().
                HasData(new UserHobby
                {
                    UserHobbyID = 4,
                    UserID = 3,
                    HobbyID = 4,
                    WebsiteLink = "https://www.karate.com/?msclkid=033d5163a6f111ecbd04e11c109355de",
                });
            modelBuilder.Entity<UserHobby>().
                HasData(new UserHobby
                {
                    UserHobbyID = 5,
                    UserID = 3,
                    HobbyID = 5,
                    WebsiteLink = "https://www.swimmingworldmagazine.com/news/the-2022-ncaa-womens-championships-day-2-finals-500-freestyle?msclkid=10132017a6f111ecba5147ba639fac7f",
                });
            modelBuilder.Entity<UserHobby>().
                HasData(new UserHobby
                {
                    UserHobbyID = 6,
                    UserID = 3,
                    HobbyID = 5,
                    WebsiteLink = "https://www.swimming.org/?msclkid=94a037dca6f111ecbfe16cc89f8fcbb2",
                });
        }
    }
}

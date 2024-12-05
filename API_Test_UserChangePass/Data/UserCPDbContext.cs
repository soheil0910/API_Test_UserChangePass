using API_Test_UserChangePass.Models;
using API_Test_UserChangePass.Utility;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Test_UserChangePass.Data
{
    public class UserCPDbContext : DbContext
    {



        public UserCPDbContext(DbContextOptions<UserCPDbContext> options) : base(options)
        {
        }
        public DbSet<Userx> Userx { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Userx>().HasData(
          new Userx()
          {
              Id = 1,
              UserName = "user1",
              PasswordHash = HashPasswordBCrypt.HashPassword("1234"),        
              Password_Test = "1234",
              Email = "soheil0910line@gmail.com",
              IsAdmin = true,
              RegisterDate = DateTime.UtcNow,


          }, new Userx()
          {
              Id = 2,
              UserName = "user2",
              PasswordHash = HashPasswordBCrypt.HashPassword("1234"),      
              Password_Test = "1234",
              Email = "soheil0910line@gmail.com",
              IsAdmin = false,
              RegisterDate = DateTime.UtcNow,


          });

            base.OnModelCreating(modelBuilder);
        }





    }
}

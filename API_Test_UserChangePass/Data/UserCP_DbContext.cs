using Microsoft.EntityFrameworkCore;
using System;

namespace API_Test_UserChangePass.Data
{
    public class UserCP_DbContext:DbContext
    {






        public UserCP_DbContext(DbContextOptions<UserCP_DbContext> options) : base(options)
        {

        }


        //public DbSet<User> Users { get; set; }





    }
}

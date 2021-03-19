using System;
using System.ComponentModel.DataAnnotations;
using ClassRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassRegister.Data
{
    public class ClassRegisterContext : DbContext
    {
        public ClassRegisterContext(DbContextOptions<ClassRegisterContext> options)
            : base(options)
        {
        }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}

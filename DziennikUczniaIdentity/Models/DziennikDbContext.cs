using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static DziennikUczniaV3.Models.Enum;

namespace DziennikUczniaV3.Models
{
    public class DziennikDbContext : DbContext
    {
        public DziennikDbContext() : base("DbNowa") { }

        //users
       // public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        //Chat
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        //Test
        public DbSet<Test> Tests { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<TestAnswer> TestAnswer { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
    }
}

/*
 * Enable-Migrations
 * Add-Migration BezDziedziczenia
 * Update-Database
 */
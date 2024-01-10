﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DziennikUczniaKoniec.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UserRole {  get; set; }

        public virtual ICollection<MessageRecipient> MessageReceipts { get; set; }
        public virtual ICollection<Message> SendMessages { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClosedQuestionAnswer> ClosedQuestionAnswer { get; set; }
        public DbSet<ClosedQuestionOption> ClosedQuestionOption { get; set; }
        public DbSet<Announcement> GlobalAnnouncement { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageRecipient> MessageRecipient { get; set; }
        public DbSet<ClosedQuestion> ClosedQuestion { get; set; }
        public DbSet<OpenQuestion> OpenQuestion { get; set; }
        public DbSet<OpenTestAnswer> OpenQuestionAnswer { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestAttempt> TestAttempt { get; set; }
        public DbSet<TestSharing> TestSharing { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<StudentPrent> StudentPrent { get; set; }
        public DbSet<TeacherClassSubject> TeacherClassSubject { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
                .Property(c => c.SubjectDescription)
                .IsUnicode(true);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // public System.Data.Entity.DbSet<DziennikUczniaKoniec.Models.ApplicationUser> ApplicationUsers { get; set; }
    }

    public class IdentityManager
    {
        public RoleManager<IdentityRole> LocalRoleManager
        {
            get
            {
                return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ApplicationDbContext.Create()));
            }
        }

        public UserManager<ApplicationUser> LocalUserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ApplicationDbContext.Create()));
            }
        }

        public ApplicationUser GetUserByID(string userID)
        {
            ApplicationUser user = null;
            UserManager<ApplicationUser> um = this.LocalUserManager;
            user = um.FindById(userID);
            return user;
        }

        public ApplicationUser GetUserByName(string email)
        {
            ApplicationUser user = null;
            UserManager<ApplicationUser> um = this.LocalUserManager;
            user = um.FindByEmail(email);
            return user;
        }

        public bool RoleExists(string name)
        {
            var rm = LocalRoleManager;
            return rm.RoleExists(name);
        }

        public bool CreateRole(string name)
        {
            var rm = LocalRoleManager;
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = LocalUserManager;
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }


        public bool AddUserToRole(string userId, string roleName)
        {
            var um = LocalUserManager;
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public bool AddUserToRoleByUsername(string username, string roleName)
        {
            var um = LocalUserManager;
            string userID = um.FindByName(username).Id;
            var idResult = um.AddToRole(userID, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId)
        {
            var um = LocalUserManager;
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
                um.RemoveFromRole(userId, role.RoleId);
        }
    }
}
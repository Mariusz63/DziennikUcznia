using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NowyDziennik.Enum;
using NowyDziennik.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NowyDziennik.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string SelectedRole { get; set; } = RolesEnum.Student.ToString();
        public byte[] ProfilePhoto { get; set; }

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
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TeacherClassSubject> TeacherClassSubject { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<StudentGrade> StudentGrade { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<AnnouncementUser> AnnouncementUser { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answer { get; set; }
       // public DbSet<TestViewModel> TestViewModels { get; set; }
       // public DbSet<ClassTopicViewModel> ClassTopicViewModels { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }
        public DbSet<ClassTopic> ClassTopics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // modelBuilder.Entity<Student>()
           //     .HasMany(s => s.Subjects)
           //     .WithMany(s => s.Students)
           //     .Map(cs =>
           //     {
           //         cs.MapLeftKey("StudentId");
           //         cs.MapRightKey("SubjectId");
           //         cs.ToTable("StudentSubjects");
           //     });

           // modelBuilder.Entity<Student>()
           //.HasMany(s => s.Grades)
           //.WithOne(g => g.Student)
           //.HasForeignKey(g => g.StudentId);

           //// Configure the Class - Topic relationship
           // modelBuilder.Entity<Class>()
           // .HasMany(c => c.ClassTopics)
           // .WithRequired(ct => ct.Class)
           // .HasForeignKey(ct => ct.ClassId);

           // // Configure the ClassTopic-FileAttachment relationship
           // modelBuilder.Entity<ClassTopic>()
           //     .HasMany(ct => ct.FileAttachments)
           //     .WithRequired(fa => fa.ClassTopic)
           //     .HasForeignKey(fa => fa.ClassTopicId);
        }

    }
}



//Klasa dodana (napisana)
public class IdentityManager
{
    public RoleManager<IdentityRole> LocalRoleManager
    {
        get
        {
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        }
    }


    public UserManager<ApplicationUser> LocalUserManager
    {
        get
        {
            return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
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
        {
            um.RemoveFromRole(userId, role.RoleId);
        }
    }
}

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DziennikUczniaN.Models
{
    public class Role
    {
        public const string Administrator = "Administrator", Teacher = "Teacher", Parent = "Parent", Student = "Student";
        public const string AdministratorTeacher = "Administrator,Teacher";
        public const string AdministratorTeacherStudent = "Administrator,Teacher,Student";
        public const string TeacherStudent = "Teacher,Student";
        public static string[] All = new string[] { Administrator, Teacher, Parent, Student };

    }
}
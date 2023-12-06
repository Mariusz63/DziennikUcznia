using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DziennikUczniaV3.Models
{
    public class Enum
    {

        public enum Roles
        {
            None = 0,
            Student = 1,
            Teacher = 2,
            Admin = Student | Teacher
        }
    }
}
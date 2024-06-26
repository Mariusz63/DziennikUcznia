﻿namespace DziennikUczniaKoniec.Models
{
    public class ClassMembership
    {
        public int ClassMembershipId { get; set; }

        // Foreign keys
        public string UserId { get; set; }
        public int ClassId { get; set; }

        // Navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual Class Class { get; set; }
    }
}
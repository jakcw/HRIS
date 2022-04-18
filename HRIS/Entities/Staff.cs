using System;
using System.Collections.Generic;
using System.Linq;

namespace HRIS.Entities
{
    public enum Category
    {
        Academic,
        Technical,
        Admin,
        Casual
    }
    public class Staff
    {
        public int ID { get; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public Campus Campus { get; set; }
        public string Phone { get; set; }
        public string Room { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Category Category { get; set; }

    }
}

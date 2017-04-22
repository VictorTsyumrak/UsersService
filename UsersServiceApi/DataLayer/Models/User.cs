using System;

namespace DataLayer.Models
{
    public class User
    {
        public User()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
using System;

namespace DataLayer.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime FoundationDate { get; set; }
    }
}
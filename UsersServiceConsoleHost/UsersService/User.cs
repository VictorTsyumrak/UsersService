using System;
using System.Runtime.Serialization;

namespace UsersService
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Middlename { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}

using System;

namespace UserManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Genre Genre { get; set; }
        public DateTime InclusionDate { get; set; }
    }


    public enum Genre
    {
        Masculine = 1,
        Feminine = 2
    }
}

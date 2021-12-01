using System;
using UserManagement.Domain.Entities;

namespace UserManagement.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Genre Genre { get; set; }
        public DateTime InclusionDate { get; set; }
        public bool Active { get; set; }
    }
}

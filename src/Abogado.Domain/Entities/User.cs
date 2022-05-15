using Abogado.Domain.Enums;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class User : Entity
    {
        public List<Case> Cases { get;}

        public List<Meeting> Meetings { get; }

        public Role Role { get; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string EncriptPassword { get; }

        private User()
        {

        }

        private User(Role role, string name, string lastname, string email, string encriptPassword)
        {
            Role = role;
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Lastname = Guard.Against.NullOrEmpty(lastname, nameof(lastname));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            EncriptPassword = Guard.Against.NullOrEmpty(encriptPassword, nameof(encriptPassword));
        }

        public static User Build(Role role, string name, string lastname, string email, string encriptPassword)
        {
            return new User(role, name, lastname, email, encriptPassword);
        }

        public void ChangeAtributtes(string name, string lastName, string email)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Lastname = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));  
        }
    }
}

using Abogado.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class Meeting : Entity
    {
        public List<User> Users { get; private set; }

        public DateTime Date { get; private set; }

        private Meeting()
        {

        }

        private Meeting(DateTime date)
        {
            Date = date;
        }

        public static Meeting Build(DateTime date)
        {
            return new Meeting(date);
        }

        public void AddUser(User user)
        {
            if (Users is null)
                this.Users = new List<User>();

            if (Users.Count >= 2)
                throw new Exception("solamente puede tener dos objetos.");
            else if (Users.Any(x => x.Role == user.Role))
                throw new Exception("La reunion solo puede tener asociado un abogado y un cliente");

            Users.Add(user);
        }

        public void ChangeAttributes(DateTime date)
        {
            this.Date = date;
        }
    }
}

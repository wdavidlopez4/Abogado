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
        public List<UserMeeting> Users { get; private set; }

        public DateTime Date { get;}

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

        public void AddLawyer(User user)
        {
            if (Users is null)
                this.Users = new List<UserMeeting>();

            if (Users.Count >= 2)
                throw new Exception("solamnete puede tener dos objetos.");

            else if (Users.Any(x => x.User.Role == Role.abogado))
                throw new Exception("solo puede tener un abogado");

            Users.Add(UserMeeting.Build(user, this));
        }

        public void AddUser(User user)
        {
            if (Users is null)
                this.Users = new List<UserMeeting>();

            if (Users.Count >= 2)
                throw new Exception("solamnete puede tener dos objetos.");

            else if (Users.Any(x => x.User.Role == Role.cliente || x.User.Role == Role.aux))
                throw new Exception("solo puede tener un cliente o aux");

            Users.Add(UserMeeting.Build(user, this));
        }
    }
}

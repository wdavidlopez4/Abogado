using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Domain.Entities
{
    public class UserMeeting : Entity
    {
        public Guid UserId { get; private set; }

        public User User { get; private set; }

        public Guid MeetingId { get; private set; }

        public Meeting Meeting { get; private set; }

        private UserMeeting()
        {

        }

        private UserMeeting(User user, Meeting meeting)
        {
            User = user;
            Meeting = meeting;
        }

        public static UserMeeting Build(User user, Meeting meeting)
        {
            return new UserMeeting(user, meeting);
        }
    }
}

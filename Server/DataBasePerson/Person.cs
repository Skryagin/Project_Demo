using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasePerson
{
    public class Person
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Sent> SentId { get; set; }
        public ICollection<NotSent> notSentId { get; set; }

    }
}

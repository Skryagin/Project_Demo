using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBasePerson
{
    public class DataContext : DbContext
    {
        public DataContext(string conn) : base(conn) { }
        public DbSet<Person> Person { get; set; }
        public ICollection<NotSent> NotSentId { get; set; }
        public ICollection<Sent> SentId { get; set; }
    }
}

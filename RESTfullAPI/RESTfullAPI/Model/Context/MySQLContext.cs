using Microsoft.EntityFrameworkCore;

namespace RESTfullAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> TablePerson { get; set; }
        public DbSet<Book> TableBook { get; set; }
    }
}

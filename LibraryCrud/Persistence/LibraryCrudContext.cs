using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryCrud.Persistence
{
    public class LibraryCrudContext : DbContext
    {
        public LibraryCrudContext(DbContextOptions options) : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    

    }
    
}

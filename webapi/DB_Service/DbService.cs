using Microsoft.EntityFrameworkCore;
using webapi.Model.BD_Model;

namespace webapi.DB_Service
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<EnrolleeModel> ListEnrolle { get; set; }
        //public DbSet<OneEnrolleListModel> OneEnrolle {  get; set; }
    }
}

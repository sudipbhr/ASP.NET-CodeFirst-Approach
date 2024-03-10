using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class StudentDBContext : DbContext // studentDb context inherites Db context class
    {
        //creating constructor , parameterized constructor
        //dbcontextoption carries informatio like connection string, database
        public StudentDBContext(DbContextOptions options): base(options) //call parent class constructor i.e constructor of Db Context
        {

            
        }
        public DbSet<Student> Students { get; set; } //used to present the  name of the table in database
    }
}

/*
 Dbcontext is used to interact with the underlying database
used to manage database connection and is used to retrieve and save data in database
instance of dbcontext represetn sessio with the database which can be used to query and save insetace of your
entities to database

 * */


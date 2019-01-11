namespace WebApplication1.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication1.Models;

    public class SalesERPDAL : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
    }


}
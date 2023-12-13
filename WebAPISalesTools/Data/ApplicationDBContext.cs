using Microsoft.EntityFrameworkCore;
using WebAPISalesTools.Models;

namespace WebAPISalesTools.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<OrderFromSAP> Order_List { get; set; }

    }
}

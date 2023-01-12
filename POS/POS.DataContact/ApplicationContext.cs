using Microsoft.EntityFrameworkCore;
using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Category> categoryEntities => Set<Category>();
        public DbSet<Products> productsEntities => Set<Products>();
        public DbSet<Supplier> supplierEntities => Set<Supplier>();
        public DbSet<Customers> customersEntities => Set<Customers>();
        public DbSet<Orders> ordersEntities => Set<Orders>();
        public DbSet<OrderDetails> orderDetailsEntities => Set<OrderDetails>();
        public DbSet<Shippers> shipperEntities => Set<Shippers>();
        public DbSet<Employees> employeeEntities => Set<Employees>();

    }
}

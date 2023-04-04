using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Service_PK.Model;

public class ApplicationContext : DbContext
{
    public DbSet<employee> employees { get; set; } = null!;

    public DbSet<autopart> autoparts { get; set; } = null!;
    public DbSet<autopartinorder> Autopartinorder { get; set; } = null!;
    public DbSet<warehouse> warehouses { get; set; } = null!;
    public DbSet<typeservices> TypeServices { get; set; } = null!;
    public DbSet<typeautopart> typeautoparts { get; set; } = null!;
    public DbSet<services> Services { get; set; } = null!;
    public DbSet<Pay_type> Pay_Types { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<PK> PKs { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<carinorder> carinorders { get; set; } = null!;
    public DbSet<employeeinorder> employeeinorders { get; set; } = null!;
    public DbSet<type_pk> type_pks { get; set; } = null!;
    public DbSet<serviceinorder> Serviceinorder { get; set; } = null!;
    public DbSet<autopartinwarehouse> Autopartinwarehouses { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=2244;database=pk_service;",
            new MySqlServerVersion(new Version(8, 0, 25)));
    }
}
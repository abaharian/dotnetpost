
using Microsoft.EntityFrameworkCore;

namespace dotnetpost.models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(GlobalConfig.getInstanse().ConnectionString);


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

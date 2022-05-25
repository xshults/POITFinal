 using Microsoft.EntityFrameworkCore;
 using SkuskaApp.DTOs;

 public class DataContext : DbContext
 {
     public DbSet<DataDTO> DataDtos { get; set; }

     public DataContext(DbContextOptions<DataContext> options) : base(options){}

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     { 
         modelBuilder.ApplyConfiguration(new DataConfiguration());
     }
 }
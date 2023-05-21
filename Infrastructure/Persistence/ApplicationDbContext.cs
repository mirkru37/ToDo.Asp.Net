using Application.Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : IdentityDbContext<UserEntity>, IApplicationDBContext
{
    #region Ctor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    #endregion
    
    #region DbSet   
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    #endregion
    
    #region Methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>()
            .HasOne(t => t.User)             // Зв'язок з моделлю User
            .WithMany(u => u.Tasks)          // Зв'язок з колекцією Tasks
            .HasForeignKey(t => t.UserID);

        modelBuilder.Entity<TagEntity>()
            .HasMany(t => t.Tasks)
            .WithMany(t => t.Tags)
            .UsingEntity(j => j.ToTable("TaskTag"));
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}
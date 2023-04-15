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
    public DbSet<FolderEntity> Folders { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    #endregion
    
    #region Methods
    public Task<int> SaveChangesAsync()
    {
        base.SaveChanges();
        return new Task<int>(() => { return 1;});
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TagEntity>()
            .HasMany(t => t.Tasks)
            .WithMany(t => t.Tags)
            .UsingEntity(j => j.ToTable("TaskTag"));

        modelBuilder.Entity<FolderEntity>()
            .HasMany(f => f.Tasks)
            .WithOne(t => t.Folder)
            .HasForeignKey(t => t.Id)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<FolderEntity>()
            .HasMany(f => f.Users)
            .WithMany(u => u.Folders)
            .UsingEntity(j => j.ToTable("FolderUser"));
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<FolderEntity> Folders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}
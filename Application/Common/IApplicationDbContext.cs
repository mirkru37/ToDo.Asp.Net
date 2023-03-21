class ApplicationContext : DbContext
{

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<TagEntity> Tag { get; set; }
    public DbSet<FolderEntity> Task_Category { get; set; }

    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;user=root;password=159357;database=mydb;");
    }
}
namespace Domain;

public class FolderEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsPublic { get; set; }
    public virtual List<TaskEntity> Tasks { get; set; }
    public virtual List<UserEntity> Users { get; set; }
}
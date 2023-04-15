namespace Domain;

public class TaskEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Deadline { get; set; }
    public int Priority { get; set; }
    public virtual List<TagEntity> Tags { get; set; }
    public virtual FolderEntity Folder { get; set; }
    public virtual UserEntity User { get; set; }
}
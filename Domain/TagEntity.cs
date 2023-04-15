namespace Domain;

public class TagEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public virtual List<TaskEntity> Tasks { get; set; }
}
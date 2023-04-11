namespace Domain;

public class TagEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<TaskEntity> Tasks { get; set; }
}
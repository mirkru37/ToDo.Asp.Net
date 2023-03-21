public class UserEntity
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public virtual List<TaskEntity> Tasks { get; set; }
    public virtual List<FolderEntity> Folders { get; set; }
}